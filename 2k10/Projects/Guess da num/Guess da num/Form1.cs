using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Guess_da_num
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetLabelText();
        }
        double chances = 1;
        int highInterval = 100;
        int lowInterval = 0;
        int guessTimes = 0;
        string lastTryInt = null;
        Random numToGuess = new Random();
        int j = 0;
        int staticNumToGuess = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text.ToString(), out j))
            {
                if (j > 100 || j < 0)
                {
                    label2.Text = "Mon chiffre est seulement entre 0 et 100!";
                }
                else
                {
                    lastTryInt = textBox1.Text;
                    guessTimes++;
                    SetLabelText();
                    if (staticNumToGuess > j)
                    {
                        label2.Text = "Plus haut!";
                        if (lowInterval < j)
                        {
                            lowInterval = j;
                        }
                    }
                    else if (staticNumToGuess < j)
                    {
                        label2.Text = "Plus bas!";
                        if (highInterval > j)
                        {
                            highInterval = j;
                        }
                    }
                    else
                    {
                        label2.Text = "C'est ça! En " + guessTimes + @" fois!

avec " + chances.ToString()+ "% de chances de trouver la réponse!";
                        button2.Visible = true;
                        button1.Visible = false;
                        textBox1.Visible = false;
                        label3.Visible = false;
                    }
                }
            }
            chances = 100 / ((highInterval - lowInterval) - 1);
            label3.Text = Math.Round(chances).ToString() + "% de chances";
            textBox1.Text = null;
            textBox1.Focus();
        }
        private void Reset()
        {
            highInterval = 100;
            lowInterval = 0;
            guessTimes = 0;
            lastTryInt = null;
            chances = 1;
            staticNumToGuess = numToGuess.Next(100);
            label3.Visible = true;
            button2.Visible = false;
            button1.Visible = true;
            textBox1.Visible = true;
            SetLabelText();
            label2.Text = "Essayez de deviner le chiffre que j'ai en tête!";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            staticNumToGuess = numToGuess.Next(100);
        }
        private void SetLabelText()
        {
            lastTry.Text = "Dernier essai: " + lastTryInt;
            label1.Text = "Nombre d'essais: " + guessTimes.ToString();
        }
        private void textBox1_CheckKeys(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                button1_Click(sender, e);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
