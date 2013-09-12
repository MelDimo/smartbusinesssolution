namespace com.sbs.gui.references.modules
{
    partial class fRefModules
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fRefModules));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tSButton_add = new System.Windows.Forms.ToolStripButton();
            this.tSButton_edit = new System.Windows.Forms.ToolStripButton();
            this.tSButton_del = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tSSLabel_recCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridView_main = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fname = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fpath = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.assembly_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isGUI = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_main)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSButton_add,
            this.tSButton_edit,
            this.tSButton_del});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(648, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tSButton_add
            // 
            this.tSButton_add.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSButton_add.Image = ((System.Drawing.Image)(resources.GetObject("tSButton_add.Image")));
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
            this.tSButton_edit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSButton_edit.Name = "tSButton_edit";
            this.tSButton_edit.Size = new System.Drawing.Size(23, 22);
            this.tSButton_edit.Text = "Редактировать";
            this.tSButton_edit.Click += new System.EventHandler(this.tSButton_edit_Click);
            // 
            // tSButton_del
            // 
            this.tSButton_del.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSButton_del.Image = ((System.Drawing.Image)(resources.GetObject("tSButton_del.Image")));
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 403);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(648, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tSSLabel_recCount
            // 
            this.tSSLabel_recCount.Name = "tSSLabel_recCount";
            this.tSSLabel_recCount.Size = new System.Drawing.Size(105, 17);
            this.tSSLabel_recCount.Text = "tSSLabel_recCount";
            // 
            // dataGridView_main
            // 
            this.dataGridView_main.AllowUserToAddRows = false;
            this.dataGridView_main.AllowUserToDeleteRows = false;
            this.dataGridView_main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_main.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.fname,
            this.fpath,
            this.assembly_name,
            this.isGUI});
            this.dataGridView_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_main.Location = new System.Drawing.Point(0, 25);
            this.dataGridView_main.MultiSelect = false;
            this.dataGridView_main.Name = "dataGridView_main";
            this.dataGridView_main.RowHeadersVisible = false;
            this.dataGridView_main.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_main.Size = new System.Drawing.Size(648, 378);
            this.dataGridView_main.TabIndex = 4;
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // fname
            // 
            this.fname.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.fname.HeaderText = "Имя файла";
            this.fname.Name = "fname";
            this.fname.ReadOnly = true;
            this.fname.Width = 5;
            // 
            // fpath
            // 
            this.fpath.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fpath.HeaderText = "Путь к файлу";
            this.fpath.Name = "fpath";
            this.fpath.ReadOnly = true;
            // 
            // assembly_name
            // 
            this.assembly_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCellsExceptHeader;
            this.assembly_name.HeaderText = "Имя сборки";
            this.assembly_name.Name = "assembly_name";
            this.assembly_name.ReadOnly = true;
            this.assembly_name.Width = 5;
            // 
            // isGUI
            // 
            this.isGUI.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.isGUI.FalseValue = "0";
            this.isGUI.HeaderText = "Интерфейс?";
            this.isGUI.Name = "isGUI";
            this.isGUI.ReadOnly = true;
            this.isGUI.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.isGUI.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.isGUI.TrueValue = "1";
            this.isGUI.Width = 95;
            // 
            // fRefModules
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 425);
            this.Controls.Add(this.dataGridView_main);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "fRefModules";
            this.Text = "Справочник модулей";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_main)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tSButton_add;
        private System.Windows.Forms.ToolStripButton tSButton_edit;
        private System.Windows.Forms.ToolStripButton tSButton_del;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tSSLabel_recCount;
        private System.Windows.Forms.DataGridView dataGridView_main;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn fname;
        private System.Windows.Forms.DataGridViewTextBoxColumn fpath;
        private System.Windows.Forms.DataGridViewTextBoxColumn assembly_name;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isGUI;
    }
}

