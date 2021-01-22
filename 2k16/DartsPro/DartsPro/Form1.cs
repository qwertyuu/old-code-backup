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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            ModifierForm mod = new ModifierForm(dataGridView.Columns[0].HeaderText, dataGridView.Columns[1].HeaderText);
            if (mod.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                dataGridView.Columns[0].HeaderText = mod.joueur1;
                dataGridView.Columns[1].HeaderText = mod.joueur2;
            }

        }


    }
}