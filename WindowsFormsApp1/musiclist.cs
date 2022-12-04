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
using WindowsFormsApp1.dao;

namespace WindowsFormsApp1
{
    public partial class musiclist : UserControl
    {
        string id;
        string title;
        string link;
        public musiclist()
        {
            InitializeComponent();
            refresh();
        }
        public void refresh()
        {
            Maindao maindao=new Maindao();
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = maindao.fillmusictab();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string html = "<html> <head>";
            html += " <meta content='IE=Edge' http-equiv='X-UA-Compatible'/> ";
            html += " <iframe id='video' src= 'https://www.youtube.com/embed/{0}' width='369' height='301' frameborder='0' allowfullscreen  /iframe> ";
            html += " </body>  </html> ";
            this.webBrowser1.DocumentText = string.Format(html, link.Split('=')[1]);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") || textBox2.Text.Equals(""))
            {
                MessageBox.Show("Please fill the two fields");
            }
            else if (!Regex.IsMatch(textBox2.Text, @"[(http(s)?):\/\/(www\.)?a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#?&//=]*)"))
            {
                MessageBox.Show("Please enter a valid link in the form of https://www.");
            }
            else
            {
                Maindao maindao = new Maindao();
                maindao.addmusic(textBox1.Text, textBox2.Text);
                MessageBox.Show("Added successfully");
                textBox1.Text = "";
                textBox2.Text = "";
                refresh();
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowindex = dataGridView1.CurrentCell.RowIndex;
            this.id=textBox3.Text= dataGridView1.Rows[rowindex].Cells[0].Value.ToString();
            this.title=textBox4.Text = dataGridView1.Rows[rowindex].Cells[1].Value.ToString();
            this.link=textBox5.Text = dataGridView1.Rows[rowindex].Cells[2].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text.Equals(""))
            {
                MessageBox.Show("Select an entry first");
            }
            else
            {
                Maindao maindao = new Maindao();
                maindao.deletemusic(textBox3.Text);
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                MessageBox.Show("Deleted successfully");
                refresh();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox4.Text.Equals("") || textBox5.Text.Equals(""))
            {
                MessageBox.Show("Fill the Title and link fields");
            }
            else if (!Regex.IsMatch(textBox5.Text, @"[(http(s)?):\/\/(www\.)?a-zA-Z0-9@:%._\+~#=]{2,256}\.[a-z]{2,6}\b([-a-zA-Z0-9@:%_\+.~#?&//=]*)"))
            {
                MessageBox.Show("Please enter a valid link in the form of https://www.");
            }
            else
            {
                Maindao maindao = new Maindao();
                maindao.editmusic(textBox3.Text, textBox4.Text, textBox5.Text);
                MessageBox.Show("Edited successfully");
                refresh();
            }
        }
    }   
}
