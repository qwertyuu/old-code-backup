using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random___Better_code
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
            Console.CursorVisible = false;
            int oldheight = Console.WindowHeight;
            int oldwidth = Console.WindowWidth;
            int delaymax = randInt.Next(next);
            int delay = 0;
            while(true)
            {
                if (color == ConsoleColor.Black)
                {
                    color++;
                }
                if (color == ConsoleColor.White)
                {
                    color = ConsoleColor.Blue;
                }
                if (oldheight != Console.WindowHeight || oldwidth != Console.WindowWidth)
                {
                    Console.Clear();
                    next = ((Console.WindowHeight * Console.WindowWidth) * 188 / 87);
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
                Console.Write('0');
                delay++;
                if (delay >= delaymax)
                {
                    delaymax = randInt.Next(next);
                    delay = 0;
                    color++;
                }
            }

        }
    }
}