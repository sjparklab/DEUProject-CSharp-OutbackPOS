using DEUProject_CSharp_OutbackPOS.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEUProject_CSharp_OutbackPOS.Data
{
    // 결제정보 통신용 리포지토리
    public class PaymentRepository
    {
        private readonly OrderRepository orderRepository = new OrderRepository();

        public int AddPayment(int tableId, decimal totalAmount, string paymentMethod)
        {
            int paymentId;
            // 데이터베이스 연결 및 결제 정보 저장 로직
            using (var connection = new SQLiteConnection("Data Source=database.db;Version=3;"))
            {
                connection.Open();
                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = "INSERT INTO Payments (TableID, TotalAmount, PaymentMethod, PaymentTime) VALUES (@TableID, @TotalAmount, @PaymentMethod, @PaymentTime); SELECT last_insert_rowid();";
                    command.Parameters.AddWithValue("@TableID", tableId);
                    command.Parameters.AddWithValue("@TotalAmount", totalAmount);
                    command.Parameters.AddWithValue("@PaymentMethod", paymentMethod);
                    command.Parameters.AddWithValue("@PaymentTime", DateTime.Now); // Add this line


                    paymentId = Convert.ToInt32(command.ExecuteScalar());
                }
            }

            return paymentId;
        }

        public List<Payment> GetAllPayments()
        {
            var payments = new List<Payment>();

            // 데이터베이스 연결 및 결제 정보 조회 로직
            using (var connection = new SQLiteConnection("Data Source=database.db;Version=3;"))
            {
                connection.Open();
                using (var command = new SQLiteCommand("SELECT * FROM Payments", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var payment = new Payment
                            {
                                Id = Convert.ToInt32(reader["PaymentID"]),
                                TotalAmount = Convert.ToDecimal(reader["TotalAmount"]),
                                Orders = orderRepository.GetOrdersByPaymentId(Convert.ToInt32(reader["PaymentID"]))
                            };
                            payments.Add(payment);
                        }
                    }
                }
            }

            return payments;
        }

        public void DeletePayment(int paymentId)
        {
            using (var connection = new SQLiteConnection("Data Source=database.db;Version=3;"))
            {
                connection.Open();
                using (var command = new SQLiteCommand(connection))
                {
                    command.CommandText = "DELETE FROM Payments WHERE PaymentID = @PaymentID";
                    command.Parameters.AddWithValue("@PaymentID", paymentId);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
