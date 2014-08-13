using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Diagnostics;

namespace com.sbs.dll.utilites
{
    public partial class fDelivery : Form
    {
        DataTable dtClients;
        DataTable dtCity;
        DataTable dtTariff;
        DataTable dtDrivers;

        DBaccess dbAccess = new DBaccess();

        bool isNewClient = false;

        public DTO_DBoard.Delivery oDelivery;

        public fDelivery(DTO_DBoard.Delivery pDelivery)
        {
            oDelivery = pDelivery;

            InitializeComponent();

            dataGridView_main.AutoGenerateColumns = false;
            dataGridView_main.Columns["id"].DataPropertyName = "id";
            dataGridView_main.Columns["fio"].DataPropertyName = "fio";
            dataGridView_main.Columns["street"].DataPropertyName = "street";

            intiData();
        }

        private void intiData()
        {
            dtTariff = new DataTable();
            dtDrivers = new DataTable();

            setClientInfo();

            comboBox_driver.SelectedValue = oDelivery.driverId;
            comboBox_tariff.SelectedValue = oDelivery.tariff;
            comboBox_city.SelectedValue = oDelivery.deliveryClient.addr_city;

            textBox_cardNumber.Text = oDelivery.cardNumber;
            textBox_comment.Text = oDelivery.comment;

            try
            {
                dtTariff = dbAccess.getTariff(GValues.DBMode);
                dtDrivers = dbAccess.getDrivers(GValues.DBMode);
                dtCity = dbAccess.getCity(GValues.DBMode);
            }
            catch (Exception exc)
            {
                uMessage.Show("Неудалось загрузить справочники.", exc, SystemIcons.Information);
                setEnabled(false);
                return;
            }

            comboBox_city.DataSource = dtCity;
            comboBox_city.ValueMember = "id";
            comboBox_city.DisplayMember = "name";

            comboBox_driver.DataSource = dtDrivers;
            comboBox_driver.ValueMember = "id";
            comboBox_driver.DisplayMember = "name";

            comboBox_tariff.DataSource = dtTariff;
            comboBox_tariff.ValueMember = "id";
            comboBox_tariff.DisplayMember = "name";
        }

        private void setClientInfo()
        {
            textBox_tel.Text = oDelivery.deliveryClient.telNumb;
            textBox_fio.Text = oDelivery.deliveryClient.fio;
            textBox_addr.Text = oDelivery.deliveryClient.addr_str;
            textBox_house.Text = oDelivery.deliveryClient.addr_house;
            textBox_korp.Text = oDelivery.deliveryClient.addr_korp;
            textBox_app.Text = oDelivery.deliveryClient.addr_app;
            textBox_porch.Text = oDelivery.deliveryClient.addr_porch;
            textBox_code.Text = oDelivery.deliveryClient.addr_code;
            textBox_floor.Text = oDelivery.deliveryClient.addr_floor;
        }

        private void setEnabled(bool pEnabled)
        {
            groupBox1.Enabled = pEnabled;
            groupBox2.Enabled = pEnabled;
            groupBox_clients.Enabled = pEnabled;
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            saveData();
            DialogResult = DialogResult.OK;
        }

        private void saveData()
        {
            if (!checkData()) return;

            dbAccess.saveData(oDelivery);
        }

