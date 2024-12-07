using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEUProject_CSharp_OutbackPOS.Model
{
    public class Payment
    {
        public int Id { get; set; }
        public decimal TotalAmount { get; set; }
        public List<OutbackOrder> Orders { get; set; }
    }
}
