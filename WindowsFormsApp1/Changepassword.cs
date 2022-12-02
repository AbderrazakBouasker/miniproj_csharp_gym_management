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
    public partial class Changepassword : Form
    {
        string password;
        string name;
        public Changepassword()
        {
            InitializeComponent();
        }
        public Changepassword(string name,string password)
        {
            InitializeComponent();
            this.password= password;
            this.name= name;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Equals("") || textBox5.Text.Equals(""))
            {
                MessageBox.Show("Please fill all fields");
            }
            else if (textBox2.Text.Equals(textBox5.Text))
            {
                MessageBox.Show("Old and new password should be different");
            }
            else if(!textBox2.Text.Equals(password))
            {
                MessageBox.Show("Old password is wrong");
            }
            else
            {
                Logindao logindao = new Logindao();
                logindao.login(name,password);
                logindao.changepassword(textBox5.Text);
                button2.Enabled = false;
                MessageBox.Show("Password changed successfully");
            }
        }
    }
}
