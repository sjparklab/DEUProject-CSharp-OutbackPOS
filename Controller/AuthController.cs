using System;
using System.Windows.Forms;
using DEUProject_CSharp_OutbackPOS.Data;
using DEUProject_CSharp_OutbackPOS.Model;

namespace DEUProject_CSharp_OutbackPOS.Controller
{
    public class AuthController
    {
        UserRepository userRepository = new UserRepository();

        public bool Register(string UserId, string Password, string Name, string Position = "관리자")
        {
            if (string.IsNullOrWhiteSpace(UserId) || string.IsNullOrWhiteSpace(Password) || string.IsNullOrWhiteSpace(Name))
            {
                MessageBox.Show("입력되지 않은 값이 있습니다!");
                return false;
            }
            try
            {
                // 비밀번호 해싱
                string hashedPassword = BCrypt.Net.BCrypt.HashPassword(Password);

                // 사용자 생성 및 저장
                User user = new User(UserId, hashedPassword, Name, Position);
                userRepository.AddUser(user);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"등록 중 오류가 발생했습니다: {ex.Message}");
                return false;
            }
        }

        public User Login(string UserId, string Password)
        {
            if (string.IsNullOrWhiteSpace(UserId) || string.IsNullOrWhiteSpace(Password))
            {
                MessageBox.Show("입력되지 않은 값이 있습니다!");
                return null;
            }
            try
            {
                // 데이터베이스에서 사용자 검색
                User user = userRepository.findByUserId(UserId);
                if (user == null)
                {
                    MessageBox.Show("사용자를 검색하지 못했습니다!");
                    return null;
                }

                // 비밀번호 검증
                if (BCrypt.Net.BCrypt.Verify(Password, user.Password))
                {
                    return user; // 로그인 성공
                }
                else
                {
                    MessageBox.Show("비밀번호가 일치하지 않습니다!");
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"로그인 중 오류가 발생했습니다: {ex.Message}");
                return null;
            }
        }
    }
}