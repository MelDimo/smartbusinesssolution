namespace com.sbs.gui.references.refitems
{
    partial class fRefItems
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fRefItems));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tSButton_add = new System.Windows.Forms.ToolStripButton();
            this.tSButton_edit = new System.Windows.Forms.ToolStripButton();
            this.tSButton_del = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tSSLabel_recCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridView_main = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ref_tmc_type_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ref_measure_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ref_status_name = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.toolStrip1.Size = new System.Drawing.Size(589, 25);
            this.toolStrip1.TabIndex = 9;
            this.toolStrip1.Text = "toolStrip1";
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
            this.statusStrip1.Location = new System.Drawing.Point(0, 353);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(589, 22);
            this.statusStrip1.TabIndex = 10;
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_main.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView_main.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.name,
            this.ref_tmc_type_name,
            this.ref_measure_name,
            this.ref_status_name});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_main.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_main.Location = new System.Drawing.Point(0, 25);
            this.dataGridView_main.Name = "dataGridView_main";
            this.dataGridView_main.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_main.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView_main.RowHeadersVisible = false;
            this.dataGridView_main.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_main.Size = new System.Drawing.Size(589, 328);
            this.dataGridView_main.TabIndex = 11;
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.name.HeaderText = "Наименование";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // ref_tmc_type_name
            // 
            this.ref_tmc_type_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ref_tmc_type_name.HeaderText = "Тип ТМЦ";
            this.ref_tmc_type_name.Name = "ref_tmc_type_name";
            this.ref_tmc_type_name.ReadOnly = true;
            // 
            // ref_measure_name
            // 
            this.ref_measure_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ref_measure_name.HeaderText = "Ед. измерения";
            this.ref_measure_name.Name = "ref_measure_name";
            this.ref_measure_name.ReadOnly = true;
            this.ref_measure_name.Width = 107;
            // 
            // ref_status_name
            // 
            this.ref_status_name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.ref_status_name.HeaderText = "Статус";
            this.ref_status_name.Name = "ref_status_name";
            this.ref_status_name.ReadOnly = true;
            this.ref_status_name.Width = 66;
            // 
            // fRefItems
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 375);
            this.Controls.Add(this.dataGridView_main);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.MinimizeBox = false;
            this.Name = "fRefItems";
            this.ShowInTaskbar = false;
            this.Text = "Справочник Материалов";
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
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn ref_tmc_type_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn ref_measure_name;
        private System.Windows.Forms.DataGridViewTextBoxColumn ref_status_name;
    }
}

