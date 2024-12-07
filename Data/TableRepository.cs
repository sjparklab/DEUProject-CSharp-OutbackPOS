using System;
using System.Collections.Generic;
using System.Data.SQLite;
using DEUProject_CSharp_OutbackPOS.CustomException;

namespace DEUProject_CSharp_OutbackPOS.Model
{
    public class TableRepository
    {
        private readonly string connectionString = "Data Source=database.db;Version=3;";

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
            catch (SQLiteException)
            {
                try
                {
                    throw new DatabaseReadException("Failed to retrieve tables.");
                }
                catch (DatabaseReadException e)
                {
                    Console.WriteLine(e.Message + e.GetErrorType() + e.GetErrorDetails());
                }
            }
            catch (Exception)
            {
                throw new DatabaseConnectionException("Failed to connect to the database." , connectionString);
            }
            return tables;
        }

        public void SaveAllTables(IEnumerable<Table> tables)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        foreach (var table in tables)
                        {
                            string upsertTableQuery = @"INSERT INTO TableLayout (Name, X, Y, Width, Height, IsOccupied, BorderColorArgb)
                                VALUES (@Name, @X, @Y, @Width, @Height, @IsOccupied, @BorderColorArgb)
                                ON CONFLICT(Name) DO UPDATE SET
                                    X = excluded.X,
                                    Y = excluded.Y,
                                    Width = excluded.Width,
                                    Height = excluded.Height,
                                    IsOccupied = excluded.IsOccupied,
                                    BorderColorArgb = excluded.BorderColorArgb;";
                            using (var command = new SQLiteCommand(upsertTableQuery, connection))
                            {
                                command.Parameters.AddWithValue("@Id", table.Id);
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
                        transaction.Commit();
                    }
                }
            }
            catch (SQLiteException)
            {
                try
                {
                    throw new DatabaseWriteException("Failed to save all tables.");
                }
                catch (DatabaseWriteException e)
                {
                    Console.WriteLine(e.Message + e.GetErrorType() + e.GetErrorDetails());
                }
            }
            catch (Exception)
            {
                throw new DatabaseConnectionException("Failed to connect to the database.", connectionString);
            }
        }
    }
}
