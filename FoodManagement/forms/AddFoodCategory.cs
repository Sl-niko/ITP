using Guna.UI.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;


namespace Sarasi_HMS
{
    public partial class AddFoodCategory : Form
    {
        private static AddFoodCategory uniqueInstance = null;
        private String status = "insert"; //add or update

        FoodCategory foodCategory = new FoodCategory(); //instance of the table 

        private AddFoodCategory()
        {
            InitializeComponent();
        }

        public static AddFoodCategory getInstance()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new AddFoodCategory();
            }
            return uniqueInstance;
        }  

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Categories categories = Categories.getInstance();
            this.Hide();
            categories.Show();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //taking the user inputs and preparing the object 
            foodCategory.foodCategoryID = txtCategoryID.Text;
            foodCategory.name  = txtCategoryName.Text;
            foodCategory.description = txtCategoryDescription.Text;


            using (DBEntities db = new DBEntities())
            {
                if (status == "insert")
                {
                    db.FoodCategories.Add(foodCategory);
                   
                    MessageBox.Show("Category Added Successfully");
                }
                else if (status == "update")
                {
                    //updating the database 
                    db.Entry(foodCategory).State = EntityState.Modified;
                   
                    MessageBox.Show("Category Updated Successfully");
                }

                try
                {
                    db.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                {
                    foreach (var entityValidationErrors in ex.EntityValidationErrors)
                    {
                        foreach (var validationError in entityValidationErrors.ValidationErrors)
                        {
                            MessageBox.Show("Property: " + validationError.PropertyName + " Error: " + validationError.ErrorMessage);
                        }
                    }
                }



                clearTexts();

            }
            //addding new Item to the Restaurant POS as a button
            RestaurantPOS.getInstance().loadCategoryButtons();


            ///-------clear the flow layout and re load the category list 
            Categories categories = Categories.getInstance();
            categories.clearCatgoryList();
            categories.loadFoodCategories();
            categories.Show();
            this.Hide();

        } // end of brnSave clicked event 


        //method to edit category details 
        public  void editcategory(String id)
        {
            //retreiving selected row 
            using(DBEntities db = new DBEntities())
            {
                //setting status to update
                status = "update";
                btnSave.Text = "Update";

                foodCategory = db.FoodCategories.Where(x => x.foodCategoryID == id).FirstOrDefault();
                MessageBox.Show(foodCategory.foodCategoryID);

                //storing values to the textboxes
                txtCategoryID.Text = foodCategory.foodCategoryID;
                txtCategoryName.Text = foodCategory.name;
                txtCategoryDescription.Text = foodCategory.description;

                
            }
        }//end of edit item category method

    

        public void clearTexts()
        {
            txtCategoryDescription.Text = txtCategoryID.Text = txtCategoryName.Text = "";
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            
            String result = Util.generateKey("FoodCategory");
            MessageBox.Show(result);
            txtCategoryID.Text = result;
        }
    }
}
