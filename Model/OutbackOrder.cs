using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEUProject_CSharp_OutbackPOS.Model
{
    // 기본 주문정보 (주문 아이템은 OutbackOrderItem 리스트로 구현)
    public class OutbackOrder
    {
        public int Id { get; set; }
        public int OrderID { get; set; }
        public int TableID { get; set; }
        public string TableName { get; set; }
        public BindingList<OutbackOrderItem> outbackOrderItem { get; set; } = new BindingList<OutbackOrderItem>();
        public decimal TotalTablePrice => outbackOrderItem.Sum(item => item.PriceSum);
    }
}