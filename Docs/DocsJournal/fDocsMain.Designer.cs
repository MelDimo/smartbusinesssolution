namespace com.sbs.gui.docsjournal
{
    partial class fDocsMain
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
            this.groupBox_filter = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_docsType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_docsNumber = new System.Windows.Forms.TextBox();
            this.dateTimePicker_dateCreate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_own = new System.Windows.Forms.ComboBox();
            this.button_filter = new System.Windows.Forms.Button();
            this.statusStrip_info = new System.Windows.Forms.StatusStrip();
            this.dataGridView_main = new System.Windows.Forms.DataGridView();
            this.menuStrip_filter = new System.Windows.Forms.MenuStrip();
            this.tSMenuItem_create = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox_filter.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_main)).BeginInit();
            this.menuStrip_filter.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_filter
            // 
            this.groupBox_filter.Controls.Add(this.tableLayoutPanel1);
            this.groupBox_filter.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox_filter.Location = new System.Drawing.Point(2, 26);
            this.groupBox_filter.Name = "groupBox_filter";
            this.groupBox_filter.Size = new System.Drawing.Size(960, 72);
            this.groupBox_filter.TabIndex = 0;
            this.groupBox_filter.TabStop = false;
            this.groupBox_filter.Text = "Фильтр документов";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 126F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 199F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBox_docsType, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_docsNumber, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.dateTimePicker_dateCreate, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.comboBox_own, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_filter, 4, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(954, 53);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(473, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Тип документа";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox_docsType
            // 
            this.comboBox_docsType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_docsType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_docsType.FormattingEnabled = true;
            this.comboBox_docsType.Location = new System.Drawing.Point(3, 29);
            this.comboBox_docsType.Name = "comboBox_docsType";
            this.comboBox_docsType.Size = new System.Drawing.Size(473, 21);
            this.comboBox_docsType.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(482, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 26);
            this.label2.TabIndex = 2;
            this.label2.Text = "Номер документа";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(602, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 26);
            this.label3.TabIndex = 4;
            this.label3.Text = "Дата создания";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_docsNumber
            // 
            this.textBox_docsNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_docsNumber.Location = new System.Drawing.Point(482, 29);
            this.textBox_docsNumber.Name = "textBox_docsNumber";
            this.textBox_docsNumber.Size = new System.Drawing.Size(114, 20);
            this.textBox_docsNumber.TabIndex = 5;
            // 
            // dateTimePicker_dateCreate
            // 
            this.dateTimePicker_dateCreate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dateTimePicker_dateCreate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker_dateCreate.Location = new System.Drawing.Point(602, 29);
            this.dateTimePicker_dateCreate.Name = "dateTimePicker_dateCreate";
            this.dateTimePicker_dateCreate.Size = new System.Drawing.Size(120, 20);
            this.dateTimePicker_dateCreate.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(728, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(193, 26);
            this.label4.TabIndex = 7;
            this.label4.Text = "Принадлежность";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox_own
            // 
            this.comboBox_own.Dock = System.Windows.Forms.DockStyle.Fill;
            this.comboBox_own.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_own.FormattingEnabled = true;
            this.comboBox_own.Location = new System.Drawing.Point(728, 29);
            this.comboBox_own.Name = "comboBox_own";
            this.comboBox_own.Size = new System.Drawing.Size(193, 21);
            this.comboBox_own.TabIndex = 8;
            // 
            // button_filter
            // 
            this.button_filter.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button_filter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_filter.Location = new System.Drawing.Point(927, 29);
            this.button_filter.Name = "button_filter";
            this.button_filter.Size = new System.Drawing.Size(24, 21);
            this.button_filter.TabIndex = 9;
            this.button_filter.UseVisualStyleBackColor = true;
            // 
            // statusStrip_info
            // 
            this.statusStrip_info.Location = new System.Drawing.Point(2, 437);
            this.statusStrip_info.Name = "statusStrip_info";
            this.statusStrip_info.Size = new System.Drawing.Size(960, 22);
            this.statusStrip_info.TabIndex = 1;
            this.statusStrip_info.Text = "statusStrip1";
            // 
            // dataGridView_main
            // 
            this.dataGridView_main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_main.Location = new System.Drawing.Point(2, 98);
            this.dataGridView_main.Name = "dataGridView_main";
            this.dataGridView_main.Size = new System.Drawing.Size(960, 339);
            this.dataGridView_main.TabIndex = 2;
            // 
            // menuStrip_filter
            // 
            this.menuStrip_filter.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSMenuItem_create});
            this.menuStrip_filter.Location = new System.Drawing.Point(2, 2);
            this.menuStrip_filter.Name = "menuStrip_filter";
            this.menuStrip_filter.Size = new System.Drawing.Size(960, 24);
            this.menuStrip_filter.TabIndex = 3;
            this.menuStrip_filter.Text = "menuStrip1";
            // 
            // tSMenuItem_create
            // 
            this.tSMenuItem_create.Name = "tSMenuItem_create";
            this.tSMenuItem_create.Size = new System.Drawing.Size(62, 20);
            this.tSMenuItem_create.Text = "Создать";
            // 
            // fDocsMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(964, 461);
            this.Controls.Add(this.dataGridView_main);
            this.Controls.Add(this.statusStrip_info);
            this.Controls.Add(this.groupBox_filter);
            this.Controls.Add(this.menuStrip_filter);
            this.MainMenuStrip = this.menuStrip_filter;
            this.Name = "fDocsMain";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Text = "Журнал документов";
            this.Shown += new System.EventHandler(this.fDocsMain_Shown);
            this.groupBox_filter.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_main)).EndInit();
            this.menuStrip_filter.ResumeLayout(false);
            this.menuStrip_filter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_filter;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_docsType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_docsNumber;
        private System.Windows.Forms.DateTimePicker dateTimePicker_dateCreate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_own;
        private System.Windows.Forms.Button button_filter;
        private System.Windows.Forms.StatusStrip statusStrip_info;
        private System.Windows.Forms.DataGridView dataGridView_main;
        private System.Windows.Forms.MenuStrip menuStrip_filter;
        private System.Windows.Forms.ToolStripMenuItem tSMenuItem_create;

    }
}

