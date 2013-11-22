using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace com.sbs.dll.utilites
{
    public partial class fChooser : Form
    {
        public Object[] xData;

        private string sourceName;  // Расматриваю значение и принимаю решение какие данные возвращать

        private bool isSelected = false;

        /// <summary>
        /// Форма отображает табличные данные для выбора
        /// </summary>
        /// <param name="pSourceName">Наименование источника данных</param>
        public fChooser(string pSourceName)
        {
            sourceName = pSourceName;

            InitializeComponent();

            dataGridView_main.AutoGenerateColumns = false;
        }

        private void dataGridView_main_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            { 
                case Keys.Enter:
                    e.SuppressKeyPress = true;
                    makeChoice();
                    break;

                case Keys.Escape:
                    Close();
                    break;

            }
        }

        private void makeChoice()
        {
            if (dataGridView_main.SelectedRows.Count == 0) return;

            switch (sourceName)
            {
                case "UNIT":
                    returnUnit();
                    break;

                case "ACCOUNT":
                    returnAccount();
                    break;

                case"CONTRACTOR":
                    returnContractor();
                    break;

                case "CURRENCY":
                    returnCurrency();
                    break;

                case "ITEMSRAW":
                    returnItemsRaw();
                    break;

                case "NOMENCLATURE":
                    returnNomenclature();
                    break;

                case "MEASURE":
                    returnMeasure();
                    break;

                case "GETTMC":
                    returnTMC();
                    break;

            }

            isSelected = true;

            Close();
        }

        private void returnTMC()
        {
            int id;
            string name;
            string name_short;

            id = (int)dataGridView_main.SelectedRows[0].Cells["id"].Value;
            name = dataGridView_main.SelectedRows[0].Cells["name"].Value.ToString();
            name_short = dataGridView_main.SelectedRows[0].Cells["name_short"].Value.ToString();

            xData = new object[] { id, name, name_short };
        }

        private void returnMeasure()
        {
            int id;
            string name;
            string name_short;

            id = (int)dataGridView_main.SelectedRows[0].Cells["id"].Value;
            name = dataGridView_main.SelectedRows[0].Cells["name"].Value.ToString();
            name_short = dataGridView_main.SelectedRows[0].Cells["name_short"].Value.ToString();

            xData = new object[] { id, name, name_short };
        }

        private void returnNomenclature()
        {
            int id;
            string name;

            id = (int)dataGridView_main.SelectedRows[0].Cells["id"].Value;
            name = dataGridView_main.SelectedRows[0].Cells["name"].Value.ToString();

            xData = new object[] { id, name };
        }

        private void returnItemsRaw()
        {
            int id;
            string name;

            id = (int)dataGridView_main.SelectedRows[0].Cells["id"].Value;
            name = dataGridView_main.SelectedRows[0].Cells["name"].Value.ToString();

            xData = new object[] { id, name };

        }

        private void returnCurrency()
        {
            int IdCurrency;
            string code;
            string name;
            string description;
            int ref_currency_type;
            string ref_currency_type_name;
            int idCourse;
            int multiplicity;
            decimal course;

            IdCurrency = (int)dataGridView_main.SelectedRows[0].Cells["IdCurrency"].Value;
            code = dataGridView_main.SelectedRows[0].Cells["code"].Value.ToString() ;
            name = dataGridView_main.SelectedRows[0].Cells["name"].Value.ToString();
            description = dataGridView_main.SelectedRows[0].Cells["description"].Value.ToString();
            ref_currency_type = (int)dataGridView_main.SelectedRows[0].Cells["ref_currency_type"].Value;
            ref_currency_type_name = dataGridView_main.SelectedRows[0].Cells["ref_currency_type_name"].Value.ToString();
            idCourse = (int)dataGridView_main.SelectedRows[0].Cells["idCourse"].Value;
            multiplicity = (int)dataGridView_main.SelectedRows[0].Cells["multiplicity"].Value;
            course = (decimal)dataGridView_main.SelectedRows[0].Cells["course"].Value;

            xData = new object[] { IdCurrency, code, name, description, ref_currency_type, ref_currency_type_name, idCourse, multiplicity, course };
        }

        private void returnContractor()
        {
            int xId;
            string xName;

            xId = (int)dataGridView_main.SelectedRows[0].Cells["id"].Value;
            xName = dataGridView_main.SelectedRows[0].Cells["name"].Value.ToString();

            xData = new object[] { xId, xName };
        }

        private void returnAccount()
        {
            int xId;
            string xGroup_II;
            string xName;

            xId = (int)dataGridView_main.SelectedRows[0].Cells["id"].Value;
            xGroup_II = dataGridView_main.SelectedRows[0].Cells["group_II"].Value.ToString();
            xName = dataGridView_main.SelectedRows[0].Cells["name"].Value.ToString();

            xData = new object[] { xId, xGroup_II, xName };
        }

        private void returnUnit()
        {
            int xId;
            string xName;

            xId = (int)dataGridView_main.SelectedRows[0].Cells["id"].Value;
            xName = dataGridView_main.SelectedRows[0].Cells["name"].Value.ToString();

            xData = new object[] { xId, xName };
        }

        private void button_select_Click(object sender, EventArgs e)
        {
            makeChoice();
        }

        private void fChooser_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (isSelected) DialogResult = DialogResult.OK;
            else DialogResult = DialogResult.Cancel;
        }
    }
}
