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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl_main = new System.Windows.Forms.TabControl();
            this.tabPage_bill = new System.Windows.Forms.TabPage();
            this.dataGridView_bill = new System.Windows.Forms.DataGridView();
            this.tabPage_dish = new System.Windows.Forms.TabPage();
            this.dataGridView_dish = new System.Windows.Forms.DataGridView();
            this.tabPage_refusing = new System.Windows.Forms.TabPage();
            this.dataGridView_refusing = new System.Windows.Forms.DataGridView();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.tabControl_bill = new System.Windows.Forms.TabControl();
            this.tabPage_selectBill = new System.Windows.Forms.TabPage();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox_curItem = new System.Windows.Forms.TextBox();
            this.tSStatusLabel_whenOpen = new System.Windows.Forms.ToolStripStatusLabel();
            this.tSStatusLabel_separate = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip_top = new System.Windows.Forms.ToolStrip();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bill_numb = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ref_status_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip_bottom
            // 
            this.statusStrip_bottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSStatusLabel_whoOpen,
            this.tSStatusLabel_separate,
            this.tSStatusLabel_whenOpen});
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
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
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
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(176, 52);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Заказ №";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.ForeColor = System.Drawing.Color.Blue;
            this.textBox1.Location = new System.Drawing.Point(3, 22);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(170, 22);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "125";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox2.Location = new System.Drawing.Point(185, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(177, 52);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Дата открытия";
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox2.ForeColor = System.Drawing.Color.Blue;
            this.textBox2.Location = new System.Drawing.Point(3, 22);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(171, 22);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "125";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox3);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox3.Location = new System.Drawing.Point(368, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(178, 52);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Прошло";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Control;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox3.ForeColor = System.Drawing.Color.Blue;
            this.textBox3.Location = new System.Drawing.Point(3, 22);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(172, 22);
            this.textBox3.TabIndex = 1;
            this.textBox3.Text = "125";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBox4);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox4.Location = new System.Drawing.Point(3, 61);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(176, 64);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Сумма по счету";
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.Control;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox4.ForeColor = System.Drawing.Color.Blue;
            this.textBox4.Location = new System.Drawing.Point(3, 22);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(170, 22);
            this.textBox4.TabIndex = 1;
            this.textBox4.Text = "125";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.textBox5);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox5.Location = new System.Drawing.Point(185, 61);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(177, 64);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Стол №";
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.SystemColors.Control;
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox5.ForeColor = System.Drawing.Color.Blue;
            this.textBox5.Location = new System.Drawing.Point(3, 22);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(171, 22);
            this.textBox5.TabIndex = 1;
            this.textBox5.Text = "125";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // 
            // tabPage_selectBill
            // 
            this.tabPage_selectBill.Controls.Add(this.dataGridView1);
            this.tabPage_selectBill.Location = new System.Drawing.Point(4, 22);
            this.tabPage_selectBill.Name = "tabPage_selectBill";
            this.tabPage_selectBill.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_selectBill.Size = new System.Drawing.Size(541, 384);
            this.tabPage_selectBill.TabIndex = 0;
            this.tabPage_selectBill.Text = "tabPage_selectBill";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(535, 378);
            this.dataGridView1.TabIndex = 0;
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
            // tSStatusLabel_whenOpen
            // 
            this.tSStatusLabel_whenOpen.Name = "tSStatusLabel_whenOpen";
            this.tSStatusLabel_whenOpen.Size = new System.Drawing.Size(140, 17);
            this.tSStatusLabel_whenOpen.Text = "tSStatusLabel_whenOpen";
            // 
            // tSStatusLabel_separate
            // 
            this.tSStatusLabel_separate.Name = "tSStatusLabel_separate";
            this.tSStatusLabel_separate.Size = new System.Drawing.Size(25, 17);
            this.tSStatusLabel_separate.Text = "      ";
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
            // ref_status_name
            // 
            this.ref_status_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ref_status_name.HeaderText = "Состояние";
            this.ref_status_name.Name = "ref_status_name";
            this.ref_status_name.ReadOnly = true;
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
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
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
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripStatusLabel tSStatusLabel_whoOpen;
        private System.Windows.Forms.TextBox textBox_curItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.ToolStripStatusLabel tSStatusLabel_separate;
        private System.Windows.Forms.ToolStripStatusLabel tSStatusLabel_whenOpen;
        private System.Windows.Forms.ToolStrip toolStrip_top;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn bill_numb;
        private System.Windows.Forms.DataGridViewTextBoxColumn ref_status_name;
    }
}

