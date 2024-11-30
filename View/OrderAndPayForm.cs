using DEUProject_CSharp_OutbackPOS.Controller;
using DEUProject_CSharp_OutbackPOS.CustomControl;
using DEUProject_CSharp_OutbackPOS.Data;
using DEUProject_CSharp_OutbackPOS.Model;
using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace DEUProject_CSharp_OutbackPOS.View
{
    public partial class OrderAndPayForm : Form
    {
        OrderController orderController = new OrderController();
        MenuRepository menuRepository = new MenuRepository();
        BindingList<OutbackOrderItem> currentOrderItems = new BindingList<OutbackOrderItem>();
        CustomTablePanel selectedTable;

        public OrderAndPayForm(PosMainForm refreshingForm, CustomTablePanel table)
        {
            InitializeComponent();
            LoadMenu();
            lbltableName.Text = table.Name;
            nowMenuGridView.AutoGenerateColumns = false;
            nowMenuGridView.DataSource = currentOrderItems;
            selectedTable = table;
        }

        public void LoadMenu()
        {
            var menus = menuRepository.GetAllMenus();

            menuGrid.DataSource = menus;
            var uniqueCategories = menus
                .Select(item => item.Category)
                .Distinct() // 중복제거               
                .ToList();

            categoryComboBox.DataSource = uniqueCategories;
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
                nowMenuGridView.Refresh();
            }
        }

        private void nowMenuGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            Console.Write("Debugging TEST\n");
            if (e.ColumnIndex >= 0 && nowMenuGridView.Columns[e.ColumnIndex].Name == "Quantity")
            {
                // 수정된 수량 가져오기
                int rowIndex = e.RowIndex;
                var orderItem = currentOrderItems[rowIndex];

                // 새 수량 설정
                int newQuantity = Convert.ToInt32(nowMenuGridView.Rows[rowIndex].Cells["Quantity"].Value);
                orderItem.Quantity = newQuantity;

                if(orderItem.Quantity <= 0)
                {
                    currentOrderItems.RemoveAt(rowIndex);
                }

                // UI 업데이트
                nowMenuGridView.Refresh();
            }
        }

        private void btnTableOrder_Click(object sender, EventArgs e)
        {
            OutbackOrder order = new OutbackOrder
            {
                outbackOrderItem = currentOrderItems,
                TableID = (int) selectedTable.Tag,
                TableName = selectedTable.Name,

            };

            // 주문 처리 로직
            orderController.AddNewOrder(order);
            this.Close();
        }
    }
}