namespace com.sbs.dll.utilites
{
    partial class fMessage_Exception
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_ok = new System.Windows.Forms.Button();
            this.tabControl_main = new System.Windows.Forms.TabControl();
            this.tabPage_desc = new System.Windows.Forms.TabPage();
            this.textBox_message = new System.Windows.Forms.TextBox();
            this.tabPage_adv = new System.Windows.Forms.TabPage();
            this.textBox_exception = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.tabControl_main.SuspendLayout();
            this.tabPage_desc.SuspendLayout();
            this.tabPage_adv.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_ok);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(2, 142);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(459, 38);
            this.panel1.TabIndex = 1;
            // 
            // button_ok
            // 
            this.button_ok.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.button_ok.Location = new System.Drawing.Point(200, 10);
            this.button_ok.Name = "button_ok";
            this.button_ok.Size = new System.Drawing.Size(75, 23);
            this.button_ok.TabIndex = 0;
            this.button_ok.Text = "Ок";
            this.button_ok.UseVisualStyleBackColor = true;
            this.button_ok.Click += new System.EventHandler(this.button_ok_Click);
            // 
            // tabControl_main
            // 
            this.tabControl_main.Controls.Add(this.tabPage_desc);
            this.tabControl_main.Controls.Add(this.tabPage_adv);
            this.tabControl_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_main.Location = new System.Drawing.Point(2, 2);
            this.tabControl_main.Name = "tabControl_main";
            this.tabControl_main.SelectedIndex = 0;
            this.tabControl_main.Size = new System.Drawing.Size(459, 140);
            this.tabControl_main.TabIndex = 2;
            // 
            // tabPage_desc
            // 
            this.tabPage_desc.Controls.Add(this.textBox_message);
            this.tabPage_desc.Location = new System.Drawing.Point(4, 22);
            this.tabPage_desc.Name = "tabPage_desc";
            this.tabPage_desc.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_desc.Size = new System.Drawing.Size(451, 114);
            this.tabPage_desc.TabIndex = 0;
            this.tabPage_desc.Text = "Описание";
            this.tabPage_desc.UseVisualStyleBackColor = true;
            // 
            // textBox_message
            // 
            this.textBox_message.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_message.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_message.Location = new System.Drawing.Point(3, 3);
            this.textBox_message.Multiline = true;
            this.textBox_message.Name = "textBox_message";
            this.textBox_message.ReadOnly = true;
            this.textBox_message.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_message.Size = new System.Drawing.Size(445, 108);
            this.textBox_message.TabIndex = 0;
            // 
            // tabPage_adv
            // 
            this.tabPage_adv.Controls.Add(this.textBox_exception);
            this.tabPage_adv.Location = new System.Drawing.Point(4, 22);
            this.tabPage_adv.Name = "tabPage_adv";
            this.tabPage_adv.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_adv.Size = new System.Drawing.Size(451, 114);
            this.tabPage_adv.TabIndex = 1;
            this.tabPage_adv.Text = "Дополнительно";
            this.tabPage_adv.UseVisualStyleBackColor = true;
            // 
            // textBox_exception
            // 
            this.textBox_exception.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_exception.Location = new System.Drawing.Point(3, 3);
            this.textBox_exception.Multiline = true;
            this.textBox_exception.Name = "textBox_exception";
            this.textBox_exception.ReadOnly = true;
            this.textBox_exception.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_exception.Size = new System.Drawing.Size(445, 108);
            this.textBox_exception.TabIndex = 0;
            // 
            // fMessage_Exception
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 182);
            this.Controls.Add(this.tabControl_main);
            this.Controls.Add(this.panel1);
            this.Name = "fMessage_Exception";
            this.Padding = new System.Windows.Forms.Padding(2);
            this.Text = "fMessage_Exception";
            this.panel1.ResumeLayout(false);
            this.tabControl_main.ResumeLayout(false);
            this.tabPage_desc.ResumeLayout(false);
            this.tabPage_desc.PerformLayout();
            this.tabPage_adv.ResumeLayout(false);
            this.tabPage_adv.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_ok;
        private System.Windows.Forms.TabControl tabControl_main;
        private System.Windows.Forms.TabPage tabPage_desc;
        private System.Windows.Forms.TextBox textBox_message;
        private System.Windows.Forms.TabPage tabPage_adv;
        private System.Windows.Forms.TextBox textBox_exception;
    }
}