using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DEUProject_CSharp_OutbackPOS.Model
{
    public class Table
    {
        public int Id { get; set; } // Primary Key
        public string Name { get; set; } // 테이블 이름
        public int X { get; set; } // X 좌표
        public int Y { get; set; } // Y 좌표
        public int Width { get; set; } // 테이블 너비
        public int Height { get; set; } // 테이블 높이

        public Table() { } // 기본 생성자

        public Table(string Name, int X, int Y, int Width, int Height) // 테이블 생성자
        {
            this.Name = Name;
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
        }
    }
}