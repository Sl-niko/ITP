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
    public partial class rooms : Form
    {
        public rooms()
        {
            InitializeComponent();
        }

        private void btnAddroom_Click(object sender, EventArgs e)
        {
            AddRoom addroomm = new AddRoom();
            addroomm.Show();
            this.Close();
        }

        private void Btnavaibile1_Click(object sender, EventArgs e)
        {
            AvailableRooms avil = new AvailableRooms();
            avil.Show();
            this.Close();

            
        }
    }
}
