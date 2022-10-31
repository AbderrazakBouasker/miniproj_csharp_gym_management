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
    public partial class Memberslist : UserControl
    {
        public Memberslist()
        {
            InitializeComponent();
            refresh();
        }
        public void refresh()
        {
            Maindao maindao = new Maindao();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = maindao.fillmembertab();
        }
        public bool checkboxes()
        {
            bool ver=false;
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                if (dataGridView1.Rows[i].Cells[7].Value!=null)
                {
                    if ((bool)dataGridView1.Rows[i].Cells[7].Value == true)
                    {
                        ver = true;
                        break;
                    }
                }
                
            }
            return ver;
        }

        public void button2_Click(object sender, EventArgs e)
        {
            string ids = "";
            if (checkboxes()==true)
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (dataGridView1.Rows[i].Cells[7].Value != null)
                    {
                        if ((bool)dataGridView1.Rows[i].Cells[7].Value == true)
                        {
                            ids += dataGridView1.Rows[i].Cells[8].Value;
                            ids += ",";
                        }
                    }
                }

                ids=ids.Remove(ids.Length-1,1);
                DialogResult dialogResult= MessageBox.Show("Are you sure you want to delete ?", "Confirmation window", MessageBoxButtons.YesNo);
                if (dialogResult==DialogResult.Yes)
                {
                    Maindao maindao = new Maindao();
                    maindao.deletemember(ids);
                    MessageBox.Show("member(s) deleted successfully");
                    refresh();
                }
            }
            else
            {
                MessageBox.Show("Please select a member to delete");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkboxes())
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    if (dataGridView1.Rows[i].Cells[7].Value!=null)
                    {
                        if ((bool)dataGridView1.Rows[i].Cells[7].Value==true)
                        {
                            string idnumber = ""+ dataGridView1.Rows[i].Cells[0].Value;
                            string name = ""+ dataGridView1.Rows[i].Cells[1].Value;
                            string lastname = "" +dataGridView1.Rows[i].Cells[2].Value;
                            string company = "" +dataGridView1.Rows[i].Cells[3].Value;
                            string reduction = "" + dataGridView1.Rows[i].Cells[4].Value;
                            string startdate = "" + dataGridView1.Rows[i].Cells[5].Value;
                            string enddate = "" + dataGridView1.Rows[i].Cells[6].Value;
                            string id = "" + dataGridView1.Rows[i].Cells[8].Value;
                            Editmemberscreen editmemberscreen = new Editmemberscreen(id,idnumber,name,lastname,company,reduction,startdate,enddate);
                            editmemberscreen.Show();
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a member to edit");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text=="")
            {
                refresh();
            }
            else
            {
                Maindao maindao = new Maindao();
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = maindao.fillmembertabbyname(textBox1.Text);

            }
        }
    }
}
