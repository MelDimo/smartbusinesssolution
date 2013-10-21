namespace com.sbs.gui.DashBoard
{
    partial class fAnotherWaiter
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.listBox_waiter = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBox_waiter);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(401, 198);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Кому передаем счет?";
            // 
            // listBox_waiter
            // 
            this.listBox_waiter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_waiter.FormattingEnabled = true;
            this.listBox_waiter.Location = new System.Drawing.Point(3, 16);
            this.listBox_waiter.Name = "listBox_waiter";
            this.listBox_waiter.Size = new System.Drawing.Size(395, 179);
            this.listBox_waiter.TabIndex = 0;
            this.listBox_waiter.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listBox_waiter_KeyDown);
            // 
            // fAnotherWaiter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 204);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.KeyPreview = true;
            this.Name = "fAnotherWaiter";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Shown += new System.EventHandler(this.fAnotherWaiter_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fAnotherWaiter_KeyDown);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.ListBox listBox_waiter;

    }
}