using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll.utilites;

namespace com.sbs.gui.timetracking
{
    public partial class fMIFare : Form
    {
        public string keyId = "";

        public fMIFare()
        {
            InitializeComponent();
            this.BackgroundImage = com.sbs.dll.utilites.Properties.Resources.ACR122_logoNFC;
        }

        private void fMIFare_Shown(object sender, EventArgs e)
        {
            bool error = false;
            try
            {
                Mifire oMifare = new Mifire();
                keyId = oMifare.readMifire();
                if (keyId.Trim().Length == 0) throw new Exception("Не удалось прочесть данные.");
            }
            catch (Exception exc) 
            { 
                uMessage.Show("Ошибка взаимодействия с ридером" + Environment.NewLine + exc.Message, exc, SystemIcons.Information);
                error = true;
            }

            if (error) DialogResult = DialogResult.Cancel;
            else DialogResult = DialogResult.OK;
        }
    }
}
