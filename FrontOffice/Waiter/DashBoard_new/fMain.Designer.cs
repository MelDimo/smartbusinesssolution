﻿using System.Windows.Forms;
using System.Drawing;
namespace com.sbs.gui.dashboard
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.panel_bills = new System.Windows.Forms.Panel();
            this.panel_dishes = new System.Windows.Forms.Panel();
            this.button_trapFocus = new System.Windows.Forms.Button();
            this.groupBox_bills = new com.sbs.gui.dashboard.extGroupBox();
            this.flowLayoutPanel_bills = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_printBill = new System.Windows.Forms.Button();
            this.button_newBill = new System.Windows.Forms.Button();
            this.groupBox_billDish = new com.sbs.gui.dashboard.extGroupBox();
            this.flowLayoutPanel_billInfo = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox_billInfo = new com.sbs.gui.dashboard.extGroupBox();
            this.flowLayoutPanel_billEdit = new System.Windows.Forms.FlowLayoutPanel();
            this.panel_billInfo = new System.Windows.Forms.Panel();
            this.groupBox_groups = new com.sbs.gui.dashboard.extGroupBox();
            this.treeView_CarteGroups = new System.Windows.Forms.TreeView();
            this.groupBox_dish = new com.sbs.gui.dashboard.extGroupBox();
            this.flowLayoutPanel_dish = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.panel_bills.SuspendLayout();
            this.panel_dishes.SuspendLayout();
            this.groupBox_bills.SuspendLayout();
            this.panel1.SuspendLayout();
            this.groupBox_billDish.SuspendLayout();
            this.groupBox_billInfo.SuspendLayout();
            this.groupBox_groups.SuspendLayout();
            this.groupBox_dish.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox_bills, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.groupBox_billDish, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1127, 694);
            this.tableLayoutPanel1.TabIndex = 0;
            this.tableLayoutPanel1.TabStop = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65F));
            this.tableLayoutPanel2.Controls.Add(this.groupBox_billInfo, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.tableLayoutPanel3, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1127, 694);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel3.Controls.Add(this.groupBox_groups, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.groupBox_dish, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(397, 3);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(727, 688);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // panel_bills
            // 
            this.panel_bills.Controls.Add(this.tableLayoutPanel1);
            this.panel_bills.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_bills.Location = new System.Drawing.Point(0, 0);
            this.panel_bills.Name = "panel_bills";
            this.panel_bills.Size = new System.Drawing.Size(1127, 694);
            this.panel_bills.TabIndex = 1;
            // 
            // panel_dishes
            // 
            this.panel_dishes.Controls.Add(this.tableLayoutPanel2);
            this.panel_dishes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_dishes.Location = new System.Drawing.Point(0, 0);
            this.panel_dishes.Name = "panel_dishes";
            this.panel_dishes.Size = new System.Drawing.Size(1127, 694);
            this.panel_dishes.TabIndex = 2;
            // 
            // button_trapFocus
            // 
            this.button_trapFocus.Location = new System.Drawing.Point(0, 0);
            this.button_trapFocus.Name = "button_trapFocus";
            this.button_trapFocus.Size = new System.Drawing.Size(75, 14);
            this.button_trapFocus.TabIndex = 1;
            this.button_trapFocus.TabStop = false;
            this.button_trapFocus.Text = "button_trapFocus";
            this.button_trapFocus.UseVisualStyleBackColor = true;
            // 
            // groupBox_bills
            // 
            this.groupBox_bills.BorderColor = System.Drawing.Color.Empty;
            this.groupBox_bills.Controls.Add(this.flowLayoutPanel_bills);
            this.groupBox_bills.Controls.Add(this.panel1);
            this.groupBox_bills.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_bills.Location = new System.Drawing.Point(3, 3);
            this.groupBox_bills.Name = "groupBox_bills";
            this.groupBox_bills.Size = new System.Drawing.Size(388, 688);
            this.groupBox_bills.TabIndex = 0;
            this.groupBox_bills.TabStop = false;
            // 
            // flowLayoutPanel_bills
            // 
            this.flowLayoutPanel_bills.AutoScroll = true;
            this.flowLayoutPanel_bills.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel_bills.Location = new System.Drawing.Point(3, 95);
            this.flowLayoutPanel_bills.Name = "flowLayoutPanel_bills";
            this.flowLayoutPanel_bills.Size = new System.Drawing.Size(382, 590);
            this.flowLayoutPanel_bills.TabIndex = 0;
            this.flowLayoutPanel_bills.TabStop = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button_printBill);
            this.panel1.Controls.Add(this.button_newBill);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(3, 16);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(382, 79);
            this.panel1.TabIndex = 1;
            // 
            // button_printBill
            // 
            this.button_printBill.Location = new System.Drawing.Point(84, 8);
            this.button_printBill.Name = "button_printBill";
            this.button_printBill.Size = new System.Drawing.Size(75, 62);
            this.button_printBill.TabIndex = 2;
            this.button_printBill.TabStop = false;
            this.button_printBill.Text = "F5";
            this.button_printBill.UseVisualStyleBackColor = true;
            // 
            // button_newBill
            // 
            this.button_newBill.Location = new System.Drawing.Point(3, 8);
            this.button_newBill.Name = "button_newBill";
            this.button_newBill.Size = new System.Drawing.Size(75, 62);
            this.button_newBill.TabIndex = 0;
            this.button_newBill.TabStop = false;
            this.button_newBill.Text = "F2";
            this.button_newBill.UseVisualStyleBackColor = true;
            this.button_newBill.Click += new System.EventHandler(this.button_newBill_Click);
            // 
            // groupBox_billDish
            // 
            this.groupBox_billDish.BorderColor = System.Drawing.Color.Empty;
            this.groupBox_billDish.Controls.Add(this.flowLayoutPanel_billInfo);
            this.groupBox_billDish.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_billDish.Location = new System.Drawing.Point(397, 3);
            this.groupBox_billDish.Name = "groupBox_billDish";
            this.groupBox_billDish.Size = new System.Drawing.Size(727, 688);
            this.groupBox_billDish.TabIndex = 1;
            this.groupBox_billDish.TabStop = false;
            // 
            // flowLayoutPanel_billInfo
            // 
            this.flowLayoutPanel_billInfo.AutoScroll = true;
            this.flowLayoutPanel_billInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel_billInfo.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel_billInfo.Name = "flowLayoutPanel_billInfo";
            this.flowLayoutPanel_billInfo.Size = new System.Drawing.Size(721, 669);
            this.flowLayoutPanel_billInfo.TabIndex = 0;
            // 
            // groupBox_billInfo
            // 
            this.groupBox_billInfo.BorderColor = System.Drawing.Color.Empty;
            this.groupBox_billInfo.Controls.Add(this.flowLayoutPanel_billEdit);
            this.groupBox_billInfo.Controls.Add(this.panel_billInfo);
            this.groupBox_billInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_billInfo.Location = new System.Drawing.Point(3, 3);
            this.groupBox_billInfo.Name = "groupBox_billInfo";
            this.groupBox_billInfo.Size = new System.Drawing.Size(388, 688);
            this.groupBox_billInfo.TabIndex = 0;
            this.groupBox_billInfo.TabStop = false;
            // 
            // flowLayoutPanel_billEdit
            // 
            this.flowLayoutPanel_billEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel_billEdit.Location = new System.Drawing.Point(3, 105);
            this.flowLayoutPanel_billEdit.Name = "flowLayoutPanel_billEdit";
            this.flowLayoutPanel_billEdit.Size = new System.Drawing.Size(382, 580);
            this.flowLayoutPanel_billEdit.TabIndex = 0;
            // 
            // panel_billInfo
            // 
            this.panel_billInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel_billInfo.Location = new System.Drawing.Point(3, 16);
            this.panel_billInfo.Name = "panel_billInfo";
            this.panel_billInfo.Size = new System.Drawing.Size(382, 89);
            this.panel_billInfo.TabIndex = 1;
            // 
            // groupBox_groups
            // 
            this.groupBox_groups.BorderColor = System.Drawing.Color.Empty;
            this.groupBox_groups.Controls.Add(this.treeView_CarteGroups);
            this.groupBox_groups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_groups.Location = new System.Drawing.Point(3, 3);
            this.groupBox_groups.Name = "groupBox_groups";
            this.groupBox_groups.Size = new System.Drawing.Size(284, 682);
            this.groupBox_groups.TabIndex = 0;
            this.groupBox_groups.TabStop = false;
            // 
            // treeView_CarteGroups
            // 
            this.treeView_CarteGroups.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView_CarteGroups.FullRowSelect = true;
            this.treeView_CarteGroups.HideSelection = false;
            this.treeView_CarteGroups.Location = new System.Drawing.Point(3, 16);
            this.treeView_CarteGroups.Name = "treeView_CarteGroups";
            this.treeView_CarteGroups.Size = new System.Drawing.Size(278, 663);
            this.treeView_CarteGroups.TabIndex = 0;
            this.treeView_CarteGroups.TabStop = false;
            this.treeView_CarteGroups.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView_CarteGroups_AfterSelect);
            // 
            // groupBox_dish
            // 
            this.groupBox_dish.BorderColor = System.Drawing.Color.Empty;
            this.groupBox_dish.Controls.Add(this.flowLayoutPanel_dish);
            this.groupBox_dish.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox_dish.Location = new System.Drawing.Point(293, 3);
            this.groupBox_dish.Name = "groupBox_dish";
            this.groupBox_dish.Size = new System.Drawing.Size(431, 682);
            this.groupBox_dish.TabIndex = 1;
            this.groupBox_dish.TabStop = false;
            // 
            // flowLayoutPanel_dish
            // 
            this.flowLayoutPanel_dish.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel_dish.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel_dish.Name = "flowLayoutPanel_dish";
            this.flowLayoutPanel_dish.Size = new System.Drawing.Size(425, 663);
            this.flowLayoutPanel_dish.TabIndex = 1;
            // 
            // fMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1127, 694);
            this.Controls.Add(this.panel_bills);
            this.Controls.Add(this.panel_dishes);
            this.Controls.Add(this.button_trapFocus);
            this.KeyPreview = true;
            this.Name = "fMain";
            this.Text = "fMain";
            this.Shown += new System.EventHandler(this.fMain_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fMain_KeyDown);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.panel_bills.ResumeLayout(false);
            this.panel_dishes.ResumeLayout(false);
            this.groupBox_bills.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.groupBox_billDish.ResumeLayout(false);
            this.groupBox_billInfo.ResumeLayout(false);
            this.groupBox_groups.ResumeLayout(false);
            this.groupBox_dish.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        //private System.Windows.Forms.GroupBox groupBox_bills;
        private extGroupBox groupBox_bills;
        //private System.Windows.Forms.GroupBox groupBox_billDish;
        private extGroupBox groupBox_billDish;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_billInfo;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_bills;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        //private System.Windows.Forms.GroupBox groupBox_billInfo;
        private extGroupBox groupBox_billInfo;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_billEdit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TreeView treeView_CarteGroups;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel_dish;
        //private System.Windows.Forms.GroupBox groupBox_groups;
        private extGroupBox groupBox_groups;
        //private System.Windows.Forms.GroupBox groupBox_dish;
        private extGroupBox groupBox_dish;
        private Panel panel1;
        private Button button_newBill;
        private Panel panel_bills;
        private Panel panel_dishes;
        private Button button_trapFocus;
        private Panel panel_billInfo;
        private Button button_printBill;
    }

    public class extGroupBox : GroupBox
    {
        private Color borderColor;

        public Color BorderColor
        {
            get { return this.borderColor; }
            set { this.borderColor = value; }
        }
        public extGroupBox()
        {
            //this.borderColor = Color.Black;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Size tSize = TextRenderer.MeasureText(this.Text, this.Font);
            Rectangle borderRect = e.ClipRectangle;
            borderRect.Y += tSize.Height / 2;
            borderRect.Height -= tSize.Height / 2;
            ControlPaint.DrawBorder(e.Graphics, borderRect, this.borderColor, ButtonBorderStyle.Solid);
            Rectangle textRect = e.ClipRectangle;
            textRect.X += 6;
            textRect.Width = tSize.Width;
            textRect.Height = tSize.Height;
            e.Graphics.FillRectangle(new SolidBrush(this.BackColor), textRect);
            e.Graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), textRect);
        }
    }
}