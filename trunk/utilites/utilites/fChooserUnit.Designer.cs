namespace com.sbs.dll.utilites
{
    partial class fChooserUnit
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView_main = new System.Windows.Forms.DataGridView();
            this.label_path = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_select = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_main)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView_main);
            this.groupBox1.Controls.Add(this.label_path);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(401, 455);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Данные";
            // 
            // dataGridView_main
            // 
            this.dataGridView_main.AllowUserToAddRows = false;
            this.dataGridView_main.AllowUserToDeleteRows = false;
            this.dataGridView_main.AllowUserToResizeRows = false;
            this.dataGridView_main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_main.Location = new System.Drawing.Point(3, 33);
            this.dataGridView_main.MultiSelect = false;
            this.dataGridView_main.Name = "dataGridView_main";
            this.dataGridView_main.ReadOnly = true;
            this.dataGridView_main.RowHeadersVisible = false;
            this.dataGridView_main.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_main.Size = new System.Drawing.Size(395, 419);
            this.dataGridView_main.TabIndex = 0;
            this.dataGridView_main.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView_main_KeyDown);
            this.dataGridView_main.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dataGridView_main_MouseDoubleClick);
            // 
            // label_path
            // 
            this.label_path.AutoSize = true;
            this.label_path.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_path.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_path.Location = new System.Drawing.Point(3, 16);
            this.label_path.Name = "label_path";
            this.label_path.Padding = new System.Windows.Forms.Padding(2);
            this.label_path.Size = new System.Drawing.Size(4, 17);
            this.label_path.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_select);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 455);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(401, 32);
            this.panel1.TabIndex = 3;
            // 
            // button_select
            // 
            this.button_select.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_select.Location = new System.Drawing.Point(0, 0);
            this.button_select.Name = "button_select";
            this.button_select.Size = new System.Drawing.Size(401, 32);
            this.button_select.TabIndex = 0;
            this.button_select.Text = "Выбрать";
            this.button_select.UseVisualStyleBackColor = true;
            this.button_select.Click += new System.EventHandler(this.button_select_Click);
            // 
            // fChooserUnit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(401, 487);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "fChooserUnit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "fChooserUnit";
            this.Shown += new System.EventHandler(this.fChooserUnit_Shown);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_main)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.DataGridView dataGridView_main;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_select;
        private System.Windows.Forms.Label label_path;
    }
}