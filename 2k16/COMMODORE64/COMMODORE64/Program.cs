using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace COMMODORE64
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] loles = { '/', '\\' };
            Console.WindowHeight = Console.LargestWindowHeight;
            Random rnd = new Random();
            for (int i = 0; i < (Console.WindowHeight - 1) * Console.WindowWidth - 1; i++)
            {
                Console.Write(loles[rnd.Next(2)]);
            }
            Console.ReadKey(true);
        }
    }
}