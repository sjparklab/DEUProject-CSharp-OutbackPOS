using System;
using System.Data.SQLite;
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
                        Name TEXT NOT NULL UNIQUE,
                        X INTEGER NOT NULL,
                        Y INTEGER NOT NULL,
                        Width INTEGER NOT NULL,
                        Height INTEGER NOT NULL,
                        BorderColorArgb INTEGER NOT NULL,
                        IsOccupied INTEGER NOT NULL DEFAULT 0
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
                        Description TEXT,
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

                    CREATE TABLE IF NOT EXISTS Orders (
                        OrderID INTEGER PRIMARY KEY AUTOINCREMENT,
                        TableID INTEGER NOT NULL,
                        TableName TEXT NOT NULL,
                        OrderTime TEXT NOT NULL,
                        PaymentID INTEGER,
                        FOREIGN KEY (PaymentID) REFERENCES Payments(PaymentID)
                    );

                    CREATE TABLE IF NOT EXISTS OrderItems (
                        OrderItemID INTEGER PRIMARY KEY AUTOINCREMENT,
                        OrderID INTEGER NOT NULL,
                        MenuID INTEGER NOT NULL,
                        MenuName TEXT NOT NULL,
                        Quantity INTEGER NOT NULL,
                        Price REAL NOT NULL,
                        TotalPrice REAL NOT NULL,
                        FOREIGN KEY (OrderID) REFERENCES Orders(OrderID)
                    );

                    CREATE TABLE IF NOT EXISTS Payments (
                        PaymentID INTEGER PRIMARY KEY AUTOINCREMENT, -- 고유 결제 ID
                        TableID INTEGER NOT NULL, -- 테이블 ID
                        TotalAmount REAL NOT NULL, -- 총 결제 금액
                        PaymentMethod TEXT NOT NULL, -- 결제 방법 (예: 카드, 현금 등)
                        PaymentTime TEXT NOT NULL -- 결제 시간
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
                        string insertAccountsQuery = @"
                            INSERT INTO Users (UserId, Password, Name, Position)
                            VALUES
                            ('admin', @PasswordAdmin, 'Administrator', 'Admin'),
                            ('employee1', @PasswordEmployee1, 'Employee 1', 'Employee'),
                            ('employee2', @PasswordEmployee2, 'Employee 2', 'Employee'),
                            ('employee3', @PasswordEmployee3, 'Employee 3', 'Employee'),
                            ('employee4', @PasswordEmployee4, 'Employee 4', 'Employee'),
                            ('general1', @PasswordGeneral1, 'General User 1', 'General'),
                            ('general2', @PasswordGeneral2, 'General User 2', 'General'),
                            ('general3', @PasswordGeneral3, 'General User 3', 'General'),
                            ('general4', @PasswordGeneral4, 'General User 4', 'General'),
                            ('general5', @PasswordGeneral5, 'General User 5', 'General');
                        ";
                        using (var command = new SQLiteCommand(insertAccountsQuery, connection))
                        {
                            // 비밀번호 암호화 또는 기본 비밀번호 설정
                            command.Parameters.AddWithValue("@PasswordAdmin", BCrypt.Net.BCrypt.HashPassword("admin123"));
                            command.Parameters.AddWithValue("@PasswordEmployee1", BCrypt.Net.BCrypt.HashPassword("employee1"));
                            command.Parameters.AddWithValue("@PasswordEmployee2", BCrypt.Net.BCrypt.HashPassword("employee2"));
                            command.Parameters.AddWithValue("@PasswordEmployee3", BCrypt.Net.BCrypt.HashPassword("employee3"));
                            command.Parameters.AddWithValue("@PasswordEmployee4", BCrypt.Net.BCrypt.HashPassword("employee4"));
                            command.Parameters.AddWithValue("@PasswordGeneral1", BCrypt.Net.BCrypt.HashPassword("general1"));
                            command.Parameters.AddWithValue("@PasswordGeneral2", BCrypt.Net.BCrypt.HashPassword("general2"));
                            command.Parameters.AddWithValue("@PasswordGeneral3", BCrypt.Net.BCrypt.HashPassword("general3"));
                            command.Parameters.AddWithValue("@PasswordGeneral4", BCrypt.Net.BCrypt.HashPassword("general4"));
                            command.Parameters.AddWithValue("@PasswordGeneral5", BCrypt.Net.BCrypt.HashPassword("general5"));

                            command.ExecuteNonQuery();
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
                                ('뉴욕 스트립 스테이크', 'SteakMenu', 57000, 'Classic New York strip steak', 12, 'USA', NULL, NULL, 'Medium Rare', 'Grilled', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
                                ('T-본 스테이크', 'SteakMenu', 85000, 'Premium T-bone steak', 8, 'Australia', NULL, NULL, 'Medium', 'Grilled', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),

                                -- Pasta & Sides
                                ('블랙 트러플 크림 파스타', 'PastaMenu', 25900, 'Creamy pasta with black truffle', 25, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'Truffle', NULL, NULL, NULL, NULL, NULL),
                                ('갈릭 쉬림프 파스타', 'PastaMenu', 23900, 'Garlic-flavored pasta with shrimp', 20, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'Shrimp', NULL, NULL, NULL,NULL,NULL),
                                ('스파이시 치킨 파스타', 'PastaMenu', 22900, 'Spicy pasta with grilled chicken', 18, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'Chicken', NULL, NULL, NULL, NULL, NULL),
                                ('아웃백 시그니처 감자튀김', 'SidesMenu', 8900, 'Crispy and seasoned fries', 50, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
                                ('버터 허브 브로콜리', 'SidesMenu', 7900, 'Broccoli with herb butter', 40, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),

                                -- Beverages
                                ('뱅 쇼', 'DrinkMenu', 8700, 'Hot mulled wine', 30, NULL, NULL, 'Hot Drink', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
                                ('시그니처 핫 초콜릿', 'DrinkMenu', 6700, 'Rich hot chocolate', 30, NULL, NULL, 'Hot Drink', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
                                ('테라 생맥주 (340ml)', 'DrinkMenu', 6000, 'Fresh draft beer', 50, NULL, '340ml', 'Beer', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
                                ('테라 생맥주 (1700ml)', 'DrinkMenu', 25000, 'Fresh draft beer', 20, NULL, '1700ml', 'Beer', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),

                                -- Wines
                                ('하우스 와인 Red (Glass)', 'WineMenu', 9000, 'Smooth red wine by the glass', 40, NULL, 'Glass', 'Wine', NULL, NULL, NULL, NULL, NULL, NULL, 3, 4, 3, 4),
                                ('하우스 와인 White (Glass)', 'WineMenu', 9000, 'Crisp white wine by the glass', 40, NULL, 'Glass', 'Wine', NULL, NULL, NULL, NULL, NULL, NULL, 4, 2, 2, 1),
                                ('울프 블라스 빌야라 쉬라즈 (Bottle)', 'WineMenu', 45000, 'Bold and rich Shiraz', 15, NULL, 'Bottle', 'Wine', NULL, NULL, NULL, NULL, NULL, NULL, 4, 3, 4, 4),
                                ('샤르도네 (Bottle)', 'WineMenu', 42000, 'Elegant Chardonnay with a crisp finish', 12, NULL, 'Bottle', 'Wine', NULL, NULL, NULL, NULL, NULL, NULL, 3, 3, 2, 2),
                                ('피노 누아 (Glass)', 'WineMenu', 15000, 'Fruity and light Pinot Noir', 20, NULL, 'Glass', 'Wine', NULL, NULL, NULL, NULL, NULL, NULL, 4, 4, 2, 1),

                                -- Desserts
                                ('초콜릿 러바 케이크', 'DessertMenu', 12900, 'Warm chocolate cake with melted center', 30, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
                                ('뉴욕 치즈 케이크', 'DessertMenu', 11900, 'Rich and creamy cheesecake', 25, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
                                ('애플 크럼블', 'DessertMenu', 10900, 'Warm apple crumble with vanilla ice cream', 20, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL),
                                ('티라미수', 'DessertMenu', 9900, 'Classic tiramisu with espresso flavor', 20, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL);
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
