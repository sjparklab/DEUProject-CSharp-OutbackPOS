using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DEUProject_CSharp_OutbackPOS
{
    public partial class TableManageForm : Form
    {
        private PictureBox draggedIcon; // 현재 드래그 중인 아이콘
        private Point dragOffset; // 드래그 시작 시의 마우스 오프셋
        private bool isDragging = false; // 드래그 상태 확인

        public TableManageForm()
        {
            InitializeComponent();
        }

        private void TableIcon_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is PictureBox originalIcon)
            {
                // 복사본 생성
                draggedIcon = new PictureBox
                {
                    Name = originalIcon.Name, // 이름 복사
                    Size = originalIcon.Size,
                    BackColor = originalIcon.BackColor,
                    BorderStyle = originalIcon.BorderStyle,
                    Image = originalIcon.Image,
                    SizeMode = originalIcon.SizeMode
                };

                // 오른쪽 패널에 복사본 추가
                tablePanel.Controls.Add(draggedIcon);

                // 드래그 상태 활성화
                isDragging = true;
            }
        }

        private void TableIcon_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging && draggedIcon != null)
            {
                // 마우스 위치에 따라 draggedIcon 이동
                Point mousePosition = tablePanel.PointToClient(Cursor.Position);
                draggedIcon.Location = new Point(mousePosition.X - draggedIcon.Width / 2, mousePosition.Y - draggedIcon.Height / 2);
            }
        }


        private void TableIcon_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDragging && draggedIcon != null)
            {
                // 드래그 종료 시 확인
                Point iconLocation = tablePanel.PointToClient(Cursor.Position);

                if (tablePanel.ClientRectangle.Contains(iconLocation))
                {
                    // 패널 내부에 위치 유지
                    draggedIcon.Location = iconLocation;
                }
                else
                {
                    // 패널 밖이면 복사본 삭제
                    tablePanel.Controls.Remove(draggedIcon);
                }

                // 드래그 상태 비활성화
                isDragging = false;
                draggedIcon = null;
            }
        }
    }
}
