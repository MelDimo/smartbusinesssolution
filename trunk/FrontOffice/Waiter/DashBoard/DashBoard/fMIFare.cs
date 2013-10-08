using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll.utilites;

namespace com.sbs.gui.DashBoard
{
    public partial class fMIFare : Form
    {
        public fMIFare()
        {
            InitializeComponent();
            this.BackgroundImage = com.sbs.dll.utilites.Properties.Resources.ACR122_logoNFC;
        }

        private void fMIFare_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Escape:
                    DialogResult = DialogResult.Cancel;
                    break;

                case Keys.Enter:
                    DialogResult = DialogResult.OK;
                    break;
            }
        }

        private void fMIFare_Shown(object sender, EventArgs e)
        {
            string keyId;
            try
            {
                Mifire oMifare = new Mifire();
                keyId = oMifare.readMifire();
            }
            catch (Exception exc) { uMessage.Show("Ошибка взаимодействия с ридером", exc, SystemIcons.Information); return; }

            if (keyId.Length > 0) MessageBox.Show(keyId);
            else Close();
        }
    }
}
