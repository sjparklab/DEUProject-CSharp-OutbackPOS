using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEUProject_CSharp_OutbackPOS.Model
{
    public class OutbackMenu
    {
        public int MenuID { get; set; }       // 메뉴 ID (Primary Key)
        public string Name { get; set; }      // 메뉴 이름
        public string Category { get; set; }  // 카테고리
        public decimal Price { get; set; }    // 가격
        public string Description { get; set; } // 설명
        public int Stock { get; set; }        // 재고
        public string IngredientOrigin { get; set; }
    }
}
