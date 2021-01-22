using System;
using System.Linq;
using System.Text;
namespace PYTHON
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] listeChiffres = new int[5000000];
            Random rnd = new Random();
            for (int i = 0; i < listeChiffres.Length; i++)
            {
                listeChiffres[i] = rnd.Next(5000);
            }
            var resultats = from chiffre in listeChiffres
                            where chiffre % 2 == 0
                            select chiffre;
            StringBuilder sB = new StringBuilder();
            foreach (var chiffre in resultats)
            {
                sB.Append(chiffre.ToString() + '\n');
            }
            Console.Write(sB.ToString());
            Console.ReadKey(true);
        }
    }
}