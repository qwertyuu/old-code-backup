using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace String_Format
{
    class Program
    {
        static void Main(string[] args)
        {
            string uInput = Console.ReadLine();
            Console.WriteLine("Salut {0}{1}!", uInput, "Swag");
            Console.ReadKey(true);
        }
    }
}
