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
            SaveFileDialog sfd = new SaveFileDialog();
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                textBox_path.Text = sfd.FileName;
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

            XmlNode nodeBill;
            XmlNode nodeBill_Bill;
            XmlNode nodeBill_CEKS;
            XmlNode nodeBill_CEKLINES;
            XmlDocument xmlDoc = new XmlDocument();
            XmlDocument xmlDocBill = new XmlDocument();
            XmlDocument xmlDocCEKS = new XmlDocument();
            XmlDocument xmlDocCEKLINES = new XmlDocument();

            xmlDocBill.LoadXml(strXmlBill);
            xmlDocCEKS.LoadXml(strXMLCEKS);
            xmlDocCEKLINES.LoadXml(strXMLCEKLINES);

            XmlDocumentFragment fragment;

            dsExport = dbAccess.exportFor1C(oFilter);
            
            xmlDoc.Load(@".\resource\export1C.xml");
            
            #region -------------------------------------------------------------- Заполняем данные по смене

            xmlDoc.SelectNodes(@"XmlBills/Smen_Array/XmlSmen/SmenId")[0].InnerText = oSeasonBranch.seasonID.ToString();
            xmlDoc.SelectNodes(@"XmlBills/Smen_Array/XmlSmen/SmenDate")[0].InnerText = oSeasonBranch.dateOpen.ToShortDateString();

            #endregion

            nodeBill = xmlDoc.SelectNodes(@"XmlBills/Bill_Array")[0];
            foreach (DataRow dr in dsExport.Tables["XmlBill"].Rows)
            {
                nodeBill_Bill = xmlDocBill.DocumentElement.SelectSingleNode("/XmlBill");
                
                nodeBill_CEKLINES = xmlDocCEKLINES.DocumentElement.SelectSingleNode("/XMLCEKLINES");

                nodeBill_Bill.SelectNodes("ID")[0].InnerText = dr["ID"].ToString();
                nodeBill_Bill.SelectNodes("D_Date")[0].InnerText = dr["D_Date"].ToString();
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

                foreach (DataRow dr1 in dsExport.Tables["XmlCeks"].Rows)
                {
                    nodeBill_CEKS = xmlDocCEKS.DocumentElement.SelectSingleNode("/XMLCEKS");

                    nodeBill_CEKS.SelectNodes("DEPARTAMENT")[0].InnerText = "";
                    nodeBill_CEKS.SelectNodes("DEPARTAMENT_TYPE")[0].InnerText = "";
                    nodeBill_CEKS.SelectNodes("D_SUMM")[0].InnerText = "";
                    nodeBill_CEKS.SelectNodes("D_NDSSUMM")[0].InnerText = "";
                    nodeBill_CEKS.SelectNodes("D_DISCOUNT_SUMM")[0].InnerText = "";
                    nodeBill_CEKS.SelectNodes("D_DISCOUNT_NDSSUMM")[0].InnerText = "";
                    nodeBill_CEKS.SelectNodes("D_ID")[0].InnerText = "";
                }
                
                




                xmlDoc.SelectNodes(@"XmlBills/Bill_Array")[0].AppendChild(xmlDoc.ImportNode(nodeBill_Bill, true));
            }
            

            xmlDoc.Save(@"C:\Temp\export1C.xml");

            //node.CloneNode(true);
        }
    }
}
