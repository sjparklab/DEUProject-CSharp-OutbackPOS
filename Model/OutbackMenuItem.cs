using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEUProject_CSharp_OutbackPOS.Model
{
    public class OutbackMenuItem
    {
        public int MenuID { get; set; }
        public string MenuName { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}
