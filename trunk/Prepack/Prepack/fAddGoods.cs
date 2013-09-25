using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll.utilites;

namespace com.sbs.gui.prepack
{
    public partial class fAddGoods : Form
    {
        private DBaccess dbAccess = new DBaccess();

        public int selectedPrepack;

        public fAddGoods()
        {
            InitializeComponent();

            dataGridView_goods.AutoGenerateColumns = false;

            initData();
        }

        private void initData()
        {
            DataTable dt = new DataTable();

            try
            {
                dt = dbAccess.getAllGoods("offline");
            }
            catch (Exception exc) { uMessage.Show("Ошибка обработки данных", exc, SystemIcons.Error); return; }

            dataGridView_goods.DataSource = dt;
            dataGridView_goods.Columns["id"].DataPropertyName = "id";
            dataGridView_goods.Columns["code"].DataPropertyName = "code";
            dataGridView_goods.Columns["name"].DataPropertyName = "name";
            dataGridView_goods.Columns["manufacturer"].DataPropertyName = "manufacturer";
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            int selectedGood;
            if(dataGridView_goods.SelectedRows.Count == 0)
            {
                uMessage.Show("Укажите желаемый продукт", SystemIcons.Information);
                return;
            }

            selectedGood = (int)dataGridView_goods.SelectedRows[0].Cells["id"].Value;

            try
            {
                dbAccess.addGoodsInfo("offline", selectedPrepack, selectedGood, 0);
            }
            catch (Exception exc) { uMessage.Show("Ошибка обработки данных", exc, SystemIcons.Error); return; }
            
            DialogResult = DialogResult.OK;
        }
    }
}
