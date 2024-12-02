using DEUProject_CSharp_OutbackPOS.Controller;
using DEUProject_CSharp_OutbackPOS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DEUProject_CSharp_OutbackPOS.View
{
    public partial class MenuManageForm : Form
    {
        MenuController menuController = new MenuController();
        private List<OutbackMenu> menuList = new List<OutbackMenu>();

        public MenuManageForm()
        {
            InitializeComponent();
            LoadMenusFromDatabase(); // 데이터베이스에서 메뉴 로드
            UpdateMenuListView();   // ListView 갱신
            FillLastColumn();
        }

        // 데이터베이스에서 메뉴 불러오기
        private void LoadMenusFromDatabase()
        {
            menuList = menuController.GetAllMenus();
        }

        // ListView 업데이트
        private void UpdateMenuListView()
        {
            savedMenuListView.Items.Clear();
            foreach (var menu in menuList)
            {
                ListViewItem item = new ListViewItem(menu.MenuID.ToString());
                item.SubItems.Add(menu.Stock.ToString());
                item.SubItems.Add(menu.Name);
                savedMenuListView.Items.Add(item);
            }
        }

        private void FillLastColumn()
        {
            int totalWidth = savedMenuListView.ClientSize.Width;
            int otherColumnsWidth = 0;

            // 마지막 열을 제외한 너비 계산
            for (int i = 0; i < savedMenuListView.Columns.Count - 1; i++)
            {
                otherColumnsWidth += savedMenuListView.Columns[i].Width;
            }

            // 마지막 열의 너비 설정
            savedMenuListView.Columns[savedMenuListView.Columns.Count - 1].Width = totalWidth - otherColumnsWidth;
        }

        private void savedMenuListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (savedMenuListView.SelectedItems.Count > 0)
            {
                // 선택된 항목에서 MenuID 가져오기
                int selectedMenuID = Convert.ToInt32(savedMenuListView.SelectedItems[0].Text);

                // DB에서 메뉴 정보 가져오기
                OutbackMenu menu = menuController.GetMenuById(selectedMenuID);

                if (menu != null)
                {
                    // 가져온 메뉴 정보를 UI에 표시
                    DisplayMenuDetails(menu);
                }
                else
                {
                    MessageBox.Show("메뉴 정보를 가져오지 못했습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // 가져온 메뉴 정보를 UI에 표시
        private void DisplayMenuDetails(OutbackMenu menu)
        {
            detailTxtBoxMenuID.Text = menu.MenuID.ToString();
            detailTxtBoxMenuName.Text = menu.Name;
            detailCmBoxMainCategory.Text = menu.Category;
            detailTxtBoxMenuPrice.Text = menu.Price.ToString("C");
            detailTxtBoxMenuStock.Text = menu.Stock.ToString();
            detailCmBoxOrigin.Text = menu.IngredientOrigin;

            //// 카테고리별 추가 정보를 표시
            //if (menu is SetMenu setMenu)
            //{
            //    lblSteakOption.Text = setMenu.SteakOption;
            //    lblPremiumSidesOption.Text = setMenu.PremiumSidesOption;
            //    lblPastaOption.Text = setMenu.PastaOption;
            //    lblDrinkOption.Text = setMenu.DrinkOption;
            //}
            //else if (menu is DrinkMenu drinkMenu)
            //{
            //    lblSize.Text = drinkMenu.Size;
            //    lblCategory2.Text = drinkMenu.Category2;
            //}
            //else if (menu is SteakMenu steakMenu)
            //{
            //    lblDoneness.Text = steakMenu.Doneness;
            //    lblCookingStyle.Text = steakMenu.CookingStyle;
            //}
        }
    }
}