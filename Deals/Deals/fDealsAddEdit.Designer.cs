namespace com.sbs.gui.deals
{
    partial class fDealsAddEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fDealsAddEdit));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView_dish = new System.Windows.Forms.DataGridView();
            this.dish_refDishes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dish_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dish_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip_dishBottom = new System.Windows.Forms.StatusStrip();
            this.tSSLabel_dishCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip_dishTop = new System.Windows.Forms.ToolStrip();
            this.tSButton_dishAdd = new System.Windows.Forms.ToolStripButton();
            this.tSButton_dishDel = new System.Windows.Forms.ToolStripButton();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_dealsId = new System.Windows.Forms.TextBox();
            this.textBox_dealsName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_dealsStatus = new System.Windows.Forms.ComboBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView_bonus = new System.Windows.Forms.DataGridView();
            this.bonus_refDishes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bonus_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bonus_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip_bonusBottom = new System.Windows.Forms.StatusStrip();
            this.tSSLabel_bonusCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip_bonusTop = new System.Windows.Forms.ToolStrip();
            this.tSButton_bonusAdd = new System.Windows.Forms.ToolStripButton();
            this.tSButton_bonusDel = new System.Windows.Forms.ToolStripButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBox_sumCount = new System.Windows.Forms.CheckBox();
            this.numericUpDown_sumCount = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimePicker_start = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_end = new System.Windows.Forms.DateTimePicker();
            this.button_save = new System.Windows.Forms.Button();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_dish)).BeginInit();
            this.statusStrip_dishBottom.SuspendLayout();
            this.toolStrip_dishTop.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_bonus)).BeginInit();
            this.statusStrip_bonusBottom.SuspendLayout();
            this.toolStrip_bonusTop.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_sumCount)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox4);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Size = new System.Drawing.Size(833, 491);
            this.splitContainer1.SplitterDistance = 395;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView_dish);
            this.groupBox1.Controls.Add(this.statusStrip_dishBottom);
            this.groupBox1.Controls.Add(this.toolStrip_dishTop);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(2, 114);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(391, 375);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Позиции участвующие в акции";
            // 
            // dataGridView_dish
            // 
            this.dataGridView_dish.AllowUserToAddRows = false;
            this.dataGridView_dish.AllowUserToDeleteRows = false;
            this.dataGridView_dish.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView_dish.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_dish.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_dish.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dish_refDishes,
            this.dish_name,
            this.dish_price});
            this.dataGridView_dish.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_dish.Location = new System.Drawing.Point(3, 41);
            this.dataGridView_dish.MultiSelect = false;
            this.dataGridView_dish.Name = "dataGridView_dish";
            this.dataGridView_dish.ReadOnly = true;
            this.dataGridView_dish.RowHeadersVisible = false;
            this.dataGridView_dish.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_dish.Size = new System.Drawing.Size(385, 309);
            this.dataGridView_dish.TabIndex = 1;
            // 
            // dish_refDishes
            // 
            this.dish_refDishes.HeaderText = "id";
            this.dish_refDishes.Name = "dish_refDishes";
            this.dish_refDishes.ReadOnly = true;
            this.dish_refDishes.Visible = false;
            // 
            // dish_name
            // 
            this.dish_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dish_name.HeaderText = "Наименование";
            this.dish_name.Name = "dish_name";
            this.dish_name.ReadOnly = true;
            // 
            // dish_price
            // 
            this.dish_price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dish_price.HeaderText = "Цена";
            this.dish_price.Name = "dish_price";
            this.dish_price.ReadOnly = true;
            this.dish_price.Width = 58;
            // 
            // statusStrip_dishBottom
            // 
            this.statusStrip_dishBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSSLabel_dishCount});
            this.statusStrip_dishBottom.Location = new System.Drawing.Point(3, 350);
            this.statusStrip_dishBottom.Name = "statusStrip_dishBottom";
            this.statusStrip_dishBottom.Size = new System.Drawing.Size(385, 22);
            this.statusStrip_dishBottom.TabIndex = 2;
            this.statusStrip_dishBottom.Text = "statusStrip1";
            // 
            // tSSLabel_dishCount
            // 
            this.tSSLabel_dishCount.Name = "tSSLabel_dishCount";
            this.tSSLabel_dishCount.Size = new System.Drawing.Size(92, 17);
            this.tSSLabel_dishCount.Text = "Количество: {0}";
            // 
            // toolStrip_dishTop
            // 
            this.toolStrip_dishTop.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip_dishTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSButton_dishAdd,
            this.tSButton_dishDel});
            this.toolStrip_dishTop.Location = new System.Drawing.Point(3, 16);
            this.toolStrip_dishTop.Name = "toolStrip_dishTop";
            this.toolStrip_dishTop.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip_dishTop.Size = new System.Drawing.Size(385, 25);
            this.toolStrip_dishTop.TabIndex = 0;
            this.toolStrip_dishTop.Text = "toolStrip1";
            // 
            // tSButton_dishAdd
            // 
            this.tSButton_dishAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSButton_dishAdd.Image = ((System.Drawing.Image)(resources.GetObject("tSButton_dishAdd.Image")));
            this.tSButton_dishAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tSButton_dishAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSButton_dishAdd.Name = "tSButton_dishAdd";
            this.tSButton_dishAdd.Size = new System.Drawing.Size(23, 22);
            this.tSButton_dishAdd.Text = "Добавить";
            this.tSButton_dishAdd.Click += new System.EventHandler(this.tSButton_dishAdd_Click);
            // 
            // tSButton_dishDel
            // 
            this.tSButton_dishDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSButton_dishDel.Image = ((System.Drawing.Image)(resources.GetObject("tSButton_dishDel.Image")));
            this.tSButton_dishDel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tSButton_dishDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSButton_dishDel.Name = "tSButton_dishDel";
            this.tSButton_dishDel.Size = new System.Drawing.Size(23, 22);
            this.tSButton_dishDel.Text = "Удалить";
            this.tSButton_dishDel.Click += new System.EventHandler(this.tSButton_dishDel_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tableLayoutPanel1);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(2, 2);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(391, 112);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Информация";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_dealsId, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_dealsName, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.comboBox_dealsStatus, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(385, 93);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "id";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "Наименование";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_dealsId
            // 
            this.textBox_dealsId.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_dealsId.Location = new System.Drawing.Point(93, 3);
            this.textBox_dealsId.Name = "textBox_dealsId";
            this.textBox_dealsId.ReadOnly = true;
            this.textBox_dealsId.Size = new System.Drawing.Size(289, 20);
            this.textBox_dealsId.TabIndex = 0;
            // 
            // textBox_dealsName
            // 
            this.textBox_dealsName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_dealsName.Location = new System.Drawing.Point(93, 29);
            this.textBox_dealsName.Name = "textBox_dealsName";
            this.textBox_dealsName.Size = new System.Drawing.Size(289, 20);
            this.textBox_dealsName.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(3, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 26);
            this.label5.TabIndex = 4;
            this.label5.Text = "Статус";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox_dealsStatus
            // 
            this.comboBox_dealsStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_dealsStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_dealsStatus.FormattingEnabled = true;
            this.comboBox_dealsStatus.Location = new System.Drawing.Point(93, 55);
            this.comboBox_dealsStatus.Name = "comboBox_dealsStatus";
            this.comboBox_dealsStatus.Size = new System.Drawing.Size(289, 21);
            this.comboBox_dealsStatus.TabIndex = 2;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView_bonus);
            this.groupBox3.Controls.Add(this.statusStrip_bonusBottom);
            this.groupBox3.Controls.Add(this.toolStrip_bonusTop);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(2, 114);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(430, 375);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Бонус";
            // 
            // dataGridView_bonus
            // 
            this.dataGridView_bonus.AllowUserToAddRows = false;
            this.dataGridView_bonus.AllowUserToDeleteRows = false;
            this.dataGridView_bonus.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView_bonus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_bonus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_bonus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bonus_refDishes,
            this.bonus_name,
            this.bonus_price});
            this.dataGridView_bonus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_bonus.Location = new System.Drawing.Point(3, 41);
            this.dataGridView_bonus.Name = "dataGridView_bonus";
            this.dataGridView_bonus.ReadOnly = true;
            this.dataGridView_bonus.RowHeadersVisible = false;
            this.dataGridView_bonus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_bonus.Size = new System.Drawing.Size(424, 309);
            this.dataGridView_bonus.TabIndex = 1;
            // 
            // bonus_refDishes
            // 
            this.bonus_refDishes.HeaderText = "id";
            this.bonus_refDishes.Name = "bonus_refDishes";
            this.bonus_refDishes.ReadOnly = true;
            this.bonus_refDishes.Visible = false;
            // 
            // bonus_name
            // 
            this.bonus_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.bonus_name.HeaderText = "Наименование";
            this.bonus_name.Name = "bonus_name";
            this.bonus_name.ReadOnly = true;
            // 
            // bonus_price
            // 
            this.bonus_price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.bonus_price.HeaderText = "Цена";
            this.bonus_price.Name = "bonus_price";
            this.bonus_price.ReadOnly = true;
            this.bonus_price.Width = 58;
            // 
            // statusStrip_bonusBottom
            // 
            this.statusStrip_bonusBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSSLabel_bonusCount});
            this.statusStrip_bonusBottom.Location = new System.Drawing.Point(3, 350);
            this.statusStrip_bonusBottom.Name = "statusStrip_bonusBottom";
            this.statusStrip_bonusBottom.Size = new System.Drawing.Size(424, 22);
            this.statusStrip_bonusBottom.TabIndex = 3;
            this.statusStrip_bonusBottom.Text = "statusStrip2";
            // 
            // tSSLabel_bonusCount
            // 
            this.tSSLabel_bonusCount.Name = "tSSLabel_bonusCount";
            this.tSSLabel_bonusCount.Size = new System.Drawing.Size(92, 17);
            this.tSSLabel_bonusCount.Text = "Количество: {0}";
            // 
            // toolStrip_bonusTop
            // 
            this.toolStrip_bonusTop.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip_bonusTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSButton_bonusAdd,
            this.tSButton_bonusDel});
            this.toolStrip_bonusTop.Location = new System.Drawing.Point(3, 16);
            this.toolStrip_bonusTop.Name = "toolStrip_bonusTop";
            this.toolStrip_bonusTop.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip_bonusTop.Size = new System.Drawing.Size(424, 25);
            this.toolStrip_bonusTop.TabIndex = 0;
            this.toolStrip_bonusTop.Text = "toolStrip2";
            // 
            // tSButton_bonusAdd
            // 
            this.tSButton_bonusAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSButton_bonusAdd.Image = ((System.Drawing.Image)(resources.GetObject("tSButton_bonusAdd.Image")));
            this.tSButton_bonusAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tSButton_bonusAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSButton_bonusAdd.Name = "tSButton_bonusAdd";
            this.tSButton_bonusAdd.Size = new System.Drawing.Size(23, 22);
            this.tSButton_bonusAdd.Text = "Добавить";
            this.tSButton_bonusAdd.Click += new System.EventHandler(this.tSButton_bonusAdd_Click);
            // 
            // tSButton_bonusDel
            // 
            this.tSButton_bonusDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSButton_bonusDel.Image = ((System.Drawing.Image)(resources.GetObject("tSButton_bonusDel.Image")));
            this.tSButton_bonusDel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tSButton_bonusDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSButton_bonusDel.Name = "tSButton_bonusDel";
            this.tSButton_bonusDel.Size = new System.Drawing.Size(23, 22);
            this.tSButton_bonusDel.Text = "Удалить";
            this.tSButton_bonusDel.Click += new System.EventHandler(this.tSButton_bonusDel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(430, 112);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Условие";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 136F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.checkBox_sumCount, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.numericUpDown_sumCount, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.dateTimePicker_start, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.dateTimePicker_end, 1, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.Padding = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(424, 93);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // checkBox_sumCount
            // 
            this.checkBox_sumCount.AutoSize = true;
            this.checkBox_sumCount.Checked = true;
            this.checkBox_sumCount.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_sumCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox_sumCount.Location = new System.Drawing.Point(5, 5);
            this.checkBox_sumCount.Name = "checkBox_sumCount";
            this.checkBox_sumCount.Size = new System.Drawing.Size(130, 23);
            this.checkBox_sumCount.TabIndex = 0;
            this.checkBox_sumCount.Text = "Суммарное кол-во =";
            this.checkBox_sumCount.UseVisualStyleBackColor = true;
            // 
            // numericUpDown_sumCount
            // 
            this.numericUpDown_sumCount.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDown_sumCount.Location = new System.Drawing.Point(141, 5);
            this.numericUpDown_sumCount.Name = "numericUpDown_sumCount";
            this.numericUpDown_sumCount.Size = new System.Drawing.Size(278, 20);
            this.numericUpDown_sumCount.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(5, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 23);
            this.label3.TabIndex = 2;
            this.label3.Text = "Дата начала";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(5, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(130, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "Дата окончания";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dateTimePicker_start
            // 
            this.dateTimePicker_start.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimePicker_start.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_start.Location = new System.Drawing.Point(141, 34);
            this.dateTimePicker_start.Name = "dateTimePicker_start";
            this.dateTimePicker_start.Size = new System.Drawing.Size(278, 20);
            this.dateTimePicker_start.TabIndex = 1;
            // 
            // dateTimePicker_end
            // 
            this.dateTimePicker_end.Checked = false;
            this.dateTimePicker_end.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimePicker_end.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_end.Location = new System.Drawing.Point(141, 57);
            this.dateTimePicker_end.Name = "dateTimePicker_end";
            this.dateTimePicker_end.ShowCheckBox = true;
            this.dateTimePicker_end.Size = new System.Drawing.Size(278, 20);
            this.dateTimePicker_end.TabIndex = 2;
            // 
            // button_save
            // 
            this.button_save.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_save.Location = new System.Drawing.Point(0, 491);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(833, 34);
            this.button_save.TabIndex = 3;
            this.button_save.Text = "Сохранить";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // fDealsAddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(833, 525);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.button_save);
            this.MinimizeBox = false;
            this.Name = "fDealsAddEdit";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "fDealsAddEdit";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_dish)).EndInit();
            this.statusStrip_dishBottom.ResumeLayout(false);
            this.statusStrip_dishBottom.PerformLayout();
            this.toolStrip_dishTop.ResumeLayout(false);
            this.toolStrip_dishTop.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_bonus)).EndInit();
            this.statusStrip_bonusBottom.ResumeLayout(false);
            this.statusStrip_bonusBottom.PerformLayout();
            this.toolStrip_bonusTop.ResumeLayout(false);
            this.toolStrip_bonusTop.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_sumCount)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView_dish;
        private System.Windows.Forms.StatusStrip statusStrip_dishBottom;
        private System.Windows.Forms.ToolStripStatusLabel tSSLabel_dishCount;
        private System.Windows.Forms.ToolStrip toolStrip_dishTop;
        private System.Windows.Forms.ToolStripButton tSButton_dishAdd;
        private System.Windows.Forms.ToolStripButton tSButton_dishDel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_dealsId;
        private System.Windows.Forms.TextBox textBox_dealsName;
        private System.Windows.Forms.DataGridView dataGridView_bonus;
        private System.Windows.Forms.StatusStrip statusStrip_bonusBottom;
        private System.Windows.Forms.ToolStripStatusLabel tSSLabel_bonusCount;
        private System.Windows.Forms.ToolStrip toolStrip_bonusTop;
        private System.Windows.Forms.ToolStripButton tSButton_bonusAdd;
        private System.Windows.Forms.ToolStripButton tSButton_bonusDel;
        private System.Windows.Forms.NumericUpDown numericUpDown_sumCount;
        private System.Windows.Forms.CheckBox checkBox_sumCount;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimePicker_start;
        private System.Windows.Forms.DateTimePicker dateTimePicker_end;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_dealsStatus;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.DataGridViewTextBoxColumn dish_refDishes;
        private System.Windows.Forms.DataGridViewTextBoxColumn dish_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn dish_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn bonus_refDishes;
        private System.Windows.Forms.DataGridViewTextBoxColumn bonus_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn bonus_price;
    }
}