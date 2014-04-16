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
 
        public fExport41C(DTO_DBoard.SeasonBranch pSeason)
        {
            oSeasonBranch = pSeason;

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
            XmlNode nodeBill;
            XmlNode nodeBill_Clone;
            XmlDocument xmlDoc = new XmlDocument();
            
            xmlDoc.Load(@".\resource\export1C.xml");
            
            #region -------------------------------------------------------------- Заполняем данные по смене

            xmlDoc.SelectNodes(@"XmlBills/Smen_Array/XmlSmen/SmenId")[0].InnerText = oSeasonBranch.seasonID.ToString();
            xmlDoc.SelectNodes(@"XmlBills/Smen_Array/XmlSmen/SmenDate")[0].InnerText = oSeasonBranch.dateOpen.ToShortDateString();

            #endregion

            nodeBill = xmlDoc.SelectNodes(@"XmlBills/Bill_Array/XmlBill")[0];



            nodeBill_Clone = nodeBill.CloneNode(true);

            xmlDoc.Save(@".\resource\export1C.xml");

            //node.CloneNode(true);
        }
    }
}
