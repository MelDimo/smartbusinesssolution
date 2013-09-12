namespace com.sbs.gui.compositionorg
{
    partial class fCompOrg
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fCompOrg));
            this.splitContainer_org = new System.Windows.Forms.SplitContainer();
            this.groupBox_org = new System.Windows.Forms.GroupBox();
            this.statusStrip_org = new System.Windows.Forms.StatusStrip();
            this.toolStrip_org = new System.Windows.Forms.ToolStrip();
            this.tSButton_orgAdd = new System.Windows.Forms.ToolStripButton();
            this.tSButton_orgEdit = new System.Windows.Forms.ToolStripButton();
            this.tSButton_orgDel = new System.Windows.Forms.ToolStripButton();
            this.splitContainer_branch = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.statusStrip_branch = new System.Windows.Forms.StatusStrip();
            this.toolStrip_branch = new System.Windows.Forms.ToolStrip();
            this.tSButton_branchAdd = new System.Windows.Forms.ToolStripButton();
            this.tSButton_branchEdit = new System.Windows.Forms.ToolStripButton();
            this.tSButton_branchDel = new System.Windows.Forms.ToolStripButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.toolStrip_unit = new System.Windows.Forms.ToolStrip();
            this.tSButton_unitAdd = new System.Windows.Forms.ToolStripButton();
            this.tSButton_unitEdit = new System.Windows.Forms.ToolStripButton();
            this.tSButton_unitDel = new System.Windows.Forms.ToolStripButton();
            this.statusStrip_unit = new System.Windows.Forms.StatusStrip();
            this.listBox_org = new System.Windows.Forms.ListBox();
            this.listBox_branch = new System.Windows.Forms.ListBox();
            this.listBox_unit = new System.Windows.Forms.ListBox();
            this.splitContainer_org.Panel1.SuspendLayout();
            this.splitContainer_org.Panel2.SuspendLayout();
            this.splitContainer_org.SuspendLayout();
            this.groupBox_org.SuspendLayout();
            this.toolStrip_org.SuspendLayout();
            this.splitContainer_branch.Panel1.SuspendLayout();
            this.splitContainer_branch.Panel2.SuspendLayout();
            this.splitContainer_branch.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.toolStrip_branch.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.toolStrip_unit.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer_org
            // 
            this.splitContainer_org.BackColor = System.Drawing.SystemColors.Control;
            this.splitContainer_org.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_org.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_org.Name = "splitContainer_org";
            // 
            // splitContainer_org.Panel1
            // 
            this.splitContainer_org.Panel1.Controls.Add(this.groupBox_org);
            this.splitContainer_org.Panel1.Padding = new System.Windows.Forms.Padding(5);
            // 
            // splitContainer_org.Panel2
            // 
            this.splitContainer_org.Panel2.Controls.Add(this.splitContainer_branch);
            this.splitContainer_org.Size = new System.Drawing.Size(830, 527);
            this.splitContainer_org.SplitterDistance = 276;
            this.splitContainer_org.TabIndex = 0;
            // 
            // groupBox_org
            // 
            this.groupBox_org.Controls.Add(this.listBox_org);
            this.groupBox_org.Controls.Add(this.statusStrip_org);
            this.groupBox_org.Controls.Add(this.toolStrip_org);
            this.groupBox_org.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_org.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox_org.Location = new System.Drawing.Point(5, 5);
            this.groupBox_org.Name = "groupBox_org";
            this.groupBox_org.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox_org.Size = new System.Drawing.Size(266, 517);
            this.groupBox_org.TabIndex = 3;
            this.groupBox_org.TabStop = false;
            this.groupBox_org.Text = "Организации";
            // 
            // statusStrip_org
            // 
            this.statusStrip_org.Location = new System.Drawing.Point(5, 490);
            this.statusStrip_org.Name = "statusStrip_org";
            this.statusStrip_org.Size = new System.Drawing.Size(256, 22);
            this.statusStrip_org.TabIndex = 0;
            this.statusStrip_org.Text = "statusStrip1";
            // 
            // toolStrip_org
            // 
            this.toolStrip_org.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip_org.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSButton_orgAdd,
            this.tSButton_orgEdit,
            this.tSButton_orgDel});
            this.toolStrip_org.Location = new System.Drawing.Point(5, 18);
            this.toolStrip_org.Name = "toolStrip_org";
            this.toolStrip_org.Size = new System.Drawing.Size(256, 25);
            this.toolStrip_org.TabIndex = 1;
            this.toolStrip_org.Text = "toolStrip1";
            // 
            // tSButton_orgAdd
            // 
            this.tSButton_orgAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSButton_orgAdd.Image = ((System.Drawing.Image)(resources.GetObject("tSButton_orgAdd.Image")));
            this.tSButton_orgAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSButton_orgAdd.Name = "tSButton_orgAdd";
            this.tSButton_orgAdd.Size = new System.Drawing.Size(23, 22);
            this.tSButton_orgAdd.Text = "tSButton_orgAdd";
            this.tSButton_orgAdd.Click += new System.EventHandler(this.tSButton_orgAdd_Click);
            // 
            // tSButton_orgEdit
            // 
            this.tSButton_orgEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSButton_orgEdit.Image = ((System.Drawing.Image)(resources.GetObject("tSButton_orgEdit.Image")));
            this.tSButton_orgEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSButton_orgEdit.Name = "tSButton_orgEdit";
            this.tSButton_orgEdit.Size = new System.Drawing.Size(23, 22);
            this.tSButton_orgEdit.Text = "tSButton_orgEdit";
            this.tSButton_orgEdit.Click += new System.EventHandler(this.tSButton_orgEdit_Click);
            // 
            // tSButton_orgDel
            // 
            this.tSButton_orgDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSButton_orgDel.Image = ((System.Drawing.Image)(resources.GetObject("tSButton_orgDel.Image")));
            this.tSButton_orgDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSButton_orgDel.Name = "tSButton_orgDel";
            this.tSButton_orgDel.Size = new System.Drawing.Size(23, 22);
            this.tSButton_orgDel.Text = "tSButton_orgDel";
            this.tSButton_orgDel.Click += new System.EventHandler(this.tSButton_orgDel_Click);
            // 
            // splitContainer_branch
            // 
            this.splitContainer_branch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_branch.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_branch.Name = "splitContainer_branch";
            // 
            // splitContainer_branch.Panel1
            // 
            this.splitContainer_branch.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer_branch.Panel1.Padding = new System.Windows.Forms.Padding(5);
            // 
            // splitContainer_branch.Panel2
            // 
            this.splitContainer_branch.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer_branch.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainer_branch.Size = new System.Drawing.Size(550, 527);
            this.splitContainer_branch.SplitterDistance = 249;
            this.splitContainer_branch.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.listBox_branch);
            this.groupBox1.Controls.Add(this.statusStrip_branch);
            this.groupBox1.Controls.Add(this.toolStrip_branch);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(5, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox1.Size = new System.Drawing.Size(239, 517);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Заведения";
            // 
            // statusStrip_branch
            // 
            this.statusStrip_branch.Location = new System.Drawing.Point(5, 490);
            this.statusStrip_branch.Name = "statusStrip_branch";
            this.statusStrip_branch.Size = new System.Drawing.Size(229, 22);
            this.statusStrip_branch.TabIndex = 0;
            this.statusStrip_branch.Text = "statusStrip2";
            // 
            // toolStrip_branch
            // 
            this.toolStrip_branch.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip_branch.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSButton_branchAdd,
            this.tSButton_branchEdit,
            this.tSButton_branchDel});
            this.toolStrip_branch.Location = new System.Drawing.Point(5, 18);
            this.toolStrip_branch.Name = "toolStrip_branch";
            this.toolStrip_branch.Size = new System.Drawing.Size(229, 25);
            this.toolStrip_branch.TabIndex = 1;
            this.toolStrip_branch.Text = "toolStrip2";
            // 
            // tSButton_branchAdd
            // 
            this.tSButton_branchAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSButton_branchAdd.Image = ((System.Drawing.Image)(resources.GetObject("tSButton_branchAdd.Image")));
            this.tSButton_branchAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSButton_branchAdd.Name = "tSButton_branchAdd";
            this.tSButton_branchAdd.Size = new System.Drawing.Size(23, 22);
            this.tSButton_branchAdd.Text = "toolStripButton4";
            this.tSButton_branchAdd.Click += new System.EventHandler(this.tSButton_branchAdd_Click);
            // 
            // tSButton_branchEdit
            // 
            this.tSButton_branchEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSButton_branchEdit.Image = ((System.Drawing.Image)(resources.GetObject("tSButton_branchEdit.Image")));
            this.tSButton_branchEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSButton_branchEdit.Name = "tSButton_branchEdit";
            this.tSButton_branchEdit.Size = new System.Drawing.Size(23, 22);
            this.tSButton_branchEdit.Text = "toolStripButton5";
            this.tSButton_branchEdit.Click += new System.EventHandler(this.tSButton_branchEdit_Click);
            // 
            // tSButton_branchDel
            // 
            this.tSButton_branchDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSButton_branchDel.Image = ((System.Drawing.Image)(resources.GetObject("tSButton_branchDel.Image")));
            this.tSButton_branchDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSButton_branchDel.Name = "tSButton_branchDel";
            this.tSButton_branchDel.Size = new System.Drawing.Size(23, 22);
            this.tSButton_branchDel.Text = "toolStripButton6";
            this.tSButton_branchDel.Click += new System.EventHandler(this.tSButton_branchDel_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.listBox_unit);
            this.groupBox2.Controls.Add(this.toolStrip_unit);
            this.groupBox2.Controls.Add(this.statusStrip_unit);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(5, 5);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(5);
            this.groupBox2.Size = new System.Drawing.Size(287, 517);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Подразделения";
            // 
            // toolStrip_unit
            // 
            this.toolStrip_unit.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip_unit.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tSButton_unitAdd,
            this.tSButton_unitEdit,
            this.tSButton_unitDel});
            this.toolStrip_unit.Location = new System.Drawing.Point(5, 18);
            this.toolStrip_unit.Name = "toolStrip_unit";
            this.toolStrip_unit.Size = new System.Drawing.Size(277, 25);
            this.toolStrip_unit.TabIndex = 1;
            this.toolStrip_unit.Text = "toolStrip3";
            // 
            // tSButton_unitAdd
            // 
            this.tSButton_unitAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSButton_unitAdd.Image = ((System.Drawing.Image)(resources.GetObject("tSButton_unitAdd.Image")));
            this.tSButton_unitAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSButton_unitAdd.Name = "tSButton_unitAdd";
            this.tSButton_unitAdd.Size = new System.Drawing.Size(23, 22);
            this.tSButton_unitAdd.Text = "toolStripButton7";
            this.tSButton_unitAdd.Click += new System.EventHandler(this.tSButton_unitAdd_Click);
            // 
            // tSButton_unitEdit
            // 
            this.tSButton_unitEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSButton_unitEdit.Image = ((System.Drawing.Image)(resources.GetObject("tSButton_unitEdit.Image")));
            this.tSButton_unitEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSButton_unitEdit.Name = "tSButton_unitEdit";
            this.tSButton_unitEdit.Size = new System.Drawing.Size(23, 22);
            this.tSButton_unitEdit.Text = "toolStripButton8";
            this.tSButton_unitEdit.Click += new System.EventHandler(this.tSButton_unitEdit_Click);
            // 
            // tSButton_unitDel
            // 
            this.tSButton_unitDel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tSButton_unitDel.Image = ((System.Drawing.Image)(resources.GetObject("tSButton_unitDel.Image")));
            this.tSButton_unitDel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tSButton_unitDel.Name = "tSButton_unitDel";
            this.tSButton_unitDel.Size = new System.Drawing.Size(23, 22);
            this.tSButton_unitDel.Text = "toolStripButton9";
            this.tSButton_unitDel.Click += new System.EventHandler(this.tSButton_unitDel_Click);
            // 
            // statusStrip_unit
            // 
            this.statusStrip_unit.Location = new System.Drawing.Point(5, 490);
            this.statusStrip_unit.Name = "statusStrip_unit";
            this.statusStrip_unit.Size = new System.Drawing.Size(277, 22);
            this.statusStrip_unit.TabIndex = 0;
            this.statusStrip_unit.Text = "statusStrip3";
            // 
            // listBox_org
            // 
            this.listBox_org.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_org.FormattingEnabled = true;
            this.listBox_org.Location = new System.Drawing.Point(5, 43);
            this.listBox_org.Name = "listBox_org";
            this.listBox_org.Size = new System.Drawing.Size(256, 447);
            this.listBox_org.TabIndex = 2;
            // 
            // listBox_branch
            // 
            this.listBox_branch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_branch.FormattingEnabled = true;
            this.listBox_branch.Location = new System.Drawing.Point(5, 43);
            this.listBox_branch.Name = "listBox_branch";
            this.listBox_branch.Size = new System.Drawing.Size(229, 447);
            this.listBox_branch.TabIndex = 2;
            // 
            // listBox_unit
            // 
            this.listBox_unit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox_unit.FormattingEnabled = true;
            this.listBox_unit.Location = new System.Drawing.Point(5, 43);
            this.listBox_unit.Name = "listBox_unit";
            this.listBox_unit.Size = new System.Drawing.Size(277, 447);
            this.listBox_unit.TabIndex = 2;
            // 
            // fCompOrg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(830, 527);
            this.Controls.Add(this.splitContainer_org);
            this.MinimumSize = new System.Drawing.Size(846, 565);
            this.Name = "fCompOrg";
            this.Text = "Организационная модель";
            this.splitContainer_org.Panel1.ResumeLayout(false);
            this.splitContainer_org.Panel2.ResumeLayout(false);
            this.splitContainer_org.ResumeLayout(false);
            this.groupBox_org.ResumeLayout(false);
            this.groupBox_org.PerformLayout();
            this.toolStrip_org.ResumeLayout(false);
            this.toolStrip_org.PerformLayout();
            this.splitContainer_branch.Panel1.ResumeLayout(false);
            this.splitContainer_branch.Panel2.ResumeLayout(false);
            this.splitContainer_branch.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.toolStrip_branch.ResumeLayout(false);
            this.toolStrip_branch.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.toolStrip_unit.ResumeLayout(false);
            this.toolStrip_unit.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer_org;
        private System.Windows.Forms.ToolStrip toolStrip_org;
        private System.Windows.Forms.StatusStrip statusStrip_org;
        private System.Windows.Forms.SplitContainer splitContainer_branch;
        private System.Windows.Forms.ToolStrip toolStrip_branch;
        private System.Windows.Forms.StatusStrip statusStrip_branch;
        private System.Windows.Forms.ToolStrip toolStrip_unit;
        private System.Windows.Forms.StatusStrip statusStrip_unit;
        private System.Windows.Forms.ToolStripButton tSButton_orgAdd;
        private System.Windows.Forms.ToolStripButton tSButton_orgEdit;
        private System.Windows.Forms.ToolStripButton tSButton_orgDel;
        private System.Windows.Forms.ToolStripButton tSButton_branchAdd;
        private System.Windows.Forms.ToolStripButton tSButton_branchEdit;
        private System.Windows.Forms.ToolStripButton tSButton_branchDel;
        private System.Windows.Forms.ToolStripButton tSButton_unitAdd;
        private System.Windows.Forms.ToolStripButton tSButton_unitEdit;
        private System.Windows.Forms.ToolStripButton tSButton_unitDel;
        private System.Windows.Forms.GroupBox groupBox_org;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox listBox_org;
        private System.Windows.Forms.ListBox listBox_branch;
        private System.Windows.Forms.ListBox listBox_unit;
    }
}

