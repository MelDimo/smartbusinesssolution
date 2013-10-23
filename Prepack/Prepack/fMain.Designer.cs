namespace com.sbs.gui.prepack
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMain));
            this.statusStrip_bottom = new System.Windows.Forms.StatusStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView_prepackMain = new System.Windows.Forms.DataGridView();
            this.prepackmain_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prepackmain_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prepackmain_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prepackmain_ref_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prepackmain_ref_status_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip_prepackMain = new System.Windows.Forms.ToolStrip();
            this.tSButton_addPrepackMain = new System.Windows.Forms.ToolStripButton();
            this.tSButton_editPrepackMain = new System.Windows.Forms.ToolStripButton();
            this.tSButton_delPrepackMain = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tSButton_dublicate = new System.Windows.Forms.ToolStripButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tabControl_main = new System.Windows.Forms.TabControl();
            this.tabPage_goods = new System.Windows.Forms.TabPage();
            this.dataGridView_goods = new System.Windows.Forms.DataGridView();
            this.goods_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goods_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goods_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goods_manufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goods_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goods_status_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip_goods = new System.Windows.Forms.ToolStrip();
            this.tSButton_addGoods = new System.Windows.Forms.ToolStripButton();
            this.tSButton_delGoods = new System.Windows.Forms.ToolStripButton();
            this.tabPage_prepack = new System.Windows.Forms.TabPage();
            this.dataGridView_prepack = new System.Windows.Forms.DataGridView();
            this.prepack_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prepack_code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prepack_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prepack_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prepack_status_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip_prepack = new System.Windows.Forms.ToolStrip();
            this.tSButton_addPrepack = new System.Windows.Forms.ToolStripButton();
            this.tSButton_delPrepack = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button_filter = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_org = new System.Windows.Forms.ComboBox();
            this.comboBox_branch = new System.Windows.Forms.ComboBox();
            this.comboBox_unit = new System.Windows.Forms.ComboBox();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_prepackMain)).BeginInit();
            this.toolStrip_prepackMain.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl_main.SuspendLayout();
            this.tabPage_goods.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_goods)).BeginInit();
            this.toolStrip_goods.SuspendLayout();
            this.tabPage_prepack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_prepack)).BeginInit();
            this.toolStrip_prepack.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip_bottom
            // 
            this.statusStrip_bottom.Location = new System.Drawing.Point(2, 324);
            this.statusStrip_bottom.Name = "statusStrip_bottom";
            this.statusStrip_bottom.Size = new System.Drawing.Size(606, 22);
            this.statusStrip_bottom.TabIndex = 0;
            this.statusStrip_bottom.Text = "statusStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(2, 72);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer1.Size = new System.Drawing.Size(606, 252);
            this.splitContainer1.SplitterDistance = 201;
            this.splitContainer1.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView_prepackMain);
            this.groupBox2.Controls.Add(this.toolStrip_prepackMain);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(201, 252);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Полуфабрикат";
            // 
            // dataGridView_prepackMain
            // 
            this.dataGridView_prepackMain.AllowUserToAddRows = false;
            this.dataGridView_prepackMain.AllowUserToDeleteRows = false;
            this.dataGridView_prepackMain.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_prepackMain.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.prepackmain_id,
            this.prepackmain_code,
            this.prepackmain_name,
            this.prepackmain_ref_status,
            this.prepackmain_ref_status_name});
            this.dataGridView_prepackMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_prepackMain.Location = new System.Drawing.Point(3, 41);
            this.dataGridView_prepackMain.MultiSelect = false;
            this.dataGridView_prepackMain.Name = "dataGridView_prepackMain";
            this.dataGridView_prepackMain.ReadOnly = true;
            this.dataGridView_prepackMain.RowHeadersVisible = false;
            this.dataGridView_prepackMain.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_prepackMain.Size = new System.Drawing.Size(195, 208);
            this.dataGridView_prepackMain.TabIndex = 1;
            this.dataGridView_prepackMain.RowStateChanged += new System.Windows.Forms.DataGridViewRowStateChangedEventHandler(this.dataGridView_prepackMain_RowStateChanged);
            // 
            // prepackmain_id
            // 
            this.prepackmain_id.HeaderText = "prepackmain_id";
            this.prepackmain_id.Name = "prepackmain_id";
            this.prepackmain_id.ReadOnly = true;
            this.prepackmain_id.Visible = false;
            // 
            // prepackmain_code
            // 
            this.prepackmain_code.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.prepackmain_code.HeaderText = "Ключ";
            this.prepackmain_code.Name = "prepackmain_code";
            this.prepackmain_code.ReadOnly = true;
            this.prepackmain_code.Width = 58;
            // 
            // prepackmain_name
            // 
            this.prepackmain_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.prepackmain_name.HeaderText = "Наименование";
            this.prepackmain_name.Name = "prepackmain_name";
            this.prepackmain_name.ReadOnly = true;
            // 
            // prepackmain_ref_status
            // 
            this.prepackmain_ref_status.HeaderText = "ref_status";
            this.prepackmain_ref_status.Name = "prepackmain_ref_status";
            this.prepackmain_ref_status.ReadOnly = true;
            this.prepackmain_ref_status.Visible = false;
            // 
            // prepackmain_ref_status_name
            // 
            this.prepackmain_ref_status_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.prepackmain_ref_status_name.HeaderText = "Статус";
            this.prepackmain_ref_status_name.Name = "prepackmain_ref_status_name";
            this.prepackmain_ref_status_name.ReadOnly = true;
            this.prepackmain_ref_status_name.Width = 66;
            // 
            // toolStrip_prepackMain
            // 
            this.toolStrip_prepackMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip_prepackMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSButton_addPrepackMain,
            this.tSButton_editPrepackMain,
            this.tSButton_delPrepackMain,
            this.toolStripSeparator1,
            this.tSButton_dublicate});
            this.toolStrip_prepackMain.Location = new System.Drawing.Point(3, 16);
            this.toolStrip_prepackMain.Name = "toolStrip_prepackMain";
            this.toolStrip_prepackMain.Size = new System.Drawing.Size(195, 25);
            this.toolStrip_prepackMain.TabIndex = 0;
            this.toolStrip_prepackMain.Text = "toolStrip1";
            // 
            // tSButton_addPrepackMain
            // 
            this.tSButton_addPrepackMain.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSButton_addPrepackMain.Image = ((System.Drawing.Image)(resources.GetObject("tSButton_addPrepackMain.Image")));
            this.tSButton_addPrepackMain.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tSButton_addPrepackMain.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSButton_addPrepackMain.Name = "tSButton_addPrepackMain";
            this.tSButton_addPrepackMain.Size = new System.Drawing.Size(23, 22);
            this.tSButton_addPrepackMain.Text = "toolStripButton1";
            this.tSButton_addPrepackMain.ToolTipText = "Создать";
            this.tSButton_addPrepackMain.Click += new System.EventHandler(this.tSButton_addPrepackMain_Click);
            // 
            // tSButton_editPrepackMain
            // 
            this.tSButton_editPrepackMain.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSButton_editPrepackMain.Image = ((System.Drawing.Image)(resources.GetObject("tSButton_editPrepackMain.Image")));
            this.tSButton_editPrepackMain.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tSButton_editPrepackMain.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSButton_editPrepackMain.Name = "tSButton_editPrepackMain";
            this.tSButton_editPrepackMain.Size = new System.Drawing.Size(23, 22);
            this.tSButton_editPrepackMain.Text = "toolStripButton1";
            this.tSButton_editPrepackMain.ToolTipText = "Редактировать";
            this.tSButton_editPrepackMain.Click += new System.EventHandler(this.tSButton_editPrepackMain_Click);
            // 
            // tSButton_delPrepackMain
            // 
            this.tSButton_delPrepackMain.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSButton_delPrepackMain.Image = ((System.Drawing.Image)(resources.GetObject("tSButton_delPrepackMain.Image")));
            this.tSButton_delPrepackMain.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tSButton_delPrepackMain.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSButton_delPrepackMain.Name = "tSButton_delPrepackMain";
            this.tSButton_delPrepackMain.Size = new System.Drawing.Size(23, 22);
            this.tSButton_delPrepackMain.Text = "toolStripButton3";
            this.tSButton_delPrepackMain.ToolTipText = "Удалить";
            this.tSButton_delPrepackMain.Click += new System.EventHandler(this.tSButton_delPrepackMain_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tSButton_dublicate
            // 
            this.tSButton_dublicate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSButton_dublicate.Image = ((System.Drawing.Image)(resources.GetObject("tSButton_dublicate.Image")));
            this.tSButton_dublicate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tSButton_dublicate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSButton_dublicate.Name = "tSButton_dublicate";
            this.tSButton_dublicate.Size = new System.Drawing.Size(23, 22);
            this.tSButton_dublicate.Text = "toolStripButton1";
            this.tSButton_dublicate.ToolTipText = "Дублировать...";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tabControl_main);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(401, 252);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ингридиенты";
            // 
            // tabControl_main
            // 
            this.tabControl_main.Controls.Add(this.tabPage_goods);
            this.tabControl_main.Controls.Add(this.tabPage_prepack);
            this.tabControl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_main.Location = new System.Drawing.Point(3, 16);
            this.tabControl_main.Name = "tabControl_main";
            this.tabControl_main.SelectedIndex = 0;
            this.tabControl_main.Size = new System.Drawing.Size(395, 233);
            this.tabControl_main.TabIndex = 0;
            // 
            // tabPage_goods
            // 
            this.tabPage_goods.Controls.Add(this.dataGridView_goods);
            this.tabPage_goods.Controls.Add(this.toolStrip_goods);
            this.tabPage_goods.Location = new System.Drawing.Point(4, 22);
            this.tabPage_goods.Name = "tabPage_goods";
            this.tabPage_goods.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_goods.Size = new System.Drawing.Size(387, 207);
            this.tabPage_goods.TabIndex = 0;
            this.tabPage_goods.Text = "Продукты";
            // 
            // dataGridView_goods
            // 
            this.dataGridView_goods.AllowUserToAddRows = false;
            this.dataGridView_goods.AllowUserToDeleteRows = false;
            this.dataGridView_goods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_goods.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.goods_id,
            this.goods_code,
            this.goods_name,
            this.goods_manufacturer,
            this.goods_status,
            this.goods_status_name});
            this.dataGridView_goods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_goods.Location = new System.Drawing.Point(3, 28);
            this.dataGridView_goods.MultiSelect = false;
            this.dataGridView_goods.Name = "dataGridView_goods";
            this.dataGridView_goods.ReadOnly = true;
            this.dataGridView_goods.RowHeadersVisible = false;
            this.dataGridView_goods.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_goods.Size = new System.Drawing.Size(381, 176);
            this.dataGridView_goods.TabIndex = 0;
            // 
            // goods_id
            // 
            this.goods_id.HeaderText = "id";
            this.goods_id.Name = "goods_id";
            this.goods_id.ReadOnly = true;
            this.goods_id.Visible = false;
            // 
            // goods_code
            // 
            this.goods_code.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.goods_code.HeaderText = "Ключ";
            this.goods_code.Name = "goods_code";
            this.goods_code.ReadOnly = true;
            this.goods_code.Width = 58;
            // 
            // goods_name
            // 
            this.goods_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.goods_name.HeaderText = "Наименование";
            this.goods_name.Name = "goods_name";
            this.goods_name.ReadOnly = true;
            // 
            // goods_manufacturer
            // 
            this.goods_manufacturer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.goods_manufacturer.HeaderText = "Производитель";
            this.goods_manufacturer.Name = "goods_manufacturer";
            this.goods_manufacturer.ReadOnly = true;
            // 
            // goods_status
            // 
            this.goods_status.HeaderText = "status";
            this.goods_status.Name = "goods_status";
            this.goods_status.ReadOnly = true;
            this.goods_status.Visible = false;
            // 
            // goods_status_name
            // 
            this.goods_status_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.goods_status_name.HeaderText = "Статус";
            this.goods_status_name.Name = "goods_status_name";
            this.goods_status_name.ReadOnly = true;
            this.goods_status_name.Width = 66;
            // 
            // toolStrip_goods
            // 
            this.toolStrip_goods.Enabled = false;
            this.toolStrip_goods.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip_goods.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSButton_addGoods,
            this.tSButton_delGoods});
            this.toolStrip_goods.Location = new System.Drawing.Point(3, 3);
            this.toolStrip_goods.Name = "toolStrip_goods";
            this.toolStrip_goods.Size = new System.Drawing.Size(381, 25);
            this.toolStrip_goods.TabIndex = 1;
            this.toolStrip_goods.Text = "toolStrip1";
            // 
            // tSButton_addGoods
            // 
            this.tSButton_addGoods.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSButton_addGoods.Image = ((System.Drawing.Image)(resources.GetObject("tSButton_addGoods.Image")));
            this.tSButton_addGoods.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tSButton_addGoods.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSButton_addGoods.Name = "tSButton_addGoods";
            this.tSButton_addGoods.Size = new System.Drawing.Size(23, 22);
            this.tSButton_addGoods.Text = "toolStripButton4";
            this.tSButton_addGoods.ToolTipText = "Добавить";
            this.tSButton_addGoods.Click += new System.EventHandler(this.tSButton_addGoods_Click);
            // 
            // tSButton_delGoods
            // 
            this.tSButton_delGoods.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSButton_delGoods.Image = ((System.Drawing.Image)(resources.GetObject("tSButton_delGoods.Image")));
            this.tSButton_delGoods.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tSButton_delGoods.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSButton_delGoods.Name = "tSButton_delGoods";
            this.tSButton_delGoods.Size = new System.Drawing.Size(23, 22);
            this.tSButton_delGoods.Text = "toolStripButton5";
            this.tSButton_delGoods.ToolTipText = "Удалить";
            this.tSButton_delGoods.Click += new System.EventHandler(this.tSButton_delGoods_Click);
            // 
            // tabPage_prepack
            // 
            this.tabPage_prepack.Controls.Add(this.dataGridView_prepack);
            this.tabPage_prepack.Controls.Add(this.toolStrip_prepack);
            this.tabPage_prepack.Location = new System.Drawing.Point(4, 22);
            this.tabPage_prepack.Name = "tabPage_prepack";
            this.tabPage_prepack.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_prepack.Size = new System.Drawing.Size(387, 207);
            this.tabPage_prepack.TabIndex = 1;
            this.tabPage_prepack.Text = "Полуфабрикаты";
            // 
            // dataGridView_prepack
            // 
            this.dataGridView_prepack.AllowUserToAddRows = false;
            this.dataGridView_prepack.AllowUserToDeleteRows = false;
            this.dataGridView_prepack.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_prepack.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.prepack_id,
            this.prepack_code,
            this.prepack_name,
            this.prepack_status,
            this.prepack_status_name});
            this.dataGridView_prepack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_prepack.Location = new System.Drawing.Point(3, 28);
            this.dataGridView_prepack.Name = "dataGridView_prepack";
            this.dataGridView_prepack.ReadOnly = true;
            this.dataGridView_prepack.RowHeadersVisible = false;
            this.dataGridView_prepack.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_prepack.Size = new System.Drawing.Size(381, 176);
            this.dataGridView_prepack.TabIndex = 0;
            // 
            // prepack_id
            // 
            this.prepack_id.HeaderText = "id";
            this.prepack_id.Name = "prepack_id";
            this.prepack_id.ReadOnly = true;
            this.prepack_id.Visible = false;
            // 
            // prepack_code
            // 
            this.prepack_code.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.prepack_code.HeaderText = "Ключ";
            this.prepack_code.Name = "prepack_code";
            this.prepack_code.ReadOnly = true;
            this.prepack_code.Width = 58;
            // 
            // prepack_name
            // 
            this.prepack_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.prepack_name.HeaderText = "Наименование";
            this.prepack_name.Name = "prepack_name";
            this.prepack_name.ReadOnly = true;
            // 
            // prepack_status
            // 
            this.prepack_status.HeaderText = "status";
            this.prepack_status.Name = "prepack_status";
            this.prepack_status.ReadOnly = true;
            this.prepack_status.Visible = false;
            // 
            // prepack_status_name
            // 
            this.prepack_status_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.prepack_status_name.HeaderText = "Статус";
            this.prepack_status_name.Name = "prepack_status_name";
            this.prepack_status_name.ReadOnly = true;
            this.prepack_status_name.Width = 66;
            // 
            // toolStrip_prepack
            // 
            this.toolStrip_prepack.Enabled = false;
            this.toolStrip_prepack.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip_prepack.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSButton_addPrepack,
            this.tSButton_delPrepack});
            this.toolStrip_prepack.Location = new System.Drawing.Point(3, 3);
            this.toolStrip_prepack.Name = "toolStrip_prepack";
            this.toolStrip_prepack.Size = new System.Drawing.Size(381, 25);
            this.toolStrip_prepack.TabIndex = 1;
            this.toolStrip_prepack.Text = "toolStrip1";
            // 
            // tSButton_addPrepack
            // 
            this.tSButton_addPrepack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSButton_addPrepack.Image = ((System.Drawing.Image)(resources.GetObject("tSButton_addPrepack.Image")));
            this.tSButton_addPrepack.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tSButton_addPrepack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSButton_addPrepack.Name = "tSButton_addPrepack";
            this.tSButton_addPrepack.Size = new System.Drawing.Size(23, 22);
            this.tSButton_addPrepack.Text = "toolStripButton2";
            this.tSButton_addPrepack.ToolTipText = "Добавить";
            this.tSButton_addPrepack.Click += new System.EventHandler(this.tSButton_addPrepack_Click);
            // 
            // tSButton_delPrepack
            // 
            this.tSButton_delPrepack.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSButton_delPrepack.Image = ((System.Drawing.Image)(resources.GetObject("tSButton_delPrepack.Image")));
            this.tSButton_delPrepack.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tSButton_delPrepack.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSButton_delPrepack.Name = "tSButton_delPrepack";
            this.tSButton_delPrepack.Size = new System.Drawing.Size(23, 22);
            this.tSButton_delPrepack.Text = "toolStripButton6";
            this.tSButton_delPrepack.ToolTipText = "Добавить";
            this.tSButton_delPrepack.Click += new System.EventHandler(this.tSButton_delPrepack_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(606, 70);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Фильтр";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.Controls.Add(this.button_filter, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBox_org, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBox_branch, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.comboBox_unit, 2, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(600, 51);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // button_filter
            // 
            this.button_filter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_filter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_filter.Location = new System.Drawing.Point(567, 23);
            this.button_filter.Name = "button_filter";
            this.button_filter.Size = new System.Drawing.Size(30, 25);
            this.button_filter.TabIndex = 0;
            this.button_filter.UseVisualStyleBackColor = true;
            this.button_filter.Click += new System.EventHandler(this.button_filter_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(182, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Организация";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(191, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(182, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Заведение";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(379, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Подразделение";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox_org
            // 
            this.comboBox_org.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_org.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_org.FormattingEnabled = true;
            this.comboBox_org.Location = new System.Drawing.Point(3, 23);
            this.comboBox_org.Name = "comboBox_org";
            this.comboBox_org.Size = new System.Drawing.Size(182, 21);
            this.comboBox_org.TabIndex = 4;
            // 
            // comboBox_branch
            // 
            this.comboBox_branch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_branch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_branch.FormattingEnabled = true;
            this.comboBox_branch.Location = new System.Drawing.Point(191, 23);
            this.comboBox_branch.Name = "comboBox_branch";
            this.comboBox_branch.Size = new System.Drawing.Size(182, 21);
            this.comboBox_branch.TabIndex = 5;
            // 
            // comboBox_unit
            // 
            this.comboBox_unit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_unit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_unit.FormattingEnabled = true;
            this.comboBox_unit.Location = new System.Drawing.Point(379, 23);
            this.comboBox_unit.Name = "comboBox_unit";
            this.comboBox_unit.Size = new System.Drawing.Size(182, 21);
            this.comboBox_unit.TabIndex = 6;
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 348);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip_bottom);
            this.MinimizeBox = false;
            this.Name = "fMain";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Полуфабрикаты";
            this.Shown += new System.EventHandler(this.fMain_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_prepackMain)).EndInit();
            this.toolStrip_prepackMain.ResumeLayout(false);
            this.toolStrip_prepackMain.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.tabControl_main.ResumeLayout(false);
            this.tabPage_goods.ResumeLayout(false);
            this.tabPage_goods.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_goods)).EndInit();
            this.toolStrip_goods.ResumeLayout(false);
            this.toolStrip_goods.PerformLayout();
            this.tabPage_prepack.ResumeLayout(false);
            this.tabPage_prepack.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_prepack)).EndInit();
            this.toolStrip_prepack.ResumeLayout(false);
            this.toolStrip_prepack.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip_bottom;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStrip_prepackMain;
        private System.Windows.Forms.ToolStripButton tSButton_addPrepackMain;
        private System.Windows.Forms.ToolStripButton tSButton_delPrepackMain;
        private System.Windows.Forms.TabControl tabControl_main;
        private System.Windows.Forms.TabPage tabPage_goods;
        private System.Windows.Forms.TabPage tabPage_prepack;
        private System.Windows.Forms.DataGridView dataGridView_prepackMain;
        private System.Windows.Forms.DataGridView dataGridView_goods;
        private System.Windows.Forms.DataGridView dataGridView_prepack;
        private System.Windows.Forms.ToolStrip toolStrip_goods;
        private System.Windows.Forms.ToolStripButton tSButton_addGoods;
        private System.Windows.Forms.ToolStripButton tSButton_delGoods;
        private System.Windows.Forms.ToolStrip toolStrip_prepack;
        private System.Windows.Forms.ToolStripButton tSButton_addPrepack;
        private System.Windows.Forms.ToolStripButton tSButton_delPrepack;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button_filter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_org;
        private System.Windows.Forms.ComboBox comboBox_branch;
        private System.Windows.Forms.ComboBox comboBox_unit;
        private System.Windows.Forms.ToolStripButton tSButton_editPrepackMain;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tSButton_dublicate;
        private System.Windows.Forms.DataGridViewTextBoxColumn prepackmain_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn prepackmain_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn prepackmain_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn prepackmain_ref_status;
        private System.Windows.Forms.DataGridViewTextBoxColumn prepackmain_ref_status_name;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridViewTextBoxColumn prepack_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn prepack_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn prepack_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn prepack_status;
        private System.Windows.Forms.DataGridViewTextBoxColumn prepack_status_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn goods_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn goods_code;
        private System.Windows.Forms.DataGridViewTextBoxColumn goods_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn goods_manufacturer;
        private System.Windows.Forms.DataGridViewTextBoxColumn goods_status;
        private System.Windows.Forms.DataGridViewTextBoxColumn goods_status_name;
    }
}

