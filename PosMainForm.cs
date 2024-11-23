using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DEUProject_CSharp_OutbackPOS.Model;

namespace DEUProject_CSharp_OutbackPOS
{
    public partial class PosMainForm : Form
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Position { get; set; }
        TableRepository tableRepository = new TableRepository();

        public PosMainForm(User user)
        {
            this.Id = user.UserId;
            this.UserName = user.UserName;
            this.Position = user.Position;
            InitializeComponent();
            txtUserInform.Text = $"사용자 ID: {Id}\n사용자 이름: {UserName}\n직책: {Position}";
        }

        private void btnTableManage_Click(object sender, EventArgs e)
        {
            TableManageForm tableManageForm = new TableManageForm(this);
            tableManageForm.Show();
            //this.Hide();
        }

        private void PosMainForm_Load(object sender, EventArgs e)
        {
            LoadTablePanel();
        }

        internal void LoadTablePanel()
        {
            tableLayoutMenuPanel.Controls.Clear();

            List<Table> tables = tableRepository.GetAllTables();
            foreach (Table table in tables)
            {
                Panel tablePanel = new Panel
                {
                    Name = table.Name,
                    Location = new Point(table.X, table.Y),
                    Width = table.Width,
                    Height = table.Height,
                    BackColor = Color.White,
                    BorderStyle = BorderStyle.FixedSingle,
                };

                Label tableNameLable = new Label
                {
                    Text = tablePanel.Name,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter
                };
                tableNameLable.MouseClick += (LabelSender, LabelEvent) => { TablePanel_MouseClick(tablePanel, LabelEvent); };
                tablePanel.Controls.Add(tableNameLable);
                tablePanel.MouseClick += TablePanel_MouseClick;
                tableLayoutMenuPanel.Controls.Add(tablePanel);
            }
        }

        private void TablePanel_MouseClick(object sender, MouseEventArgs e)
        {
            OrderAndPayForm orderAndPayForm = new OrderAndPayForm(this, (Panel) sender);
            orderAndPayForm.Show();
        }

        private void btnCustomerManage_Click(object sender, EventArgs e)
        {

        }

        
    }
}
