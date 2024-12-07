using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEUProject_CSharp_OutbackPOS.Model
{
    // 음료 메뉴 상속
    public class DrinkMenu : OutbackMenu
    {
        public string Size { get; set; }
        public string Category2 { get; set; }
    }
}
