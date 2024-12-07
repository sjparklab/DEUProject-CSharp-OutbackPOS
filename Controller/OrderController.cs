using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DEUProject_CSharp_OutbackPOS.Data;
using DEUProject_CSharp_OutbackPOS.Model;

namespace DEUProject_CSharp_OutbackPOS.Controller
{
    public class OrderController
    {
        OrderRepository orderRepository = new OrderRepository();

        public void AddNewOrder(OutbackOrder order)
        {
            orderRepository.AddNewOrder(order);
        }

        // 미결제 주문 조회
        public List<OutbackOrderItem> GetUnpaidOrderItemsByTableId(int tableId)
        {
            return orderRepository.GetUnpaidOrderItemsByTableId(tableId);
        }
    }
}
