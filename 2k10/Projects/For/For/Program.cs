using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace For
{
    class Program
    {
        static void Main(string[] args)
        {

            for (int i = 0; i < 10; i++)
            {
                //Console.WriteLine(i.ToString());

                if (i == 7)
                {
                    Console.WriteLine("Sept criss!");
                    break;
                }
            }
            for (int myDick = 0; myDick < 10; myDick++)
            {
                Console.WriteLine(myDick);
            }
            Console.ReadLine();
        }
    }
}
