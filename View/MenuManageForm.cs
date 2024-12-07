using DEUProject_CSharp_OutbackPOS.Controller;
using DEUProject_CSharp_OutbackPOS.CustomException;
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
            LoadCategoriesToComboBox(); // 카테고리 콤보박스 로드
            LoadOriginsToComboBox(); // 원산지 콤보박스 로드
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
        }

        private void btnMenuSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!int.TryParse(detailTxtBoxMenuStock.Text, out int stock))
                {
                    throw new UnexpectedInputException("재고는 숫자여야 합니다.", 1001);
                }

                OutbackMenu menu = new OutbackMenu
                {
                    MenuID = string.IsNullOrEmpty(detailTxtBoxMenuID.Text) ? 0 : int.Parse(detailTxtBoxMenuID.Text),
                    Name = detailTxtBoxMenuName.Text,
                    Category = detailCmBoxMainCategory.Text,
                    Price = decimal.Parse(detailTxtBoxMenuPrice.Text, System.Globalization.NumberStyles.Currency),
                    Stock = stock,
                    IngredientOrigin = detailCmBoxOrigin.Text
                };

                if (menu.MenuID == 0)
                {
                    // 새 메뉴 추가  
                    menuController.AddMenu(menu);
                    MessageBox.Show("새 메뉴가 추가되었습니다.", "정보", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    // 기존 메뉴 업데이트  
                    menuController.UpdateMenu(menu);
                    MessageBox.Show("메뉴가 업데이트되었습니다.", "정보", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // 메뉴 목록 갱신  
                LoadMenusFromDatabase();
                UpdateMenuListView();
            }
            catch (UnexpectedInputException ex)
            {
                MessageBox.Show(ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("알 수 없는 오류가 발생했습니다: " + ex.Message, "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMenuDelete_Click(object sender, EventArgs e)
        {
            if (savedMenuListView.SelectedItems.Count > 0)
            {
                // 선택된 항목에서 MenuID 가져오기
                int selectedMenuID = Convert.ToInt32(savedMenuListView.SelectedItems[0].Text);

                // 메뉴 삭제 확인
                DialogResult result = MessageBox.Show("정말로 이 메뉴를 삭제하시겠습니까?", "삭제 확인", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    // DB에서 메뉴 삭제
                    menuController.DeleteMenu(selectedMenuID);

                    // 메뉴 목록 갱신
                    LoadMenusFromDatabase();
                    UpdateMenuListView();

                    MessageBox.Show("메뉴가 삭제되었습니다.", "정보", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("삭제할 메뉴를 선택하세요.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnMenuSearch_Click(object sender, EventArgs e)
        {
            string searchNameText = txtBoxMenuNameSearch.Text.ToLower();
            string searchIDText = txtBoxMenuIDSearch.Text.ToLower();
            string searchCategory = cmBoxMainCategorySelect.Text.ToLower();
            string searchOrigin = cmBoxOrigin.Text.ToLower();

            var filteredMenus = menuList.Where(menu =>
                menu.MenuID.ToString().Contains(searchIDText) &&
                menu.Name.ToLower().Contains(searchNameText) &&
                (searchCategory == "all" || menu.Category.ToLower().Contains(searchCategory)) &&
                (searchOrigin == "all" || menu.IngredientOrigin.ToLower().Contains(searchOrigin))
            ).ToList();

            savedMenuListView.Items.Clear();
            foreach (var menu in filteredMenus)
            {
                ListViewItem item = new ListViewItem(menu.MenuID.ToString());
                item.SubItems.Add(menu.Stock.ToString());
                item.SubItems.Add(menu.Name);
                savedMenuListView.Items.Add(item);
            }
        }

        // 카테고리 콤보박스 로드
        private void LoadCategoriesToComboBox()
        {
            var categories = menuList.Select(menu => menu.Category).Distinct().ToList();
            categories.Insert(0, "All"); // "All" 카테고리 추가
            cmBoxMainCategorySelect.Items.Clear();
            detailCmBoxMainCategory.Items.Clear();
            foreach (var category in categories)
            {
                cmBoxMainCategorySelect.Items.Add(category);
                detailCmBoxMainCategory.Items.Add(category);
            }
        }

        // 원산지 콤보박스 로드
        private void LoadOriginsToComboBox()
        {
            var origins = menuList.Select(menu => menu.IngredientOrigin).Where(origin => !string.IsNullOrWhiteSpace(origin)).Distinct().ToList();
            origins.Insert(0, "All"); // "All" 카테고리 추가
            cmBoxOrigin.Items.Clear();
            detailCmBoxOrigin.Items.Clear();
            foreach (var origin in origins)
            {
                cmBoxOrigin.Items.Add(origin);
                detailCmBoxOrigin.Items.Add(origin);
            }
        }

        private void btnMainAddOrigin_Click(object sender, EventArgs e)
        {
            string newOrigin = txtBoxIngredientOriginAdd.Text.Trim();
            if (!string.IsNullOrEmpty(newOrigin) && !cmBoxOrigin.Items.Contains(newOrigin))
            {
                cmBoxOrigin.Items.Add(newOrigin);
                detailCmBoxOrigin.Items.Add(newOrigin);
                txtBoxIngredientOriginAdd.Clear();
            }
        }

        private void btnAddCategory_Click(object sender, EventArgs e)
        {
            string newCategory = txtBoxAddCategory.Text.Trim();
            if (!string.IsNullOrEmpty(newCategory) && !cmBoxMainCategorySelect.Items.Contains(newCategory))
            {
                cmBoxMainCategorySelect.Items.Add(newCategory);
                detailCmBoxMainCategory.Items.Add(newCategory);
                txtBoxAddCategory.Clear();
            }
        }

        private void btnNewMenu_Click(object sender, EventArgs e)
        {
            detailTxtBoxMenuID.Clear();
            detailTxtBoxMenuName.Clear();
            detailCmBoxMainCategory.SelectedIndex = -1;
            detailTxtBoxMenuPrice.Clear();
            detailTxtBoxMenuStock.Clear();
            detailCmBoxOrigin.SelectedIndex = -1;
        }
    }
}