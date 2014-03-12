namespace com.sbs.gui.users
{
    partial class fUsers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fUsers));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.statusStrip_bottom = new System.Windows.Forms.StatusStrip();
            this.tSSLabel_recCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip_top = new System.Windows.Forms.ToolStrip();
            this.tSButton_add = new System.Windows.Forms.ToolStripButton();
            this.tSButton_edit = new System.Windows.Forms.ToolStripButton();
            this.tSButton_del = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tSButton_group = new System.Windows.Forms.ToolStripButton();
            this.tSButton_menu = new System.Windows.Forms.ToolStripButton();
            this.tSButton_doc = new System.Windows.Forms.ToolStripButton();
            this.tSButton_pwd = new System.Windows.Forms.ToolStripButton();
            this.tSButton_acl = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tSComboBox_RecType = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tSComboBox_organization = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.tSComboBox_branch = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.tSComboBox_unit = new System.Windows.Forms.ToolStripComboBox();
            this.tSButton_applyFilter = new System.Windows.Forms.ToolStripButton();
            this.dataGridView_main = new System.Windows.Forms.DataGridView();
            this.tSButton_mail = new System.Windows.Forms.ToolStripButton();
            this.statusStrip_bottom.SuspendLayout();
            this.toolStrip_top.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_main)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip_bottom
            // 
            this.statusStrip_bottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSSLabel_recCount});
            this.statusStrip_bottom.Location = new System.Drawing.Point(0, 472);
            this.statusStrip_bottom.Name = "statusStrip_bottom";
            this.statusStrip_bottom.Size = new System.Drawing.Size(950, 22);
            this.statusStrip_bottom.TabIndex = 6;
            this.statusStrip_bottom.Text = "statusStrip_bottom";
            // 
            // tSSLabel_recCount
            // 
            this.tSSLabel_recCount.Name = "tSSLabel_recCount";
            this.tSSLabel_recCount.Size = new System.Drawing.Size(105, 17);
            this.tSSLabel_recCount.Text = "tSSLabel_recCount";
            // 
            // toolStrip_top
            // 
            this.toolStrip_top.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip_top.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSButton_add,
            this.tSButton_edit,
            this.tSButton_del,
            this.toolStripSeparator1,
            this.tSButton_group,
            this.tSButton_menu,
            this.tSButton_doc,
            this.tSButton_pwd,
            this.tSButton_acl,
            this.tSButton_mail});
            this.toolStrip_top.Location = new System.Drawing.Point(0, 0);
            this.toolStrip_top.Name = "toolStrip_top";
            this.toolStrip_top.Padding = new System.Windows.Forms.Padding(5);
            this.toolStrip_top.Size = new System.Drawing.Size(950, 33);
            this.toolStrip_top.TabIndex = 7;
            this.toolStrip_top.Text = "toolStrip_top";
            // 
            // tSButton_add
            // 
            this.tSButton_add.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSButton_add.Image = ((System.Drawing.Image)(resources.GetObject("tSButton_add.Image")));
            this.tSButton_add.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tSButton_add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSButton_add.Name = "tSButton_add";
            this.tSButton_add.Size = new System.Drawing.Size(23, 20);
            this.tSButton_add.Text = "Добавить";
            this.tSButton_add.Click += new System.EventHandler(this.tSButton_add_Click);
            // 
            // tSButton_edit
            // 
            this.tSButton_edit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSButton_edit.Image = ((System.Drawing.Image)(resources.GetObject("tSButton_edit.Image")));
            this.tSButton_edit.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tSButton_edit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSButton_edit.Name = "tSButton_edit";
            this.tSButton_edit.Size = new System.Drawing.Size(23, 20);
            this.tSButton_edit.Text = "Редактировать";
            this.tSButton_edit.Click += new System.EventHandler(this.tSButton_edit_Click);
            // 
            // tSButton_del
            // 
            this.tSButton_del.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSButton_del.Image = ((System.Drawing.Image)(resources.GetObject("tSButton_del.Image")));
            this.tSButton_del.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tSButton_del.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSButton_del.Name = "tSButton_del";
            this.tSButton_del.Size = new System.Drawing.Size(23, 20);
            this.tSButton_del.Text = "Удалить";
            this.tSButton_del.Click += new System.EventHandler(this.tSButton_del_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // tSButton_group
            // 
            this.tSButton_group.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSButton_group.Image = ((System.Drawing.Image)(resources.GetObject("tSButton_group.Image")));
            this.tSButton_group.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tSButton_group.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSButton_group.Name = "tSButton_group";
            this.tSButton_group.Size = new System.Drawing.Size(23, 20);
            this.tSButton_group.Text = "avalable_group";
            this.tSButton_group.ToolTipText = "Состоит в группах";
            this.tSButton_group.Click += new System.EventHandler(this.tSButton_group_Click);
            // 
            // tSButton_menu
            // 
            this.tSButton_menu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSButton_menu.Image = ((System.Drawing.Image)(resources.GetObject("tSButton_menu.Image")));
            this.tSButton_menu.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tSButton_menu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSButton_menu.Name = "tSButton_menu";
            this.tSButton_menu.Size = new System.Drawing.Size(23, 20);
            this.tSButton_menu.Text = "avaliable_mnu";
            this.tSButton_menu.ToolTipText = "Доступные пункты меню";
            this.tSButton_menu.Click += new System.EventHandler(this.tSButton_menu_Click);
            // 
            // tSButton_doc
            // 
            this.tSButton_doc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSButton_doc.Image = ((System.Drawing.Image)(resources.GetObject("tSButton_doc.Image")));
            this.tSButton_doc.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tSButton_doc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSButton_doc.Name = "tSButton_doc";
            this.tSButton_doc.Size = new System.Drawing.Size(23, 20);
            this.tSButton_doc.Text = "avaliable_doc";
            this.tSButton_doc.ToolTipText = "Доступные документы";
            // 
            // tSButton_pwd
            // 
            this.tSButton_pwd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSButton_pwd.Image = ((System.Drawing.Image)(resources.GetObject("tSButton_pwd.Image")));
            this.tSButton_pwd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tSButton_pwd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSButton_pwd.Name = "tSButton_pwd";
            this.tSButton_pwd.Size = new System.Drawing.Size(23, 20);
            this.tSButton_pwd.Text = "toolStripButton1";
            this.tSButton_pwd.ToolTipText = "Пароль...";
            this.tSButton_pwd.Click += new System.EventHandler(this.tSButton_pwd_Click);
            // 
            // tSButton_acl
            // 
            this.tSButton_acl.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSButton_acl.Image = ((System.Drawing.Image)(resources.GetObject("tSButton_acl.Image")));
            this.tSButton_acl.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tSButton_acl.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSButton_acl.Name = "tSButton_acl";
            this.tSButton_acl.Size = new System.Drawing.Size(23, 20);
            this.tSButton_acl.Text = "tSButton_acl";
            this.tSButton_acl.ToolTipText = "Права...";
            this.tSButton_acl.Click += new System.EventHandler(this.tSButton_acl_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tSComboBox_RecType,
            this.toolStripLabel2,
            this.tSComboBox_organization,
            this.toolStripLabel3,
            this.tSComboBox_branch,
            this.toolStripLabel4,
            this.tSComboBox_unit,
            this.tSButton_applyFilter});
            this.toolStrip1.Location = new System.Drawing.Point(0, 33);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(950, 25);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(73, 22);
            this.toolStripLabel1.Text = "Тип записи";
            // 
            // tSComboBox_RecType
            // 
            this.tSComboBox_RecType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tSComboBox_RecType.Items.AddRange(new object[] {
            "Пользователь",
            "Группа"});
            this.tSComboBox_RecType.Name = "tSComboBox_RecType";
            this.tSComboBox_RecType.Size = new System.Drawing.Size(121, 25);
            this.tSComboBox_RecType.SelectedIndexChanged += new System.EventHandler(this.tSComboBox_RecType_SelectedIndexChanged);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(84, 22);
            this.toolStripLabel2.Text = "Организация";
            // 
            // tSComboBox_organization
            // 
            this.tSComboBox_organization.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tSComboBox_organization.Name = "tSComboBox_organization";
            this.tSComboBox_organization.Size = new System.Drawing.Size(121, 25);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(70, 22);
            this.toolStripLabel3.Text = "Заведение";
            // 
            // tSComboBox_branch
            // 
            this.tSComboBox_branch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tSComboBox_branch.Name = "tSComboBox_branch";
            this.tSComboBox_branch.Size = new System.Drawing.Size(121, 25);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(99, 22);
            this.toolStripLabel4.Text = "Подразделение";
            // 
            // tSComboBox_unit
            // 
            this.tSComboBox_unit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tSComboBox_unit.Name = "tSComboBox_unit";
            this.tSComboBox_unit.Size = new System.Drawing.Size(121, 25);
            // 
            // tSButton_applyFilter
            // 
            this.tSButton_applyFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSButton_applyFilter.Image = ((System.Drawing.Image)(resources.GetObject("tSButton_applyFilter.Image")));
            this.tSButton_applyFilter.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tSButton_applyFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSButton_applyFilter.Name = "tSButton_applyFilter";
            this.tSButton_applyFilter.Size = new System.Drawing.Size(23, 22);
            this.tSButton_applyFilter.Text = "apply_filter";
            this.tSButton_applyFilter.ToolTipText = "Применить фильтр";
            this.tSButton_applyFilter.Click += new System.EventHandler(this.tSButton_applyFilter_Click);
            // 
            // dataGridView_main
            // 
            this.dataGridView_main.AllowUserToAddRows = false;
            this.dataGridView_main.AllowUserToDeleteRows = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_main.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridView_main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView_main.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridView_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_main.Location = new System.Drawing.Point(0, 58);
            this.dataGridView_main.MultiSelect = false;
            this.dataGridView_main.Name = "dataGridView_main";
            this.dataGridView_main.ReadOnly = true;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView_main.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dataGridView_main.RowHeadersVisible = false;
            this.dataGridView_main.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_main.Size = new System.Drawing.Size(950, 414);
            this.dataGridView_main.TabIndex = 9;
            // 
            // tSButton_mail
            // 
            this.tSButton_mail.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSButton_mail.Image = ((System.Drawing.Image)(resources.GetObject("tSButton_mail.Image")));
            this.tSButton_mail.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tSButton_mail.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSButton_mail.Name = "tSButton_mail";
            this.tSButton_mail.Size = new System.Drawing.Size(23, 20);
            this.tSButton_mail.Text = "tSButton_mail";
            this.tSButton_mail.ToolTipText = "Почта";
            this.tSButton_mail.Click += new System.EventHandler(this.tSButton_mail_Click);
            // 
            // fUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(950, 494);
            this.Controls.Add(this.dataGridView_main);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.toolStrip_top);
            this.Controls.Add(this.statusStrip_bottom);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(880, 532);
            this.Name = "fUsers";
            this.ShowInTaskbar = false;
            this.Text = "Сотрудники";
            this.Shown += new System.EventHandler(this.fUsers_Shown);
            this.statusStrip_bottom.ResumeLayout(false);
            this.statusStrip_bottom.PerformLayout();
            this.toolStrip_top.ResumeLayout(false);
            this.toolStrip_top.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_main)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip_bottom;
        private System.Windows.Forms.ToolStripStatusLabel tSSLabel_recCount;
        private System.Windows.Forms.ToolStrip toolStrip_top;
        private System.Windows.Forms.ToolStripButton tSButton_add;
        private System.Windows.Forms.ToolStripButton tSButton_edit;
        private System.Windows.Forms.ToolStripButton tSButton_del;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tSButton_menu;
        private System.Windows.Forms.ToolStripButton tSButton_doc;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox tSComboBox_RecType;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox tSComboBox_organization;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripComboBox tSComboBox_branch;
        private System.Windows.Forms.ToolStripButton tSButton_applyFilter;
        private System.Windows.Forms.DataGridView dataGridView_main;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.ToolStripComboBox tSComboBox_unit;
        private System.Windows.Forms.ToolStripButton tSButton_group;
        private System.Windows.Forms.ToolStripButton tSButton_pwd;
        private System.Windows.Forms.ToolStripButton tSButton_acl;
        private System.Windows.Forms.ToolStripButton tSButton_mail;

    }
}

