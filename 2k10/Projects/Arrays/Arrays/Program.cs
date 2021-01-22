using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] numbers = new int[5];
            //numbers[0] = 2;
            //numbers[1] = 5;
            //numbers[2] = 7;
            //numbers[3] = 10;
            //numbers[4] = 15;

            int[] numbers = { 4, 6, 10, 45, 22, 30 };
            
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i].ToString());
            }


            string[] names = { "Bibo", "Pineault", "Mouette", "Mitaine" };
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }

            string myText = "C'est le temps de tuer les gens par leur age et tout";
            char[] charArray = myText.ToCharArray();
            Array.Reverse(charArray);

            foreach (char myChar in charArray)
            {
                Console.Write(myChar);
            }

            //Console.WriteLine(numbers[0] + numbers[4]);
            Console.ReadLine();
        }
    }
}
