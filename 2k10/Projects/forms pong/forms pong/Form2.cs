using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace forms_pong
{
    public partial class Form2 : Form
    {

        public Form2()
        {
            InitializeComponent();
        }
        public bool end = false;

        private void Form2_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            end = true;
        }

        private void Form2_Shown(object sender, EventArgs e)
        {
            //label1.Text = "You have survived " + (DateTime.Now - timer.start).Minutes + " minutes.";
            DateTime gamestopped = DateTime.Now;
            label1.Text = "You survived: " + (gamestopped - time.GlobalValue).Minutes + " minute and " + (gamestopped - time.GlobalValue).Seconds + " seconds" + "\n" + "The ball bounced " + time.bounceCount + " times!";
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }


    }
}
