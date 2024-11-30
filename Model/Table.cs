using System;
using System.Collections.Generic;
using System.Drawing;
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
        public bool IsOccupied { get; set; } // 테이블 점유 여부
        public int BorderColorArgb { get; set; } // Color 저장 (ARGB 값)

        public Table(string name, int x, int y, int width, int height, Color borderColor) // 컬러 값 포함한 생성자
        {
            this.Name = name;
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
            this.BorderColorArgb = borderColor.ToArgb(); // Color를 ARGB 값으로 변환
        }

        // BorderColor를 Color 타입으로 반환
        public Color GetBorderColor()
        {
            return Color.FromArgb(BorderColorArgb);
        }

        // BorderColor를 설정 (Color 타입 입력)
        public void SetBorderColor(Color color)
        {
            BorderColorArgb = color.ToArgb();
        }
    }
}