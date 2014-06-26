namespace com.sbs.gui.usersdiscount
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tSSLabel_count = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tSSLabel_add = new System.Windows.Forms.ToolStripButton();
            this.tSSLabel_edit = new System.Windows.Forms.ToolStripButton();
            this.tSSLabel_del = new System.Windows.Forms.ToolStripButton();
            this.dataGridView_main = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.discount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.refStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateStart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.xkey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isExpDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_main)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSSLabel_count});
            this.statusStrip1.Location = new System.Drawing.Point(0, 354);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(646, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tSSLabel_count
            // 
            this.tSSLabel_count.Name = "tSSLabel_count";
            this.tSSLabel_count.Size = new System.Drawing.Size(87, 17);
            this.tSSLabel_count.Text = "tSSLabel_count";
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSSLabel_add,
            this.tSSLabel_edit,
            this.tSSLabel_del});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(646, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tSSLabel_add
            // 
            this.tSSLabel_add.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSSLabel_add.Image = ((System.Drawing.Image)(resources.GetObject("tSSLabel_add.Image")));
            this.tSSLabel_add.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tSSLabel_add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSSLabel_add.Name = "tSSLabel_add";
            this.tSSLabel_add.Size = new System.Drawing.Size(23, 22);
            this.tSSLabel_add.ToolTipText = "Добавить";
            this.tSSLabel_add.Click += new System.EventHandler(this.tSSLabel_add_Click);
            // 
            // tSSLabel_edit
            // 
            this.tSSLabel_edit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSSLabel_edit.Image = ((System.Drawing.Image)(resources.GetObject("tSSLabel_edit.Image")));
            this.tSSLabel_edit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tSSLabel_edit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSSLabel_edit.Name = "tSSLabel_edit";
            this.tSSLabel_edit.Size = new System.Drawing.Size(23, 22);
            this.tSSLabel_edit.ToolTipText = "Редактировать";
            this.tSSLabel_edit.Click += new System.EventHandler(this.tSSLabel_edit_Click);
            // 
            // tSSLabel_del
            // 
            this.tSSLabel_del.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSSLabel_del.Image = ((System.Drawing.Image)(resources.GetObject("tSSLabel_del.Image")));
            this.tSSLabel_del.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tSSLabel_del.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSSLabel_del.Name = "tSSLabel_del";
            this.tSSLabel_del.Size = new System.Drawing.Size(23, 22);
            this.tSSLabel_del.ToolTipText = "Удалить";
            this.tSSLabel_del.Click += new System.EventHandler(this.tSSLabel_del_Click);
            // 
            // dataGridView_main
            // 
            this.dataGridView_main.AllowUserToAddRows = false;
            this.dataGridView_main.AllowUserToDeleteRows = false;
            this.dataGridView_main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_main.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.fio,
            this.discount,
            this.refStatus,
            this.dateStart,
            this.dateEnd,
            this.xkey,
            this.isExpDate});
            this.dataGridView_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_main.Location = new System.Drawing.Point(0, 25);
            this.dataGridView_main.MultiSelect = false;
            this.dataGridView_main.Name = "dataGridView_main";
            this.dataGridView_main.ReadOnly = true;
            this.dataGridView_main.RowHeadersVisible = false;
            this.dataGridView_main.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_main.Size = new System.Drawing.Size(646, 329);
            this.dataGridView_main.TabIndex = 2;
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // fio
            // 
            this.fio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fio.HeaderText = "ФИО";
            this.fio.Name = "fio";
            this.fio.ReadOnly = true;
            // 
            // discount
            // 
            this.discount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.discount.HeaderText = "Скидка";
            this.discount.Name = "discount";
            this.discount.ReadOnly = true;
            this.discount.Width = 69;
            // 
            // refStatus
            // 
            this.refStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.refStatus.HeaderText = "Статус";
            this.refStatus.Name = "refStatus";
            this.refStatus.ReadOnly = true;
            this.refStatus.Visible = false;
            this.refStatus.Width = 66;
            // 
            // dateStart
            // 
            this.dateStart.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dateStart.HeaderText = "Дата начала";
            this.dateStart.Name = "dateStart";
            this.dateStart.ReadOnly = true;
            this.dateStart.Width = 96;
            // 
            // dateEnd
            // 
            this.dateEnd.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dateEnd.HeaderText = "Дата окончания";
            this.dateEnd.Name = "dateEnd";
            this.dateEnd.ReadOnly = true;
            this.dateEnd.Width = 105;
            // 
            // xkey
            // 
            this.xkey.HeaderText = "Ключ";
            this.xkey.Name = "xkey";
            this.xkey.ReadOnly = true;
            this.xkey.Visible = false;
            // 
            // isExpDate
            // 
            this.isExpDate.HeaderText = "isExpDate";
            this.isExpDate.Name = "isExpDate";
            this.isExpDate.ReadOnly = true;
            this.isExpDate.Visible = false;
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(646, 376);
            this.Controls.Add(this.dataGridView_main);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip1);
            this.MinimizeBox = false;
            this.Name = "fMain";
            this.ShowInTaskbar = false;
            this.Text = "Дисконтные карты";
            this.Shown += new System.EventHandler(this.fMain_Shown);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_main)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tSSLabel_count;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tSSLabel_add;
        private System.Windows.Forms.ToolStripButton tSSLabel_edit;
        private System.Windows.Forms.ToolStripButton tSSLabel_del;
        private System.Windows.Forms.DataGridView dataGridView_main;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn fio;
        private System.Windows.Forms.DataGridViewTextBoxColumn discount;
        private System.Windows.Forms.DataGridViewTextBoxColumn refStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateStart;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn xkey;
        private System.Windows.Forms.DataGridViewTextBoxColumn isExpDate;
    }
}

