namespace com.sbs.gui.carte
{
    partial class fTopping
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fTopping));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.treeView_toppGroup = new System.Windows.Forms.TreeView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_groupAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_groupEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_groupDel = new System.Windows.Forms.ToolStripButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView_topping = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_toppingAdd = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_toppingDel = new System.Windows.Forms.ToolStripButton();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toppings_groups = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cartedishes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_topping)).BeginInit();
            this.toolStrip1.SuspendLayout();
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
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(632, 451);
            this.splitContainer1.SplitterDistance = 228;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.treeView_toppGroup);
            this.groupBox1.Controls.Add(this.toolStrip2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(228, 451);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Группы";
            // 
            // treeView_toppGroup
            // 
            this.treeView_toppGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_toppGroup.FullRowSelect = true;
            this.treeView_toppGroup.HideSelection = false;
            this.treeView_toppGroup.Location = new System.Drawing.Point(3, 41);
            this.treeView_toppGroup.Name = "treeView_toppGroup";
            this.treeView_toppGroup.Size = new System.Drawing.Size(222, 407);
            this.treeView_toppGroup.TabIndex = 2;
            this.treeView_toppGroup.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_toppGroup_AfterSelect);
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
            this.toolStrip2.Size = new System.Drawing.Size(222, 25);
            this.toolStrip2.TabIndex = 1;
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
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView_topping);
            this.groupBox2.Controls.Add(this.toolStrip1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(400, 451);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Топпинги";
            // 
            // dataGridView_topping
            // 
            this.dataGridView_topping.AllowUserToAddRows = false;
            this.dataGridView_topping.AllowUserToDeleteRows = false;
            this.dataGridView_topping.AllowUserToResizeColumns = false;
            this.dataGridView_topping.AllowUserToResizeRows = false;
            this.dataGridView_topping.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_topping.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.toppings_groups,
            this.cartedishes,
            this.name,
            this.price});
            this.dataGridView_topping.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_topping.Location = new System.Drawing.Point(3, 41);
            this.dataGridView_topping.MultiSelect = false;
            this.dataGridView_topping.Name = "dataGridView_topping";
            this.dataGridView_topping.ReadOnly = true;
            this.dataGridView_topping.RowHeadersVisible = false;
            this.dataGridView_topping.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_topping.Size = new System.Drawing.Size(394, 407);
            this.dataGridView_topping.TabIndex = 3;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_toppingAdd,
            this.toolStripButton_toppingDel});
            this.toolStrip1.Location = new System.Drawing.Point(3, 16);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(394, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton_toppingAdd
            // 
            this.toolStripButton_toppingAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_toppingAdd.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_toppingAdd.Image")));
            this.toolStripButton_toppingAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_toppingAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_toppingAdd.Name = "toolStripButton_toppingAdd";
            this.toolStripButton_toppingAdd.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_toppingAdd.Text = "Добавить";
            this.toolStripButton_toppingAdd.Click += new System.EventHandler(this.toolStripButton_toppingAdd_Click);
            // 
            // toolStripButton_toppingDel
            // 
            this.toolStripButton_toppingDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_toppingDel.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_toppingDel.Image")));
            this.toolStripButton_toppingDel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_toppingDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_toppingDel.Name = "toolStripButton_toppingDel";
            this.toolStripButton_toppingDel.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton_toppingDel.Text = "Удалить";
            this.toolStripButton_toppingDel.Click += new System.EventHandler(this.toolStripButton_toppingDel_Click);
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // toppings_groups
            // 
            this.toppings_groups.HeaderText = "toppings_groups";
            this.toppings_groups.Name = "toppings_groups";
            this.toppings_groups.ReadOnly = true;
            this.toppings_groups.Visible = false;
            // 
            // cartedishes
            // 
            this.cartedishes.HeaderText = "cartedishes";
            this.cartedishes.Name = "cartedishes";
            this.cartedishes.ReadOnly = true;
            this.cartedishes.Visible = false;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.name.HeaderText = "Блюдо";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // price
            // 
            this.price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.price.HeaderText = "Цена";
            this.price.Name = "price";
            this.price.ReadOnly = true;
            this.price.Width = 58;
            // 
            // fTopping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 451);
            this.Controls.Add(this.splitContainer1);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(648, 489);
            this.Name = "fTopping";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Редактирование топпингов";
            this.Shown += new System.EventHandler(this.fTopping_Shown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_topping)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView treeView_toppGroup;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton toolStripButton_groupAdd;
        private System.Windows.Forms.ToolStripButton toolStripButton_groupEdit;
        private System.Windows.Forms.ToolStripButton toolStripButton_groupDel;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView_topping;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton_toppingAdd;
        private System.Windows.Forms.ToolStripButton toolStripButton_toppingDel;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn toppings_groups;
        private System.Windows.Forms.DataGridViewTextBoxColumn cartedishes;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;

    }
}