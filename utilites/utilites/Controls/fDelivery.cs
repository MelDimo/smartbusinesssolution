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
        DataTable dtStreet;

        DBaccess dbAccess = new DBaccess();
        Suppurt.FormOpenModes eFormOpensModes;

        bool isNewClient = false;
        bool isNewStreet = false;

        public DTO_DBoard.Delivery oDelivery;

        public fDelivery(DTO_DBoard.Delivery pDelivery, Suppurt.FormOpenModes pFormOpensModes )
        {
            oDelivery = pDelivery;
            eFormOpensModes = pFormOpensModes;

            InitializeComponent();

            dataGridView_main.AutoGenerateColumns = false;
            dataGridView_main.Columns["id"].DataPropertyName = "id";
            dataGridView_main.Columns["fio"].DataPropertyName = "fio";
            dataGridView_main.Columns["street"].DataPropertyName = "fullAddr";
            dataGridView_main.Columns["cityName"].DataPropertyName = "cityName";
            

            if (eFormOpensModes == Suppurt.FormOpenModes.ReadOnly)
            {
                button_save.Enabled = false;
                groupBox1.Enabled = false;
                groupBox2.Enabled = false;
            }

            intiData();
        }

        private void intiData()
        {
            dtTariff = new DataTable();
            dtDrivers = new DataTable();

            try
            {
                dtTariff = dbAccess.getTariff(GValues.DBMode);
                dtDrivers = dbAccess.getDrivers(GValues.DBMode);
                dtCity = dbAccess.getCity(GValues.DBMode);
                dtStreet = dbAccess.getStreet(GValues.DBMode);
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

            string[] postSource = dtStreet
                    .AsEnumerable()
                    .Select<System.Data.DataRow, String>(x => x.Field<String>("name"))
                    .ToArray();
            var source = new AutoCompleteStringCollection();
            source.AddRange(postSource);
            textBox_addr.AutoCompleteCustomSource = source;
            textBox_addr.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBox_addr.AutoCompleteSource = AutoCompleteSource.CustomSource;

            setClientInfo();
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

            if (eFormOpensModes != Suppurt.FormOpenModes.Edit)
            {
                textBox_cardNumber.Text = oDelivery.cardNumber;
                textBox_comment.Text = oDelivery.comment;

                comboBox_driver.SelectedValue = oDelivery.driverId;
                comboBox_tariff.SelectedValue = oDelivery.tariff;
                comboBox_city.SelectedValue = oDelivery.deliveryClient.addr_city;
            }

            textBox_fio.Focus();
        }

        private void setEnabled(bool pEnabled)
        {
            groupBox1.Enabled = pEnabled;
            groupBox2.Enabled = pEnabled;
            groupBox_clients.Enabled = pEnabled;
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveData()) DialogResult = DialogResult.OK;
            }
            catch (Exception exc)
            {
                uMessage.Show("Ошибка обработки данных", exc, SystemIcons.Information);
                return;
            }
        }

        private bool saveData()
        {
            if (!checkData()) return false;
            else
            {
                switch (eFormOpensModes)
                { 
                    case Suppurt.FormOpenModes.New:
                        dbAccess.saveData(oDelivery);
                        break;

                    case Suppurt.FormOpenModes.Edit:
                        dbAccess.editData(oDelivery);
                        break;

                    default:
                        break;
                }
                return true;
            }
        }

        private bool checkData()
        {
            string errMsg = "Следующие обязательные поля не заполнены: ";

            //if (eFormOpensModes == Suppurt.FormOpenModes.Edit)
            //{
                if (!oDelivery.deliveryClient.telNumb.Equals(textBox_tel.Text.Trim())) isNewClient = true;
                if (!oDelivery.deliveryClient.fio.Equals(textBox_fio.Text.Trim())) isNewClient = true;
                if (!oDelivery.deliveryClient.addr_city.Equals((int)comboBox_city.SelectedValue)) isNewClient = true;
                if (!oDelivery.deliveryClient.addr_str.Equals(textBox_addr.Text.Trim())) isNewClient = true;
                if (!oDelivery.deliveryClient.addr_house.Equals(textBox_house.Text.Trim())) isNewClient = true;
                if (!oDelivery.deliveryClient.addr_korp.Equals(textBox_korp.Text.Trim())) isNewClient = true;
                if (!oDelivery.deliveryClient.addr_app.Equals(textBox_app.Text.Trim())) isNewClient = true;
                if (!oDelivery.deliveryClient.addr_porch.Equals(textBox_porch.Text.Trim())) isNewClient = true;
                if (!oDelivery.deliveryClient.addr_code.Equals(textBox_code.Text.Trim())) isNewClient = true;
                if (!oDelivery.deliveryClient.addr_floor.Equals(textBox_floor.Text.Trim())) isNewClient = true;

                if (textBox_addr.Text.Trim().Length > 0)
                {
                    int count = (from row in dtStreet.AsEnumerable() where row.Field<string>("name") == textBox_addr.Text.Trim() select row).Count();
                    if (count == 0) isNewStreet = true;
                }
                
            //}

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
                oDelivery.deliveryClient.id = Guid.NewGuid().ToString();
                try { dbAccess.saveClient(oDelivery.deliveryClient); }
                catch (Exception exc)
                {
                    uMessage.Show("Неудалось сохранить клиента.", exc, SystemIcons.Information);
                    return false;
                }
            }

            if (isNewStreet)
            {
                try { dbAccess.saveStreet(oDelivery.deliveryClient.addr_str); }
                catch (Exception exc)
                {
                    uMessage.Show("Неудалось добавить улицу в справочник.", exc, SystemIcons.Information);
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
                    if (groupBox_clients.Visible)
                    {
                        groupBox_clients.Visible = false;
                        return;
                    }
                    else
                    {
                        DialogResult = DialogResult.Cancel;
                    }
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
                    break;

                case 1:
                    getClientInfo(dtClients.Rows[0]);
                    setClientInfo();

                    break;

                default: // > 1
                    dtClients.Columns.Add(new DataColumn()
                    {
                        ColumnName = "fullAddr",
                        Expression = "street +' '+ house +' '+ korp +' '+ app +' '+ porch +' '+ code +' '+  floor"
                    } );

                    dataGridView_main.DataSource = dtClients;
                    groupBox_clients.Visible = true;
                    groupBox_clients.BringToFront();
                    dataGridView_main.Rows[0].Selected = true;
                    dataGridView_main.Focus();
                    break;
            }
        }

        private void getClientInfo(DataRow dataRow)
        {
            oDelivery.deliveryClient.id = dataRow["id"].ToString();
            oDelivery.deliveryClient.telNumb = dataRow["phone"].ToString();
            oDelivery.deliveryClient.fio = dataRow["fio"].ToString();
            oDelivery.deliveryClient.addr_city = (int)dataRow["ref_city"];
            oDelivery.deliveryClient.addr_str = dataRow["street"].ToString();
            oDelivery.deliveryClient.addr_house = dataRow["house"].ToString();
            oDelivery.deliveryClient.addr_korp = dataRow["korp"].ToString();
            oDelivery.deliveryClient.addr_app = dataRow["app"].ToString();
            oDelivery.deliveryClient.addr_porch = dataRow["porch"].ToString();
            oDelivery.deliveryClient.addr_code = dataRow["code"].ToString();
            oDelivery.deliveryClient.addr_floor = dataRow["floor"].ToString();
        }

        private void dataGridView_main_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            { 
                case Keys.Escape:
                    groupBox_clients.SendToBack();
                    groupBox_clients.Visible = false;
                    textBox_fio.Focus();
                    break;

                case Keys.Enter:
                    if (dataGridView_main.Rows.Count == 0) return;
                    groupBox_clients.SendToBack();
                    groupBox_clients.Visible = false;
                    getClientInfo((dataGridView_main.SelectedRows[0].DataBoundItem as DataRowView).Row);
                    setClientInfo();
                    break;
            }
        }
    }

    class DBaccess
    {
        private getReference oReferences = new getReference();

        private SqlConnection con;
        private SqlCommand command = null;

        internal DataTable getDeliveryClients(string pDbType, string pPhone)
        {
            return oReferences.getDeliveryClients(pDbType, pPhone);
        }

        internal DataTable getCity(string pDbType)
        {
            return oReferences.getCity(pDbType);
        }

        internal DataTable getStreet(string pDbType)
        {
            DataTable dtResult = new DataTable();

            try
            {
                con = new DBCon().getConnection(pDbType);
                command = null;

                con.Open();
                command = con.CreateCommand();

                command.CommandText = " SELECT name " +
                                        " FROM ref_delivery_street";

                using (SqlDataReader dr = command.ExecuteReader())
                {
                    dtResult.Load(dr);
                }

                con.Close();
            }
            catch (Exception exc) { throw exc; }
            finally { if (con.State == ConnectionState.Open) con.Close(); }

            return dtResult;
        }

        internal DataTable getDrivers(string pDbType)
        {
            return oReferences.getDeliveryDrivers(pDbType);
        }

        internal DataTable getTariff(string pDbType)
        {
            return oReferences.getDeliveryTariff(pDbType);
        }

        internal void saveData(DTO_DBoard.Delivery pDelivery)
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

        internal void editData(DTO_DBoard.Delivery pDelivery)
        {
            con = new DBCon().getConnection(GValues.DBMode);

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandType = CommandType.Text;
                command.CommandText = " UPDATE bills_info_delivery  SET ref_delivery_client = ref_delivery_client, " +
                                      "                                 ref_driver = @driver, " +
                                      "                                 ref_delivery_tariff = @ref_delivery_tariff, " +
                                      "                                  discountNumber = @discountNumber, " +
                                      "                                  xcomment = @xcomment" +
                                      " WHERE branch = @branch AND season = @season AND bills = @bills";
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

        internal void saveStreet(string pAddrStr)
        {
            con = new DBCon().getConnection(GValues.DBMode);

            try
            {
                con.Open();
                command = con.CreateCommand();

                command.CommandType = CommandType.Text;
                command.CommandText = " INSERT INTO ref_delivery_street (name)" +
                                                            " VALUES (  @name)";
                command.Parameters.Add("name", SqlDbType.NVarChar).Value = pAddrStr;

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
