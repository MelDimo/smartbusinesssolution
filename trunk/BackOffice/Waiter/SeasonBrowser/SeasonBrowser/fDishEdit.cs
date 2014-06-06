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

namespace com.sbs.gui.seasonbrowser
{
    public partial class fDishEdit : Form
    {
        DBaccess dbAccess = new DBaccess();

        DBaccess.Role curRole;
        
        DTO_DBoard.Dish oDish;
        Filter oFilter;

        public fDishEdit(Filter pFilter, DTO_DBoard.Dish pDish, DBaccess.Role pCurRole)
        {
            oDish = pDish;
            oFilter = pFilter;
            curRole = pCurRole;

            InitializeComponent();
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            if (curRole == DBaccess.Role.BACKOFFICE && oFilter.isSeasonOpen)
            {
                MessageBox.Show("Вы не можете вносить изменения в открытую смену.", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            oDish.count = numericUpDown_count.Value;
            oDish.refStatus = (int)comboBox_status.SelectedValue;

            try
            {
                dbAccess.saveDish(oFilter, oDish);
            }
            catch (Exception exc) { uMessage.Show("Неудалось сохранить блюдо.", exc, SystemIcons.Information); return; }

            DialogResult = DialogResult.OK;
        }

        private void fDishEdit_Shown(object sender, EventArgs e)
        {
            switch (curRole)
            {
                case DBaccess.Role.BACKOFFICE:
                    comboBox_status.Enabled = false;
                    break;

                case DBaccess.Role.FRONTOFFICE:
                    comboBox_status.Enabled = false;
                    numericUpDown_count.Enabled = false;
                    break;
            }

            fillControls();
        }

        private void fillControls()
        {
            textBox_id.Text = oDish.id.ToString();
            textBox_name.Text = oDish.name;
            textBox_price.Text = oDish.price.ToString();
            numericUpDown_count.Value = oDish.count;

            comboBox_status.SelectedValue = oDish.refStatus;

        }

        private void button_history_Click(object sender, EventArgs e)
        {
            DataTable dt = dbAccess.getDishesLog(oFilter, oDish);

            fHistory fHis = new fHistory();
            fHis.dataGridView_main.DataSource = dt;
            fHis.ShowDialog();
            
        }
    }
}
