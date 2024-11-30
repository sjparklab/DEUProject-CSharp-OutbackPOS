using DEUProject_CSharp_OutbackPOS.Model;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace DEUProject_CSharp_OutbackPOS.Data
{
    public class OrderRepository
        {
            private readonly string connectionString = "Data Source=database.db;Version=3;";

            public void AddNewOrder(OutbackOrder order)
            {
                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    using (var transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Orders 테이블에 주문 추가
                            string insertOrderQuery = @"
                            INSERT INTO Orders (TableID, TableName, OrderTime) 
                            VALUES (@TableID, @TableName, @OrderTime);
                        ";
                            using (var orderCommand = new SQLiteCommand(insertOrderQuery, connection))
                            {
                                orderCommand.Parameters.AddWithValue("@TableID", order.TableID);
                                orderCommand.Parameters.AddWithValue("@TableName", order.TableName);
                                orderCommand.Parameters.AddWithValue("@OrderTime", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                                orderCommand.ExecuteNonQuery();
                            }

                            // 방금 추가된 주문 ID 가져오기
                            long orderId = connection.LastInsertRowId;

                            // OrderItems 테이블에 주문 아이템 추가
                            string insertOrderItemQuery = @"
                            INSERT INTO OrderItems (OrderID, MenuID, MenuName, Quantity, Price, TotalPrice) 
                            VALUES (@OrderID, @MenuID, @MenuName, @Quantity, @Price, @TotalPrice);
                        ";
                            foreach (var item in order.outbackOrderItem)
                            {
                                using (var itemCommand = new SQLiteCommand(insertOrderItemQuery, connection))
                                {
                                    itemCommand.Parameters.AddWithValue("@OrderID", orderId);
                                    itemCommand.Parameters.AddWithValue("@MenuID", item.MenuID);
                                    itemCommand.Parameters.AddWithValue("@MenuName", item.MenuName);
                                    itemCommand.Parameters.AddWithValue("@Quantity", item.Quantity);
                                    itemCommand.Parameters.AddWithValue("@Price", item.Price);
                                    itemCommand.Parameters.AddWithValue("@TotalPrice", item.PriceSum);
                                    itemCommand.ExecuteNonQuery();
                                }
                            }

                            transaction.Commit();
                        }
                        catch (Exception)
                        {
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }

            public List<OutbackOrder> GetAllOrders()
            {
                var orders = new List<OutbackOrder>();

                using (var connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();

                    // Orders 테이블 조회
                    string selectOrderQuery = "SELECT OrderID, TableID, TableName, OrderTime FROM Orders";
                    using (var orderCommand = new SQLiteCommand(selectOrderQuery, connection))
                    {
                        using (var reader = orderCommand.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var order = new OutbackOrder
                                {
                                    OrderID = reader.GetInt32(0),
                                    TableID = reader.GetInt32(1),
                                    TableName = reader.GetString(2),
                                };

                                orders.Add(order);
                            }
                        }
                    }

                    // OrderItems 테이블 조회
                    foreach (var order in orders)
                    {
                        string selectOrderItemsQuery = "SELECT MenuID, MenuName, Quantity, Price FROM OrderItems WHERE OrderID = @OrderID";
                        using (var itemCommand = new SQLiteCommand(selectOrderItemsQuery, connection))
                        {
                            itemCommand.Parameters.AddWithValue("@OrderID", order.OrderID);
                            using (var reader = itemCommand.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    order.outbackOrderItem.Add(new OutbackOrderItem
                                    {
                                        outbackMenuItem = new OutbackMenuItem
                                        {
                                            MenuID = reader.GetInt32(0),
                                            MenuName = reader.GetString(1),
                                            Price = reader.GetDecimal(3)
                                        },
                                        Quantity = reader.GetInt32(2)
                                    });
                                }
                            }
                        }
                    }
                }

                return orders;
            }
        }
}