        private bool checkData()
        {
            string errMsg = "Следующие обязательные поля не заполнены: ";

            oDelivery.deliveryClient.telNumb = textBox_tel.Text.Trim();
            oDelivery.deliveryClient.fio = textBox_fio.Text.Trim();
            oDelivery.deliveryClient.addr_city = (int)comboBox_city.SelectedValue;
            oDelivery.deliveryClient.addr_str = textBox_addr.Text.Trim();
            oDelivery.deliveryClient.addr_house = textBox_house.Text.Trim();
            oDelivery.deliveryClient.addr_korp = textBox_korp.Text.Trim();
            oDelivery.deliveryClient.addr_app = textBox_app.Text.Trim();
            oDelivery.deliveryClient.addr_porch = textBox_porch.Text.Trim();
            oDelivery.deliveryClient.addr_code = textBox_code.Text.Trim();
            oDelivery.deliveryClient.addr_floor = textBox_floor.Text.Trim();

            oDelivery.driverId = (int)comboBox_driver.SelectedValue;
            oDelivery.tariff = (int)comboBox_tariff.SelectedValue;

            if (string.Empty.Equals(oDelivery.deliveryClient.telNumb)) errMsg += Environment.NewLine + "- Номер телефона;";
            if (string.Empty.Equals(oDelivery.deliveryClient.fio)) errMsg += Environment.NewLine + "- ФИО;";
            if (string.Empty.Equals(oDelivery.deliveryClient.addr_city)) errMsg += Environment.NewLine + "- Город;";
            if (string.Empty.Equals(oDelivery.deliveryClient.addr_str)) errMsg += Environment.NewLine + "- Улица;";
            if (string.Empty.Equals(oDelivery.deliveryClient.addr_house)) errMsg += Environment.NewLine + "- Номер дома;";

            if (!"Следующие обязательные поля не заполнены: ".Equals(errMsg))
            {
                MessageBox.Show(errMsg, GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (isNewClient)
            {
                try { dbAccess.saveClient(oDelivery.deliveryClient); }
                catch (Exception exc)
                {
                    uMessage.Show("Неудалось сохранить клиента.", exc, SystemIcons.Information);
                    setEnabled(false);
                    return false;
                }
            }

            return true;
        }

        private void fDelivery_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            { 
                case Keys.Escape:
                    DialogResult = DialogResult.Cancel;
                    break;
            }
        }

        private void textBox_tel_Validated(object sender, EventArgs e)
        {
            dtClients = new DataTable();

            try
            {
                dtClients = dbAccess.getDeliveryClients(GValues.DBMode, textBox_tel.Text.Trim());
            }
            catch (Exception exc)
            {
                uMessage.Show("Неудалось загрузить справочник клиентов.", exc, SystemIcons.Information);
                return;
            }

            switch (dtClients.Rows.Count)
            { 
                case 0:
                    isNewClient = true;
                    oDelivery.deliveryClient.id = Guid.NewGuid().ToString();
                    break;

                case 1:
                    oDelivery.deliveryClient.id = dtClients.Rows[0]["id"].ToString();
                    oDelivery.deliveryClient.telNumb = dtClients.Rows[0]["phone"].ToString();
                    oDelivery.deliveryClient.fio = dtClients.Rows[0]["fio"].ToString();
                    oDelivery.deliveryClient.addr_city = (int)dtClients.Rows[0]["ref_city"];
                    oDelivery.deliveryClient.addr_str = dtClients.Rows[0]["street"].ToString();
                    oDelivery.deliveryClient.addr_house = dtClients.Rows[0]["house"].ToString();
                    oDelivery.deliveryClient.addr_korp = dtClients.Rows[0]["korp"].ToString();
                    oDelivery.deliveryClient.addr_app = dtClients.Rows[0]["app"].ToString();
                    oDelivery.deliveryClient.addr_porch = dtClients.Rows[0]["porch"].ToString();
                    oDelivery.deliveryClient.addr_code = dtClients.Rows[0]["code"].ToString();
                    oDelivery.deliveryClient.addr_floor = dtClients.Rows[0]["floor"].ToString();

                    setClientInfo();

                    break;

                default: // > 1
                    dataGridView_main.DataSource = dtClients;
                    groupBox_clients.Visible = true;
                    groupBox_clients.BringToFront();
                    break;
            }
        }

        private void dataGridView_main_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            { 
                case Keys.Escape:
                    groupBox_clients.SendToBack();
                    groupBox_clients.Visible = false;
                    break;

                case Keys.Enter:
                    groupBox_clients.SendToBack();
                    groupBox_clients.Visible = false;
                    break;
            }
        }
    }

