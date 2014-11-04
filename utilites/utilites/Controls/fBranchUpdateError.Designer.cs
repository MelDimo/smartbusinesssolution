namespace com.sbs.dll.utilites
{
    partial class fBranchUpdateError
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
            this.richTextBox_errors = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // richTextBox_errors
            // 
            this.richTextBox_errors.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox_errors.Location = new System.Drawing.Point(0, 0);
            this.richTextBox_errors.Name = "richTextBox_errors";
            this.richTextBox_errors.Size = new System.Drawing.Size(484, 399);
            this.richTextBox_errors.TabIndex = 0;
            this.richTextBox_errors.Text = "";
            // 
            // fBranchUpdateError
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 399);
            this.Controls.Add(this.richTextBox_errors);
            this.MinimizeBox = false;
            this.Name = "fBranchUpdateError";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "fBranchUpdateError";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBox_errors;

    }
}