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
    public partial class FrmChangements : Form
    {
        BindingSource bJoueurs;
        public FrmChangements()
        {
            InitializeComponent();
            bJoueurs = new BindingSource();
            bJoueurs.DataSource = ListeJoueurs.Get();
            lstJoueurs.DataSource = bJoueurs;
            lstJoueurs.DisplayMember = "Nom";
        }
        

        private void btnSauvQuit_Click(object sender, EventArgs e)
        {
            XDocument xDoc = new XDocument(
                        new XDeclaration("1.0", "UTF-8", null),
                        new XElement("Joueurs",
                            from item in (List<Joueur>)bJoueurs.DataSource
                            select new XElement("Joueur",
                                new XElement("Nom", item.Nom))));
            xDoc.Save("joueurs.xml");
            this.Close();
        }

        private void btnAjout_Click(object sender, EventArgs e)
        {
            ListeJoueurs.Ajout(new Joueur(txtAjout.Text));
            bJoueurs.ResetBindings(false);
            txtAjout.Text = "";
        }

        private void btnSupp_Click(object sender, EventArgs e)
        {
            ListeJoueurs.Supprimer(lstJoueurs.SelectedIndex);
            bJoueurs.ResetBindings(false);
        }
    }
}