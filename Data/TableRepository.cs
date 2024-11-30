using System.Data.SQLite;
using System.Collections.Generic;

namespace DEUProject_CSharp_OutbackPOS.Model
{
    public class TableRepository
    {
        private readonly string connectionString = "Data Source=database.db;Version=3;";

        public void ClearAllTables()
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand("DELETE FROM TableLayout", connection))
                {
                    command.ExecuteNonQuery();
                }
            }
        }

        public void AddTable(Table table)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = @"
                    INSERT INTO TableLayout (Name, X, Y, Width, Height, BorderColorArgb, IsOccupied)
                    VALUES (@Name, @X, @Y, @Width, @Height, @BorderColorArgb, @IsOccupied)
                ";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", table.Name);
                    command.Parameters.AddWithValue("@X", table.X);
                    command.Parameters.AddWithValue("@Y", table.Y);
                    command.Parameters.AddWithValue("@Width", table.Width);
                    command.Parameters.AddWithValue("@Height", table.Height);
                    command.Parameters.AddWithValue("@BorderColorArgb", table.BorderColorArgb);
                    command.Parameters.AddWithValue("@IsOccupied", table.IsOccupied ? 1 : 0);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Table> GetAllTables()
        {
            var tables = new List<Table>();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT Id, Name, X, Y, Width, Height, BorderColorArgb, IsOccupied FROM TableLayout";
                using (var command = new SQLiteCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tables.Add(new Table
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                X = reader.GetInt32(2),
                                Y = reader.GetInt32(3),
                                Width = reader.GetInt32(4),
                                Height = reader.GetInt32(5),
                                BorderColorArgb = reader.GetInt32(6),
                                IsOccupied = reader.GetInt32(7) == 1
                            });
                        }
                    }
                }
            }

            return tables;
        }

        public Table GetTableById(int tableId)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = @"
                    SELECT Id, Name, X, Y, Width, Height, BorderColorArgb, IsOccupied
                    FROM TableLayout
                    WHERE Id = @TableID
                ";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TableID", tableId);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Table
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                X = reader.GetInt32(2),
                                Y = reader.GetInt32(3),
                                Width = reader.GetInt32(4),
                                Height = reader.GetInt32(5),
                                BorderColorArgb = reader.GetInt32(6),
                                IsOccupied = reader.GetInt32(7) == 1
                            };
                        }
                    }
                }
            }

            return null; // 테이블이 없을 경우 null 반환
        }

        public void UpdateTable(Table table)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = @"
                    UPDATE TableLayout
                    SET Name = @Name, X = @X, Y = @Y, Width = @Width, Height = @Height,
                        BorderColorArgb = @BorderColorArgb, IsOccupied = @IsOccupied
                    WHERE Id = @TableID
                ";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", table.Name);
                    command.Parameters.AddWithValue("@X", table.X);
                    command.Parameters.AddWithValue("@Y", table.Y);
                    command.Parameters.AddWithValue("@Width", table.Width);
                    command.Parameters.AddWithValue("@Height", table.Height);
                    command.Parameters.AddWithValue("@BorderColorArgb", table.BorderColorArgb);
                    command.Parameters.AddWithValue("@IsOccupied", table.IsOccupied ? 1 : 0);
                    command.Parameters.AddWithValue("@TableID", table.Id);

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
