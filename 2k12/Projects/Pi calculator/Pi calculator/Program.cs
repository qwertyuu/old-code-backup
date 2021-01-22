using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pi_calculator
{
    class Program
    {
        public static decimal pi = 0;
        static void Main(string[] args)
        {
            bool add = true;
            ulong namz = 1;
            UInt64 length = UInt64.Parse(Console.ReadLine());
            pLength = length;
            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(Monitor));
            t.IsBackground = true;
            t.Start();
            for (; i <= length; i++)
            {
                if (add == true)
                {
                    pi += (decimal)1 / namz;
                }
                else
                {
                    pi -= (decimal)1 / namz;
                }
                namz += 2;
                add = !add;
            }
            pi *= 4;
            Console.Write(pi);
            t.Abort();
            Console.ReadKey(true);
        }
        public static ulong i = 1;
        public static UInt64 pLength = 0;
        static void Monitor()
        {
            double percent = 0;
            while (true)
            {
                DateTime begin = DateTime.Now;
                percent = Math.Round(((double)i / pLength) * 100);
                Console.WriteLine(percent + " " + pi * 4);
                System.Threading.Thread.Sleep(1000);
            }
        }
        static double RemainingTime(DateTime _begin, double p)
        {
            double calc;
            TimeSpan tS = DateTime.Now - _begin;
            //calc = (double)100 / p;
            calc = tS.TotalSeconds;
            return calc;
        }
    }
}
