using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEUProject_CSharp_OutbackPOS.Model
{
    public class Payment
    {
        // 결제정보 저장
        public int Id { get; set; }
        public decimal TotalAmount { get; set; }
        public List<OutbackOrder> Orders { get; set; }
    }
}
