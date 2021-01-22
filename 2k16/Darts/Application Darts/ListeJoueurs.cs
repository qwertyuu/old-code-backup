using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Darts
{
    static class ListeJoueurs
    {
        static List<Joueur> _joueurs;
        static ListeJoueurs()
        {
            if (_joueurs == null)
            {
                _joueurs = new List<Joueur>();
            }
        }

        public static void Ajout(Joueur _j)
        {
            _joueurs.Add(_j);
        }

        public static void Supprimer(int index)
        {
            if (index != -1)
            {
                _joueurs.RemoveAt(index);
            }
        }

        public static List<Joueur> Get()
        {
            return _joueurs;
        }

    }
}
