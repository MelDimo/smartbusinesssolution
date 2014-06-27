using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll.utilites;

namespace com.sbs.gui.usersdiscount
{
    public partial class fMIFare : Form
    {
        public string keyId = string.Empty;

        public fMIFare()
        {
            InitializeComponent();
            this.BackgroundImage = com.sbs.dll.utilites.Properties.Resources.ACR122_logoNFC;
        }

        private void fMIFare_Shown(object sender, EventArgs e)
        {
            try
            {
                Mifire oMifare = new Mifire();
                keyId = oMifare.readMifire();
            }
            catch (Exception exc) { uMessage.Show("Ошибка взаимодействия с ридером" + Environment.NewLine + exc.Message, exc, SystemIcons.Information); DialogResult = DialogResult.Cancel; }

            if (keyId.Equals(string.Empty)) DialogResult = DialogResult.Cancel;
            else DialogResult = DialogResult.OK;
        }
    }
}
