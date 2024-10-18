using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Airline
{
    internal class PersonClass
    {
        string Codemeli = "", PersonName = "", Fname = "", Gender = "", Marriage = "", BirthdayDate = "";

        public string codemeli_sg
        {
            set { Codemeli = value; }
            get { return Codemeli; }
        }

        public string PersonName_sg
        {
            set { PersonName = value; }   
            get { return PersonName; }
        }

        public string Fname_sg
        {
            set { Fname = value; }
            get { return Fname; }
        }

        public string Gender_sg
        {
            set { Gender = value; }
            get { return Gender; }

        }

        public string Marriage_sg
        {
            set { Marriage = value; }
            get { return Marriage; }
        }

        public string BirthdayDate_sg
        {
            set { BirthdayDate = value; }
            get { return BirthdayDate; }
        }

        public void insert_Person()
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\AvalPc\\source\\repos\\Airline\\Airline\\bin\\Debug\\DBAirLine.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("insert_person", con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Codemeli", Codemeli);
            cmd.Parameters.AddWithValue("@PersonName", PersonName);
            cmd.Parameters.AddWithValue("@Fname", Fname);
            cmd.Parameters.AddWithValue("Gender", Gender);
            cmd.Parameters.AddWithValue("@Marriage", Marriage);
            cmd.Parameters.AddWithValue("BirthdayDate", BirthdayDate);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("اطلاعات با موفقیت ثبت شد");
            }

            catch(SqlException erorr)
            {

                MessageBox.Show(erorr.Message);


            }

        }

        public void edit_person()
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\AvalPc\\source\\repos\\Airline\\Airline\\bin\\Debug\\DBAirLine.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("edit_person", con);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Codemeli", Codemeli);
            cmd.Parameters.AddWithValue("@PersonName", PersonName);
            cmd.Parameters.AddWithValue("@Fname", Fname);
            cmd.Parameters.AddWithValue("Gender", Gender);
            cmd.Parameters.AddWithValue("@Marriage", Marriage);
            cmd.Parameters.AddWithValue("BirthdayDate", BirthdayDate);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("اطلاعات با موفقیت ویرایش شد");
            }

            catch (SqlException erorr)
            {

                MessageBox.Show(erorr.Message);


            }

        }

        public void Delete_person()
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\AvalPc\\source\\repos\\Airline\\Airline\\bin\\Debug\\DBAirLine.mdf;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("Delete_person", con);
            cmd.CommandType= CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Codemeli", Codemeli);

            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("اطلاعات با موفقیت حذف شد");

            }

            catch (SqlException erorr)
            {
                MessageBox.Show(erorr.Message);
            }
        }

        public DataTable Search_person_id()
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\AvalPc\\source\\repos\\Airline\\Airline\\bin\\Debug\\DBAirLine.mdf;Integrated Security=True");
            SqlDataAdapter da = new SqlDataAdapter("Search_person", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.AddWithValue("@Codemeli", Codemeli);

            DataTable dt = new DataTable();
            da.Fill(dt);

            return dt;

        }


        public DataSet Search_Person_by_fname_name()
        {
            SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\AvalPc\\source\\repos\\Airline\\Airline\\bin\\Debug\\DBAirLine.mdf;Integrated Security=True");
            SqlDataAdapter da = new SqlDataAdapter("Search_person_by_fname_name", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            da.SelectCommand.Parameters.AddWithValue("@PersonName", PersonName);
            da.SelectCommand.Parameters.AddWithValue("@Fname", Fname);

            DataSet ds = new DataSet();
            da.Fill(ds, "TBlInformationPerson");

            return ds;

        }

    }
}
