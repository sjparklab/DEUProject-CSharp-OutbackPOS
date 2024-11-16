using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            bool isLoggedIn = authSystem.Login(txtBoxId.Text, txtBoxPW.Text);
            if (isLoggedIn)
            {
                txtLoginResult.Text = "로그인 성공!";
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
    }
}
