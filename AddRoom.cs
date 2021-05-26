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
    public partial class AddRoom : Form
    {
        public AddRoom()
        {
            InitializeComponent();
        }

        Room_bll u = new Room_bll();
        Room_dal dal = new Room_dal();

        private void txtRoomNum_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void txtmaxAdult_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void btnEditroom_Click(object sender, EventArgs e)
        {
            // get the valuse from ui 

            u.RoomNo = Convert.ToInt32(txtRoomNum.Text);
            u.BedType = comboRoomtyp.Text;
            u.MaxAdult = txtmaxAdult.Text;
            u.Floor_ = txtfloor.Text;
            u.RoomType = comboRoomtyp.Text;

            // update data into database

            bool success = dal.Update(u);
            // if data is updated successfully then the value of success will be true else it will false

            if (success == true)
            {
                // data update successfully 
                MessageBox.Show("Room details successfully updated !");
            }
            else
            {
                MessageBox.Show("Failed to update room details");
            }


            // Refreshing data grid view 

            DataTable dt = dal.Select();
            gridRooms.DataSource = dt;
        }

        private void btnbackto_Rooms_Click(object sender, EventArgs e)
        {
            rooms rom = new rooms();
            rom.Show();
            this.Close();
        }

        private void btnSaveRoom_Click(object sender, EventArgs e)
        {
            u.BedType = ComboBeadType.Text;
            u.MaxAdult = txtmaxAdult.Text;
            u.Floor_ = txtfloor.Text;
            u.RoomType = comboRoomtyp.Text;
            u.available = "1";

            bool succcess = dal.Insert(u);

            if (succcess == true)
            {
                MessageBox.Show(" Room successfully added");
                clear();
            }
            else
            {
                MessageBox.Show(" Failed to add new room");
            }

            // Refreshing data grid view 

            DataTable dt = dal.Select();
            gridRooms.DataSource = dt;
        }

        private void AddRoom_Load(object sender, EventArgs e)
        {

            DataTable dt = dal.Select();
            gridRooms.DataSource = dt;

        }
        private void clear()
        {
            ComboBeadType.Text = " ";
            txtmaxAdult.Text = " ";
            txtfloor.Text = " ";
            comboRoomtyp.Text = " ";

        }

        private void btnResetRoom_Click(object sender, EventArgs e)
        {
            clear();

        }

        private void gridRooms_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // get index of particular row
            int rowIndex = e.RowIndex;
            txtRoomNum.Text = gridRooms.Rows[rowIndex].Cells[0].Value.ToString();
            ComboBeadType.Text = gridRooms.Rows[rowIndex].Cells[1].Value.ToString();
            txtmaxAdult.Text = gridRooms.Rows[rowIndex].Cells[2].Value.ToString();
            txtfloor.Text = gridRooms.Rows[rowIndex].Cells[3].Value.ToString();
            comboRoomtyp.Text = gridRooms.Rows[rowIndex].Cells[4].Value.ToString();


        }

        private void btndeleteRoom_Click(object sender, EventArgs e)
        {
            // gettinng room details from gread

            u.RoomNo = Convert.ToInt32(txtRoomNum.Text);
            bool success = dal.Delete(u);
            // if data is updated successfully then the value of success will be true else it will false

            if (success == true)
            {
                MessageBox.Show("Room details deleted successfully");
                clear();
            }
            else
            {
                MessageBox.Show("Failed to delete Room details");
            }

            // refreshing datagrid view
            DataTable dt = dal.Select();
            gridRooms.DataSource = dt;
        }
    }
}
