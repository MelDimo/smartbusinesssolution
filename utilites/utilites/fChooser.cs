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

                case "ADDITIONALCOST":
                    returnAddCost();
                    break;

                case "REFDISHES":
                    returnRefDishes();
                    break;

                case "USERGROUPS":
                    returnUserGroups();
                    break;

                case "USERS":
                    returnUsers();
                    break;

                case "ACL":
                    returnACL();
                    break;
            }

            isSelected = true;

            Close();
        }

        private void returnACL()
        {
            int xId;
            string xName;

            xId = (int)dataGridView_main.SelectedRows[0].Cells["id"].Value;
            xName = dataGridView_main.SelectedRows[0].Cells["name"].Value.ToString();

            xData = new object[] { xId, xName };
        }

        private void returnUsers()
        {
            List<int> id = new List<int>(); ;
            string name = string.Empty;

            foreach (DataGridViewRow dr in dataGridView_main.Rows)
            {
                if ((bool)dr.Cells["checked"].Value)
                {
                    id.Add((int)dr.Cells["id"].Value);
                    name += dr.Cells["fio"].Value.ToString() + "; ";
                }
            }
            name.TrimEnd(new char[] { ';', ' ' });

            xData = new object[] { id, name };
        }

        private void returnUserGroups()
        {
            List<int> id = new List<int>(); ;
            string name = string.Empty;

            foreach (DataGridViewRow dr in dataGridView_main.Rows)
            {
                if ((bool)dr.Cells["checked"].Value)
                {
                    id.Add((int)dr.Cells["id"].Value);
                    name += dr.Cells["name"].Value.ToString() + "; ";
                }
            }
            name.TrimEnd(new char[] { ';', ' ' });

            xData = new object[] { id, name };
        }

        private void returnRefDishes()
        {
            int id;
            string name;
            decimal price;
            int ref_status;
            int ref_printers_type;

            id = (int)dataGridView_main.SelectedRows[0].Cells["id"].Value;
            name = dataGridView_main.SelectedRows[0].Cells["name"].Value.ToString();
            price = (decimal)dataGridView_main.SelectedRows[0].Cells["price"].Value;
            ref_status = (int)dataGridView_main.SelectedRows[0].Cells["ref_status"].Value;
            ref_printers_type = (int)dataGridView_main.SelectedRows[0].Cells["ref_printers_type"].Value;

            xData = new object[] { id, name, price, ref_status, ref_printers_type };
        }

        private void returnAddCost()
        {
            int id;
            string name;
            int ref_accounts;
            string ref_accounts_name;
            int ref_contractor;
            string ref_contractor_name;

            id = (int)dataGridView_main.SelectedRows[0].Cells["id"].Value;
            name = dataGridView_main.SelectedRows[0].Cells["name"].Value.ToString();
            ref_accounts = (int)dataGridView_main.SelectedRows[0].Cells["ref_accounts"].Value;
            ref_accounts_name = dataGridView_main.SelectedRows[0].Cells["ref_accounts_name"].Value.ToString();
            ref_contractor = (int)dataGridView_main.SelectedRows[0].Cells["ref_contractor"].Value;
            ref_contractor_name = dataGridView_main.SelectedRows[0].Cells["ref_contractor_name"].Value.ToString();

            xData = new object[] { id, name, ref_accounts, ref_accounts_name, ref_contractor, ref_contractor_name };
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
