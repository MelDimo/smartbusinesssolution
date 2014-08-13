namespace com.sbs.dll.utilites.Controls
{
    partial class textBoxNumeric
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
            this.textBox_numb = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox_numb
            // 
            this.textBox_numb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_numb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_numb.Location = new System.Drawing.Point(0, 0);
            this.textBox_numb.Name = "textBox_numb";
            this.textBox_numb.ReadOnly = true;
            this.textBox_numb.Size = new System.Drawing.Size(77, 26);
            this.textBox_numb.TabIndex = 0;
            this.textBox_numb.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBox_numb_KeyDown);
            // 
            // textBoxNumeric
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.Controls.Add(this.textBox_numb);
            this.Name = "textBoxNumeric";
            this.Size = new System.Drawing.Size(77, 26);
            this.Load += new System.EventHandler(this.textBoxNumeric_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_numb;
    }
}
