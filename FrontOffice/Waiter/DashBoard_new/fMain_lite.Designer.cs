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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel_bills = new System.Windows.Forms.Panel();
            this.dataGridView_bills = new System.Windows.Forms.DataGridView();
            this.panel_menuGroups = new System.Windows.Forms.Panel();
            this.panel_dishes = new System.Windows.Forms.Panel();
            this.panel_top = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_dateOpen = new System.Windows.Forms.Label();
            this.label_billType = new System.Windows.Forms.Label();
            this.label_billNumber = new System.Windows.Forms.Label();
            this.label_elapsedTime = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridView_billInfo = new System.Windows.Forms.DataGridView();
            this.statusStrip_billInfo = new System.Windows.Forms.StatusStrip();
            this.tSSLabel_countBillInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.label_leftAreaInfo = new System.Windows.Forms.Label();
            this.bills_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bills_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bills_table = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bills_sum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.billsinfo_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.billsinfo_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.billsinfo_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.billsinfo_count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.billsinfo_summ = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.billsinfo_refStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.treeView_CarteGroups = new System.Windows.Forms.TreeView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView_dishes = new System.Windows.Forms.DataGridView();
            this.panel_carteGroups = new System.Windows.Forms.Panel();
            this.panel_carteDishes = new System.Windows.Forms.Panel();
            this.dishes_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dishes_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dishes_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel_bills.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_bills)).BeginInit();
            this.panel_menuGroups.SuspendLayout();
            this.panel_top.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_billInfo)).BeginInit();
            this.statusStrip_billInfo.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_dishes)).BeginInit();
            this.panel_carteGroups.SuspendLayout();
            this.panel_carteDishes.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip_bottom
            // 
            this.statusStrip_bottom.Location = new System.Drawing.Point(0, 597);
            this.statusStrip_bottom.Name = "statusStrip_bottom";
            this.statusStrip_bottom.Size = new System.Drawing.Size(970, 22);
            this.statusStrip_bottom.SizingGrip = false;
            this.statusStrip_bottom.TabIndex = 0;
            this.statusStrip_bottom.Text = "statusStrip1";
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
            this.splitContainer1.Panel1.Controls.Add(this.panel_dishes);
            this.splitContainer1.Panel1.Controls.Add(this.panel_top);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(970, 597);
            this.splitContainer1.SplitterDistance = 494;
            this.splitContainer1.TabIndex = 1;
            this.splitContainer1.TabStop = false;
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
            this.bills_number,
            this.bills_table,
            this.bills_sum});
            this.dataGridView_bills.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_bills.Location = new System.Drawing.Point(0, 0);
            this.dataGridView_bills.MultiSelect = false;
            this.dataGridView_bills.Name = "dataGridView_bills";
            this.dataGridView_bills.ReadOnly = true;
            this.dataGridView_bills.RowHeadersVisible = false;
            this.dataGridView_bills.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataGridView_bills.RowTemplate.Height = 40;
            this.dataGridView_bills.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_bills.Size = new System.Drawing.Size(494, 565);
            this.dataGridView_bills.TabIndex = 0;
            this.dataGridView_bills.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView_bills_KeyDown);
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
            // panel_dishes
            // 
            this.panel_dishes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_dishes.Location = new System.Drawing.Point(0, 32);
            this.panel_dishes.Name = "panel_dishes";
            this.panel_dishes.Size = new System.Drawing.Size(494, 565);
            this.panel_dishes.TabIndex = 0;
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dataGridView_billInfo, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.statusStrip_billInfo, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 96F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(472, 597);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label_dateOpen);
            this.panel1.Controls.Add(this.label_billType);
            this.panel1.Controls.Add(this.label_billNumber);
            this.panel1.Controls.Add(this.label_elapsedTime);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(466, 90);
            this.panel1.TabIndex = 0;
            // 
            // label_dateOpen
            // 
            this.label_dateOpen.AutoSize = true;
            this.label_dateOpen.Location = new System.Drawing.Point(69, 71);
            this.label_dateOpen.Name = "label_dateOpen";
            this.label_dateOpen.Size = new System.Drawing.Size(82, 13);
            this.label_dateOpen.TabIndex = 6;
            this.label_dateOpen.Text = "label_dateOpen";
            // 
            // label_billType
            // 
            this.label_billType.AutoSize = true;
            this.label_billType.Location = new System.Drawing.Point(295, 15);
            this.label_billType.Name = "label_billType";
            this.label_billType.Size = new System.Drawing.Size(71, 13);
            this.label_billType.TabIndex = 5;
            this.label_billType.Text = "label_billType";
            // 
            // label_billNumber
            // 
            this.label_billNumber.AutoSize = true;
            this.label_billNumber.Location = new System.Drawing.Point(74, 15);
            this.label_billNumber.Name = "label_billNumber";
            this.label_billNumber.Size = new System.Drawing.Size(84, 13);
            this.label_billNumber.TabIndex = 4;
            this.label_billNumber.Text = "label_billNumber";
            // 
            // label_elapsedTime
            // 
            this.label_elapsedTime.AutoSize = true;
            this.label_elapsedTime.Location = new System.Drawing.Point(231, 71);
            this.label_elapsedTime.Name = "label_elapsedTime";
            this.label_elapsedTime.Size = new System.Drawing.Size(95, 13);
            this.label_elapsedTime.TabIndex = 3;
            this.label_elapsedTime.Text = "label_elapsedTime";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(231, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Тип счета";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(14, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Открыт:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
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
            this.dataGridView_billInfo.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataGridView_billInfo.RowTemplate.Height = 40;
            this.dataGridView_billInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_billInfo.Size = new System.Drawing.Size(466, 475);
            this.dataGridView_billInfo.TabIndex = 1;
            // 
            // statusStrip_billInfo
            // 
            this.statusStrip_billInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusStrip_billInfo.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSSLabel_countBillInfo});
            this.statusStrip_billInfo.Location = new System.Drawing.Point(0, 577);
            this.statusStrip_billInfo.Name = "statusStrip_billInfo";
            this.statusStrip_billInfo.Size = new System.Drawing.Size(472, 20);
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
            // bills_id
            // 
            this.bills_id.HeaderText = "id";
            this.bills_id.Name = "bills_id";
            this.bills_id.ReadOnly = true;
            this.bills_id.Visible = false;
            // 
            // bills_number
            // 
            this.bills_number.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.bills_number.HeaderText = "Счет №";
            this.bills_number.Name = "bills_number";
            this.bills_number.ReadOnly = true;
            // 
            // bills_table
            // 
            this.bills_table.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.bills_table.HeaderText = "Столик";
            this.bills_table.Name = "bills_table";
            this.bills_table.ReadOnly = true;
            // 
            // bills_sum
            // 
            this.bills_sum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.bills_sum.HeaderText = "Сумма";
            this.bills_sum.Name = "bills_sum";
            this.bills_sum.ReadOnly = true;
            // 
            // billsinfo_id
            // 
            this.billsinfo_id.HeaderText = "id";
            this.billsinfo_id.Name = "billsinfo_id";
            this.billsinfo_id.ReadOnly = true;
            this.billsinfo_id.Visible = false;
            // 
            // billsinfo_name
            // 
            this.billsinfo_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.billsinfo_name.HeaderText = "Наименование";
            this.billsinfo_name.Name = "billsinfo_name";
            this.billsinfo_name.ReadOnly = true;
            // 
            // billsinfo_price
            // 
            this.billsinfo_price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.billsinfo_price.HeaderText = "Стоимость";
            this.billsinfo_price.Name = "billsinfo_price";
            this.billsinfo_price.ReadOnly = true;
            this.billsinfo_price.Width = 87;
            // 
            // billsinfo_count
            // 
            this.billsinfo_count.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.billsinfo_count.HeaderText = "Кол-во";
            this.billsinfo_count.Name = "billsinfo_count";
            this.billsinfo_count.ReadOnly = true;
            this.billsinfo_count.Width = 66;
            // 
            // billsinfo_summ
            // 
            this.billsinfo_summ.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.billsinfo_summ.HeaderText = "Сумма";
            this.billsinfo_summ.Name = "billsinfo_summ";
            this.billsinfo_summ.ReadOnly = true;
            this.billsinfo_summ.Width = 66;
            // 
            // billsinfo_refStatus
            // 
            this.billsinfo_refStatus.HeaderText = "billsinfo_refStatus";
            this.billsinfo_refStatus.Name = "billsinfo_refStatus";
            this.billsinfo_refStatus.ReadOnly = true;
            this.billsinfo_refStatus.Visible = false;
            // 
            // treeView_CarteGroups
            // 
            this.treeView_CarteGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_CarteGroups.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treeView_CarteGroups.Location = new System.Drawing.Point(3, 3);
            this.treeView_CarteGroups.Name = "treeView_CarteGroups";
            this.treeView_CarteGroups.Size = new System.Drawing.Size(185, 533);
            this.treeView_CarteGroups.TabIndex = 0;
            this.treeView_CarteGroups.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_CarteGroups_AfterSelect);
            this.treeView_CarteGroups.KeyDown += new System.Windows.Forms.KeyEventHandler(this.treeView_CarteGroups_KeyDown);
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
            this.dataGridView_dishes.Location = new System.Drawing.Point(3, 3);
            this.dataGridView_dishes.MultiSelect = false;
            this.dataGridView_dishes.Name = "dataGridView_dishes";
            this.dataGridView_dishes.ReadOnly = true;
            this.dataGridView_dishes.RowHeadersVisible = false;
            this.dataGridView_dishes.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataGridView_dishes.RowTemplate.Height = 40;
            this.dataGridView_dishes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_dishes.Size = new System.Drawing.Size(285, 533);
            this.dataGridView_dishes.TabIndex = 1;
            this.dataGridView_dishes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView_dishes_KeyDown);
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
            // panel_carteDishes
            // 
            this.panel_carteDishes.Controls.Add(this.dataGridView_dishes);
            this.panel_carteDishes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_carteDishes.Location = new System.Drawing.Point(200, 3);
            this.panel_carteDishes.Name = "panel_carteDishes";
            this.panel_carteDishes.Padding = new System.Windows.Forms.Padding(3);
            this.panel_carteDishes.Size = new System.Drawing.Size(291, 539);
            this.panel_carteDishes.TabIndex = 3;
            // 
            // dishes_id
            // 
            this.dishes_id.HeaderText = "id";
            this.dishes_id.Name = "dishes_id";
            this.dishes_id.ReadOnly = true;
            this.dishes_id.Visible = false;
            // 
            // dishes_name
            // 
            this.dishes_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dishes_name.HeaderText = "Наименование";
            this.dishes_name.Name = "dishes_name";
            this.dishes_name.ReadOnly = true;
            // 
            // dishes_price
            // 
            this.dishes_price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dishes_price.HeaderText = "Стоимость";
            this.dishes_price.Name = "dishes_price";
            this.dishes_price.ReadOnly = true;
            this.dishes_price.Width = 87;
            // 
            // fMain_lite
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 619);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip_bottom);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "fMain_lite";
            this.ShowInTaskbar = false;
            this.Shown += new System.EventHandler(this.fMain_lite_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fMain_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel_bills.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_bills)).EndInit();
            this.panel_menuGroups.ResumeLayout(false);
            this.panel_top.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_billInfo)).EndInit();
            this.statusStrip_billInfo.ResumeLayout(false);
            this.statusStrip_billInfo.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_dishes)).EndInit();
            this.panel_carteGroups.ResumeLayout(false);
            this.panel_carteDishes.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip_bottom;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel_top;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel_bills;
        private System.Windows.Forms.Panel panel_dishes;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn bills_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn bills_number;
        private System.Windows.Forms.DataGridViewTextBoxColumn bills_table;
        private System.Windows.Forms.DataGridViewTextBoxColumn bills_sum;
        private System.Windows.Forms.DataGridViewTextBoxColumn billsinfo_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn billsinfo_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn billsinfo_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn billsinfo_count;
        private System.Windows.Forms.DataGridViewTextBoxColumn billsinfo_summ;
        private System.Windows.Forms.DataGridViewTextBoxColumn billsinfo_refStatus;
        private System.Windows.Forms.TreeView treeView_CarteGroups;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView dataGridView_dishes;
        private System.Windows.Forms.Panel panel_carteGroups;
        private System.Windows.Forms.Panel panel_carteDishes;
        private System.Windows.Forms.DataGridViewTextBoxColumn dishes_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn dishes_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn dishes_price;
    }
}

