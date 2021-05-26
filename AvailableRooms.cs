using Sarasi_HMS.BLL;
using Sarasi_HMS.DAL;
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
    public partial class AvailableRooms : Form
    {
        public AvailableRooms()
        {
            InitializeComponent();
        }

        Room_bll g = new Room_bll();
        Room_dal dal = new Room_dal();

        private void btnbackto_Rooms2_Click(object sender, EventArgs e)
        {
            rooms rm = new rooms();
            rm.Show();
            this.Close();
        }

        private void AvailableRooms_Load(object sender, EventArgs e)
        {
            // refreshing Data table


            DataTable dt = dal.availableRoom(); ;

            greidAvilRoom.DataSource = dt;
        }

        private void btnShowAvila_Click(object sender, EventArgs e)
        {
            // refreshing Data table


            DataTable dt = dal.availableRoom(); ;

            greidAvilRoom.DataSource = dt;
        }
    }
}
