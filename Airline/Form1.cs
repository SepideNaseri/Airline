using System.Data;
using System.Linq.Expressions;

namespace Airline
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Btnsave_Click(object sender, EventArgs e)
        {
            PersonClass pClass = new PersonClass();

            pClass.codemeli_sg = txtcodemeli.Text;
            pClass.PersonName_sg = txtname.Text;
            pClass.Fname_sg = txtFname.Text;

            if (Rbtnfemale.Checked == true)
                pClass.Gender_sg = "زن";
            else if (RbtnMale.Checked == true)
                pClass.Gender_sg = "مرد";

            if (Rbtnsingle.Checked == true)
                pClass.Marriage_sg = "مجرد";
            else if (Rbtnmarry.Checked == true)
                pClass.Marriage_sg = "متاهل";

            pClass.BirthdayDate_sg = txtyear.Text + "/" + txtmonth.Text + "/" + txtday.Text;

            pClass.insert_Person();




        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            PersonClass pClass = new PersonClass();

            pClass.codemeli_sg = T2txtcodemeli.Text;

            DataTable dt = pClass.Search_person_id();

            if (dt.Rows.Count == 0)
                MessageBox.Show("این کد ملی قبلا ثبت نشده است");
            else
            {
                panel1.Enabled = true;
                T2txtname.Text = dt.Rows[0]["PersonName"].ToString();
                T2txtfamily.Text = dt.Rows[0]["Fname"].ToString();

                if (dt.Rows[0]["Gender"].ToString() == "زن")
                    T2rdbfemale.Checked = true;
                else if (dt.Rows[0]["Gender"].ToString() == "مرد")
                    T2rdbmale.Checked = true;

                if (dt.Rows[0]["Marriage"].ToString() == "مجرد")
                    T2rdbsingle.Checked = true;
                else if (dt.Rows[0]["Marriage"].ToString() == "متاهل")
                    T2rdbmarry.Checked = true;

                string[] tt = dt.Rows[0]["BirthdayDate"].ToString().Split('/');

                T2txtyear.Text = tt[0];
                T2txtmonth.Text = tt[1];
                T2txtday.Text = tt[2];
            }

        }

        private void btnedit_Click(object sender, EventArgs e)
        {
            PersonClass pClass = new PersonClass();

            pClass.codemeli_sg = T2txtcodemeli.Text;
            pClass.PersonName_sg = T2txtname.Text;
            pClass.Fname_sg = T2txtfamily.Text;

            if (T2rdbfemale.Checked == true)
                pClass.Gender_sg = "زن";
            else if (T2rdbmale.Checked == true)
                pClass.Gender_sg = "مرد";

            if (T2rdbsingle.Checked == true)
                pClass.Marriage_sg = "مجرد";
            else if (T2rdbmarry.Checked == true)
                pClass.Marriage_sg = "متاهل";

            pClass.BirthdayDate_sg = T2txtyear.Text + "/" + T2txtmonth.Text + "/" + T2txtday.Text;

            pClass.edit_person();

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            PersonClass pClass = new PersonClass();

            pClass.codemeli_sg = T2txtcodemeli.Text;

            pClass.Delete_person();
        }

        private void Tb3btnInsert_Click(object sender, EventArgs e)
        {
            Flight_Information Fclass = new Flight_Information();

            Fclass.flightID_sg = Tb3txtFlight.Text;
            Fclass.Origin_sg = txtTb3origin.Text;
            Fclass.Destination_sg = Tb3txtDestination.Text;
            Fclass.Capacity_sg = Tb3txtcapecity.Text;

            Fclass.FlightTime_sg = Tb3cmbTime.Text + ":" + Tb3cmbminute.Text;


            Fclass.FlightDate_sg = Tb3txtyear.Text + "/" + Tb3txtmonth.Text + "/" + Tb3txtdate.Text;

            Fclass.insert_Flight();

        }

        private void TB4btnsearchf_Click(object sender, EventArgs e)
        {

            Flight_Information Fclass = new Flight_Information();

            Fclass.flightID_sg = TB4txtFlightid.Text;

            DataTable dtBL = Fclass.Search_Flight_ID();

            if (dtBL.Rows.Count == 0)
                MessageBox.Show("این کد پرواز قبلا ثبت شده است");

            else
            {
                panel2.Enabled = true;
                tb4txtorigin.Text = dtBL.Rows[0]["Origin"].ToString();
                tb4txtdestination.Text = dtBL.Rows[0]["Destination"].ToString();
                tb4txtcapacity.Text = dtBL.Rows[0]["Capacity"].ToString();


                string[] clock = dtBL.Rows[0]["FlightTime"].ToString().Split(':');

                tb4cmbhour.Text = clock[0];
                tb4cmbmin.Text = clock[1];


                string[] ttt = dtBL.Rows[0]["FlightDate"].ToString().Split('/');

                tb4txtyear.Text = ttt[0];
                tb4txtmonth.Text = ttt[1];
                tb4txtday.Text = ttt[2];

            }

        }

        private void tb4btnedit_Click(object sender, EventArgs e)
        {

            Flight_Information Fclass = new Flight_Information();

            Fclass.flightID_sg = TB4txtFlightid.Text;
            Fclass.Origin_sg = tb4txtorigin.Text;
            Fclass.Destination_sg = tb4txtdestination.Text;
            Fclass.Capacity_sg = tb4txtcapacity.Text;

            Fclass.FlightTime_sg = tb4cmbhour.Text + ":" + tb4cmbmin.Text;


            Fclass.FlightDate_sg = tb4txtyear.Text + "/" + tb4txtmonth.Text + "/" + tb4txtday.Text;

            Fclass.edit_Flight();


        }

        private void tb4btndelete_Click(object sender, EventArgs e)
        {
            Flight_Information Fclass = new Flight_Information();

            Fclass.flightID_sg = TB4txtFlightid.Text;

            Fclass.Delete_Flight();
        }

        private void tb5btnserach_Click(object sender, EventArgs e)
        {
            PersonClass pClass = new PersonClass();
            pClass.PersonName_sg = tb5txtname.Text;
            pClass.Fname_sg = tb5txtfname.Text;

            DataSet ds = pClass.Search_Person_by_fname_name();

            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = ds.Tables["TBlInformationPerson"];
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;

            tb5txtcodemeli.Text = dataGridView1.Rows[i].Cells["Codemeli"].Value.ToString();
            tb5txtnameview.Text = dataGridView1.Rows[i].Cells["PersonName"].Value.ToString();
            tb5txtfnameview.Text = dataGridView1.Rows[i].Cells["Fname"].Value.ToString();

            string[] tt = dataGridView1.Rows[i].Cells["BirthdayDate"].Value.ToString().Split('/');

            tb5txtyear.Text = tt[0];
            tb5txtmonth.Text = tt[1];
            tb5txtday.Text = tt[2];

            if (dataGridView1.Rows[i].Cells["Gender"].Value.ToString() == "زن")
                tb5rdbwoman.Checked = true;
            if (dataGridView1.Rows[i].Cells["Gender"].Value.ToString() == "مرد")
                tb5rdbmale.Checked = true;

            if (dataGridView1.Rows[i].Cells["Marriage"].Value.ToString() == "مجرد")
                tb5rdbsingle.Checked = true;
            if (dataGridView1.Rows[i].Cells["Marriage"].Value.ToString() == "متاهل")
                tb5rdbmarried.Checked = true;

           
             




        }
    }
}
