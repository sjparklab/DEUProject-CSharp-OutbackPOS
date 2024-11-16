using System;
using System.IO;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DEUProject_CSharp_OutbackPOS.Data;

namespace DEUProject_CSharp_OutbackPOS
{
    internal static class Program
    {

        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
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

            using (var connection = DatabaseHelper.GetConnection())
            {
                connection.Open();
                Console.WriteLine("SQLite 데이터베이스 연결 성공!");

                // 필요한 작업 수행 (예: 테이블 생성, 데이터 삽입 등)
                string createTableQuery = @"CREATE TABLE IF NOT EXISTS Users (Id INTEGER PRIMARY KEY AUTOINCREMENT, UserId TEXT NOT NULL UNIQUE, Password TEXT NOT NULL, Name TEXT NOT NULL, Position TEXT NOT NULL);";

                using (SQLiteCommand command = new SQLiteCommand(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                    Console.WriteLine("Users 테이블 생성 완료!");
                }
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }
    }
}
