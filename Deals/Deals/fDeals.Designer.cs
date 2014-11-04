namespace com.sbs.gui.deals
{
    partial class fDeals
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fDeals));
            this.toolStrip_top = new System.Windows.Forms.ToolStrip();
            this.toolStripButton_add = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_edit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton_del = new System.Windows.Forms.ToolStripButton();
            this.dataGridView_main = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.treeView_carte = new System.Windows.Forms.TreeView();
            this.deals_id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deals_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deals_dateStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deals_dateEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deals_refStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip_top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_main)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip_top
            // 
            this.toolStrip_top.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip_top.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_add,
            this.toolStripButton_edit,
            this.toolStripButton_del});
            this.toolStrip_top.Location = new System.Drawing.Point(3, 16);
            this.toolStrip_top.Name = "toolStrip_top";
            this.toolStrip_top.Padding = new System.Windows.Forms.Padding(2);
            this.toolStrip_top.Size = new System.Drawing.Size(476, 27);
            this.toolStrip_top.TabIndex = 0;
            this.toolStrip_top.Text = "toolStrip1";
            // 
            // toolStripButton_add
            // 
            this.toolStripButton_add.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_add.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_add.Image")));
            this.toolStripButton_add.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_add.Name = "toolStripButton_add";
            this.toolStripButton_add.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton_add.Text = "Добавить";
            this.toolStripButton_add.Click += new System.EventHandler(this.toolStripButton_add_Click);
            // 
            // toolStripButton_edit
            // 
            this.toolStripButton_edit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_edit.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_edit.Image")));
            this.toolStripButton_edit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_edit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_edit.Name = "toolStripButton_edit";
            this.toolStripButton_edit.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton_edit.Text = "Редактировать";
            this.toolStripButton_edit.Click += new System.EventHandler(this.toolStripButton_edit_Click);
            // 
            // toolStripButton_del
            // 
            this.toolStripButton_del.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton_del.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton_del.Image")));
            this.toolStripButton_del.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripButton_del.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton_del.Name = "toolStripButton_del";
            this.toolStripButton_del.Size = new System.Drawing.Size(23, 20);
            this.toolStripButton_del.Text = "Удалить";
            this.toolStripButton_del.Click += new System.EventHandler(this.toolStripButton_del_Click);
            // 
            // dataGridView_main
            // 
            this.dataGridView_main.AllowUserToAddRows = false;
            this.dataGridView_main.AllowUserToDeleteRows = false;
            this.dataGridView_main.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView_main.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_main.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.deals_id,
            this.deals_name,
            this.deals_dateStart,
            this.deals_dateEnd,
            this.deals_refStatus});
            this.dataGridView_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_main.Location = new System.Drawing.Point(3, 43);
            this.dataGridView_main.Name = "dataGridView_main";
            this.dataGridView_main.ReadOnly = true;
            this.dataGridView_main.RowHeadersVisible = false;
            this.dataGridView_main.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_main.Size = new System.Drawing.Size(476, 411);
            this.dataGridView_main.TabIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView_main);
            this.groupBox1.Controls.Add(this.toolStrip_top);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(482, 457);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Акции";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(2, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Size = new System.Drawing.Size(819, 457);
            this.splitContainer1.SplitterDistance = 333;
            this.splitContainer1.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.treeView_carte);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(333, 457);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Меню";
            // 
            // treeView_carte
            // 
            this.treeView_carte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_carte.FullRowSelect = true;
            this.treeView_carte.HideSelection = false;
            this.treeView_carte.Location = new System.Drawing.Point(3, 16);
            this.treeView_carte.Name = "treeView_carte";
            this.treeView_carte.Size = new System.Drawing.Size(327, 438);
            this.treeView_carte.TabIndex = 0;
            // 
            // deals_id
            // 
            this.deals_id.HeaderText = "id";
            this.deals_id.Name = "deals_id";
            this.deals_id.ReadOnly = true;
            this.deals_id.Visible = false;
            // 
            // deals_name
            // 
            this.deals_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.deals_name.HeaderText = "Наименование";
            this.deals_name.Name = "deals_name";
            this.deals_name.ReadOnly = true;
            // 
            // deals_dateStart
            // 
            this.deals_dateStart.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.deals_dateStart.HeaderText = "Начало";
            this.deals_dateStart.Name = "deals_dateStart";
            this.deals_dateStart.ReadOnly = true;
            this.deals_dateStart.Width = 69;
            // 
            // deals_dateEnd
            // 
            this.deals_dateEnd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.deals_dateEnd.HeaderText = "Окончание";
            this.deals_dateEnd.Name = "deals_dateEnd";
            this.deals_dateEnd.ReadOnly = true;
            this.deals_dateEnd.Width = 87;
            // 
            // deals_refStatus
            // 
            this.deals_refStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.deals_refStatus.HeaderText = "Статус";
            this.deals_refStatus.Name = "deals_refStatus";
            this.deals_refStatus.ReadOnly = true;
            this.deals_refStatus.Width = 66;
            // 
            // fDeals
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(823, 461);
            this.Controls.Add(this.splitContainer1);
            this.MinimizeBox = false;
            this.Name = "fDeals";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.ShowIcon = false;
            this.Text = "Акции";
            this.toolStrip_top.ResumeLayout(false);
            this.toolStrip_top.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_main)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip_top;
        private System.Windows.Forms.ToolStripButton toolStripButton_add;
        private System.Windows.Forms.ToolStripButton toolStripButton_edit;
        private System.Windows.Forms.ToolStripButton toolStripButton_del;
        private System.Windows.Forms.DataGridView dataGridView_main;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TreeView treeView_carte;
        private System.Windows.Forms.DataGridViewTextBoxColumn deals_id;
        private System.Windows.Forms.DataGridViewTextBoxColumn deals_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn deals_dateStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn deals_dateEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn deals_refStatus;
    }
}

