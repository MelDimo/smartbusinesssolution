namespace com.sbs.dll.utilites
{
    partial class fDelivery
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_city = new System.Windows.Forms.ComboBox();
            this.textBox_addr = new System.Windows.Forms.TextBox();
            this.textBox_tel = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_fio = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_house = new System.Windows.Forms.TextBox();
            this.textBox_korp = new System.Windows.Forms.TextBox();
            this.textBox_app = new System.Windows.Forms.TextBox();
            this.textBox_porch = new System.Windows.Forms.TextBox();
            this.textBox_code = new System.Windows.Forms.TextBox();
            this.textBox_floor = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox_comment = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox_cardNumber = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.comboBox_tariff = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBox_driver = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_save = new System.Windows.Forms.Button();
            this.groupBox_clients = new System.Windows.Forms.GroupBox();
            this.dataGridView_main = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cityName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.city = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.street = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox_clients.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_main)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox1.Controls.Add(this.tableLayoutPanel2);
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(554, 119);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Данные клиента";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 4;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 63F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 47F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.comboBox_city, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.textBox_addr, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.textBox_tel, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.label12, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.textBox_fio, 3, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(548, 56);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Телефон";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox_city
            // 
            this.comboBox_city.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_city.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_city.FormattingEnabled = true;
            this.comboBox_city.Location = new System.Drawing.Point(66, 31);
            this.comboBox_city.Name = "comboBox_city";
            this.comboBox_city.Size = new System.Drawing.Size(125, 21);
            this.comboBox_city.TabIndex = 2;
            // 
            // textBox_addr
            // 
            this.textBox_addr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_addr.Location = new System.Drawing.Point(244, 31);
            this.textBox_addr.Name = "textBox_addr";
            this.textBox_addr.Size = new System.Drawing.Size(301, 20);
            this.textBox_addr.TabIndex = 3;
            // 
            // textBox_tel
            // 
            this.textBox_tel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_tel.Location = new System.Drawing.Point(66, 3);
            this.textBox_tel.Name = "textBox_tel";
            this.textBox_tel.Size = new System.Drawing.Size(125, 20);
            this.textBox_tel.TabIndex = 0;
            this.textBox_tel.Validated += new System.EventHandler(this.textBox_tel_Validated);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(197, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 28);
            this.label3.TabIndex = 4;
            this.label3.Text = "Адрес";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label12.Location = new System.Drawing.Point(3, 28);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 28);
            this.label12.TabIndex = 7;
            this.label12.Text = "Город";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(197, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 28);
            this.label2.TabIndex = 2;
            this.label2.Text = "ФИО";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_fio
            // 
            this.textBox_fio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_fio.Location = new System.Drawing.Point(244, 3);
            this.textBox_fio.Name = "textBox_fio";
            this.textBox_fio.Size = new System.Drawing.Size(301, 20);
            this.textBox_fio.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label7, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label8, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.label9, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_house, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_korp, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_app, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_porch, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_code, 4, 1);
            this.tableLayoutPanel1.Controls.Add(this.textBox_floor, 5, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 73);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(548, 43);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Дом";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(94, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "Корп";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(185, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "Кв";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label7.Location = new System.Drawing.Point(276, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(85, 17);
            this.label7.TabIndex = 3;
            this.label7.Text = "Подъезд";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Location = new System.Drawing.Point(367, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 17);
            this.label8.TabIndex = 4;
            this.label8.Text = "Код";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label9.Location = new System.Drawing.Point(458, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(87, 17);
            this.label9.TabIndex = 5;
            this.label9.Text = "Этаж";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_house
            // 
            this.textBox_house.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_house.Location = new System.Drawing.Point(3, 20);
            this.textBox_house.Name = "textBox_house";
            this.textBox_house.Size = new System.Drawing.Size(85, 20);
            this.textBox_house.TabIndex = 0;
            // 
            // textBox_korp
            // 
            this.textBox_korp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_korp.Location = new System.Drawing.Point(94, 20);
            this.textBox_korp.Name = "textBox_korp";
            this.textBox_korp.Size = new System.Drawing.Size(85, 20);
            this.textBox_korp.TabIndex = 1;
            // 
            // textBox_app
            // 
            this.textBox_app.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_app.Location = new System.Drawing.Point(185, 20);
            this.textBox_app.Name = "textBox_app";
            this.textBox_app.Size = new System.Drawing.Size(85, 20);
            this.textBox_app.TabIndex = 2;
            // 
            // textBox_porch
            // 
            this.textBox_porch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_porch.Location = new System.Drawing.Point(276, 20);
            this.textBox_porch.Name = "textBox_porch";
            this.textBox_porch.Size = new System.Drawing.Size(85, 20);
            this.textBox_porch.TabIndex = 3;
            // 
            // textBox_code
            // 
            this.textBox_code.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_code.Location = new System.Drawing.Point(367, 20);
            this.textBox_code.Name = "textBox_code";
            this.textBox_code.Size = new System.Drawing.Size(85, 20);
            this.textBox_code.TabIndex = 4;
            // 
            // textBox_floor
            // 
            this.textBox_floor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_floor.Location = new System.Drawing.Point(458, 20);
            this.textBox_floor.Name = "textBox_floor";
            this.textBox_floor.Size = new System.Drawing.Size(87, 20);
            this.textBox_floor.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.textBox_comment);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.textBox_cardNumber);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.comboBox_tariff);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.comboBox_driver);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 122);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(554, 161);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Параметры";
            // 
            // textBox_comment
            // 
            this.textBox_comment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_comment.Location = new System.Drawing.Point(91, 106);
            this.textBox_comment.Multiline = true;
            this.textBox_comment.Name = "textBox_comment";
            this.textBox_comment.Size = new System.Drawing.Size(457, 49);
            this.textBox_comment.TabIndex = 3;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(6, 109);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(77, 13);
            this.label14.TabIndex = 6;
            this.label14.Text = "Комментарий";
            // 
            // textBox_cardNumber
            // 
            this.textBox_cardNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_cardNumber.Location = new System.Drawing.Point(91, 80);
            this.textBox_cardNumber.Name = "textBox_cardNumber";
            this.textBox_cardNumber.Size = new System.Drawing.Size(457, 20);
            this.textBox_cardNumber.TabIndex = 2;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 83);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(75, 13);
            this.label13.TabIndex = 4;
            this.label13.Text = "Номер карты";
            // 
            // comboBox_tariff
            // 
            this.comboBox_tariff.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_tariff.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_tariff.FormattingEnabled = true;
            this.comboBox_tariff.Location = new System.Drawing.Point(91, 53);
            this.comboBox_tariff.Name = "comboBox_tariff";
            this.comboBox_tariff.Size = new System.Drawing.Size(457, 21);
            this.comboBox_tariff.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 56);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 13);
            this.label11.TabIndex = 2;
            this.label11.Text = "Тариф";
            // 
            // comboBox_driver
            // 
            this.comboBox_driver.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox_driver.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_driver.FormattingEnabled = true;
            this.comboBox_driver.Location = new System.Drawing.Point(91, 26);
            this.comboBox_driver.Name = "comboBox_driver";
            this.comboBox_driver.Size = new System.Drawing.Size(457, 21);
            this.comboBox_driver.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 29);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 13);
            this.label10.TabIndex = 0;
            this.label10.Text = "Водитель";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.button_save);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 283);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(554, 29);
            this.panel1.TabIndex = 2;
            // 
            // button_save
            // 
            this.button_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_save.Location = new System.Drawing.Point(388, 3);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(144, 23);
            this.button_save.TabIndex = 0;
            this.button_save.Text = "Сохранить";
            this.button_save.UseVisualStyleBackColor = true;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // groupBox_clients
            // 
            this.groupBox_clients.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox_clients.Controls.Add(this.dataGridView_main);
            this.groupBox_clients.Location = new System.Drawing.Point(70, 76);
            this.groupBox_clients.Name = "groupBox_clients";
            this.groupBox_clients.Size = new System.Drawing.Size(438, 174);
            this.groupBox_clients.TabIndex = 7;
            this.groupBox_clients.TabStop = false;
            this.groupBox_clients.Text = "Найденные совпадения";
            this.groupBox_clients.Visible = false;
            // 
            // dataGridView_main
            // 
            this.dataGridView_main.AllowUserToAddRows = false;
            this.dataGridView_main.AllowUserToDeleteRows = false;
            this.dataGridView_main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_main.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.cityName,
            this.city,
            this.fio,
            this.street});
            this.dataGridView_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_main.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView_main.Location = new System.Drawing.Point(3, 16);
            this.dataGridView_main.MultiSelect = false;
            this.dataGridView_main.Name = "dataGridView_main";
            this.dataGridView_main.ReadOnly = true;
            this.dataGridView_main.RowHeadersVisible = false;
            this.dataGridView_main.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_main.Size = new System.Drawing.Size(432, 155);
            this.dataGridView_main.TabIndex = 0;
            this.dataGridView_main.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView_main_KeyDown);
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // cityName
            // 
            this.cityName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.cityName.HeaderText = "Город";
            this.cityName.Name = "cityName";
            this.cityName.ReadOnly = true;
            this.cityName.Width = 62;
            // 
            // city
            // 
            this.city.HeaderText = "city";
            this.city.Name = "city";
            this.city.ReadOnly = true;
            this.city.Visible = false;
            // 
            // fio
            // 
            this.fio.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.fio.HeaderText = "ФИО";
            this.fio.Name = "fio";
            this.fio.ReadOnly = true;
            this.fio.Width = 59;
            // 
            // street
            // 
            this.street.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.street.HeaderText = "Адрес";
            this.street.Name = "street";
            this.street.ReadOnly = true;
            // 
            // fDelivery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(560, 315);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox_clients);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(460, 294);
            this.Name = "fDelivery";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.fDelivery_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fDelivery_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.groupBox_clients.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_main)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comboBox_city;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_house;
        private System.Windows.Forms.TextBox textBox_korp;
        private System.Windows.Forms.TextBox textBox_app;
        private System.Windows.Forms.TextBox textBox_porch;
        private System.Windows.Forms.TextBox textBox_code;
        private System.Windows.Forms.TextBox textBox_floor;
        private System.Windows.Forms.TextBox textBox_addr;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_fio;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_tel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox comboBox_tariff;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox comboBox_driver;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox_comment;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox textBox_cardNumber;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox groupBox_clients;
        private System.Windows.Forms.DataGridView dataGridView_main;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn cityName;
        private System.Windows.Forms.DataGridViewTextBoxColumn city;
        private System.Windows.Forms.DataGridViewTextBoxColumn fio;
        private System.Windows.Forms.DataGridViewTextBoxColumn street;

    }
}