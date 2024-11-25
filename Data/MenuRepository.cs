using DEUProject_CSharp_OutbackPOS.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace DEUProject_CSharp_OutbackPOS.Data
{
    public class MenuRepository
    {
        private readonly string connectionString = "Data Source=database.db;Version=3;";        
        
        // 메뉴 가져오기
        public List<OutbackMenu> GetAllMenus()
        {
            var menus = new List<OutbackMenu>();
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Menu";

                using (var command = new SQLiteCommand(query, connection))
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string category = reader["Category"].ToString();

                        OutbackMenu menu;
                        switch (category)
                        {
                            case "SetMenu":
                                menu = new SetMenu
                                {
                                    SteakOption = reader["SteakOption"].ToString(),
                                    PremiumSidesOption = reader["PremiumSidesOption"].ToString(),
                                    PastaOption = reader["PastaOption"].ToString(),
                                    DrinkOption = reader["DrinkOption"].ToString()
                                };
                                break;

                            case "DrinkMenu":
                                menu = new DrinkMenu
                                {
                                    Size = reader["Size"].ToString(),
                                    Category2 = reader["Category2"].ToString()
                                };
                                break;

                            case "SteakMenu":
                                menu = new SteakMenu
                                {
                                    Doneness = reader["Doneness"].ToString(),
                                    CookingStyle = reader["CookingStyle"].ToString()
                                };
                                break;

                            default:
                                menu = new OutbackMenu();
                                break;
                        }

                        // 공통 속성 설정
                        menu.MenuID = Convert.ToInt32(reader["MenuID"]);
                        menu.Name = reader["Name"].ToString();
                        menu.Category = category;
                        menu.Price = Convert.ToDecimal(reader["Price"]);
                        menu.Stock = Convert.ToInt32(reader["Stock"]);
                        menu.IngredientOrigin = reader["IngredientOrigin"].ToString();

                        menus.Add(menu);
                    }
                }
            }

            return menus;
        }

        // 메뉴 추가
        public void AddMenu(OutbackMenu menu)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = @"
                INSERT INTO Menu 
                (Name, Category, Price, Stock, IngredientOrigin, Size, Category2, Doneness, CookingStyle, SteakOption, 
                 PremiumSidesOption, PastaOption, DrinkOption) 
                VALUES 
                (@Name, @Category, @Price, @Stock, @IngredientOrigin, @Size, @Category2, @Doneness, @CookingStyle, 
                 @SteakOption, @PremiumSidesOption, @PastaOption, @DrinkOption)";

                using (var command = new SQLiteCommand(query, connection))
                {
                    // 공통 속성
                    command.Parameters.AddWithValue("@Name", menu.Name);
                    command.Parameters.AddWithValue("@Category", menu.Category);
                    command.Parameters.AddWithValue("@Price", menu.Price);
                    command.Parameters.AddWithValue("@Stock", menu.Stock);
                    command.Parameters.AddWithValue("@IngredientOrigin", menu.IngredientOrigin ?? (object)DBNull.Value);

                    // 상속 속성
                    if (menu is SetMenu setMenu)
                    {
                        command.Parameters.AddWithValue("@SteakOption", setMenu.SteakOption ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@PremiumSidesOption", setMenu.PremiumSidesOption ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@PastaOption", setMenu.PastaOption ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@DrinkOption", setMenu.DrinkOption ?? (object)DBNull.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@SteakOption", DBNull.Value);
                        command.Parameters.AddWithValue("@PremiumSidesOption", DBNull.Value);
                        command.Parameters.AddWithValue("@PastaOption", DBNull.Value);
                        command.Parameters.AddWithValue("@DrinkOption", DBNull.Value);
                    }

                    if (menu is DrinkMenu drinkMenu)
                    {
                        command.Parameters.AddWithValue("@Size", drinkMenu.Size ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@Category2", drinkMenu.Category2 ?? (object)DBNull.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@Size", DBNull.Value);
                        command.Parameters.AddWithValue("@Category2", DBNull.Value);
                    }

                    if (menu is SteakMenu steakMenu)
                    {
                        command.Parameters.AddWithValue("@Doneness", steakMenu.Doneness ?? (object)DBNull.Value);
                        command.Parameters.AddWithValue("@CookingStyle", steakMenu.CookingStyle ?? (object)DBNull.Value);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@Doneness", DBNull.Value);
                        command.Parameters.AddWithValue("@CookingStyle", DBNull.Value);
                    }

                    command.ExecuteNonQuery();
                }
            }
        }

        // 메뉴 수정
        public void UpdateMenu(OutbackMenu menu)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string query = @"
            UPDATE Menu 
            SET Name = @Name, Category = @Category, Price = @Price, Stock = @Stock, IngredientOrigin = @IngredientOrigin, 
                Size = @Size, Category2 = @Category2, Doneness = @Doneness, CookingStyle = @CookingStyle, 
                SteakOption = @SteakOption, PremiumSidesOption = @PremiumSidesOption, PastaOption = @PastaOption, 
                DrinkOption = @DrinkOption, Acidity = @Acidity, Sweetness = @Sweetness, Body = @Body, Tannin = @Tannin 
            WHERE MenuID = @MenuID";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        // 공통 속성
                        command.Parameters.AddWithValue("@MenuID", menu.MenuID);
                        command.Parameters.AddWithValue("@Name", menu.Name);
                        command.Parameters.AddWithValue("@Category", menu.Category);
                        command.Parameters.AddWithValue("@Price", menu.Price);
                        command.Parameters.AddWithValue("@Stock", menu.Stock);
                        command.Parameters.AddWithValue("@IngredientOrigin", menu.IngredientOrigin ?? (object)DBNull.Value);

                        // 상속된 속성 처리
                        if (menu is DrinkMenu drinkMenu)
                        {
                            command.Parameters.AddWithValue("@Size", drinkMenu.Size ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@Category2", drinkMenu.Category2 ?? (object)DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Size", DBNull.Value);
                            command.Parameters.AddWithValue("@Category2", DBNull.Value);
                        }

                        if (menu is SteakMenu steakMenu)
                        {
                            command.Parameters.AddWithValue("@Doneness", steakMenu.Doneness ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@CookingStyle", steakMenu.CookingStyle ?? (object)DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Doneness", DBNull.Value);
                            command.Parameters.AddWithValue("@CookingStyle", DBNull.Value);
                        }

                        if (menu is SetMenu setMenu)
                        {
                            command.Parameters.AddWithValue("@SteakOption", setMenu.SteakOption ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@PremiumSidesOption", setMenu.PremiumSidesOption ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@PastaOption", setMenu.PastaOption ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@DrinkOption", setMenu.DrinkOption ?? (object)DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@SteakOption", DBNull.Value);
                            command.Parameters.AddWithValue("@PremiumSidesOption", DBNull.Value);
                            command.Parameters.AddWithValue("@PastaOption", DBNull.Value);
                            command.Parameters.AddWithValue("@DrinkOption", DBNull.Value);
                        }

                        if (menu is WineMenu wineMenu)
                        {
                            command.Parameters.AddWithValue("@Acidity", wineMenu.Acidity ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@Sweetness", wineMenu.Sweetness ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@Body", wineMenu.Body ?? (object)DBNull.Value);
                            command.Parameters.AddWithValue("@Tannin", wineMenu.Tannin ?? (object)DBNull.Value);
                        }
                        else
                        {
                            command.Parameters.AddWithValue("@Acidity", DBNull.Value);
                            command.Parameters.AddWithValue("@Sweetness", DBNull.Value);
                            command.Parameters.AddWithValue("@Body", DBNull.Value);
                            command.Parameters.AddWithValue("@Tannin", DBNull.Value);
                        }

                        command.ExecuteNonQuery();
                        Console.WriteLine("메뉴 데이터 수정 완료.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"오류 발생: {ex.Message}");
            }
        }

        // 메뉴 삭제
        public void DeleteMenu(int menuID)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    string query = "DELETE FROM Menu WHERE MenuID = @MenuID";

                    using (var command = new SQLiteCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@MenuID", menuID);
                        command.ExecuteNonQuery();
                        Console.WriteLine("메뉴 데이터 삭제 완료.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"오류 발생: {ex.Message}");
            }
        }
    }
}
