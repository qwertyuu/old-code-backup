using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJEulerrrr
{
    class Program
    {
        static void Main(string[] args)
        {

            int first = 1;
            int second = 1;
            int temp = 0;
            int index = 1;
            while (true)
            {
                temp = second;
                second = first;
                first = second + temp;
                index++;
                if (first.ToString().Length >= 1000)
                {
                    Console.WriteLine(first);
                    break;
                }
                Console.WriteLine(index + ":" + first);
            }
            Console.ReadKey(true);
        }

        static int Fib(int index)
        {
            if (index == 1 || index == 2)
            {
                return 1;
            }
            return Fib(index - 1) + Fib(index - 2);
        }
    }
}
