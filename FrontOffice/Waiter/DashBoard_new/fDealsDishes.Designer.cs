namespace com.sbs.gui.dashboard
{
    partial class fDealsDishes
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
            this.dataGridView_main = new System.Windows.Forms.DataGridView();
            this.refDishes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_dealsName = new System.Windows.Forms.Label();
            this.label_season = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_main)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_main
            // 
            this.dataGridView_main.AllowUserToAddRows = false;
            this.dataGridView_main.AllowUserToDeleteRows = false;
            this.dataGridView_main.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView_main.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView_main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_main.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.refDishes,
            this.name});
            this.dataGridView_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_main.Location = new System.Drawing.Point(0, 63);
            this.dataGridView_main.MultiSelect = false;
            this.dataGridView_main.Name = "dataGridView_main";
            this.dataGridView_main.ReadOnly = true;
            this.dataGridView_main.RowHeadersVisible = false;
            this.dataGridView_main.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.dataGridView_main.RowTemplate.Height = 25;
            this.dataGridView_main.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_main.Size = new System.Drawing.Size(575, 138);
            this.dataGridView_main.TabIndex = 0;
            // 
            // refDishes
            // 
            this.refDishes.HeaderText = "refDishes";
            this.refDishes.Name = "refDishes";
            this.refDishes.ReadOnly = true;
            this.refDishes.Visible = false;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.name.HeaderText = "Наименование";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(45)))), ((int)(((byte)(36)))));
            this.panel1.Controls.Add(this.label_dealsName);
            this.panel1.Controls.Add(this.label_season);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(575, 63);
            this.panel1.TabIndex = 1;
            // 
            // label_dealsName
            // 
            this.label_dealsName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_dealsName.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F);
            this.label_dealsName.ForeColor = System.Drawing.Color.White;
            this.label_dealsName.Location = new System.Drawing.Point(0, 35);
            this.label_dealsName.Name = "label_dealsName";
            this.label_dealsName.Size = new System.Drawing.Size(575, 28);
            this.label_dealsName.TabIndex = 2;
            this.label_dealsName.Text = "label_dealsName";
            this.label_dealsName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_season
            // 
            this.label_season.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_season.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_season.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(220)))), ((int)(((byte)(0)))));
            this.label_season.Location = new System.Drawing.Point(0, 0);
            this.label_season.Name = "label_season";
            this.label_season.Size = new System.Drawing.Size(575, 35);
            this.label_season.TabIndex = 1;
            this.label_season.Text = "Акция";
            this.label_season.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fDealsDishes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 201);
            this.ControlBox = false;
            this.Controls.Add(this.dataGridView_main);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "fDealsDishes";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.fDealsDishes_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fDealsDishes_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_main)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_main;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_season;
        private System.Windows.Forms.Label label_dealsName;
        private System.Windows.Forms.DataGridViewTextBoxColumn refDishes;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
    }
}