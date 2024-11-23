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
        TableRepository tableRepository = new TableRepository();
        Panel movedTable;
        Panel selectedTablePanel;
        Point movingOffset;
        bool Dragging = false;
        PosMainForm posMainForm;

        public TableManageForm(PosMainForm refreshingForm)
        {
            InitializeComponent();
            posMainForm = refreshingForm;
        }

        private void btnTableLayoutSave_Click(object sender, EventArgs e)
        {
            tableRepository.ClearAllTables();
            foreach(Panel p in tableLayoutPanel.Controls)
            {
                int x = p.Location.X;
                int y = p.Location.Y;
                Table table = new Table(p.Name, x, y, p.Width, p.Height);
                tableRepository.AddTable(table);
            }
            DialogResult result = MessageBox.Show("테이블 저장에 성공했습니다! 테이블 관리창을 닫으시겠습니까?", "테이블 관리창 종료", MessageBoxButtons.YesNo);

            if(DialogResult.Yes == result)
            {
                posMainForm.LoadTablePanel();
                this.Close();
            }
            else
            {
                posMainForm.LoadTablePanel();
                return;
            }
        }

        //private void tablePanel_Paint(object sender, PaintEventArgs e)
        //{
        //    Graphics g = e.Graphics;

        //    using (Pen gridPen = new Pen(Color.LightGray, 1))
        //    {
        //        for (int x = 0; x < tableLayoutPanel.Width; x += cellSize) // 격자크기만큼 이동하면서 그리기
        //        {
        //            g.DrawLine(gridPen, x, 0, x, tableLayoutPanel.Height); // 세로선
        //        }
        //        for (int y = 0; y < tableLayoutPanel.Height; y += cellSize)
        //        {
        //            g.DrawLine(gridPen, 0, y, tableLayoutPanel.Width, y); // 가로선
        //        }
        //    }
        //}

        private void btnTableAdd_Click(object sender, EventArgs e)
        {
            Panel tablePanel = new Panel
            {
                Name = "테이블 - " + tableLayoutPanel.Controls.Count,
                Size = new Size(250, 250),
                Location = new Point(tableLayoutPanel.Width / 2, tableLayoutPanel.Height / 2),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
            };

            Label tableNameLable = new Label
            {
                Text = tablePanel.Name,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };

            tableNameLable.MouseDown += (LabelSender, LabelEvent) => { TablePanel_MouseDown(tablePanel, LabelEvent); };
            tableNameLable.MouseMove += (LabelSender, LabelEvent) => { TablePanel_MouseMove(tablePanel, LabelEvent); };
            tableNameLable.MouseUp += (LabelSender, LabelEvent) => { TablePanel_MouseUp(tablePanel, LabelEvent); };
            tableNameLable.MouseClick += (LabelSender, LabelEvent) => { TablePanel_MouseClick(tablePanel, LabelEvent); };
            tablePanel.Controls.Add(tableNameLable);

            // 이벤트 연결
            tablePanel.MouseDown += TablePanel_MouseDown;
            tablePanel.MouseMove += TablePanel_MouseMove;
            tablePanel.MouseUp += TablePanel_MouseUp;
            tablePanel.MouseClick += TablePanel_MouseClick;

            tableLayoutPanel.Controls.Add(tablePanel);
        }

        private void TablePanel_MouseDown(object sender, MouseEventArgs e)
        {
            movedTable = (Panel) sender;
            movingOffset = e.Location;
            Dragging = true;
        }

        private void TablePanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (Dragging)
            {
                movedTable.Left += e.X - movingOffset.X;
                movedTable.Top += e.Y - movingOffset.Y;
            }
        }
        private void TablePanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (Dragging)
            {
                Dragging = false;
            }
        }

        private void TablePanel_MouseClick(object sender, MouseEventArgs e)
        {
            Panel tablePanel = (Panel) sender;
            selectedTablePanel = tablePanel;
            textBox1.Text = tablePanel.Name;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox tableName = (TextBox)sender;
            selectedTablePanel.Name = tableName.Text;
            foreach (Label label in selectedTablePanel.Controls)
            {
                label.Text = selectedTablePanel.Name;
            }
        }

        private void TableManageForm_Load(object sender, EventArgs e)
        {
            List<Table> tables = tableRepository.GetAllTables();
            foreach (Table table in tables)
            {
                Panel tablePanel = new Panel
                {
                    Name = table.Name,
                    Location = new Point(table.X, table.Y),
                    Width = table.Width,
                    Height = table.Height,
                    BackColor = Color.White,
                    BorderStyle = BorderStyle.FixedSingle,
                };

                Label tableNameLable = new Label
                {
                    Text = tablePanel.Name,
                    Dock = DockStyle.Fill,
                    TextAlign = ContentAlignment.MiddleCenter
                };

                tableNameLable.MouseDown += (LabelSender, LabelEvent) => { TablePanel_MouseDown(tablePanel, LabelEvent); };
                tableNameLable.MouseMove += (LabelSender, LabelEvent) => { TablePanel_MouseMove(tablePanel, LabelEvent); };
                tableNameLable.MouseUp += (LabelSender, LabelEvent) => { TablePanel_MouseUp(tablePanel, LabelEvent); };
                tableNameLable.MouseClick += (LabelSender, LabelEvent) => { TablePanel_MouseClick(tablePanel, LabelEvent); };
                tablePanel.Controls.Add(tableNameLable);

                // 이벤트 연결
                tablePanel.MouseDown += TablePanel_MouseDown;
                tablePanel.MouseMove += TablePanel_MouseMove;
                tablePanel.MouseUp += TablePanel_MouseUp;
                tablePanel.MouseClick += TablePanel_MouseClick;

                tableLayoutPanel.Controls.Add(tablePanel);

            }
        }

        private void btnTableRemove_Click(object sender, EventArgs e)
        {
            tableLayoutPanel.Controls.Remove(selectedTablePanel);
        }

        //private void TableIcon_MouseDown(object sender, MouseEventArgs e)
        //{
        //    if (sender is PictureBox originalIcon)
        //    {
        //        // 크기 조정인지 확인
        //        if (IsMouseOnEdge(originalIcon, e.Location, out resizeDirection))
        //        {
        //            isResizing = true;
        //            draggedIcon = originalIcon;
        //            dragOffset = e.Location; // 마우스 클릭 위치 저장
        //        }
        //        else
        //        {
        //            // 드래그 이동
        //            draggedIcon = originalIcon;
        //            isDragging = true;
        //            dragOffset = e.Location;
        //        }
        //    }
        //}


        //private void TableIcon_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (isResizing && draggedIcon != null)
        //    {
        //        int cellSize = 50; // 격자 크기

        //        // 현재 마우스 위치를 격자에 맞춤
        //        Point mousePosition = tablePanel.PointToClient(Cursor.Position);

        //        // 마우스 위치를 기준으로 새로운 크기 계산
        //        int newWidth = ((mousePosition.X / cellSize) * cellSize) - draggedIcon.Left;
        //        int newHeight = ((mousePosition.Y / cellSize) * cellSize) - draggedIcon.Top;

        //        // 최소 크기 보장
        //        newWidth = Math.Max(cellSize, newWidth);
        //        newHeight = Math.Max(cellSize, newHeight);

        //        // 패널 초과 방지
        //        int maxAllowedWidth = tablePanel.Width - draggedIcon.Left;
        //        int maxAllowedHeight = tablePanel.Height - draggedIcon.Top;

        //        // 오른쪽/아래쪽 초과 방지
        //        newWidth = Math.Min(newWidth, maxAllowedWidth);
        //        newHeight = Math.Min(newHeight, maxAllowedHeight);

        //        // 크기 조정 적용
        //        draggedIcon.Size = new Size(newWidth, newHeight);
        //    }
        //    else if (isDragging && draggedIcon != null)
        //    {
        //        int cellSize = 50; // 격자 크기
        //        Point mousePosition = tablePanel.PointToClient(Cursor.Position);

        //        // 격자에 맞춘 위치 계산
        //        int snappedX = Math.Max(0, (mousePosition.X / cellSize) * cellSize);
        //        int snappedY = Math.Max(0, (mousePosition.Y / cellSize) * cellSize);

        //        // 오른쪽/아래쪽 초과 방지
        //        snappedX = Math.Min(snappedX, tablePanel.Width - draggedIcon.Width);
        //        snappedY = Math.Min(snappedY, tablePanel.Height - draggedIcon.Height);

        //        // 위치 이동 적용
        //        draggedIcon.Location = new Point(snappedX, snappedY);
        //    }

        //    else if (sender is PictureBox hoveredIcon)
        //    {
        //        // 크기 조정 마우스 커서 변경
        //        if (IsMouseOnEdge(hoveredIcon, e.Location, out var direction))
        //        {
        //            if (direction.HasFlag(AnchorStyles.Right) && direction.HasFlag(AnchorStyles.Bottom))
        //                hoveredIcon.Cursor = Cursors.SizeNWSE;
        //            else if (direction.HasFlag(AnchorStyles.Right))
        //                hoveredIcon.Cursor = Cursors.SizeWE;
        //            else if (direction.HasFlag(AnchorStyles.Bottom))
        //                hoveredIcon.Cursor = Cursors.SizeNS;
        //        }
        //        else
        //        {
        //            hoveredIcon.Cursor = Cursors.Default;
        //        }
        //    }
        //}

        //private void TableIcon_MouseUp(object sender, MouseEventArgs e)
        //{
        //    if (isResizing)
        //    {
        //        isResizing = false;
        //        resizeDirection = AnchorStyles.None;
        //    }
        //    else if (isDragging)
        //    {
        //        isDragging = false;
        //    }

        //    draggedIcon = null; // 드래그 또는 크기 조정 중인 아이콘 초기화
        //}

        //private bool IsMouseOnEdge(Control control, Point mouseLocation, out AnchorStyles direction)
        //{
        //    int edgeSize = 10; // 테두리 감지 범위
        //    direction = AnchorStyles.None;

        //    if (mouseLocation.X >= control.Width - edgeSize) direction |= AnchorStyles.Right;
        //    if (mouseLocation.Y >= control.Height - edgeSize) direction |= AnchorStyles.Bottom;

        //    return direction != AnchorStyles.None;
        //}

        //private void btnTableLayoutSave_Click(object sender, EventArgs e)
        //{
        //    var repository = new TableRepository();

        //    // DB에 기존 데이터 삭제
        //    repository.ClearAllTables();

        //    // 현재 tablePanel에 있는 모든 PictureBox 저장
        //    foreach (Control control in tablePanel.Controls)
        //    {
        //        if (control is PictureBox tableIcon)
        //        {
        //            var table = new Table
        //            {
        //                Name = tableIcon.Name,
        //                X = tableIcon.Left,
        //                Y = tableIcon.Top,
        //                Width = tableIcon.Width,
        //                Height = tableIcon.Height,
        //            };
        //            repository.AddTable(table);
        //        }
        //    }

        //    MessageBox.Show("테이블 배치가 저장되었습니다!");
        //}

        //private void TableManageForm_Load(object sender, EventArgs e)
        //{
        //    var repository = new TableRepository();
        //    var tables = repository.GetAllTables();

        //    foreach (var table in tables)
        //    {
        //        PictureBox tableIcon = new PictureBox
        //        {
        //            Name = table.Name,
        //            Size = new Size(table.Width, table.Height),
        //            Location = new Point(table.X, table.Y),
        //            BackColor = Color.White,
        //            BorderStyle = BorderStyle.FixedSingle,
        //            SizeMode = PictureBoxSizeMode.Zoom
        //        };

        //        // 이벤트 연결
        //        tableIcon.MouseDown += TableIcon_MouseDown;
        //        tableIcon.MouseMove += TableIcon_MouseMove;
        //        tableIcon.MouseUp += TableIcon_MouseUp;

        //        // 테이블 추가
        //        tablePanel.Controls.Add(tableIcon);
        //    }
        //}
    }
}