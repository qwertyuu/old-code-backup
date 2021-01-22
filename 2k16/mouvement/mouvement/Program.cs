using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mouvement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.Write("#");
            bool clear = false;
            int XPos = 0;
            int YPos = 0;
            bool kill = true;
            while (kill)
            {
                var key = Console.ReadKey(true);

                switch (key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        XPos--;
                        break;
                    case ConsoleKey.RightArrow:
                        XPos++;
                        break;
                    case ConsoleKey.DownArrow:
                        YPos++;
                        break;
                    case ConsoleKey.UpArrow:
                        YPos--;
                        break;
                    case ConsoleKey.Spacebar:
                        clear = !clear;
                        break;
                    case ConsoleKey.Escape:
                        kill = false;
                        break;
                }
                if (clear)
                {
                    Console.Clear();
                }
                Console.SetCursorPosition(XPos, YPos);
                Console.Write('#');
            }
        }
    }
}
