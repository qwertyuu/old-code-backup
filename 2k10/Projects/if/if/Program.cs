using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace @if
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("S'il te plais Raph, écris d'koi qu'on en finisse sacrement");
            //string userValue;
            //userValue = Console.ReadLine();
            //Console.WriteLine("T'as écrit: " + userValue);
            //Console.ReadLine();

            Console.WriteLine("T'aime tu mieu la porte 1, 2 ou 34?");
            string userValue = Console.ReadLine();
            //string wat = "penisvagin";
            //if (texteDeMarde == "1")
            //    wat = "Tu t'es faite fourrer solide!";                
            //else if (texteDeMarde == "2")
            //    wat = "Tu trouves une pomme sti!";
            //else if (texteDeMarde == "34")
            //    wat = "Bon bein c'est le paradis maudite marde";
            //else
            //    wat = "Voyons sti arrete de niaiser la pi ecris une vrai criss de reponse lol";
            //Console.WriteLine(wat);
            //Console.ReadLine();

            string message = (userValue == "1") ? "bateau" : "set de couteau de cuisine";
            Console.WriteLine("T'as gagné un {0}! Pi t'as écrit {1}.", message, userValue);
            Console.ReadLine();
        }
    }
}
