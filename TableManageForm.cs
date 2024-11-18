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
        private PictureBox selectedPictureBox; // 현재 드래그 중인 PictureBox
        private Point dragOffset; // 드래그 시작 시의 마우스 오프셋
        public TableManageForm()
        {
            InitializeComponent();
        }


    }
}
