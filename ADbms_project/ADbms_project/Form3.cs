using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ADbms_project
{
    public partial class Form3 : Form
    {


        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\New folder\ADBMS project\CMS_PROJECT1.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        public Form3()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            mASTER_FORM mf = new mASTER_FORM();
            mf.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void INSERT(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into StudentFee_Data values ('" + textBox9.Text + "', '" + dateTimePicker1.Value.ToString("yyyyMMdd") + "', '" + textBox2.Text + "','" + comboBox7.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            textBox9.Text = "";
            textBox2.Text = "";
            dateTimePicker1.Text = "";
            comboBox7.Text = "";
            disp_data();
            MessageBox.Show("Record Inserted Successfully !!");
        }
        public void disp_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from StudentFee_Data";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
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

        private void DELETE(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from StudentFee_Data where StudentID ='" + textBox2.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            textBox9.Text = "";
            textBox2.Text = "";
            dateTimePicker1.Text = "";
            comboBox7.Text = "";
            disp_data();
            MessageBox.Show("Record Deleted Successfully !!");
        }

        private void UPDATE(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = ("update StudentFee_Data set StudentID='" + textBox2.Text + "', Fee='" + textBox9.Text + "', FeeName='" + comboBox7.Text + "', Date='" + dateTimePicker1.Value.ToString("yyyyMMdd") + "'  where StudentID='" + textBox2.Text + "' ");
            cmd.ExecuteNonQuery();
            con.Close();
            textBox9.Text = "";
            textBox2.Text = "";
            dateTimePicker1.Text = "";
            comboBox7.Text = "";
            disp_data();
            MessageBox.Show("Record Updated Successfully !!");

        }

        private void VIEW(object sender, EventArgs e)
        {
            disp_data();

        }

        private void SEARCH(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from StudentFee_data";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            textBox9.Text = "";
            textBox2.Text = "";
            dateTimePicker1.Text = "";
            comboBox7.Text = "";
        }

        private void EXIT(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            comboBox6.Items.Add("XI");
            comboBox6.Items.Add("XII");

            comboBox7.Items.Add("Admission Fees");
            comboBox7.Items.Add("Examination Fees");
            comboBox7.Items.Add("Monthly fees");




            //funtion 
            disp_data();

            display_data();



            if (comboBox7.Text == "Admission Fees")
            {
                textBox9.Text = "1200";

            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (comboBox7.Text == "Admission Fees")
            {

                textBox9.Text = "12000";

            }
            else
            {
                if (comboBox7.Text == "Examination Fees")
                {

                    textBox9.Text = "1200";

                }
                else
                {
                    if (comboBox7.Text == "Monthly fees")
                    {

                        textBox9.Text = "6000";

                    }
                     else
                        {
                            textBox9.Text = " ";

                        }


                    }
                }
            }
        }
    }

