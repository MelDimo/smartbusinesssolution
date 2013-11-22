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
using System.Data.SqlClient;

namespace com.sbs.gui.references.currency
{
    public partial class fCourse : Form
    {
        Currency oCurrency;
        DateTime dateOld; // предыдущая дата
        private string formMode; // В каком режиме диалог "EDIT"/"ADD"

        public fCourse(Currency pCurrency)
        {
            oCurrency = pCurrency;

            if (oCurrency.IdCourse == 0) formMode = "ADD";
            else formMode = "EDIT";

            InitializeComponent();
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            bool retVal = false;
            try
            {
                retVal = saveData();
            }
            catch (Exception exc) { uMessage.Show("Ошибка обработки данных", exc, SystemIcons.Error); return; }

            if (!retVal) return;

            MessageBox.Show("Данные успешно сохранены.", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
            DialogResult = DialogResult.OK;
        }

        private bool saveData()
        {
            string errMessage = "Заполнены не все обязательные поля:";

            if (!errMessage.Equals("Заполнены не все обязательные поля:"))
            {
                uMessage.Show(errMessage, SystemIcons.Information);
                return false;
            }

            SqlConnection con = new DBCon().getConnection("offline");
            SqlCommand command = null;
            DataTable dt = new DataTable();
            try
            {
                con.Open();

                command = con.CreateCommand();

                command.Parameters.Add("ref_currency", SqlDbType.Int).Value = oCurrency.id;
                command.Parameters.Add("multiplicity", SqlDbType.Int).Value = oCurrency.multiplicity;
                command.Parameters.Add("course", SqlDbType.Decimal).Value = oCurrency.course;
                command.Parameters.Add("date_start", SqlDbType.DateTime).Value = oCurrency.dateStart;

                if (dateOld == oCurrency.dateStart) formMode = "EDIT";
                else formMode = "ADD";

                switch (formMode)
                {
                    case "ADD":
                        command.CommandText = "INSERT INTO ref_currency_course(ref_currency,    multiplicity,   course,     date_start)" +
                                                                    " VALUES (@ref_currency,    @multiplicity,  @course,    @date_start)";
                        break;

                    case "EDIT":
                        command.CommandText = "UPDATE ref_currency_course SET ref_currency = @ref_currency," +
                                                                    " multiplicity = @multiplicity," +
                                                                    " course = @course," +
                                                                    " date_start = @date_start" +
                                                " WHERE date_start = @date_start";
                        break;

                    default:
                        throw new Exception("Неудалось определить в каком режиме работает форма!");
                }

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            return true;
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void fCourse_Shown(object sender, EventArgs e)
        {
            textBox_currency.DataBindings.Add("Text", oCurrency, "description");
            textBox_multiplicity.DataBindings.Add("Text", oCurrency, "multiplicity");
            numUpDown_course.DataBindings.Add("Text", oCurrency, "course");
            dTimePicker_date.DataBindings.Add("Value", oCurrency, "dateStart");
        }
    }
}
