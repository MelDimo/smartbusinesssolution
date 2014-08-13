namespace com.sbs.dll.utilites
{
    partial class fAddDishToBill_topping
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
            this.cartedishes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView_toppGroup = new System.Windows.Forms.TreeView();
            this.dataGridView_topping = new System.Windows.Forms.DataGridView();
            this.isSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toppings_groups = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_topping)).BeginInit();
            this.SuspendLayout();
            // 
            // cartedishes
            // 
            this.cartedishes.HeaderText = "cartedishes";
            this.cartedishes.Name = "cartedishes";
            this.cartedishes.Visible = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView_toppGroup);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(5);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView_topping);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(5);
            this.splitContainer1.Size = new System.Drawing.Size(657, 525);
            this.splitContainer1.SplitterDistance = 293;
            this.splitContainer1.TabIndex = 1;
            this.splitContainer1.TabStop = false;
            // 
            // treeView_toppGroup
            // 
            this.treeView_toppGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_toppGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.treeView_toppGroup.HideSelection = false;
            this.treeView_toppGroup.Location = new System.Drawing.Point(5, 5);
            this.treeView_toppGroup.Name = "treeView_toppGroup";
            this.treeView_toppGroup.Size = new System.Drawing.Size(283, 515);
            this.treeView_toppGroup.TabIndex = 0;
            this.treeView_toppGroup.TabStop = false;
            this.treeView_toppGroup.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_toppGroup_AfterSelect);
            // 
            // dataGridView_topping
            // 
            this.dataGridView_topping.AllowUserToAddRows = false;
            this.dataGridView_topping.AllowUserToDeleteRows = false;
            this.dataGridView_topping.AllowUserToResizeColumns = false;
            this.dataGridView_topping.AllowUserToResizeRows = false;
            this.dataGridView_topping.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_topping.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.isSelected,
            this.id,
            this.toppings_groups,
            this.cartedishes,
            this.name,
            this.price});
            this.dataGridView_topping.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView_topping.Location = new System.Drawing.Point(5, 5);
            this.dataGridView_topping.MultiSelect = false;
            this.dataGridView_topping.Name = "dataGridView_topping";
            this.dataGridView_topping.RowHeadersVisible = false;
            this.dataGridView_topping.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView_topping.Size = new System.Drawing.Size(350, 515);
            this.dataGridView_topping.TabIndex = 4;
            this.dataGridView_topping.TabStop = false;
            this.dataGridView_topping.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridView_topping_KeyDown);
            // 
            // isSelected
            // 
            this.isSelected.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.isSelected.HeaderText = " ";
            this.isSelected.Name = "isSelected";
            this.isSelected.ReadOnly = true;
            this.isSelected.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.isSelected.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.isSelected.Width = 35;
            // 
            // id
            // 
            this.id.HeaderText = "id";
            this.id.Name = "id";
            this.id.Visible = false;
            // 
            // toppings_groups
            // 
            this.toppings_groups.HeaderText = "toppings_groups";
            this.toppings_groups.Name = "toppings_groups";
            this.toppings_groups.Visible = false;
            // 
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.name.HeaderText = "Блюдо";
            this.name.Name = "name";
            this.name.ReadOnly = true;
            // 
            // price
            // 
            this.price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.price.HeaderText = "Цена";
            this.price.Name = "price";
            this.price.ReadOnly = true;
            this.price.Width = 58;
            // 
            // fAddDishToBill_topping
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 525);
            this.ControlBox = false;
            this.Controls.Add(this.splitContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "fAddDishToBill_topping";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.fAddDishToBill_topping_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fAddDishToBill_topping_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_topping)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn cartedishes;
        private System.Windows.Forms.SplitContainer splitContainer1;
        internal System.Windows.Forms.TreeView treeView_toppGroup;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn toppings_groups;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        internal System.Windows.Forms.DataGridView dataGridView_topping;
    }
}