using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pipo
{
    class Program
    {
        static int i;
        static decimal pi;
        static void Main(string[] args)
        {
            bool fairePlus = true;
            decimal denominateur = 1;
            pi = 0;
            System.Threading.Thread sauce = new System.Threading.Thread(check);
            sauce.IsBackground = true;
            sauce.Start();
            for (i = 0; i < int.MaxValue; i++)
            {
                if (fairePlus)
                {
                    pi += 4 / denominateur;
                }
                else
                {
                    pi -= 4 / denominateur;
                }
                denominateur += 2;
                fairePlus = !fairePlus;
            }
            Console.WriteLine(pi);
            Console.ReadKey(true);
        }

        private static void check(object obj)
        {
            while (true)
            {
                Console.WriteLine(Math.Round((i / (double)int.MaxValue) * 100, 2).ToString().PadRight(6) + "%  " + pi);
                System.Threading.Thread.Sleep(500);
            }
        }
    }
}
