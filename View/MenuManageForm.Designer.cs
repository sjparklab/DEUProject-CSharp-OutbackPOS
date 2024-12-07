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
            this.savedMenuListView = new System.Windows.Forms.ListView();
            this.menuID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStock = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.cmBoxOrigin = new System.Windows.Forms.ComboBox();
            this.txtBoxMaxStockSearch = new System.Windows.Forms.TextBox();
            this.txtBoxMinStockSearch = new System.Windows.Forms.TextBox();
            this.txtBoxMaxPriceSearch = new System.Windows.Forms.TextBox();
            this.txtBoxMenuNameSearch = new System.Windows.Forms.TextBox();
            this.lblOrigin = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblMaxPrice = new System.Windows.Forms.Label();
            this.lblMinPrice = new System.Windows.Forms.Label();
            this.lblMenuMainCategory = new System.Windows.Forms.Label();
            this.lblMenuNameSearch = new System.Windows.Forms.Label();
            this.lblMenuID = new System.Windows.Forms.Label();
            this.txtBoxMenuIDSearch = new System.Windows.Forms.TextBox();
            this.cmBoxMainCategorySelect = new System.Windows.Forms.ComboBox();
            this.txtBoxMinPriceSearch = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.btnMenuSave = new System.Windows.Forms.Button();
            this.btnMenuSearch = new System.Windows.Forms.Button();
            this.btnMenuDelete = new System.Windows.Forms.Button();
            this.btnNewMenu = new System.Windows.Forms.Button();
            this.doubleBufferedPanel1 = new DEUProject_CSharp_OutbackPOS.CustomControl.DoubleBufferedPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.detailCmBoxOrigin = new System.Windows.Forms.ComboBox();
            this.txtBoxIngredientOriginAdd = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnAddCategory = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.detailTxtBoxMenuStock = new System.Windows.Forms.TextBox();
            this.detailCmBoxMainCategory = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.detailTxtBoxMenuPrice = new System.Windows.Forms.TextBox();
            this.txtBoxAddCategory = new System.Windows.Forms.TextBox();
            this.detailTxtBoxMenuName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnMainAddOrigin = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.detailTxtBoxMenuID = new System.Windows.Forms.TextBox();
            this.menuManageMainLayout.SuspendLayout();
            this.tableLayoutPanelTitle.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.doubleBufferedPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuManageMainLayout
            // 
            this.menuManageMainLayout.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.menuManageMainLayout.ColumnCount = 1;
            this.menuManageMainLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.menuManageMainLayout.Controls.Add(this.tableLayoutPanelTitle, 0, 0);
            this.menuManageMainLayout.Controls.Add(this.tableLayoutPanel1, 0, 2);
            this.menuManageMainLayout.Controls.Add(this.tableLayoutPanel3, 0, 1);
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
            this.tableLayoutPanel1.Controls.Add(this.savedMenuListView, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.doubleBufferedPanel1, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(4, 272);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1890, 748);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // savedMenuListView
            // 
            this.savedMenuListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.menuID,
            this.menuStock,
            this.menuName});
            this.savedMenuListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.savedMenuListView.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.savedMenuListView.FullRowSelect = true;
            this.savedMenuListView.GridLines = true;
            this.savedMenuListView.HideSelection = false;
            this.savedMenuListView.Location = new System.Drawing.Point(0, 0);
            this.savedMenuListView.Margin = new System.Windows.Forms.Padding(0);
            this.savedMenuListView.MultiSelect = false;
            this.savedMenuListView.Name = "savedMenuListView";
            this.savedMenuListView.Size = new System.Drawing.Size(472, 748);
            this.savedMenuListView.TabIndex = 0;
            this.savedMenuListView.UseCompatibleStateImageBehavior = false;
            this.savedMenuListView.View = System.Windows.Forms.View.Details;
            this.savedMenuListView.SelectedIndexChanged += new System.EventHandler(this.savedMenuListView_SelectedIndexChanged);
            // 
            // menuID
            // 
            this.menuID.Text = "ID";
            this.menuID.Width = 75;
            // 
            // menuStock
            // 
            this.menuStock.Text = "재고";
            this.menuStock.Width = 75;
            // 
            // menuName
            // 
            this.menuName.Text = "메뉴명";
            this.menuName.Width = 300;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(4, 86);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1890, 179);
            this.tableLayoutPanel3.TabIndex = 7;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(232)))), ((int)(((byte)(235)))));
            this.tableLayoutPanel2.ColumnCount = 8;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.Controls.Add(this.cmBoxOrigin, 7, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtBoxMaxStockSearch, 6, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtBoxMinStockSearch, 5, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtBoxMaxPriceSearch, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtBoxMenuNameSearch, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblOrigin, 7, 0);
            this.tableLayoutPanel2.Controls.Add(this.label7, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.label6, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblMaxPrice, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblMinPrice, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblMenuMainCategory, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblMenuNameSearch, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblMenuID, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtBoxMenuIDSearch, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.cmBoxMainCategorySelect, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtBoxMinPriceSearch, 3, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1506, 173);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // cmBoxOrigin
            // 
            this.cmBoxOrigin.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmBoxOrigin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmBoxOrigin.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmBoxOrigin.FormattingEnabled = true;
            this.cmBoxOrigin.Location = new System.Drawing.Point(1319, 43);
            this.cmBoxOrigin.Name = "cmBoxOrigin";
            this.cmBoxOrigin.Size = new System.Drawing.Size(182, 33);
            this.cmBoxOrigin.TabIndex = 15;
            // 
            // txtBoxMaxStockSearch
            // 
            this.txtBoxMaxStockSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBoxMaxStockSearch.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtBoxMaxStockSearch.Location = new System.Drawing.Point(1131, 44);
            this.txtBoxMaxStockSearch.Name = "txtBoxMaxStockSearch";
            this.txtBoxMaxStockSearch.Size = new System.Drawing.Size(182, 31);
            this.txtBoxMaxStockSearch.TabIndex = 14;
            // 
            // txtBoxMinStockSearch
            // 
            this.txtBoxMinStockSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBoxMinStockSearch.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtBoxMinStockSearch.Location = new System.Drawing.Point(943, 44);
            this.txtBoxMinStockSearch.Name = "txtBoxMinStockSearch";
            this.txtBoxMinStockSearch.Size = new System.Drawing.Size(182, 31);
            this.txtBoxMinStockSearch.TabIndex = 13;
            // 
            // txtBoxMaxPriceSearch
            // 
            this.txtBoxMaxPriceSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBoxMaxPriceSearch.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtBoxMaxPriceSearch.Location = new System.Drawing.Point(755, 44);
            this.txtBoxMaxPriceSearch.Name = "txtBoxMaxPriceSearch";
            this.txtBoxMaxPriceSearch.Size = new System.Drawing.Size(182, 31);
            this.txtBoxMaxPriceSearch.TabIndex = 12;
            // 
            // txtBoxMenuNameSearch
            // 
            this.txtBoxMenuNameSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBoxMenuNameSearch.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtBoxMenuNameSearch.Location = new System.Drawing.Point(191, 44);
            this.txtBoxMenuNameSearch.Name = "txtBoxMenuNameSearch";
            this.txtBoxMenuNameSearch.Size = new System.Drawing.Size(182, 31);
            this.txtBoxMenuNameSearch.TabIndex = 9;
            // 
            // lblOrigin
            // 
            this.lblOrigin.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblOrigin.AutoSize = true;
            this.lblOrigin.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblOrigin.Location = new System.Drawing.Point(1371, 2);
            this.lblOrigin.Name = "lblOrigin";
            this.lblOrigin.Size = new System.Drawing.Size(79, 30);
            this.lblOrigin.TabIndex = 7;
            this.lblOrigin.Text = "원산지";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(1167, 2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 30);
            this.label7.TabIndex = 6;
            this.label7.Text = "최대 재고";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(979, 2);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 30);
            this.label6.TabIndex = 5;
            this.label6.Text = "최소 재고";
            // 
            // lblMaxPrice
            // 
            this.lblMaxPrice.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMaxPrice.AutoSize = true;
            this.lblMaxPrice.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMaxPrice.Location = new System.Drawing.Point(791, 2);
            this.lblMaxPrice.Name = "lblMaxPrice";
            this.lblMaxPrice.Size = new System.Drawing.Size(109, 30);
            this.lblMaxPrice.TabIndex = 4;
            this.lblMaxPrice.Text = "최대 가격";
            // 
            // lblMinPrice
            // 
            this.lblMinPrice.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMinPrice.AutoSize = true;
            this.lblMinPrice.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMinPrice.Location = new System.Drawing.Point(603, 2);
            this.lblMinPrice.Name = "lblMinPrice";
            this.lblMinPrice.Size = new System.Drawing.Size(109, 30);
            this.lblMinPrice.TabIndex = 3;
            this.lblMinPrice.Text = "최소 가격";
            // 
            // lblMenuMainCategory
            // 
            this.lblMenuMainCategory.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMenuMainCategory.AutoSize = true;
            this.lblMenuMainCategory.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMenuMainCategory.Location = new System.Drawing.Point(404, 2);
            this.lblMenuMainCategory.Name = "lblMenuMainCategory";
            this.lblMenuMainCategory.Size = new System.Drawing.Size(131, 30);
            this.lblMenuMainCategory.TabIndex = 2;
            this.lblMenuMainCategory.Text = "주 카테고리";
            // 
            // lblMenuNameSearch
            // 
            this.lblMenuNameSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMenuNameSearch.AutoSize = true;
            this.lblMenuNameSearch.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMenuNameSearch.Location = new System.Drawing.Point(242, 2);
            this.lblMenuNameSearch.Name = "lblMenuNameSearch";
            this.lblMenuNameSearch.Size = new System.Drawing.Size(79, 30);
            this.lblMenuNameSearch.TabIndex = 1;
            this.lblMenuNameSearch.Text = "메뉴명";
            // 
            // lblMenuID
            // 
            this.lblMenuID.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblMenuID.AutoSize = true;
            this.lblMenuID.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblMenuID.Location = new System.Drawing.Point(54, 2);
            this.lblMenuID.Name = "lblMenuID";
            this.lblMenuID.Size = new System.Drawing.Size(79, 30);
            this.lblMenuID.TabIndex = 0;
            this.lblMenuID.Text = "메뉴ID";
            // 
            // txtBoxMenuIDSearch
            // 
            this.txtBoxMenuIDSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBoxMenuIDSearch.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtBoxMenuIDSearch.Location = new System.Drawing.Point(3, 44);
            this.txtBoxMenuIDSearch.Name = "txtBoxMenuIDSearch";
            this.txtBoxMenuIDSearch.Size = new System.Drawing.Size(182, 31);
            this.txtBoxMenuIDSearch.TabIndex = 8;
            // 
            // cmBoxMainCategorySelect
            // 
            this.cmBoxMainCategorySelect.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmBoxMainCategorySelect.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmBoxMainCategorySelect.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmBoxMainCategorySelect.FormattingEnabled = true;
            this.cmBoxMainCategorySelect.Location = new System.Drawing.Point(379, 43);
            this.cmBoxMainCategorySelect.Name = "cmBoxMainCategorySelect";
            this.cmBoxMainCategorySelect.Size = new System.Drawing.Size(182, 33);
            this.cmBoxMainCategorySelect.TabIndex = 10;
            // 
            // txtBoxMinPriceSearch
            // 
            this.txtBoxMinPriceSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtBoxMinPriceSearch.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtBoxMinPriceSearch.Location = new System.Drawing.Point(567, 44);
            this.txtBoxMinPriceSearch.Name = "txtBoxMinPriceSearch";
            this.txtBoxMinPriceSearch.Size = new System.Drawing.Size(182, 31);
            this.txtBoxMinPriceSearch.TabIndex = 11;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(232)))), ((int)(((byte)(235)))));
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.btnMenuSave, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnMenuSearch, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.btnMenuDelete, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.btnNewMenu, 0, 1);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(1515, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(372, 173);
            this.tableLayoutPanel4.TabIndex = 8;
            // 
            // btnMenuSave
            // 
            this.btnMenuSave.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMenuSave.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMenuSave.Location = new System.Drawing.Point(189, 3);
            this.btnMenuSave.Name = "btnMenuSave";
            this.btnMenuSave.Size = new System.Drawing.Size(180, 80);
            this.btnMenuSave.TabIndex = 1;
            this.btnMenuSave.Text = "저장";
            this.btnMenuSave.UseVisualStyleBackColor = true;
            this.btnMenuSave.Click += new System.EventHandler(this.btnMenuSave_Click);
            // 
            // btnMenuSearch
            // 
            this.btnMenuSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMenuSearch.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMenuSearch.Location = new System.Drawing.Point(3, 3);
            this.btnMenuSearch.Name = "btnMenuSearch";
            this.btnMenuSearch.Size = new System.Drawing.Size(180, 80);
            this.btnMenuSearch.TabIndex = 0;
            this.btnMenuSearch.Text = "검색";
            this.btnMenuSearch.UseVisualStyleBackColor = true;
            this.btnMenuSearch.Click += new System.EventHandler(this.btnMenuSearch_Click);
            // 
            // btnMenuDelete
            // 
            this.btnMenuDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMenuDelete.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnMenuDelete.Location = new System.Drawing.Point(189, 89);
            this.btnMenuDelete.Name = "btnMenuDelete";
            this.btnMenuDelete.Size = new System.Drawing.Size(180, 81);
            this.btnMenuDelete.TabIndex = 2;
            this.btnMenuDelete.Text = "삭제";
            this.btnMenuDelete.UseVisualStyleBackColor = true;
            this.btnMenuDelete.Click += new System.EventHandler(this.btnMenuDelete_Click);
            // 
            // btnNewMenu
            // 
            this.btnNewMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNewMenu.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnNewMenu.Location = new System.Drawing.Point(3, 89);
            this.btnNewMenu.Name = "btnNewMenu";
            this.btnNewMenu.Size = new System.Drawing.Size(180, 81);
            this.btnNewMenu.TabIndex = 3;
            this.btnNewMenu.Text = "신규";
            this.btnNewMenu.UseVisualStyleBackColor = true;
            this.btnNewMenu.Click += new System.EventHandler(this.btnNewMenu_Click);
            // 
            // doubleBufferedPanel1
            // 
            this.doubleBufferedPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(229)))), ((int)(((byte)(232)))), ((int)(((byte)(235)))));
            this.doubleBufferedPanel1.Controls.Add(this.groupBox1);
            this.doubleBufferedPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.doubleBufferedPanel1.Location = new System.Drawing.Point(475, 3);
            this.doubleBufferedPanel1.Name = "doubleBufferedPanel1";
            this.doubleBufferedPanel1.Size = new System.Drawing.Size(1412, 742);
            this.doubleBufferedPanel1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.detailCmBoxOrigin);
            this.groupBox1.Controls.Add(this.txtBoxIngredientOriginAdd);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.btnAddCategory);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.detailTxtBoxMenuStock);
            this.groupBox1.Controls.Add(this.detailCmBoxMainCategory);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.detailTxtBoxMenuPrice);
            this.groupBox1.Controls.Add(this.txtBoxAddCategory);
            this.groupBox1.Controls.Add(this.detailTxtBoxMenuName);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnMainAddOrigin);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.detailTxtBoxMenuID);
            this.groupBox1.Location = new System.Drawing.Point(27, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1355, 696);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "메뉴/재고 관리";
            // 
            // detailCmBoxOrigin
            // 
            this.detailCmBoxOrigin.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.detailCmBoxOrigin.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.detailCmBoxOrigin.FormattingEnabled = true;
            this.detailCmBoxOrigin.Location = new System.Drawing.Point(90, 151);
            this.detailCmBoxOrigin.Name = "detailCmBoxOrigin";
            this.detailCmBoxOrigin.Size = new System.Drawing.Size(182, 33);
            this.detailCmBoxOrigin.TabIndex = 32;
            // 
            // txtBoxIngredientOriginAdd
            // 
            this.txtBoxIngredientOriginAdd.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtBoxIngredientOriginAdd.Location = new System.Drawing.Point(400, 151);
            this.txtBoxIngredientOriginAdd.Name = "txtBoxIngredientOriginAdd";
            this.txtBoxIngredientOriginAdd.Size = new System.Drawing.Size(301, 31);
            this.txtBoxIngredientOriginAdd.TabIndex = 30;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label10.Location = new System.Drawing.Point(323, 154);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(108, 25);
            this.label10.TabIndex = 31;
            this.label10.Text = "원산지 추가";
            // 
            // btnAddCategory
            // 
            this.btnAddCategory.Location = new System.Drawing.Point(1213, 151);
            this.btnAddCategory.Name = "btnAddCategory";
            this.btnAddCategory.Size = new System.Drawing.Size(99, 22);
            this.btnAddCategory.TabIndex = 29;
            this.btnAddCategory.Text = "추가";
            this.btnAddCategory.UseVisualStyleBackColor = true;
            this.btnAddCategory.Click += new System.EventHandler(this.btnAddCategory_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label9.Location = new System.Drawing.Point(41, 154);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 25);
            this.label9.TabIndex = 28;
            this.label9.Text = "원산지";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(707, 85);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 28);
            this.button1.TabIndex = 26;
            this.button1.Text = "입/출고 관리";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label8.Location = new System.Drawing.Point(363, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 25);
            this.label8.TabIndex = 25;
            this.label8.Text = "재고";
            // 
            // detailTxtBoxMenuStock
            // 
            this.detailTxtBoxMenuStock.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.detailTxtBoxMenuStock.Location = new System.Drawing.Point(400, 88);
            this.detailTxtBoxMenuStock.Name = "detailTxtBoxMenuStock";
            this.detailTxtBoxMenuStock.Size = new System.Drawing.Size(301, 31);
            this.detailTxtBoxMenuStock.TabIndex = 24;
            // 
            // detailCmBoxMainCategory
            // 
            this.detailCmBoxMainCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.detailCmBoxMainCategory.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.detailCmBoxMainCategory.FormattingEnabled = true;
            this.detailCmBoxMainCategory.Location = new System.Drawing.Point(967, 88);
            this.detailCmBoxMainCategory.Name = "detailCmBoxMainCategory";
            this.detailCmBoxMainCategory.Size = new System.Drawing.Size(345, 33);
            this.detailCmBoxMainCategory.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(53, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 25);
            this.label5.TabIndex = 23;
            this.label5.Text = "가격";
            // 
            // detailTxtBoxMenuPrice
            // 
            this.detailTxtBoxMenuPrice.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.detailTxtBoxMenuPrice.Location = new System.Drawing.Point(90, 90);
            this.detailTxtBoxMenuPrice.Name = "detailTxtBoxMenuPrice";
            this.detailTxtBoxMenuPrice.Size = new System.Drawing.Size(182, 31);
            this.detailTxtBoxMenuPrice.TabIndex = 22;
            // 
            // txtBoxAddCategory
            // 
            this.txtBoxAddCategory.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtBoxAddCategory.Location = new System.Drawing.Point(967, 151);
            this.txtBoxAddCategory.Name = "txtBoxAddCategory";
            this.txtBoxAddCategory.Size = new System.Drawing.Size(240, 31);
            this.txtBoxAddCategory.TabIndex = 20;
            // 
            // detailTxtBoxMenuName
            // 
            this.detailTxtBoxMenuName.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.detailTxtBoxMenuName.Location = new System.Drawing.Point(400, 32);
            this.detailTxtBoxMenuName.Name = "detailTxtBoxMenuName";
            this.detailTxtBoxMenuName.Size = new System.Drawing.Size(424, 31);
            this.detailTxtBoxMenuName.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(890, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 25);
            this.label3.TabIndex = 19;
            this.label3.Text = "주 카테고리";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(351, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 25);
            this.label2.TabIndex = 17;
            this.label2.Text = "메뉴명";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(862, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 25);
            this.label4.TabIndex = 21;
            this.label4.Text = "주 카테고리 추가";
            // 
            // btnMainAddOrigin
            // 
            this.btnMainAddOrigin.Location = new System.Drawing.Point(707, 151);
            this.btnMainAddOrigin.Name = "btnMainAddOrigin";
            this.btnMainAddOrigin.Size = new System.Drawing.Size(117, 24);
            this.btnMainAddOrigin.TabIndex = 17;
            this.btnMainAddOrigin.Text = "추가";
            this.btnMainAddOrigin.UseVisualStyleBackColor = true;
            this.btnMainAddOrigin.Click += new System.EventHandler(this.btnMainAddOrigin_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(40, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "메뉴ID";
            // 
            // detailTxtBoxMenuID
            // 
            this.detailTxtBoxMenuID.Enabled = false;
            this.detailTxtBoxMenuID.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.detailTxtBoxMenuID.Location = new System.Drawing.Point(90, 32);
            this.detailTxtBoxMenuID.Name = "detailTxtBoxMenuID";
            this.detailTxtBoxMenuID.Size = new System.Drawing.Size(182, 31);
            this.detailTxtBoxMenuID.TabIndex = 16;
            // 
            // MenuManageForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1898, 1024);
            this.Controls.Add(this.menuManageMainLayout);
            this.Name = "MenuManageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MenuManageForm";
            this.menuManageMainLayout.ResumeLayout(false);
            this.tableLayoutPanelTitle.ResumeLayout(false);
            this.tableLayoutPanelTitle.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.doubleBufferedPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel menuManageMainLayout;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelTitle;
        private System.Windows.Forms.Label txtTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListView savedMenuListView;
        private System.Windows.Forms.ColumnHeader menuID;
        private System.Windows.Forms.ColumnHeader menuName;
        private System.Windows.Forms.ColumnHeader menuStock;
        private CustomControl.DoubleBufferedPanel doubleBufferedPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblMenuID;
        private System.Windows.Forms.Label lblOrigin;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblMaxPrice;
        private System.Windows.Forms.Label lblMinPrice;
        private System.Windows.Forms.Label lblMenuMainCategory;
        private System.Windows.Forms.Label lblMenuNameSearch;
        private System.Windows.Forms.TextBox txtBoxMenuIDSearch;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TextBox txtBoxMenuNameSearch;
        private System.Windows.Forms.ComboBox cmBoxMainCategorySelect;
        private System.Windows.Forms.TextBox txtBoxMaxPriceSearch;
        private System.Windows.Forms.TextBox txtBoxMinPriceSearch;
        private System.Windows.Forms.TextBox txtBoxMaxStockSearch;
        private System.Windows.Forms.TextBox txtBoxMinStockSearch;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button btnMenuSave;
        private System.Windows.Forms.Button btnMenuSearch;
        private System.Windows.Forms.ComboBox cmBoxOrigin;
        private System.Windows.Forms.TextBox detailTxtBoxMenuID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtBoxAddCategory;
        private System.Windows.Forms.ComboBox detailCmBoxMainCategory;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox detailTxtBoxMenuName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnMainAddOrigin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox detailTxtBoxMenuPrice;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox detailTxtBoxMenuStock;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtBoxIngredientOriginAdd;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnAddCategory;
        private System.Windows.Forms.ComboBox detailCmBoxOrigin;
        private System.Windows.Forms.Button btnMenuDelete;
        private System.Windows.Forms.Button btnNewMenu;
    }
}