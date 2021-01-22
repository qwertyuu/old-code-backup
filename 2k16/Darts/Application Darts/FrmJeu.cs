using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Application_Darts
{
    public partial class FrmJeu : Form
    {
        ScoreBoard sB;
        public FrmJeu(ScoreBoard _sb)
        {
            InitializeComponent();
            sB = _sb;
            lblactuel1.Text = lblactuel2.Text = sB.Initial.ToString();
        }
        FrmDepart dep = new FrmDepart();

        private void réinitialiserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult res;
            res = MessageBox.Show("Êtes-vous sûr de vouloir réinitialiser les scores?", "Attention", MessageBoxButtons.OKCancel);
            if (res == DialogResult.OK)
            {
                lblactuel1.Text = lblactuel2.Text = sB.Initial.ToString();
            }

        }

        private void menuPrincipalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            dep.Visible = true;
        }

        private void FrmJeu_Load(object sender, EventArgs e)
        {
            lblJ1.Text = sB.Joueur1.Nom;
            lblJ2.Text = sB.Joueur2.Nom;
        }



        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //Ajoute le score
                //switch a l'autre box
            }
            if (e.KeyCode == Keys.B)
            {
                //retour a l'autre
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //Ajoute le score
            }
        }


    }
}
