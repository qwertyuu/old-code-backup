using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raphael_Cote_Interfaces_Lab3_Pt2
{
    class Program
    {
        static void Main(string[] args)
        {
            Automobile[] autos = new Automobile[]{
                new Automobile("Toyota", 1999),
                new Automobile("Ford", 2005),
                new Automobile("Audi", 2015),
                new Automobile("Mercedes", 2016),
                new Automobile("Chevrolet", 1989)
            };
            Console.WriteLine("Contenu non trié :");
            foreach (var auto in autos)
            {
                Console.WriteLine("        " + auto.Constructeur);
            }

            Array.Sort(autos);

            Console.WriteLine("Contenu trié :");
            foreach (var auto in autos)
            {
                Console.WriteLine("        " + auto.Constructeur);
            }
            Console.ReadKey(true);
        }
    }
}
