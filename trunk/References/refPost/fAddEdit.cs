using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using com.sbs.dll;
using com.sbs.dll.utilites;

namespace com.sbs.gui.references.post
{
    public partial class fAddEdit : Form
    {
        DataTable dtStatus = new DataTable();

        public fAddEdit()
        {
            InitializeComponent();

            getRefStatus();
        }

        private void getRefStatus()
        {
            SqlConnection con = new DBCon().getConnection("offline");
            SqlCommand command = null;
            try
            {
                con.Open();
                command = con.CreateCommand();
                command.CommandText = "SELECT id, name FROM ref_status";

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtStatus.Load(dr);
                }
                con.Close();

                if (dtStatus.Rows.Count == 0) throw new Exception("Таблица справочников не содержит данных");
            }
            catch (Exception exc) { uMessage.Show("Ошибка обработки данных", exc, SystemIcons.Error); return; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            comboBox_status.DataSource = dtStatus;
            comboBox_status.ValueMember = "id";
            comboBox_status.DisplayMember = "name";
        }

        private void button_ok_Click(object sender, EventArgs e)
        {

        }

        private void button_apply_Click(object sender, EventArgs e)
        {

        }

        private void button_cancel_Click(object sender, EventArgs e)
        {

        }
    }
}
