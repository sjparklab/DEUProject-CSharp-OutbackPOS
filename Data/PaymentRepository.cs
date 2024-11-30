using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace DEUProject_CSharp_OutbackPOS.Data
{
    public class PaymentRepository
    {
        private readonly string connectionString = "Data Source=database.db;Version=3;";

        // 결제 정보 추가
        public int AddPayment(int tableId, decimal totalAmount, string paymentMethod)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = @"
                    INSERT INTO Payments (TableID, TotalAmount, PaymentMethod, PaymentTime)
                    VALUES (@TableID, @TotalAmount, @PaymentMethod, @PaymentTime);
                ";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TableID", tableId);
                    command.Parameters.AddWithValue("@TotalAmount", totalAmount);
                    command.Parameters.AddWithValue("@PaymentMethod", paymentMethod);
                    command.Parameters.AddWithValue("@PaymentTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                    command.ExecuteNonQuery();
                    return (int)connection.LastInsertRowId; // PaymentID 반환
                }
            }
        }
    }
}

