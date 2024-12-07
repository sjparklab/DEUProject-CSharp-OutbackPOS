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

        // 모든 테이블 반환
        public IEnumerable<Table> GetAll()
        {
            return tables; // IEnumerable로 반환
        }

        public void Clear()
        {
            tables.Clear();
        }

        // ID로 테이블 검색 (인덱서)
        public Table this[int id]
        {
            get
            {
                foreach (var table in tables)
                {
                    if (table.Id == id)
                    {
                        return table;
                    }
                }
                return null;
            }
        }

        // 이름으로 테이블 검색 (인덱서)
        public Table this[string name]
        {
            get
            {
                // 대소문자를 구분하지 않고 검색
                foreach (var table in tables)
                {
                    if (table.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
                    {
                        return table;
                    }
                }
                return null;
            }
        }
    }
}
