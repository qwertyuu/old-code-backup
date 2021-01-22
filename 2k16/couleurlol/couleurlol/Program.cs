using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace couleurlol
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            while (true)
            {
                Console.Write(rnd.Next(2));
                System.Threading.Thread.Sleep(10);
            }
        }
    }
}
