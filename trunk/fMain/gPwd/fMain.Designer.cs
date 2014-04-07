namespace com.sbs.gui.gPwd
{
    partial class fMain
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_localPWD = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_localUser = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_localDB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_localSQlServer = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_mainPWD = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_mainUser = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_mainDB = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_mainSQLServer = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_save = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox_key = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox_fileBD = new System.Windows.Forms.TextBox();
            this.button_browBD = new System.Windows.Forms.Button();
            this.button_executeDB = new System.Windows.Forms.Button();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button_browData = new System.Windows.Forms.Button();
            this.textBox_fileData = new System.Windows.Forms.TextBox();
            this.button_executeData = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.textBox_log = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.groupBox3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(454, 407);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox_localPWD);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox_localUser);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.textBox_localDB);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox_localSQlServer);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(448, 156);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Локальный сервер";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Пароль";
            // 
            // textBox_localPWD
            // 
            this.textBox_localPWD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_localPWD.Location = new System.Drawing.Point(95, 101);
            this.textBox_localPWD.Name = "textBox_localPWD";
            this.textBox_localPWD.Size = new System.Drawing.Size(344, 20);
            this.textBox_localPWD.TabIndex = 3;
            this.textBox_localPWD.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Пользователь";
            // 
            // textBox_localUser
            // 
            this.textBox_localUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_localUser.Location = new System.Drawing.Point(95, 75);
            this.textBox_localUser.Name = "textBox_localUser";
            this.textBox_localUser.Size = new System.Drawing.Size(344, 20);
            this.textBox_localUser.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "БД";
            // 
            // textBox_localDB
            // 
            this.textBox_localDB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_localDB.Location = new System.Drawing.Point(95, 49);
            this.textBox_localDB.Name = "textBox_localDB";
            this.textBox_localDB.Size = new System.Drawing.Size(344, 20);
            this.textBox_localDB.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "SQL Server";
            // 
            // textBox_localSQlServer
            // 
            this.textBox_localSQlServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_localSQlServer.Location = new System.Drawing.Point(95, 23);
            this.textBox_localSQlServer.Name = "textBox_localSQlServer";
            this.textBox_localSQlServer.Size = new System.Drawing.Size(344, 20);
            this.textBox_localSQlServer.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.textBox_mainPWD);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textBox_mainUser);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.textBox_mainDB);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.textBox_mainSQLServer);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 165);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(448, 156);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Головной сервер";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 105);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Пароль";
            // 
            // textBox_mainPWD
            // 
            this.textBox_mainPWD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_mainPWD.Location = new System.Drawing.Point(95, 102);
            this.textBox_mainPWD.Name = "textBox_mainPWD";
            this.textBox_mainPWD.Size = new System.Drawing.Size(344, 20);
            this.textBox_mainPWD.TabIndex = 3;
            this.textBox_mainPWD.UseSystemPasswordChar = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Пользователь";
            // 
            // textBox_mainUser
            // 
            this.textBox_mainUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_mainUser.Location = new System.Drawing.Point(95, 76);
            this.textBox_mainUser.Name = "textBox_mainUser";
            this.textBox_mainUser.Size = new System.Drawing.Size(344, 20);
            this.textBox_mainUser.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 53);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(23, 13);
            this.label7.TabIndex = 11;
            this.label7.Text = "БД";
            // 
            // textBox_mainDB
            // 
            this.textBox_mainDB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_mainDB.Location = new System.Drawing.Point(95, 50);
            this.textBox_mainDB.Name = "textBox_mainDB";
            this.textBox_mainDB.Size = new System.Drawing.Size(344, 20);
            this.textBox_mainDB.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 27);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "SQL Server";
            // 
            // textBox_mainSQLServer
            // 
            this.textBox_mainSQLServer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_mainSQLServer.Location = new System.Drawing.Point(95, 24);
            this.textBox_mainSQLServer.Name = "textBox_mainSQLServer";
            this.textBox_mainSQLServer.Size = new System.Drawing.Size(344, 20);
            this.textBox_mainSQLServer.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_save);
            this.panel1.Controls.Add(this.button_cancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 377);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(448, 27);
            this.panel1.TabIndex = 3;
            // 
            // button_save
            // 
            this.button_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_save.Location = new System.Drawing.Point(284, 3);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(75, 23);
            this.button_save.TabIndex = 0;
            this.button_save.Text = "Сохранить";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_cancel.Location = new System.Drawing.Point(365, 3);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 1;
            this.button_cancel.Text = "Отмена";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox_key);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(3, 327);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(448, 44);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ключ";
            // 
            // textBox_key
            // 
            this.textBox_key.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_key.Location = new System.Drawing.Point(3, 16);
            this.textBox_key.MaxLength = 16;
            this.textBox_key.Name = "textBox_key";
            this.textBox_key.Size = new System.Drawing.Size(442, 20);
            this.textBox_key.TabIndex = 0;
            this.textBox_key.UseSystemPasswordChar = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(2, 5);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(407, 400);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox6);
            this.tabPage1.Controls.Add(this.button_executeDB);
            this.tabPage1.Controls.Add(this.groupBox4);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(399, 374);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Создать БД";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button_executeData);
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(341, 83);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Заполнить таблицы";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.button_browBD);
            this.groupBox4.Controls.Add(this.textBox_fileBD);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(3, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(393, 44);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Путь к сценирию";
            // 
            // textBox_fileBD
            // 
            this.textBox_fileBD.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_fileBD.Location = new System.Drawing.Point(3, 19);
            this.textBox_fileBD.Name = "textBox_fileBD";
            this.textBox_fileBD.ReadOnly = true;
            this.textBox_fileBD.Size = new System.Drawing.Size(346, 20);
            this.textBox_fileBD.TabIndex = 0;
            // 
            // button_browBD
            // 
            this.button_browBD.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_browBD.Location = new System.Drawing.Point(355, 16);
            this.button_browBD.Name = "button_browBD";
            this.button_browBD.Size = new System.Drawing.Size(32, 23);
            this.button_browBD.TabIndex = 1;
            this.button_browBD.Text = "...";
            this.button_browBD.UseVisualStyleBackColor = true;
            this.button_browBD.Click += new System.EventHandler(this.button_browBD_Click);
            // 
            // button_executeDB
            // 
            this.button_executeDB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.button_executeDB.Location = new System.Drawing.Point(6, 56);
            this.button_executeDB.Name = "button_executeDB";
            this.button_executeDB.Size = new System.Drawing.Size(384, 23);
            this.button_executeDB.TabIndex = 1;
            this.button_executeDB.Text = "Выполнить";
            this.button_executeDB.UseVisualStyleBackColor = true;
            this.button_executeDB.Click += new System.EventHandler(this.button_executeDB_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button_browData);
            this.groupBox5.Controls.Add(this.textBox_fileData);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(3, 3);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(335, 44);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Путь к сценирию";
            // 
            // button_browData
            // 
            this.button_browData.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_browData.Location = new System.Drawing.Point(297, 16);
            this.button_browData.Name = "button_browData";
            this.button_browData.Size = new System.Drawing.Size(32, 23);
            this.button_browData.TabIndex = 1;
            this.button_browData.Text = "...";
            this.button_browData.UseVisualStyleBackColor = true;
            // 
            // textBox_fileData
            // 
            this.textBox_fileData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_fileData.Location = new System.Drawing.Point(3, 19);
            this.textBox_fileData.Name = "textBox_fileData";
            this.textBox_fileData.ReadOnly = true;
            this.textBox_fileData.Size = new System.Drawing.Size(288, 20);
            this.textBox_fileData.TabIndex = 0;
            // 
            // button_executeData
            // 
            this.button_executeData.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.button_executeData.Location = new System.Drawing.Point(6, 56);
            this.button_executeData.Name = "button_executeData";
            this.button_executeData.Size = new System.Drawing.Size(326, 23);
            this.button_executeData.TabIndex = 2;
            this.button_executeData.Text = "Выполнить";
            this.button_executeData.UseVisualStyleBackColor = true;
            this.button_executeData.Click += new System.EventHandler(this.button_executeData_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tabControl1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(454, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(2, 5, 2, 2);
            this.panel2.Size = new System.Drawing.Size(411, 407);
            this.panel2.TabIndex = 1;
            // 
            // groupBox6
            // 
            this.groupBox6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox6.Controls.Add(this.textBox_log);
            this.groupBox6.Location = new System.Drawing.Point(6, 80);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(390, 288);
            this.groupBox6.TabIndex = 1;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Результат";
            // 
            // textBox_log
            // 
            this.textBox_log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_log.Location = new System.Drawing.Point(3, 16);
            this.textBox_log.Multiline = true;
            this.textBox_log.Name = "textBox_log";
            this.textBox_log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_log.Size = new System.Drawing.Size(384, 269);
            this.textBox_log.TabIndex = 0;
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(865, 407);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(778, 385);
            this.Name = "fMain";
            this.Text = "Параметры подключения";
            this.Shown += new System.EventHandler(this.fMain_Shown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_localSQlServer;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_localPWD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_localUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_localDB;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_mainPWD;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_mainUser;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_mainDB;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_mainSQLServer;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox textBox_key;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button button_browBD;
        private System.Windows.Forms.TextBox textBox_fileBD;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button button_executeDB;
        private System.Windows.Forms.Button button_executeData;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button button_browData;
        private System.Windows.Forms.TextBox textBox_fileData;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox textBox_log;
    }
}

