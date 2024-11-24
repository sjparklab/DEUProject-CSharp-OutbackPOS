using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEUProject_CSharp_OutbackPOS.Model
{
    public class SteakMenu : Menu
    {
        public string Category2 { get; set; }
        public string Doneness { get; set; } // 굽기 정도 (Rare, Medium, Well-done)
        public string CookingStyle { get; set; }
    }
}
