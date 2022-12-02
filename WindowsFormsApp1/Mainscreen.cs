using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using WindowsFormsApp1.dao;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WindowsFormsApp1
{
    public partial class Mainscreen : UserControl
    {
        public Mainscreen()
        {
            InitializeComponent();
            setmaintable();
            refresh();
            
        }
        public void refresh()
        {
            Maindao maindao = new Maindao();
            textBox1.Text = maindao.getmemcount();
            if (textBox3.Text=="")
            {
                textBox2.Text = maindao.getavgincome(60);
            }
            else
            {
                textBox2.Text = maindao.getavgincome(int.Parse(textBox3.Text));
            }
            
            setmaintable();
        }
        public void setmaintable()
        {
            DataTable dt = new DataTable();
            Maindao maindao=new Maindao();
            try
            {
                if (textBox4.Text == "")
                {
                    dt = maindao.maintable(3);
                }
                else if (!Regex.IsMatch(textBox4.Text, @"^\d+$"))
                {
                    MessageBox.Show("Days field input should be integer");
                    textBox4.Text = "";
                }
                else
                {
                    dt = maindao.maintable(int.Parse(textBox4.Text));
                }
                dataGridView1.DataSource = dt;
            }
            catch (Exception)
            {
                MessageBox.Show("Input should be a number");
                textBox4.Text = "";
                throw;
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            Maindao maindao = new Maindao();
            try
            {
                if (textBox3.Text == "")
                {
                    textBox2.Text = maindao.getavgincome(60);
                }
                else if (!Regex.IsMatch(textBox3.Text, @"^\d+$"))
                {
                    MessageBox.Show("Cost field input should be integer");
                    textBox3.Text = "";
                }
                else
                {
                    textBox2.Text = maindao.getavgincome(int.Parse(textBox3.Text));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Input should be a number");
                textBox3.Text = "";
                throw;
            }
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            setmaintable();
        }
    }
}
