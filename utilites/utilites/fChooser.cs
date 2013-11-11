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
            }

            isSelected = true;

            Close();
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
