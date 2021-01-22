using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Oyster.Math;

namespace Réponses
{
    class Program
    {
        static void Main(string[] args)
        {
            bool dicks = false;
            do
            {
            string dicka = "haha";
            bool yep = false;
            do
            {
                Console.Write("Entrez une question: ");
                dicka = Console.ReadLine();
                if (dicka == "" || dicka == " ")
                {
                    yep = false;
                    Console.WriteLine("?");
                }
                else
                    yep = true;
            } while (!yep);

            int randomNum = RandomNumber(dicka);
            if (randomNum == 0)
                Console.WriteLine("oui!");
            else if (randomNum == 1)
                Console.WriteLine("Nope");
            else if (randomNum == 2)
                Console.WriteLine("J'sais pas :(");

            } while (!dicks);
        }

        private static int RandomNumber(string dicka)
        {
            string[] seeda = new string[dicka.Length];
            int baba = 0;
            foreach (char c in dicka)
            {
                seeda[baba] = GetTheValue(c).ToString();
                baba++;
            }
            string passString = ConvertStringArrayToString(seeda);
            Random random = new Random(DoParse(passString));
            return random.Next(3);
        }

        private static int DoParse(string passString)
        {
            int seed = 2;
            bool works = false;
            do
            {
                if (int.TryParse(passString, out seed))
                {
                    works = true;
                }
                else
                {
                    string passString1 = passString.Substring(0, passString.Length / 2);
                    string passString2 = passString.Substring(passString.Length / 2);
                    IntX part1 = IntX.Parse(passString1);
                    IntX part2 = IntX.Parse(passString2);
                    IntX reponse = part1 + part2;
                    passString = reponse.ToString();
                }
                Console.WriteLine(passString);
            } while (!works);
            return seed;
        }
        static string ConvertStringArrayToString(string[] array)
        {
            StringBuilder builder = new StringBuilder();
            foreach (string value in array)
            {
                builder.Append(value);
            }
            return builder.ToString();
        }
        private static int GetTheValue(Char c)
        {
            if (c >= '0' && c <= '9')
            {
                return (int)c - (int)'0' + 40;
            }
            else if (c >= 'A' && c <= 'Z')
            {
                return (int)c - (int)'A' + 10;
            }
            else if (c >= 'a' && c <= 'z')
            {
                return (int)c - (int)'a' + 10;
            }
            else
            {
                return 0;
            }
        }   
    }
}
