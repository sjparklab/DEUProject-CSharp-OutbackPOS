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
using DEUProject_CSharp_OutbackPOS;

namespace DEUProject_CSharp_OutbackPOS
{
    public partial class LoginForm : Form
    {
        AuthClass authSystem = new AuthClass();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e) // 로그인 버튼 눌렀을 때 동작
        {
            User loggedInUser = authSystem.Login(txtBoxId.Text, txtBoxPW.Text);
            if (loggedInUser != null)
            {
                PosMainForm pos = new PosMainForm(loggedInUser);
                this.Hide();
                pos.FormClosed += (s, args) => this.Close();
                pos.Show();
            }
            else
            {
                txtLoginResult.Text = "로그인 실패!";
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            FontControl.ApplyFontToAllControls(this, "Pretendard-Medium");
        }
    }
}
