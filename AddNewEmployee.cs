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
    public partial class AddNewEmployee : Form
    {
        private static AddNewEmployee uniqueInstance = null;

        private static String empType="none";

        String fileName;

        Employee employeeModel = new Employee();
        Driver driverModel = new Driver();
        Cleaner cleanerModel = new Cleaner();
        Reception receptionModel = new Reception();
        HeadChef HeadchefModel = new HeadChef();

        private AddNewEmployee()
        {
            InitializeComponent();
        }

        public static AddNewEmployee getInstance()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new AddNewEmployee();
            }
            return uniqueInstance;
        }
        private void rbdriver_CheckedChanged(object sender, EventArgs e)
        {
            empType = "driver";
            driverpanel.Show();
            driverpanel.BringToFront();

            clenaerpanel.Hide();
            receptionpanel.Hide();
            panelmanege.Hide();
            headchefpanel.Hide();
        }

        private void rbmanager_CheckedChanged(object sender, EventArgs e)
        {
            empType = "manager";
            panelmanege.Show();
            panelmanege.BringToFront();

            clenaerpanel.Hide();
            receptionpanel.Hide();
            driverpanel.Hide();
            headchefpanel.Hide();

        }

        private void rbcleaner_CheckedChanged(object sender, EventArgs e)
        {
            empType = "cleaner";
            panelmanege.Hide();
            receptionpanel.Hide();
            driverpanel.Hide();
            headchefpanel.Hide();

            clenaerpanel.Show();
            clenaerpanel.BringToFront();
        }

        private void rbreception_CheckedChanged(object sender, EventArgs e)
        {
            empType = "receptionist";
            receptionpanel.Show();
            receptionpanel.BringToFront();

            panelmanege.Hide();
            clenaerpanel.Hide();
            driverpanel.Hide();
            headchefpanel.Hide();
        }

        private void rbheadchef_CheckedChanged(object sender, EventArgs e)
        {
            empType = "headChef";
            panelmanege.Hide();
            clenaerpanel.Hide();
            driverpanel.Hide();
            receptionpanel.Hide();

            headchefpanel.Show();
            headchefpanel.BringToFront();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            employeeModel.employeeId = txtempid.Text;
            employeeModel.fname = txtfname.Text;
            employeeModel.lname = txtlname.Text;
            employeeModel.dob = txtdob.Value;
            employeeModel.contactno = Int32.Parse(txtconatcno.Text);
            employeeModel.nic = txtnic.Text;
            employeeModel.matrialstatus = txtmatrialststus.Text;
            employeeModel.email = txtemail.Text;
            employeeModel.basicsalary = Int32.Parse(txtbasicsal.Text);
            employeeModel.gender =cmbgender.Text;
            employeeModel.nationality =txtnationality.Text;

            //imagee 
            employeeModel.image = Util.convertImageToBinary(picBoxEmp.Image);


            if (empType == "driver")
            {
                driverModel.driverid = txtempid.Text;
                driverModel.licenceNo = Int32.Parse(txtlicenno.Text);
                driverModel.service = txtservice.Text;

                using(DBEntities db = new DBEntities())
                {
                    db.Employees.Add(employeeModel);
                    db.Drivers.Add(driverModel);
                    db.SaveChanges();
                    MessageBox.Show("Driver added Successfully!!!");
                }


            }else if (empType == "cleaner")
            {
                cleanerModel.cleanerid = txtempid.Text;
                cleanerModel.ctype = txtclenertype.Text;

                using(DBEntities db = new DBEntities())
                {
                    db.Cleaners.Add(cleanerModel);
                    db.SaveChanges();
                    MessageBox.Show("Clear added Successfully!!!");
                   
                }
            }else if (empType == "Reception")
            {
                receptionModel.receptionid = txtempid.Text;
                receptionModel.language = txtlanguages.Text;

                using (DBEntities db = new DBEntities()) 
                {
                    db.Receptions.Add(receptionModel);
                    db.SaveChanges();
                    MessageBox.Show("Clear added Successfully!!!");
                }
            }
            else
            {
                HeadchefModel.headchefid = txtempid.Text;
                HeadchefModel.service = txtservice.Text;

                using(DBEntities db=new DBEntities())
                {
                    db.HeadChefs.Add(HeadchefModel);
                    db.SaveChanges();
                    MessageBox.Show("Clear added Successfully!!!");
                }
            }


        }//end of save event 

        private void btnbrowser_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "JPEG|*.jpg", ValidateNames = true, Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    fileName = ofd.FileName;
                    picBoxEmp.Image = Image.FromFile(fileName);
                }


            }
                
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
           String key= Util.generateKey(empType);
            txtempid.Text = key;
        }
    }
}
