using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace offset
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput = Console.ReadLine();
            char[] demStuff = userInput.ToCharArray();
            char[] offset = new char[demStuff.Length];
            char[] lol = new char[demStuff.Length];
            int index = 0;
            foreach (char toOffset in demStuff)
            {
                lol[index] = (char)(toOffset + 3);
                Console.Write(lol[index]);
                index++;
            }
            Console.WriteLine();
            Console.ReadKey(true);
            foreach (char toOffset in lol)
            {
                Console.Write((char)(toOffset - 3));
                index++;
            }
            Console.ReadKey(true);
        }
    }
}
