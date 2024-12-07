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
using DEUProject_CSharp_OutbackPOS.Controller;
using DEUProject_CSharp_OutbackPOS.CustomException;
using System.Text.RegularExpressions;

namespace DEUProject_CSharp_OutbackPOS.View
{
    public partial class RegisterForm : Form
    {
        AuthController authController = new AuthController();
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                ValidateInputs();
                string userID = txtBoxId.Text;
                string password = txtBoxPW.Text;
                string name = txtBoxUserName.Text;
                string position = txtBoxPosition.Text; // 기본값 설정

                bool isRegistered = authController.Register(userID, password, name, position);
                if (isRegistered)
                {
                    MessageBox.Show("회원가입이 완료되었습니다.", "정보", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("회원가입에 실패했습니다.", "오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        private void ValidateInputs()
        {
            string userID = txtBoxId.Text;
            string password = txtBoxPW.Text;
            string confirmPassword = txtBoxPWConfirm.Text;

            if (string.IsNullOrWhiteSpace(userID))
            {
                throw new UnexpectedInputException("ID를 입력하세요.", 1002);
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                throw new UnexpectedInputException("비밀번호를 입력하세요.", 1003);
            }

            if (password != confirmPassword)
            {
                throw new UnexpectedInputException("비밀번호가 일치하지 않습니다.", 1004);
            }

            if (!IsValidID(userID))
            {
                throw new UnexpectedInputException("ID는 영어 소문자, 대문자, 숫자, 특수문자만 가능합니다.", 1005);
            }

            if (!IsValidPassword(password))
            {
                throw new UnexpectedInputException("비밀번호는 영어 소문자, 대문자, 숫자, 특수문자만 가능합니다.", 1006);
            }
        }

        private bool IsValidID(string id)
        {
            return Regex.IsMatch(id, @"^[a-zA-Z0-9!@#$%^&*()_+=-]+$");
        }

        private bool IsValidPassword(string password)
        {
            return Regex.IsMatch(password, @"^[a-zA-Z0-9!@#$%^&*()_+=-]+$");
        }
    }
}
