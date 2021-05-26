using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sarasi_HMS
{
    public partial class testBillRow : UserControl
    {
        public testBillRow()
        {
            InitializeComponent();
        }

        public string FName
        {
            get { return lblName.Text; }
            set { lblName.Text = value; }
        }
        public string Quantity
        {
            get { return lblQty.Text; }
            set { lblQty.Text = value; }
        }

        public string total
        {
            get { return lblSubTotal.Text; }
            set { lblSubTotal.Text = value; }
        }
    }
}
