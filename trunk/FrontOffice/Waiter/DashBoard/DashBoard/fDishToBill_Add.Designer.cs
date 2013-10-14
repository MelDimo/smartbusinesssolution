namespace com.sbs.gui.DashBoard
{
    partial class fDishToBill_Add
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label_dishName = new System.Windows.Forms.Label();
            this.textBox_price = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_count = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.Controls.Add(this.label_dishName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_price, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_count, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(604, 41);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label_dishName
            // 
            this.label_dishName.AutoSize = true;
            this.label_dishName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_dishName.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_dishName.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label_dishName.Location = new System.Drawing.Point(3, 15);
            this.label_dishName.Name = "label_dishName";
            this.label_dishName.Size = new System.Drawing.Size(458, 26);
            this.label_dishName.TabIndex = 0;
            this.label_dishName.Text = "label_dishName";
            this.label_dishName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_price
            // 
            this.textBox_price.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_price.Location = new System.Drawing.Point(467, 18);
            this.textBox_price.Name = "textBox_price";
            this.textBox_price.ReadOnly = true;
            this.textBox_price.Size = new System.Drawing.Size(64, 20);
            this.textBox_price.TabIndex = 5;
            this.textBox_price.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(537, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Кол-во";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_count
            // 
            this.textBox_count.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_count.Location = new System.Drawing.Point(537, 18);
            this.textBox_count.Name = "textBox_count";
            this.textBox_count.Size = new System.Drawing.Size(64, 20);
            this.textBox_count.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(467, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Цена";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // fDishToBill_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 41);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel1);
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(620, 79);
            this.MinimumSize = new System.Drawing.Size(620, 79);
            this.Name = "fDishToBill_Add";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Добавить к заказу";
            this.TopMost = true;
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fDishToBill_Add_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        internal System.Windows.Forms.Label label_dishName;
        internal System.Windows.Forms.TextBox textBox_price;
        internal System.Windows.Forms.TextBox textBox_count;

    }
}