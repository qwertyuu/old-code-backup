using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandlebrot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.WindowWidth = Console.BufferWidth = 270;
            Console.WindowHeight = Console.BufferHeight = 85;
            int width = Console.WindowWidth;
            int height = Console.WindowHeight;
            for (int Py = 0; Py < height; Py++)
            {
                for (int Px = 0; Px < width; Px++)
                {
                    double x0 = -2.5 + (3.5 * Px) / width;
                    double y0 = -1 + (2.0 * Py) / height;
                    double x = 0.0;
                    double y = 0.0;
                    int i;
                    double powX;
                    double powY;
                    double xtemp;
                    for (i = 0; (powX = x * x) + (powY = y * y) < 4.0 && i < 20000; i++)
                    {
                        xtemp = powX - powY + x0;
                        y = 2 * x * y + y0;
                        x = xtemp;
                    }
                    Console.SetCursorPosition(Px, Py);
                    Console.BackgroundColor = (ConsoleColor)(i % Enum.GetNames(typeof(ConsoleColor)).Length);
                    if (!(Py == height - 1 && Px == width - 1))
                    {
                        Console.Write(' ');
                    }
                }
            }
            Console.ReadKey(true);
        }
    }
}
