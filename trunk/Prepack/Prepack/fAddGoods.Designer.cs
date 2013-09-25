namespace com.sbs.gui.prepack
{
    partial class fAddGoods
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
            this.groupBox_goods = new System.Windows.Forms.GroupBox();
            this.dataGridView_goods = new System.Windows.Forms.DataGridView();
            this.button_ok = new System.Windows.Forms.Button();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.code = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.manufacturer = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox_goods.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_goods)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox_goods
            // 
            this.groupBox_goods.Controls.Add(this.dataGridView_goods);
            this.groupBox_goods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_goods.Location = new System.Drawing.Point(2, 2);
            this.groupBox_goods.Name = "groupBox_goods";
            this.groupBox_goods.Size = new System.Drawing.Size(323, 308);
            this.groupBox_goods.TabIndex = 0;
            this.groupBox_goods.TabStop = false;
            this.groupBox_goods.Text = "Продукты";
            // 
            // dataGridView_goods
            // 
            this.dataGridView_goods.AllowUserToAddRows = false;
            this.dataGridView_goods.AllowUserToDeleteRows = false;
            this.dataGridView_goods.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_goods.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.code,
            this.name,
            this.manufacturer});
            this.dataGridView_goods.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_goods.Location = new System.Drawing.Point(3, 16);
            this.dataGridView_goods.Name = "dataGridView_goods";
            this.dataGridView_goods.ReadOnly = true;
            this.dataGridView_goods.RowHeadersVisible = false;
            this.dataGridView_goods.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_goods.Size = new System.Drawing.Size(317, 289);
            this.dataGridView_goods.TabIndex = 0;
            // 
            // button_ok
            // 
            this.button_ok.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button_ok.Location = new System.Drawing.Point(2, 310);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(323, 23);
            this.button_ok.TabIndex = 1;
            this.button_ok.Text = "Выбрать";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // id
            // 
            this.id.HeaderText = "goods_id";
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
            // manufacturer
            // 
            this.manufacturer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.manufacturer.HeaderText = "Производитель";
            this.manufacturer.Name = "manufacturer";
            this.manufacturer.ReadOnly = true;
            this.manufacturer.Width = 111;
            // 
            // fAddGoods
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 335);
            this.Controls.Add(this.groupBox_goods);
            this.Controls.Add(this.button_ok);
            this.MinimizeBox = false;
            this.Name = "fAddGoods";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Выбор продукта";
            this.groupBox_goods.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_goods)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_goods;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.DataGridView dataGridView_goods;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn code;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn manufacturer;
    }
}