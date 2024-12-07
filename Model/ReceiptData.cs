using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEUProject_CSharp_OutbackPOS.Model
{
    internal class ReceiptData
    {
        public int PaymentId { get; set; }
        public decimal TotalAmount { get; set; }
        public List<OutbackOrder> Orders { get; set; }
    }
}
