using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll;

namespace com.sbs.gui.dashboard
{
    public partial class fSplash : Form
    {

        public fSplash()
        {
            InitializeComponent();

            this.BackgroundImage = com.sbs.dll.utilites.Properties.Resources.splash_1;
        }

        private void fSplash_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            { 
                case Keys.Enter:
                    enterKey();
                    break;
            }
        }

        private void enterKey()
        {
            switch(GValues.authortype)
            {
                case 1:
                    fMIFare fMiFare = new fMIFare();
                    fMiFare.ShowDialog();        
                    break;
                case 2:
                    MessageBox.Show("Авторизация по логину на данном этапе не доступна");
                    break;
            }
            

        }
    }
}
