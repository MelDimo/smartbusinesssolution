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
            this.tSButton_config = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.statusStrip_bottom = new System.Windows.Forms.StatusStrip();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView_postBox = new System.Windows.Forms.DataGridView();
            this.webBrowser_content = new System.Windows.Forms.WebBrowser();
            this.from = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.subject = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateIncoming = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip_top.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_postBox)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip_top
            // 
            this.toolStrip_top.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip_top.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSButton_recive,
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
            this.tSButton_recive.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSButton_recive.Name = "tSButton_recive";
            this.tSButton_recive.Size = new System.Drawing.Size(23, 22);
            this.tSButton_recive.Text = "tSButton_recive";
            this.tSButton_recive.ToolTipText = "Получить почту";
            // 
            // tSButton_config
            // 
            this.tSButton_config.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSButton_config.Image = ((System.Drawing.Image)(resources.GetObject("tSButton_config.Image")));
            this.tSButton_config.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSButton_config.Name = "tSButton_config";
            this.tSButton_config.Size = new System.Drawing.Size(23, 22);
            this.tSButton_config.Text = "tSButton_config";
            this.tSButton_config.ToolTipText = "Настройки";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // statusStrip_bottom
            // 
            this.statusStrip_bottom.Location = new System.Drawing.Point(0, 462);
            this.statusStrip_bottom.Name = "statusStrip_bottom";
            this.statusStrip_bottom.Size = new System.Drawing.Size(818, 22);
            this.statusStrip_bottom.TabIndex = 1;
            this.statusStrip_bottom.Text = "statusStrip1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView_postBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.webBrowser_content, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 25);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(818, 437);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // dataGridView_postBox
            // 
            this.dataGridView_postBox.AllowUserToAddRows = false;
            this.dataGridView_postBox.AllowUserToDeleteRows = false;
            this.dataGridView_postBox.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_postBox.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.from,
            this.subject,
            this.dateIncoming});
            this.dataGridView_postBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_postBox.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView_postBox.Location = new System.Drawing.Point(3, 3);
            this.dataGridView_postBox.MultiSelect = false;
            this.dataGridView_postBox.Name = "dataGridView_postBox";
            this.dataGridView_postBox.ReadOnly = true;
            this.dataGridView_postBox.RowHeadersVisible = false;
            this.dataGridView_postBox.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_postBox.Size = new System.Drawing.Size(280, 431);
            this.dataGridView_postBox.TabIndex = 0;
            // 
            // webBrowser_content
            // 
            this.webBrowser_content.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser_content.Location = new System.Drawing.Point(289, 3);
            this.webBrowser_content.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser_content.Name = "webBrowser_content";
            this.webBrowser_content.Size = new System.Drawing.Size(526, 431);
            this.webBrowser_content.TabIndex = 1;
            // 
            // from
            // 
            this.from.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.from.HeaderText = "От";
            this.from.Name = "from";
            this.from.ReadOnly = true;
            this.from.Width = 45;
            // 
            // subject
            // 
            this.subject.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.subject.HeaderText = "Тема";
            this.subject.Name = "subject";
            this.subject.ReadOnly = true;
            // 
            // dateIncoming
            // 
            this.dateIncoming.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.dateIncoming.HeaderText = "Дата";
            this.dateIncoming.Name = "dateIncoming";
            this.dateIncoming.ReadOnly = true;
            this.dateIncoming.Width = 58;
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(818, 484);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.statusStrip_bottom);
            this.Controls.Add(this.toolStrip_top);
            this.Name = "fMain";
            this.Text = "Почта";
            this.toolStrip_top.ResumeLayout(false);
            this.toolStrip_top.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_postBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip_top;
        private System.Windows.Forms.ToolStripButton tSButton_recive;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tSButton_config;
        private System.Windows.Forms.StatusStrip statusStrip_bottom;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridView_postBox;
        private System.Windows.Forms.WebBrowser webBrowser_content;
        private System.Windows.Forms.DataGridViewTextBoxColumn from;
        private System.Windows.Forms.DataGridViewTextBoxColumn subject;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateIncoming;
    }
}