using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Sarasi_HMS
{
    class Util
    {
        private static String startLetter;
        private static int randomnumber;
        private static String key;
        private static bool result;

        public static String categoryID;
        private static FoodCategory fCategory;
        private static ItemCategory ICategory;



        private static List<FoodCategory> foodcategoriesID;
        private static List<ItemCategory> ItemcategoryIDs;
        private static List<Food> foodCodes;
        private static List<Item> itemIds;
        private static List<Employee> employeeIDs;

        //method to generate a unique key 
        public static String generateKey(String tableName)
        {
            Random random = new Random(); 

            do
            {
                randomnumber = random.Next(0, 10000); //generateb random number 
                using (DBEntities db = new DBEntities())
                {
                    if (tableName == "FoodCategory")
                    {
                        startLetter = "Fc";
                        key = startLetter + randomnumber;
                        foodcategoriesID = db.FoodCategories.ToList();
                        result = foodcategoriesID.Exists(x => x.foodCategoryID.Contains(key));

                        

                    } else if (tableName == "ItemCategory_KtchenItem" || tableName == "ItemCategory_ReadyMade")
                    {
                        if (tableName == "ItemCategory_KtchenItem")
                        {
                            startLetter = "KIc";
                        } else if (tableName == "ItemCategory_ReadyMade")
                        {

                            startLetter = "RPc";
                        }

                        key = startLetter + randomnumber;
                        ItemcategoryIDs = db.ItemCategories.ToList();
                        result = ItemcategoryIDs.Exists(x => x.itemCategoryID.Contains(key));

                    } else if (tableName == "food")
                    {
                        startLetter = "F";
                        key = startLetter + randomnumber;
                        foodCodes = db.Foods.ToList();
                        result = foodCodes.Exists(x => x.foodCode.Contains(key));


                    }
                    else if (tableName == "readyMade")
                    {
                        startLetter = "RP";
                        key = startLetter + randomnumber;
                        itemIds = db.Items.ToList();
                        result = itemIds.Exists(x => x.itemID.Contains(key));

                    }else if (tableName == "driver" || tableName== "cleaner" || tableName== "receptionist" || tableName=="manager" || tableName=="headChef")
                    {
                        if (tableName == "driver")
                        {
                            startLetter = "D";
                        }else if (tableName == "cleaner")
                        {
                            startLetter = "C";
                        }
                        else if (tableName == "manager")
                        {
                            startLetter = "M";
                        }
                        else if (tableName == "headChef")
                        {
                            startLetter = "hc";
                        }
                        else if (tableName == "receptionist")
                        {
                            startLetter = "Rc";
                        }

                        key = startLetter + randomnumber;
                        employeeIDs = db.Employees.ToList();
                        result = employeeIDs.Exists(x => x.employeeId.Contains(key));
                    }
                   
                }

            } while (result == true);
            return key;
        }//end of the generate key method 
    
        //method to get the selected categorie's id 
        public static String getCategoryID(String tableName, String categoryName)
        {
            using(DBEntities db = new DBEntities())
            {
                if (tableName == "FoodCategory")
                {
                    fCategory = db.FoodCategories.Where(fc => fc.name == categoryName).First();
                    categoryID = fCategory.foodCategoryID;
                }
                else if (tableName == "ItemCategory")
                {
                    ICategory = db.ItemCategories.Where(fc => fc.categoryName == categoryName).First();
                    categoryID = ICategory.itemCategoryID;
                }
            }

           
            return categoryID; ; //if not found 
        }// end of getCategory Function -------------------------------------------------


        //Method for convert an byte array to an image 
        public static Image convertBinaryToImage(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                return Image.FromStream(ms);
            }
        }

        //method to convert the image into an byte array
        public static byte[] convertImageToBinary(Image img)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                return ms.ToArray();
            }

        }



    }
}
