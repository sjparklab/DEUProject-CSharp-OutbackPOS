using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEUProject_CSharp_OutbackPOS.Data
{
    public static class DatabaseHelper
    {
        private static string connectionString = "Data Source=database.db;Version=3;";

        public static SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(connectionString);
        }
    }
}
