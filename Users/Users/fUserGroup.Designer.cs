namespace com.sbs.gui.users
{
    partial class fUserGroup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fUserGroup));
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_ok = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label_fio = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBox_groups = new System.Windows.Forms.ListBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tSButton_add = new System.Windows.Forms.ToolStripButton();
            this.tSButton_del = new System.Windows.Forms.ToolStripButton();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_cancel);
            this.panel1.Controls.Add(this.button_ok);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 415);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(307, 35);
            this.panel1.TabIndex = 1;
            // 
            // button_cancel
            // 
            this.button_cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_cancel.Location = new System.Drawing.Point(209, 7);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(75, 23);
            this.button_cancel.TabIndex = 2;
            this.button_cancel.Text = "Отмена";
            this.button_cancel.UseVisualStyleBackColor = true;
            // 
            // button_ok
            // 
            this.button_ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_ok.Location = new System.Drawing.Point(128, 7);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 0;
            this.button_ok.Text = "Ок";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label_fio, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(3);
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(307, 415);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // label_fio
            // 
            this.label_fio.AutoSize = true;
            this.label_fio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_fio.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_fio.Location = new System.Drawing.Point(6, 3);
            this.label_fio.Name = "label_fio";
            this.label_fio.Size = new System.Drawing.Size(295, 60);
            this.label_fio.TabIndex = 0;
            this.label_fio.Text = "___";
            this.label_fio.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBox_groups);
            this.groupBox1.Controls.Add(this.toolStrip1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(6, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(295, 343);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Состоит в группах";
            // 
            // listBox_groups
            // 
            this.listBox_groups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_groups.FormattingEnabled = true;
            this.listBox_groups.Location = new System.Drawing.Point(3, 41);
            this.listBox_groups.Name = "listBox_groups";
            this.listBox_groups.Size = new System.Drawing.Size(289, 299);
            this.listBox_groups.TabIndex = 1;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSButton_add,
            this.tSButton_del});
            this.toolStrip1.Location = new System.Drawing.Point(3, 16);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(289, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tSButton_add
            // 
            this.tSButton_add.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSButton_add.Image = ((System.Drawing.Image)(resources.GetObject("tSButton_add.Image")));
            this.tSButton_add.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tSButton_add.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSButton_add.Name = "tSButton_add";
            this.tSButton_add.Size = new System.Drawing.Size(23, 22);
            this.tSButton_add.Text = "toolStripButton1";
            this.tSButton_add.ToolTipText = "Включить в группу...";
            this.tSButton_add.Click += new System.EventHandler(this.tSButton_add_Click);
            // 
            // tSButton_del
            // 
            this.tSButton_del.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSButton_del.Image = ((System.Drawing.Image)(resources.GetObject("tSButton_del.Image")));
            this.tSButton_del.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tSButton_del.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSButton_del.Name = "tSButton_del";
            this.tSButton_del.Size = new System.Drawing.Size(23, 22);
            this.tSButton_del.Text = "toolStripButton2";
            this.tSButton_del.ToolTipText = "Исключить из группы";
            this.tSButton_del.Click += new System.EventHandler(this.tSButton_del_Click);
            // 
            // fUserGroup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(307, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel1);
            this.MinimizeBox = false;
            this.Name = "fUserGroup";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "fUserGroup";
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label_fio;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tSButton_add;
        private System.Windows.Forms.ToolStripButton tSButton_del;
        private System.Windows.Forms.ListBox listBox_groups;
    }
}