namespace Host4Test
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
            this.button_open = new System.Windows.Forms.Button();
            this.button_openMainForm = new System.Windows.Forms.Button();
            this.label_info = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_open
            // 
            this.button_open.Location = new System.Drawing.Point(254, 43);
            this.button_open.Name = "button_open";
            this.button_open.Size = new System.Drawing.Size(93, 30);
            this.button_open.TabIndex = 0;
            this.button_open.Text = "Открыть";
            this.button_open.UseVisualStyleBackColor = true;
            this.button_open.Click += new System.EventHandler(this.button_open_Click);
            // 
            // button_openMainForm
            // 
            this.button_openMainForm.Location = new System.Drawing.Point(263, 141);
            this.button_openMainForm.Name = "button_openMainForm";
            this.button_openMainForm.Size = new System.Drawing.Size(126, 23);
            this.button_openMainForm.TabIndex = 1;
            this.button_openMainForm.Text = "OpenMainForm";
            this.button_openMainForm.UseVisualStyleBackColor = true;
            this.button_openMainForm.Click += new System.EventHandler(this.button_openMainForm_Click);
            // 
            // label_info
            // 
            this.label_info.AutoSize = true;
            this.label_info.Location = new System.Drawing.Point(95, 186);
            this.label_info.Name = "label_info";
            this.label_info.Size = new System.Drawing.Size(52, 13);
            this.label_info.TabIndex = 2;
            this.label_info.Text = "label_info";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(272, 222);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "IMail";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 463);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label_info);
            this.Controls.Add(this.button_openMainForm);
            this.Controls.Add(this.button_open);
            this.Name = "fMain";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fMain_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_open;
        private System.Windows.Forms.Button button_openMainForm;
        private System.Windows.Forms.Label label_info;
        private System.Windows.Forms.Button button1;
    }
}

