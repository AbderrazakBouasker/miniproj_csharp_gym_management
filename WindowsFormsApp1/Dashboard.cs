using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                Dbconnect.con.Open();
                string query = "select username from logininfo where id=1";

            }
            catch (Exception)
            {
                Dbconnect.con.Close();
                throw;
            }
            Dbconnect.con.Close();
            
            Console.WriteLine("test");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        { 
            Sidepanel.Height=button3.Height;
            Sidepanel.Top = button3.Top;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Sidepanel.Height = button4.Height;
            Sidepanel.Top = button4.Top;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
