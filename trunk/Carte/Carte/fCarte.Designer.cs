namespace com.sbs.gui.carte
{
    partial class fCarte
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fCarte));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridView_carte = new System.Windows.Forms.DataGridView();
            this.carte_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.carte_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.carte_ref_status_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_carteAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_carteEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_carteDel = new System.Windows.Forms.ToolStripButton();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.treeView_group = new System.Windows.Forms.TreeView();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_groupAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_groupEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_groupDel = new System.Windows.Forms.ToolStripButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.dataGridView_dishes = new System.Windows.Forms.DataGridView();
            this.dishes_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dishes_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dishes_price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dishes_ref_printers_type_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dishes_ref_status_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip3 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_dishAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_dishEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_dishDel = new System.Windows.Forms.ToolStripButton();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox_branchName = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton_branch = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_carte)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip2.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_dishes)).BeginInit();
            this.statusStrip3.SuspendLayout();
            this.toolStrip3.SuspendLayout();
            this.toolStrip4.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 29);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Size = new System.Drawing.Size(939, 484);
            this.splitContainer1.SplitterDistance = 348;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.statusStrip1);
            this.groupBox1.Controls.Add(this.dataGridView_carte);
            this.groupBox1.Controls.Add(this.toolStrip1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(344, 480);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Меню";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(3, 455);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(338, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(103, 17);
            this.toolStripStatusLabel1.Text = "tSSLabel_carteInfo";
            // 
            // dataGridView_carte
            // 
            this.dataGridView_carte.AllowUserToAddRows = false;
            this.dataGridView_carte.AllowUserToDeleteRows = false;
            this.dataGridView_carte.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView_carte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_carte.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.carte_id,
            this.carte_name,
            this.carte_ref_status_name});
            this.dataGridView_carte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_carte.Location = new System.Drawing.Point(3, 41);
            this.dataGridView_carte.MultiSelect = false;
            this.dataGridView_carte.Name = "dataGridView_carte";
            this.dataGridView_carte.ReadOnly = true;
            this.dataGridView_carte.RowHeadersVisible = false;
            this.dataGridView_carte.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_carte.Size = new System.Drawing.Size(338, 436);
            this.dataGridView_carte.TabIndex = 1;
            this.dataGridView_carte.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView_carte_KeyDown);
            // 
            // carte_id
            // 
            this.carte_id.HeaderText = "carte_id";
            this.carte_id.Name = "carte_id";
            this.carte_id.ReadOnly = true;
            this.carte_id.Visible = false;
            // 
            // carte_name
            // 
            this.carte_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.carte_name.HeaderText = "Наименование";
            this.carte_name.Name = "carte_name";
            this.carte_name.ReadOnly = true;
            // 
            // carte_ref_status_name
            // 
            this.carte_ref_status_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.carte_ref_status_name.HeaderText = "Статус";
            this.carte_ref_status_name.Name = "carte_ref_status_name";
            this.carte_ref_status_name.ReadOnly = true;
            this.carte_ref_status_name.Width = 66;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_carteAdd,
            this.toolStripButton_carteEdit,
            this.toolStripButton_carteDel});
            this.toolStrip1.Location = new System.Drawing.Point(3, 16);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(338, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton_carteAdd
            // 
            this.toolStripButton_carteAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_carteAdd.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_carteAdd.Image")));
            this.toolStripButton_carteAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_carteAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_carteAdd.Name = "toolStripButton_carteAdd";
            this.toolStripButton_carteAdd.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_carteAdd.Text = "Добавить";
            this.toolStripButton_carteAdd.Click += new System.EventHandler(this.toolStripButton_carteAdd_Click);
            // 
            // toolStripButton_carteEdit
            // 
            this.toolStripButton_carteEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_carteEdit.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_carteEdit.Image")));
            this.toolStripButton_carteEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_carteEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_carteEdit.Name = "toolStripButton_carteEdit";
            this.toolStripButton_carteEdit.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_carteEdit.Text = "Редактировать";
            this.toolStripButton_carteEdit.Click += new System.EventHandler(this.toolStripButton_carteEdit_Click);
            // 
            // toolStripButton_carteDel
            // 
            this.toolStripButton_carteDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_carteDel.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_carteDel.Image")));
            this.toolStripButton_carteDel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_carteDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_carteDel.Name = "toolStripButton_carteDel";
            this.toolStripButton_carteDel.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_carteDel.Text = "Удалить";
            this.toolStripButton_carteDel.Click += new System.EventHandler(this.toolStripButton_carteDel_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(2, 2);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox2);
            this.splitContainer2.Panel1.Padding = new System.Windows.Forms.Padding(2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox3);
            this.splitContainer2.Panel2.Padding = new System.Windows.Forms.Padding(2);
            this.splitContainer2.Size = new System.Drawing.Size(583, 480);
            this.splitContainer2.SplitterDistance = 250;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.treeView_group);
            this.groupBox2.Controls.Add(this.statusStrip2);
            this.groupBox2.Controls.Add(this.toolStrip2);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(246, 476);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Структура меню";
            // 
            // treeView_group
            // 
            this.treeView_group.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_group.FullRowSelect = true;
            this.treeView_group.HideSelection = false;
            this.treeView_group.Location = new System.Drawing.Point(3, 41);
            this.treeView_group.Name = "treeView_group";
            this.treeView_group.Size = new System.Drawing.Size(240, 410);
            this.treeView_group.TabIndex = 2;
            this.treeView_group.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_group_AfterSelect);
            // 
            // statusStrip2
            // 
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel2});
            this.statusStrip2.Location = new System.Drawing.Point(3, 451);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(240, 22);
            this.statusStrip2.SizingGrip = false;
            this.statusStrip2.TabIndex = 1;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(109, 17);
            this.toolStripStatusLabel2.Text = "tSSLabel_groupInfo";
            // 
            // toolStrip2
            // 
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_groupAdd,
            this.toolStripButton_groupEdit,
            this.toolStripButton_groupDel});
            this.toolStrip2.Location = new System.Drawing.Point(3, 16);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(240, 25);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripButton_groupAdd
            // 
            this.toolStripButton_groupAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_groupAdd.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_groupAdd.Image")));
            this.toolStripButton_groupAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_groupAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_groupAdd.Name = "toolStripButton_groupAdd";
            this.toolStripButton_groupAdd.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_groupAdd.Text = "Добавить";
            this.toolStripButton_groupAdd.Click += new System.EventHandler(this.toolStripButton_groupAdd_Click);
            // 
            // toolStripButton_groupEdit
            // 
            this.toolStripButton_groupEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_groupEdit.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_groupEdit.Image")));
            this.toolStripButton_groupEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_groupEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_groupEdit.Name = "toolStripButton_groupEdit";
            this.toolStripButton_groupEdit.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_groupEdit.Text = "Редактировать";
            this.toolStripButton_groupEdit.Click += new System.EventHandler(this.toolStripButton_groupEdit_Click);
            // 
            // toolStripButton_groupDel
            // 
            this.toolStripButton_groupDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_groupDel.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_groupDel.Image")));
            this.toolStripButton_groupDel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_groupDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_groupDel.Name = "toolStripButton_groupDel";
            this.toolStripButton_groupDel.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_groupDel.Text = "Удалить";
            this.toolStripButton_groupDel.Click += new System.EventHandler(this.toolStripButton_groupDel_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dataGridView_dishes);
            this.groupBox3.Controls.Add(this.statusStrip3);
            this.groupBox3.Controls.Add(this.toolStrip3);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(2, 2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(325, 476);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ассортимент";
            // 
            // dataGridView_dishes
            // 
            this.dataGridView_dishes.AllowUserToAddRows = false;
            this.dataGridView_dishes.AllowUserToDeleteRows = false;
            this.dataGridView_dishes.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView_dishes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_dishes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dishes_id,
            this.dishes_name,
            this.dishes_price,
            this.dishes_ref_printers_type_name,
            this.dishes_ref_status_name});
            this.dataGridView_dishes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_dishes.Location = new System.Drawing.Point(3, 41);
            this.dataGridView_dishes.MultiSelect = false;
            this.dataGridView_dishes.Name = "dataGridView_dishes";
            this.dataGridView_dishes.ReadOnly = true;
            this.dataGridView_dishes.RowHeadersVisible = false;
            this.dataGridView_dishes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_dishes.Size = new System.Drawing.Size(319, 410);
            this.dataGridView_dishes.TabIndex = 2;
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
            this.dishes_price.HeaderText = "Цена";
            this.dishes_price.Name = "dishes_price";
            this.dishes_price.ReadOnly = true;
            this.dishes_price.Width = 58;
            // 
            // dishes_ref_printers_type_name
            // 
            this.dishes_ref_printers_type_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dishes_ref_printers_type_name.HeaderText = "Тип принтера";
            this.dishes_ref_printers_type_name.Name = "dishes_ref_printers_type_name";
            this.dishes_ref_printers_type_name.ReadOnly = true;
            this.dishes_ref_printers_type_name.Width = 101;
            // 
            // dishes_ref_status_name
            // 
            this.dishes_ref_status_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dishes_ref_status_name.HeaderText = "Статус";
            this.dishes_ref_status_name.Name = "dishes_ref_status_name";
            this.dishes_ref_status_name.ReadOnly = true;
            this.dishes_ref_status_name.Width = 66;
            // 
            // statusStrip3
            // 
            this.statusStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel3});
            this.statusStrip3.Location = new System.Drawing.Point(3, 451);
            this.statusStrip3.Name = "statusStrip3";
            this.statusStrip3.Size = new System.Drawing.Size(319, 22);
            this.statusStrip3.SizingGrip = false;
            this.statusStrip3.TabIndex = 1;
            this.statusStrip3.Text = "statusStrip3";
            // 
            // toolStripStatusLabel3
            // 
            this.toolStripStatusLabel3.Name = "toolStripStatusLabel3";
            this.toolStripStatusLabel3.Size = new System.Drawing.Size(110, 17);
            this.toolStripStatusLabel3.Text = "tSSLabel_dishesInfo";
            // 
            // toolStrip3
            // 
            this.toolStrip3.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_dishAdd,
            this.toolStripButton_dishEdit,
            this.toolStripButton_dishDel});
            this.toolStrip3.Location = new System.Drawing.Point(3, 16);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(319, 25);
            this.toolStrip3.TabIndex = 0;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // toolStripButton_dishAdd
            // 
            this.toolStripButton_dishAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_dishAdd.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_dishAdd.Image")));
            this.toolStripButton_dishAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_dishAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_dishAdd.Name = "toolStripButton_dishAdd";
            this.toolStripButton_dishAdd.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_dishAdd.Text = "Добавить";
            this.toolStripButton_dishAdd.Click += new System.EventHandler(this.toolStripButton_dishAdd_Click);
            // 
            // toolStripButton_dishEdit
            // 
            this.toolStripButton_dishEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_dishEdit.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_dishEdit.Image")));
            this.toolStripButton_dishEdit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_dishEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_dishEdit.Name = "toolStripButton_dishEdit";
            this.toolStripButton_dishEdit.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_dishEdit.Text = "Редактировать";
            this.toolStripButton_dishEdit.Click += new System.EventHandler(this.toolStripButton_dishEdit_Click);
            // 
            // toolStripButton_dishDel
            // 
            this.toolStripButton_dishDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_dishDel.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_dishDel.Image")));
            this.toolStripButton_dishDel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_dishDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_dishDel.Name = "toolStripButton_dishDel";
            this.toolStripButton_dishDel.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_dishDel.Text = "Удалить";
            this.toolStripButton_dishDel.Click += new System.EventHandler(this.toolStripButton_dishDel_Click);
            // 
            // toolStrip4
            // 
            this.toolStrip4.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripTextBox_branchName,
            this.toolStripButton_branch});
            this.toolStrip4.Location = new System.Drawing.Point(0, 0);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Size = new System.Drawing.Size(939, 29);
            this.toolStrip4.TabIndex = 3;
            this.toolStrip4.Text = "toolStrip4";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Padding = new System.Windows.Forms.Padding(3);
            this.toolStripLabel1.Size = new System.Drawing.Size(76, 26);
            this.toolStripLabel1.Text = "Заведение";
            // 
            // toolStripTextBox_branchName
            // 
            this.toolStripTextBox_branchName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.toolStripTextBox_branchName.Name = "toolStripTextBox_branchName";
            this.toolStripTextBox_branchName.Padding = new System.Windows.Forms.Padding(3);
            this.toolStripTextBox_branchName.ReadOnly = true;
            this.toolStripTextBox_branchName.Size = new System.Drawing.Size(138, 29);
            // 
            // toolStripButton_branch
            // 
            this.toolStripButton_branch.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_branch.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_branch.Image")));
            this.toolStripButton_branch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_branch.Name = "toolStripButton_branch";
            this.toolStripButton_branch.Padding = new System.Windows.Forms.Padding(3);
            this.toolStripButton_branch.Size = new System.Drawing.Size(26, 26);
            this.toolStripButton_branch.Text = "Выбрать";
            this.toolStripButton_branch.Click += new System.EventHandler(this.toolStripButton_branch_Click);
            // 
            // fCarte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 513);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip4);
            this.MinimizeBox = false;
            this.Name = "fCarte";
            this.ShowInTaskbar = false;
            this.Text = "Меню";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_carte)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.statusStrip2.ResumeLayout(false);
            this.statusStrip2.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_dishes)).EndInit();
            this.statusStrip3.ResumeLayout(false);
            this.statusStrip3.PerformLayout();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dataGridView_carte;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_carteAdd;
        private System.Windows.Forms.ToolStripButton toolStripButton_carteEdit;
        private System.Windows.Forms.ToolStripButton toolStripButton_carteDel;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton_groupAdd;
        private System.Windows.Forms.ToolStripButton toolStripButton_groupEdit;
        private System.Windows.Forms.ToolStripButton toolStripButton_groupDel;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripButton toolStripButton_dishAdd;
        private System.Windows.Forms.ToolStripButton toolStripButton_dishEdit;
        private System.Windows.Forms.ToolStripButton toolStripButton_dishDel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.StatusStrip statusStrip2;
        private System.Windows.Forms.DataGridView dataGridView_dishes;
        private System.Windows.Forms.StatusStrip statusStrip3;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel3;
        private System.Windows.Forms.ToolStrip toolStrip4;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox_branchName;
        private System.Windows.Forms.ToolStripButton toolStripButton_branch;
        private System.Windows.Forms.DataGridViewTextBoxColumn carte_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn carte_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn carte_ref_status_name;
        private System.Windows.Forms.TreeView treeView_group;
        private System.Windows.Forms.DataGridViewTextBoxColumn dishes_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn dishes_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn dishes_price;
        private System.Windows.Forms.DataGridViewTextBoxColumn dishes_ref_printers_type_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn dishes_ref_status_name;
    }
}

