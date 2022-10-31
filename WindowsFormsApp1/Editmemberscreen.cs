using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
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
            textBox3.Text= company;
            textBox4.Text= reduction;
            monthCalendar1.SetDate(DateTime.Parse(startdate));
            monthCalendar2.SetDate(DateTime.Parse(enddate));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Maindao maindao = new Maindao();
            maindao.editmember(id, textBox1.Text, textBox2.Text, textBox5.Text, textBox3.Text, textBox4.Text, monthCalendar1.SelectionStart.ToShortDateString(), monthCalendar2.SelectionStart.ToShortDateString());
            MessageBox.Show("Member edited successfully");
        }
    }
}
