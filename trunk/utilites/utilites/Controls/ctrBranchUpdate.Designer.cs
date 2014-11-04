namespace com.sbs.dll.utilites
{
    partial class ctrBranchUpdate
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button_host = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.progressBar_info = new System.Windows.Forms.ProgressBar();
            this.label_srvInfo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label_branchName = new System.Windows.Forms.Label();
            this.button_error = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_host
            // 
            this.button_host.AutoSize = true;
            this.button_host.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_host.Location = new System.Drawing.Point(1, 1);
            this.button_host.Name = "button_host";
            this.button_host.Size = new System.Drawing.Size(331, 62);
            this.button_host.TabIndex = 0;
            this.button_host.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.progressBar_info, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_srvInfo, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(1, 1);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(331, 62);
            this.tableLayoutPanel1.TabIndex = 1;
            this.tableLayoutPanel1.Click += new System.EventHandler(this.selectBtnHost);
            // 
            // progressBar_info
            // 
            this.progressBar_info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar_info.Location = new System.Drawing.Point(3, 30);
            this.progressBar_info.Name = "progressBar_info";
            this.progressBar_info.Size = new System.Drawing.Size(325, 14);
            this.progressBar_info.TabIndex = 1;
            this.progressBar_info.Click += new System.EventHandler(this.selectBtnHost);
            // 
            // label_srvInfo
            // 
            this.label_srvInfo.AutoSize = true;
            this.label_srvInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_srvInfo.Location = new System.Drawing.Point(3, 47);
            this.label_srvInfo.Name = "label_srvInfo";
            this.label_srvInfo.Size = new System.Drawing.Size(325, 15);
            this.label_srvInfo.TabIndex = 2;
            this.label_srvInfo.Text = "label_srvInfo";
            this.label_srvInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_srvInfo.Click += new System.EventHandler(this.selectBtnHost);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label_branchName);
            this.panel1.Controls.Add(this.button_error);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(325, 21);
            this.panel1.TabIndex = 3;
            // 
            // label_branchName
            // 
            this.label_branchName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_branchName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_branchName.Location = new System.Drawing.Point(0, 0);
            this.label_branchName.Name = "label_branchName";
            this.label_branchName.Size = new System.Drawing.Size(269, 21);
            this.label_branchName.TabIndex = 0;
            this.label_branchName.Text = "label_branchName";
            this.label_branchName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_branchName.Click += new System.EventHandler(this.selectBtnHost);
            // 
            // button_error
            // 
            this.button_error.Dock = System.Windows.Forms.DockStyle.Right;
            this.button_error.Location = new System.Drawing.Point(269, 0);
            this.button_error.Name = "button_error";
            this.button_error.Size = new System.Drawing.Size(56, 21);
            this.button_error.TabIndex = 1;
            this.button_error.Text = "ошибка";
            this.button_error.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button_error.UseVisualStyleBackColor = true;
            this.button_error.Visible = false;
            this.button_error.Click += new System.EventHandler(this.button_error_Click);
            // 
            // ctrBranchUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.button_host);
            this.Name = "ctrBranchUpdate";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Size = new System.Drawing.Size(333, 64);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label_branchName;
        private System.Windows.Forms.Label label_srvInfo;
        public System.Windows.Forms.Button button_host;
        public System.Windows.Forms.ProgressBar progressBar_info;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Button button_error;
    }
}
