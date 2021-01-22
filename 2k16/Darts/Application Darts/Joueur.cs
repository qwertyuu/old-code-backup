using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Darts
{
    public class Joueur
    {
        public string Nom { get; set; }
        public List<int> listScore {get;set;}

        public Joueur(string _nom)
        {
            listScore = new List<int>();
            Nom = _nom;
        }
    }
}
