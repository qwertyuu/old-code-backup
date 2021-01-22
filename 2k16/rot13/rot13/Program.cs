using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rot13
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string uInput = Console.ReadLine().ToUpper();
                string output = "";
                foreach (var item in uInput)
                {
                    output += (char)((int)item % 26 + 65);
                }
                Console.WriteLine(output);
            }
        }
    }
}
