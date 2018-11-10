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
    public partial class Form4 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=D:\New folder\ADBMS project\CMS_PROJECT1.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        public Form4()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            mASTER_FORM mf = new mASTER_FORM();
            mf.Show();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            comboBox3.Items.Add("Cash");
            comboBox3.Items.Add("Cheque");

            display_data();
            disp_data();
        }

        private void INSERT(object sender, EventArgs e)
        {
             con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into TeachersSalary_Data values ('" + textBox3.Text + "','" + textBox2.Text + "','" + textBox15.Text + "','" + dateTimePicker1.Value.ToString("yyyyMMdd") + "','" + comboBox3.Text + "','" + textBox13.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            textBox3.Text = "";
            textBox2.Text = "";
            dateTimePicker1.Text = "";
            textBox13.Text = "";
            textBox15.Text = "";
            comboBox3.Text = "";
            
            disp_data();
            

            MessageBox.Show("Record Inserted Successfully !!");
        }
        public void disp_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select * from TeachersSalary_data";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            
        }
        public void display_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Teachers_Data";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView2.DataSource = dt;
            con.Close();
            
        }

        private void DELETE(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from TeachersSalary_Data where TeachersID ='"+textBox3.Text+"'";
            cmd.ExecuteNonQuery();
            con.Close();
            textBox3.Text = "";
            textBox2.Text = "";
            dateTimePicker1.Text = "";
            textBox13.Text = "";
            textBox15.Text = "";
            comboBox3.Text = "";

            disp_data();
            MessageBox.Show("Record Deleted Successfully !!");
        }

        private void UPDATE(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = ("update TeachersSalary_data set TeachersID='" + textBox3.Text + "',Salary='" + textBox2.Text + "',PaymentDate='" + dateTimePicker1.Value.ToString("yyyyMMdd") +  "', TotalPayment='" + textBox15.Text + "',Grade='" +textBox13.Text+ "', PaymentMode='" + comboBox3.Text + "'  where TeachersID='" + textBox3.Text + "' ");
            cmd.ExecuteNonQuery();
            con.Close();
            textBox3.Text = "";
            textBox2.Text = "";
            dateTimePicker1.Text = "";
            textBox13.Text = "";
            textBox15.Text = "";
            comboBox3.Text = "";

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
            cmd.CommandText = "select * from TeachersSalary_Data where TeachersID='"+textBox3.Text+"'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void EXIT(object sender, EventArgs e)
        {
            this.Hide();
            mASTER_FORM mf = new mASTER_FORM();
            mf.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (textBox13.Text == "21")
            {

                textBox2.Text = "35000";

            }
            else 
            {  if ( textBox13.Text == "20"  )
              {

                  textBox2.Text = "37000";
            
            
            
            }else 
            {  if ( textBox13.Text == "19"  )
              {


                  textBox2.Text = "45000";
            
              }else
            {
                if (textBox13.Text == "22")
                {

                    textBox2.Text = "30000";


                }
                else {

                    textBox2.Text = " ";
                
                
                
                }
            
            
            
            }
            
            
            
            }
            
            
            
            }
        }

       
    }
}
