namespace com.sbs.gui.references.refdishes
{
    partial class fRefDishes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fRefDishes));
            this.dataGridView_main = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ref_status_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.minStep = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tSSLabel_recCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.tSButton_add = new System.Windows.Forms.ToolStripButton();
            this.tSButton_edit = new System.Windows.Forms.ToolStripButton();
            this.tSButton_del = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tSButton_dublicate = new System.Windows.Forms.ToolStripButton();
            this.panel_bottom = new System.Windows.Forms.Panel();
            this.textBox_search = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView_DishesGroups = new System.Windows.Forms.TreeView();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tSButton_addTree = new System.Windows.Forms.ToolStripButton();
            this.tSButton_editTree = new System.Windows.Forms.ToolStripButton();
            this.tSButton_delTree = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_main)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel_bottom.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_main
            // 
            this.dataGridView_main.AllowUserToAddRows = false;
            this.dataGridView_main.AllowUserToDeleteRows = false;
            this.dataGridView_main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_main.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.code,
            this.name,
            this.price,
            this.ref_status_name,
            this.minStep});
            this.dataGridView_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_main.Location = new System.Drawing.Point(3, 28);
            this.dataGridView_main.MultiSelect = false;
            this.dataGridView_main.Name = "dataGridView_main";
            this.dataGridView_main.ReadOnly = true;
            this.dataGridView_main.RowHeadersVisible = false;
            this.dataGridView_main.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_main.Size = new System.Drawing.Size(381, 433);
            this.dataGridView_main.TabIndex = 13;
            this.dataGridView_main.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView_main_KeyDown);
            this.dataGridView_main.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dataGridView_main_KeyPress);
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // code
            // 
            this.code.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.code.HeaderText = "Ключ";
            this.code.Name = "code";
            this.code.ReadOnly = true;
            this.code.Width = 58;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.name.HeaderText = "Наименование";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // price
            // 
            this.price.HeaderText = "Цена";
            this.price.Name = "price";
            this.price.ReadOnly = true;
            // 
            // ref_status_name
            // 
            this.ref_status_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ref_status_name.HeaderText = "Статус";
            this.ref_status_name.Name = "ref_status_name";
            this.ref_status_name.ReadOnly = true;
            this.ref_status_name.Width = 66;
            // 
            // minStep
            // 
            this.minStep.HeaderText = "minStep";
            this.minStep.Name = "minStep";
            this.minStep.ReadOnly = true;
            this.minStep.Visible = false;
            // 
            // tSSLabel_recCount
            // 
            this.tSSLabel_recCount.Name = "tSSLabel_recCount";
            this.tSSLabel_recCount.Size = new System.Drawing.Size(105, 17);
            this.tSSLabel_recCount.Text = "tSSLabel_recCount";
            // 
            // tSButton_add
            // 
            this.tSButton_add.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSButton_add.Image = ((System.Drawing.Image)(resources.GetObject("tSButton_add.Image")));
            this.tSButton_add.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tSButton_add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSButton_add.Name = "tSButton_add";
            this.tSButton_add.Size = new System.Drawing.Size(23, 22);
            this.tSButton_add.Text = "Добавить";
            this.tSButton_add.Click += new System.EventHandler(this.tSButton_add_Click);
            // 
            // tSButton_edit
            // 
            this.tSButton_edit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSButton_edit.Image = ((System.Drawing.Image)(resources.GetObject("tSButton_edit.Image")));
            this.tSButton_edit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tSButton_edit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSButton_edit.Name = "tSButton_edit";
            this.tSButton_edit.Size = new System.Drawing.Size(23, 22);
            this.tSButton_edit.Text = "Редактировать";
            this.tSButton_edit.Click += new System.EventHandler(this.tSButton_edit_Click);
            // 
            // tSButton_del
            // 
            this.tSButton_del.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSButton_del.Enabled = false;
            this.tSButton_del.Image = ((System.Drawing.Image)(resources.GetObject("tSButton_del.Image")));
            this.tSButton_del.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tSButton_del.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSButton_del.Name = "tSButton_del";
            this.tSButton_del.Size = new System.Drawing.Size(23, 22);
            this.tSButton_del.Text = "Удалить";
            this.tSButton_del.Click += new System.EventHandler(this.tSButton_del_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSSLabel_recCount});
            this.statusStrip1.Location = new System.Drawing.Point(0, 488);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(653, 22);
            this.statusStrip1.TabIndex = 12;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSButton_add,
            this.tSButton_edit,
            this.tSButton_del,
            this.tSButton_dublicate});
            this.toolStrip1.Location = new System.Drawing.Point(3, 3);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(381, 25);
            this.toolStrip1.TabIndex = 11;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tSButton_dublicate
            // 
            this.tSButton_dublicate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSButton_dublicate.Image = ((System.Drawing.Image)(resources.GetObject("tSButton_dublicate.Image")));
            this.tSButton_dublicate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tSButton_dublicate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSButton_dublicate.Name = "tSButton_dublicate";
            this.tSButton_dublicate.Size = new System.Drawing.Size(23, 22);
            this.tSButton_dublicate.Text = "Дублировать";
            this.tSButton_dublicate.Click += new System.EventHandler(this.tSButton_dublicate_Click);
            // 
            // panel_bottom
            // 
            this.panel_bottom.Controls.Add(this.textBox_search);
            this.panel_bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_bottom.Location = new System.Drawing.Point(0, 464);
            this.panel_bottom.Name = "panel_bottom";
            this.panel_bottom.Size = new System.Drawing.Size(653, 24);
            this.panel_bottom.TabIndex = 14;
            this.panel_bottom.Visible = false;
            // 
            // textBox_search
            // 
            this.textBox_search.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox_search.Location = new System.Drawing.Point(0, 4);
            this.textBox_search.Name = "textBox_search";
            this.textBox_search.Size = new System.Drawing.Size(653, 20);
            this.textBox_search.TabIndex = 0;
            this.textBox_search.TextChanged += new System.EventHandler(this.textBox_search_TextChanged);
            this.textBox_search.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_search_KeyDown);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView_DishesGroups);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip2);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(3);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView_main);
            this.splitContainer1.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(3);
            this.splitContainer1.Size = new System.Drawing.Size(653, 464);
            this.splitContainer1.SplitterDistance = 262;
            this.splitContainer1.TabIndex = 15;
            // 
            // treeView_DishesGroups
            // 
            this.treeView_DishesGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_DishesGroups.HideSelection = false;
            this.treeView_DishesGroups.Location = new System.Drawing.Point(3, 28);
            this.treeView_DishesGroups.Name = "treeView_DishesGroups";
            this.treeView_DishesGroups.Size = new System.Drawing.Size(256, 433);
            this.treeView_DishesGroups.TabIndex = 0;
            this.treeView_DishesGroups.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_DishesGroups_AfterSelect);
            // 
            // toolStrip2
            // 
            this.toolStrip2.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSButton_addTree,
            this.tSButton_editTree,
            this.tSButton_delTree});
            this.toolStrip2.Location = new System.Drawing.Point(3, 3);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip2.Size = new System.Drawing.Size(256, 25);
            this.toolStrip2.TabIndex = 1;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tSButton_addTree
            // 
            this.tSButton_addTree.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSButton_addTree.Image = ((System.Drawing.Image)(resources.GetObject("tSButton_addTree.Image")));
            this.tSButton_addTree.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tSButton_addTree.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSButton_addTree.Name = "tSButton_addTree";
            this.tSButton_addTree.Size = new System.Drawing.Size(23, 22);
            this.tSButton_addTree.Text = "Добавить";
            this.tSButton_addTree.Click += new System.EventHandler(this.tSButton_addTree_Click);
            // 
            // tSButton_editTree
            // 
            this.tSButton_editTree.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSButton_editTree.Image = ((System.Drawing.Image)(resources.GetObject("tSButton_editTree.Image")));
            this.tSButton_editTree.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tSButton_editTree.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSButton_editTree.Name = "tSButton_editTree";
            this.tSButton_editTree.Size = new System.Drawing.Size(23, 22);
            this.tSButton_editTree.Text = "Редактировать";
            this.tSButton_editTree.Click += new System.EventHandler(this.tSButton_editTree_Click);
            // 
            // tSButton_delTree
            // 
            this.tSButton_delTree.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSButton_delTree.Image = ((System.Drawing.Image)(resources.GetObject("tSButton_delTree.Image")));
            this.tSButton_delTree.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tSButton_delTree.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSButton_delTree.Name = "tSButton_delTree";
            this.tSButton_delTree.Size = new System.Drawing.Size(23, 22);
            this.tSButton_delTree.Text = "Удалить";
            this.tSButton_delTree.Click += new System.EventHandler(this.tSButton_delTree_Click);
            // 
            // fRefDishes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(653, 510);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel_bottom);
            this.Controls.Add(this.statusStrip1);
            this.MinimizeBox = false;
            this.Name = "fRefDishes";
            this.ShowInTaskbar = false;
            this.Text = "Блюда";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_main)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel_bottom.ResumeLayout(false);
            this.panel_bottom.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            this.splitContainer1.ResumeLayout(false);
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_main;
        private System.Windows.Forms.ToolStripStatusLabel tSSLabel_recCount;
        private System.Windows.Forms.ToolStripButton tSButton_add;
        private System.Windows.Forms.ToolStripButton tSButton_edit;
        private System.Windows.Forms.ToolStripButton tSButton_del;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn ref_status_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn minStep;
        private System.Windows.Forms.Panel panel_bottom;
        private System.Windows.Forms.TextBox textBox_search;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView_DishesGroups;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tSButton_addTree;
        private System.Windows.Forms.ToolStripButton tSButton_editTree;
        private System.Windows.Forms.ToolStripButton tSButton_delTree;
        private System.Windows.Forms.ToolStripButton tSButton_dublicate;
    }
}

