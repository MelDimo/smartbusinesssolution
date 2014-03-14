namespace com.sbs.dll.mailChecker
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fMain));
            this.toolStrip_top = new System.Windows.Forms.ToolStrip();
            this.tSButton_recive = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tSButton_config = new System.Windows.Forms.ToolStripButton();
            this.statusStrip_bottom = new System.Windows.Forms.StatusStrip();
            this.dataGridView_postBox = new System.Windows.Forms.DataGridView();
            this.webBrowser_content = new System.Windows.Forms.WebBrowser();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tSButton_delete = new System.Windows.Forms.ToolStripButton();
            this.dateIncoming = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.from = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.body = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.messageNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button_previos = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button_next = new System.Windows.Forms.Button();
            this.toolStrip_top.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_postBox)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip_top
            // 
            this.toolStrip_top.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip_top.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSButton_recive,
            this.tSButton_delete,
            this.toolStripSeparator1,
            this.tSButton_config});
            this.toolStrip_top.Location = new System.Drawing.Point(0, 0);
            this.toolStrip_top.Name = "toolStrip_top";
            this.toolStrip_top.Size = new System.Drawing.Size(818, 25);
            this.toolStrip_top.TabIndex = 0;
            this.toolStrip_top.Text = "toolStrip1";
            // 
            // tSButton_recive
            // 
            this.tSButton_recive.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSButton_recive.Image = ((System.Drawing.Image)(resources.GetObject("tSButton_recive.Image")));
            this.tSButton_recive.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tSButton_recive.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSButton_recive.Name = "tSButton_recive";
            this.tSButton_recive.Size = new System.Drawing.Size(23, 22);
            this.tSButton_recive.Text = "tSButton_recive";
            this.tSButton_recive.ToolTipText = "Получить почту";
            this.tSButton_recive.Click += new System.EventHandler(this.tSButton_recive_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tSButton_config
            // 
            this.tSButton_config.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSButton_config.Image = ((System.Drawing.Image)(resources.GetObject("tSButton_config.Image")));
            this.tSButton_config.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tSButton_config.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSButton_config.Name = "tSButton_config";
            this.tSButton_config.Size = new System.Drawing.Size(23, 22);
            this.tSButton_config.Text = "tSButton_config";
            this.tSButton_config.ToolTipText = "Настройки";
            this.tSButton_config.Click += new System.EventHandler(this.tSButton_config_Click);
            // 
            // statusStrip_bottom
            // 
            this.statusStrip_bottom.Location = new System.Drawing.Point(0, 462);
            this.statusStrip_bottom.Name = "statusStrip_bottom";
            this.statusStrip_bottom.Size = new System.Drawing.Size(818, 22);
            this.statusStrip_bottom.TabIndex = 1;
            this.statusStrip_bottom.Text = "statusStrip1";
            // 
            // dataGridView_postBox
            // 
            this.dataGridView_postBox.AllowUserToAddRows = false;
            this.dataGridView_postBox.AllowUserToDeleteRows = false;
            this.dataGridView_postBox.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_postBox.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dateIncoming,
            this.subject,
            this.from,
            this.body,
            this.messageNumber});
            this.dataGridView_postBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_postBox.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView_postBox.Location = new System.Drawing.Point(0, 36);
            this.dataGridView_postBox.MultiSelect = false;
            this.dataGridView_postBox.Name = "dataGridView_postBox";
            this.dataGridView_postBox.ReadOnly = true;
            this.dataGridView_postBox.RowHeadersVisible = false;
            this.dataGridView_postBox.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_postBox.Size = new System.Drawing.Size(380, 401);
            this.dataGridView_postBox.TabIndex = 0;
            // 
            // webBrowser_content
            // 
            this.webBrowser_content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser_content.Location = new System.Drawing.Point(0, 0);
            this.webBrowser_content.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser_content.Name = "webBrowser_content";
            this.webBrowser_content.Size = new System.Drawing.Size(434, 437);
            this.webBrowser_content.TabIndex = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dataGridView_postBox);
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.webBrowser_content);
            this.splitContainer1.Size = new System.Drawing.Size(818, 437);
            this.splitContainer1.SplitterDistance = 380;
            this.splitContainer1.TabIndex = 3;
            // 
            // tSButton_delete
            // 
            this.tSButton_delete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSButton_delete.Image = ((System.Drawing.Image)(resources.GetObject("tSButton_delete.Image")));
            this.tSButton_delete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tSButton_delete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSButton_delete.Name = "tSButton_delete";
            this.tSButton_delete.Size = new System.Drawing.Size(23, 22);
            this.tSButton_delete.Text = "toolStripButton1";
            this.tSButton_delete.Click += new System.EventHandler(this.tSButton_delete_Click);
            // 
            // dateIncoming
            // 
            this.dateIncoming.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dateIncoming.HeaderText = "Дата";
            this.dateIncoming.Name = "dateIncoming";
            this.dateIncoming.ReadOnly = true;
            this.dateIncoming.Width = 58;
            // 
            // subject
            // 
            this.subject.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.subject.HeaderText = "Тема";
            this.subject.Name = "subject";
            this.subject.ReadOnly = true;
            // 
            // from
            // 
            this.from.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.from.HeaderText = "От";
            this.from.Name = "from";
            this.from.ReadOnly = true;
            this.from.Width = 45;
            // 
            // body
            // 
            this.body.HeaderText = "body";
            this.body.Name = "body";
            this.body.ReadOnly = true;
            this.body.Visible = false;
            // 
            // messageNumber
            // 
            this.messageNumber.HeaderText = "messageNumber";
            this.messageNumber.Name = "messageNumber";
            this.messageNumber.ReadOnly = true;
            this.messageNumber.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(380, 36);
            this.panel1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.Controls.Add(this.button_previos, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.button_next, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(378, 34);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // button_previos
            // 
            this.button_previos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button_previos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_previos.Location = new System.Drawing.Point(3, 3);
            this.button_previos.Name = "button_previos";
            this.button_previos.Size = new System.Drawing.Size(39, 28);
            this.button_previos.TabIndex = 0;
            this.button_previos.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(48, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(282, 34);
            this.label1.TabIndex = 1;
            this.label1.Text = "label_CurFrom";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_next
            // 
            this.button_next.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.button_next.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_next.Location = new System.Drawing.Point(336, 3);
            this.button_next.Name = "button_next";
            this.button_next.Size = new System.Drawing.Size(39, 28);
            this.button_next.TabIndex = 2;
            this.button_next.UseVisualStyleBackColor = true;
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 484);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip_bottom);
            this.Controls.Add(this.toolStrip_top);
            this.Name = "fMain";
            this.Text = "Почта";
            this.Shown += new System.EventHandler(this.fMain_Shown);
            this.toolStrip_top.ResumeLayout(false);
            this.toolStrip_top.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_postBox)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip_top;
        private System.Windows.Forms.ToolStripButton tSButton_recive;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tSButton_config;
        private System.Windows.Forms.StatusStrip statusStrip_bottom;
        private System.Windows.Forms.DataGridView dataGridView_postBox;
        private System.Windows.Forms.WebBrowser webBrowser_content;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripButton tSButton_delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateIncoming;
        private System.Windows.Forms.DataGridViewTextBoxColumn subject;
        private System.Windows.Forms.DataGridViewTextBoxColumn from;
        private System.Windows.Forms.DataGridViewTextBoxColumn body;
        private System.Windows.Forms.DataGridViewTextBoxColumn messageNumber;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button_previos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_next;
    }
}