using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paie_net
{
    class Program
    {
        static void Main()
        {
            Random rand = new Random();
            while (true)
            {
                double toPrint = rand.NextDouble() * 10;
                Console.WriteLine("Entrez le taux horaire: {0}", (int)toPrint);
                double tauxHoraire = toPrint;
                toPrint = rand.NextDouble() * 10;
                double nbHeures = toPrint;
                Console.WriteLine("Entrez le nombre d'heures: {0}", (int)toPrint);
                double salaireNet = 0.85 * tauxHoraire * nbHeures - 20.79;
                Console.WriteLine((int)salaireNet);
            }
        }
    }
}
