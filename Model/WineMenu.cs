using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEUProject_CSharp_OutbackPOS.Model
{
    // 와인 메뉴 정보
    public class WineMenu : DrinkMenu
    {
        public int? Acidity { get; set; }
        public int? Sweetness { get; set; }
        public int? Body { get; set; }
        public int? Tannin { get; set; }
    }
}
