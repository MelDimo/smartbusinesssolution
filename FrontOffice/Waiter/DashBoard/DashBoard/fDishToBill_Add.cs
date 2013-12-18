using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace com.sbs.gui.DashBoard
{
    public partial class fDishToBill_Add : Form
    {
        oDishes Dishes;
        public List<oDishes> arrDishesToping = new List<oDishes>();

        public fDishToBill_Add(ref oDishes pDishes, DataTable dtToppings)
        {
            Dishes = pDishes;

            InitializeComponent();

            textBox_price.Text = Dishes.Price.ToString();
            label_dishName.Text = Dishes.Name;

            if (dtToppings.Rows.Count > 0) //-------------------- Есть топинги
            {
                this.Height = 272;

                dataGridView_main.AutoGenerateColumns = false;
                
                dataGridView_main.DataSource = dtToppings;
                dataGridView_main.Columns["id"].DataPropertyName = "id";
                dataGridView_main.Columns["name"].DataPropertyName = "name";
                dataGridView_main.Columns["isSelected"].DataPropertyName = "isSelected";
            }
        }

        private void fDishToBill_Add_KeyDown(object sender, KeyEventArgs e)
        {
            float xCount = 0;

            switch (e.KeyCode)
            { 
                case Keys.Enter:
                    getToppings();
                    if (float.TryParse(textBox_count.Text, out xCount))
                    {
                        Dishes.Count = xCount;
                        DialogResult = DialogResult.OK;
                    }
                    break;

                case Keys.Escape:
                    DialogResult = DialogResult.Cancel;
                    break;

                case Keys.Space:
                    if (dataGridView_main.SelectedRows.Count == 0) return;
                    if (dataGridView_main.CurrentRow.Cells["isChecked"].Value == null)
                        dataGridView_main.CurrentRow.Cells["isChecked"].Value = true;
                    else
                        dataGridView_main.CurrentRow.Cells["isChecked"].Value = !(bool)dataGridView_main.CurrentRow.Cells["isChecked"].Value;
                    break;
            }
        }

        private void getToppings()
        {
            if (dataGridView_main.SelectedRows.Count == 0) return;

            foreach (DataGridViewRow dgvr in dataGridView_main.Rows)
            {
                if (dgvr.Cells["isChecked"].Value == null) continue;
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
        }

        private void fDishToBill_Add_Shown(object sender, EventArgs e)
        {

            foreach (DataGridViewRow dr in dataGridView_main.Rows)
            {
                if ((int)dr.Cells["isSelected"].Value == 1)
                    dr.Cells["isChecked"].Value = true;
            }
        }
    }
}
