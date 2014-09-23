namespace com.sbs.gui.dashboard
{
    partial class fMain_lite
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
            this.statusStrip_bottom = new System.Windows.Forms.StatusStrip();
            this.tSSLabel_fio = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel_menuGroups = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel_carteGroups = new System.Windows.Forms.Panel();
            this.treeView_CarteGroups = new System.Windows.Forms.TreeView();
            this.panel_carteDishes = new System.Windows.Forms.Panel();
            this.panel_dishes = new System.Windows.Forms.Panel();
            this.groupBox_dishes = new System.Windows.Forms.GroupBox();
            this.dataGridView_dishes = new System.Windows.Forms.DataGridView();
            this.dishes_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dishes_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dishes_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel_refuse = new System.Windows.Forms.Panel();
            this.groupBox_refuse = new System.Windows.Forms.GroupBox();
            this.dataGridView_refuse = new System.Windows.Forms.DataGridView();
            this.refuse_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refuse_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refuse_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel_bills = new System.Windows.Forms.Panel();
            this.dataGridView_bills = new System.Windows.Forms.DataGridView();
            this.bills_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bills_oDeliveryBills = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bills_billType = new System.Windows.Forms.DataGridViewImageColumn();
            this.bills_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bills_table = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bills_sum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel_top = new System.Windows.Forms.Panel();
            this.label_leftAreaInfo = new System.Windows.Forms.Label();
            this.tableLayoutPanel_billsInfo = new System.Windows.Forms.TableLayoutPanel();
            this.panel_BillsInfoHeader = new System.Windows.Forms.Panel();
            this.label_billSum = new System.Windows.Forms.Label();
            this.label_dateOpen = new System.Windows.Forms.Label();
            this.label_billType = new System.Windows.Forms.Label();
            this.label_billNumber = new System.Windows.Forms.Label();
            this.label_elapsedTime = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView_billInfo = new System.Windows.Forms.DataGridView();
            this.billsinfo_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.billsinfo_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.billsinfo_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.billsinfo_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.billsinfo_summ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.billsinfo_refStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip_billInfo = new System.Windows.Forms.StatusStrip();
            this.tSSLabel_countBillInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip_bottom.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel_menuGroups.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel_carteGroups.SuspendLayout();
            this.panel_carteDishes.SuspendLayout();
            this.panel_dishes.SuspendLayout();
            this.groupBox_dishes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_dishes)).BeginInit();
            this.panel_refuse.SuspendLayout();
            this.groupBox_refuse.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_refuse)).BeginInit();
            this.panel_bills.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_bills)).BeginInit();
            this.panel_top.SuspendLayout();
            this.tableLayoutPanel_billsInfo.SuspendLayout();
            this.panel_BillsInfoHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_billInfo)).BeginInit();
            this.statusStrip_billInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip_bottom
            // 
            this.statusStrip_bottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSSLabel_fio});
            this.statusStrip_bottom.Location = new System.Drawing.Point(0, 597);
            this.statusStrip_bottom.Name = "statusStrip_bottom";
            this.statusStrip_bottom.Size = new System.Drawing.Size(970, 22);
            this.statusStrip_bottom.SizingGrip = false;
            this.statusStrip_bottom.TabIndex = 0;
            this.statusStrip_bottom.Text = "statusStrip1";
            // 
            // tSSLabel_fio
            // 
            this.tSSLabel_fio.Name = "tSSLabel_fio";
            this.tSSLabel_fio.Size = new System.Drawing.Size(118, 17);
            this.tSSLabel_fio.Text = "toolStripStatusLabel1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel_menuGroups);
            this.splitContainer1.Panel1.Controls.Add(this.panel_bills);
            this.splitContainer1.Panel1.Controls.Add(this.panel_top);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel_billsInfo);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(3);
            this.splitContainer1.Size = new System.Drawing.Size(970, 597);
            this.splitContainer1.SplitterDistance = 494;
            this.splitContainer1.TabIndex = 1;
            this.splitContainer1.TabStop = false;
            // 
            // panel_menuGroups
            // 
            this.panel_menuGroups.Controls.Add(this.tableLayoutPanel2);
            this.panel_menuGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_menuGroups.Location = new System.Drawing.Point(0, 32);
            this.panel_menuGroups.Name = "panel_menuGroups";
            this.panel_menuGroups.Size = new System.Drawing.Size(494, 565);
            this.panel_menuGroups.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel2.Controls.Add(this.panel_carteGroups, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.panel_carteDishes, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(494, 565);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // panel_carteGroups
            // 
            this.panel_carteGroups.Controls.Add(this.treeView_CarteGroups);
            this.panel_carteGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_carteGroups.Location = new System.Drawing.Point(3, 3);
            this.panel_carteGroups.Name = "panel_carteGroups";
            this.panel_carteGroups.Padding = new System.Windows.Forms.Padding(3);
            this.panel_carteGroups.Size = new System.Drawing.Size(191, 539);
            this.panel_carteGroups.TabIndex = 2;
            // 
            // treeView_CarteGroups
            // 
            this.treeView_CarteGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_CarteGroups.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treeView_CarteGroups.Location = new System.Drawing.Point(3, 3);
            this.treeView_CarteGroups.Name = "treeView_CarteGroups";
            this.treeView_CarteGroups.Size = new System.Drawing.Size(185, 533);
            this.treeView_CarteGroups.TabIndex = 0;
            this.treeView_CarteGroups.TabStop = false;
            this.treeView_CarteGroups.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_CarteGroups_AfterSelect);
            this.treeView_CarteGroups.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeView_CarteGroups_KeyDown);
            // 
            // panel_carteDishes
            // 
            this.panel_carteDishes.Controls.Add(this.panel_dishes);
            this.panel_carteDishes.Controls.Add(this.panel_refuse);
            this.panel_carteDishes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_carteDishes.Location = new System.Drawing.Point(200, 3);
            this.panel_carteDishes.Name = "panel_carteDishes";
            this.panel_carteDishes.Size = new System.Drawing.Size(291, 539);
            this.panel_carteDishes.TabIndex = 3;
            // 
            // panel_dishes
            // 
            this.panel_dishes.Controls.Add(this.groupBox_dishes);
            this.panel_dishes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_dishes.Location = new System.Drawing.Point(0, 0);
            this.panel_dishes.Name = "panel_dishes";
            this.panel_dishes.Padding = new System.Windows.Forms.Padding(3);
            this.panel_dishes.Size = new System.Drawing.Size(291, 393);
            this.panel_dishes.TabIndex = 5;
            // 
            // groupBox_dishes
            // 
            this.groupBox_dishes.Controls.Add(this.dataGridView_dishes);
            this.groupBox_dishes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_dishes.Location = new System.Drawing.Point(3, 3);
            this.groupBox_dishes.Name = "groupBox_dishes";
            this.groupBox_dishes.Size = new System.Drawing.Size(285, 387);
            this.groupBox_dishes.TabIndex = 3;
            this.groupBox_dishes.TabStop = false;
            this.groupBox_dishes.Text = "Наименования";
            // 
            // dataGridView_dishes
            // 
            this.dataGridView_dishes.AllowUserToAddRows = false;
            this.dataGridView_dishes.AllowUserToDeleteRows = false;
            this.dataGridView_dishes.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView_dishes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_dishes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dishes_id,
            this.dishes_name,
            this.dishes_price});
            this.dataGridView_dishes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_dishes.Location = new System.Drawing.Point(3, 16);
            this.dataGridView_dishes.MultiSelect = false;
            this.dataGridView_dishes.Name = "dataGridView_dishes";
            this.dataGridView_dishes.ReadOnly = true;
            this.dataGridView_dishes.RowHeadersVisible = false;
            this.dataGridView_dishes.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataGridView_dishes.RowTemplate.Height = 25;
            this.dataGridView_dishes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_dishes.Size = new System.Drawing.Size(279, 368);
            this.dataGridView_dishes.TabIndex = 1;
            this.dataGridView_dishes.TabStop = false;
            this.dataGridView_dishes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView_dishes_KeyDown);
            // 
            // dishes_id
            // 
            this.dishes_id.HeaderText = "id";
            this.dishes_id.Name = "dishes_id";
            this.dishes_id.ReadOnly = true;
            this.dishes_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dishes_id.Visible = false;
            // 
            // dishes_name
            // 
            this.dishes_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dishes_name.HeaderText = "Наименование";
            this.dishes_name.Name = "dishes_name";
            this.dishes_name.ReadOnly = true;
            this.dishes_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // dishes_price
            // 
            this.dishes_price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dishes_price.HeaderText = "Стоимость";
            this.dishes_price.Name = "dishes_price";
            this.dishes_price.ReadOnly = true;
            this.dishes_price.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.dishes_price.Width = 68;
            // 
            // panel_refuse
            // 
            this.panel_refuse.Controls.Add(this.groupBox_refuse);
            this.panel_refuse.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_refuse.Location = new System.Drawing.Point(0, 393);
            this.panel_refuse.Name = "panel_refuse";
            this.panel_refuse.Padding = new System.Windows.Forms.Padding(3);
            this.panel_refuse.Size = new System.Drawing.Size(291, 146);
            this.panel_refuse.TabIndex = 4;
            this.panel_refuse.Visible = false;
            // 
            // groupBox_refuse
            // 
            this.groupBox_refuse.Controls.Add(this.dataGridView_refuse);
            this.groupBox_refuse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_refuse.Location = new System.Drawing.Point(3, 3);
            this.groupBox_refuse.Name = "groupBox_refuse";
            this.groupBox_refuse.Size = new System.Drawing.Size(285, 140);
            this.groupBox_refuse.TabIndex = 2;
            this.groupBox_refuse.TabStop = false;
            this.groupBox_refuse.Text = "Висяки";
            // 
            // dataGridView_refuse
            // 
            this.dataGridView_refuse.AllowUserToAddRows = false;
            this.dataGridView_refuse.AllowUserToDeleteRows = false;
            this.dataGridView_refuse.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView_refuse.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_refuse.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.refuse_id,
            this.refuse_name,
            this.refuse_count});
            this.dataGridView_refuse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_refuse.Location = new System.Drawing.Point(3, 16);
            this.dataGridView_refuse.Name = "dataGridView_refuse";
            this.dataGridView_refuse.ReadOnly = true;
            this.dataGridView_refuse.RowHeadersVisible = false;
            this.dataGridView_refuse.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_refuse.Size = new System.Drawing.Size(279, 121);
            this.dataGridView_refuse.TabIndex = 0;
            this.dataGridView_refuse.TabStop = false;
            this.dataGridView_refuse.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView_refuse_KeyDown);
            // 
            // refuse_id
            // 
            this.refuse_id.HeaderText = "id";
            this.refuse_id.Name = "refuse_id";
            this.refuse_id.ReadOnly = true;
            this.refuse_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.refuse_id.Visible = false;
            // 
            // refuse_name
            // 
            this.refuse_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.refuse_name.HeaderText = "Наименование";
            this.refuse_name.Name = "refuse_name";
            this.refuse_name.ReadOnly = true;
            this.refuse_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // refuse_count
            // 
            this.refuse_count.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.refuse_count.HeaderText = "Кол-во";
            this.refuse_count.Name = "refuse_count";
            this.refuse_count.ReadOnly = true;
            this.refuse_count.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.refuse_count.Width = 47;
            // 
            // panel_bills
            // 
            this.panel_bills.Controls.Add(this.dataGridView_bills);
            this.panel_bills.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_bills.Location = new System.Drawing.Point(0, 32);
            this.panel_bills.Name = "panel_bills";
            this.panel_bills.Size = new System.Drawing.Size(494, 565);
            this.panel_bills.TabIndex = 1;
            // 
            // dataGridView_bills
            // 
            this.dataGridView_bills.AllowUserToAddRows = false;
            this.dataGridView_bills.AllowUserToDeleteRows = false;
            this.dataGridView_bills.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView_bills.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_bills.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bills_id,
            this.bills_oDeliveryBills,
            this.bills_billType,
            this.bills_number,
            this.bills_table,
            this.bills_sum});
            this.dataGridView_bills.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_bills.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_bills.MultiSelect = false;
            this.dataGridView_bills.Name = "dataGridView_bills";
            this.dataGridView_bills.ReadOnly = true;
            this.dataGridView_bills.RowHeadersVisible = false;
            this.dataGridView_bills.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataGridView_bills.RowTemplate.Height = 25;
            this.dataGridView_bills.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_bills.Size = new System.Drawing.Size(494, 565);
            this.dataGridView_bills.TabIndex = 0;
            this.dataGridView_bills.TabStop = false;
            this.dataGridView_bills.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView_bills_KeyDown);
            // 
            // bills_id
            // 
            this.bills_id.HeaderText = "id";
            this.bills_id.Name = "bills_id";
            this.bills_id.ReadOnly = true;
            this.bills_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.bills_id.Visible = false;
            // 
            // bills_oDeliveryBills
            // 
            this.bills_oDeliveryBills.HeaderText = "bills_oDeliveryBills";
            this.bills_oDeliveryBills.Name = "bills_oDeliveryBills";
            this.bills_oDeliveryBills.ReadOnly = true;
            this.bills_oDeliveryBills.Visible = false;
            // 
            // bills_billType
            // 
            this.bills_billType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.bills_billType.HeaderText = "";
            this.bills_billType.Name = "bills_billType";
            this.bills_billType.ReadOnly = true;
            this.bills_billType.Width = 5;
            // 
            // bills_number
            // 
            this.bills_number.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.bills_number.HeaderText = "Счет №";
            this.bills_number.Name = "bills_number";
            this.bills_number.ReadOnly = true;
            this.bills_number.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // bills_table
            // 
            this.bills_table.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.bills_table.HeaderText = "Столик";
            this.bills_table.Name = "bills_table";
            this.bills_table.ReadOnly = true;
            this.bills_table.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // bills_sum
            // 
            this.bills_sum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.bills_sum.HeaderText = "Сумма";
            this.bills_sum.Name = "bills_sum";
            this.bills_sum.ReadOnly = true;
            this.bills_sum.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // panel_top
            // 
            this.panel_top.Controls.Add(this.label_leftAreaInfo);
            this.panel_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_top.Location = new System.Drawing.Point(0, 0);
            this.panel_top.Name = "panel_top";
            this.panel_top.Size = new System.Drawing.Size(494, 32);
            this.panel_top.TabIndex = 0;
            // 
            // label_leftAreaInfo
            // 
            this.label_leftAreaInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_leftAreaInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_leftAreaInfo.ForeColor = System.Drawing.Color.Blue;
            this.label_leftAreaInfo.Location = new System.Drawing.Point(0, 0);
            this.label_leftAreaInfo.Name = "label_leftAreaInfo";
            this.label_leftAreaInfo.Size = new System.Drawing.Size(494, 32);
            this.label_leftAreaInfo.TabIndex = 0;
            this.label_leftAreaInfo.Text = "label_leftAreaInfo";
            this.label_leftAreaInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel_billsInfo
            // 
            this.tableLayoutPanel_billsInfo.ColumnCount = 1;
            this.tableLayoutPanel_billsInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_billsInfo.Controls.Add(this.panel_BillsInfoHeader, 0, 0);
            this.tableLayoutPanel_billsInfo.Controls.Add(this.dataGridView_billInfo, 0, 1);
            this.tableLayoutPanel_billsInfo.Controls.Add(this.statusStrip_billInfo, 0, 2);
            this.tableLayoutPanel_billsInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_billsInfo.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel_billsInfo.Name = "tableLayoutPanel_billsInfo";
            this.tableLayoutPanel_billsInfo.RowCount = 3;
            this.tableLayoutPanel_billsInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tableLayoutPanel_billsInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_billsInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_billsInfo.Size = new System.Drawing.Size(466, 591);
            this.tableLayoutPanel_billsInfo.TabIndex = 0;
            // 
            // panel_BillsInfoHeader
            // 
            this.panel_BillsInfoHeader.Controls.Add(this.label_billSum);
            this.panel_BillsInfoHeader.Controls.Add(this.label_dateOpen);
            this.panel_BillsInfoHeader.Controls.Add(this.label_billType);
            this.panel_BillsInfoHeader.Controls.Add(this.label_billNumber);
            this.panel_BillsInfoHeader.Controls.Add(this.label_elapsedTime);
            this.panel_BillsInfoHeader.Controls.Add(this.label3);
            this.panel_BillsInfoHeader.Controls.Add(this.label2);
            this.panel_BillsInfoHeader.Controls.Add(this.label1);
            this.panel_BillsInfoHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_BillsInfoHeader.Location = new System.Drawing.Point(3, 3);
            this.panel_BillsInfoHeader.Name = "panel_BillsInfoHeader";
            this.panel_BillsInfoHeader.Size = new System.Drawing.Size(460, 90);
            this.panel_BillsInfoHeader.TabIndex = 0;
            // 
            // label_billSum
            // 
            this.label_billSum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label_billSum.AutoSize = true;
            this.label_billSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_billSum.ForeColor = System.Drawing.Color.Blue;
            this.label_billSum.Location = new System.Drawing.Point(350, 54);
            this.label_billSum.Name = "label_billSum";
            this.label_billSum.Size = new System.Drawing.Size(104, 17);
            this.label_billSum.TabIndex = 7;
            this.label_billSum.Text = "label_billSum";
            // 
            // label_dateOpen
            // 
            this.label_dateOpen.AutoSize = true;
            this.label_dateOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_dateOpen.Location = new System.Drawing.Point(84, 54);
            this.label_dateOpen.Name = "label_dateOpen";
            this.label_dateOpen.Size = new System.Drawing.Size(109, 17);
            this.label_dateOpen.TabIndex = 6;
            this.label_dateOpen.Text = "label_dateOpen";
            // 
            // label_billType
            // 
            this.label_billType.AutoSize = true;
            this.label_billType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_billType.Location = new System.Drawing.Point(295, 15);
            this.label_billType.Name = "label_billType";
            this.label_billType.Size = new System.Drawing.Size(95, 17);
            this.label_billType.TabIndex = 5;
            this.label_billType.Text = "label_billType";
            // 
            // label_billNumber
            // 
            this.label_billNumber.AutoSize = true;
            this.label_billNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_billNumber.Location = new System.Drawing.Point(84, 15);
            this.label_billNumber.Name = "label_billNumber";
            this.label_billNumber.Size = new System.Drawing.Size(113, 17);
            this.label_billNumber.TabIndex = 4;
            this.label_billNumber.Text = "label_billNumber";
            // 
            // label_elapsedTime
            // 
            this.label_elapsedTime.AutoSize = true;
            this.label_elapsedTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_elapsedTime.Location = new System.Drawing.Point(205, 54);
            this.label_elapsedTime.Name = "label_elapsedTime";
            this.label_elapsedTime.Size = new System.Drawing.Size(127, 17);
            this.label_elapsedTime.TabIndex = 3;
            this.label_elapsedTime.Text = "label_elapsedTime";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(205, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Тип счета";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(14, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Открыт:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(14, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Счет №";
            // 
            // dataGridView_billInfo
            // 
            this.dataGridView_billInfo.AllowUserToAddRows = false;
            this.dataGridView_billInfo.AllowUserToDeleteRows = false;
            this.dataGridView_billInfo.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView_billInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_billInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.billsinfo_id,
            this.billsinfo_name,
            this.billsinfo_price,
            this.billsinfo_count,
            this.billsinfo_summ,
            this.billsinfo_refStatus});
            this.dataGridView_billInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_billInfo.Location = new System.Drawing.Point(3, 99);
            this.dataGridView_billInfo.MultiSelect = false;
            this.dataGridView_billInfo.Name = "dataGridView_billInfo";
            this.dataGridView_billInfo.ReadOnly = true;
            this.dataGridView_billInfo.RowHeadersVisible = false;
            this.dataGridView_billInfo.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataGridView_billInfo.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dataGridView_billInfo.RowTemplate.Height = 25;
            this.dataGridView_billInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_billInfo.Size = new System.Drawing.Size(460, 469);
            this.dataGridView_billInfo.TabIndex = 1;
            this.dataGridView_billInfo.TabStop = false;
            this.dataGridView_billInfo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView_billInfo_KeyDown);
            // 
            // billsinfo_id
            // 
            this.billsinfo_id.HeaderText = "id";
            this.billsinfo_id.Name = "billsinfo_id";
            this.billsinfo_id.ReadOnly = true;
            this.billsinfo_id.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.billsinfo_id.Visible = false;
            // 
            // billsinfo_name
            // 
            this.billsinfo_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.billsinfo_name.HeaderText = "Наименование";
            this.billsinfo_name.Name = "billsinfo_name";
            this.billsinfo_name.ReadOnly = true;
            this.billsinfo_name.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // billsinfo_price
            // 
            this.billsinfo_price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.billsinfo_price.HeaderText = "Стоимость";
            this.billsinfo_price.Name = "billsinfo_price";
            this.billsinfo_price.ReadOnly = true;
            this.billsinfo_price.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.billsinfo_price.Width = 68;
            // 
            // billsinfo_count
            // 
            this.billsinfo_count.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.billsinfo_count.HeaderText = "Кол-во";
            this.billsinfo_count.Name = "billsinfo_count";
            this.billsinfo_count.ReadOnly = true;
            this.billsinfo_count.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.billsinfo_count.Width = 47;
            // 
            // billsinfo_summ
            // 
            this.billsinfo_summ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.billsinfo_summ.HeaderText = "Сумма";
            this.billsinfo_summ.Name = "billsinfo_summ";
            this.billsinfo_summ.ReadOnly = true;
            this.billsinfo_summ.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.billsinfo_summ.Width = 47;
            // 
            // billsinfo_refStatus
            // 
            this.billsinfo_refStatus.HeaderText = "billsinfo_refStatus";
            this.billsinfo_refStatus.Name = "billsinfo_refStatus";
            this.billsinfo_refStatus.ReadOnly = true;
            this.billsinfo_refStatus.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.billsinfo_refStatus.Visible = false;
            // 
            // statusStrip_billInfo
            // 
            this.statusStrip_billInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusStrip_billInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSSLabel_countBillInfo});
            this.statusStrip_billInfo.Location = new System.Drawing.Point(0, 571);
            this.statusStrip_billInfo.Name = "statusStrip_billInfo";
            this.statusStrip_billInfo.Size = new System.Drawing.Size(466, 20);
            this.statusStrip_billInfo.SizingGrip = false;
            this.statusStrip_billInfo.TabIndex = 2;
            this.statusStrip_billInfo.Text = "statusStrip1";
            // 
            // tSSLabel_countBillInfo
            // 
            this.tSSLabel_countBillInfo.Name = "tSSLabel_countBillInfo";
            this.tSSLabel_countBillInfo.Size = new System.Drawing.Size(124, 15);
            this.tSSLabel_countBillInfo.Text = "tSSLabel_countBillInfo";
            // 
            // fMain_lite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 619);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip_bottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "fMain_lite";
            this.ShowInTaskbar = false;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.fMain_lite_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fMain_KeyDown);
            this.statusStrip_bottom.ResumeLayout(false);
            this.statusStrip_bottom.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel_menuGroups.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel_carteGroups.ResumeLayout(false);
            this.panel_carteDishes.ResumeLayout(false);
            this.panel_dishes.ResumeLayout(false);
            this.groupBox_dishes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_dishes)).EndInit();
            this.panel_refuse.ResumeLayout(false);
            this.groupBox_refuse.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_refuse)).EndInit();
            this.panel_bills.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_bills)).EndInit();
            this.panel_top.ResumeLayout(false);
            this.tableLayoutPanel_billsInfo.ResumeLayout(false);
            this.tableLayoutPanel_billsInfo.PerformLayout();
            this.panel_BillsInfoHeader.ResumeLayout(false);
            this.panel_BillsInfoHeader.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_billInfo)).EndInit();
            this.statusStrip_billInfo.ResumeLayout(false);
            this.statusStrip_billInfo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip_bottom;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel_top;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_billsInfo;
        private System.Windows.Forms.Panel panel_BillsInfoHeader;
        private System.Windows.Forms.Panel panel_bills;
        private System.Windows.Forms.Panel panel_menuGroups;
        private System.Windows.Forms.DataGridView dataGridView_bills;
        private System.Windows.Forms.DataGridView dataGridView_billInfo;
        private System.Windows.Forms.Label label_elapsedTime;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_dateOpen;
        private System.Windows.Forms.Label label_billType;
        private System.Windows.Forms.Label label_billNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.StatusStrip statusStrip_billInfo;
        private System.Windows.Forms.ToolStripStatusLabel tSSLabel_countBillInfo;
        private System.Windows.Forms.Label label_leftAreaInfo;
        private System.Windows.Forms.TreeView treeView_CarteGroups;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView dataGridView_dishes;
        private System.Windows.Forms.Panel panel_carteGroups;
        private System.Windows.Forms.Panel panel_carteDishes;
        private System.Windows.Forms.GroupBox groupBox_refuse;
        private System.Windows.Forms.DataGridView dataGridView_refuse;
        private System.Windows.Forms.GroupBox groupBox_dishes;
        private System.Windows.Forms.Panel panel_dishes;
        private System.Windows.Forms.Panel panel_refuse;
        private System.Windows.Forms.DataGridViewTextBoxColumn dishes_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn dishes_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn dishes_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn refuse_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn refuse_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn refuse_count;
        private System.Windows.Forms.DataGridViewTextBoxColumn billsinfo_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn billsinfo_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn billsinfo_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn billsinfo_count;
        private System.Windows.Forms.DataGridViewTextBoxColumn billsinfo_summ;
        private System.Windows.Forms.DataGridViewTextBoxColumn billsinfo_refStatus;
        private System.Windows.Forms.Label label_billSum;
        private System.Windows.Forms.DataGridViewTextBoxColumn bills_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn bills_oDeliveryBills;
        private System.Windows.Forms.DataGridViewImageColumn bills_billType;
        private System.Windows.Forms.DataGridViewTextBoxColumn bills_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn bills_table;
        private System.Windows.Forms.DataGridViewTextBoxColumn bills_sum;
        private System.Windows.Forms.ToolStripStatusLabel tSSLabel_fio;
    }
}

