using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTest
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> a = new List<int>();
            a.Add(1);
            a.Add(5);
            a.Add(3);
            a.Add(5);
            var lol = from i in a
                      orderby i ascending
                      select i;
            foreach (var item in lol)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey(true);
        }
    }
}
