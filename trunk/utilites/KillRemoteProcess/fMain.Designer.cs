namespace KillRemoteProcess
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
            this.button_terminate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_host = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_procName = new System.Windows.Forms.TextBox();
            this.textBox_UpDown = new com.sbs.dll.utilites.Controls.textBoxNumeric();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_terminate
            // 
            this.button_terminate.Location = new System.Drawing.Point(230, 17);
            this.button_terminate.Name = "button_terminate";
            this.button_terminate.Size = new System.Drawing.Size(75, 46);
            this.button_terminate.TabIndex = 3;
            this.button_terminate.Text = "Terminate";
            this.button_terminate.UseVisualStyleBackColor = true;
            this.button_terminate.Click += new System.EventHandler(this.button_terminate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Remote host";
            // 
            // textBox_host
            // 
            this.textBox_host.Location = new System.Drawing.Point(99, 17);
            this.textBox_host.Name = "textBox_host";
            this.textBox_host.Size = new System.Drawing.Size(125, 20);
            this.textBox_host.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Process name";
            // 
            // textBox_procName
            // 
            this.textBox_procName.Location = new System.Drawing.Point(99, 43);
            this.textBox_procName.Name = "textBox_procName";
            this.textBox_procName.Size = new System.Drawing.Size(125, 20);
            this.textBox_procName.TabIndex = 2;
            // 
            // textBox_UpDown
            // 
            this.textBox_UpDown.AutoSize = true;
            this.textBox_UpDown.Location = new System.Drawing.Point(368, 20);
            this.textBox_UpDown.Name = "textBox_UpDown";
            this.textBox_UpDown.Size = new System.Drawing.Size(77, 26);
            this.textBox_UpDown.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(186, 117);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(178, 42);
            this.button1.TabIndex = 5;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 222);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox_UpDown);
            this.Controls.Add(this.textBox_procName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_host);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_terminate);
            this.Name = "fMain";
            this.Text = "Terminate remote process";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_terminate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_host;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_procName;
        private com.sbs.dll.utilites.Controls.textBoxNumeric textBox_UpDown;
        private System.Windows.Forms.Button button1;
    }
}

