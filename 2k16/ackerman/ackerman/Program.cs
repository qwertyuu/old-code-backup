using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ackerman
{
    class Program
    {
        static void Main(string[] args)
        {
            /*def A(m, n):
    return n + 1 if m == 0 else A(m - 1, 1) if n == 0 else A(m - 1, A(m, n - 1))

for m in range(5):
    for n in range(5):
        print '(' + str(m) + ', ' + str(n) + ') = ' + str(A(m, n))*/
            for (int m = 0; m < 5; m++)
            {
                for (int n = 0; n < 5; n++)
                {
                    level = 0;
                    Console.WriteLine("A({0}, {1}) = {2}", m, n, A(m, n));
                    Console.ReadLine();
                }
            }
        }
        static int level = 0;
        static int A(int m, int n)
        {
            string before = "";
            for (int i = 0; i < level; i++)
            {
                before += "  |";
            }
            Console.WriteLine(before + "{0}:{1}", m, n);
            level++;
            int toReturn = m == 0 ? n + 1 : n == 0 ? A(m - 1, 1) : A(m - 1, A(m, n - 1));
            level--;
            return toReturn;
        }
    }
}
