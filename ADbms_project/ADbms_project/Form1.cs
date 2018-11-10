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
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\New folder\ADBMS project\CMS_PROJECT1.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //combobox values
            comboBox1.Items.Add("XI");
            comboBox1.Items.Add("XII");

            comboBox2.Items.Add("Female");
            comboBox2.Items.Add("Male");

            comboBox3.Items.Add("Muslim");
            comboBox3.Items.Add("Non-Muslim");

            comboBox4.Items.Add("Pakistani");
            comboBox4.Items.Add("Foreign");

            //funtion 
            disp_data();

        }

        private void Insert(object sender, EventArgs e)
        {
            try
            {

            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Student_Data values ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox1.Text + "','" + dateTimePicker1.Value.ToString("yyyyMMdd") + "','" + textBox6.Text + "','" + comboBox2.Text + "','" + comboBox3.Text + "','" + comboBox4.Text + "','" + textBox7.Text.ToString() + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox1.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            dateTimePicker1.Text = "";
            disp_data();
            MessageBox.Show("Record Inserted Successfully !!");
            }
            catch (Exception)
            {
                MessageBox.Show("Data Insertion Error ");
            }
            finally
            {
                con.Close();
            }
        }

        public void disp_data()
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "select * from Student_data";
                cmd.ExecuteNonQuery();
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                dataGridView1.DataSource = dt;
                con.Close();
            }

            catch (Exception)
            {
                MessageBox.Show("Connection Error");
            
            }

            
        }

        private void Delete(object sender, EventArgs e)
        {
            try
            {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from Student_Data where StudentID ='" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox1.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            dateTimePicker1.Text = "";
            disp_data();
            MessageBox.Show("Record Deleted Successfully !!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
            finally
            {
                con.Close();
            }
        }

        private void Upadate(object sender, EventArgs e)
        {
            try
            {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = ("update Student_Data set StudentID='" + textBox1.Text + "',StudentName ='" + textBox2.Text + "', FatherName='" + textBox3.Text + "',FatherOccupation='" + textBox4.Text + "', SClass='" + comboBox1.Text + "', DOB='" + dateTimePicker1.Value.ToString("yyyyMMdd") + "', Address='" + textBox6.Text + "', Gender='" + comboBox2.Text + "', Religion='" + comboBox3.Text + "', Nationality='" + comboBox4.Text + "', FatherContactNo='" + textBox7.Text.ToString() + "'  where StudentID='" + textBox1.Text + "' ");
            cmd.ExecuteNonQuery();
            con.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox1.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            dateTimePicker1.Text = "";
            disp_data();
            MessageBox.Show("Record Updated Successfully !!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
            finally
            {
                con.Close();
            }
        }

        private void View(object sender, EventArgs e)
        {
            disp_data();
        }

        private void Search(object sender, EventArgs e)
        {
            try
            {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Student_data where StudentID='" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            textBox1.Text = "";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error " + ex);
            }
            finally
            {
                con.Close();
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker1.Value.ToString("yyyyMMdd");
          
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            mASTER_FORM mf = new mASTER_FORM();
            mf.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
