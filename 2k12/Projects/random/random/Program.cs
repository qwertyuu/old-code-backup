using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;

namespace random
{
    class Program
    {
        static void Main(string[] args)
        {
            Random randInt = new Random();
            var color = ConsoleColor.White;
            int top;
            int left;
            int next = ((Console.WindowHeight * Console.WindowWidth) * 188 / 87);
            int oldheight = Console.WindowHeight;
            int oldwidth = Console.WindowWidth;
            int delaymax = randInt.Next(next);
            int delay = 0;
            bool iAmGay = false;
            do
            {

                if (color == ConsoleColor.Black)
                {
                    color++;
                }
                if (color == ConsoleColor.White)
                {
                    color = ConsoleColor.Black;
                }
                if (oldheight != Console.WindowHeight || oldwidth != Console.WindowWidth)
                {
                    Console.Clear();
                }
                oldwidth = Console.WindowWidth;
                oldheight = Console.WindowHeight;
                Console.ForegroundColor = color;
                top = randInt.Next(Console.WindowHeight);
                left = randInt.Next(Console.WindowWidth);
                if ((left * top) == ((Console.WindowHeight - 1) * (Console.WindowWidth - 1)))
                {
                    left = Console.WindowWidth - 3;
                }
                Console.SetCursorPosition(left, top);
                Console.Write(WriteThis(randInt));
                    delay++;
                if (delay >= delaymax)
                {
                    delaymax = randInt.Next(next);
                    delay = 0;
                    color++;
                }
                next = ((Console.WindowHeight * Console.WindowWidth) * 188 / 87);
                //System.Threading.Thread.Sleep(5);
            } while (iAmGay == false);

        }

        private static string WriteThis(Random randInt)
        {
            int ret = randInt.Next(1);
            switch (ret)
            {
                case 0:
                    return "0";
                case 1:
                    return " ";
                default:
                    return "2";
            }
        }
    }
}
