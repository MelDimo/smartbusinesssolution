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

namespace com.sbs.gui.seasonbrowser
{
    public partial class fXOrderViewer : Form
    {
        string printerAddress;
        string documentText;
        string documentName;

        public fXOrderViewer(string pPrinterAddress, string pDocumentText, string pDocumentName)
        {
            printerAddress = pPrinterAddress;
            documentText = pDocumentText;
            documentName = pDocumentName;

            InitializeComponent();

            tSButton_print.Image = com.sbs.dll.utilites.Properties.Resources.printer_26;

            tSSLabel_printerName.Text = pPrinterAddress;
            textBox_report.Text = pDocumentText;
        }

        private void Print(String printerAddress, String text, String documentName)
        {
            int Error = 0;
            RawPrinterHelper rph = new RawPrinterHelper();

            byte[] bText = Encoding.GetEncoding(866).GetBytes(text);
            string sText = Encoding.GetEncoding(1251).GetString(bText);

            rph.SendStringToPrinter(printerAddress, sText, out Error);
        }

        private void tSButton_print_Click(object sender, EventArgs e)
        {
            try
            {
                this.Print(printerAddress, documentText, documentName);
            }
            catch(Exception exc)
            {
                uMessage.Show("Ошибка печати.", exc, SystemIcons.Information);
            }

            MessageBox.Show("Отчет распечатан.", GValues.prgNameFull, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
