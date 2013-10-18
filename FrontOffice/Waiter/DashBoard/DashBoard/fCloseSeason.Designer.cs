namespace com.sbs.gui.DashBoard
{
    partial class fCloseSeason
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
            this.panel_top = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label_seasonName = new System.Windows.Forms.Label();
            this.label_seasonNumber = new System.Windows.Forms.Label();
            this.flowLayoutPanel_waiter = new System.Windows.Forms.FlowLayoutPanel();
            this.panel_main = new System.Windows.Forms.Panel();
            this.panel_waiterInfo = new System.Windows.Forms.Panel();
            this.dataGridView_waiterInfo = new System.Windows.Forms.DataGridView();
            this.billId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.billNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.billSum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.billStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel_top.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel_main.SuspendLayout();
            this.panel_waiterInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_waiterInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_top
            // 
            this.panel_top.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(45)))), ((int)(((byte)(36)))));
            this.panel_top.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_top.Controls.Add(this.tableLayoutPanel1);
            this.panel_top.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_top.Location = new System.Drawing.Point(0, 0);
            this.panel_top.Name = "panel_top";
            this.panel_top.Size = new System.Drawing.Size(548, 62);
            this.panel_top.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label_seasonName, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_seasonNumber, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(546, 60);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label_seasonName
            // 
            this.label_seasonName.AutoSize = true;
            this.label_seasonName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_seasonName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_seasonName.ForeColor = System.Drawing.Color.White;
            this.label_seasonName.Location = new System.Drawing.Point(3, 30);
            this.label_seasonName.Name = "label_seasonName";
            this.label_seasonName.Size = new System.Drawing.Size(540, 30);
            this.label_seasonName.TabIndex = 1;
            this.label_seasonName.Text = "label2";
            this.label_seasonName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_seasonNumber
            // 
            this.label_seasonNumber.AutoSize = true;
            this.label_seasonNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_seasonNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_seasonNumber.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(220)))), ((int)(((byte)(0)))));
            this.label_seasonNumber.Location = new System.Drawing.Point(3, 0);
            this.label_seasonNumber.Name = "label_seasonNumber";
            this.label_seasonNumber.Size = new System.Drawing.Size(540, 30);
            this.label_seasonNumber.TabIndex = 0;
            this.label_seasonNumber.Text = "Закрытие смены №";
            this.label_seasonNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // flowLayoutPanel_waiter
            // 
            this.flowLayoutPanel_waiter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel_waiter.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel_waiter.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel_waiter.Name = "flowLayoutPanel_waiter";
            this.flowLayoutPanel_waiter.Size = new System.Drawing.Size(546, 368);
            this.flowLayoutPanel_waiter.TabIndex = 0;
            // 
            // panel_main
            // 
            this.panel_main.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_main.Controls.Add(this.flowLayoutPanel_waiter);
            this.panel_main.Location = new System.Drawing.Point(0, 64);
            this.panel_main.Name = "panel_main";
            this.panel_main.Size = new System.Drawing.Size(548, 370);
            this.panel_main.TabIndex = 1;
            // 
            // panel_waiterInfo
            // 
            this.panel_waiterInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_waiterInfo.Controls.Add(this.dataGridView_waiterInfo);
            this.panel_waiterInfo.Location = new System.Drawing.Point(0, 64);
            this.panel_waiterInfo.Name = "panel_waiterInfo";
            this.panel_waiterInfo.Size = new System.Drawing.Size(548, 366);
            this.panel_waiterInfo.TabIndex = 0;
            // 
            // dataGridView_waiterInfo
            // 
            this.dataGridView_waiterInfo.AllowUserToAddRows = false;
            this.dataGridView_waiterInfo.AllowUserToDeleteRows = false;
            this.dataGridView_waiterInfo.AllowUserToResizeColumns = false;
            this.dataGridView_waiterInfo.AllowUserToResizeRows = false;
            this.dataGridView_waiterInfo.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView_waiterInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_waiterInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.billId,
            this.idStatus,
            this.billNumber,
            this.billSum,
            this.billStatus});
            this.dataGridView_waiterInfo.Location = new System.Drawing.Point(3, 3);
            this.dataGridView_waiterInfo.MultiSelect = false;
            this.dataGridView_waiterInfo.Name = "dataGridView_waiterInfo";
            this.dataGridView_waiterInfo.RowHeadersVisible = false;
            this.dataGridView_waiterInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_waiterInfo.Size = new System.Drawing.Size(540, 358);
            this.dataGridView_waiterInfo.TabIndex = 0;
            this.dataGridView_waiterInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_waiterInfo_CellClick);
            this.dataGridView_waiterInfo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView_waiterInfo_KeyDown);
            // 
            // billId
            // 
            this.billId.HeaderText = "billId";
            this.billId.Name = "billId";
            this.billId.Visible = false;
            // 
            // idStatus
            // 
            this.idStatus.HeaderText = "idStatus";
            this.idStatus.Name = "idStatus";
            this.idStatus.Visible = false;
            // 
            // billNumber
            // 
            this.billNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.billNumber.HeaderText = "Счет №";
            this.billNumber.Name = "billNumber";
            // 
            // billSum
            // 
            this.billSum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.billSum.HeaderText = "Сумма счета";
            this.billSum.Name = "billSum";
            // 
            // billStatus
            // 
            this.billStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.billStatus.HeaderText = "Состояние счета";
            this.billStatus.Name = "billStatus";
            // 
            // fCloseSeason
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 433);
            this.ControlBox = false;
            this.Controls.Add(this.panel_main);
            this.Controls.Add(this.panel_waiterInfo);
            this.Controls.Add(this.panel_top);
            this.KeyPreview = true;
            this.Name = "fCloseSeason";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Shown += new System.EventHandler(this.fCloseSeason_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fCloseSeason_KeyDown);
            this.panel_top.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel_main.ResumeLayout(false);
            this.panel_waiterInfo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_waiterInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_top;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label_seasonName;
        private System.Windows.Forms.Label label_seasonNumber;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_waiter;
        private System.Windows.Forms.Panel panel_main;
        private System.Windows.Forms.Panel panel_waiterInfo;
        private System.Windows.Forms.DataGridView dataGridView_waiterInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn billId;
        private System.Windows.Forms.DataGridViewTextBoxColumn idStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn billNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn billSum;
        private System.Windows.Forms.DataGridViewTextBoxColumn billStatus;
    }
}