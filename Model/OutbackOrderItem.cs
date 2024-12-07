using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DEUProject_CSharp_OutbackPOS.Model
{
    // 주문 갯수와 가격 정보를 담은 주문 데이터
    public class OutbackOrderItem
    {
        public OutbackMenuItem outbackMenuItem { get; set; } // 메뉴 정보와 연결
        public int Quantity { get; set; }      // 주문 수량
        public decimal PriceSum => outbackMenuItem.Price * Quantity; // 총 금액 계산
        public DateTime orderTime { get; }

        public OutbackOrderItem()
        {
            orderTime = DateTime.Now;
        }

        // 데이터 바인딩
        public string MenuName => outbackMenuItem.MenuName; // 메뉴 이름
        public decimal Price => outbackMenuItem.Price;      // 가격
        public int MenuID => outbackMenuItem.MenuID;        // 메뉴 ID
    }
}
