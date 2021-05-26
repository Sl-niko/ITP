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

    public partial class RestaurantPOS : Form
    {
        //unique instance 
        private static RestaurantPOS uniqueInstance = null;

            //List of Controls
        public static List<Panel> ResPOSPanels = new List<Panel>();
        public static List<Button> ResPOSButtons = new List<Button>();

        //list of category Buttons
        private static List<foodcategoryButton> foodCategoryButtonList = new List<foodcategoryButton>();
      
        private static List<FoodCategory> foodCategoryList = new List<FoodCategory>();
        private static foodcategoryButton foodcategorybutton;

        POSsettings posSettings = POSsettings.getInstance();

        private RestaurantPOS()
        {
            InitializeComponent();
            initialAdd();

            posSettings.ApplyThemes(Color.Black, Color.Black);
        }

        public static RestaurantPOS getInstance()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new RestaurantPOS();
            }
            return uniqueInstance;
        }
        private void initialAdd()
        {
            //panels
            ResPOSPanels.Add(flowPanelCategories);
            ResPOSPanels.Add(flowPanelFoods);
            ResPOSPanels.Add(panelMainResPOS);
            ResPOSPanels.Add(panelBottomResPOS);
            ResPOSPanels.Add(panelBill);
            ResPOSPanels.Add(panelTotal);

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

        private void flowPanelFoods_Paint(object sender, PaintEventArgs e)
        { 
        }

        private void btnPOSSettings_Click(object sender, EventArgs e)
        {
            
            posSettings.Show();
            posSettings.BringToFront();
           
        }

        private void RestaurantPOS_Load(object sender, EventArgs e)
        {
            //formload 
            loadCategoryButtons();


        }

        //----------Manage Category buttons-
        public  void loadCategoryButtons()
        {
            //clear the list 
            foodCategoryButtonList.Clear();
            clearFlowcategorybutton();

            using (DBEntities db = new DBEntities())
            {
                foodCategoryList = db.FoodCategories.ToList();
            }

            foreach(FoodCategory Item in foodCategoryList)
            {
                //creating new Button
                foodcategorybutton = new foodcategoryButton();
                foodcategorybutton.ButtonName = Item.name;
                foodcategorybutton.ButtonID = Item.foodCategoryID; 
                //add button to the List 
                foodCategoryButtonList.Add(foodcategorybutton);
            }   

            //load button list to the flow panel 
            foreach(foodcategoryButton Item in foodCategoryButtonList)
            {
                flowPanelCategories.Controls.Add(Item);
            }
        }

        public void clearFlowcategorybutton()
        {
            flowPanelCategories.Controls.Clear();
        }




        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCancelFood_Click(object sender, EventArgs e)
        {
            KitchenPOS kitchenPOS = KitchenPOS.getInstance();
            this.Hide();
            kitchenPOS.Show();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = Login.getInstance();
            login.Show();
        }
    }
}
