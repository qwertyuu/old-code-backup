using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab2_POO_.NET
{
    class Validateur
    {

        public static void Valider(string _prenom, string _nom, int _age)
        {
            if (_age < 0 || _age > 109)
            {
                throw new ArgumentOutOfRangeException("Age");
            }
        }


    }
}
