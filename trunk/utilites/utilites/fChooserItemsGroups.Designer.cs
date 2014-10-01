namespace com.sbs.dll.utilites
{
    partial class fChooserItemsGroups
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
            this.button_select = new System.Windows.Forms.Button();
            this.groupBox_unit = new System.Windows.Forms.GroupBox();
            this.treeView_main = new System.Windows.Forms.TreeView();
            this.panel1.SuspendLayout();
            this.groupBox_unit.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_select);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 504);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(361, 32);
            this.panel1.TabIndex = 5;
            // 
            // button_select
            // 
            this.button_select.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_select.Location = new System.Drawing.Point(0, 0);
            this.button_select.Name = "button_select";
            this.button_select.Size = new System.Drawing.Size(361, 32);
            this.button_select.TabIndex = 0;
            this.button_select.Text = "Выбрать";
            this.button_select.UseVisualStyleBackColor = true;
            this.button_select.Click += new System.EventHandler(this.button_select_Click);
            // 
            // groupBox_unit
            // 
            this.groupBox_unit.Controls.Add(this.treeView_main);
            this.groupBox_unit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_unit.Location = new System.Drawing.Point(0, 0);
            this.groupBox_unit.Name = "groupBox_unit";
            this.groupBox_unit.Size = new System.Drawing.Size(361, 504);
            this.groupBox_unit.TabIndex = 6;
            this.groupBox_unit.TabStop = false;
            this.groupBox_unit.Text = "Группы";
            // 
            // treeView_main
            // 
            this.treeView_main.CheckBoxes = true;
            this.treeView_main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_main.FullRowSelect = true;
            this.treeView_main.HideSelection = false;
            this.treeView_main.Location = new System.Drawing.Point(3, 16);
            this.treeView_main.Name = "treeView_main";
            this.treeView_main.Size = new System.Drawing.Size(355, 485);
            this.treeView_main.TabIndex = 49;
            // 
            // fChooserItemsGroups
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 536);
            this.Controls.Add(this.groupBox_unit);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fChooserItemsGroups";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "fChooserItemsGroups";
            this.Shown += new System.EventHandler(this.fChooserItemsGroups_Shown);
            this.panel1.ResumeLayout(false);
            this.groupBox_unit.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_select;
        private System.Windows.Forms.GroupBox groupBox_unit;
        private System.Windows.Forms.TreeView treeView_main;
    }
}