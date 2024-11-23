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
                        Description TEXT,
                        Stock INTEGER NOT NULL
                    );
                ";

                using (var command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("초기 테이블 생성 완료!");
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
                            INSERT INTO Menu (Name, Category, Price, Description, Stock)
                            VALUES
                            ('Outback Special Steak', 'Steak', 30000, 'Tender and juicy steak', 10000),
                            ('Bloomin Onion', 'Appetizer', 9000, 'Crispy onion rings', 15000),
                            ('Chocolate Thunder', 'Dessert', 7000, 'Rich chocolate brownie', 20000),
                            ('Coke', 'Beverage', 3000, 'Refreshing soda', 50000);
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
