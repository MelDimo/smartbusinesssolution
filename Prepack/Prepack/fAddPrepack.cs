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
    public partial class fAddPrepack : Form
    {
        private DBaccess dbAccess = new DBaccess();

        public int selectedPrepack;
        public int selectedUnit;

        public fAddPrepack(int selectedUnit)
        {
            InitializeComponent();

            dataGridView_prepack.AutoGenerateColumns = false;

            initData(selectedUnit);
        }

        private void initData(int selectedUnit)
        {
            DataTable dt = new DataTable();

            try
            {
                dt = dbAccess.getPrepack("offline", selectedUnit);
            }
            catch (Exception exc) { uMessage.Show("Ошибка обработки данных", exc, SystemIcons.Error); return; }

            dataGridView_prepack.DataSource = dt;
            dataGridView_prepack.Columns["id"].DataPropertyName = "id";
            dataGridView_prepack.Columns["code"].DataPropertyName = "code";
            dataGridView_prepack.Columns["name"].DataPropertyName = "name";
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            int selectedPrepackId;
            if (dataGridView_prepack.SelectedRows.Count == 0)
            {
                uMessage.Show("Укажите желаемый продукт", SystemIcons.Information);
                return;
            }

            selectedPrepackId = (int)dataGridView_prepack.SelectedRows[0].Cells["id"].Value;

            try
            {
                dbAccess.addPrepackInfo("offline", selectedPrepack, 0, selectedPrepackId);
            }
            catch (Exception exc) { uMessage.Show("Ошибка обработки данных", exc, SystemIcons.Error); return; }

            DialogResult = DialogResult.OK;
        }
    }
}
