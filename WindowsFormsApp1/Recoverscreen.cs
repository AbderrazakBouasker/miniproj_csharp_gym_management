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
    public partial class Recoverscreen : Form
    {
        public Recoverscreen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Loginscreen loginscreen = new Loginscreen();
            loginscreen.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Logindao logindao = new Logindao();
            bool b = logindao.checkuserexist(textBox1.Text, textBox2.Text, textBox3.Text);
            if (textBox1.Text=="" || textBox2.Text=="" || textBox3.Text == "")
            {
                MessageBox.Show("Please fill all fields");
            }
            else if (b)
            {
                MessageBox.Show("Your password is : "+logindao.getpassword(textBox1.Text,textBox2.Text,textBox3.Text));
            }
            else
            {
                MessageBox.Show("Wrong info or user doesn't exist");
            }
            
        }
    }
}
