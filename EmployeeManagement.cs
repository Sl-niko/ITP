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
    public partial class EmployeeManagement : Form
    {
        private static EmployeeManagement uniqueInstance = null;


        private EmployeeManagement()
        {
            InitializeComponent();
        }

        public static EmployeeManagement getInstance()
        {
            if (uniqueInstance == null)
            {
                uniqueInstance = new EmployeeManagement();
            }
            return uniqueInstance;
        }

        private void Btnemployee_Click(object sender, EventArgs e)
        {
            AddNewEmployee addEmp = AddNewEmployee.getInstance();
            this.Hide();
            addEmp.Show();
        }
    }
}
