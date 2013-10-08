using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using com.sbs.dll;
using com.sbs.dll.utilites;

namespace com.sbs.gui.DashBoard
{
    public partial class fMain : Form
    {
        private static DBaccess DbAccess = new DBaccess();

        internal DataSet dsDishes;

        int xCurCarte, xCurDishesGroup, xDishes;    // id текущих выбранных позиций

        public fMain(DataSet pDsDishes)
        {
            dsDishes = pDsDishes;

            InitializeComponent();

            dataGridView_bill.AutoGenerateColumns = false;
            dataGridView_bill.MultiSelect = false;
            dataGridView_bill.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            dataGridView_dish.AutoGenerateColumns = false;
            dataGridView_dish.MultiSelect = false;
            dataGridView_dish.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView_dish.KeyDown += new KeyEventHandler(dataGridView_dish_KeyDown);

            dataGridView_refusing.AutoGenerateColumns = false;

            splitContainer1.FixedPanel = FixedPanel.Panel2;
            splitContainer2.FixedPanel = FixedPanel.Panel1;

            tSStatusLabel_whoOpen.Text = "Смена открыта: " + GValues.openSeasonUserName;
            tSStatusLabel_whenOpen.Text = GValues.openSeasonDate;

            //createCarte();

        }

        void dataGridView_dish_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Enter:
                    if (dataGridView_dish.SelectedRows.Count == 0) return;
                    ToolStripButton tsButton;
                    oFilter filter;
                    int xId = (int)dataGridView_dish.SelectedRows[0].Cells["id"].Value;

                    switch (((DataTable)dataGridView_dish.DataSource).TableName)
                    { 
                        case "carte":
                            filter = new oFilter();

                            tsButton = new ToolStripButton();
                            tsButton.Click += new EventHandler(tsButton_Click);
                            tsButton.Text = dataGridView_dish.SelectedRows[0].Cells["name"].Value.ToString();
                            tsButton.Name = (toolStrip_top.Items.Count + 1).ToString();

                            filter.TabName = "carte";
                            tsButton.Tag = filter;

                            toolStrip_top.Items.Add(tsButton);

                            xCurCarte = xId;
                            createDishesGroup(xCurCarte, 0);
                            break;

                        case "dishesgroup":
                            filter = new oFilter();

                            tsButton = new ToolStripButton();
                            tsButton.Click += new EventHandler(tsButton_Click);
                            tsButton.Text = dataGridView_dish.SelectedRows[0].Cells["name"].Value.ToString();
                            tsButton.Name = (toolStrip_top.Items.Count + 1).ToString();

                            filter.TabName = "dishesgroup";
                            filter.Dishesgroup = (int)dataGridView_dish.SelectedRows[0].Cells["id_parent"].Value;
                            filter.Carte = xCurCarte;
                            tsButton.Tag = filter;

                            toolStrip_top.Items.Add(tsButton);

                            xCurDishesGroup = xId;

                            var results = from myRow in dsDishes.Tables["dishes"].AsEnumerable()
                                          where myRow.Field<int>("dishes_group") == xId
                                          select myRow;

                            if (results.Count() > 0)
                            {
                                createDishes(xCurDishesGroup);
                            }
                            else
                                createDishesGroup(xCurCarte, xCurDishesGroup);

                            break;

                        case "dishes":
                            break;
                    }
                    break;

