using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJE
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong sum = 0;
            Console.WriteLine(facteur(11));
            for (ulong i = 3; i < 11; i++)
            {
                ulong[] partiesI = decouper(i);
                ulong total = 0;
                for (ulong j = 0; j < (ulong)partiesI.Length; j++)
                {
                    total += facteur(partiesI[j]);
                }
                if (total == i)
                {
                    sum += i;
                }
            }
            Console.WriteLine(sum);
            Console.ReadKey(true);
        }

        static ulong[] decouper(ulong n)
        {
            string texteN = n.ToString();
            char[] caractereN = texteN.ToCharArray();
            ulong[] toReturn = new ulong[caractereN.Length];
            for (ulong i = 0; i < (ulong)toReturn.Length; i++)
            {
                toReturn[i] = (ulong)char.GetNumericValue(caractereN[i]);
            }
            return toReturn;
        }

        static ulong facteur(ulong n)
        {
            //Console.WriteLine(n);
            if (n == 2)
            {
                return 2;
            }
            return n * facteur(n - 1);
        }
    }
}
