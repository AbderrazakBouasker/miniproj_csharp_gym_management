using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using WindowsFormsApp1.dao;

namespace WindowsFormsApp1
{
    public partial class Editmemberscreen : Form
    {
        string id="";
        public Editmemberscreen()
        {
            InitializeComponent();
        }
        public Editmemberscreen(string id, string idnumber, string name, string lastname, string company, string reduction, string startdate, string enddate)
        {
            InitializeComponent();
            this.id = id;
            textBox1.Text= idnumber;
            textBox2.Text= name;
            textBox5.Text= lastname;
            monthCalendar1.SetDate(DateTime.Parse(startdate));
            monthCalendar2.SetDate(DateTime.Parse(enddate));
            if (company=="")
            {
                textBox3.Text = "Optional";
                textBox3.ForeColor = Color.Gray;
            }
            else
            {
                textBox3.ForeColor = Color.Black;
                textBox3.Text = company;
            }
            if (reduction=="")
            {
                textBox4.Text = "Optional";
                textBox4.ForeColor = Color.Gray;
            }
            else
            {
                textBox4.ForeColor = Color.Black;
                textBox4.Text = reduction;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Maindao maindao = new Maindao();
            if (textBox1.Text==""|| textBox2.Text==""|| textBox5.Text=="")
            {
                MessageBox.Show("Please fill all necessary fields");
            }
            else if (!Regex.IsMatch(textBox1.Text, @"^\d+$") || !Regex.IsMatch(textBox4.Text, @"^\d+$"))
            {
                MessageBox.Show("Id and reduction fields input should be numeric");
            }
            else if (monthCalendar2.SelectionStart <= monthCalendar1.SelectionStart)
            {
                MessageBox.Show("Start date should be earlier than end date");
            }
            else
            {
                string tempbox3 = textBox3.Text;
                string tempbox4 = textBox4.Text;
                if (textBox3.Text == "Optional")
                {
                    tempbox3 = "";
                }
                if (textBox4.Text == "Optional")
                {
                    tempbox4 = "null";
                }
                maindao.editmember(id, textBox1.Text, textBox2.Text, textBox5.Text, tempbox3, tempbox4, monthCalendar1.SelectionStart.ToShortDateString(), monthCalendar2.SelectionStart.ToShortDateString());
                MessageBox.Show("Member edited successfully");
            }
            
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Optional")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.Black;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "Optional";
                textBox3.ForeColor = Color.Gray;
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

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "Optional")
            {
                textBox4.Text = "";
                textBox4.ForeColor = Color.Black;
            }
        }
    }
}
