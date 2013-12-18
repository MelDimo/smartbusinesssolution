using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll.utilites;

namespace com.sbs.gui.DashBoard
{
    public partial class fDishAddTopping : Form
    {
        public List<oDishes> arrDishesToping = new List<oDishes>();
        private DBaccess DbAccess = new DBaccess();

        public fDishAddTopping(DataTable dtToppings)
        {
            InitializeComponent();

            dataGridView_main.AutoGenerateColumns = false;
            
            dataGridView_main.DataSource = dtToppings;
            dataGridView_main.Columns["id"].DataPropertyName = "id";
            dataGridView_main.Columns["name"].DataPropertyName = "name";
            dataGridView_main.AutoGenerateColumns = false;
        }

        private void dataGridView_main_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            { 
                case Keys.Enter:
                    if (dataGridView_main.SelectedRows.Count == 0) return;

                    foreach (DataGridViewRow dgvr in dataGridView_main.Rows)
                    {
                        if ((bool)dgvr.Cells["isChecked"].Value)
                            arrDishesToping.Add(new oDishes()
                            {
                                Id = (int)dgvr.Cells["id"].Value,
                                Name = dgvr.Cells["name"].Value.ToString(),
                                Count = 1,
                                Price = 0,
                                Discount = 0
                            });
                    }
                    
                    DialogResult = DialogResult.OK;
                    break;

                case Keys.Escape:
                    DialogResult = DialogResult.Cancel;
                    break;

                case Keys.Space:
                    if (dataGridView_main.SelectedRows.Count == 0) return;
                    dataGridView_main.CurrentRow.Cells["isChecked"].Value = !(bool)dataGridView_main.CurrentRow.Cells["isChecked"].Value;
                    break;
            }
        }
    }
}
