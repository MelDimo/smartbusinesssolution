namespace com.sbs.gui.references.accounts
{
    partial class fAddEdit
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
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_I = new System.Windows.Forms.TextBox();
            this.textBox_I_I = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_ok = new System.Windows.Forms.Button();
            this.textBox_II = new System.Windows.Forms.TextBox();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_xvid = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBox_id = new System.Windows.Forms.TextBox();
            this.checkBox_kolvo = new System.Windows.Forms.CheckBox();
            this.checkBox_offbalance = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(156, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(299, 30);
            this.label3.TabIndex = 3;
            this.label3.Text = "Наименование";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_I
            // 
            this.textBox_I.Location = new System.Drawing.Point(3, 0);
            this.textBox_I.MaxLength = 2;
            this.textBox_I.Name = "textBox_I";
            this.textBox_I.Size = new System.Drawing.Size(36, 20);
            this.textBox_I.TabIndex = 0;
            // 
            // textBox_I_I
            // 
            this.textBox_I_I.Location = new System.Drawing.Point(45, 0);
            this.textBox_I_I.MaxLength = 1;
            this.textBox_I_I.Name = "textBox_I_I";
            this.textBox_I_I.Size = new System.Drawing.Size(27, 20);
            this.textBox_I_I.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(4, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Код 1-го порядка";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(86, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "Код 2-го порядка";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_cancel);
            this.panel1.Controls.Add(this.button_ok);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 134);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(606, 35);
            this.panel1.TabIndex = 3;
            // 
            // button_cancel
            // 
            this.button_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_cancel.Location = new System.Drawing.Point(510, 6);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 1;
            this.button_cancel.Text = "Отмена";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // button_ok
            // 
            this.button_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ok.Location = new System.Drawing.Point(429, 6);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 0;
            this.button_ok.Text = "Ок";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // textBox_II
            // 
            this.textBox_II.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_II.Location = new System.Drawing.Point(86, 35);
            this.textBox_II.MaxLength = 5;
            this.textBox_II.Name = "textBox_II";
            this.textBox_II.Size = new System.Drawing.Size(63, 20);
            this.textBox_II.TabIndex = 1;
            // 
            // textBox_name
            // 
            this.textBox_name.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_name.Location = new System.Drawing.Point(156, 35);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(299, 20);
            this.textBox_name.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 81F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 69F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 122F));
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_II, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_name, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBox_xvid, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 32);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(582, 62);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(462, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 30);
            this.label4.TabIndex = 6;
            this.label4.Text = "Вид счета";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox_xvid
            // 
            this.comboBox_xvid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_xvid.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_xvid.FormattingEnabled = true;
            this.comboBox_xvid.Items.AddRange(new object[] {
            "Активный",
            "Пассивный"});
            this.comboBox_xvid.Location = new System.Drawing.Point(462, 35);
            this.comboBox_xvid.Name = "comboBox_xvid";
            this.comboBox_xvid.Size = new System.Drawing.Size(116, 21);
            this.comboBox_xvid.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBox_I_I);
            this.panel2.Controls.Add(this.textBox_I);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(4, 35);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(75, 24);
            this.panel2.TabIndex = 0;
            // 
            // textBox_id
            // 
            this.textBox_id.Location = new System.Drawing.Point(12, 6);
            this.textBox_id.Name = "textBox_id";
            this.textBox_id.ReadOnly = true;
            this.textBox_id.Size = new System.Drawing.Size(100, 20);
            this.textBox_id.TabIndex = 10;
            this.textBox_id.TabStop = false;
            // 
            // checkBox_kolvo
            // 
            this.checkBox_kolvo.AutoSize = true;
            this.checkBox_kolvo.Location = new System.Drawing.Point(12, 106);
            this.checkBox_kolvo.Name = "checkBox_kolvo";
            this.checkBox_kolvo.Size = new System.Drawing.Size(85, 17);
            this.checkBox_kolvo.TabIndex = 0;
            this.checkBox_kolvo.Text = "Количество";
            this.checkBox_kolvo.UseVisualStyleBackColor = true;
            // 
            // checkBox_offbalance
            // 
            this.checkBox_offbalance.AutoSize = true;
            this.checkBox_offbalance.Location = new System.Drawing.Point(98, 106);
            this.checkBox_offbalance.Name = "checkBox_offbalance";
            this.checkBox_offbalance.Size = new System.Drawing.Size(101, 17);
            this.checkBox_offbalance.TabIndex = 1;
            this.checkBox_offbalance.Text = "Забалансовый";
            this.checkBox_offbalance.UseVisualStyleBackColor = true;
            // 
            // fAddEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 169);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.textBox_id);
            this.Controls.Add(this.checkBox_offbalance);
            this.Controls.Add(this.checkBox_kolvo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fAddEdit";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "fAddEdit";
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_I;
        private System.Windows.Forms.TextBox textBox_I_I;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.TextBox textBox_II;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox textBox_id;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_xvid;
        private System.Windows.Forms.CheckBox checkBox_kolvo;
        private System.Windows.Forms.CheckBox checkBox_offbalance;
        private System.Windows.Forms.Panel panel2;

    }
}