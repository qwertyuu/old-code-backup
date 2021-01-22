using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MATRIX_MUCH
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = 274;
            Console.WindowHeight = 88;
            Random rand = new Random();
            Matrix HUE = new Matrix(rand);
            int width = Console.WindowWidth;
            int height = Console.WindowHeight;
            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            string AFFICHELEDONTLEL = "";
            while (true)
            {
                AFFICHELEDONTLEL = HUE.Get();
                Console.SetCursorPosition(0, 0);
                Console.Write(AFFICHELEDONTLEL);
                //System.Threading.Thread.Sleep(50);
                if (height != Console.WindowHeight || width != Console.WindowWidth)
                {
                    Console.Clear();
                    HUE = new Matrix(rand);
                    height = Console.WindowHeight;
                    width = Console.WindowWidth;
                }
                
                HUE.Update();
            }
        }
    }
}