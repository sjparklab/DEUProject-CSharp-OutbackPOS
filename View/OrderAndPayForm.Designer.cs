namespace DEUProject_CSharp_OutbackPOS.View
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelTitle = new System.Windows.Forms.TableLayoutPanel();
            this.txtTitle = new System.Windows.Forms.Label();
            this.orderpayLayout = new System.Windows.Forms.TableLayoutPanel();
            this.orderPaySystem = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbltableName = new System.Windows.Forms.Label();
            this.addMenuListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nowMenuListView = new System.Windows.Forms.ListView();
            this.menu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.quantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.priceSum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuSearch = new System.Windows.Forms.TableLayoutPanel();
            this.menuGrid = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.btnTableOrder = new System.Windows.Forms.Button();
            this.btnTablePay = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.메뉴삭제ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoryComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBoxID = new System.Windows.Forms.TextBox();
            this.txtBoxPrice = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblCat2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanelTitle.SuspendLayout();
            this.orderpayLayout.SuspendLayout();
            this.orderPaySystem.SuspendLayout();
            this.panel1.SuspendLayout();
            this.menuSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.menuGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
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
            this.orderpayLayout.Controls.Add(this.orderPaySystem, 1, 0);
            this.orderpayLayout.Controls.Add(this.menuSearch, 0, 0);
            this.orderpayLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderpayLayout.Location = new System.Drawing.Point(4, 126);
            this.orderpayLayout.Name = "orderpayLayout";
            this.orderpayLayout.RowCount = 1;
            this.orderpayLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.orderpayLayout.Size = new System.Drawing.Size(2712, 1432);
            this.orderpayLayout.TabIndex = 6;
            // 
            // orderPaySystem
            // 
            this.orderPaySystem.BackColor = System.Drawing.Color.White;
            this.orderPaySystem.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Outset;
            this.orderPaySystem.ColumnCount = 1;
            this.orderPaySystem.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.orderPaySystem.Controls.Add(this.panel1, 0, 0);
            this.orderPaySystem.Controls.Add(this.addMenuListView, 0, 2);
            this.orderPaySystem.Controls.Add(this.nowMenuListView, 0, 1);
            this.orderPaySystem.Controls.Add(this.tableLayoutPanel2, 0, 3);
            this.orderPaySystem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderPaySystem.Location = new System.Drawing.Point(2034, 0);
            this.orderPaySystem.Margin = new System.Windows.Forms.Padding(0);
            this.orderPaySystem.Name = "orderPaySystem";
            this.orderPaySystem.RowCount = 4;
            this.orderPaySystem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.orderPaySystem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.orderPaySystem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.orderPaySystem.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.orderPaySystem.Size = new System.Drawing.Size(678, 1432);
            this.orderPaySystem.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbltableName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(2, 2);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(674, 213);
            this.panel1.TabIndex = 0;
            // 
            // lbltableName
            // 
            this.lbltableName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbltableName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbltableName.Font = new System.Drawing.Font("맑은 고딕", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbltableName.Location = new System.Drawing.Point(0, 0);
            this.lbltableName.Name = "lbltableName";
            this.lbltableName.Size = new System.Drawing.Size(674, 213);
            this.lbltableName.TabIndex = 4;
            this.lbltableName.Text = "lbltableName";
            this.lbltableName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // addMenuListView
            // 
            this.addMenuListView.CheckBoxes = true;
            this.addMenuListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.addMenuListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addMenuListView.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.addMenuListView.HideSelection = false;
            this.addMenuListView.Location = new System.Drawing.Point(2, 858);
            this.addMenuListView.Margin = new System.Windows.Forms.Padding(0);
            this.addMenuListView.Name = "addMenuListView";
            this.addMenuListView.Size = new System.Drawing.Size(674, 284);
            this.addMenuListView.TabIndex = 1;
            this.addMenuListView.UseCompatibleStateImageBehavior = false;
            this.addMenuListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "메뉴명";
            this.columnHeader1.Width = 300;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "가격";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "갯수";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "총액";
            this.columnHeader4.Width = 100;
            // 
            // nowMenuListView
            // 
            this.nowMenuListView.CheckBoxes = true;
            this.nowMenuListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.menu,
            this.price,
            this.quantity,
            this.priceSum});
            this.nowMenuListView.ContextMenuStrip = this.contextMenuStrip1;
            this.nowMenuListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.nowMenuListView.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.nowMenuListView.Location = new System.Drawing.Point(2, 217);
            this.nowMenuListView.Margin = new System.Windows.Forms.Padding(0);
            this.nowMenuListView.Name = "nowMenuListView";
            this.nowMenuListView.Size = new System.Drawing.Size(674, 639);
            this.nowMenuListView.TabIndex = 0;
            this.nowMenuListView.UseCompatibleStateImageBehavior = false;
            this.nowMenuListView.View = System.Windows.Forms.View.Details;
            // 
            // menu
            // 
            this.menu.Text = "메뉴명";
            this.menu.Width = 300;
            // 
            // price
            // 
            this.price.Text = "가격";
            this.price.Width = 100;
            // 
            // quantity
            // 
            this.quantity.Text = "갯수";
            this.quantity.Width = 100;
            // 
            // priceSum
            // 
            this.priceSum.Text = "총액";
            this.priceSum.Width = 100;
            // 
            // menuSearch
            // 
            this.menuSearch.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.menuSearch.ColumnCount = 1;
            this.menuSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.menuSearch.Controls.Add(this.menuGrid, 0, 1);
            this.menuSearch.Controls.Add(this.groupBox1, 0, 0);
            this.menuSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.menuSearch.Location = new System.Drawing.Point(0, 0);
            this.menuSearch.Margin = new System.Windows.Forms.Padding(0);
            this.menuSearch.Name = "menuSearch";
            this.menuSearch.RowCount = 2;
            this.menuSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.menuSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.menuSearch.Size = new System.Drawing.Size(2034, 1432);
            this.menuSearch.TabIndex = 2;
            // 
            // menuGrid
            // 
            this.menuGrid.AllowUserToResizeColumns = false;
            this.menuGrid.AllowUserToResizeRows = false;
            this.menuGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.menuGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.menuGrid.Location = new System.Drawing.Point(1, 216);
            this.menuGrid.Margin = new System.Windows.Forms.Padding(0);
            this.menuGrid.Name = "menuGrid";
            this.menuGrid.ReadOnly = true;
            this.menuGrid.RowHeadersWidth = 62;
            this.menuGrid.RowTemplate.Height = 30;
            this.menuGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.menuGrid.Size = new System.Drawing.Size(2032, 1215);
            this.menuGrid.TabIndex = 0;
            this.menuGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.menuGrid_CellDoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.lblCat2);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.txtBoxPrice);
            this.groupBox1.Controls.Add(this.lblPrice);
            this.groupBox1.Controls.Add(this.txtBoxID);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.categoryComboBox);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.groupBox1.Location = new System.Drawing.Point(22, 23);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1989, 170);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "메뉴 검색";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.btnTablePay, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.btnTableOrder, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(5, 1147);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(668, 280);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // btnTableOrder
            // 
            this.btnTableOrder.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTableOrder.Font = new System.Drawing.Font("맑은 고딕", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnTableOrder.Location = new System.Drawing.Point(42, 65);
            this.btnTableOrder.Name = "btnTableOrder";
            this.btnTableOrder.Size = new System.Drawing.Size(250, 150);
            this.btnTableOrder.TabIndex = 0;
            this.btnTableOrder.Text = "주문";
            this.btnTableOrder.UseVisualStyleBackColor = true;
            this.btnTableOrder.Click += new System.EventHandler(this.btnTableOrder_Click);
            // 
            // btnTablePay
            // 
            this.btnTablePay.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnTablePay.Font = new System.Drawing.Font("맑은 고딕", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnTablePay.Location = new System.Drawing.Point(376, 65);
            this.btnTablePay.Name = "btnTablePay";
            this.btnTablePay.Size = new System.Drawing.Size(250, 150);
            this.btnTablePay.TabIndex = 1;
            this.btnTablePay.Text = "결제";
            this.btnTablePay.UseVisualStyleBackColor = true;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(1796, 37);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(171, 110);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.Text = "검색";
            this.btnSearch.UseVisualStyleBackColor = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.메뉴삭제ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(163, 36);
            // 
            // 메뉴삭제ToolStripMenuItem
            // 
            this.메뉴삭제ToolStripMenuItem.Name = "메뉴삭제ToolStripMenuItem";
            this.메뉴삭제ToolStripMenuItem.Size = new System.Drawing.Size(162, 32);
            this.메뉴삭제ToolStripMenuItem.Text = "메뉴 삭제";
            // 
            // categoryComboBox
            // 
            this.categoryComboBox.FormattingEnabled = true;
            this.categoryComboBox.Location = new System.Drawing.Point(682, 88);
            this.categoryComboBox.Name = "categoryComboBox";
            this.categoryComboBox.Size = new System.Drawing.Size(191, 36);
            this.categoryComboBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(677, 47);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 28);
            this.label1.TabIndex = 2;
            this.label1.Text = "카테고리";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(115, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 28);
            this.label2.TabIndex = 4;
            this.label2.Text = "ID";
            // 
            // txtBoxID
            // 
            this.txtBoxID.Location = new System.Drawing.Point(120, 88);
            this.txtBoxID.Multiline = true;
            this.txtBoxID.Name = "txtBoxID";
            this.txtBoxID.Size = new System.Drawing.Size(197, 36);
            this.txtBoxID.TabIndex = 5;
            // 
            // txtBoxPrice
            // 
            this.txtBoxPrice.Location = new System.Drawing.Point(404, 88);
            this.txtBoxPrice.Multiline = true;
            this.txtBoxPrice.Name = "txtBoxPrice";
            this.txtBoxPrice.Size = new System.Drawing.Size(197, 36);
            this.txtBoxPrice.TabIndex = 7;
            // 
            // lblPrice
            // 
            this.lblPrice.AutoSize = true;
            this.lblPrice.Location = new System.Drawing.Point(399, 47);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(52, 28);
            this.lblPrice.TabIndex = 6;
            this.lblPrice.Text = "가격";
            // 
            // lblCat2
            // 
            this.lblCat2.AutoSize = true;
            this.lblCat2.Location = new System.Drawing.Point(952, 47);
            this.lblCat2.Name = "lblCat2";
            this.lblCat2.Size = new System.Drawing.Size(132, 28);
            this.lblCat2.TabIndex = 9;
            this.lblCat2.Text = "세부카테고리";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(957, 88);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(191, 36);
            this.comboBox1.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1227, 47);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 28);
            this.label3.TabIndex = 11;
            this.label3.Text = "원산지";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(1232, 88);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(191, 36);
            this.comboBox2.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1508, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 28);
            this.label4.TabIndex = 13;
            this.label4.Text = "재고 유/무";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(1513, 88);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(57, 32);
            this.radioButton1.TabIndex = 14;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "유";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(1576, 88);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(57, 32);
            this.radioButton2.TabIndex = 15;
            this.radioButton2.Text = "무";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // OrderAndPayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2720, 1562);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "OrderAndPayForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "아웃백스테이크하우스 - 주문/결제";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanelTitle.ResumeLayout(false);
            this.tableLayoutPanelTitle.PerformLayout();
            this.orderpayLayout.ResumeLayout(false);
            this.orderPaySystem.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.menuSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.menuGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTitle;
        private System.Windows.Forms.Label txtTitle;
        private System.Windows.Forms.TableLayoutPanel orderpayLayout;
        private System.Windows.Forms.TableLayoutPanel orderPaySystem;
        private System.Windows.Forms.ListView nowMenuListView;
        private System.Windows.Forms.ColumnHeader menu;
        private System.Windows.Forms.ColumnHeader price;
        private System.Windows.Forms.ColumnHeader quantity;
        private System.Windows.Forms.DataGridView menuGrid;
        private System.Windows.Forms.ColumnHeader priceSum;
        private System.Windows.Forms.ListView addMenuListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.TableLayoutPanel menuSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbltableName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button btnTablePay;
        private System.Windows.Forms.Button btnTableOrder;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 메뉴삭제ToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox categoryComboBox;
        private System.Windows.Forms.TextBox txtBoxID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBoxPrice;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label lblCat2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}