using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.dao;

namespace WindowsFormsApp1
{
    public partial class Creatuserscreen : Form
    {
        public Creatuserscreen()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="" ||textBox2.Text=="" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "")
            {
                MessageBox.Show("Please fill all fields");
            }
            else if(textBox2.Text!=textBox5.Text)
            {
                MessageBox.Show("Password and Confirm password must be the same");
            }
            else
            {
                Logindao logindao = new Logindao();
                logindao.creatuser(textBox1.Text,textBox2.Text,textBox3.Text,textBox4.Text);
                MessageBox.Show("User added successfully");
                button2.Enabled = false;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Loginscreen loginscreen =new Loginscreen();
            loginscreen.Show();
            this.Hide();
        }
    }
}
