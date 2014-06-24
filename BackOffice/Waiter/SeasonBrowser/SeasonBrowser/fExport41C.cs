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
using System.Xml;
using System.Diagnostics;

namespace com.sbs.gui.seasonbrowser
{
    public partial class fExport41C : Form
    {
        DTO_DBoard.SeasonBranch oSeasonBranch;
        Filter oFilter;

        DBaccess dbAccess = new DBaccess();
 
        public fExport41C(DTO_DBoard.SeasonBranch pSeason, Filter pFilter)
        {
            oSeasonBranch = pSeason;
            oFilter = pFilter;

            InitializeComponent();

            textBox_seasonNumber.Text = oSeasonBranch.seasonID.ToString();
            textBox_seasonDate.Text = oSeasonBranch.dateOpen + " - " + oSeasonBranch.dateClose;
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void button_browse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                textBox_path.Text = fbd.SelectedPath + @"\Смена_N_" + oFilter.season.ToString() + ".xml";
            }
        }

        private void button_ok_Click(object sender, EventArgs e)
        {
            try
            {
                exportData();
            }
            catch (Exception exc) { uMessage.Show("Неудалось экспортировать данные", exc, SystemIcons.Information); return; }

            DialogResult = DialogResult.OK;
        }

        private void exportData()
        {
            int curDep = 0;

            DataSet dsExport;

            string strXmlBill = "<XmlBill>" +
                                    "<ID></ID>" +
                                    "<D_Date></D_Date>" +
                                    "<OFI></OFI>" +
                                    "<DEPARTAMEN></DEPARTAMEN>" +
                                    "<D_SUMM></D_SUMM>" +
                                    "<D_NDSSUMM></D_NDSSUMM>" +
                                    "<D_DISCOUNT_SUMM></D_DISCOUNT_SUMM>" +
                                    "<D_DISCOUNT_NDSSUMM></D_DISCOUNT_NDSSUMM>" +
                                    "<SMENID></SMENID>" +
                                    "<CASSID></CASSID>" +
                                    "<CLIENDID/>" +
                                    "<PAY_ARRAY>" +
                                        "<XMLPAYS>" +
                                            "<PAYTYPE></PAYTYPE>" +
                                        "</XMLPAYS>" +
                                    "</PAY_ARRAY>" +
                                    "<BUXS_ARRAY>" +
                                        "<XMLBUXS>" +
                                            "<BUXS_ID></BUXS_ID>" +
                                        "</XMLBUXS>" +
                                    "</BUXS_ARRAY>" +
                                    "<CEKS_ARRAY>" +
                                    "</CEKS_ARRAY>" +
                                "</XmlBill>";

            string strXMLCEKS = "<XMLCEKS>" +
                                    "<DEPARTAMENT></DEPARTAMENT>" +
                                    "<DEPARTAMENT_TYPE></DEPARTAMENT_TYPE>" +
                                    "<D_SUMM></D_SUMM>" +
                                    "<D_NDSSUMM></D_NDSSUMM>" +
                                    "<D_DISCOUNT_SUMM></D_DISCOUNT_SUMM>" +
                                    "<D_DISCOUNT_NDSSUMM></D_DISCOUNT_NDSSUMM>" +
                                    "<D_ID></D_ID>" +
                                    "<CEKSLINE_ARRAY>" +
                                    "</CEKSLINE_ARRAY>" +
                                "</XMLCEKS>";

            string strXMLCEKLINES = "<XMLCEKLINES>" +
                                        "<LineID></LineID>" +
                                        "<OwnerID></OwnerID>" +
                                        "<ASSID></ASSID>" +
                                        "<QTY></QTY>" +
                                        "<COEF_QTY></COEF_QTY>" +
                                        "<PRICE></PRICE>" +
                                        "<NODISK_PRICE></NODISK_PRICE>" +
                                        "<NDS_PROCENT></NDS_PROCENT>" +
                                        "<NDSID></NDSID>" +
                                        "<SUMM></SUMM>" +
                                        "<NDSSUMM></NDSSUMM>" +
                                        "<DISCOUNTSUMM></DISCOUNTSUMM>" +
                                        "<DISCOUNTSUMMNDS></DISCOUNTSUMMNDS>" +
                                    "</XMLCEKLINES>";

            XmlNode nodeBill = null;
            XmlNode nodeBill_Bill = null;
            XmlNode nodeBill_CEKS = null;
            XmlNode nodeBill_CEKLINES = null;

            XmlDocument xmlDoc = new XmlDocument();
            XmlDocument xmlDocBill = new XmlDocument();
            XmlDocument xmlDocCEKS = new XmlDocument();
            XmlDocument xmlDocCEKLINES = new XmlDocument();

            xmlDocBill.LoadXml(strXmlBill);
            xmlDocCEKS.LoadXml(strXMLCEKS);
            xmlDocCEKLINES.LoadXml(strXMLCEKLINES);

            dsExport = dbAccess.exportFor1C(oFilter);
            DataTable dtFilteringData;
            
            xmlDoc.Load(@".\resource\export1C.xml");
            
            #region -------------------------------------------------------------- Заполняем данные по смене

            xmlDoc.SelectNodes(@"XmlBills/Smen_Array/XmlSmen/SmenId")[0].InnerText = oSeasonBranch.seasonID.ToString();
            xmlDoc.SelectNodes(@"XmlBills/Smen_Array/XmlSmen/SmenDate")[0].InnerText = oSeasonBranch.dateOpen.ToShortDateString();

            #endregion

            nodeBill = xmlDoc.SelectNodes(@"XmlBills/Bill_Array")[0];
            foreach (DataRow dr in dsExport.Tables["XmlBill"].Rows)
            {
                xmlDocBill.LoadXml(strXmlBill);
                nodeBill_Bill = xmlDocBill.DocumentElement.SelectSingleNode("/XmlBill");
                
                nodeBill_Bill.SelectNodes("ID")[0].InnerText = dr["ID"].ToString();
                nodeBill_Bill.SelectNodes("D_Date")[0].InnerText = ((DateTime)dr["D_Date"]).ToString("o");
                nodeBill_Bill.SelectNodes("OFI")[0].InnerText = dr["OFI"].ToString();
                nodeBill_Bill.SelectNodes("DEPARTAMEN")[0].InnerText = dr["DEPARTAMEN"].ToString();
                nodeBill_Bill.SelectNodes("D_SUMM")[0].InnerText = dr["D_SUMM"].ToString();
                nodeBill_Bill.SelectNodes("D_NDSSUMM")[0].InnerText = dr["D_NDSSUMM"].ToString();
                nodeBill_Bill.SelectNodes("D_DISCOUNT_SUMM")[0].InnerText = dr["D_DISCOUNT_SUMM"].ToString();
                nodeBill_Bill.SelectNodes("D_DISCOUNT_NDSSUMM")[0].InnerText = dr["D_DISCOUNT_NDSSUMM"].ToString();
                nodeBill_Bill.SelectNodes("SMENID")[0].InnerText = dr["SMENID"].ToString();
                nodeBill_Bill.SelectNodes("CASSID")[0].InnerText = dr["CASSID"].ToString(); // Внешний код заведения
                nodeBill_Bill.SelectNodes("CLIENDID")[0].InnerText = dr["CLIENDID"].ToString();

                var unitInfo = from rec in dsExport.Tables["XmlBuxs"].AsEnumerable()
                               where rec.Field<int>("bills_id") == (int)dr["bills_id"]
                               select rec;

                nodeBill_Bill.SelectNodes("BUXS_ARRAY/XMLBUXS/BUXS_ID")[0].InnerText = unitInfo.First().Field<int>("BUXS_ID").ToString();

                dsExport.Tables["XmlCeks"].DefaultView.RowFilter = "bills = " + dr["bills_id"].ToString();

                curDep = 0;

                foreach (DataRowView drw in dsExport.Tables["XmlCeks"].DefaultView)
                {
                    DataRow dr1 = drw.Row;

                    if ((int)dr1["DEPARTAMENT"] != curDep)
                    {
                        if (curDep != 0)
                        {

                            nodeBill_Bill.SelectNodes(@"CEKS_ARRAY")[0].AppendChild(xmlDocBill.ImportNode(nodeBill_CEKS, true));
                        }
                        
                        xmlDocCEKS.LoadXml(strXMLCEKS);
                        nodeBill_CEKS = xmlDocCEKS.DocumentElement.SelectSingleNode("/XMLCEKS");

                        nodeBill_CEKS.SelectNodes("DEPARTAMENT")[0].InnerText = dr1["DEPARTAMENT"].ToString();
                        nodeBill_CEKS.SelectNodes("DEPARTAMENT_TYPE")[0].InnerText = "0";
                        nodeBill_CEKS.SelectNodes("D_SUMM")[0].InnerText = "0";
                        nodeBill_CEKS.SelectNodes("D_NDSSUMM")[0].InnerText = "0";
                        nodeBill_CEKS.SelectNodes("D_DISCOUNT_SUMM")[0].InnerText = "0";
                        nodeBill_CEKS.SelectNodes("D_DISCOUNT_NDSSUMM")[0].InnerText = "0";
                        nodeBill_CEKS.SelectNodes("D_ID")[0].InnerText = "0";
                    }

                    nodeBill_CEKLINES = xmlDocCEKLINES.DocumentElement.SelectSingleNode("/XMLCEKLINES");

                    nodeBill_CEKLINES.SelectNodes("LineID")[0].InnerText = dr1["LineID"].ToString();
                    nodeBill_CEKLINES.SelectNodes("OwnerID")[0].InnerText = dr1["OwnerID"].ToString();
                    nodeBill_CEKLINES.SelectNodes("ASSID")[0].InnerText = dr1["ASSID"].ToString();
                    nodeBill_CEKLINES.SelectNodes("QTY")[0].InnerText = dr1["QTY"].ToString();
                    nodeBill_CEKLINES.SelectNodes("COEF_QTY")[0].InnerText = dr1["COEF_QTY"].ToString();
                    nodeBill_CEKLINES.SelectNodes("PRICE")[0].InnerText = dr1["PRICE"].ToString();
                    nodeBill_CEKLINES.SelectNodes("NODISK_PRICE")[0].InnerText = dr1["NODISK_PRICE"].ToString();
                    nodeBill_CEKLINES.SelectNodes("NDS_PROCENT")[0].InnerText = dr1["NDS_PROCENT"].ToString();
                    nodeBill_CEKLINES.SelectNodes("NDSID")[0].InnerText = dr1["NDSID"].ToString();
                    nodeBill_CEKLINES.SelectNodes("SUMM")[0].InnerText = dr1["SUMM"].ToString();
                    nodeBill_CEKLINES.SelectNodes("NDSSUMM")[0].InnerText = dr1["NDSSUMM"].ToString();
                    nodeBill_CEKLINES.SelectNodes("DISCOUNTSUMM")[0].InnerText = dr1["DISCOUNTSUMM"].ToString();
                    nodeBill_CEKLINES.SelectNodes("DISCOUNTSUMMNDS")[0].InnerText = dr1["DISCOUNTSUMMNDS"].ToString();

                    nodeBill_CEKS.SelectNodes(@"CEKSLINE_ARRAY")[0].AppendChild(xmlDocCEKS.ImportNode(nodeBill_CEKLINES, true));

                    nodeBill_CEKS.SelectNodes("D_SUMM")[0].InnerText = (decimal.Parse(nodeBill_CEKS.SelectNodes("D_SUMM")[0].InnerText) + (decimal)dr1["SUMM"]).ToString();

                    curDep = (int)dr1["DEPARTAMENT"];
                }

                if (nodeBill_CEKS != null)
                    nodeBill_Bill.SelectNodes(@"CEKS_ARRAY")[0].AppendChild(xmlDocBill.ImportNode(nodeBill_CEKS, true));

                xmlDoc.SelectNodes(@"XmlBills/Bill_Array")[0].AppendChild(xmlDoc.ImportNode(nodeBill_Bill, true));

            }

            //if (oFilter.isSeasonOpen)
            //{
            //    MessageBox.Show("Возможна выгрузка только закрытой смены.", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return;
            //}

            if (textBox_path.Text.Length == 0)
            {
                MessageBox.Show("Укажите путь для выгружаемого файла.", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            xmlDoc.Save(textBox_path.Text);

            //node.CloneNode(true);
        }
    }
}
