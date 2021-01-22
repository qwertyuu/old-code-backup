using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PreciDart
{
    class BDHandler
    {
        private bdPreciDartEntities1 entitees;
        private List<tblJoueur> joueurs;

        public BDHandler()
        {
            entitees = new bdPreciDartEntities1();
            joueurs = entitees.tblJoueurs.ToList();
        }

        public void Update()
        {
            entitees.SaveChanges();
        }

        public tblJoueur CreateJoueur(string _NomJoueur)
        {
            return new tblJoueur() { NomJoueur = _NomJoueur };
        }

        public tblJoueur CreateJoueur(string _NomJoueur, tblEquipe _equipe)
        {
            return new tblJoueur() { NomJoueur = _NomJoueur, NoEquipe = _equipe.IdEquipe, tblEquipe = _equipe };
        }

        public tblScore CreateScore(tblMatch match, tblJoueur joueur, short _point, byte _index)
        {
            return new tblScore() { Tour = _index, tblJoueur = joueur, Score = _point, tblMatch = match, IdMatch = match.IdMatch, IdJoueur = joueur.NoJoueur };
        }

        public tblEquipe CreateEquipe(string _nom)
        {
            return new tblEquipe() { NomEquipe = _nom };
        }

        public tblMatch CreateMatch(tblJoueur _j1, tblJoueur _j2)
        {
            return new tblMatch() { NoJoueur1 = _j1.NoJoueur, NoJoueur2 = _j2.NoJoueur, tblJoueur1 = _j1, tblJoueur2 = _j2 };
        }

        public void AddMatch(tblMatch _m)
        {
            entitees.tblMatches.Add(_m);
            Update();
        }

        public void AddScores(List<tblScore> scores)
        {
            foreach (var item in scores)
            {
                entitees.tblScores.Add(item);
            }
            Update();
        }

        public void AddEquipe(tblEquipe _equipe)
        {
            entitees.tblEquipes.Add(_equipe);
            Update();
        }

        public void AddJoueur(tblJoueur _joueur)
        {
            entitees.tblJoueurs.Add(_joueur);
            Update();
        }

    }
}
