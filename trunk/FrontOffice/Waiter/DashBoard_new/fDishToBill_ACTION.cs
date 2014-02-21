using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll;
using com.sbs.dll.utilites;

namespace com.sbs.gui.dashboard
{
    public partial class fDishToBill_ACTION : Form
    {
        private DTO_DBoard.Dish oDish;
        private DTO_DBoard.Bill oBill;

        DBaccess dbAccess = new DBaccess();

        public fDishToBill_ACTION(DTO_DBoard.Bill pBill, DTO_DBoard.Dish pDish)
        {
            oBill = pBill;
            oDish = pDish;

            InitializeComponent();

            label_name.Text = oDish.name;
        }

        private void fDishToBill_ACTION_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            { 
                case Keys.Escape:
                    DialogResult = DialogResult.Cancel;
                    break;
            }
        }

        private void button_refuse_Click(object sender, EventArgs e)
        {
            fRefuse fref = new fRefuse();
            fref.trackBar_count.Minimum = 0;
            fref.trackBar_count.Maximum = int.Parse(oDish.count.ToString("F0"));
            fref.trackBar_count.Value = int.Parse(oDish.count.ToString("F0"));
            if(fref.ShowDialog() == DialogResult.Cancel) return;

            try
            {
                refuseDish(fref.trackBar_count.Value);
            }
            catch (Exception exc) { uMessage.Show("Неудалось поместить блюда в хранилище.", exc, SystemIcons.Information); return; }

            DialogResult = DialogResult.OK;
        }

        private void refuseDish(int pNewCount)
        {
            dbAccess.dishRefuse("offline", oBill, oDish, pNewCount);
        }
    }
}
