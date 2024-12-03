using System;
using System.Collections.Generic;
using System.Data.SQLite;
using DEUProject_CSharp_OutbackPOS.CustomException;

namespace DEUProject_CSharp_OutbackPOS.Model
{
    public class TableRepository
    {
        private readonly string connectionString = "Data Source=database.db;Version=3;";

        // 테이블 전체 삭제
        public void ClearAllTables()
        {
            try
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
            catch (SQLiteException ex)
            {
                throw new DatabaseQueryException("테이블 전체 삭제 중 오류 발생", "DELETE FROM TableLayout", ex.ErrorCode, ex);
            }
        }

        // 테이블 추가
        public void AddTable(Table table)
        {
            try
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
            catch (SQLiteException ex)
            {
                throw new DatabaseWriteException(
                    "테이블 추가 중 오류 발생",
                    "INSERT INTO TableLayout (Name, X, Y, Width, Height, BorderColorArgb, IsOccupied)",
                    "TableLayout",
                    null,
                    ex
                );
            }
        }

        // 모든 테이블 가져오기
        public List<Table> GetAllTables()
        {
            var tables = new List<Table>();

            try
            {
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
            }
            catch (SQLiteException ex)
            {
                throw new DatabaseReadException("모든 테이블 읽기 중 오류 발생", "SELECT * FROM TableLayout", "TableLayout", ex);
            }

            return tables;
        }

        // ID로 특정 테이블 가져오기
        public Table GetTableById(int tableId)
        {
            try
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
            }
            catch (SQLiteException ex)
            {
                throw new DatabaseReadException("테이블 읽기 중 오류 발생", "SELECT * FROM TableLayout WHERE Id = @TableID", "TableLayout", ex);
            }

            return null; // 테이블이 없을 경우 null 반환
        }

        // 테이블 업데이트
        public void UpdateTable(Table table)
        {
            try
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
            catch (SQLiteException ex)
            {
                throw new DatabaseWriteException(
                    "테이블 업데이트 중 오류 발생",
                    "UPDATE TableLayout SET ... WHERE Id = @TableID",
                    "TableLayout",
                    null,
                    ex
                );
            }
        }

        // 모든 테이블 저장
        public void SaveAllTables(IEnumerable<Table> tables)
        {
            try
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    using (var transaction = connection.BeginTransaction())
                    {
                        string query = @"
                            REPLACE INTO TableLayout (Id, Name, X, Y, Width, Height, BorderColorArgb, IsOccupied)
                            VALUES (@Id, @Name, @X, @Y, @Width, @Height, @BorderColorArgb, @IsOccupied)";

                        foreach (var table in tables)
                        {
                            using (var command = new SQLiteCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@Id", table.Id);
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

                        transaction.Commit();
                    }
                }
            }
            catch (SQLiteException ex)
            {
                switch (ex.ErrorCode)
                {
                    case 1: // SQL syntax error
                        throw new DatabaseQueryException("SQL 구문 오류 발생", query, ex.ErrorCode, ex);

                    case 19: // Constraint violation
                        throw new DatabaseWriteException("제약 조건 위반", query, "TableLayout", null, ex);

                    case 14: // Unable to open database file
                        throw new DatabaseConnectionException("데이터베이스 파일 열기 실패", connectionString, ex);

                    default:
                        throw new DatabaseException("알 수 없는 SQLite 오류 발생", query);
                }
            }

        }
    }
}
