using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Same
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime lala = DateTime.Now;
            int max = 0;
            for (int i = 0; i < 100; i++)
            {
                for (int multiple1 = 0; multiple1 < 999; multiple1++)
                {
                    for (int multiple2 = multiple1; multiple2 < 999; multiple2++)
                    {
                        var val = multiple1 * multiple2;
                        var shit = val.ToString();
                        if (shit == new string(shit.Reverse().ToArray()))
                        {
                            if (val > max)
                            {
                                max = val;
                            }
                        }
                    }
                }
                Console.WriteLine(i.ToString() + ' ' + (DateTime.Now - lala).TotalSeconds);
            }
            Console.WriteLine(max);
            Console.WriteLine((DateTime.Now - lala).TotalSeconds);
            Console.ReadKey(true);
        }
    }
}
