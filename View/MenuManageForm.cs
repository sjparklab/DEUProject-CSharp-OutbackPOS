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
    }
}