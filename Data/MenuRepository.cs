using DEUProject_CSharp_OutbackPOS.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEUProject_CSharp_OutbackPOS.Data
{
    public class MenuRepository
    {
        private readonly string connectionString = "Data Source=database.db;Version=3;";

        // 모든 메뉴 가져오기
        public List<Menu> GetAllMenus()
        {
            var menus = new List<Menu>();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Menu";

                using (var command = new SQLiteCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            menus.Add(new Menu
                            {
                                MenuID = Convert.ToInt32(reader["MenuID"]),
                                Name = reader["Name"].ToString(),
                                Category = reader["Category"].ToString(),
                                Price = Convert.ToDecimal(reader["Price"]),
                                Description = reader["Description"].ToString(),
                                Stock = Convert.ToInt32(reader["Stock"])
                            });
                        }
                    }
                }

                connection.Close();
            }

            return menus;
        }

        // 메뉴 추가
        public void AddMenu(Menu menu)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Menu (Name, Category, Price, Description, Stock) VALUES (@Name, @Category, @Price, @Description, @Stock)";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", menu.Name);
                    command.Parameters.AddWithValue("@Category", menu.Category);
                    command.Parameters.AddWithValue("@Price", menu.Price);
                    command.Parameters.AddWithValue("@Description", menu.Description);
                    command.Parameters.AddWithValue("@Stock", menu.Stock);

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        // 메뉴 수정
        public void UpdateMenu(Menu menu)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = "UPDATE Menu SET Name = @Name, Category = @Category, Price = @Price, Description = @Description, Stock = @Stock WHERE MenuID = @MenuID";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MenuID", menu.MenuID);
                    command.Parameters.AddWithValue("@Name", menu.Name);
                    command.Parameters.AddWithValue("@Category", menu.Category);
                    command.Parameters.AddWithValue("@Price", menu.Price);
                    command.Parameters.AddWithValue("@Description", menu.Description);
                    command.Parameters.AddWithValue("@Stock", menu.Stock);

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        // 메뉴 삭제
        public void DeleteMenu(int menuID)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Menu WHERE MenuID = @MenuID";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MenuID", menuID);

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }
    }
}
