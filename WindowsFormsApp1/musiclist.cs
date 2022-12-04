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
    public partial class musiclist : UserControl
    {
        public musiclist()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string html = "<html> <head>";
            html += " <meta content='IE=Edge' http-equiv='X-UA-Compatible'/> ";
            html += " <iframe id='video' src= 'https://www.youtube.com/embed/{0}' width='369' height='301' frameborder='0' allowfullscreen  /iframe> ";
            html += " </body>  </html> ";
            this.webBrowser1.DocumentText = string.Format(html, textBox2.Text.Split('=')[1]);
        }
    }   
}
