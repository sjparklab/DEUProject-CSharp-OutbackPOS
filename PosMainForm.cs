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
            TableManageForm tableManageForm = new TableManageForm();
            tableManageForm.Show();
            //this.Hide();
        }

        private void PosMainForm_Load(object sender, EventArgs e)
        {
            FontControl.ApplyFontToAllControls(this, "Pretendard-Medium");
        }
    }
}
