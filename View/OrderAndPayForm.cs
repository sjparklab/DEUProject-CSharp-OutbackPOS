using DEUProject_CSharp_OutbackPOS.Controller;
using DEUProject_CSharp_OutbackPOS.CustomControl;
using DEUProject_CSharp_OutbackPOS.Data;
using DEUProject_CSharp_OutbackPOS.Model;
using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace DEUProject_CSharp_OutbackPOS.View
{
    public partial class OrderAndPayForm : Form
    {
        OrderController orderController = new OrderController();
        TableController tableController = new TableController();
        MenuRepository menuRepository = new MenuRepository();
        BindingList<OutbackOrderItem> currentOrderItems = new BindingList<OutbackOrderItem>();
        BindingList<OutbackOrderItem> nowOrderedItems = new BindingList<OutbackOrderItem>();
        CustomTablePanel selectedTable;
        PosMainForm posMainForm;

        // 초기화 및 데이터 생성, 메인폼 연결
        public OrderAndPayForm(PosMainForm refreshingForm, CustomTablePanel table)
        {
            InitializeComponent();
            LoadMenu();
            lbltableName.Text = table.Name;
            addMenuGridView.AutoGenerateColumns = false;
            addMenuGridView.DataSource = currentOrderItems;
            nowMenuGridView.AutoGenerateColumns = false;
            nowMenuGridView.DataSource = nowOrderedItems;
            selectedTable = table;
            posMainForm = refreshingForm;
            LoadUnpaidOrderItems();
        }

        public void LoadMenu()
        {
            var menus = menuRepository.GetAllMenus();

            menuGrid.DataSource = menus;
            var uniqueCategories = menus
                .Select(item => item.Category)
                .Distinct()
                .ToList();
            uniqueCategories.Insert(0, "All"); // Add "All" category

            categoryComboBox.DataSource = uniqueCategories;

            var uniqueIngredientOrigins = menus
                .Select(item => item.IngredientOrigin)
                .Where(origin => !string.IsNullOrEmpty(origin))
                .Distinct()
                .ToList();
            uniqueIngredientOrigins.Insert(0, "All"); // Add "All" ingredient origin

            comboBoxIngredientOrigin.DataSource = uniqueIngredientOrigins;
        }

        private void menuGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // 메뉴 가져오기
                DataGridViewRow row = menuGrid.Rows[e.RowIndex];
                int menuId = Convert.ToInt32(row.Cells["MenuID"].Value);
                string name = row.Cells["Name"].Value.ToString();
                decimal price = Convert.ToDecimal(row.Cells["Price"].Value);

                // 메뉴 추가 또는 업데이트
                OutbackOrderItem existingItem = currentOrderItems.FirstOrDefault(orderItem => orderItem.outbackMenuItem.MenuID == menuId);
                if (existingItem != null)
                {
                    existingItem.Quantity++;
                }
                else
                {
                    currentOrderItems.Add(new OutbackOrderItem
                    { 
                        Quantity = 1,
                        outbackMenuItem = new OutbackMenuItem
                        {
                            MenuID = menuId,
                            MenuName = name,
                            Price = price,
                        }
                    });
                }

                // DataGridView 갱신
                addMenuGridView.Refresh();
            }
        }

        private void addMenuGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && addMenuGridView.Columns[e.ColumnIndex].Name == "Quantity")
            {
                // 수정된 수량 가져오기
                int rowIndex = e.RowIndex;
                var orderItem = currentOrderItems[rowIndex];

                // 새 수량 설정
                int newQuantity = Convert.ToInt32(addMenuGridView.Rows[rowIndex].Cells["Quantity"].Value);
                orderItem.Quantity = newQuantity;

                if(orderItem.Quantity <= 0)
                {
                    currentOrderItems.RemoveAt(rowIndex);
                }

                // UI 업데이트
                addMenuGridView.Refresh();
            }
        }

        private void btnTableOrder_Click(object sender, EventArgs e)
        {
            Table table = (Table) selectedTable.Tag;
            OutbackOrder order = new OutbackOrder
            {
                outbackOrderItem = currentOrderItems,
                TableID = table.Id,
                TableName = table.Name,
            };

            // 주문 처리 로직
            orderController.AddNewOrder(order);
            table.IsOccupied = true;
            tableController.UpdateTable(table);
            posMainForm.LoadTables();
            this.Close();
        }

        private void btnTablePay_Click(object sender, EventArgs e)
        {
            var table = (Table)selectedTable.Tag; // 선택된 테이블 정보 가져오기

            // 결제 처리
            PaymentController paymentController = new PaymentController();
            paymentController.ProcessPayment(table.Id, "Card"); // 결제 방식은 Card로 예시

            // UI 업데이트
            selectedTable.BackColor = Color.White;
            selectedTable.Controls.Clear(); // 기존 UI 초기화
            posMainForm.LoadTables(); // 테이블 다시 로드
            MessageBox.Show("결제가 완료되었습니다.");
            this.Close();
        }

        private void LoadUnpaidOrderItems()
        {
            // 선택된 테이블 정보 가져오기
            Table table = (Table)selectedTable.Tag;

            // 미결제 주문 항목 가져오기
            var unpaidOrderItems = orderController.GetUnpaidOrderItemsByTableId(table.Id);

            // 기존 목록에 동일한 MenuID가 있으면 수량 증가, 없으면 추가
            foreach (var item in unpaidOrderItems)
            {
                var existingItem = nowOrderedItems.FirstOrDefault(x => x.outbackMenuItem.MenuID == item.outbackMenuItem.MenuID);

                if (existingItem != null)
                {
                    // 기존 항목이 있으면 수량 증가
                    existingItem.Quantity += item.Quantity;
                }
                else
                {
                    // 새 항목 추가
                    nowOrderedItems.Add(item);
                }
            }

            // DataGridView 갱신
            nowMenuGridView.Refresh();
        }

        private void nowMenuGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && nowMenuGridView.Columns[e.ColumnIndex].Name == "Quantity")
            {
                // 수정된 수량 가져오기
                int rowIndex = e.RowIndex;
                var orderItem = nowOrderedItems[rowIndex];

                // 새 수량 설정
                int newQuantity = Convert.ToInt32(nowMenuGridView.Rows[rowIndex].Cells["Quantity"].Value);
                orderItem.Quantity = newQuantity;

                if (orderItem.Quantity <= 0)
                {
                    nowOrderedItems.RemoveAt(rowIndex);
                }

                // UI 업데이트
                nowMenuGridView.Refresh();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string id = txtBoxID.Text;
            decimal price;
            decimal.TryParse(txtBoxPrice.Text, out price);
            string category1 = categoryComboBox.SelectedItem?.ToString();
            string origin = comboBoxIngredientOrigin.SelectedItem?.ToString();

            var menus = menuRepository.GetAllMenus();

            var filteredMenus = menus.Where(menu =>
                (string.IsNullOrEmpty(id) || menu.MenuID.ToString().Contains(id)) &&
                (price == 0 || menu.Price <= price) &&
                ((category1 == "All" || category1 == null) || (string.IsNullOrEmpty(category1) || menu.Category == category1)) &&
                ((origin == "All" || origin == null) || (string.IsNullOrEmpty(origin) || menu.IngredientOrigin == origin))
            ).ToList();

            menuGrid.DataSource = filteredMenus;
        }

    }
}