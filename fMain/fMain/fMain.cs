using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll;
using System.Diagnostics;
using System.Reflection;
using System.ServiceModel;
using System.Threading;
using System.Messaging;
using com.sbs.dll.utilites;
using com.sbs.gui.main.Properties;

namespace com.sbs.gui.main
{
    public partial class fMain : Form
    {
        DTO.Message oMessage = new DTO.Message();
        Thread msgListner;

        fInfo infoForm = new fInfo();

        static bool threadFlag = true;

        public fMain(DataTable pDtMnu)
        {
            InitializeComponent();

            this.Text = GValues.prgNameFull;

            createMnu(pDtMnu);

            msgListner = new Thread(monitorMessage);
            msgListner.Start();
        }

        private void monitorMessage()
        {
            try
            {
                if (!MessageQueue.Exists(@".\Private$\SBSInnerMessage")) MessageQueue.Create(@".\Private$\SBSInnerMessage");

                MessageQueue messageQueue = new MessageQueue(@".\Private$\SBSInnerMessage");
                messageQueue.Purge();

                while (threadFlag)
                {
                    System.Messaging.Message[] messages = messageQueue.GetAllMessages();
                    foreach (System.Messaging.Message message in messages)
                    {
                        message.Formatter = new XmlMessageFormatter(new Type[] { typeof(DTO.Message) });
                        oMessage = (DTO.Message)message.Body;
                        switch (oMessage.id)
                        {
                            case "MESSAGE_UNSEEN": // Непрочитанные сообщения
                                setMailInfo(oMessage);
                                break;

                            case "APPLICATION_CLOSE":// Необходимость закрыть приложение
                                initCloseProtocol(oMessage);
                                break;
                        }
                    }
                    // after all processing, delete all the messages
                    messageQueue.Purge();

                    Thread.Sleep(30000);
                }
            }
            catch (Exception exc) 
            { 
                //uMessage.Show("Ошибка в прослушивателе сообщений.", exc, SystemIcons.Information); 
                return; 
            }
        }

        private void initCloseProtocol(DTO.Message pMessage)
        {
            
        }

        public void setMailInfo(DTO.Message oMessage)
        {
            //Debug.Print("int.Parse(oMessage.Body) > 0 :" + (int.Parse(oMessage.Body) > 0));
            tSSLabel_mailChecker.Text = int.Parse(oMessage.Body) > 0 ? oMessage.Header + oMessage.Body : "";
        }

        private void createMnu(DataTable pDtMnu)
        {
            MenuStrip mainMnu = new MenuStrip();
            ToolStripMenuItem mnuItem;
            bool isChild;

            foreach (DataRow dr in pDtMnu.Rows)
            {
                if ((int)dr["id"] == 0) continue; // Элемент не имеет интерфейса

                isChild = false;

                mnuItem = new ToolStripMenuItem(dr["name"].ToString());
                mnuItem.Name = dr["id"].ToString();
                mnuItem.Tag = dr["assembly_name"].ToString();
                mnuItem.Click += new EventHandler(mnuItem_Click);

                foreach (ToolStripMenuItem parentItem in mainMnu.Items.Find(dr["id_parent"].ToString(), true))
                {
                    parentItem.DropDownItems.Add(mnuItem);
                    isChild = true;
                }

                if (!isChild) mainMnu.Items.Add(mnuItem);
            }

            this.Controls.Add(mainMnu);
        }

        void mnuItem_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;

            if (clickedItem.Tag.ToString().Equals("")) return;

            if (isFormOpen(clickedItem.Name)) return;

            foreach (Assembly currentassembly in AppDomain.CurrentDomain.GetAssemblies())
            {
                Type type = currentassembly.GetType(clickedItem.Tag.ToString(), false, true);

                if (type != null)
                {
                    Form form = (Form)Activator.CreateInstance(type);
                    form.Name = clickedItem.Name;
                    tabControl_top.TabPages.Add(form.Name, form.Text);
                    if (form.Tag != null)
                    {
                        if (!form.Tag.Equals("DIALOG")) form.MdiParent = this;
                    }
                    else
                        form.MdiParent = this;

                    form.FormClosed += new FormClosedEventHandler(form_FormClosed);
                    form.Activated += new EventHandler(form_Activated);
                    if (form.Tag != null)
                    {
                        if (form.Tag.Equals("DIALOG")) form.ShowDialog(); // Or Application.Run(form)
                    }
                    else
                        form.Show();
                    return;
                }
            }
        }

        void form_Activated(object sender, EventArgs e)
        {
            tabControl_top.SelectTab(((Form)sender).Name);
        }

        void form_FormClosed(object sender, FormClosedEventArgs e)
        {
            tabControl_top.TabPages.RemoveByKey(((Form)sender).Name);
        }

        private bool isFormOpen(string pFormName)
        {
            foreach (Form form in this.MdiChildren)
            {
                if (form.Name.Equals(pFormName))
                {
                    form.Activate();
                    foreach(TabPage tp in tabControl_top.TabPages)
                    {
                        if (tp.Name.Equals(pFormName)) tp.Select();
                    }
                    return true;
                }
            }

            return false;
        }

        private void fMain_Shown(object sender, EventArgs e)
        {
            tSSLabel_info.Text = UsersInfo.UserName;
            tSSLabel_basetype.Text = GValues.DBMode;
        }

        private void tabControl_top_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl_top.TabPages.Count == 0) return;

            string xName = tabControl_top.SelectedTab.Name;

            foreach (Form form in this.MdiChildren)
            {
                if (form.Name.Equals(xName))
                {
                    form.Activate();
                }
            }
        }

        private void fMain_FormClosed(object sender, FormClosedEventArgs e)
        {


            MethodInfo methodInfoBill;
            object classInstance;

            Settings set = new Settings();
            set.formSize = this.Size;
            set.formLocation = this.Location;
            set.formState = this.WindowState;
            set.Save();

            threadFlag = false;

            GValues.isAlive = false;

            for(int i = 0; i < GValues.DicDemans.Count; i++) // Пробегаюсь по сохраненым деманам и запускаю их методы
            {
                methodInfoBill = GValues.DicDemans.ElementAt(i).Value.GetMethod(GValues.DicDemans.ElementAt(i).Key);
                classInstance = Activator.CreateInstance(GValues.DicDemans.ElementAt(i).Value, null);
                methodInfoBill.Invoke(classInstance, null);
            }

            infoForm.Close();
        }

        private void fMain_Load(object sender, EventArgs e)
        {
            Settings set = new Settings();
            this.Size = set.formSize;
            this.Location = set.formLocation;
            this.WindowState = set.formState;
        }

        private void fMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Thread wndTread = new Thread(fInfo_show);
            wndTread.IsBackground = true;
            wndTread.Start();
        }

        public void fInfo_show()
        {
            infoForm.ShowDialog();
        }
    }
}
