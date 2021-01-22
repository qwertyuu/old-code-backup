using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SortingOP
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] toSort = new int[130];
            Console.WindowWidth = 274;
            Random rand = new Random();
            for (int i = 0; i < toSort.Length; i++)
            {
                toSort[i] = rand.Next(10);
            }
            ShakeIt(toSort);
            Console.ReadLine();
        }

        private static void ShakeIt(int[] old)
        {
            int[] toSort = new int[old.Length];
            bool sorted = false;
            int max = toSort.Length - 1;
            int min = 0;
            int count = 0;
            for (int i = 0; i < old.Length; i++)
            {
                Console.Write(old[i] + " ");
            }
            Console.WriteLine();
            while (!sorted)
            {
                for (int i = 0; i < toSort.Length; i++)
                {
                    toSort[i] = old[i];
                }
                Console.WriteLine();
                sorted = true;
                for (int i = min; i < max; i++)
                {
                    if (old[i] > old[i + 1])
                    {
                        sorted = false;
                        int buf = old[i];
                        old[i] = old[i + 1];
                        old[i + 1] = buf;
                    }
                }
                max--;
                for (int i = max; i > min; i--)
                {
                    if (old[i] < old[i - 1])
                    {
                        sorted = false;
                        int buf = old[i];
                        old[i] = old[i - 1];
                        old[i - 1] = buf;
                    }
                }
                min++;
                for (int i = 0; i < old.Length; i++)
                {
                    if (toSort[i] != old[i])
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(old[i] + " ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.Write(old[i] + " ");
                    }
                }
                Console.WriteLine();
                count++;
            }
            Console.WriteLine();
            Console.Write("Fini " + count);
        }
    }
}
