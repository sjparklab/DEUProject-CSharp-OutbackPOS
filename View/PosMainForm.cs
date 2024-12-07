using DEUProject_CSharp_OutbackPOS.Controller;
using DEUProject_CSharp_OutbackPOS.CustomControl;
using DEUProject_CSharp_OutbackPOS.Model;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace DEUProject_CSharp_OutbackPOS.View
{
    public partial class PosMainForm : Form
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Position { get; set; }
        TableController tableController;

        public PosMainForm(User user)
        {
            this.Id = user.UserId;
            this.UserName = user.UserName;
            this.Position = user.Position;
            InitializeComponent();
            tableController = new TableController(tableLayoutMenuPanel);
            txtUserInform.Text = $"사용자 ID: {Id}\n사용자 이름: {UserName}\n직책: {Position}";
            LoadTables();
        }

        private void btnTableManage_Click(object sender, EventArgs e)
        {
            TableManageForm tableManageForm = new TableManageForm(this);
            tableManageForm.Show();
        }

        public void LoadTables()
        {
            tableLayoutMenuPanel.Controls.Clear();

            tableController.LoadTables(panel =>
            {
                Table table = (Table)panel.Tag; // panel.Tag에 연결된 테이블 객체를 가져옵니다.

                // 테이블이 점유된 경우 배경색 변경
                if (table.IsOccupied)
                {
                    panel.BackColor = Color.FromArgb(49, 130, 246);
                }
                else
                {
                    panel.BackColor = Color.White;
                }

                // 이벤트 연결
                panel.MouseDown += TablePanel_MouseClick;
                tableLayoutMenuPanel.Controls.Add(panel);
            });
        }

        private void TablePanel_MouseClick(object sender, MouseEventArgs e)
        {
            OrderAndPayForm orderAndPayForm = new OrderAndPayForm(this, (CustomTablePanel) sender);
            orderAndPayForm.Show();
        }

        private void btnCustomerManage_Click(object sender, EventArgs e)
        {

        }

        private void btnMenuManage_Click(object sender, EventArgs e)
        {
            MenuManageForm menuManageForm = new MenuManageForm();
            menuManageForm.Show();
        }

        private void btnReceiptManage_Click(object sender, EventArgs e)
        {
            ReceiptForm receiptForm = new ReceiptForm();
            receiptForm.Show();
        }
    }
}
