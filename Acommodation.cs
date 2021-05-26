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
    public partial class Acommodation : Form
    {
        public Acommodation()
        {
            InitializeComponent();
        }

        private void btnRooms_Click(object sender, EventArgs e)
        {
            rooms room = new rooms();
            room.Show();
            this.Close();
        }
    }
}
