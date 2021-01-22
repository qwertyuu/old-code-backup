using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Heritage_Pt1
{
    class Program
    {
        static void Main(string[] args)
        {
            CompteBancaire Jean = new CompteBancaire("Jean Tremblay");
            CompteBancaireRemunere Raphael = new CompteBancaireRemunere("Raphael Cote", 1000d);

            Console.WriteLine(Jean.Relever());
            Console.WriteLine(Raphael.Relever());
            Console.WriteLine();

            Jean.Crediter(200d);
            Raphael.Crediter(200d);

            Console.WriteLine(Jean.Relever());
            Console.WriteLine(Raphael.Relever());

            Console.ReadKey(true);
        }
    }
}
