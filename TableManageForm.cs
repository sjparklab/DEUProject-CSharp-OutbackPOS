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
        private bool isNewTable = false; // 새로 추가된 테이블인지 확인

        public TableManageForm()
        {
            InitializeComponent();
        }

        private void TableIcon_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is PictureBox originalIcon)
            {
                //MessageBox.Show(originalIcon.Parent?.Name ?? "No Parent");
                // `tableLayoutPanel4`에서 클릭한 경우 (새 테이블 생성)
                if (originalIcon.Parent == tablePanel)
                {
                    // 새 아이콘 복사본 생성
                    draggedIcon = new PictureBox
                    {
                        Name = originalIcon.Name, // 이름 복사
                        Size = originalIcon.Size,
                        BackColor = originalIcon.BackColor,
                        BorderStyle = originalIcon.BorderStyle,
                        Image = originalIcon.Image,
                        SizeMode = originalIcon.SizeMode,
                        Tag = originalIcon.Tag
                    };

                    // 복사본에도 이벤트 연결
                    draggedIcon.MouseDown += TableIcon_MouseDown;
                    draggedIcon.MouseMove += TableIcon_MouseMove;
                    draggedIcon.MouseUp += TableIcon_MouseUp;

                    // 오른쪽 패널에 복사본 추가
                    tablePanel.Controls.Add(draggedIcon);
                    isNewTable = true; // 새 테이블 추가 상태
                }
                // `tablePanel`에서 클릭한 경우 (기존 테이블 이동)
                else if (originalIcon.Parent == tablePanel)
                {
                    draggedIcon = originalIcon; // 기존 테이블 참조
                    isNewTable = false; // 기존 테이블 이동 상태
                }

                // 드래그 상태 활성화
                isDragging = true;

                // 드래그 오프셋 저장
                dragOffset = e.Location;
            }
        }

        private void TableIcon_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging && draggedIcon != null)
            {
                // 마우스 위치에 따라 draggedIcon 이동
                Point mousePosition = tablePanel.PointToClient(Cursor.Position);
                draggedIcon.Location = new Point(mousePosition.X - dragOffset.X, mousePosition.Y - dragOffset.Y);
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
                    draggedIcon.Location = new Point(iconLocation.X - dragOffset.X, iconLocation.Y - dragOffset.Y);
                }
                else
                {
                    // 새로 추가된 경우 패널 밖으로 드롭 시 삭제
                    if (isNewTable)
                    {
                        tablePanel.Controls.Remove(draggedIcon);
                    }
                }

                // 드래그 상태 비활성화
                isDragging = false;
                draggedIcon = null;
            }
        }

        private void saveTableLayout_Click(object sender, EventArgs e)
        {
            var repository = new TableRepository();
            repository.ClearAllTableIcons();

            foreach (Control control in tablePanel.Controls)
            {
                if (control is PictureBox tableIcon)
                {
                    var icon = new Table
                    {
                        Name = tableIcon.Name,
                        X = tableIcon.Left,
                        Y = tableIcon.Top,
                        ImagePath = (string) tableIcon.Tag
                    };
                    repository.AddTableIcon(icon);
                }
            }
            MessageBox.Show("테이블 위치가 저장되었습니다.");
        }

        private void TableManageForm_Load(object sender, EventArgs e)
        {
            var repository = new TableRepository();
            var icons = repository.GetAllTableIcons();

            foreach (var icon in icons)
            {
                PictureBox tableIcon = new PictureBox
                {
                    Name = icon.Name,
                    Size = new Size(300, 300),
                    BackColor = Color.SlateGray,
                    BorderStyle = BorderStyle.FixedSingle,
                    Location = new Point(icon.X, icon.Y),
                    Image = (Image)Properties.Resources.ResourceManager.GetObject(icon.ImagePath), // 리소스 이름으로 이미지 로드
                    Tag = icon.ImagePath, // 리소스 이름 저장
                    SizeMode = PictureBoxSizeMode.Zoom
                };

                // 이벤트 연결
                tableIcon.MouseDown += TableIcon_MouseDown;
                tableIcon.MouseMove += TableIcon_MouseMove;
                tableIcon.MouseUp += TableIcon_MouseUp;

                // 패널에 추가
                tablePanel.Controls.Add(tableIcon);
            }
            FontControl.ApplyFontToAllControls(this, "Pretendard-Medium");
        }
    }
}