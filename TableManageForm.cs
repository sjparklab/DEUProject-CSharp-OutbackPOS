using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DEUProject_CSharp_OutbackPOS.Model;

namespace DEUProject_CSharp_OutbackPOS
{
    public partial class TableManageForm : Form
    {
        private PictureBox draggedIcon; // 현재 드래그 중인 아이콘
        private Point dragOffset; // 드래그 시작 시의 마우스 오프셋
        private bool isDragging = false; // 드래그 상태 확인
        private bool isResizing = false; // 크기 조정 상태 확인
        private AnchorStyles resizeDirection = AnchorStyles.None; // 크기 조정 방향 저장

        public TableManageForm()
        {
            InitializeComponent();

            // 테이블 패널에 Paint 이벤트 연결 (격자 그리기)
            tablePanel.Paint += tablePanel_Paint;
        }

        private void tablePanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int cellSize = 25; // 격자 크기
            Pen gridPen = new Pen(Color.LightGray, 1); // 격자 선 색상 및 두께

            for (int x = 0; x < tablePanel.Width; x += cellSize)
            {
                g.DrawLine(gridPen, x, 0, x, tablePanel.Height); // 세로선
            }
            for (int y = 0; y < tablePanel.Height; y += cellSize)
            {
                g.DrawLine(gridPen, 0, y, tablePanel.Width, y); // 가로선
            }

            gridPen.Dispose();
        }

        private void btnTableAdd_Click(object sender, EventArgs e)
        {
            int cellSize = 25; // 격자 크기
            int tableSize = 100; // 테이블 크기
            int startX = (tablePanel.Width / 2) / cellSize * cellSize; // 격자 중심에 위치
            int startY = (tablePanel.Height / 2) / cellSize * cellSize;

            PictureBox newTable = new PictureBox
            {
                Name = $"Table_{tablePanel.Controls.Count + 1}",
                Size = new Size(tableSize, tableSize),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Location = new Point(startX, startY),
                SizeMode = PictureBoxSizeMode.Zoom,
                Tag = "default_table_image" // 리소스 이미지 태그
            };

            // 드래그 이벤트 연결
            newTable.MouseDown += TableIcon_MouseDown;
            newTable.MouseMove += TableIcon_MouseMove;
            newTable.MouseUp += TableIcon_MouseUp;

            tablePanel.Controls.Add(newTable);
        }

