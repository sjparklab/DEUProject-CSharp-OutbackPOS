using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DEUProject_CSharp_OutbackPOS.Data;
using DEUProject_CSharp_OutbackPOS.Model;

namespace DEUProject_CSharp_OutbackPOS
{
    internal class AuthClass
    {
        UserRepository userRepository = new UserRepository();
        public string Id { get; set; }
        public string Pw { get; set; }
        public string Name { get; set; }
        public string Position { get; set; }


        public bool Register(string UserId, string Password, string Name, string Position = "관리자")
        {
            if (string.IsNullOrWhiteSpace(UserId) || string.IsNullOrWhiteSpace(Password) || string.IsNullOrWhiteSpace(Name))
            {
                MessageBox.Show("입력되지 않은 값이 있습니다!");
                return false;
            }
            try
            {
                User user = new User(UserId, Password, Name, Position);
                userRepository.AddUser(user);
                return true;
            } 
            catch (Exception ex)
            {
                MessageBox.Show($"등록 중 오류가 발생했습니다: {ex.Message}");
                return false;
            }
        }

        public bool Login(string UserId, string Password)
        {
            if (string.IsNullOrWhiteSpace(UserId) || string.IsNullOrWhiteSpace(Password))
            {
                MessageBox.Show("입력되지 않은 값이 있습니다!");
                return false;
            }
            try
            {
                User user = userRepository.findByUserId(UserId);
                if (user == null)
                {
                    MessageBox.Show("사용자를 검색하지 못했습니다!");
                    return false;
                }
                if(user.Password.Equals(Password))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"등록 중 오류가 발생했습니다: {ex.Message}");
                return false;
            }
        }

    }
}
