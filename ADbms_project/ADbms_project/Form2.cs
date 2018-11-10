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
    public partial class Form2 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\New folder\ADBMS project\CMS_PROJECT1.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            //combobox values
            comboBox1.Items.Add("Femail");
            comboBox1.Items.Add("Male");

            comboBox2.Items.Add("Pre_Engneering");
            comboBox2.Items.Add("Medical");

            comboBox3.Items.Add("16");
            comboBox3.Items.Add("17");

           

            //funtion 
            disp_data();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            mASTER_FORM mf = new mASTER_FORM();
            mf.Show();
        }

        private void Insert(object sender, EventArgs e)
        {
             con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Teachers_Data values ('"+textBox1.Text+"', '"+textBox2.Text+"', '"+textBox3.Text+"', '"+textBox4.Text+"', '"+comboBox1.Text+"', '"+dateTimePicker1.Value.ToString("yyyyMMdd")+"', '"+comboBox2.Text+"', '"+ textBox7.Text+"', '"+textBox6.Text+"', '"+comboBox3.Text +"', '"+dateTimePicker2.Value.ToString("yyyyMMdd")+"', '"+dateTimePicker2.Value.ToString("yyyyMMdd")+"')";
            cmd.ExecuteNonQuery();
            con.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            dateTimePicker2.Text = "";
            dateTimePicker3.Text = "";
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
        public void disp_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Teachers_Data";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }
        

        private void Delete(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from Teachers_Data where TeachersID ='" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            dateTimePicker2.Text = "";
            dateTimePicker3.Text = "";
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

        private void Update(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = ("update Teachers_Data set TeachersID='" + textBox1.Text + "',TeacherName ='" + textBox2.Text + "', TAddress='" + textBox3.Text + "',TContactNo='" + textBox4.Text + "', TGender='" + comboBox1.Text + "', TDOB='" + dateTimePicker1.Value.ToString("yyyyMMdd") + "', TDepartment='" + comboBox2.Text + "', Qualification='" + textBox7.Text + "', YearOfExperience='" + textBox6.Text + "', Grade='" + comboBox1.Text + "',DOfAppointment='" + dateTimePicker2.Value.ToString("yyyyMMdd") + "',DOfRetirement='" +dateTimePicker1.Value.ToString("yyyyMMdd")+ "'  where TeachersID='" + textBox1.Text + "' ");
            cmd.ExecuteNonQuery();
            con.Close();
            con.Close();
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            dateTimePicker2.Text = "";
            dateTimePicker3.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox1.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            comboBox3.Text = "";
            dateTimePicker1.Text = "";
            disp_data();
            disp_data();
            MessageBox.Show("Record Updated Successfully !!");
        }

        private void View(object sender, EventArgs e)
        {
            disp_data();

        }

        private void Search(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Teachers_Data where TeachersID='" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            textBox1.Text = "";
        }

        private void Exit(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker2.Value.ToString("yyyyMMdd");

        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker3.Value.ToString("yyyyMMdd");
        }
    }
}
