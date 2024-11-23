using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DEUProject_CSharp_OutbackPOS.Data;
using DEUProject_CSharp_OutbackPOS.Model;

namespace DEUProject_CSharp_OutbackPOS
{
    public partial class OrderAndPayForm : Form
    {
        MenuRepository menuRepository = new MenuRepository();
        public OrderAndPayForm(PosMainForm refreshingForm, Panel table)
        {
            InitializeComponent();

            LoadMenu();
        }

        public void LoadMenu()
        {
            var menus = menuRepository.GetAllMenus();
            menuGrid.DataSource = menus;
        }

        private void menuGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // 선택된 행 데이터 가져오기
                DataGridViewRow row = menuGrid.Rows[e.RowIndex];

                int menuId = Convert.ToInt32(row.Cells["MenuID"].Value);
                string name = row.Cells["Name"].Value.ToString();
                string category = row.Cells["Category"].Value.ToString();
                decimal price = Convert.ToDecimal(row.Cells["Price"].Value);

                bool itemExists = false;
                foreach (ListViewItem item in listView1.Items)
                {
                    if (Convert.ToInt32(item.Tag) == menuId) // Tag를 MenuID로 설정
                    {
                        // 수량 증가
                        int currentQuantity = Convert.ToInt32(item.SubItems[2].Text);
                        currentQuantity++;

                        // 총 가격 업데이트
                        item.SubItems[2].Text = currentQuantity.ToString();
                        item.SubItems[3].Text = (currentQuantity * price).ToString("C");

                        itemExists = true;
                        break;
                    }
                }

                if (!itemExists)
                {
                    // 새로운 항목 추가
                    ListViewItem listItem = new ListViewItem(name);
                    listItem.Tag = menuId; // Tag에 MenuID 저장
                    listItem.SubItems.Add(price.ToString("C"));
                    listItem.SubItems.Add("1"); // 초기 수량
                    listItem.SubItems.Add(price.ToString("C")); // 총 가격 (수량 * 단가)

                    listView1.Items.Add(listItem);
                }
            }
        }
    }
}