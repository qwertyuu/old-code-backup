using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJ14
{
    class Program
    {
        static void Main(string[] args)
        {
            uint largest = 0;
            for (uint i = 0; i <= 1000000; i++)
            {
                uint buffer = i;
                uint iterations = 1;
                while (buffer > 1)
                {
                    if (buffer % 2 == 0)
                    {
                        buffer /= 2;
                    }
                    else
                    {
                        buffer = 3 * buffer + 1;
                    }
                    iterations++;
                }
                if (iterations > largest)
                {
                    Console.WriteLine("{0} itérations pour {1}", iterations, i);
                    largest = iterations;
                }
            }
            Console.WriteLine("Terminé");
            Console.ReadKey(true);
        }
    }
}
