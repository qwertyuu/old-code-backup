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
using System.IO;

namespace Application_Darts
{
    public partial class FrmDepart : Form
    {
        BindingSource bJoueurs1,bJoueurs2;

        public FrmDepart()
        {
            InitializeComponent();
            bJoueurs1 = new BindingSource();
            bJoueurs2 = new BindingSource();
            bJoueurs1.DataSource = ListeJoueurs.Get();
            bJoueurs2.DataSource = ListeJoueurs.Get();
            boxJ1.DataSource = bJoueurs1;
            boxJ2.DataSource = bJoueurs2;
            boxJ1.DisplayMember = "Nom";
            boxJ2.DisplayMember = "Nom";
            Export lel = new Export();
        }

        private void infosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmInfos info = new FrmInfos();
            info.ShowDialog();
        }

        private void ajouterSupprimerJoueurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmChangements change = new FrmChangements();
            change.ShowDialog();
            resetB();
        }

        private void FrmDepart_Load(object sender, EventArgs e)
        {
            if(File.Exists("joueurs.xml"))
            {
                XElement xelement = XElement.Load("joueurs.xml");
                IEnumerable<XElement> joueurs = xelement.Elements();


                foreach (var joueurSelect in joueurs)
                {
                    Joueur joueur = new Joueur(joueurSelect.Element("Nom").Value);
                    ListeJoueurs.Ajout(joueur);
                }
            }
            resetB();  
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int ScoreInitial = -1;

            if (boxJ1.SelectedIndex == boxJ2.SelectedIndex)
            {
                MessageBox.Show("Impossible de jouer contre soi même");
            }
            else if ((txtScoreIni.Text == "0") || (txtScoreIni.Text == ""))
            {
                MessageBox.Show("Score nul");
            }
            else if (!int.TryParse(txtScoreIni.Text,out ScoreInitial))
            {
                MessageBox.Show("Le score n'est pas un chiffre");
            }
            else
            {
                ScoreBoard SCB = new ScoreBoard(ScoreInitial,
                    (Joueur)bJoueurs1[boxJ1.SelectedIndex],
                    (Joueur)bJoueurs2[boxJ2.SelectedIndex]);
                this.Visible = false;
                FrmJeu jeu = new FrmJeu(SCB);
                jeu.ShowDialog();
                this.Visible = true;
                resetB();
            }
        }
        private void resetB()
        {
            bJoueurs1.ResetBindings(false);
            bJoueurs2.ResetBindings(false);
        }
    }
}
