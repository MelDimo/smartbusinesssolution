namespace com.sbs.gui.users
{
    partial class fAddEditUsers
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_ok = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tabControl_main = new System.Windows.Forms.TabControl();
            this.tabPage_official = new System.Windows.Forms.TabPage();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.dateTimePicker_bdate = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_tabn = new System.Windows.Forms.TextBox();
            this.button_nextTabN = new System.Windows.Forms.Button();
            this.pictureBox_users = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.comboBox_branch = new System.Windows.Forms.ComboBox();
            this.comboBox_unit = new System.Windows.Forms.ComboBox();
            this.comboBox_post = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBox_org = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_sname = new System.Windows.Forms.TextBox();
            this.textBox_lname = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_fname = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_status = new System.Windows.Forms.ComboBox();
            this.tabPage_private = new System.Windows.Forms.TabPage();
            this.panel1.SuspendLayout();
            this.tabControl_main.SuspendLayout();
            this.tabPage_official.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_users)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_cancel);
            this.panel1.Controls.Add(this.button_ok);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 316);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(683, 35);
            this.panel1.TabIndex = 0;
            // 
            // button_cancel
            // 
            this.button_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_cancel.Location = new System.Drawing.Point(585, 7);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 2;
            this.button_cancel.Text = "Отмена";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // button_ok
            // 
            this.button_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ok.Location = new System.Drawing.Point(504, 7);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 0;
            this.button_ok.Text = "Ок";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 351);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(683, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tabControl_main
            // 
            this.tabControl_main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl_main.Controls.Add(this.tabPage_official);
            this.tabControl_main.Controls.Add(this.tabPage_private);
            this.tabControl_main.Location = new System.Drawing.Point(0, 0);
            this.tabControl_main.Name = "tabControl_main";
            this.tabControl_main.SelectedIndex = 0;
            this.tabControl_main.Size = new System.Drawing.Size(683, 316);
            this.tabControl_main.TabIndex = 2;
            // 
            // tabPage_official
            // 
            this.tabPage_official.Controls.Add(this.panel2);
            this.tabPage_official.Location = new System.Drawing.Point(4, 22);
            this.tabPage_official.Name = "tabPage_official";
            this.tabPage_official.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_official.Size = new System.Drawing.Size(675, 290);
            this.tabPage_official.TabIndex = 0;
            this.tabPage_official.Text = "Служебная информация";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tableLayoutPanel4);
            this.panel2.Controls.Add(this.pictureBox_users);
            this.panel2.Controls.Add(this.tableLayoutPanel2);
            this.panel2.Controls.Add(this.tableLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(669, 170);
            this.panel2.TabIndex = 9;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 5;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 95F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.label10, 3, 0);
            this.tableLayoutPanel4.Controls.Add(this.dateTimePicker_bdate, 4, 0);
            this.tableLayoutPanel4.Controls.Add(this.label8, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.textBox_tabn, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.button_nextTabN, 2, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(0, 119);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(511, 25);
            this.tableLayoutPanel4.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label10.Location = new System.Drawing.Point(281, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(89, 25);
            this.label10.TabIndex = 0;
            this.label10.Text = "Дата рождения";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dateTimePicker_bdate
            // 
            this.dateTimePicker_bdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_bdate.Location = new System.Drawing.Point(376, 3);
            this.dateTimePicker_bdate.Name = "dateTimePicker_bdate";
            this.dateTimePicker_bdate.Size = new System.Drawing.Size(99, 20);
            this.dateTimePicker_bdate.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(3, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(104, 25);
            this.label8.TabIndex = 2;
            this.label8.Text = "Табельный номер";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_tabn
            // 
            this.textBox_tabn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_tabn.Location = new System.Drawing.Point(113, 3);
            this.textBox_tabn.Name = "textBox_tabn";
            this.textBox_tabn.Size = new System.Drawing.Size(132, 20);
            this.textBox_tabn.TabIndex = 3;
            // 
            // button_nextTabN
            // 
            this.button_nextTabN.Location = new System.Drawing.Point(251, 3);
            this.button_nextTabN.Name = "button_nextTabN";
            this.button_nextTabN.Size = new System.Drawing.Size(24, 19);
            this.button_nextTabN.TabIndex = 4;
            this.button_nextTabN.Text = "->";
            this.button_nextTabN.UseVisualStyleBackColor = true;
            // 
            // pictureBox_users
            // 
            this.pictureBox_users.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_users.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_users.Location = new System.Drawing.Point(517, 0);
            this.pictureBox_users.Name = "pictureBox_users";
            this.pictureBox_users.Size = new System.Drawing.Size(152, 161);
            this.pictureBox_users.TabIndex = 8;
            this.pictureBox_users.TabStop = false;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Controls.Add(this.label5, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label6, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label7, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.comboBox_branch, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.comboBox_unit, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.comboBox_post, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.label11, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.comboBox_org, 0, 1);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 56);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(511, 57);
            this.tableLayoutPanel2.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(130, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 28);
            this.label5.TabIndex = 0;
            this.label5.Text = "Заведение";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(257, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(121, 28);
            this.label6.TabIndex = 1;
            this.label6.Text = "Подразделение";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(384, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 28);
            this.label7.TabIndex = 2;
            this.label7.Text = "Должность";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox_branch
            // 
            this.comboBox_branch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_branch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_branch.FormattingEnabled = true;
            this.comboBox_branch.Location = new System.Drawing.Point(130, 31);
            this.comboBox_branch.Name = "comboBox_branch";
            this.comboBox_branch.Size = new System.Drawing.Size(121, 21);
            this.comboBox_branch.TabIndex = 3;
            // 
            // comboBox_unit
            // 
            this.comboBox_unit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_unit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_unit.FormattingEnabled = true;
            this.comboBox_unit.Location = new System.Drawing.Point(257, 31);
            this.comboBox_unit.Name = "comboBox_unit";
            this.comboBox_unit.Size = new System.Drawing.Size(121, 21);
            this.comboBox_unit.TabIndex = 4;
            // 
            // comboBox_post
            // 
            this.comboBox_post.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_post.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_post.FormattingEnabled = true;
            this.comboBox_post.Location = new System.Drawing.Point(384, 31);
            this.comboBox_post.Name = "comboBox_post";
            this.comboBox_post.Size = new System.Drawing.Size(124, 21);
            this.comboBox_post.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label11.Location = new System.Drawing.Point(3, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(121, 28);
            this.label11.TabIndex = 6;
            this.label11.Text = "Организация";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox_org
            // 
            this.comboBox_org.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_org.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_org.FormattingEnabled = true;
            this.comboBox_org.Location = new System.Drawing.Point(3, 31);
            this.comboBox_org.Name = "comboBox_org";
            this.comboBox_org.Size = new System.Drawing.Size(121, 21);
            this.comboBox_org.TabIndex = 7;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_sname, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_lname, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_fname, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBox_status, 3, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(511, 54);
            this.tableLayoutPanel1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 27);
            this.label1.TabIndex = 0;
            this.label1.Text = "Фамилия";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_sname
            // 
            this.textBox_sname.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_sname.Location = new System.Drawing.Point(257, 30);
            this.textBox_sname.Name = "textBox_sname";
            this.textBox_sname.Size = new System.Drawing.Size(121, 20);
            this.textBox_sname.TabIndex = 5;
            // 
            // textBox_lname
            // 
            this.textBox_lname.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_lname.Location = new System.Drawing.Point(3, 30);
            this.textBox_lname.Name = "textBox_lname";
            this.textBox_lname.Size = new System.Drawing.Size(121, 20);
            this.textBox_lname.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(257, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 27);
            this.label3.TabIndex = 2;
            this.label3.Text = "Отчество";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_fname
            // 
            this.textBox_fname.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_fname.Location = new System.Drawing.Point(130, 30);
            this.textBox_fname.Name = "textBox_fname";
            this.textBox_fname.Size = new System.Drawing.Size(121, 20);
            this.textBox_fname.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(130, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 27);
            this.label2.TabIndex = 1;
            this.label2.Text = "Имя";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(384, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 27);
            this.label4.TabIndex = 6;
            this.label4.Text = "Статус";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox_status
            // 
            this.comboBox_status.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_status.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_status.FormattingEnabled = true;
            this.comboBox_status.Location = new System.Drawing.Point(384, 30);
            this.comboBox_status.Name = "comboBox_status";
            this.comboBox_status.Size = new System.Drawing.Size(124, 21);
            this.comboBox_status.TabIndex = 7;
            // 
            // tabPage_private
            // 
            this.tabPage_private.Location = new System.Drawing.Point(4, 22);
            this.tabPage_private.Name = "tabPage_private";
            this.tabPage_private.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_private.Size = new System.Drawing.Size(675, 290);
            this.tabPage_private.TabIndex = 1;
            this.tabPage_private.Text = "Личная информация";
            // 
            // fAddEditUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 373);
            this.Controls.Add(this.tabControl_main);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(699, 411);
            this.Name = "fAddEditUsers";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "fAddEditUsers";
            this.Shown += new System.EventHandler(this.fAddEditUsers_Shown);
            this.panel1.ResumeLayout(false);
            this.tabControl_main.ResumeLayout(false);
            this.tabPage_official.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_users)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TabControl tabControl_main;
        private System.Windows.Forms.TabPage tabPage_official;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabPage tabPage_private;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox textBox_sname;
        private System.Windows.Forms.TextBox textBox_fname;
        private System.Windows.Forms.TextBox textBox_lname;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_status;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox comboBox_branch;
        private System.Windows.Forms.ComboBox comboBox_unit;
        private System.Windows.Forms.ComboBox comboBox_post;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox_users;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dateTimePicker_bdate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBox_org;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_tabn;
        private System.Windows.Forms.Button button_nextTabN;
    }
}