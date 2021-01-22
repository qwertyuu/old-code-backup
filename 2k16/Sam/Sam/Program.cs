using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sam
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] billets = new int[] { 100, 50, 20, 10, 5, 2, 1 };
            int[] nombre = new int[billets.Length];
            int input = 0;
            while (!int.TryParse(Console.ReadLine(), out input)) ;
            for (int i = 0; i < billets.Length; i++)
            {
                while (input >= billets[i])
                {
                    nombre[i]++;
                    input -= billets[i];
                }
                Console.WriteLine("{0} billets de {1}", nombre[i], billets[i]);
            }
            Console.ReadKey(true);
        }
    }
}
