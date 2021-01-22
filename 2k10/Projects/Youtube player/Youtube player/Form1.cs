using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Skybound.Gecko;

namespace Youtube_player
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Skybound.Gecko.Xpcom.Initialize(@"C:\Users\Paul\Desktop\xulrunner");
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            geckoWebBrowser1.Navigate(@"C:\Users\Paul\Desktop\new.html");
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
