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

                string createTableQuery = @"
                CREATE TABLE IF NOT EXISTS TableLayout (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    X INTEGER NOT NULL,
                    Y INTEGER NOT NULL,
                    ImagePath TEXT NOT NULL
                ); 
                CREATE TABLE IF NOT EXISTS Users (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT, 
                    UserId TEXT NOT NULL UNIQUE, 
                    Password TEXT NOT NULL, 
                    Name TEXT NOT NULL, 
                    Position TEXT NOT NULL
                );";

                using (var command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("초기 테이블 생성 완료!");
                }
            }
        }
    }
}
