using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll.utilites;
using com.sbs.dll;

namespace com.sbs.gui.users
{
    public partial class fSearch : Form
    {
        DBaccess dbAccess = new DBaccess();
        DataTable dtResult = new DataTable();

        public fSearch()
        {
            InitializeComponent();

            splitContainer1.IsSplitterFixed = true;
            splitContainer1.FixedPanel = FixedPanel.Panel1;

            dataGridView_main.AutoGenerateColumns = false;
            dataGridView_main.Columns["id"].DataPropertyName = "id";
            dataGridView_main.Columns["fio"].DataPropertyName = "fio";
            dataGridView_main.Columns["login"].DataPropertyName = "login";
            dataGridView_main.Columns["xkey"].DataPropertyName = "xkey";
        }

        private void button_key_Click(object sender, EventArgs e)
        {
            fMIFare fMiFare = new fMIFare();
            if (fMiFare.ShowDialog() != DialogResult.OK) return;

            textBox_key.Text = fMiFare.keyId;
        }

        private void button_find_Click(object sender, EventArgs e)
        {
            dataGridView_main.DataSource = null;
            find();
        }

        private void find()
        {
            string fio = textBox_fio.Text.Trim() + "%";
            string login = textBox_login.Text.Trim() + "%";
            string key = textBox_key.Text.Trim() + "%";

            if (!(fio.Length != 0 || login.Length != 0 || key.Length != 0))
            {
                MessageBox.Show("Укажите хотя бы один параметр.", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (string.Empty.Equals(fio)) fio = "%";
            if (string.Empty.Equals(login)) login = "%";
            if (string.Empty.Equals(key)) key = "%";

            try
            {
                dtResult = dbAccess.searchUsers(GValues.DBMode, fio, login, key);
            }
            catch (Exception exc)
            {
                uMessage.Show("Неудалось получить данные.", exc, SystemIcons.Information);
                return;
            }

            dataGridView_main.DataSource = dtResult;
        }
    }
}
