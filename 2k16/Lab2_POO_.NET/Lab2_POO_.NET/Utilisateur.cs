using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2_POO_.NET
{
    class Utilisateur
    {
        public string Prenom { get; private set; }
        public string Nom { get; private set; }
        public int Age { get; private set; }
        private string representation;

        public Utilisateur(string _prenom, string _nom, int _age)
        {
            Prenom = _prenom;
            Nom = _nom;
            Age = _age;
            representation = string.Format("{0} {1}, {2} ans", _prenom, _nom, _age);
            try
            {
                Validateur.Valider(_prenom, _nom, _age);
            }
            catch (ArgumentOutOfRangeException e)
            {
                representation = string.Format("{0} {1}: {2} hors limite. {3} n'est pas entre 0 et 109", _prenom, _nom, e.ParamName, _age);
            }

        }

        public override string ToString()
        {
            return representation;
        }
    }
}
