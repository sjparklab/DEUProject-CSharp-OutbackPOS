using DEUProject_CSharp_OutbackPOS.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        // 테이블 ID로 결제되지 않은 주문 조회
        public List<OutbackOrder> GetUnpaidOrdersByTableId(int tableId)
        {
            var orders = new List<OutbackOrder>();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = @"
                    SELECT o.OrderID, 
                           o.TableID, 
                           o.TableName, 
                           o.OrderTime, 
                           IFNULL(oi.MenuID, -1) AS MenuID, 
                           IFNULL(oi.MenuName, 'Unknown') AS MenuName, 
                           IFNULL(oi.Quantity, 0) AS Quantity, 
                           IFNULL(oi.Price, 0.0) AS Price
                    FROM Orders o
                    LEFT JOIN OrderItems oi ON o.OrderID = oi.OrderID
                    WHERE o.TableID = @TableID AND o.PaymentID IS NULL;
                ";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TableID", tableId);

                    using (var reader = command.ExecuteReader())
                    {
                        OutbackOrder currentOrder = null;

                        while (reader.Read())
                        {
                            var orderId = reader.GetInt32(0);

                            // 새로운 주문이면 추가
                            if (currentOrder == null || currentOrder.OrderID != orderId)
                            {
                                currentOrder = new OutbackOrder
                                {
                                    OrderID = orderId,
                                    TableID = reader.GetInt32(1),
                                    TableName = reader.GetString(2),
                                    outbackOrderItem = new BindingList<OutbackOrderItem>()
                                };
                                orders.Add(currentOrder);
                            }

                            // OutbackMenuItem 생성
                            OutbackMenuItem menuItem = new OutbackMenuItem
                            {
                                MenuName = reader.GetString(5),  // Menu 이름
                                Price = reader.GetDecimal(7),   // 단가
                                MenuID = reader.GetInt32(4)     // Menu ID
                            };

                            // OutbackOrderItem 생성 및 OutbackMenuItem 연결
                            OutbackOrderItem orderItem = new OutbackOrderItem
                            {
                                outbackMenuItem = menuItem,      // OutbackMenuItem 연결
                                Quantity = reader.GetInt32(6)   // 주문 수량
                            };

                            // 주문 항목 추가
                            currentOrder.outbackOrderItem.Add(orderItem);
                        }
                    }
                }
            }
            return orders;
        }

        // 테이블 ID로 결제되지 않은 주문 항목 조회 - OutbackOrderItem형으로 리턴, DataGridView 바인딩용
        public List<OutbackOrderItem> GetUnpaidOrderItemsByTableId(int tableId)
        {
            var unpaidOrderItems = new List<OutbackOrderItem>();

            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();

                string query = @"
                    SELECT 
                        oi.MenuID, 
                        oi.MenuName, 
                        oi.Quantity, 
                        oi.Price, 
                        (oi.Quantity * oi.Price) AS TotalPrice
                    FROM Orders o
                    JOIN OrderItems oi ON o.OrderID = oi.OrderID
                    WHERE o.TableID = @TableID AND o.PaymentID IS NULL;
                ";

                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@TableID", tableId);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // OutbackMenuItem 생성
                            var menuItem = new OutbackMenuItem
                            {
                                MenuID = reader.GetInt32(0),
                                MenuName = reader.GetString(1),
                                Price = reader.GetDecimal(3)
                            };

                            // OutbackOrderItem 생성
                            var orderItem = new OutbackOrderItem
                            {
                                outbackMenuItem = menuItem,
                                Quantity = reader.GetInt32(2)
                            };

                            unpaidOrderItems.Add(orderItem);
                        }
                    }
                }
            }

            return unpaidOrderItems;
        }


        // 주문의 PaymentID 업데이트
        public void UpdateOrderPaymentId(int orderId, int paymentId)
        {
            using (var connection = new SQLiteConnection(connectionString))
            {
                connection.Open();
                string query = @"
                    UPDATE Orders
                    SET PaymentID = @PaymentID
                    WHERE OrderID = @OrderID
                ";
                using (var command = new SQLiteCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@PaymentID", paymentId);
                    command.Parameters.AddWithValue("@OrderID", orderId);
                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
