namespace com.sbs.gui.prepack
{
    partial class fAddPrepack
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
            this.dataGridView_prepack = new System.Windows.Forms.DataGridView();
            this.groupBox_goods = new System.Windows.Forms.GroupBox();
            this.button_ok = new System.Windows.Forms.Button();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_prepack)).BeginInit();
            this.groupBox_goods.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView_prepack
            // 
            this.dataGridView_prepack.AllowUserToAddRows = false;
            this.dataGridView_prepack.AllowUserToDeleteRows = false;
            this.dataGridView_prepack.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_prepack.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.code,
            this.name});
            this.dataGridView_prepack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_prepack.Location = new System.Drawing.Point(3, 16);
            this.dataGridView_prepack.Name = "dataGridView_prepack";
            this.dataGridView_prepack.ReadOnly = true;
            this.dataGridView_prepack.RowHeadersVisible = false;
            this.dataGridView_prepack.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_prepack.Size = new System.Drawing.Size(278, 275);
            this.dataGridView_prepack.TabIndex = 0;
            // 
            // groupBox_goods
            // 
            this.groupBox_goods.Controls.Add(this.dataGridView_prepack);
            this.groupBox_goods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_goods.Location = new System.Drawing.Point(0, 0);
            this.groupBox_goods.Name = "groupBox_goods";
            this.groupBox_goods.Size = new System.Drawing.Size(284, 294);
            this.groupBox_goods.TabIndex = 2;
            this.groupBox_goods.TabStop = false;
            this.groupBox_goods.Text = "Полуфабрикаты";
            // 
            // button_ok
            // 
            this.button_ok.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button_ok.Location = new System.Drawing.Point(0, 294);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(284, 23);
            this.button_ok.TabIndex = 3;
            this.button_ok.Text = "Выбрать";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // id
            // 
            this.id.HeaderText = "prepack_id";
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
            // fAddPrepack
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 317);
            this.Controls.Add(this.groupBox_goods);
            this.Controls.Add(this.button_ok);
            this.Name = "fAddPrepack";
            this.Text = "Выбор полуфабриката";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_prepack)).EndInit();
            this.groupBox_goods.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_prepack;
        private System.Windows.Forms.GroupBox groupBox_goods;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
    }
}