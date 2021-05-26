using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sarasi_HMS.BLL;

namespace Sarasi_HMS.DAL
{
    class Room_dal
    {
        static string myconnstrng = ConfigurationManager.ConnectionStrings["DBEntities1"].ConnectionString;

        #region Select Data from Database

        public DataTable Select()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();
            try
            {
                String sql = "SELECT * FROM Room";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }
        #endregion

        #region Insert Data in Database

        public bool Insert(Room_bll u)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                String sql = "INSERT INTO Room(BedType,MaxAdult,Floor_,RoomType,available) VALUES (@BedType,@MaxAdult,@Floor_,@RoomType,@available)";
                SqlCommand cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddWithValue("@BedType", u.BedType);
                cmd.Parameters.AddWithValue("@MaxAdult", u.MaxAdult);
                cmd.Parameters.AddWithValue("@Floor_", u.Floor_);
                cmd.Parameters.AddWithValue("@RoomType", u.RoomType);
                cmd.Parameters.AddWithValue("@available", u.available);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }

        #endregion


        #region Updaate Data in Dataabase
        public bool Update(Room_bll u)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);
            try
            {
                string sql = "UPDATE Room SET BedType=@BedType,MaxAdult=@MaxAdult,Floor_=@Floor_,RoomType=@RoomType WHERE RoomNo=@RoomNo ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@BedType", u.BedType);
                cmd.Parameters.AddWithValue("@MaxAdult", u.MaxAdult);
                cmd.Parameters.AddWithValue("@Floor_", u.Floor_);
                cmd.Parameters.AddWithValue("@RoomType", u.RoomType);
                cmd.Parameters.AddWithValue("@RoomNo", u.RoomNo);


                conn.Open();

                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }


            return isSuccess;
        }

        #endregion


        #region Delete Data from DAtabase


        public bool Delete(Room_bll u)
        {
            bool isSuccess = false;
            SqlConnection conn = new SqlConnection(myconnstrng);

            try
            {
                string sql = "DELETE FROM Room WHERE RoomNo= @RoomNo ";

                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@RoomNo", u.RoomNo);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conn.Close();
            }
            return isSuccess;
        }

        #endregion


        #region Search user

        public DataTable Search(string Keywords)
        {
            SqlConnection conn = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();
            try
            {
                String sql = "SELECT * FROM Room WHERE RoomNo LIKE '%" + Keywords + "%'  OR MaxAdult LIKE'%" + Keywords + "%' ";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        #endregion




        #region Select Avilable Rooms

        public DataTable availableRoom()
        {
            SqlConnection conn = new SqlConnection(myconnstrng);

            DataTable dt = new DataTable();

            try
            {
                string sql = "SELECT * FROM Room WHERE available='1'";
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                conn.Open();
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return dt;
        }

        #endregion



    }
}
