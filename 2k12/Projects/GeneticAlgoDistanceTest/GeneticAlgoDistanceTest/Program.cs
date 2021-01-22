using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeneticAlgoDistanceTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadKey(true);
            //initial pop
            List<Individu> population = new List<Individu>();
            for (int i = 0; i < 10000; i++)
            {
                Individu buf = new Individu();
                buf.chromosome = GetRandomChromosome();
                buf.distance = GetDistance(buf);
                population.Add(buf);
            }
            double somme = 0;
            int count = 0;
            while (true)
            {
                if (count % 1000 == 0)
                {
                    //System.Threading.Thread.Sleep(50);
                    Print(population, somme, count);
                }
                somme = 0;
                foreach (var item in population)
                {
                    somme += item.distance;
                }
                //foreach (var item in population)
                //{
                //    item.probabilité = item.distance / somme;
                //}
                List<Individu> choisis = new List<Individu>();
                List<Individu> prochainePop = new List<Individu>();
                while (choisis.Count < 200)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        double a = 0;
                        double rand = pubRandom.NextDouble() * somme;
                        foreach (var item in population)
                        {
                            if (rand > a && rand < a + item.distance)
                            {
                                choisis.Add(item);
                                break;
                            }
                            a += item.distance;
                        }
                    }

                    prochainePop.AddRange(GenerateNewPop(choisis[choisis.Count - 2], choisis[choisis.Count - 1]));
                }
                population = prochainePop;
                count++;
            }
        }

        private static void Print(List<Individu> population, double somme, int count)
        {
            Console.Clear();
            int a = (int)((double)goal[0] / (double)UInt32.MaxValue * (Console.WindowWidth - 1));
            int b = (int)((double)goal[1] / (double)UInt32.MaxValue * (Console.WindowHeight - 2));
            Console.SetCursorPosition(a, b);
            Console.Write('O');
            foreach (var item in population)
            {
                int x = (int)((double)item.chromosome[0] / (double)UInt32.MaxValue * (Console.WindowWidth - 1));
                int y = (int)((double)item.chromosome[1] / (double)UInt32.MaxValue * (Console.WindowHeight - 2));
                Console.SetCursorPosition(x, y);
                Console.Write('#');
            }
            Console.SetCursorPosition(0, Console.WindowHeight - 1);
            if (somme > highest)
            {
                highest = somme;
            }
            Console.Write(somme + ":" + daBest + ":" + count);
            if (daBest >= 4294967296 - 100000)
            {
                Console.ReadKey(true);
            }
        }
        private static double highest = 0;
        private static IEnumerable<Individu> GenerateNewPop(Individu individu1, Individu individu2)
        {
            List<Individu> toReturn = new List<Individu>();
            StringBuilder ch1 = new StringBuilder();
            StringBuilder ch2 = new StringBuilder();
            string bit1 = Convert.ToString(individu1.chromosome[0], 2);
            ch1.Append(new string('0', 32 - bit1.Length));
            ch1.Append(bit1);
            bit1 = Convert.ToString(individu1.chromosome[1], 2);
            ch1.Append(new string('0', 32 - bit1.Length));
            ch1.Append(bit1);
            string bit2 = Convert.ToString(individu2.chromosome[0], 2);
            ch2.Append(new string('0', 32 - bit2.Length));
            ch2.Append(bit2);
            bit2 = Convert.ToString(individu2.chromosome[1], 2);
            ch2.Append(new string('0', 32 - bit2.Length));
            ch2.Append(bit2);
            string chromosome1 = ch1.ToString();
            string chromosome2 = ch2.ToString();
            if (pubRandom.Next(100) < 100)
            {
                int cut = pubRandom.Next(chromosome1.Length);
                StringBuilder c1 = new StringBuilder();
                StringBuilder c2 = new StringBuilder();
                c1.Append(chromosome1.Substring(0, cut));
                c1.Append(chromosome2.Substring(cut));
                c2.Append(chromosome2.Substring(0, cut));
                c2.Append(chromosome1.Substring(cut));
                chromosome1 = c1.ToString();
                chromosome2 = c2.ToString();
            }
            for (int i = 0; i < 2; i++)
            {
                if (pubRandom.Next(500) < 1)
                {
                    if (i == 0)
                    {
                        char[] buf = chromosome1.ToCharArray();
                        int a = pubRandom.Next(buf.Length);
                        buf[a] = buf[a] == '0' ? '1' : '0';
                        chromosome1 = new string(buf);
                    }
                    else
                    {
                        char[] buf = chromosome2.ToCharArray();
                        int a = pubRandom.Next(buf.Length);
                        buf[a] = buf[a] == '0' ? '1' : '0';
                        chromosome2 = new string(buf);
                    }
                }
            }
            Individu a1 = new Individu();
            a1.chromosome = new UInt32[] { Convert.ToUInt32(chromosome1.Substring(0, chromosome1.Length / 2), 2), Convert.ToUInt32(chromosome1.Substring(chromosome1.Length / 2), 2) };
            a1.distance = GetDistance(a1);
            Individu a2 = new Individu();
            a2.chromosome = new UInt32[] { Convert.ToUInt32(chromosome2.Substring(0, chromosome1.Length / 2), 2), Convert.ToUInt32(chromosome2.Substring(chromosome1.Length / 2), 2) };
            a2.distance = GetDistance(a2);
            toReturn.Add(a1);
            toReturn.Add(a2);
            return toReturn;
        }

        private static double GetDistance(Individu buf)
        {
            double ret = UInt32.MaxValue - Math.Sqrt(Math.Pow(Math.Abs(goal[0] - buf.chromosome[0]), 2) + Math.Pow(Math.Abs(goal[1] - buf.chromosome[1]), 2));
            if (ret > daBest)
            {
                daBest = ret;
            }
            return ret;
        }
        public static double daBest = 0;
        private static UInt32[] GetRandomChromosome()
        {
            UInt32[] toReturn = new UInt32[2];
            for (int i = 0; i < 2; i++)
            {
                toReturn[i] = (UInt32)pubRandom.Next() + (UInt32)pubRandom.Next();
            }
            return toReturn;
        }
        public static Random pubRandom = new Random();
        public static UInt32[] goal = { (UInt32)pubRandom.Next() + (UInt32)pubRandom.Next(), (UInt32)pubRandom.Next() + (UInt32)pubRandom.Next()};
    }
    class Individu
    {
        public UInt32[] chromosome { get; set; }
        public double distance { get; set; }
    }
}
