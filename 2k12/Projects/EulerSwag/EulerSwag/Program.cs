using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EulerSwag
{
    class Program
    {
        static void Main(string[] args)
        {
            UInt64 somme = 0;
            int[] all = new int[2000000];
            for (int i = 0; i < all.Length; i++)
            {
                all[i] = i;
            }
            int index = 2;
            bool killitwithfire = false;
            for (int i = 0; i < all.Length; i++)
            {
                    while (all[index] == -1)
                    {
                        index++;
                        if (index >= all.Length)
                        {
                            killitwithfire = true;
                            break;
                        }
                    }
                    if (killitwithfire)
                    {
                        break;
                    }

                    for (int j = all[index] * 2; j < all.Length; j += all[index])
                    {
                        all[j] = -1;
                    }
                    index++;
            }
            for (int i = 2; i < all.Length; i++)
            {
                if (all[i] != -1)
                {
                    somme += (UInt64)all[i];
                }
            }

            Console.WriteLine(somme);
            Console.ReadKey(true);

        }
    }
}
