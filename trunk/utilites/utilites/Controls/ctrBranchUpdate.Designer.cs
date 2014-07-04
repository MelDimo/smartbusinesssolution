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
            this.label_branchName = new System.Windows.Forms.Label();
            this.progressBar_info = new System.Windows.Forms.ProgressBar();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_host
            // 
            this.button_host.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_host.Location = new System.Drawing.Point(0, 0);
            this.button_host.Name = "button_host";
            this.button_host.Size = new System.Drawing.Size(335, 53);
            this.button_host.TabIndex = 0;
            this.button_host.UseVisualStyleBackColor = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label_branchName, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.progressBar_info, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(335, 53);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label_branchName
            // 
            this.label_branchName.AutoSize = true;
            this.label_branchName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_branchName.Location = new System.Drawing.Point(3, 0);
            this.label_branchName.Name = "label_branchName";
            this.label_branchName.Size = new System.Drawing.Size(329, 26);
            this.label_branchName.TabIndex = 0;
            this.label_branchName.Text = "label_branchName";
            this.label_branchName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // progressBar_info
            // 
            this.progressBar_info.Dock = System.Windows.Forms.DockStyle.Fill;
            this.progressBar_info.Location = new System.Drawing.Point(3, 29);
            this.progressBar_info.Name = "progressBar_info";
            this.progressBar_info.Size = new System.Drawing.Size(329, 21);
            this.progressBar_info.TabIndex = 1;
            // 
            // ctrBranchUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.button_host);
            this.Name = "ctrBranchUpdate";
            this.Size = new System.Drawing.Size(335, 53);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_host;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label_branchName;
        private System.Windows.Forms.ProgressBar progressBar_info;
    }
}
