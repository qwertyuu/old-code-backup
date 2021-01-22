using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace change_base
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Chiffre décimal: ");
            int toChange = int.Parse(Console.ReadLine());
            Console.Write("Base: ");
            int baseToApply = int.Parse(Console.ReadLine());
            int baseFollower = 1;
            int count = 0;
            while (baseFollower <= toChange)
            {
                baseFollower *= baseToApply;
                count++;
            }
            baseFollower /= baseToApply;
            int[] output = new int[count];
            count = 0;
            while (toChange > 0)
            {
                if (toChange >= baseFollower)
                {
                    toChange -= baseFollower;
                    output[count]++;
                }
                else
                {
                    baseFollower /= baseToApply;
                    count++;
                }
            }
            foreach (var item in output)
            {
                Console.Write(item);
            }
            Console.WriteLine();
            Console.ReadLine();
        }
    }
}
