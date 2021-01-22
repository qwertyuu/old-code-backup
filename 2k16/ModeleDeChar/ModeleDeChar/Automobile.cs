using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ModeleDeChar
{
    class Automobile
    {
        public int Kilometrage { get; set; }
        public int Poids { get; set; }
        public string Couleur { get; set; }
        public string Modele { get; set; }

        public static string JeSuisQuoi()
        {
            return "Un auto";
        }

        public string publicRouille()
        {
            return this.Rouille();
        }


        private string Rouille()
        {
            return "Ma couleur " + this.Couleur + " rouille";
        }

    }
}
