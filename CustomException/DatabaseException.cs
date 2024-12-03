using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEUProject_CSharp_OutbackPOS.CustomException
{
    public abstract class DatabaseException : ApplicationException
    {
        public string Query { get; }
        public DateTime Timestamp { get; } = DateTime.Now;

        // 생성자
        public DatabaseException(string message, string query = null)
            : base(message)
        {
            Query = query;
        }

        // 공통 메서드
        public override string ToString()
        {
            return $"[{Timestamp}] DB 예외: {Message}, 쿼리: {Query ?? "쿼리 정보 없음"}";
        }

        // 추상 메서드: 세부 오류 메시지 제공
        public abstract string GetErrorDetails();

        // 추상 메서드: 예외 유형 제공
        public abstract string GetErrorType();
    }
}