    class DBaccess
    {
        private getReference oReferences = new getReference();

        private SqlConnection con;
        private SqlCommand command = null;

        public DataTable getDeliveryClients(string pDbType, string pPhone)
        {
            return oReferences.getDeliveryClients(pDbType, pPhone);
        }

        public DataTable getCity(string pDbType)
        {
            return oReferences.getCity(pDbType);
        }

        public DataTable getDrivers(string pDbType)
        {
            return oReferences.getDeliveryDrivers(pDbType);
        }

        public DataTable getTariff(string pDbType)
        {
            return oReferences.getDeliveryTariff(pDbType);
        }

        public void saveData( DTO_DBoard.Delivery pDelivery)
        {

            con = new DBCon().getConnection(GValues.DBMode);

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandType = CommandType.Text;
                command.CommandText = " INSERT INTO bills_info_delivery (branch,    season,                 bills,          ref_delivery_client, " +
                                                                    "   ref_driver, ref_delivery_tariff,    discountNumber, xcomment)" +
                                                            " VALUES (  @branch,    @season,                @bills,         @ref_delivery_client, " +
                                                            "           @driver,    @ref_delivery_tariff,   @discountNumber,@xcomment)";
                command.Parameters.Clear();

                command.Parameters.Add("branch", SqlDbType.Int).Value = pDelivery.branch;
                command.Parameters.Add("season", SqlDbType.Int).Value = pDelivery.season;
                command.Parameters.Add("bills", SqlDbType.Int).Value = pDelivery.bills;
                command.Parameters.Add("ref_delivery_client", SqlDbType.NVarChar).Value = pDelivery.deliveryClient.id;
                command.Parameters.Add("driver", SqlDbType.Int).Value = pDelivery.driverId;
                command.Parameters.Add("ref_delivery_tariff", SqlDbType.Int).Value = pDelivery.tariff;
                command.Parameters.Add("discountNumber", SqlDbType.NVarChar).Value = pDelivery.cardNumber;
                command.Parameters.Add("xcomment", SqlDbType.NVarChar).Value = pDelivery.comment;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        internal void saveClient(DTO_DBoard.DeliveryClient pDeliveryClient)
        {
            con = new DBCon().getConnection(GValues.DBMode);

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandType = CommandType.Text;
                command.CommandText = " INSERT INTO ref_delivery_clients(id,    phone,     fio,    ref_city,    street, house,  korp,   app,    porch,  code,   [floor])" +
                                                            " VALUES (  @id,    @phone,    @fio,   @ref_city,   @street,@house, @korp,  @app,   @porch, @code,  @floor)";
                command.Parameters.Clear();

                command.Parameters.Add("id", SqlDbType.NVarChar).Value = pDeliveryClient.id;
                command.Parameters.Add("phone", SqlDbType.NVarChar).Value = pDeliveryClient.telNumb;
                command.Parameters.Add("fio", SqlDbType.NVarChar).Value = pDeliveryClient.fio;
                command.Parameters.Add("ref_city", SqlDbType.Int).Value = pDeliveryClient.addr_city;
                command.Parameters.Add("street", SqlDbType.NVarChar).Value = pDeliveryClient.addr_str;
                command.Parameters.Add("house", SqlDbType.NVarChar).Value = pDeliveryClient.addr_house;
                command.Parameters.Add("korp", SqlDbType.NVarChar).Value = pDeliveryClient.addr_korp;
                command.Parameters.Add("app", SqlDbType.NVarChar).Value = pDeliveryClient.addr_app;
                command.Parameters.Add("porch", SqlDbType.NVarChar).Value = pDeliveryClient.addr_porch;
                command.Parameters.Add("code", SqlDbType.NVarChar).Value = pDeliveryClient.addr_code;
                command.Parameters.Add("floor", SqlDbType.NVarChar).Value = pDeliveryClient.addr_floor;

                command.ExecuteNonQuery();

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }
    }
}
