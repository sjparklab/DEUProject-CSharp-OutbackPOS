using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEUProject_CSharp_OutbackPOS.Model;

namespace DEUProject_CSharp_OutbackPOS.Data
{
    // 사용자 정보 조회 Repository
    public class UserRepository
    {
        public List<User> GetAllUsers()
        {
            var users = new List<User>();
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM Users;";
                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        users.Add(new User
                        {
                            Id = reader.GetInt32(0),
                            UserId = reader.GetString(1),
                            UserName = reader.GetString(3),
                            Position = reader.GetString(4),
                        });
                    }
                }
            }
            return users;
        }

        public User findByUserId(string UserId)
        {
            User user = null;
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string query = "SELECT * FROM Users WHERE UserId = @UserId;";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", UserId);
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read()) // 데이터 존재 여부 확인
                        {
                            user = new User
                            {
                                Id = reader.GetInt32(0),
                                UserId = reader.GetString(1),
                                Password = reader.GetString(2),
                                UserName = reader.GetString(3),
                                Position = reader.GetString(4),
                            };
                        }
                    }
                }
            }
            return user;
        }

        public void AddUser(User user)
        {
            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                string query = "INSERT INTO Users (UserId, Password, Name, Position) " +
                    "VALUES (@UserId, @Password, @Name, @Position);";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@UserId", user.UserId);
                    command.Parameters.AddWithValue("@Password", user.Password);
                    command.Parameters.AddWithValue("@Name", user.UserName);
                    command.Parameters.AddWithValue("@Position", user.Position);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
