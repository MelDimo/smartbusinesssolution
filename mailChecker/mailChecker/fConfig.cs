using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Media;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Media;
using com.sbs.dll.utilites;

namespace com.sbs.dll.mailChecker
{

    public partial class fConfig : Form
    {
        DBAccess dbAccess = new DBAccess();

        private string formMode; // В каком режиме диалог "EDIT"/"ADD"

        class Melody
        {
            public string name { get; set; }
            public Stream melody { get; set; }
        }

        Melody curMelody;
        
        int maxMail;
        int chkSec;
        string melodyName;

        List<Melody> lMelody = new List<Melody>();

        public fConfig(string pMelody, int pMaxMail, int pChkSec)
        {
            maxMail = pMaxMail;
            chkSec = pChkSec;
            melodyName = pMelody;

            formMode = "EDIT";

            InitializeComponent();
        }

        public fConfig()
        {
            maxMail = 5;
            chkSec = 30;
            curMelody = null;

            formMode = "ADD";

            InitializeComponent();
        }

        private void fConfig_Shown(object sender, EventArgs e)
        {
            lMelody.Add(new Melody() { name = "Afternoon_Ding", melody = com.sbs.dll.utilites.Properties.Resources.Afternoon_Ding });
            lMelody.Add(new Melody() { name = "Cityscape_Ding", melody = com.sbs.dll.utilites.Properties.Resources.Cityscape_Ding });

            comboBox_melody.DataSource = lMelody;
            comboBox_melody.DisplayMember = "name";

            if (melodyName.Equals(string.Empty)) curMelody = lMelody[0];
            else curMelody = lMelody.First(oMelody => oMelody.name == melodyName);
            
            comboBox_melody.SelectedItem = curMelody;
            numericUpDown_maxMail.Value = maxMail;
            numericUpDown_chkSec.Value = chkSec / 1000;
        }

        private void button_play_Click(object sender, EventArgs e)
        {
            if (comboBox_melody.SelectedValue == null) return;

            SoundPlayer player = new SoundPlayer(curMelody.melody);
            player.Stream.Position = 0;
            player.PlaySync();
            player.Dispose();
        }

        private void button_save_Click(object sender, EventArgs e)
        {
            if (saveData())
            {
                GValues.mailChkSec = chkSec;
                Close();
            }
        }

        private bool saveData()
        {
            maxMail = (int)numericUpDown_maxMail.Value;
            chkSec = (int)numericUpDown_chkSec.Value * 1000;

            try { dbAccess.saveMailClientConfig("offline", new object[] { curMelody.name, maxMail, chkSec, formMode }); }
            
            catch (Exception exc) { uMessage.Show("Неудалось применить параметры.", exc, SystemIcons.Information); return false; }

            return true;
        }

        private void button_cancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void comboBox_melody_SelectionChangeCommitted(object sender, EventArgs e)
        {
            curMelody = ((Melody)comboBox_melody.SelectedValue);
        }
    }
}
