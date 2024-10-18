using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline
{
    internal class Flight_Information
    {

        string FlightID = "", Origin = "", Destination = "", Capacity = "", FlightDate = "", FlightTime = "";

        public string flightID_sg
        {
            set { FlightID = value; }
            get { return FlightID; }
        }

        public string Origin_sg
        {
            set { Origin = value; }
            get { return Origin; }
        }

        public string Destination_sg
        {
            set { Destination = value; }
            get { return Destination; }
        }

        public string Capacity_sg
        {
            set { Capacity = value; }
            get { return Capacity; }
        }

        public string FlightDate_sg
        {
            set { FlightDate = value; }
            get { return FlightDate; }
        }

        public string FlightTime_sg
        {
            set { FlightTime = value; }
            get { return FlightTime; }
        }

        public void insert_Flight()
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\AvalPc\\source\\repos\\Airline\\Airline\\bin\\Debug\\DBAirLine.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("insert_Flight", con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FlightID", FlightID);
            cmd.Parameters.AddWithValue("@Origin", Origin);
            cmd.Parameters.AddWithValue("@Destination", Destination);
            cmd.Parameters.AddWithValue("@Capacity", Capacity);
            cmd.Parameters.AddWithValue("@FlightDate", FlightDate);
            cmd.Parameters.AddWithValue("@FlightTime", FlightTime);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("اطلاعات پرواز با موفقیت ثبت شد");
            }

            catch (SqlException erorr)
            {

                MessageBox.Show(erorr.Message);


            }


        }


        public DataTable Search_Flight_ID()
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\AvalPc\\source\\repos\\Airline\\Airline\\bin\\Debug\\DBAirLine.mdf;Integrated Security=True");
            SqlDataAdapter data = new SqlDataAdapter("Search_Flight", con);

            data.SelectCommand.CommandType = CommandType.StoredProcedure;

            data.SelectCommand.Parameters.AddWithValue("@FlightID", FlightID);

            DataTable dtBL = new DataTable();
            data.Fill(dtBL);

            return dtBL;
        }


        public void edit_Flight()
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\AvalPc\\source\\repos\\Airline\\Airline\\bin\\Debug\\DBAirLine.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("edit_Flight", con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FlightID", FlightID);
            cmd.Parameters.AddWithValue("@Origin", Origin);
            cmd.Parameters.AddWithValue("@Destination", Destination);
            cmd.Parameters.AddWithValue("@Capacity", Capacity);
            cmd.Parameters.AddWithValue("@FlightDate", FlightDate);
            cmd.Parameters.AddWithValue("@FlightTime", FlightTime);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("اطلاعات پرواز با موفقیت ویرایش شد");
            }

            catch (SqlException erorr)
            {

                MessageBox.Show(erorr.Message);


            }

        }


        public void Delete_Flight()
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\AvalPc\\source\\repos\\Airline\\Airline\\bin\\Debug\\DBAirLine.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("Delete_Flight", con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@FlightID", FlightID);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("اطلاعات پرواز با موفقیت حذف شد");

            }

            catch (SqlException erorr)
            {
                MessageBox.Show(erorr.Message);
            }
        }

    }
}
