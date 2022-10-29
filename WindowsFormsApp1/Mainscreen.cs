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
    public partial class Mainscreen : UserControl
    {
        public Mainscreen()
        {
            InitializeComponent();
            Maindao maindao= new Maindao();
            textBox1.Text=maindao.getmemcount();
            textBox2.Text=maindao.getavgincome();
            setmaintable();
            
        }
        public void refresh()
        {
            Maindao maindao = new Maindao();
            textBox1.Text = maindao.getmemcount();
            textBox2.Text = maindao.getavgincome();
            setmaintable();
        }
        public void setmaintable()
        {
            DataTable dt = new DataTable();
            Maindao maindao=new Maindao();
            dt =maindao.maintable();
            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
