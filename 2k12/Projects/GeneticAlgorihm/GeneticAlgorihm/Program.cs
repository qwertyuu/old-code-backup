using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgorihm
{
    class Program
    {
        static void Main(string[] args)
        {
            string uInput = Console.ReadLine();
            int popLen = 30;
            int numOfCandidats = 3;
            int rounds = 300;
            List<Entry> fitnessCount = new List<Entry>();
            Random rand = new Random();
            for (int i = 0; i < popLen; i++)
            {
                Entry entryBuffer = new Entry();
                entryBuffer.Value = InitString(uInput.Length, rand);
                //Console.WriteLine(population[i]);
                entryBuffer.Fitness = GetElement(uInput, entryBuffer.Value);
                fitnessCount.Add(entryBuffer);
            }
            for (int i = 0; i < rounds - 1; i++)
            {
                fitnessCount = fitnessCount.OrderBy(x => x.Fitness).ToList();
                fitnessCount.RemoveRange(numOfCandidats, fitnessCount.Count - numOfCandidats);

            }
        }

        private static int GetElement(string uInput, string p)
        {
            int fitnessToReturn = 0;
            for (int i = 0; i < uInput.Length; i++)
            {
                fitnessToReturn += Math.Abs((int)uInput[i] - (int)p[i]);
            }
            return fitnessToReturn;
        }

        private static string InitString(int p, Random rand)
        {
            StringBuilder toReturn = new StringBuilder();
            for (int i = 0; i < p; i++)
            {
                toReturn.Append((char)rand.Next(31, 122));
            }
            return toReturn.ToString();
        }
    }
    class Entry
    {
        public int Fitness { get; set; }
        public string Value { get; set; }
    }
}