                case Keys.Back:
                    if (toolStrip_top.Items.Count == 0) return;
                    filter = (oFilter)((ToolStripButton)toolStrip_top.Items[(toolStrip_top.Items.Count).ToString()]).Tag;
                    toolStrip_top.Items[(toolStrip_top.Items.Count).ToString()].Dispose();
                    switch (filter.TabName)
                    {
                        case "carte":
                            createCarte();
                            break;

                        case "dishesgroup":
                            createDishesGroup(filter.Carte, filter.Dishesgroup);
                            break;
                    }
                    break;
            }
        }

        void tsButton_Click(object sender, EventArgs e)
        {
            ToolStripButton tsButton = sender as ToolStripButton;
            oFilter filter = tsButton.Tag as oFilter;

            for(int i = toolStrip_top.Items.Count - 1; i >= 0; i--)
            {
                if (toolStrip_top.Items[i].Equals(tsButton))
                {
                    toolStrip_top.Items[i].Dispose();
                    break;
                }

                toolStrip_top.Items[i].Dispose();
            }


            switch (filter.TabName)
            {
                case "carte":
                    createCarte();
                    break;

                case "dishesgroup":
                    createDishesGroup(filter.Carte, filter.Dishesgroup);
                    break;
            }
        }

        private void createCarte()
        {
            switch (dsDishes.Tables["carte"].Rows.Count)
            {
                case 1:
                    xCurCarte = int.Parse(dsDishes.Tables["carte"].Rows[0]["id"].ToString());
                    createDishesGroup(xCurCarte, 0);
                    break;

                case 0:
                    return;

                default:
                    break;
            }

            dataGridView_dish.Columns.Clear();

            dataGridView_dish.DataSource = dsDishes.Tables["carte"];

            DataGridViewTextBoxColumn col0 = new DataGridViewTextBoxColumn();
            col0.HeaderText = "id";
            col0.Name = "id";
            col0.DataPropertyName = "id";
            col0.Visible = false;

            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.HeaderText = "Наименование";
            col1.Name = "name";
            col1.DataPropertyName = "name";
            col1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView_dish.Columns.AddRange(new DataGridViewColumn[] { col0, col1 });

        }

        private void createDishesGroup(int pCurCarte, int pCurDishesGroup)
        {
            dataGridView_dish.Columns.Clear();

            dsDishes.Tables["dishesgroup"].DefaultView.RowFilter = string.Format("carte = {0} AND id_parent = {1}", pCurCarte, pCurDishesGroup);
            dataGridView_dish.DataSource = dsDishes.Tables["dishesgroup"];

            DataGridViewTextBoxColumn col0 = new DataGridViewTextBoxColumn();
            col0.HeaderText = "id";
            col0.Name = "id";
            col0.DataPropertyName = "id";
            col0.Visible = false;

            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.HeaderText = "carte";
            col1.Name = "carte";
            col1.DataPropertyName = "carte";
            col1.Visible = false;

            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            col2.HeaderText = "id_parent";
            col2.Name = "id_parent";
            col2.DataPropertyName = "id_parent";
            col2.Visible = false;

            DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
            col3.HeaderText = "name";
            col3.Name = "name";
            col3.DataPropertyName = "name";
            col3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView_dish.Columns.AddRange(new DataGridViewColumn[] { col0, col1, col2, col3 });
        }

        private void createDishes(int pCurDishesGroup)
        {
            dataGridView_dish.Columns.Clear();

            dsDishes.Tables["dishes"].DefaultView.RowFilter = string.Format("dishes_group = {0}", pCurDishesGroup);
            dataGridView_dish.DataSource = dsDishes.Tables["dishes"];

            DataGridViewTextBoxColumn col0 = new DataGridViewTextBoxColumn();
            col0.HeaderText = "id";
            col0.Name = "id";
            col0.DataPropertyName = "id";
            col0.Visible = false;

            DataGridViewTextBoxColumn col1 = new DataGridViewTextBoxColumn();
            col1.HeaderText = "dishes_group";
            col1.Name = "dishes_group";
            col1.DataPropertyName = "dishes_group";
            col1.Visible = false;

            DataGridViewTextBoxColumn col2 = new DataGridViewTextBoxColumn();
            col2.HeaderText = "name";
            col2.Name = "name";
            col2.DataPropertyName = "name";
            col2.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            DataGridViewTextBoxColumn col3 = new DataGridViewTextBoxColumn();
            col3.HeaderText = "price";
            col3.Name = "price";
            col3.DataPropertyName = "price";
            col3.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;

            dataGridView_dish.Columns.AddRange(new DataGridViewColumn[] { col0, col1, col2, col3 });
        }

    }

    class oFilter
    {
        private string _tabName;
        private int _carte;
        private int _dishesgroup;
        private int _dishes;

	    public int Dishes
	    {
		    get { return _dishes;}
		    set { _dishes = value;}
	    }
	
	    public int Dishesgroup
	    {
		    get { return _dishesgroup;}
		    set { _dishesgroup = value;}
	    }

	    public int Carte
	    {
		    get { return _carte;}
		    set { _carte = value;}
	    }
	
	    public string TabName
	    {
		    get { return _tabName;}
		    set { _tabName = value;}
	    }
    }
}
