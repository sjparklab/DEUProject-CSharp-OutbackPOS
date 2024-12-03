using DEUProject_CSharp_OutbackPOS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEUProject_CSharp_OutbackPOS.LoadedData
{
    public class TableCollection
    {
        public List<Table> tables = new List<Table>();

        // 테이블 추가
        public void Add(Table table)
        {
            tables.Add(table);
        }

        // 인덱서: ID로 테이블 접근
        public Table this[int id] => tables.FirstOrDefault(t => t.Id == id);

        // 인덱서: 이름으로 테이블 접근
        public Table this[string name] => tables.FirstOrDefault(t => t.Name == name);
    }
}
