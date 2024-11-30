using DEUProject_CSharp_OutbackPOS.CustomControl;
using DEUProject_CSharp_OutbackPOS.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DEUProject_CSharp_OutbackPOS.Controller
{
    public class TableController
    {
        private readonly TableRepository tableRepository;
        private readonly DoubleBufferedPanel tableLayoutPanel;

        public TableController(TableRepository repository, DoubleBufferedPanel layoutPanel)
        {
            tableRepository = repository;
            tableLayoutPanel = layoutPanel;
        }

        // 테이블 패널 생성
        public CustomTablePanel CreateTablePanel(string name, Point location, Size size, Color borderColor, int borderThickness)
        {
            CustomTablePanel tablePanel = new CustomTablePanel
            {
                Name = name,
                Location = location,
                Size = size,
                BorderColor = borderColor,
                BorderThickness = borderThickness,
                BackColor = Color.White
            };

            // 레이블 추가
            Label tableNameLabel = new Label
            {
                Text = name,
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.Transparent, // 투명 배경 설정
                Font = new Font("맑은 고딕", 12, FontStyle.Bold), // 폰트 설정
            };

            // 레이블 이벤트 연결
            tableNameLabel.MouseDown += (sender, e) => tablePanel.HandleMouseDown(e);
            tableNameLabel.MouseMove += (sender, e) => tablePanel.HandleMouseMove(e);
            tableNameLabel.MouseUp += (sender, e) => tablePanel.HandleMouseUp(e);

            // 레이블 패널에 추가
            tablePanel.Controls.Add(tableNameLabel);

            return tablePanel;
        }

        // 테이블 데이터 저장
        public void SaveTables()
        {
            tableRepository.ClearAllTables();
            foreach (CustomTablePanel panel in tableLayoutPanel.Controls)
            {
                Table table = new Table(panel.Name, panel.Location.X, panel.Location.Y, panel.Width, panel.Height, panel.BorderColor);
                tableRepository.AddTable(table);
            }
        }

        // 테이블 데이터 로드
        public void LoadTables(Action<CustomTablePanel> addPanelAction)
        {
            List<Table> tables = tableRepository.GetAllTables();
            foreach (Table table in tables)
            {
                CustomTablePanel panel = CreateTablePanel(
                    table.Name,
                    new Point(table.X, table.Y),
                    new Size(table.Width, table.Height),
                    table.GetBorderColor(), // 컬러 값 저장, // 기본 테두리 색상
                    3            // 기본 테두리 두께
                );

                addPanelAction(panel);
            }
        }

        // 테이블 삭제
        public void RemoveTable(CustomTablePanel panel)
        {
            tableLayoutPanel.Controls.Remove(panel);
        }
    }
}
