using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ADbms_project
{
    public partial class mASTER_FORM : Form
    {
        public mASTER_FORM()
        {
            InitializeComponent();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 F1 = new Form1();
            F1.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 F2 = new Form2();
            F2.Show();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form3 F3 = new Form3();
            F3.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form4 F4 = new Form4();
            F4.Show();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

            this.Hide();
            Form5 F5 = new Form5();
            F5.Show();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

       
    }
}
