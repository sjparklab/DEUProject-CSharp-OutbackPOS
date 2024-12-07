using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEUProject_CSharp_OutbackPOS.Model
{
    public class SetMenu : OutbackMenu
    {
        // 세트 메뉴 정보
        public string SteakOption { get; set; }
        public string PremiumSidesOption { get; set; }
        public string PastaOption { get; set; }
        public string DrinkOption { get; set; }
    }
}
