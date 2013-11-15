using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll.utilites;
using com.sbs.gui.docsform.db;

namespace com.sbs.gui.docsform
{
    public partial class fSupplyTMC_DOC : Form
    {
        getReference oReference = new getReference();
        DBAccess dbAccess = new DBAccess();

        DataTable dtTmcType;
        SupplyTMC oSupplyTMC;

        public fSupplyTMC_DOC(SupplyTMC pSupplyTMC)
        {
            oSupplyTMC = pSupplyTMC;

            InitializeComponent();

            textBox_TmcCurr.Text = oSupplyTMC.currCode;
        }

        private void setEnabled(bool pEnabled)
        {
            panel3.Enabled = pEnabled;
            tableLayoutPanel1.Enabled = pEnabled;
            panel4.Enabled = pEnabled;
        }

        private void fSupplyTMC_DOC_Shown(object sender, EventArgs e)
        {
            try
            {
                dtTmcType = oReference.getTmcType("offline");
            }
            catch (Exception exc) 
            { 
                uMessage.Show("Не удалось загрузить справочники.", exc, SystemIcons.Information);
                setEnabled(false);
                return;
            }

            fillControls();
        }

        private void fillControls()
        {
            comboBox_tmcType.SelectedValueChanged -= new EventHandler(comboBox_tmcType_SelectedValueChanged);

            comboBox_tmcType.DataSource = dtTmcType;
            comboBox_tmcType.DisplayMember = "name";
            comboBox_tmcType.ValueMember = "id";

            comboBox_tmcType.SelectedValueChanged +=new EventHandler(comboBox_tmcType_SelectedValueChanged);

            initControls();

        }

        private void initControls()
        {
            switch ((int)comboBox_tmcType.SelectedValue)
            { 
                case 1:
                    textBox_TmcAcc.Text = "2111";
                    break;
                case 2:
                    textBox_TmcAcc.Text = "2141";
                    break;
            }
        }

        private void comboBox_tmcType_SelectedValueChanged(object sender, EventArgs e)
        {
            initControls();
        }

        private void button_TMC_Click(object sender, EventArgs e)
        {
            try
            {
                dbAccess.getTmcByType("offline", (int)comboBox_tmcType.SelectedValue);
            }
            catch (Exception exc)
            {
                uMessage.Show("Проверка валидности данных привела к ошибке." + Environment.NewLine +
                                "Проверьте заполнены ли обязательные поля.", exc, SystemIcons.Information);
                return;
            }
        }


    }
}
