using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_vs_Iteration_test
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int[][] arrey = new int[10000][];
            int valueToGet = int.MaxValue / 2;
            for (int i = 0; i < arrey.Length; i++)
            {
                arrey[i] = new int[10000];
                for (int j = 0; j < arrey[i].Length; j++)
                {
                    arrey[i][j] = rand.Next();
                }
            }
            DateTime linq = DateTime.Now;
            for (int i = 0; i < 10000; i++)
            {
                var a = from b in arrey
                        from c in b
                        where c < valueToGet
                        orderby c
                        select c;
            }
            Console.WriteLine("LINQ a fait {0}ms", (DateTime.Now - linq).TotalMilliseconds);
            DateTime iteration = DateTime.Now;
            for (int i = 0; i < 10; i++)
            {
                List<int> toTest = new List<int>();
                for (int x = 0; x < arrey.Length; x++)
                {
                    for (int y = 0; y < arrey[x].Length; y++)
                    {
                        if (arrey[x][y] < valueToGet)
                        {
                            toTest.Add(arrey[x][y]);
                        }
                    }
                }
            }
            Console.Write("L'itération a fait {0}ms", (DateTime.Now - iteration).TotalMilliseconds);
            Console.ReadKey(true);
        }
    }
}
