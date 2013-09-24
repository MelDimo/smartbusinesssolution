using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll.utilites;
using System.IO;
using System.Reflection;

namespace com.sbs.gui.prepack
{
    public partial class fMain : Form
    {
        public fMain()
        {
            InitializeComponent();
            
            loadIcons();

            updatePrepackMain();
        }

        private void loadIcons()
        {
            SBSResources sbsResources = new SBSResources();
            sbsResources.initResources();

            Assembly myAssembly = Assembly.GetEntryAssembly();
            Stream myStream = myAssembly.GetManifestResourceStream("add_26.png");
            
            Bitmap image = new Bitmap(myStream);

            tSButton_addPrepackMain.Image = image;
        }

        private void updatePrepackMain()
        {
            DataTable dt = new DataTable();

        }

    }
}
