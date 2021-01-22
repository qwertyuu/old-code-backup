using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Appuyez sur une touche pour commencer");
            Console.ReadKey(true);
            Console.CursorVisible = false;
            allDemCells = new Cell[Console.WindowWidth][];
            alive = new List<Cell>();
            nextGenBuf = new StringBuilder();
            for (int x = 0; x < Console.WindowWidth; x++)
            {
                allDemCells[x] = new Cell[Console.WindowHeight - 1];
                for (int y = 0; y < Console.WindowHeight - 1; y++)
                {
                    Cell buf = new Cell();
                    buf.XPos = x;
                    buf.YPos = y;
                    buf.Alive = false;
                    buf.Voisins = 0;
                    allDemCells[x][y] = buf;
                }
            }
            GenerateRandomPop(allDemCells, alive);
            //DateTime now;
            //double toAverage = 0;
            //int divisor = 1;
            int count = 1;
            while (true)
            {
                //now = DateTime.Now;
                Console.Clear();
                PrintCurrentGen();
                Console.Write(count);
                NextGeneration();
                count++;
                //toAverage += (DateTime.Now - now).TotalMilliseconds;
                //Console.Write(toAverage / divisor);
                //var buf = 100 - (int)(DateTime.Now - now).TotalMilliseconds;
                //System.Threading.Thread.Sleep(buf < 0 ? 0 : buf);
                //System.Threading.Thread.Sleep(10);
                //divisor++;
            }
        }

        private static void PrintCurrentGen()
        {
            Console.Write(nextGenBuf);
            nextGenBuf = new StringBuilder();
        }

        private static void NextGeneration()
        {
            SetVoisins();
            foreach (var item in allDemCells)
            {
                foreach (var i in item)
                {
                    if (i.Alive)
                    {
                        if (i.Voisins >=4 || i.Voisins < 2)
                        {
                            i.Alive = false;
                            alive.Remove(i);
                        }
                    }
                    else
                    {
                        if (i.Voisins == 3)
                        {
                            i.Alive = true;
                            alive.Add(i);
                        }
                    }

                }
            }
            for (int y = 0; y < Console.WindowHeight - 1; y++)
            {
                for (int x = 0; x < Console.WindowWidth; x++)
                {
                    nextGenBuf.Append(allDemCells[x][y].Alive ? '#' : ' ');
                }
            }
        }

        private static void SetVoisins()
        {
            foreach (var item in allDemCells)
            {
                foreach (var i in item)
                {
                    i.Voisins = 0;
                }
            }
            foreach (var item in alive)
            {
                int minX = -1;
                int maxX = 1;
                int minY = -1;
                int maxY = 1;
                if (item.XPos == 0)
                {
                    minX = Console.WindowWidth;
                }
                else if (item.XPos == Console.WindowWidth - 1)
                {
                    maxX = - Console.WindowWidth;
                }
                if (item.YPos == 0)
                {
                    minY = Console.WindowHeight;
                }
                else if (item.YPos == Console.WindowHeight -2)
                {
                    maxY = - (Console.WindowHeight - 1);
                }
                for (int x = minX; x <= maxX; x++)
                {
                    for (int y = minY; y <= maxY; y++)
                    {
                        if (!(x == 0 && y == 0))
                        {
                            allDemCells[item.XPos + x][item.YPos + y].Voisins++;
                        }
                    }
                }
            }
        }

        static Cell[][] allDemCells;
        static List<Cell> alive;
        static StringBuilder nextGenBuf;
        public static void GenerateRandomPop(Cell[][] pop, List<Cell> _alive)
        {
            Random rand = new Random();
            foreach (var item in pop)
            {
                foreach (var i in item)
                {
                    if (rand.Next(2) == 1)
                    {
                        alive.Add(i);
                        i.Alive = true;
                    }
                }
            }
            allDemCells = pop;
            alive = _alive;
        }
    }

    class Cell
    {
        public int Voisins { get; set; }
        public bool Alive { get; set; }
        public int XPos { get; set; }
        public int YPos { get; set; }
    }
}