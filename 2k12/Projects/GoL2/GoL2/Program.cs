using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GoL2
{
    class Program
    {
        static void Main(string[] args)
        {
            Thread worker = new Thread(new ParameterizedThreadStart(workMethod));
            worker.IsBackground = true;
            Console.Title = "Multi-Threaded Game of Life!";
            Console.Write("Press any button to start generating!\nRemember not to resize the window after starting the generator!");
            System.Timers.Timer FPSCounter = new System.Timers.Timer();
            FPSCounter.Interval = 1000;
            FPSCounter.AutoReset = true;
            FPSCounter.Elapsed += FPSCounter_Elapsed;
            callPrint = new System.Timers.Timer();
            callPrint.Interval = latency;
            callPrint.AutoReset = false;
            callPrint.Elapsed += callPrint_Elapsed;
            Random rand = new Random();
            Console.ReadKey(true);
            consWinHeightCount = Console.WindowHeight - 1;
            consWinHeightCount1 = Console.WindowHeight - 2;
            consWinWidthCount = Console.WindowWidth - 1;
            for (int i = 0; i < plan.Length; i++)
            {
                plan[i] = new Cell[consWinHeightCount];
                for (int y = 0; y < plan[i].Length; y++)
                {
                    plan[i][y] = new Cell();
                    plan[i][y].alive = rand.Next(2) == 0 ? false : true;
                    plan[i][y].X = i;
                    plan[i][y].ID = y * plan.Length + i;
                    plan[i][y].Y = y;
                }
            }
            worker.Start();
            callPrint.Start();
            FPSCounter.Start();
            while (buildCount < 1500)
            {
                if (mainList.Count > 0)
                {
                    if (mainList[0] != null)
                    {
                        List<Cell> buffer = mainList[0];
                        mainList.RemoveAt(0);
                        char[] cellArray = new string(' ', Console.WindowWidth * consWinHeightCount).ToCharArray();
                        foreach (var item in buffer)
                        {
                            cellArray[item.ID] = '#';
                        }
                        mainString.Add(new string(cellArray));
                        buildCount++;
                    }
                }
            }
            Console.ReadKey(true);
        }
        static void FPSCounter_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            secondsElapsed++;
            FPS = printCount /  secondsElapsed;
            double buf = workerCount / secondsElapsed;
            if (buf > perSec)
            {
                perSec = buf;
            }
        }
        private static double latency = 70;
        private static bool printing = false;
        private static double FPS;
        private static uint secondsElapsed;
        public static List<string> mainString = new List<string>();
        public static System.Timers.Timer callPrint;
        public static int workerCount = 0;
        public static int buildCount = 0;
        public static int consWinHeightCount;
        public static int consWinHeightCount1;
        public static int consWinWidthCount;
        public static int printCount = 1;
        static void callPrint_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (mainString.Count > 0 && !printing)
            {
                printing = true;
                string buffer = mainString[0];
                mainString.RemoveAt(0);
                Console.Clear();
                Console.Write(buffer);
                Console.Write("{0}/{1}/{2} lat:{3} FPS:{4} HighBuild:{5}", printCount, buildCount, workerCount, latency, FPS, perSec);
                printCount++;
                printing = false;
            }
            callPrint.Start();
        }
        public static List<List<Cell>> mainList = new List<List<Cell>>();
        public static Cell[][] plan = new Cell[Console.WindowWidth][];
        public static double perSec;
        public static List<int> ySpace = new List<int>(3);
        public static List<int> xSpace = new List<int>(3);
        private static void workMethod(object obj)
        {
            while (workerCount < 1500)
            {
                var a = from o in plan
                        from p in o
                        where p.alive
                        select p;
                foreach (var item in a)
                {
                    if (item.X > 0)
                    {
                        xSpace.Add(-1);
                        xSpace.Add(0);
                        xSpace.Add(item.X < consWinWidthCount ? 1 : -consWinWidthCount);
                    }
                    else
                    {
                        xSpace.Add(consWinWidthCount);
                        xSpace.Add(0);
                        xSpace.Add(1);
                    }
                    if (item.Y > 0)
                    {
                        ySpace.Add(-1);
                        ySpace.Add(0);
                        ySpace.Add(item.Y < consWinHeightCount1 ? 1 : -consWinHeightCount1);
                    }
                    else
                    {
                        ySpace.Add(consWinHeightCount1);
                        ySpace.Add(0);
                        ySpace.Add(1);
                    }
                    foreach (var x in xSpace)
                    {
                        foreach (var y in ySpace)
                        {
                            if (!(y == 0 && x == 0))
                            {
                                plan[item.X + x][item.Y + y].neighbors++;
                            }
                        }
                    }
                    xSpace.Clear();
                    ySpace.Clear();
                }
                var neighCells = from pop in plan
                                 from cell in pop
                                 where cell.neighbors > 0 || cell.alive
                                 select cell;
                List<Cell> finalCells = new List<Cell>();
                foreach (var item in neighCells)
                {
                    if (plan[item.X][item.Y].alive)
                    {
                        if (plan[item.X][item.Y].neighbors > 3 || plan[item.X][item.Y].neighbors < 2)
                        {
                            plan[item.X][item.Y].alive = false;
                        }
                        else
                        {
                            finalCells.Add(plan[item.X][item.Y]);
                        }
                    }
                    else
                    {
                        if (plan[item.X][item.Y].neighbors == 3)
                        {
                            plan[item.X][item.Y].alive = true;
                            finalCells.Add(plan[item.X][item.Y]);
                        }
                    }
                    item.neighbors = 0;
                }
                mainList.Add(finalCells);
                workerCount++;
            }
        }
    }
    class Cell
    {
        public int neighbors { get; set; }
        public int ID { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public bool alive { get; set; }
    }
}
