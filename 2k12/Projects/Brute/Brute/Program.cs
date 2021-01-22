using System;
using System.Threading;

namespace Brute
{
    class Infos
    {
        public static char[] val { get; set; }
        public static uint tries { get; set; }
        public static int max { get; set; }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Infos.val = new char[5000];
            for (int i = 0; i < Infos.val.Length; i++)
            {
                Infos.val[i] = (char)64;
            }
            Thread otherWorker = new Thread(new ThreadStart(Work));
            otherWorker.IsBackground = true;
            otherWorker.Priority = ThreadPriority.Highest;
            otherWorker.Start();
            Thread.CurrentThread.Priority = ThreadPriority.Lowest;
            uint latestRez;
            while (true)
            {
                latestRez = Infos.tries;
                Thread.Sleep(2000);
                Console.Clear();
                Console.WriteLine((Infos.tries - latestRez) / 2);
                for (int i = 0; i <= Infos.max; i++)
                {
                    Console.Write(Infos.val[i]);
                }
            }
        }
        private static void Work()
        {
            Infos.max = 1;
            bool addOne = false;
            while (true)
            {
                while (Infos.val[0] < (char)122)
                {
                    Infos.val[0]++;
                    Infos.tries++;
                }
                Infos.val[0] = (char)65;
                Infos.val[1]++;
                Infos.tries++;
                for (int i = 1; i <= Infos.max; i++)
                {
                    if (Infos.val[i] == (char)122)
                    {
                        Infos.val[i] = (char)65;
                        Infos.val[i + 1]++;
                        Infos.tries++;
                        if (i == Infos.max)
                        {
                            addOne = true;
                        }
                    }
                }
                if (addOne == true)
                {
                    Infos.max++;
                    addOne = false;
                }
            }
        }
    }
}