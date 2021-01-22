using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Demineur
{
    public partial class NewGame : Form
    {
        public NewGame()
        {
            InitializeComponent();
            foreach (var item in this.Controls)
            {
                if (item is RadioButton)
                {
                    ((RadioButton)item).CheckedChanged += NewGame_CheckedChanged;
                }
            }
            Settings.amountOfMines = 10;
            Settings.height = 9;
            Settings.width = 9;
            Settings.FullColor = Color.OrangeRed;
            Settings.ActualFont = new System.Drawing.Font("Courier New", (float)15.75, FontStyle.Bold, GraphicsUnit.Point, 0);
            Settings.EmptyColor = Color.Orange;
            Settings.MineColor = Color.Blue;
        }

        void NewGame_CheckedChanged(object sender, EventArgs e)
        {
            switch (((RadioButton)sender).Name)
            {
                case "radioButton1":
                    Settings.amountOfMines = 10;
                    Settings.height = 9;
                    Settings.width = 9;
                    break;
                case "radioButton2":
                    Settings.amountOfMines = 40;
                    Settings.height = 16;
                    Settings.width = 16;
                    break;
                case "radioButton3":
                    Settings.amountOfMines = 99;
                    Settings.height = 16;
                    Settings.width = 30;
                    break;
                default:
                    break;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 game = new Form1();
            switch (game.ShowDialog())
            {
                case DialogResult.Cancel:
                    this.Close();
                    break;
                case DialogResult.Retry:
                    this.Show();
                    break;
                default:
                    break;
            }
        }

        private void menuItem3_Click(object sender, EventArgs e)
        {
            var lol = new ColorDialog();
            if (lol.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Settings.EmptyColor = lol.Color;
            }
        }

        private void menuItem4_Click(object sender, EventArgs e)
        {
            var cDialog = new ColorDialog();
            if (cDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Settings.FullColor = cDialog.Color;
            }
        }

        private void menuItem1_Click(object sender, EventArgs e)
        {
            ColorOptionDialog cD = new ColorOptionDialog();
            cD.ShowDialog();
        }
    }
}
