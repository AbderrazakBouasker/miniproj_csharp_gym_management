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
            this.webBrowser1.DocumentText = string.Format(html, textBox2.Text.Split('=')[1]);
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
    }   
}
