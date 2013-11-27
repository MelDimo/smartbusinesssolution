namespace com.sbs.gui.docsform
{
    partial class fSupplyTMC_DOC_COST
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox_costAcc = new System.Windows.Forms.TextBox();
            this.button_getCostAcc = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button_getCostContractor = new System.Windows.Forms.Button();
            this.textBox_costContractor = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.button_Ok = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.button_getCostType = new System.Windows.Forms.Button();
            this.textBox_costType = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Вид";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 32);
            this.label2.TabIndex = 2;
            this.label2.Text = "Счет";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_getCostAcc);
            this.panel1.Controls.Add(this.textBox_costAcc);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(79, 34);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(395, 26);
            this.panel1.TabIndex = 1;
            // 
            // textBox_costAcc
            // 
            this.textBox_costAcc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_costAcc.Location = new System.Drawing.Point(3, 3);
            this.textBox_costAcc.Name = "textBox_costAcc";
            this.textBox_costAcc.ReadOnly = true;
            this.textBox_costAcc.Size = new System.Drawing.Size(353, 20);
            this.textBox_costAcc.TabIndex = 0;
            this.textBox_costAcc.TabStop = false;
            // 
            // button_getCostAcc
            // 
            this.button_getCostAcc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_getCostAcc.Location = new System.Drawing.Point(362, 1);
            this.button_getCostAcc.Name = "button_getCostAcc";
            this.button_getCostAcc.Size = new System.Drawing.Size(30, 23);
            this.button_getCostAcc.TabIndex = 0;
            this.button_getCostAcc.Text = "...";
            this.button_getCostAcc.UseVisualStyleBackColor = true;
            this.button_getCostAcc.Click += new System.EventHandler(this.button_getCostAcc_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 76F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel5, 1, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(477, 133);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 31);
            this.label3.TabIndex = 4;
            this.label3.Text = "Контрагент";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button_getCostContractor);
            this.panel2.Controls.Add(this.textBox_costContractor);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(79, 66);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(395, 25);
            this.panel2.TabIndex = 2;
            // 
            // button_getCostContractor
            // 
            this.button_getCostContractor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_getCostContractor.Location = new System.Drawing.Point(362, 1);
            this.button_getCostContractor.Name = "button_getCostContractor";
            this.button_getCostContractor.Size = new System.Drawing.Size(30, 23);
            this.button_getCostContractor.TabIndex = 0;
            this.button_getCostContractor.Text = "...";
            this.button_getCostContractor.UseVisualStyleBackColor = true;
            this.button_getCostContractor.Click += new System.EventHandler(this.button_getCostContractor_Click);
            // 
            // textBox_costContractor
            // 
            this.textBox_costContractor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_costContractor.Location = new System.Drawing.Point(3, 3);
            this.textBox_costContractor.Name = "textBox_costContractor";
            this.textBox_costContractor.ReadOnly = true;
            this.textBox_costContractor.Size = new System.Drawing.Size(353, 20);
            this.textBox_costContractor.TabIndex = 0;
            this.textBox_costContractor.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.button_Ok);
            this.panel4.Controls.Add(this.button_cancel);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 175);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(501, 38);
            this.panel4.TabIndex = 1;
            // 
            // button_Ok
            // 
            this.button_Ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_Ok.Location = new System.Drawing.Point(340, 8);
            this.button_Ok.Name = "button_Ok";
            this.button_Ok.Size = new System.Drawing.Size(75, 23);
            this.button_Ok.TabIndex = 0;
            this.button_Ok.Text = "Сохранить";
            this.button_Ok.UseVisualStyleBackColor = true;
            // 
            // button_cancel
            // 
            this.button_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_cancel.Location = new System.Drawing.Point(421, 8);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 1;
            this.button_cancel.Text = "Отмена";
            this.button_cancel.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button_getCostType);
            this.panel3.Controls.Add(this.textBox_costType);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(79, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(395, 25);
            this.panel3.TabIndex = 0;
            // 
            // button_getCostType
            // 
            this.button_getCostType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_getCostType.Location = new System.Drawing.Point(362, 1);
            this.button_getCostType.Name = "button_getCostType";
            this.button_getCostType.Size = new System.Drawing.Size(30, 23);
            this.button_getCostType.TabIndex = 0;
            this.button_getCostType.Text = "...";
            this.button_getCostType.UseVisualStyleBackColor = true;
            this.button_getCostType.Click += new System.EventHandler(this.button_getCostType_Click);
            // 
            // textBox_costType
            // 
            this.textBox_costType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_costType.Location = new System.Drawing.Point(3, 3);
            this.textBox_costType.Name = "textBox_costType";
            this.textBox_costType.ReadOnly = true;
            this.textBox_costType.Size = new System.Drawing.Size(353, 20);
            this.textBox_costType.TabIndex = 0;
            this.textBox_costType.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 39);
            this.label4.TabIndex = 5;
            this.label4.Text = "Валюта";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel5
            // 
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(79, 97);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(395, 33);
            this.panel5.TabIndex = 6;
            // 
            // fSupplyTMC_DOC_COST
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(501, 213);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(517, 187);
            this.Name = "fSupplyTMC_DOC_COST";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "fSupplyTMC_DOC_COST";
            this.Shown += new System.EventHandler(this.fSupplyTMC_DOC_COST_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_getCostAcc;
        private System.Windows.Forms.TextBox textBox_costAcc;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button_getCostContractor;
        private System.Windows.Forms.TextBox textBox_costContractor;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button button_Ok;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button_getCostType;
        private System.Windows.Forms.TextBox textBox_costType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel5;
    }
}