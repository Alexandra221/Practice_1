﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Phone_book
{
    public partial class info : Form
    {
        public info()
        {
            InitializeComponent();
        }

       

        private void main_Click(object sender, EventArgs e) //переход на главную форму
        {
            this.Hide();
            main1 main = new main1();
            main.Show();
        }

       
    }
}
