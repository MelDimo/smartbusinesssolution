namespace com.sbs.gui.linkdevice
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
            this.toolStrip_top = new System.Windows.Forms.ToolStrip();
            this.tSButton_edit = new System.Windows.Forms.ToolStripButton();
            this.dataGridView_main = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.season = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.waiter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip_top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_main)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip_bottom
            // 
            this.statusStrip_bottom.Location = new System.Drawing.Point(0, 496);
            this.statusStrip_bottom.Name = "statusStrip_bottom";
            this.statusStrip_bottom.Size = new System.Drawing.Size(387, 22);
            this.statusStrip_bottom.TabIndex = 0;
            this.statusStrip_bottom.Text = "statusStrip1";
            // 
            // toolStrip_top
            // 
            this.toolStrip_top.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip_top.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSButton_edit});
            this.toolStrip_top.Location = new System.Drawing.Point(0, 0);
            this.toolStrip_top.Name = "toolStrip_top";
            this.toolStrip_top.Size = new System.Drawing.Size(387, 25);
            this.toolStrip_top.TabIndex = 1;
            this.toolStrip_top.Text = "toolStrip1";
            // 
            // tSButton_edit
            // 
            this.tSButton_edit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSButton_edit.Image = ((System.Drawing.Image)(resources.GetObject("tSButton_edit.Image")));
            this.tSButton_edit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tSButton_edit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSButton_edit.Name = "tSButton_edit";
            this.tSButton_edit.Size = new System.Drawing.Size(23, 22);
            this.tSButton_edit.ToolTipText = "Редактровать";
            // 
            // dataGridView_main
            // 
            this.dataGridView_main.AllowUserToDeleteRows = false;
            this.dataGridView_main.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView_main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_main.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.season,
            this.waiter});
            this.dataGridView_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_main.Location = new System.Drawing.Point(0, 25);
            this.dataGridView_main.MultiSelect = false;
            this.dataGridView_main.Name = "dataGridView_main";
            this.dataGridView_main.ReadOnly = true;
            this.dataGridView_main.RowHeadersVisible = false;
            this.dataGridView_main.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_main.Size = new System.Drawing.Size(387, 471);
            this.dataGridView_main.TabIndex = 2;
            // 
            // id
            // 
            this.id.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.id.HeaderText = "ID обоудования";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // season
            // 
            this.season.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.season.HeaderText = "Смена";
            this.season.Name = "season";
            this.season.ReadOnly = true;
            this.season.Width = 65;
            // 
            // waiter
            // 
            this.waiter.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.waiter.HeaderText = "Официант";
            this.waiter.Name = "waiter";
            this.waiter.ReadOnly = true;
            this.waiter.Width = 83;
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 518);
            this.Controls.Add(this.dataGridView_main);
            this.Controls.Add(this.toolStrip_top);
            this.Controls.Add(this.statusStrip_bottom);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fMain";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Мобольные официанты";
            this.toolStrip_top.ResumeLayout(false);
            this.toolStrip_top.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_main)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip_bottom;
        private System.Windows.Forms.ToolStrip toolStrip_top;
        private System.Windows.Forms.ToolStripButton tSButton_edit;
        private System.Windows.Forms.DataGridView dataGridView_main;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn season;
        private System.Windows.Forms.DataGridViewTextBoxColumn waiter;
    }
}

