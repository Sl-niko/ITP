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
    public partial class KitchenPOS : Form
    {
        //unique instance 
        private static KitchenPOS uniqueInstance = null;

        public static List<Panel> KitchenPOSPanels = new List<Panel>();
        kitchenPOSSettings kitchenPosSettings = kitchenPOSSettings.getInstance();
        private KitchenPOS()
        {
            InitializeComponent();
            initialAdd();
            kitchenPosSettings.ApplyThemes(Color.Black, Color.Black);

        }

        public static KitchenPOS getInstance()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new KitchenPOS();
            }
            return uniqueInstance;
        }
        public void initialAdd()
        {
            //adding Pannels
            KitchenPOSPanels.Add(panelBottomKitchenPOS);
            KitchenPOSPanels.Add(panelItemCategory);
            KitchenPOSPanels.Add(panelItemlist);
            KitchenPOSPanels.Add(panelMainKitchenPOS);
            KitchenPOSPanels.Add(panelOutList);

        }

        public void changeBackImage(int themenumber)
        {
            if (themenumber == 0)
            {
                this.BackgroundImage = Properties.Resources.Light;
            }
            else if (themenumber == 1)
            {
                this.BackgroundImage = Properties.Resources.posDark;
            }
        }



        private void btnPOSSettings_Click(object sender, EventArgs e)
        {

            kitchenPosSettings.Show();
            kitchenPosSettings.BringToFront();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = Login.getInstance();
            login.Show();
        }
    }
}
