using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Darts
{
    public class ScoreBoard
    {
        public Joueur Joueur1 { get; private set; }
        public Joueur Joueur2 { get; private set; }
        public Score ScoreJoueur1 { get; private set; }
        public Score ScoreJoueur2 { get; private set; }
        public int Initial { get; set; }

        public ScoreBoard(int _initial, Joueur p1, Joueur p2)
        {
            this.Initial = _initial;
            Joueur1 = p1;
            Joueur2 = p2;
            ScoreJoueur1 = new Score(_initial);
            ScoreJoueur2 = new Score(_initial);
        }

        public override string ToString()
        {
            return Joueur1.Nom + ' ' + Joueur2.Nom;
        }
    }
}
