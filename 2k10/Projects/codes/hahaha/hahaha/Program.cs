using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            char wtf = 'A';
            var lulz = ConsoleColor.DarkBlue;
            Console.ForegroundColor = lulz;
            DoAscend(wtf, lulz);
        }

        private static void DoDescend(char wtf, ConsoleColor lulz)
        {
            for (int i = Console.WindowWidth - 2; i > 0; i--)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write(wtf);
                }
                if (i < Console.WindowWidth)
                {
                    Console.WriteLine();
                }
            }
            wtf++;
            if (wtf == 'A' + 63)
            {
                wtf = 'A';
            }
            Console.ResetColor();
            lulz++;
            Console.ForegroundColor = lulz;
            if (lulz == ConsoleColor.Gray)
            {
                lulz = ConsoleColor.Black;
            }
            DoAscend(wtf, lulz); 
        }

        private static void DoAscend(char wtf, ConsoleColor lulz)
        {
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    Console.Write(wtf);
                }
                if (i < Console.WindowWidth - 1)
                {
                    Console.WriteLine();
                }

            }
            DoDescend(wtf, lulz);
        }
    }
}
