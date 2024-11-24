using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DEUProject_CSharp_OutbackPOS.Data
{
    public static class DatabaseHelper
    {
        private static string connectionString = "Data Source=database.db;Version=3;";

        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(connectionString);
        }

        public static void Initialize()
        {
            string dbFilePath = "database.db";

            // 데이터베이스 파일이 없으면 생성
            if (!File.Exists(dbFilePath))
            {
                SQLiteConnection.CreateFile(dbFilePath);
                Console.WriteLine("SQLite 데이터베이스 파일 생성 완료!");
            }
            else
            {
                Console.WriteLine("데이터베이스 파일이 이미 존재합니다.");
            }

            using (var connection = GetConnection())
            {
                connection.Open();
                Console.WriteLine("SQLite 데이터베이스 연결 성공!");

                // 테이블 생성 쿼리
                string createTableQuery = @"
                    CREATE TABLE IF NOT EXISTS TableLayout (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        X INTEGER NOT NULL,
                        Y INTEGER NOT NULL,
                        Width INTEGER NOT NULL,
                        Height INTEGER NOT NULL
                    );
                    CREATE TABLE IF NOT EXISTS Users (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT, 
                        UserId TEXT NOT NULL UNIQUE, 
                        Password TEXT NOT NULL, 
                        Name TEXT NOT NULL, 
                        Position TEXT NOT NULL
                    );
                    CREATE TABLE IF NOT EXISTS Menu (
                        MenuID INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        Category TEXT NOT NULL,
                        Price REAL NOT NULL,
                        Stock INTEGER NOT NULL,
                        IngredientOrigin TEXT,
                        Description TEXT, -- 설명을 저장하는 컬럼 추가
                        Size TEXT,
                        Category2 TEXT,
                        Doneness TEXT,
                        CookingStyle TEXT,
                        SteakOption TEXT,
                        PremiumSidesOption TEXT,
                        PastaOption TEXT,
                        DrinkOption TEXT,
                        Acidity INTEGER,
                        Sweetness INTEGER,
                        Body INTEGER,
                        Tannin INTEGER
                    );
                ";

                using (var command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("초기 테이블 생성 완료!");
                }

                string checkUserQuery = "SELECT COUNT(*) FROM Users;";
                using (var userCommand = new SQLiteCommand(checkUserQuery, connection))
                {
                    int userCount = Convert.ToInt32(userCommand.ExecuteScalar());
                    if (userCount == 0)
                    {
                        // 기본 관리자 계정 비밀번호 해싱
                        string hashedPassword = BCrypt.Net.BCrypt.HashPassword("1234");

                        // 기본 관리자 계정 삽입
                        string insertAdminQuery = @"
                            INSERT INTO Users (UserId, Password, Name, Position)
                            VALUES ('admin', @Password, 'Administrator', 'Admin');
                        ";
                        using (var insertUserCommand = new SQLiteCommand(insertAdminQuery, connection))
                        {
                            insertUserCommand.Parameters.AddWithValue("@Password", hashedPassword);
                            insertUserCommand.ExecuteNonQuery();
                            Console.WriteLine("기본 관리자 계정(admin:1234) 생성 완료!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("기본 관리자 계정이 이미 존재합니다.");
                    }
                }
                // 데이터 존재 여부 확인
                string checkDataQuery = "SELECT COUNT(*) FROM Menu;";
                using (var checkCommand = new SQLiteCommand(checkDataQuery, connection))
                {
                    int menuCount = Convert.ToInt32(checkCommand.ExecuteScalar());
                    if (menuCount == 0)
                    {
                        // 초기 데이터 삽입
                        string insertDataQuery = @"
                            INSERT INTO Menu (Name, Category, Price, Description, Stock, IngredientOrigin, Size, Category2, Doneness, CookingStyle, SteakOption, PremiumSidesOption, PastaOption, DrinkOption, Acidity, Sweetness, Body, Tannin)
                            VALUES
                            -- Special Steaks & Back Ribs
                            ('워커바웃 웰링턴 스테이크', 'SteakMenu', 67000, 'Delicious steak with layers', 10, 'Australia', NULL, NULL, 'Medium', 'Baked', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
                            ('갈릭 립아이', 'SteakMenu', 49900, 'Grilled steak with garlic topping', 15, 'Australia', NULL, NULL, 'Medium', 'Grilled', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
                            ('베이비 백 립 (600g)', 'SteakMenu', 49900, 'Smoked baby back ribs with BBQ sauce', 20, 'USA', NULL, NULL, NULL, 'Smoked', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),

                            -- Beverages
                            ('뱅 쇼', 'DrinkMenu', 8700, 'Hot mulled wine', 30, NULL, NULL, 'Hot Drink', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
                            ('시그니처 핫 초콜릿', 'DrinkMenu', 6700, 'Rich hot chocolate', 30, NULL, NULL, 'Hot Drink', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),

                            -- Draft Beers
                            ('테라 생맥주 (340ml)', 'DrinkMenu', 6000, 'Fresh draft beer', 50, NULL, '340ml', 'Beer', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
                            ('테라 생맥주 (1700ml)', 'DrinkMenu', 25000, 'Fresh draft beer', 20, NULL, '1700ml', 'Beer', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),

                            -- Wines
                            ('하우스 와인 Red (Glass)', 'WineMenu', 9000, 'Smooth red wine by the glass', 40, NULL, 'Glass', 'Wine', NULL, NULL, NULL, NULL, NULL, NULL, 3, 4, 3, 4),
                            ('하우스 와인 White (Glass)', 'WineMenu', 9000, 'Crisp white wine by the glass', 40, NULL, 'Glass', 'Wine', NULL, NULL, NULL, NULL, NULL, NULL, 4, 2, 2, 1),
                            ('울프 블라스 빌야라 쉬라즈 (Bottle)', 'WineMenu', 45000, 'Bold and rich Shiraz', 15, NULL, 'Bottle', 'Wine', NULL, NULL, NULL, NULL, NULL, NULL, 4, 3, 4, 4);
                        ";

                        using (var insertCommand = new SQLiteCommand(insertDataQuery, connection))
                        {
                            insertCommand.ExecuteNonQuery();
                            Console.WriteLine("초기 데이터 삽입 완료!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("초기 데이터가 이미 존재합니다.");
                    }
                }
            }
        }
    }
}
