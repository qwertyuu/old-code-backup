using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Random rnd = new Random();
            Console.WindowWidth = 271;
            Console.WindowHeight = 85;
            boule[] boules = new boule[50];
            int width = Console.WindowWidth;
            int height = Console.WindowHeight;
            for (int i = 0; i < boules.Length; i++)
            {
                boules[i] = new boule(rnd, width, height);
            }
            StringBuilder sB = new StringBuilder();
            Console.ReadKey(true);
            while (true)
            {
                width = Console.WindowWidth;
                height = Console.WindowHeight;
                sB.Clear();
                sB.Append(new string(' ', width * height - 1));
                for (int i = 0; i < boules.Length; i++)
                {
                    sB[boules[i].Update(width, height)] = '#';
                }
                Console.SetCursorPosition(0, 0);
                Console.Write(sB.ToString());
                System.Threading.Thread.Sleep(20);
            }
        }
    }
}
