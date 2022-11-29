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
    public partial class Addmember : UserControl
    {
        public Addmember()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime localDate = DateTime.Now;
            if (textBox1.Text=="" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Please fill all necessary fields");
            }
            else if (monthCalendar2.SelectionStart <= monthCalendar1.SelectionStart)
            {
                MessageBox.Show("Start date should be earlier than end date");
            }
            else
            {
                string tempbox4 = textBox4.Text;
                string tempbox5 = textBox5.Text;
                if (textBox4.Text=="Optional")
                {
                    tempbox4 = "";
                }
                if (textBox5.Text=="Optional")
                {
                    tempbox5 = "null";
                }
                Maindao maindao = new Maindao();
                maindao.addmember(textBox3.Text, textBox1.Text, textBox2.Text, tempbox4, tempbox5, monthCalendar1.SelectionRange.Start.ToShortDateString(), monthCalendar2.SelectionRange.Start.ToShortDateString());
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
            }
        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (textBox5.Text=="Optional")
            {
                textBox5.Text = "";
                textBox5.ForeColor = Color.Black;
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {
            if (textBox5.Text=="")
            {
                textBox5.Text = "Optional";
                textBox5.ForeColor=Color.Gray;
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text=="Optional")
            {
                textBox4.Text = "";
                textBox4.ForeColor = Color.Black;
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "Optional";
                textBox4.ForeColor = Color.Gray;
            }
        }
    }
}
