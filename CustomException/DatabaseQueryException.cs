using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEUProject_CSharp_OutbackPOS.CustomException
{
    public class DatabaseQueryException : DatabaseException
    {
        public int ErrorCode { get; }

        public DatabaseQueryException(string message, string query, int errorCode, Exception innerException = null)
            : base(message, query)
        {
            ErrorCode = errorCode;
        }

        public override string GetErrorDetails()
        {
            return $"쿼리 오류: SQL 오류 코드 {ErrorCode}, 쿼리: {Query ?? "알 수 없음"}";
        }

        public override string GetErrorType()
        {
            return "Database Query Error";
        }
    }
}
