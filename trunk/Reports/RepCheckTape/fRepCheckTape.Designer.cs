namespace com.sbs.gui.report.repchecktape
{
    partial class fRepCheckTape
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
            this.dateTimePicker_dateEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker_dateStart = new System.Windows.Forms.DateTimePicker();
            this.panel8 = new System.Windows.Forms.Panel();
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_ok = new System.Windows.Forms.Button();
            this.textBox_branchsNames = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button_branch = new System.Windows.Forms.Button();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // dateTimePicker_dateEnd
            // 
            this.dateTimePicker_dateEnd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker_dateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_dateEnd.Location = new System.Drawing.Point(95, 36);
            this.dateTimePicker_dateEnd.Name = "dateTimePicker_dateEnd";
            this.dateTimePicker_dateEnd.Size = new System.Drawing.Size(250, 20);
            this.dateTimePicker_dateEnd.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Начало периода";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Конец периода";
            // 
            // dateTimePicker_dateStart
            // 
            this.dateTimePicker_dateStart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimePicker_dateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_dateStart.Location = new System.Drawing.Point(95, 12);
            this.dateTimePicker_dateStart.Name = "dateTimePicker_dateStart";
            this.dateTimePicker_dateStart.Size = new System.Drawing.Size(250, 20);
            this.dateTimePicker_dateStart.TabIndex = 0;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.button_cancel);
            this.panel8.Controls.Add(this.button_ok);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel8.Location = new System.Drawing.Point(0, 101);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(358, 35);
            this.panel8.TabIndex = 3;
            // 
            // button_cancel
            // 
            this.button_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_cancel.Location = new System.Drawing.Point(262, 6);
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
            this.button_ok.Location = new System.Drawing.Point(181, 6);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 0;
            this.button_ok.Text = "Ок";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // textBox_branchsNames
            // 
            this.textBox_branchsNames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_branchsNames.Location = new System.Drawing.Point(95, 63);
            this.textBox_branchsNames.Name = "textBox_branchsNames";
            this.textBox_branchsNames.ReadOnly = true;
            this.textBox_branchsNames.Size = new System.Drawing.Size(221, 20);
            this.textBox_branchsNames.TabIndex = 2;
            this.textBox_branchsNames.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 66);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 13);
            this.label3.TabIndex = 50;
            this.label3.Text = "Заведение";
            // 
            // button_branch
            // 
            this.button_branch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_branch.Location = new System.Drawing.Point(321, 62);
            this.button_branch.Name = "button_branch";
            this.button_branch.Size = new System.Drawing.Size(24, 23);
            this.button_branch.TabIndex = 2;
            this.button_branch.Text = "...";
            this.button_branch.UseVisualStyleBackColor = true;
            this.button_branch.Click += new System.EventHandler(this.button_branch_Click);
            // 
            // fRepCheckTape
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(358, 136);
            this.Controls.Add(this.button_branch);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox_branchsNames);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.dateTimePicker_dateStart);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker_dateEnd);
            this.Name = "fRepCheckTape";
            this.Text = "Чековая лента";
            this.Shown += new System.EventHandler(this.fRepCheckTape_Shown);
            this.panel8.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker_dateEnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker_dateStart;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.TextBox textBox_branchsNames;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_branch;
    }
}

