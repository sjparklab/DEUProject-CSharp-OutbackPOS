using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEUProject_CSharp_OutbackPOS.CustomException
{
    public class DatabaseReadException : DatabaseException
    {
        public string ResourceName { get; }

        public DatabaseReadException(string message, string query = null, string resourceName = null)
            : base(message, query)
        {
            ResourceName = resourceName;
        }

        public override string GetErrorDetails()
        {
            return $"데이터 읽기 중 오류 발생: 리소스 '{ResourceName ?? "알 수 없음"}', 쿼리: {Query ?? "없음"}";
        }

        public override string GetErrorType()
        {
            return "Database Read Error";
        }
    }
}
