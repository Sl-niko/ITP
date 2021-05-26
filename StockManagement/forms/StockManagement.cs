using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sarasi_HMS
{
    
    public partial class StockManagement : Form
    {

        private static StockManagement uniqueInstance = null;
        //list of Panels 
        public static List<Button> StockManagementButtons = new List<Button>();
        public static List<Panel> StockManagementPanels = new List<Panel>();
        
        private StockManagement()
        {
            InitializeComponent();
            initialAdd();
            setDefaultValues();
            Settings.ApplyThemes(Color.Black, Color.Black, Settings.zColor(246, 255, 199), Color.White, Color.Chartreuse, Color.White, Color.Yellow);
            //applying light theme initially

        }

        private void setDefaultValues()
        {
            DateTime time = DateTime.Now.ToLocalTime();
            lblDateTime.Text = time.ToString();
        }

        public void initialAdd()
        {
            //adding Pannels
            StockManagementPanels.Add(panelBottomStock);
            StockManagementPanels.Add(panelMainStock);
            Settings.AllPanels.AddRange(StockManagementPanels);
           
           
            //adding buttons
            StockManagementButtons.Add(btnAddNewItems);
            StockManagementButtons.Add(btnItemAlertsStock);
            StockManagementButtons.Add(btnItemList);
            StockManagementButtons.Add(btnReportsStock);
            StockManagementButtons.Add(btnBackStock);
           

            //Add to AllButtons
            Settings.AllButtons.AddRange(StockManagementButtons);



        }
        public static StockManagement getInstance()
        {

            if(uniqueInstance == null)
            {

                uniqueInstance = new StockManagement();
            }
            return uniqueInstance;
        }
        private void btnItemList_Click(object sender, EventArgs e)
        {
            itemAlert1.Hide();
            addItems1.Hide();
            itemProgress1.Hide();
            flowLayoutPanel.Show();
            flowLayoutPanel.BringToFront();
        }

        private void btnFoodAlerts2_Click(object sender, EventArgs e)
        {
            flowLayoutPanel.Hide();
            itemProgress1.Hide();
            addItems1.Hide();
            itemAlert1.Show();
            itemAlert1.BringToFront();
        }

        private void btnReports_Click(object sender, EventArgs e)
        {
            itemAlert1.Hide();
            addItems1.Hide();
            flowLayoutPanel.Hide();
            itemProgress1.Show();
            itemProgress1.BringToFront();
        }

        private void StockManagement_Load(object sender, EventArgs e)
        {
            itemAlert1.Hide();
            addItems1.Hide();
            itemProgress1.Hide();
            flowLayoutPanel.Show();
            flowLayoutPanel.BringToFront();

        }

        private void btnAddNewItems_Click(object sender, EventArgs e)
        {
            itemAlert1.Hide();
            itemProgress1.Hide();
            flowLayoutPanel.Hide();
            addItems1.Show();
            addItems1.BringToFront();
        }

        private void btnBackStock_Click(object sender, EventArgs e)
        {
            AdminPanelForm apf = AdminPanelForm.getInstance();
            this.Hide();
            apf.Show();
        }

        private void btnItemcategories_Click(object sender, EventArgs e)
        {
            ItemCategories ic = ItemCategories.getInstance();
            this.Hide();
            ic.Show();
        }
    }
}
