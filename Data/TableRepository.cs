using System;
using System.Collections.Generic;
using System.Data.SQLite;
using DEUProject_CSharp_OutbackPOS.CustomException;

namespace DEUProject_CSharp_OutbackPOS.Model
{
    public class TableRepository
    {
        private readonly string connectionString = "Data Source=database.db;Version=3;";

        public void ClearAllTables()
        {
            string clearTableQuery = "DELETE FROM TableLayout;";
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (var command = new SQLiteCommand(clearTableQuery, connection))
                    {
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SQLiteException ex)
            {
                throw new DatabaseQueryException("Failed to clear all tables.", clearTableQuery, 100);
            }
            catch (Exception ex)
            {
                throw new DatabaseConnectionException("Failed to connect to the database.", connectionString);
            }
        }

        public void AddTable(Table table)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string insertTableQuery = @"
                        INSERT INTO TableLayout (Name, X, Y, Width, Height, IsOccupied, BorderColorArgb)
                        VALUES (@Name, @X, @Y, @Width, @Height, @IsOccupied, @BorderColorArgb);";
                    using (var command = new SQLiteCommand(insertTableQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Name", table.Name);
                        command.Parameters.AddWithValue("@X", table.X);
                        command.Parameters.AddWithValue("@Y", table.Y);
                        command.Parameters.AddWithValue("@Width", table.Width);
                        command.Parameters.AddWithValue("@Height", table.Height);
                        command.Parameters.AddWithValue("@IsOccupied", table.IsOccupied ? 1 : 0);
                        command.Parameters.AddWithValue("@BorderColorArgb", table.BorderColorArgb);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SQLiteException ex)
            {
                throw new DatabaseWriteException("Failed to add table.");
            }
            catch (Exception ex)
            {
                throw new DatabaseConnectionException("Failed to connect to the database.", connectionString);
            }
        }

        public List<Table> GetAllTables()
        {
            var tables = new List<Table>();
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    string selectAllTablesQuery = "SELECT * FROM TableLayout;";
                    using (var command = new SQLiteCommand(selectAllTablesQuery, connection))
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var table = new Table
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                X = reader.GetInt32(2),
                                Y = reader.GetInt32(3),
                                Width = reader.GetInt32(4),
                                Height = reader.GetInt32(5),
                                IsOccupied = reader.GetInt32(7) == 1,
                                BorderColorArgb = reader.GetInt32(6) // BorderColorArgb 값을 읽어옴
                            };
                            tables.Add(table);
                        }
                    }
                }
            }
            catch (SQLiteException ex)
            {
                throw new DatabaseReadException("Failed to retrieve tables.");
            }
            catch (Exception ex)
            {
                throw new DatabaseConnectionException("Failed to connect to the database." , connectionString);
            }
            return tables;
        }

        public void SaveAllTables(IEnumerable<Table> tables)
        {
            try
            {
                ClearAllTables();
                foreach (var table in tables)
                {
                    AddTable(table);
                }
            }
            catch (Exception ex)
            {
                throw new DatabaseWriteException("Failed to save all tables.");
            }
        }
    }
}
