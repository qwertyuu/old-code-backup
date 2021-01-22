using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatTheShit
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Auto> listeDeChar = new List<Auto>()
            {
                new Auto("efoijwe", 2008, 3, "3j4gh"),
                new Auto("ffjfjfj", 9999, 9, "ton cul"),
                new Auto("suce", 29229292, 2, "k3k"),
                new Auto("Toyota", 2004, 4, "Camry"),
                new Auto("Dodge", 2008, 4, "Caravan")
            };
            
            int anneeChoisie = int.Parse(Console.ReadLine());
            var reponseRequete = (from automobile in listeDeChar
                                  where automobile.Annee == anneeChoisie
                                  select automobile);
            foreach (var automobile in reponseRequete)
            {
                ImprimerChar(automobile);
            }
            Console.ReadKey(true);
        }

        public static void ImprimerChar(Auto _char)
        {
            Console.WriteLine("Mon char c'est un {0} et a été construit en {1}", _char.Modele, _char.Annee);
            
        }
        public static void ImprimerChar(string _lol)
        {
        }
    }
}
