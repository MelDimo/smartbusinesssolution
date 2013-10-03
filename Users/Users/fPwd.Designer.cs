namespace com.sbs.gui.users
{
    partial class fPwd
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
            this.tabControl_main = new System.Windows.Forms.TabControl();
            this.tabPage_password = new System.Windows.Forms.TabPage();
            this.checkBox_showPwd = new System.Windows.Forms.CheckBox();
            this.textBox_pwd = new System.Windows.Forms.TextBox();
            this.tabPage_bracelet = new System.Windows.Forms.TabPage();
            this.button_refresh = new System.Windows.Forms.Button();
            this.comboBox_listReaders = new System.Windows.Forms.ComboBox();
            this.label_readerName = new System.Windows.Forms.Label();
            this.textBox_cardID = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label_fio = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.tabControl_main.SuspendLayout();
            this.tabPage_password.SuspendLayout();
            this.tabPage_bracelet.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_cancel);
            this.panel1.Controls.Add(this.button_ok);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 170);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(407, 35);
            this.panel1.TabIndex = 1;
            // 
            // button_cancel
            // 
            this.button_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_cancel.Location = new System.Drawing.Point(309, 7);
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
            this.button_ok.Location = new System.Drawing.Point(228, 7);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 0;
            this.button_ok.Text = "Ок";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // tabControl_main
            // 
            this.tabControl_main.Controls.Add(this.tabPage_password);
            this.tabControl_main.Controls.Add(this.tabPage_bracelet);
            this.tabControl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_main.Location = new System.Drawing.Point(3, 16);
            this.tabControl_main.Name = "tabControl_main";
            this.tabControl_main.SelectedIndex = 0;
            this.tabControl_main.Size = new System.Drawing.Size(401, 92);
            this.tabControl_main.TabIndex = 2;
            this.tabControl_main.SelectedIndexChanged += new System.EventHandler(this.tabControl_main_SelectedIndexChanged);
            // 
            // tabPage_password
            // 
            this.tabPage_password.Controls.Add(this.checkBox_showPwd);
            this.tabPage_password.Controls.Add(this.textBox_pwd);
            this.tabPage_password.Location = new System.Drawing.Point(4, 22);
            this.tabPage_password.Name = "tabPage_password";
            this.tabPage_password.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_password.Size = new System.Drawing.Size(393, 66);
            this.tabPage_password.TabIndex = 0;
            this.tabPage_password.Text = "Пароль";
            this.tabPage_password.UseVisualStyleBackColor = true;
            // 
            // checkBox_showPwd
            // 
            this.checkBox_showPwd.AutoSize = true;
            this.checkBox_showPwd.Location = new System.Drawing.Point(6, 32);
            this.checkBox_showPwd.Name = "checkBox_showPwd";
            this.checkBox_showPwd.Size = new System.Drawing.Size(125, 17);
            this.checkBox_showPwd.TabIndex = 1;
            this.checkBox_showPwd.Text = "Отобразить пороль";
            this.checkBox_showPwd.UseVisualStyleBackColor = true;
            this.checkBox_showPwd.CheckedChanged += new System.EventHandler(this.checkBox_showPwd_CheckedChanged);
            // 
            // textBox_pwd
            // 
            this.textBox_pwd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_pwd.Location = new System.Drawing.Point(6, 6);
            this.textBox_pwd.Name = "textBox_pwd";
            this.textBox_pwd.Size = new System.Drawing.Size(382, 20);
            this.textBox_pwd.TabIndex = 0;
            this.textBox_pwd.UseSystemPasswordChar = true;
            // 
            // tabPage_bracelet
            // 
            this.tabPage_bracelet.Controls.Add(this.button_refresh);
            this.tabPage_bracelet.Controls.Add(this.comboBox_listReaders);
            this.tabPage_bracelet.Controls.Add(this.label_readerName);
            this.tabPage_bracelet.Controls.Add(this.textBox_cardID);
            this.tabPage_bracelet.Location = new System.Drawing.Point(4, 22);
            this.tabPage_bracelet.Name = "tabPage_bracelet";
            this.tabPage_bracelet.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_bracelet.Size = new System.Drawing.Size(393, 66);
            this.tabPage_bracelet.TabIndex = 1;
            this.tabPage_bracelet.Text = "Браслет";
            this.tabPage_bracelet.UseVisualStyleBackColor = true;
            // 
            // button_refresh
            // 
            this.button_refresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_refresh.Location = new System.Drawing.Point(352, 29);
            this.button_refresh.Name = "button_refresh";
            this.button_refresh.Size = new System.Drawing.Size(26, 26);
            this.button_refresh.TabIndex = 3;
            this.button_refresh.UseVisualStyleBackColor = true;
            this.button_refresh.Click += new System.EventHandler(this.button_refresh_Click);
            // 
            // comboBox_listReaders
            // 
            this.comboBox_listReaders.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_listReaders.FormattingEnabled = true;
            this.comboBox_listReaders.Location = new System.Drawing.Point(163, 32);
            this.comboBox_listReaders.Name = "comboBox_listReaders";
            this.comboBox_listReaders.Size = new System.Drawing.Size(183, 21);
            this.comboBox_listReaders.TabIndex = 2;
            // 
            // label_readerName
            // 
            this.label_readerName.AutoSize = true;
            this.label_readerName.Location = new System.Drawing.Point(3, 35);
            this.label_readerName.Name = "label_readerName";
            this.label_readerName.Size = new System.Drawing.Size(162, 13);
            this.label_readerName.TabIndex = 1;
            this.label_readerName.Text = "Используемое оборудование: ";
            // 
            // textBox_cardID
            // 
            this.textBox_cardID.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_cardID.Location = new System.Drawing.Point(6, 6);
            this.textBox_cardID.Name = "textBox_cardID";
            this.textBox_cardID.Size = new System.Drawing.Size(382, 20);
            this.textBox_cardID.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl_main);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(407, 111);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Авторизация";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label_fio, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(407, 56);
            this.tableLayoutPanel1.TabIndex = 4;
            // 
            // label_fio
            // 
            this.label_fio.AutoSize = true;
            this.label_fio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_fio.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_fio.Location = new System.Drawing.Point(3, 0);
            this.label_fio.Name = "label_fio";
            this.label_fio.Size = new System.Drawing.Size(401, 56);
            this.label_fio.TabIndex = 0;
            this.label_fio.Text = "label_fio";
            this.label_fio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // fPwd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 208);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.MinimumSize = new System.Drawing.Size(429, 246);
            this.Name = "fPwd";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.Text = "Аторизация";
            this.panel1.ResumeLayout(false);
            this.tabControl_main.ResumeLayout(false);
            this.tabPage_password.ResumeLayout(false);
            this.tabPage_password.PerformLayout();
            this.tabPage_bracelet.ResumeLayout(false);
            this.tabPage_bracelet.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.TabControl tabControl_main;
        private System.Windows.Forms.TabPage tabPage_password;
        private System.Windows.Forms.TabPage tabPage_bracelet;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox_pwd;
        private System.Windows.Forms.TextBox textBox_cardID;
        private System.Windows.Forms.Label label_readerName;
        private System.Windows.Forms.ComboBox comboBox_listReaders;
        private System.Windows.Forms.Button button_refresh;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox checkBox_showPwd;
        public System.Windows.Forms.Label label_fio;
    }
}