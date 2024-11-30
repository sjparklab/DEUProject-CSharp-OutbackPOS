using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEUProject_CSharp_OutbackPOS.Model
{
    // DB 저장용 필수정보 조회 Item 클래스
    public class OutbackMenuItem
    {
        public int MenuID { get; set; }
        public string MenuName { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
    }
}
