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
            this.statusStrip_bottom = new System.Windows.Forms.StatusStrip();
            this.tSSLabel_recCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip_top = new System.Windows.Forms.ToolStrip();
            this.tSButton_add = new System.Windows.Forms.ToolStripButton();
            this.tSButton_edit = new System.Windows.Forms.ToolStripButton();
            this.tSButton_del = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tSButton_menu = new System.Windows.Forms.ToolStripButton();
            this.tSButton_doc = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tSComboBox_RecType = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tSComboBox_organization = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.tSComboBox_branch = new System.Windows.Forms.ToolStripComboBox();
            this.tSButton_applyFilter = new System.Windows.Forms.ToolStripButton();
            this.dataGridView_main = new System.Windows.Forms.DataGridView();
            this.tSComboBox_unit = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
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
            this.statusStrip_bottom.Size = new System.Drawing.Size(864, 22);
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
            this.tSButton_menu,
            this.tSButton_doc});
            this.toolStrip_top.Location = new System.Drawing.Point(0, 0);
            this.toolStrip_top.Name = "toolStrip_top";
            this.toolStrip_top.Size = new System.Drawing.Size(864, 25);
            this.toolStrip_top.TabIndex = 7;
            this.toolStrip_top.Text = "toolStrip_top";
            // 
            // tSButton_add
            // 
            this.tSButton_add.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSButton_add.Image = ((System.Drawing.Image)(resources.GetObject("tSButton_add.Image")));
            this.tSButton_add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSButton_add.Name = "tSButton_add";
            this.tSButton_add.Size = new System.Drawing.Size(23, 22);
            this.tSButton_add.Text = "Добавить";
            this.tSButton_add.Click += new System.EventHandler(this.tSButton_add_Click);
            // 
            // tSButton_edit
            // 
            this.tSButton_edit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSButton_edit.Image = ((System.Drawing.Image)(resources.GetObject("tSButton_edit.Image")));
            this.tSButton_edit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSButton_edit.Name = "tSButton_edit";
            this.tSButton_edit.Size = new System.Drawing.Size(23, 22);
            this.tSButton_edit.Text = "Редактировать";
            this.tSButton_edit.Click += new System.EventHandler(this.tSButton_edit_Click);
            // 
            // tSButton_del
            // 
            this.tSButton_del.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSButton_del.Image = ((System.Drawing.Image)(resources.GetObject("tSButton_del.Image")));
            this.tSButton_del.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSButton_del.Name = "tSButton_del";
            this.tSButton_del.Size = new System.Drawing.Size(23, 22);
            this.tSButton_del.Text = "Удалить";
            this.tSButton_del.Click += new System.EventHandler(this.tSButton_del_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tSButton_menu
            // 
            this.tSButton_menu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSButton_menu.Image = ((System.Drawing.Image)(resources.GetObject("tSButton_menu.Image")));
            this.tSButton_menu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSButton_menu.Name = "tSButton_menu";
            this.tSButton_menu.Size = new System.Drawing.Size(23, 22);
            this.tSButton_menu.Text = "avaliable_mnu";
            this.tSButton_menu.ToolTipText = "Доступные пункты меню";
            // 
            // tSButton_doc
            // 
            this.tSButton_doc.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSButton_doc.Image = ((System.Drawing.Image)(resources.GetObject("tSButton_doc.Image")));
            this.tSButton_doc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSButton_doc.Name = "tSButton_doc";
            this.tSButton_doc.Size = new System.Drawing.Size(23, 22);
            this.tSButton_doc.Text = "avaliable_doc";
            this.tSButton_doc.ToolTipText = "Доступные документы";
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
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(864, 25);
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
            // tSButton_applyFilter
            // 
            this.tSButton_applyFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSButton_applyFilter.Image = ((System.Drawing.Image)(resources.GetObject("tSButton_applyFilter.Image")));
            this.tSButton_applyFilter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSButton_applyFilter.Name = "tSButton_applyFilter";
            this.tSButton_applyFilter.Size = new System.Drawing.Size(23, 22);
            this.tSButton_applyFilter.Text = "apply_filter";
            this.tSButton_applyFilter.ToolTipText = "Применить фильтр";
            // 
            // dataGridView_main
            // 
            this.dataGridView_main.AllowUserToAddRows = false;
            this.dataGridView_main.AllowUserToDeleteRows = false;
            this.dataGridView_main.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_main.Location = new System.Drawing.Point(0, 50);
            this.dataGridView_main.MultiSelect = false;
            this.dataGridView_main.Name = "dataGridView_main";
            this.dataGridView_main.ReadOnly = true;
            this.dataGridView_main.RowHeadersVisible = false;
            this.dataGridView_main.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_main.Size = new System.Drawing.Size(864, 422);
            this.dataGridView_main.TabIndex = 9;
            // 
            // tSComboBox_unit
            // 
            this.tSComboBox_unit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tSComboBox_unit.Name = "tSComboBox_unit";
            this.tSComboBox_unit.Size = new System.Drawing.Size(121, 25);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(99, 22);
            this.toolStripLabel4.Text = "Подразделение";
            // 
            // fUsers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(864, 494);
            this.Controls.Add(this.dataGridView_main);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.toolStrip_top);
            this.Controls.Add(this.statusStrip_bottom);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(646, 440);
            this.Name = "fUsers";
            this.ShowInTaskbar = false;
            this.Text = "Сотрудники";
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

    }
}

