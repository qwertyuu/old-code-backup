using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pj12
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong numberOfMultiplicator = 0;
            ulong biggest = 0;
            ulong iterator = 3;
            while (numberOfMultiplicator <= 500)
            {
                numberOfMultiplicator = 1;
                ulong accumulator = 0;
                for (ulong i = 1; i < iterator; i++)
                {
                    accumulator += i;
                }
                if (accumulator % 6 == 0 || accumulator % 8 == 0 || accumulator % 10 == 0)
                {
                    ulong half = accumulator / 2;
                    for (ulong i = 1; i <= half; i++)
                    {
                        if (accumulator % i == 0)
                        {
                            numberOfMultiplicator++;
                        }
                    }
                    if (numberOfMultiplicator > biggest)
                    {
                        biggest = numberOfMultiplicator;
                        Console.WriteLine("{1} multiplicateurs pour {0}", accumulator, numberOfMultiplicator);
                    }
                }
                iterator++;
            }
            Console.WriteLine(iterator);
            Console.ReadKey(true);
        }
    }
}
