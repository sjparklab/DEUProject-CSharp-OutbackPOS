using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEUProject_CSharp_OutbackPOS.Model
{
    public class User
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public string Position { get; set; }

        public User() { } // 기본생성자
        public User(string UserId, string Password, string Name, string Position) // 회원가입용 입력 데이터 생성자
        {
            this.UserId = UserId;
            this.Password = Password;
            this.UserName = Name;
            this.Position = Position;
        }
    }
}
