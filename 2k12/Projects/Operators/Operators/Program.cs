using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operators
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine(IntToString(int.Parse(Console.ReadLine()), new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }));
            }
        }
        public static string IntToString(int value, char[] baseChars)
        {
            Stack<char> result = new Stack<char>();
            int targetBase = baseChars.Length;
            do
            {
                result.Push(baseChars[value % targetBase]);
                value /= targetBase;
            }
            while (value > 0);
            StringBuilder actualResult = new StringBuilder();
            foreach (var item in result)
            {
                actualResult.Append(item);
            }
            return actualResult.ToString();
        }
    }
}
