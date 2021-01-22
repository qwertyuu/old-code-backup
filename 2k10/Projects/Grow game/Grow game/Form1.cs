using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Grow_game
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            elementTerre.Order = 1;
            elementFeu.Order = 2;
            elementAir.Order = 3;
            elementEau.Order = 4;

        }
        bool eauEnabled = false;
        bool airEnabled = false;
        bool terreEnabled = false;
        bool feuEnabled = false;
        bool roundCanStart = true;
        int round = 0;
        Element elementEau = new Element();
        Element elementFeu = new Element();
        Element elementAir = new Element();
        Element elementTerre = new Element();
        

        private void button4_Click(object sender, EventArgs e)
        {
            //eau
            eau.Enabled = false;
            richTextBox1.Text += "L'eau est arrivée!";
            if (roundCanStart == true)
            {
                roundCanStart = false;
                Round();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //air
            air.Enabled = false;
            richTextBox1.Text += "L'air est arrivée!";
            if (roundCanStart == true)
            {
                roundCanStart = false;
                Round();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //terre
            terre.Enabled = false;
            richTextBox1.Text += "La terre est arrivée!";
            if (roundCanStart == true)
            {
                roundCanStart = false;
                Round();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //feu
            feu.Enabled = false;
            richTextBox1.Text += "Le feu est arrivé!";
            if (roundCanStart == true)
            {
                roundCanStart = false;
                Round();
            }
        }
        int line = 1;
        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            line++;
            richTextBox1.Text += Environment.NewLine + line + ": ";
            richTextBox1.SelectionStart = richTextBox1.Text.Length;
            richTextBox1.ScrollToCaret();
        }
        void Round()
        {
            round++;
            richTextBox1.Text += "Round commencée {";
            if (round == elementAir.Order)
            {
                Console.WriteLine("LLLLLOL");
            }
            richTextBox1.Text += "} Round fini";
            roundCanStart = true;
        }
        void InitElements()
        {

        }

    }
}
