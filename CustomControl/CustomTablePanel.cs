using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DEUProject_CSharp_OutbackPOS.CustomControl
{
    public class CustomTablePanel : Panel
    {
        public int BorderThickness { get; set; } = 5; // 테두리 두께
        public Color BorderColor { get; set; } = Color.Black; // 테두리 색상

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None; // 안티앨리어싱 끄기

            // 테두리 영역 설정
            Rectangle rect = new Rectangle(
                BorderThickness / 2,
                BorderThickness / 2,
                this.Width - BorderThickness,
                this.Height - BorderThickness
            );

            // 테두리 그리기
            using (Pen pen = new Pen(BorderColor, BorderThickness))
            {
                g.DrawRectangle(pen, rect);
            }
        }

        // 메소드 전파용 이벤트 핸들러
        public void HandleMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e); // 내부적으로 protected 메서드를 호출
        }

        public void HandleMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
        }

        public void HandleMouseClick(MouseEventArgs e)
        {
            base.OnMouseClick(e);
        }
    }
}
