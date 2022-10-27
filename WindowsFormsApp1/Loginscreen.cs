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
    public partial class Loginscreen : Form
    {
        public Loginscreen()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text=="" || textBox2.Text=="")
            {
                label3.Text = "Please fill all fields";
            }
            else
            {
                Logindao logindao=new Logindao();
                bool b = logindao.login(textBox1.Text,textBox2.Text);
                if (b)
                {
                    Dashboard dashboard = new Dashboard();
                    dashboard.Show();
                    this.Hide();
                }
                else
                {
                    label3.Text = "Wrong login info";
                }
            }
        }
    }
}
