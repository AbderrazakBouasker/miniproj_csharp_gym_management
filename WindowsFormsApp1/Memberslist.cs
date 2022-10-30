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
                    ver= true;
                    break;
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
                        ids += dataGridView1.Rows[i].Cells[8].Value;
                        ids += ",";
                    }
                }
                Console.WriteLine(ids);
            }
            else
            {
                MessageBox.Show("Please select a member to delete");
            }
            /*string ids = "";
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                //bool boxchecked = (bool)dataGridView1.Rows[i].Cells[7].Value;
                
                if (dataGridView1.Rows[i].Cells[7].Value!=null)
                {
                    
                }
                else
                {
                    boxchecked = false;
                }
                if (boxchecked)
                {
                    DialogResult result = MessageBox.Show("Are you sure you want to delete ?", "Confirmation", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {

                    }
                }
            }*/
        }

        private void dataGridView1_Enter(object sender, EventArgs e)
        {
            
        }
    }
}
