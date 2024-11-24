using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEUProject_CSharp_OutbackPOS.Model
{
    public class Order
    {
        public int Id { get; set; } // 주문 ID
        public string TableName { get; set; } // 테이블 이름
        public List<string> Items { get; set; } // 주문 항목
        public decimal TotalPrice { get; set; } // 총 가격
        public DateTime OrderDate { get; set; } // 주문 날짜

        public Order()
        {
            Items = new List<string>();
            OrderDate = DateTime.Now;
        }
    }
}
