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
    public partial class Form6 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\New folder\ADBMS project\CMS_PROJECT1.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        
        //SqlCommand cmd;

        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            mASTER_FORM mf = new mASTER_FORM();
            mf.Show();
        }

        public void display_data()
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
                MessageBox.Show("Display Error");

            }


        }

        private void Update_Click(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = ("Update MarksEntery_Data set StudentID='" + textBox1.Text.ToString() + "',ExamDate='" + dateTimePicker1.Value.ToString("yyyyMMdd") + "', ExamName='" + textBox2.Text + "',MaxMarks='" + textBox6.Text.ToString() + "', PassingMarks='" + textBox7.Text.ToString() + "', ObtainedMarks = '" + textBox8.Text.ToString() + "' , Grade='" + textBox10.Text + "', Percentage='" + textBox9.Text.ToString() + "', Status='" + textBox3.Text + "'  where StudentID='" + textBox1.Text.ToString() + "' ");

                cmd.ExecuteNonQuery();


                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";

                dateTimePicker1.Text = "";

                display_data();

                MessageBox.Show("Record Updated Successfully !!");
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error. data cannot update " + ex);
            }


            finally {
                con.Close();
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            display_data();

            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Value.ToString("yyyyMMdd");
        }

        private void Delete_Click(object sender, EventArgs e)
        {

            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;

                cmd.CommandText = "delete from MarksEntery_data where StudentID ='" + textBox1.Text + "'";
                cmd.ExecuteNonQuery();
                con.Close();


                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";
                display_data();

                MessageBox.Show("Record Deleted Successfully !!");
            }

            catch (Exception ex)
            {
                MessageBox.Show("Error. Data not Deleted " + ex);
            }

            finally
            {
                con.Close();
            }
        }

        private void Show_Click(object sender, EventArgs e)
        {

            SqlCommand cmd;
            String str;

            con.Open();
            str = "Select * from MarksEntery_data where StudentID= '" + textBox1.Text.ToString() + "' ";

            cmd = new SqlCommand(str, con);

            SqlDataReader reader = cmd.ExecuteReader();
           

            while (reader.Read())
            {
                dateTimePicker1.Text = reader["ExamDate"].ToString();
                textBox2.Text = reader["ExamName"].ToString();
                textBox6.Text = reader["MaxMarks"].ToString();
                textBox7.Text = reader["PassingMarks"].ToString();
                textBox8.Text = reader["ObtainedMarks"].ToString();
                textBox10.Text = reader["Grade"].ToString();
                textBox9.Text = reader["Percentage"].ToString();
                textBox3.Text = reader["Status"].ToString();

            }

            con.Close();
                
            
        }
    }
}