        private void TableIcon_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is PictureBox originalIcon)
            {
                // 크기 조정인지 확인
                if (IsMouseOnEdge(originalIcon, e.Location, out resizeDirection))
                {
                    isResizing = true;
                    draggedIcon = originalIcon;
                    dragOffset = e.Location; // 마우스 클릭 위치 저장
                }
                else
                {
                    // 드래그 이동
                    draggedIcon = originalIcon;
                    isDragging = true;
                    dragOffset = e.Location;
                }
            }
        }


        private void TableIcon_MouseMove(object sender, MouseEventArgs e)
        {
            if (isResizing && draggedIcon != null)
            {
                int cellSize = 50; // 격자 크기

                // 현재 마우스 위치를 격자에 맞춤
                Point mousePosition = tablePanel.PointToClient(Cursor.Position);

                // 마우스 위치를 기준으로 새로운 크기 계산
                int newWidth = ((mousePosition.X / cellSize) * cellSize) - draggedIcon.Left;
                int newHeight = ((mousePosition.Y / cellSize) * cellSize) - draggedIcon.Top;

                // 최소 크기 보장
                newWidth = Math.Max(cellSize, newWidth);
                newHeight = Math.Max(cellSize, newHeight);

                // 패널 초과 방지
                int maxAllowedWidth = tablePanel.Width - draggedIcon.Left;
                int maxAllowedHeight = tablePanel.Height - draggedIcon.Top;

                // 오른쪽/아래쪽 초과 방지
                newWidth = Math.Min(newWidth, maxAllowedWidth);
                newHeight = Math.Min(newHeight, maxAllowedHeight);

                // 크기 조정 적용
                draggedIcon.Size = new Size(newWidth, newHeight);
            }
            else if (isDragging && draggedIcon != null)
            {
                int cellSize = 50; // 격자 크기
                Point mousePosition = tablePanel.PointToClient(Cursor.Position);

                // 격자에 맞춘 위치 계산
                int snappedX = Math.Max(0, (mousePosition.X / cellSize) * cellSize);
                int snappedY = Math.Max(0, (mousePosition.Y / cellSize) * cellSize);

                // 오른쪽/아래쪽 초과 방지
                snappedX = Math.Min(snappedX, tablePanel.Width - draggedIcon.Width);
                snappedY = Math.Min(snappedY, tablePanel.Height - draggedIcon.Height);

                // 위치 이동 적용
                draggedIcon.Location = new Point(snappedX, snappedY);
            }

            else if (sender is PictureBox hoveredIcon)
            {
                // 크기 조정 마우스 커서 변경
                if (IsMouseOnEdge(hoveredIcon, e.Location, out var direction))
                {
                    if (direction.HasFlag(AnchorStyles.Right) && direction.HasFlag(AnchorStyles.Bottom))
                        hoveredIcon.Cursor = Cursors.SizeNWSE;
                    else if (direction.HasFlag(AnchorStyles.Right))
                        hoveredIcon.Cursor = Cursors.SizeWE;
                    else if (direction.HasFlag(AnchorStyles.Bottom))
                        hoveredIcon.Cursor = Cursors.SizeNS;
                }
                else
                {
                    hoveredIcon.Cursor = Cursors.Default;
                }
            }
        }

        private void TableIcon_MouseUp(object sender, MouseEventArgs e)
        {
            if (isResizing)
            {
                isResizing = false;
                resizeDirection = AnchorStyles.None;
            }
            else if (isDragging)
            {
                isDragging = false;
            }

            draggedIcon = null; // 드래그 또는 크기 조정 중인 아이콘 초기화
        }

        private bool IsMouseOnEdge(Control control, Point mouseLocation, out AnchorStyles direction)
        {
            int edgeSize = 10; // 테두리 감지 범위
            direction = AnchorStyles.None;

            if (mouseLocation.X >= control.Width - edgeSize) direction |= AnchorStyles.Right;
            if (mouseLocation.Y >= control.Height - edgeSize) direction |= AnchorStyles.Bottom;

            return direction != AnchorStyles.None;
        }

        private void btnTableLayoutSave_Click(object sender, EventArgs e)
        {
            var repository = new TableRepository();

            // DB에 기존 데이터 삭제
            repository.ClearAllTables();

            // 현재 tablePanel에 있는 모든 PictureBox 저장
            foreach (Control control in tablePanel.Controls)
            {
                if (control is PictureBox tableIcon)
                {
                    var table = new Table
                    {
                        Name = tableIcon.Name,
                        X = tableIcon.Left,
                        Y = tableIcon.Top,
                        Width = tableIcon.Width,
                        Height = tableIcon.Height,
                    };
                    repository.AddTable(table);
                }
            }

            MessageBox.Show("테이블 배치가 저장되었습니다!");
        }

        private void TableManageForm_Load(object sender, EventArgs e)
        {
            var repository = new TableRepository();
            var tables = repository.GetAllTables();

            foreach (var table in tables)
            {
                PictureBox tableIcon = new PictureBox
                {
                    Name = table.Name,
                    Size = new Size(table.Width, table.Height),
                    Location = new Point(table.X, table.Y),
                    BackColor = Color.White,
                    BorderStyle = BorderStyle.FixedSingle,
                    SizeMode = PictureBoxSizeMode.Zoom
                };

                // 이벤트 연결
                tableIcon.MouseDown += TableIcon_MouseDown;
                tableIcon.MouseMove += TableIcon_MouseMove;
                tableIcon.MouseUp += TableIcon_MouseUp;

                // 테이블 추가
                tablePanel.Controls.Add(tableIcon);
            }
        }
    }
}