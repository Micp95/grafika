﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Grafika2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // Application.Run(new Form1());
            Form1 nw = new Form1();
            nw.ShowDialog();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Forml3 nw = new Forml3();
            nw.ShowDialog();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 nw = new Form4();
            nw.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form5 nw = new Form5();
            nw.ShowDialog();
        }
    }
}
