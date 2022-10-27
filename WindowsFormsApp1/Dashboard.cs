﻿using System;
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
            mainscreen1.BringToFront();
            Sidepanel.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainscreen1.BringToFront();
            Sidepanel.Hide();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        { 
            Sidepanel.Show();
            Sidepanel.Height=button3.Height;
            Sidepanel.Top = button3.Top;
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Sidepanel.Show();
            Sidepanel.Height = button4.Height;
            Sidepanel.Top = button4.Top;
            addmember1.BringToFront();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Loginscreen loginscreen=new Loginscreen();
            loginscreen.Show();
            this.Close();
        }
    }
}
