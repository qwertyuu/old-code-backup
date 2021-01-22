using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Methods
{
    class Program
    {
        static void Main(string[] args)
        {
            string myValue = superSecretFormula();
            Console.WriteLine(myValue);
            Console.ReadLine();
        }


        private static string superSecretFormula()
        {
            return "Hello World";
        }

        //private static string reversedStuff()
        //{
        //    string leTexte = superSecretFormula();
        //    char[] charArray = leTexte.ToCharArray();
        //    Array.Reverse(charArray);
        //    foreach (char myChar in charArray)
        //    {
        //        return String.
        //    }
        //}
    }
}
