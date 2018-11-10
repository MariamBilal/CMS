using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ADbms_project
{
    public partial class Form5 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\New folder\ADBMS project\CMS_PROJECT1.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
       // SqlDataReader dr;
        

        public Form5()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            mASTER_FORM mf = new mASTER_FORM();
            mf.Show();
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            comboBox2.Items.Add("1st Bi-Monthly");
            comboBox2.Items.Add("Send-up");
            comboBox2.Items.Add("Resend-up");
            comboBox2.Items.Add("Pre-Board");
            comboBox2.Items.Add("Board");

            comboBox3.Items.Add("Pass");
            comboBox3.Items.Add("Fail");



            //fetch data for student ID

            
              /* con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = con.CreateCommand();
               // SqlDataReader dr = null;

                string FetchData = "Select StudentName from Student_data where StudentID = '"+textBox5.Text+"'";
               cmd = new SqlCommand(FetchData, con);
               
              SqlDataReader dr = cmd.ExecuteReader();
                if(dr.Read())
                {

                    textBox1.Text = dr.GetValue(0).ToString();
                    //textBox1.Text = dr[0].ToString();
                
                 } */

           /*con.Open();
            SqlCommand cmd;
            SqlDataReader reader;

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    textBox1.Text = (reader["StudentName/*"].ToString());

                }
            }
            */


            //funtion for Display data
            disp_data();

            display_data();

        }

        public void disp_data()
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select * from MarksEntery_data";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }

            catch (Exception)
            {
                MessageBox.Show("Data Can't b display");

            }
      }


        public void display_data()
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "Select StudentID,StudentName,SClass from Student_data";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView2.DataSource = dt;
                con.Close();
            }

            catch (Exception)
            {
                MessageBox.Show("Display Error");

            }


        }


        private void Insert_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "insert into MarksEntery_data values ('" + textBox5.Text + "','" + dateTimePicker1.Value.ToString("yyyyMMdd") + "','" + comboBox2.Text + "','" + textBox6.Text.ToString() + "','" + textBox7.Text.ToString() + "','" + textBox8.Text.ToString() + "','" + textBox10.Text + "','" + textBox9.Text.ToString() + "','" + comboBox3.Text + "')";

                cmd.ExecuteNonQuery();
                con.Close();


                //textBox2.Text = "";
                comboBox2.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";
                textBox5.Text = "";
                comboBox3.Text = "";
                dateTimePicker1.Text = "";

                disp_data();

                MessageBox.Show("Record Inserted Successfully !!");

                con.Close();
            }

            catch (Exception ex)
            {


                MessageBox.Show("Error. Data is not inserted" + ex);

            }

        }

        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "delete from MarksEntery_Data where StudentID ='" + textBox5.Text + "'";
                cmd.ExecuteNonQuery();
                con.Close();


                comboBox2.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";
                textBox5.Text = "";
                comboBox3.Text = "";
                dateTimePicker1.Text = "";

                disp_data();

                MessageBox.Show("Record Deleted Successfully !!");
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }


        }

        private void Update_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form6 f6 = new Form6();
            f6.Show();

        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void Search_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "select * from MarksEntery_data where StudentID='" + textBox5.Text + "'";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
                textBox5.Text = "";
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Value.ToString("yyyyMMdd");
        }


    }
}
