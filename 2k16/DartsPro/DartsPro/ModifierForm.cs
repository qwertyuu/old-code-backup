using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DartsPro
{
    public partial class ModifierForm : Form
    {
        public string joueur1;
        public string joueur2;

        public ModifierForm(string _p1, string _p2, int _pointage = 301)
        {
            InitializeComponent();
            textBox1.Text = joueur1 = _p1;
            textBox2.Text = joueur2 = _p2;
            numericUpDown1.Value = _pointage;
        }

        private void ModifierForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            joueur1 = textBox1.Text;
            joueur2 = textBox2.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

    }
}
