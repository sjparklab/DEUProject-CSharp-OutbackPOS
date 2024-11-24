namespace DEUProject_CSharp_OutbackPOS
{
    partial class OrderAndPayForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelTitle = new System.Windows.Forms.TableLayoutPanel();
            this.txtTitle = new System.Windows.Forms.Label();
            this.orderpayLayout = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel = new System.Windows.Forms.Panel();
            this.menuGrid = new System.Windows.Forms.DataGridView();
            this.orderPaySystem = new System.Windows.Forms.TableLayoutPanel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.menu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.quantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.priceSum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanelTitle.SuspendLayout();
            this.orderpayLayout.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.menuGrid)).BeginInit();
            this.orderPaySystem.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanelTitle, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.orderpayLayout, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.786364F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.21364F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(2720, 1562);
            this.tableLayoutPanel1.TabIndex = 1;
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
            this.tableLayoutPanelTitle.Size = new System.Drawing.Size(2718, 121);
            this.tableLayoutPanelTitle.TabIndex = 5;
            // 
            // txtTitle
            // 
            this.txtTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTitle.AutoSize = true;
            this.txtTitle.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTitle.ForeColor = System.Drawing.Color.White;
            this.txtTitle.Location = new System.Drawing.Point(1319, 41);
            this.txtTitle.Margin = new System.Windows.Forms.Padding(50, 0, 0, 0);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(129, 38);
            this.txtTitle.TabIndex = 0;
            this.txtTitle.Text = "주문결제";
            // 
            // orderpayLayout
            // 
            this.orderpayLayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(232)))), ((int)(((byte)(235)))));
            this.orderpayLayout.ColumnCount = 2;
            this.orderpayLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.orderpayLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.orderpayLayout.Controls.Add(this.tableLayoutPanel, 0, 0);
            this.orderpayLayout.Controls.Add(this.orderPaySystem, 1, 0);
            this.orderpayLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderpayLayout.Location = new System.Drawing.Point(4, 126);
            this.orderpayLayout.Name = "orderpayLayout";
            this.orderpayLayout.RowCount = 1;
            this.orderpayLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.orderpayLayout.Size = new System.Drawing.Size(2712, 1432);
            this.orderpayLayout.TabIndex = 6;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.Controls.Add(this.menuGrid);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.Size = new System.Drawing.Size(2034, 1432);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // menuGrid
            // 
            this.menuGrid.AllowUserToResizeColumns = false;
            this.menuGrid.AllowUserToResizeRows = false;
            this.menuGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.menuGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.menuGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuGrid.Location = new System.Drawing.Point(0, 0);
            this.menuGrid.Margin = new System.Windows.Forms.Padding(0);
            this.menuGrid.Name = "menuGrid";
            this.menuGrid.ReadOnly = true;
            this.menuGrid.RowHeadersWidth = 62;
            this.menuGrid.RowTemplate.Height = 30;
            this.menuGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.menuGrid.Size = new System.Drawing.Size(2034, 1432);
            this.menuGrid.TabIndex = 0;
            this.menuGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.menuGrid_CellDoubleClick);
            // 
            // orderPaySystem
            // 
            this.orderPaySystem.BackColor = System.Drawing.Color.White;
            this.orderPaySystem.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
            this.orderPaySystem.ColumnCount = 1;
            this.orderPaySystem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.orderPaySystem.Controls.Add(this.listView1, 0, 1);
            this.orderPaySystem.Controls.Add(this.listView2, 0, 2);
            this.orderPaySystem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderPaySystem.Location = new System.Drawing.Point(2034, 0);
            this.orderPaySystem.Margin = new System.Windows.Forms.Padding(0);
            this.orderPaySystem.Name = "orderPaySystem";
            this.orderPaySystem.RowCount = 4;
            this.orderPaySystem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.523809F));
            this.orderPaySystem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 47.61905F));
            this.orderPaySystem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.80952F));
            this.orderPaySystem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 19.04762F));
            this.orderPaySystem.Size = new System.Drawing.Size(678, 1432);
            this.orderPaySystem.TabIndex = 1;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.menu,
            this.price,
            this.quantity,
            this.priceSum});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(2, 139);
            this.listView1.Margin = new System.Windows.Forms.Padding(0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(674, 677);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // menu
            // 
            this.menu.Text = "메뉴명";
            this.menu.Width = 368;
            // 
            // price
            // 
            this.price.Text = "가격";
            this.price.Width = 124;
            // 
            // quantity
            // 
            this.quantity.Text = "갯수";
            this.quantity.Width = 88;
            // 
            // priceSum
            // 
            this.priceSum.Text = "총액";
            this.priceSum.Width = 189;
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(2, 818);
            this.listView2.Margin = new System.Windows.Forms.Padding(0);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(674, 338);
            this.listView2.TabIndex = 1;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "메뉴명";
            this.columnHeader1.Width = 368;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "가격";
            this.columnHeader2.Width = 124;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "갯수";
            this.columnHeader3.Width = 88;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "총액";
            this.columnHeader4.Width = 189;
            // 
            // OrderAndPayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2720, 1562);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "OrderAndPayForm";
            this.Text = "아웃백스테이크하우스 - 테이블관리";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanelTitle.ResumeLayout(false);
            this.tableLayoutPanelTitle.PerformLayout();
            this.orderpayLayout.ResumeLayout(false);
            this.tableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.menuGrid)).EndInit();
            this.orderPaySystem.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTitle;
        private System.Windows.Forms.Label txtTitle;
        private System.Windows.Forms.TableLayoutPanel orderpayLayout;
        private System.Windows.Forms.Panel tableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel orderPaySystem;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader menu;
        private System.Windows.Forms.ColumnHeader price;
        private System.Windows.Forms.ColumnHeader quantity;
        private System.Windows.Forms.DataGridView menuGrid;
        private System.Windows.Forms.ColumnHeader priceSum;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}