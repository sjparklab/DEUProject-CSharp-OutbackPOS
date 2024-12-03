using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEUProject_CSharp_OutbackPOS.CustomException
{
    public class DatabaseConnectionException : DatabaseException
    {
        public string ConnectionString { get; }

        public DatabaseConnectionException(string message, string connectionString, Exception innerException = null)
            : base(message, null)
        {
            ConnectionString = connectionString;
        }

        public override string GetErrorDetails()
        {
            return $"DB 연결 오류: 연결 문자열 '{ConnectionString ?? "알 수 없음"}' 사용 중 문제 발생.";
        }

        public override string GetErrorType()
        {
            return "Database Connection Error";
        }
    }
}
