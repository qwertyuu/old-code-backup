using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Psychose
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            Console.CursorVisible = false;
            while (true)
            {
                Console.Write(new string('#', Console.WindowWidth * Console.WindowHeight - 1));
                Console.ForegroundColor = (ConsoleColor)rnd.Next(16);
                Console.SetCursorPosition(0, 0);
                System.Threading.Thread.Sleep(100);
                
            }
        }
    }
}
