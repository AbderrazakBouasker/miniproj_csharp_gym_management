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
    public partial class loadingscreen : Form
    {
        public loadingscreen()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            panel1.Width += 3;
            decimal dec = panel1.Width * 100 / 436;
            decimal percent = Math.Ceiling(dec);
            label1.Text = percent.ToString()+"%";
            if (panel1.Width >= 436)
            {
                timer1.Stop();
                Loginscreen loginscreen = new Loginscreen();
                loginscreen.Show();
                this.Hide();
            }
        }
    }
}
