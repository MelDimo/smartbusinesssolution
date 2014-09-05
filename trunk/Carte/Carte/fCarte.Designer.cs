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
            this.tSSLabel_carteInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridView_carte = new System.Windows.Forms.DataGridView();
            this.carte_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.carte_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.carte_ref_status_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_carteAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_carteEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_carteDel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton_carteDublicate = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_printMenu = new System.Windows.Forms.ToolStripButton();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.treeView_group = new System.Windows.Forms.TreeView();
            this.statusStrip2 = new System.Windows.Forms.StatusStrip();
            this.tSSLabel_groupInfo = new System.Windows.Forms.ToolStripStatusLabel();
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
            this.tSSLabel_dishesInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_dishAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_dishEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_dishDel = new System.Windows.Forms.ToolStripButton();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripTextBox_branchName = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripButton_branch = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_addFilter = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_filterCarteDishesRefStatus = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_filterCarteDishesGroupRefStatus = new System.Windows.Forms.ComboBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_filterCarteRefStatus = new System.Windows.Forms.ComboBox();
            this.groupBox_advFilter = new System.Windows.Forms.GroupBox();
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
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.groupBox_advFilter.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 106);
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
            this.splitContainer1.Size = new System.Drawing.Size(939, 407);
            this.splitContainer1.SplitterDistance = 365;
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
            this.groupBox1.Size = new System.Drawing.Size(361, 403);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Меню";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSSLabel_carteInfo});
            this.statusStrip1.Location = new System.Drawing.Point(3, 378);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(355, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tSSLabel_carteInfo
            // 
            this.tSSLabel_carteInfo.Name = "tSSLabel_carteInfo";
            this.tSSLabel_carteInfo.Size = new System.Drawing.Size(103, 17);
            this.tSSLabel_carteInfo.Text = "tSSLabel_carteInfo";
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
            this.dataGridView_carte.Size = new System.Drawing.Size(355, 359);
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
            this.toolStripButton_carteDel,
            this.toolStripSeparator1,
            this.toolStripButton_carteDublicate,
            this.toolStripButton_printMenu});
            this.toolStrip1.Location = new System.Drawing.Point(3, 16);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(355, 25);
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
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButton_carteDublicate
            // 
            this.toolStripButton_carteDublicate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_carteDublicate.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_carteDublicate.Image")));
            this.toolStripButton_carteDublicate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_carteDublicate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_carteDublicate.Name = "toolStripButton_carteDublicate";
            this.toolStripButton_carteDublicate.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_carteDublicate.Text = "Дублировать";
            this.toolStripButton_carteDublicate.ToolTipText = "Дублировать";
            this.toolStripButton_carteDublicate.Click += new System.EventHandler(this.toolStripButton_carteDublicate_Click);
            // 
            // toolStripButton_printMenu
            // 
            this.toolStripButton_printMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_printMenu.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_printMenu.Image")));
            this.toolStripButton_printMenu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_printMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_printMenu.Name = "toolStripButton_printMenu";
            this.toolStripButton_printMenu.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_printMenu.Text = "Печать меню";
            this.toolStripButton_printMenu.Click += new System.EventHandler(this.toolStripButton_printMenu_Click);
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
            this.splitContainer2.Size = new System.Drawing.Size(566, 403);
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
            this.groupBox2.Size = new System.Drawing.Size(246, 399);
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
            this.treeView_group.Size = new System.Drawing.Size(240, 333);
            this.treeView_group.TabIndex = 2;
            this.treeView_group.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_group_AfterSelect);
            // 
            // statusStrip2
            // 
            this.statusStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSSLabel_groupInfo});
            this.statusStrip2.Location = new System.Drawing.Point(3, 374);
            this.statusStrip2.Name = "statusStrip2";
            this.statusStrip2.Size = new System.Drawing.Size(240, 22);
            this.statusStrip2.SizingGrip = false;
            this.statusStrip2.TabIndex = 1;
            this.statusStrip2.Text = "statusStrip2";
            // 
            // tSSLabel_groupInfo
            // 
            this.tSSLabel_groupInfo.Name = "tSSLabel_groupInfo";
            this.tSSLabel_groupInfo.Size = new System.Drawing.Size(109, 17);
            this.tSSLabel_groupInfo.Text = "tSSLabel_groupInfo";
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
            this.groupBox3.Size = new System.Drawing.Size(308, 399);
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
            this.dataGridView_dishes.Size = new System.Drawing.Size(302, 333);
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
            this.tSSLabel_dishesInfo});
            this.statusStrip3.Location = new System.Drawing.Point(3, 374);
            this.statusStrip3.Name = "statusStrip3";
            this.statusStrip3.Size = new System.Drawing.Size(302, 22);
            this.statusStrip3.SizingGrip = false;
            this.statusStrip3.TabIndex = 1;
            this.statusStrip3.Text = "statusStrip3";
            // 
            // tSSLabel_dishesInfo
            // 
            this.tSSLabel_dishesInfo.Name = "tSSLabel_dishesInfo";
            this.tSSLabel_dishesInfo.Size = new System.Drawing.Size(110, 17);
            this.tSSLabel_dishesInfo.Text = "tSSLabel_dishesInfo";
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
            this.toolStrip3.Size = new System.Drawing.Size(302, 25);
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
            this.toolStripButton_dishDel.Enabled = false;
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
            this.toolStripButton_branch,
            this.toolStripButton_addFilter});
            this.toolStrip4.Location = new System.Drawing.Point(0, 0);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Padding = new System.Windows.Forms.Padding(2);
            this.toolStrip4.Size = new System.Drawing.Size(939, 33);
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
            this.toolStripTextBox_branchName.Size = new System.Drawing.Size(168, 29);
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
            // toolStripButton_addFilter
            // 
            this.toolStripButton_addFilter.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.toolStripButton_addFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_addFilter.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_addFilter.Image")));
            this.toolStripButton_addFilter.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_addFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_addFilter.Name = "toolStripButton_addFilter";
            this.toolStripButton_addFilter.Size = new System.Drawing.Size(23, 26);
            this.toolStripButton_addFilter.Text = "Настройки фильтра";
            this.toolStripButton_addFilter.ToolTipText = "Настройки фильтра";
            this.toolStripButton_addFilter.Click += new System.EventHandler(this.toolStripButton_addFilter_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.9485F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.68241F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.3691F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox6, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox5, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox4, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(933, 54);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.tableLayoutPanel4);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(624, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(306, 48);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Ассортимент";
            this.groupBox6.Visible = false;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.95442F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 84.04558F));
            this.tableLayoutPanel4.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.comboBox_filterCarteDishesRefStatus, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(300, 29);
            this.tableLayoutPanel4.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 25);
            this.label3.TabIndex = 0;
            this.label3.Text = "Статус";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox_filterCarteDishesRefStatus
            // 
            this.comboBox_filterCarteDishesRefStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_filterCarteDishesRefStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_filterCarteDishesRefStatus.FormattingEnabled = true;
            this.comboBox_filterCarteDishesRefStatus.Location = new System.Drawing.Point(50, 3);
            this.comboBox_filterCarteDishesRefStatus.Name = "comboBox_filterCarteDishesRefStatus";
            this.comboBox_filterCarteDishesRefStatus.Size = new System.Drawing.Size(247, 21);
            this.comboBox_filterCarteDishesRefStatus.TabIndex = 1;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tableLayoutPanel3);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(366, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(252, 48);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Структура меню";
            this.groupBox5.Visible = false;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.comboBox_filterCarteDishesGroupRefStatus, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(246, 29);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Статус";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox_filterCarteDishesGroupRefStatus
            // 
            this.comboBox_filterCarteDishesGroupRefStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_filterCarteDishesGroupRefStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_filterCarteDishesGroupRefStatus.FormattingEnabled = true;
            this.comboBox_filterCarteDishesGroupRefStatus.Location = new System.Drawing.Point(53, 3);
            this.comboBox_filterCarteDishesGroupRefStatus.Name = "comboBox_filterCarteDishesGroupRefStatus";
            this.comboBox_filterCarteDishesGroupRefStatus.Size = new System.Drawing.Size(190, 21);
            this.comboBox_filterCarteDishesGroupRefStatus.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tableLayoutPanel2);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(357, 48);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Меню";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 53F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.comboBox_filterCarteRefStatus, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(351, 29);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Статус";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox_filterCarteRefStatus
            // 
            this.comboBox_filterCarteRefStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_filterCarteRefStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_filterCarteRefStatus.FormattingEnabled = true;
            this.comboBox_filterCarteRefStatus.Location = new System.Drawing.Point(56, 3);
            this.comboBox_filterCarteRefStatus.Name = "comboBox_filterCarteRefStatus";
            this.comboBox_filterCarteRefStatus.Size = new System.Drawing.Size(292, 21);
            this.comboBox_filterCarteRefStatus.TabIndex = 1;
            // 
            // groupBox_advFilter
            // 
            this.groupBox_advFilter.Controls.Add(this.tableLayoutPanel1);
            this.groupBox_advFilter.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_advFilter.Location = new System.Drawing.Point(0, 33);
            this.groupBox_advFilter.Name = "groupBox_advFilter";
            this.groupBox_advFilter.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox_advFilter.Size = new System.Drawing.Size(939, 73);
            this.groupBox_advFilter.TabIndex = 0;
            this.groupBox_advFilter.TabStop = false;
            this.groupBox_advFilter.Text = "Настройки фильтра";
            // 
            // fCarte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 513);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.groupBox_advFilter);
            this.Controls.Add(this.toolStrip4);
            this.MinimizeBox = false;
            this.Name = "fCarte";
            this.ShowInTaskbar = false;
            this.Text = "Меню";
            this.Shown += new System.EventHandler(this.fCarte_Shown);
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
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.groupBox_advFilter.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripStatusLabel tSSLabel_carteInfo;
        private System.Windows.Forms.ToolStripStatusLabel tSSLabel_groupInfo;
        private System.Windows.Forms.ToolStripStatusLabel tSSLabel_dishesInfo;
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
        private System.Windows.Forms.ToolStripButton toolStripButton_carteDublicate;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton_addFilter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox_advFilter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_filterCarteRefStatus;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_filterCarteDishesRefStatus;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox_filterCarteDishesGroupRefStatus;
        private System.Windows.Forms.ToolStripButton toolStripButton_printMenu;
    }
}

