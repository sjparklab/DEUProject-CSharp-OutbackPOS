using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DEUProject_CSharp_OutbackPOS.CustomException
{
    // 입력 오류 예외처리
    public class UnexpectedInputException : ApplicationException
    {
        public int ErrorCode { get; }
        public UnexpectedInputException(string message, int errorCode) : base(message)
        {
            Console.WriteLine(message);
            ErrorCode = errorCode;
        }
    }
}
