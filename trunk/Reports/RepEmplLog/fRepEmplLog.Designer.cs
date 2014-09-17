namespace com.sbs.gui.report.repempllog
{
    partial class fRepEmplLog
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.button_getEmpl = new System.Windows.Forms.Button();
            this.textBox_users = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button_getGroup = new System.Windows.Forms.Button();
            this.textBox_usersGroups = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dateTimePicker_start = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_end = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_getBranch = new System.Windows.Forms.Button();
            this.textBox_branchsNames = new System.Windows.Forms.TextBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_ok = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel8.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 126F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dateTimePicker_start, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.dateTimePicker_end, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(3);
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(439, 157);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.button_getEmpl);
            this.panel3.Controls.Add(this.textBox_users);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(132, 123);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(301, 28);
            this.panel3.TabIndex = 10;
            // 
            // button_getEmpl
            // 
            this.button_getEmpl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_getEmpl.Location = new System.Drawing.Point(267, 2);
            this.button_getEmpl.Name = "button_getEmpl";
            this.button_getEmpl.Size = new System.Drawing.Size(30, 23);
            this.button_getEmpl.TabIndex = 1;
            this.button_getEmpl.Text = "...";
            this.button_getEmpl.UseVisualStyleBackColor = true;
            this.button_getEmpl.Click += new System.EventHandler(this.button_getEmpl_Click);
            // 
            // textBox_users
            // 
            this.textBox_users.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_users.Location = new System.Drawing.Point(4, 4);
            this.textBox_users.Name = "textBox_users";
            this.textBox_users.ReadOnly = true;
            this.textBox_users.Size = new System.Drawing.Size(257, 20);
            this.textBox_users.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button_getGroup);
            this.panel2.Controls.Add(this.textBox_usersGroups);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(132, 90);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(301, 27);
            this.panel2.TabIndex = 9;
            // 
            // button_getGroup
            // 
            this.button_getGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_getGroup.Location = new System.Drawing.Point(267, 2);
            this.button_getGroup.Name = "button_getGroup";
            this.button_getGroup.Size = new System.Drawing.Size(31, 23);
            this.button_getGroup.TabIndex = 1;
            this.button_getGroup.Text = "...";
            this.button_getGroup.UseVisualStyleBackColor = true;
            this.button_getGroup.Click += new System.EventHandler(this.button_getGroup_Click);
            // 
            // textBox_usersGroups
            // 
            this.textBox_usersGroups.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_usersGroups.Location = new System.Drawing.Point(4, 4);
            this.textBox_usersGroups.Name = "textBox_usersGroups";
            this.textBox_usersGroups.ReadOnly = true;
            this.textBox_usersGroups.Size = new System.Drawing.Size(257, 20);
            this.textBox_usersGroups.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Начало периода";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dateTimePicker_start
            // 
            this.dateTimePicker_start.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimePicker_start.Location = new System.Drawing.Point(132, 6);
            this.dateTimePicker_start.Name = "dateTimePicker_start";
            this.dateTimePicker_start.Size = new System.Drawing.Size(301, 20);
            this.dateTimePicker_start.TabIndex = 2;
            // 
            // dateTimePicker_end
            // 
            this.dateTimePicker_end.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimePicker_end.Location = new System.Drawing.Point(132, 32);
            this.dateTimePicker_end.Name = "dateTimePicker_end";
            this.dateTimePicker_end.Size = new System.Drawing.Size(301, 20);
            this.dateTimePicker_end.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(6, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Конец периода";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(6, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 33);
            this.label3.TabIndex = 4;
            this.label3.Text = "Заведение";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(6, 87);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 33);
            this.label4.TabIndex = 5;
            this.label4.Text = "Группы сотрудников";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(6, 120);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(120, 34);
            this.label5.TabIndex = 6;
            this.label5.Text = "Сотрудники";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_getBranch);
            this.panel1.Controls.Add(this.textBox_branchsNames);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(132, 57);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(301, 27);
            this.panel1.TabIndex = 8;
            // 
            // button_getBranch
            // 
            this.button_getBranch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_getBranch.Location = new System.Drawing.Point(267, 2);
            this.button_getBranch.Name = "button_getBranch";
            this.button_getBranch.Size = new System.Drawing.Size(30, 23);
            this.button_getBranch.TabIndex = 1;
            this.button_getBranch.Text = "...";
            this.button_getBranch.UseVisualStyleBackColor = true;
            this.button_getBranch.Click += new System.EventHandler(this.button_getBranch_Click);
            // 
            // textBox_branchsNames
            // 
            this.textBox_branchsNames.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_branchsNames.Location = new System.Drawing.Point(4, 4);
            this.textBox_branchsNames.Name = "textBox_branchsNames";
            this.textBox_branchsNames.ReadOnly = true;
            this.textBox_branchsNames.Size = new System.Drawing.Size(257, 20);
            this.textBox_branchsNames.TabIndex = 0;
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel8.Controls.Add(this.button_cancel);
            this.panel8.Controls.Add(this.button_ok);
            this.panel8.Location = new System.Drawing.Point(0, 160);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(439, 35);
            this.panel8.TabIndex = 49;
            // 
            // button_cancel
            // 
            this.button_cancel.Location = new System.Drawing.Point(343, 6);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 1;
            this.button_cancel.Text = "Отмена";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // button_ok
            // 
            this.button_ok.Location = new System.Drawing.Point(262, 6);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 0;
            this.button_ok.Text = "Ок";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // fRepEmplLog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(439, 195);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel8);
            this.MinimumSize = new System.Drawing.Size(455, 233);
            this.Name = "fRepEmplLog";
            this.Text = "Журнал регистрации сотрудников";
            this.Shown += new System.EventHandler(this.fRepEmplLog_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker_start;
        private System.Windows.Forms.DateTimePicker dateTimePicker_end;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button button_getEmpl;
        private System.Windows.Forms.TextBox textBox_users;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button_getGroup;
        private System.Windows.Forms.TextBox textBox_usersGroups;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_getBranch;
        private System.Windows.Forms.TextBox textBox_branchsNames;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Button button_ok;
    }
}

