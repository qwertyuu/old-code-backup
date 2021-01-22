using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raphael_Cote_Interfaces_Lab3_Pt2
{
    class Automobile : IComparable
    {
        public string Constructeur { get; private set; }
        public int Annee { get; private set; }

        public Automobile(string _cons, int _annee)
        {
            this.Constructeur = _cons;
            this.Annee = _annee;
        }

        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            Automobile auto = obj as Automobile;
            if (auto != null)
            {
                return this.Constructeur.CompareTo(auto.Constructeur);
            }
            else
            {
                throw new ArgumentException("L'objet passé en paramètre n'est pas une automobile");
            }
        }
    }
}
