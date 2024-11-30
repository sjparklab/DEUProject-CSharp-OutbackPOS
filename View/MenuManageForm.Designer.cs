namespace DEUProject_CSharp_OutbackPOS.View
{
    partial class MenuManageForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuManageMainLayout = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelTitle = new System.Windows.Forms.TableLayoutPanel();
            this.txtTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.savedMenuListVIew = new System.Windows.Forms.ListView();
            this.menuName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuManageMainLayout.SuspendLayout();
            this.tableLayoutPanelTitle.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuManageMainLayout
            // 
            this.menuManageMainLayout.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.menuManageMainLayout.ColumnCount = 1;
            this.menuManageMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.menuManageMainLayout.Controls.Add(this.tableLayoutPanelTitle, 0, 0);
            this.menuManageMainLayout.Controls.Add(this.tableLayoutPanel1, 0, 2);
            this.menuManageMainLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuManageMainLayout.Location = new System.Drawing.Point(0, 0);
            this.menuManageMainLayout.Margin = new System.Windows.Forms.Padding(4);
            this.menuManageMainLayout.Name = "menuManageMainLayout";
            this.menuManageMainLayout.RowCount = 3;
            this.menuManageMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.menuManageMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.18182F));
            this.menuManageMainLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 73.80254F));
            this.menuManageMainLayout.Size = new System.Drawing.Size(1898, 1024);
            this.menuManageMainLayout.TabIndex = 2;
            // 
            // tableLayoutPanelTitle
            // 
            this.tableLayoutPanelTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(61)))), ((int)(((byte)(75)))));
            this.tableLayoutPanelTitle.ColumnCount = 1;
            this.tableLayoutPanelTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelTitle.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanelTitle.Controls.Add(this.txtTitle, 0, 0);
            this.tableLayoutPanelTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(176)))), ((int)(((byte)(184)))), ((int)(((byte)(193)))));
            this.tableLayoutPanelTitle.Location = new System.Drawing.Point(1, 1);
            this.tableLayoutPanelTitle.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanelTitle.Name = "tableLayoutPanelTitle";
            this.tableLayoutPanelTitle.RowCount = 1;
            this.tableLayoutPanelTitle.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelTitle.Size = new System.Drawing.Size(1896, 81);
            this.tableLayoutPanelTitle.TabIndex = 5;
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTitle.AutoSize = true;
            this.txtTitle.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitle.ForeColor = System.Drawing.Color.White;
            this.txtTitle.Location = new System.Drawing.Point(866, 21);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(213, 38);
            this.txtTitle.TabIndex = 0;
            this.txtTitle.Text = "메뉴(재고) 관리";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel1.Controls.Add(this.savedMenuListVIew, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 272);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1890, 748);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // savedMenuListVIew
            // 
            this.savedMenuListVIew.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.menuID,
            this.menuName});
            this.savedMenuListVIew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.savedMenuListVIew.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.savedMenuListVIew.FullRowSelect = true;
            this.savedMenuListVIew.GridLines = true;
            this.savedMenuListVIew.HideSelection = false;
            this.savedMenuListVIew.Location = new System.Drawing.Point(0, 0);
            this.savedMenuListVIew.Margin = new System.Windows.Forms.Padding(0);
            this.savedMenuListVIew.Name = "savedMenuListVIew";
            this.savedMenuListVIew.Size = new System.Drawing.Size(472, 748);
            this.savedMenuListVIew.TabIndex = 0;
            this.savedMenuListVIew.UseCompatibleStateImageBehavior = false;
            this.savedMenuListVIew.View = System.Windows.Forms.View.Details;
            // 
            // menuName
            // 
            this.menuName.Text = "메뉴명";
            this.menuName.Width = 300;
            // 
            // menuID
            // 
            this.menuID.Text = "ID";
            this.menuID.Width = 100;
            // 
            // MenuManageForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1898, 1024);
            this.Controls.Add(this.menuManageMainLayout);
            this.Name = "MenuManageForm";
            this.Text = "MenuManageForm";
            this.menuManageMainLayout.ResumeLayout(false);
            this.tableLayoutPanelTitle.ResumeLayout(false);
            this.tableLayoutPanelTitle.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel menuManageMainLayout;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTitle;
        private System.Windows.Forms.Label txtTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListView savedMenuListVIew;
        private System.Windows.Forms.ColumnHeader menuID;
        private System.Windows.Forms.ColumnHeader menuName;
    }
}