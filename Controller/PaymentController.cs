using System.Collections.Generic;
using DEUProject_CSharp_OutbackPOS.Data;
using DEUProject_CSharp_OutbackPOS.Model;
using DEUProject_CSharp_OutbackPOS.LoadedData;

namespace DEUProject_CSharp_OutbackPOS.Controller
{
    public class PaymentController
    {
        PaymentRepository paymentRepository = new PaymentRepository();
        OrderRepository orderRepository = new OrderRepository();

        public void ProcessPayment(int tableId, string paymentMethod)
        {
            // 1. 테이블에 관련된 모든 주문 가져오기
            List<OutbackOrder> orders = orderRepository.GetUnpaidOrdersByTableId(tableId);

            // 2. 총 금액 계산
            decimal totalAmount = 0;
            foreach (var order in orders)
            {
                totalAmount += order.TotalTablePrice;
            }

            // 3. 결제 정보 저장
            int paymentId = paymentRepository.AddPayment(tableId, totalAmount, paymentMethod);

            // 4. 각 주문에 PaymentID 업데이트
            foreach (var order in orders)
            {
                orderRepository.UpdateOrderPaymentId(order.OrderID, paymentId);
            }

            // 5. 테이블 상태 초기화
            Table table = DataManager.Instance.Tables[tableId];
            if (table != null)
            {
                table.IsOccupied = false;
                DataManager.Instance.SaveAllData();
            }
        }


        public List<Payment> GetAllPayments()
        {
            // 모든 결제 정보를 가져오는 로직을 여기에 추가하세요.
            // 예를 들어, 데이터베이스에서 결제 정보를 조회하여 반환합니다.
            return paymentRepository.GetAllPayments();
        }

        public void DeletePayment(int paymentId)
        {
            paymentRepository.DeletePayment(paymentId);
        }
    }
}
