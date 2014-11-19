using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll;

namespace com.sbs.gui.dashboard
{
    public partial class fDealsDishes : Form
    {
        public DTO_DBoard.Dish oDish;
        private List<DTO_DBoard.Dish> oLDishes;
        private decimal xBonusDishes;

        public fDealsDishes(List<DTO_DBoard.Dish> pLDishes, string pDealsName, decimal pBonusDishes)
        {
            oLDishes = pLDishes;
            xBonusDishes = pBonusDishes;

            InitializeComponent();

            label_dealsName.Text = pDealsName;

            dataGridView_main.AutoGenerateColumns = false;
        }

        private void fDealsDishes_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            { 
                case Keys.Escape:
                    DialogResult = DialogResult.Cancel;
                    break;

                case Keys.Enter:
                    e.SuppressKeyPress = true;
                    if (dataGridView_main.SelectedRows.Count == 0) return;
                    oDish = oLDishes[dataGridView_main.SelectedRows[0].Index];
                    oDish.count = xBonusDishes;
                    oDish.minStep = xBonusDishes;
                    DialogResult = DialogResult.OK;
                    break;
            }
        }

        private void fDealsDishes_Shown(object sender, EventArgs e)
        {
            var blistBonus = new BindingSource();
            blistBonus.DataSource = oLDishes;

            dataGridView_main.DataSource = blistBonus;
            dataGridView_main.Columns["refDishes"].DataPropertyName = "refDishes";
            dataGridView_main.Columns["name"].DataPropertyName = "name";
        }
    }
}
