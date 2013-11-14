using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll.utilites;

namespace com.sbs.gui.docsjournal
{
    public partial class fDocsMain : Form
    {
        getReference oReferences = new getReference();

        DataTable dtDocsType;

        public fDocsMain()
        {
            InitializeComponent();

            button_filter.BackgroundImage = com.sbs.dll.utilites.Properties.Resources.filter_26;
        }

        private void fDocsMain_Shown(object sender, EventArgs e)
        {
            try
            {
                getReferences();
            }
            catch (Exception exc)
            {
                uMessage.Show("Ошибка получения данных", exc, SystemIcons.Error);
                setEnabled(false);
                return;
            }
        }

        private void setEnabled(bool pEnabled)
        {
            dataGridView_main.Enabled = pEnabled;
            statusStrip_info.Enabled = pEnabled;
            groupBox_filter.Enabled = pEnabled;
            menuStrip_filter.Enabled = pEnabled;
        }

        private void getReferences()
        {
            dtDocsType = oReferences.getDocsType("offline");
        }
    }
}
