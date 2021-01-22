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
    public partial class ColorOptionDialog : Form
    {
        public ColorOptionDialog()
        {
            InitializeComponent();
        }

        private void ColorOptionDialog_Load(object sender, EventArgs e)
        {
            button1.BackColor = Settings.FullColor;
            button2.BackColor = Settings.EmptyColor;
            button2.Font = Settings.ActualFont;
            button3.BackColor = Settings.MineColor;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog a = new ColorDialog();
            switch (a.ShowDialog())
            {
                case DialogResult.OK:
                    button1.BackColor = a.Color;
                    Settings.EmptyColor = a.Color;
                    break;
                default:
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ColorDialog a = new ColorDialog();
            switch (a.ShowDialog())
            {
                case DialogResult.OK:
                    button2.BackColor = a.Color;
                    Settings.FullColor = a.Color;
                    break;
                default:
                    break;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ColorDialog a = new ColorDialog();
            switch (a.ShowDialog())
            {
                case DialogResult.OK:
                    button3.BackColor = a.Color;
                    Settings.MineColor = a.Color;
                    break;
                default:
                    break;
            }
        }
    }
}
