namespace com.sbs.gui.DashBoard
{
    partial class fMain
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
            this.tSStatusLabel_whoOpen = new System.Windows.Forms.ToolStripStatusLabel();
            this.tSStatusLabel_separate = new System.Windows.Forms.ToolStripStatusLabel();
            this.tSStatusLabel_whenOpen = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tSStatusLabel_curWaiter = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl_main = new System.Windows.Forms.TabControl();
            this.tabPage_bill = new System.Windows.Forms.TabPage();
            this.dataGridView_bill = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bill_numb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.date_open = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ref_status_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage_dish = new System.Windows.Forms.TabPage();
            this.dataGridView_dish = new System.Windows.Forms.DataGridView();
            this.tabPage_refusing = new System.Windows.Forms.TabPage();
            this.dataGridView_refusing = new System.Windows.Forms.DataGridView();
            this.toolStrip_top = new System.Windows.Forms.ToolStrip();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox_billNumber = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_billDateOpen = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox_billTime = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox_billSum = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBox_billTable = new System.Windows.Forms.TextBox();
            this.tabControl_bill = new System.Windows.Forms.TabControl();
            this.tabPage_selectBill = new System.Windows.Forms.TabPage();
            this.dataGridView_billInfo = new System.Windows.Forms.DataGridView();
            this.billsinfo_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dishes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dishes_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dishes_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xcount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.suma = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ref_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.status_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isToppingFor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textBox_curItem = new System.Windows.Forms.TextBox();
            this.statusStrip_bottom.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl_main.SuspendLayout();
            this.tabPage_bill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_bill)).BeginInit();
            this.tabPage_dish.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_dish)).BeginInit();
            this.tabPage_refusing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_refusing)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tabControl_bill.SuspendLayout();
            this.tabPage_selectBill.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_billInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip_bottom
            // 
            this.statusStrip_bottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSStatusLabel_whoOpen,
            this.tSStatusLabel_separate,
            this.tSStatusLabel_whenOpen,
            this.toolStripStatusLabel1,
            this.tSStatusLabel_curWaiter});
            this.statusStrip_bottom.Location = new System.Drawing.Point(0, 571);
            this.statusStrip_bottom.Name = "statusStrip_bottom";
            this.statusStrip_bottom.Size = new System.Drawing.Size(997, 22);
            this.statusStrip_bottom.TabIndex = 0;
            this.statusStrip_bottom.Text = "statusStrip1";
            // 
            // tSStatusLabel_whoOpen
            // 
            this.tSStatusLabel_whoOpen.Name = "tSStatusLabel_whoOpen";
            this.tSStatusLabel_whoOpen.Size = new System.Drawing.Size(134, 17);
            this.tSStatusLabel_whoOpen.Text = "tSStatusLabel_whoOpen";
            // 
            // tSStatusLabel_separate
            // 
            this.tSStatusLabel_separate.Name = "tSStatusLabel_separate";
            this.tSStatusLabel_separate.Size = new System.Drawing.Size(25, 17);
            this.tSStatusLabel_separate.Text = "      ";
            // 
            // tSStatusLabel_whenOpen
            // 
            this.tSStatusLabel_whenOpen.Name = "tSStatusLabel_whenOpen";
            this.tSStatusLabel_whenOpen.Size = new System.Drawing.Size(140, 17);
            this.tSStatusLabel_whenOpen.Text = "tSStatusLabel_whenOpen";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(25, 17);
            this.toolStripStatusLabel1.Text = "      ";
            // 
            // tSStatusLabel_curWaiter
            // 
            this.tSStatusLabel_curWaiter.Name = "tSStatusLabel_curWaiter";
            this.tSStatusLabel_curWaiter.Size = new System.Drawing.Size(133, 17);
            this.tSStatusLabel_curWaiter.Text = "tSStatusLabel_curWaiter";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl_main);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip_top);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Size = new System.Drawing.Size(997, 542);
            this.splitContainer1.SplitterDistance = 444;
            this.splitContainer1.TabIndex = 1;
            this.splitContainer1.TabStop = false;
            // 
            // tabControl_main
            // 
            this.tabControl_main.Controls.Add(this.tabPage_bill);
            this.tabControl_main.Controls.Add(this.tabPage_dish);
            this.tabControl_main.Controls.Add(this.tabPage_refusing);
            this.tabControl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_main.Location = new System.Drawing.Point(0, 25);
            this.tabControl_main.Name = "tabControl_main";
            this.tabControl_main.SelectedIndex = 0;
            this.tabControl_main.Size = new System.Drawing.Size(444, 517);
            this.tabControl_main.TabIndex = 0;
            this.tabControl_main.TabStop = false;
            this.tabControl_main.SelectedIndexChanged += new System.EventHandler(this.tabControl_main_SelectedIndexChanged);
            // 
            // tabPage_bill
            // 
            this.tabPage_bill.Controls.Add(this.dataGridView_bill);
            this.tabPage_bill.Location = new System.Drawing.Point(4, 22);
            this.tabPage_bill.Name = "tabPage_bill";
            this.tabPage_bill.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_bill.Size = new System.Drawing.Size(436, 491);
            this.tabPage_bill.TabIndex = 0;
            this.tabPage_bill.Text = "tabPage_bill";
            // 
            // dataGridView_bill
            // 
            this.dataGridView_bill.AllowUserToAddRows = false;
            this.dataGridView_bill.AllowUserToDeleteRows = false;
            this.dataGridView_bill.AllowUserToResizeColumns = false;
            this.dataGridView_bill.AllowUserToResizeRows = false;
            this.dataGridView_bill.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView_bill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_bill.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.bill_numb,
            this.date_open,
            this.ref_status_name});
            this.dataGridView_bill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_bill.Location = new System.Drawing.Point(3, 3);
            this.dataGridView_bill.MultiSelect = false;
            this.dataGridView_bill.Name = "dataGridView_bill";
            this.dataGridView_bill.ReadOnly = true;
            this.dataGridView_bill.RowHeadersVisible = false;
            this.dataGridView_bill.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_bill.Size = new System.Drawing.Size(430, 485);
            this.dataGridView_bill.TabIndex = 0;
            this.dataGridView_bill.TabStop = false;
            this.dataGridView_bill.Leave += new System.EventHandler(this.dataGridView_bill_Leave);
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // bill_numb
            // 
            this.bill_numb.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.bill_numb.HeaderText = "№";
            this.bill_numb.Name = "bill_numb";
            this.bill_numb.ReadOnly = true;
            this.bill_numb.Width = 43;
            // 
            // date_open
            // 
            this.date_open.HeaderText = "date_open";
            this.date_open.Name = "date_open";
            this.date_open.ReadOnly = true;
            this.date_open.Visible = false;
            // 
            // ref_status_name
            // 
            this.ref_status_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ref_status_name.HeaderText = "Состояние";
            this.ref_status_name.Name = "ref_status_name";
            this.ref_status_name.ReadOnly = true;
            // 
            // tabPage_dish
            // 
            this.tabPage_dish.Controls.Add(this.dataGridView_dish);
            this.tabPage_dish.Location = new System.Drawing.Point(4, 22);
            this.tabPage_dish.Name = "tabPage_dish";
            this.tabPage_dish.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_dish.Size = new System.Drawing.Size(436, 491);
            this.tabPage_dish.TabIndex = 1;
            this.tabPage_dish.Text = "tabPage_dish";
            // 
            // dataGridView_dish
            // 
            this.dataGridView_dish.AllowUserToAddRows = false;
            this.dataGridView_dish.AllowUserToDeleteRows = false;
            this.dataGridView_dish.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView_dish.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_dish.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_dish.Location = new System.Drawing.Point(3, 3);
            this.dataGridView_dish.Name = "dataGridView_dish";
            this.dataGridView_dish.ReadOnly = true;
            this.dataGridView_dish.Size = new System.Drawing.Size(430, 485);
            this.dataGridView_dish.TabIndex = 0;
            this.dataGridView_dish.TabStop = false;
            this.dataGridView_dish.Leave += new System.EventHandler(this.dataGridView_dish_Leave);
            // 
            // tabPage_refusing
            // 
            this.tabPage_refusing.Controls.Add(this.dataGridView_refusing);
            this.tabPage_refusing.Location = new System.Drawing.Point(4, 22);
            this.tabPage_refusing.Name = "tabPage_refusing";
            this.tabPage_refusing.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_refusing.Size = new System.Drawing.Size(436, 491);
            this.tabPage_refusing.TabIndex = 2;
            this.tabPage_refusing.Text = "tabPage_refusing";
            // 
            // dataGridView_refusing
            // 
            this.dataGridView_refusing.AllowUserToAddRows = false;
            this.dataGridView_refusing.AllowUserToDeleteRows = false;
            this.dataGridView_refusing.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView_refusing.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_refusing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_refusing.Location = new System.Drawing.Point(3, 3);
            this.dataGridView_refusing.Name = "dataGridView_refusing";
            this.dataGridView_refusing.ReadOnly = true;
            this.dataGridView_refusing.Size = new System.Drawing.Size(430, 485);
            this.dataGridView_refusing.TabIndex = 0;
            this.dataGridView_refusing.TabStop = false;
            // 
            // toolStrip_top
            // 
            this.toolStrip_top.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip_top.Location = new System.Drawing.Point(0, 0);
            this.toolStrip_top.Name = "toolStrip_top";
            this.toolStrip_top.Size = new System.Drawing.Size(444, 25);
            this.toolStrip_top.TabIndex = 0;
            this.toolStrip_top.Text = "toolStrip1";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.tabControl_bill);
            this.splitContainer2.Size = new System.Drawing.Size(549, 542);
            this.splitContainer2.SplitterDistance = 128;
            this.splitContainer2.TabIndex = 0;
            this.splitContainer2.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox4, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.groupBox5, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 58F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(549, 128);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox_billNumber);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(158, 52);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Заказ №";
            // 
            // textBox_billNumber
            // 
            this.textBox_billNumber.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_billNumber.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_billNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_billNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_billNumber.ForeColor = System.Drawing.Color.Blue;
            this.textBox_billNumber.Location = new System.Drawing.Point(3, 22);
            this.textBox_billNumber.Name = "textBox_billNumber";
            this.textBox_billNumber.ReadOnly = true;
            this.textBox_billNumber.Size = new System.Drawing.Size(152, 22);
            this.textBox_billNumber.TabIndex = 0;
            this.textBox_billNumber.TabStop = false;
            this.textBox_billNumber.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox_billDateOpen);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(167, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(186, 52);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Дата открытия";
            // 
            // textBox_billDateOpen
            // 
            this.textBox_billDateOpen.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_billDateOpen.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_billDateOpen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_billDateOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_billDateOpen.ForeColor = System.Drawing.Color.Blue;
            this.textBox_billDateOpen.Location = new System.Drawing.Point(3, 22);
            this.textBox_billDateOpen.Name = "textBox_billDateOpen";
            this.textBox_billDateOpen.ReadOnly = true;
            this.textBox_billDateOpen.Size = new System.Drawing.Size(180, 22);
            this.textBox_billDateOpen.TabIndex = 1;
            this.textBox_billDateOpen.TabStop = false;
            this.textBox_billDateOpen.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox_billTime);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(359, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(187, 52);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Прошло";
            // 
            // textBox_billTime
            // 
            this.textBox_billTime.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_billTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_billTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_billTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_billTime.ForeColor = System.Drawing.Color.Blue;
            this.textBox_billTime.Location = new System.Drawing.Point(3, 22);
            this.textBox_billTime.Name = "textBox_billTime";
            this.textBox_billTime.ReadOnly = true;
            this.textBox_billTime.Size = new System.Drawing.Size(181, 22);
            this.textBox_billTime.TabIndex = 1;
            this.textBox_billTime.TabStop = false;
            this.textBox_billTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBox_billSum);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox4.Location = new System.Drawing.Point(3, 61);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(158, 64);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Сумма по счету";
            // 
            // textBox_billSum
            // 
            this.textBox_billSum.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_billSum.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_billSum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_billSum.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_billSum.ForeColor = System.Drawing.Color.Blue;
            this.textBox_billSum.Location = new System.Drawing.Point(3, 22);
            this.textBox_billSum.Name = "textBox_billSum";
            this.textBox_billSum.ReadOnly = true;
            this.textBox_billSum.Size = new System.Drawing.Size(152, 22);
            this.textBox_billSum.TabIndex = 1;
            this.textBox_billSum.TabStop = false;
            this.textBox_billSum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBox_billTable);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox5.Location = new System.Drawing.Point(167, 61);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(186, 64);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Стол №";
            // 
            // textBox_billTable
            // 
            this.textBox_billTable.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_billTable.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_billTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_billTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_billTable.ForeColor = System.Drawing.Color.Blue;
            this.textBox_billTable.Location = new System.Drawing.Point(3, 22);
            this.textBox_billTable.Name = "textBox_billTable";
            this.textBox_billTable.ReadOnly = true;
            this.textBox_billTable.Size = new System.Drawing.Size(180, 22);
            this.textBox_billTable.TabIndex = 1;
            this.textBox_billTable.TabStop = false;
            this.textBox_billTable.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tabControl_bill
            // 
            this.tabControl_bill.Controls.Add(this.tabPage_selectBill);
            this.tabControl_bill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_bill.Location = new System.Drawing.Point(0, 0);
            this.tabControl_bill.Name = "tabControl_bill";
            this.tabControl_bill.SelectedIndex = 0;
            this.tabControl_bill.Size = new System.Drawing.Size(549, 410);
            this.tabControl_bill.TabIndex = 0;
            this.tabControl_bill.TabStop = false;
            // 
            // tabPage_selectBill
            // 
            this.tabPage_selectBill.Controls.Add(this.dataGridView_billInfo);
            this.tabPage_selectBill.Location = new System.Drawing.Point(4, 22);
            this.tabPage_selectBill.Name = "tabPage_selectBill";
            this.tabPage_selectBill.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_selectBill.Size = new System.Drawing.Size(541, 384);
            this.tabPage_selectBill.TabIndex = 0;
            this.tabPage_selectBill.Text = "tabPage_selectBill";
            // 
            // dataGridView_billInfo
            // 
            this.dataGridView_billInfo.AllowUserToAddRows = false;
            this.dataGridView_billInfo.AllowUserToDeleteRows = false;
            this.dataGridView_billInfo.AllowUserToResizeColumns = false;
            this.dataGridView_billInfo.AllowUserToResizeRows = false;
            this.dataGridView_billInfo.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView_billInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_billInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.billsinfo_id,
            this.dishes,
            this.dishes_name,
            this.dishes_price,
            this.xcount,
            this.suma,
            this.ref_status,
            this.status_name,
            this.discount,
            this.isToppingFor});
            this.dataGridView_billInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_billInfo.Location = new System.Drawing.Point(3, 3);
            this.dataGridView_billInfo.MultiSelect = false;
            this.dataGridView_billInfo.Name = "dataGridView_billInfo";
            this.dataGridView_billInfo.ReadOnly = true;
            this.dataGridView_billInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_billInfo.Size = new System.Drawing.Size(535, 378);
            this.dataGridView_billInfo.TabIndex = 0;
            this.dataGridView_billInfo.TabStop = false;
            this.dataGridView_billInfo.Leave += new System.EventHandler(this.dataGridView_billInfo_Leave);
            // 
            // billsinfo_id
            // 
            this.billsinfo_id.HeaderText = "billsinfo_id";
            this.billsinfo_id.Name = "billsinfo_id";
            this.billsinfo_id.ReadOnly = true;
            this.billsinfo_id.Visible = false;
            // 
            // dishes
            // 
            this.dishes.HeaderText = "dishes";
            this.dishes.Name = "dishes";
            this.dishes.ReadOnly = true;
            this.dishes.Visible = false;
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
            this.dishes_price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dishes_price.HeaderText = "Цена";
            this.dishes_price.Name = "dishes_price";
            this.dishes_price.ReadOnly = true;
            this.dishes_price.Width = 58;
            // 
            // xcount
            // 
            this.xcount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.xcount.HeaderText = "Кол-во";
            this.xcount.Name = "xcount";
            this.xcount.ReadOnly = true;
            this.xcount.Width = 66;
            // 
            // suma
            // 
            this.suma.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.suma.HeaderText = "Сумма";
            this.suma.Name = "suma";
            this.suma.ReadOnly = true;
            this.suma.Width = 66;
            // 
            // ref_status
            // 
            this.ref_status.HeaderText = "ref_status";
            this.ref_status.Name = "ref_status";
            this.ref_status.ReadOnly = true;
            this.ref_status.Visible = false;
            // 
            // status_name
            // 
            this.status_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.status_name.HeaderText = "Статус";
            this.status_name.Name = "status_name";
            this.status_name.ReadOnly = true;
            this.status_name.Width = 66;
            // 
            // discount
            // 
            this.discount.HeaderText = "discount";
            this.discount.Name = "discount";
            this.discount.ReadOnly = true;
            this.discount.Visible = false;
            // 
            // isToppingFor
            // 
            this.isToppingFor.HeaderText = "isToppingFor";
            this.isToppingFor.Name = "isToppingFor";
            this.isToppingFor.ReadOnly = true;
            this.isToppingFor.Visible = false;
            // 
            // textBox_curItem
            // 
            this.textBox_curItem.BackColor = System.Drawing.SystemColors.Control;
            this.textBox_curItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBox_curItem.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox_curItem.Enabled = false;
            this.textBox_curItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_curItem.Location = new System.Drawing.Point(0, 542);
            this.textBox_curItem.Name = "textBox_curItem";
            this.textBox_curItem.ReadOnly = true;
            this.textBox_curItem.Size = new System.Drawing.Size(997, 29);
            this.textBox_curItem.TabIndex = 0;
            this.textBox_curItem.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 593);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.textBox_curItem);
            this.Controls.Add(this.statusStrip_bottom);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fMain";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.fMain_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fMain_KeyDown);
            this.statusStrip_bottom.ResumeLayout(false);
            this.statusStrip_bottom.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tabControl_main.ResumeLayout(false);
            this.tabPage_bill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_bill)).EndInit();
            this.tabPage_dish.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_dish)).EndInit();
            this.tabPage_refusing.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_refusing)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.tabControl_bill.ResumeLayout(false);
            this.tabPage_selectBill.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_billInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip_bottom;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TabControl tabControl_main;
        private System.Windows.Forms.TabPage tabPage_bill;
        private System.Windows.Forms.TabPage tabPage_dish;
        private System.Windows.Forms.DataGridView dataGridView_bill;
        private System.Windows.Forms.DataGridView dataGridView_dish;
        private System.Windows.Forms.TabPage tabPage_refusing;
        private System.Windows.Forms.DataGridView dataGridView_refusing;
        private System.Windows.Forms.TabControl tabControl_bill;
        private System.Windows.Forms.TabPage tabPage_selectBill;
        private System.Windows.Forms.DataGridView dataGridView_billInfo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripStatusLabel tSStatusLabel_whoOpen;
        private System.Windows.Forms.TextBox textBox_curItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_billNumber;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox textBox_billDateOpen;
        private System.Windows.Forms.TextBox textBox_billTime;
        private System.Windows.Forms.TextBox textBox_billSum;
        private System.Windows.Forms.TextBox textBox_billTable;
        private System.Windows.Forms.ToolStripStatusLabel tSStatusLabel_separate;
        private System.Windows.Forms.ToolStripStatusLabel tSStatusLabel_whenOpen;
        private System.Windows.Forms.ToolStrip toolStrip_top;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tSStatusLabel_curWaiter;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn bill_numb;
        private System.Windows.Forms.DataGridViewTextBoxColumn date_open;
        private System.Windows.Forms.DataGridViewTextBoxColumn ref_status_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn billsinfo_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn dishes;
        private System.Windows.Forms.DataGridViewTextBoxColumn dishes_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn dishes_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn xcount;
        private System.Windows.Forms.DataGridViewTextBoxColumn suma;
        private System.Windows.Forms.DataGridViewTextBoxColumn ref_status;
        private System.Windows.Forms.DataGridViewTextBoxColumn status_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn discount;
        private System.Windows.Forms.DataGridViewTextBoxColumn isToppingFor;
    }
}

