using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEUProject_CSharp_OutbackPOS.CustomException
{
    public class DatabaseWriteException : DatabaseException
    {
        public string AffectedTable { get; }
        public int? RowsAffected { get; }

        public DatabaseWriteException(string message, string query = null, string affectedTable = null, int? rowsAffected = null, Exception innerException = null)
            : base(message, query)
        {
            AffectedTable = affectedTable;
            RowsAffected = rowsAffected;
            if (innerException != null)
            {
                base.AddSuppressed(innerException);
            }
        }

        public override string GetErrorDetails()
        {
            return $"데이터 쓰기 중 오류 발생: 테이블 '{AffectedTable ?? "알 수 없음"}', 영향받은 행 수: {RowsAffected?.ToString() ?? "알 수 없음"}";
        }

        public override string GetErrorType()
        {
            return "Database Write Error";
        }
    }
}
