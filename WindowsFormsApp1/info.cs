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
    public partial class info : Form
    {
        public info()
        {
            InitializeComponent();
        }

        private void info_Load(object sender, EventArgs e)
        {
            Log.Logger("Открыта справка");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            main1 main = new main1();
            main.Show();
        }
    }
}
