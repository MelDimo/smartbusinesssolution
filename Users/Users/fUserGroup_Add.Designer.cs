namespace com.sbs.gui.users
{
    partial class fUserGroup_Add
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
            this.listBox_groups = new System.Windows.Forms.ListBox();
            this.button_select = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBox_groups);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(209, 263);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Доступные группы";
            // 
            // listBox_groups
            // 
            this.listBox_groups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_groups.FormattingEnabled = true;
            this.listBox_groups.Location = new System.Drawing.Point(3, 16);
            this.listBox_groups.Name = "listBox_groups";
            this.listBox_groups.Size = new System.Drawing.Size(203, 244);
            this.listBox_groups.TabIndex = 0;
            // 
            // button_select
            // 
            this.button_select.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button_select.Location = new System.Drawing.Point(3, 266);
            this.button_select.Name = "button_select";
            this.button_select.Size = new System.Drawing.Size(209, 23);
            this.button_select.TabIndex = 1;
            this.button_select.Text = "Выбрать";
            this.button_select.UseVisualStyleBackColor = true;
            this.button_select.Click += new System.EventHandler(this.button_select_Click);
            // 
            // fUserGroup_Add
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(215, 292);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_select);
            this.Name = "fUserGroup_Add";
            this.Padding = new System.Windows.Forms.Padding(3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "fUserGroup_Add";
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button_select;
        public System.Windows.Forms.ListBox listBox_groups;
    }
}