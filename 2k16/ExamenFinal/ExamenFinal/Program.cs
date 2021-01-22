using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenFinal
{
    class Program
    {
        static void Main(string[] args)
        {


            int[] simulations = new int[] { 100, 200, 300, 400, 500, 1000 };
            foreach (var nbVaisseaux in simulations)
            {
                Console.WriteLine("Simulation de {0} vaisseaux\n", nbVaisseaux);
                CentreTri[] centresTri = new CentreTri[10];
                for (int i = centresTri.Length - 1; i >= 0; i--)
                {
                    if (i == centresTri.Length - 1)
                    {
                        centresTri[i] = new CentreTri(i + 1);
                    }
                    else
                    {
                        centresTri[i] = new CentreTri(i + 1, centresTri[i + 1]);
                    }
                }
                for (int genere = 0; genere < nbVaisseaux; genere++)
                {
                    Vaisseau courrant = new Vaisseau();
                    centresTri[0].AjoutVaisseau(courrant);
                    for (int numCentre = 0; numCentre < centresTri.Length; numCentre++)
                    {
                        centresTri[numCentre].MiseAJour();
                    }
                }
                bool SePasseQuelquechose;
                do
                {
                    SePasseQuelquechose = false;
                    for (int numCentre = 0; numCentre < centresTri.Length; numCentre++)
                    {
                        SePasseQuelquechose |= centresTri[numCentre].MiseAJour();
                    }
                } while (SePasseQuelquechose);

                foreach (var centre in centresTri)
                {
                    Console.WriteLine(centre);
                    Console.WriteLine("Appuyer sur une touche pour afficher le prochain centre de tri");
                    Console.ReadKey(true);
                }
                Console.Clear();
            }
            Console.WriteLine("fini!");
            Console.ReadKey(true);
        }
    }
}
