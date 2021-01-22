using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dec_to_Bit
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            DateTime avant = DateTime.Now;
            for (int i = 0; i < 1000000; i++)
            {
                string toPrint = string.Empty;
                double input = rand.Next();
                double val = 1;
                while (val * 2 <= input)
                {
                    val *= 2;
                }
                while (val >= 1)
                {
                    if (input >= val)
                    {
                        toPrint += '1';
                        input -= val;
                    }
                    else
                    {
                        toPrint += '0';
                    }
                    val /= 2;
                }

                //double output = 0;
                //while (input != 0)
                //{
                //    double power = Math.Floor(Math.Log(input, 2));
                //    input -= Math.Pow(2, power);
                //    output += Math.Pow(10, power);
                //}
                //toPrint = output.ToString();

                //Console.WriteLine(toPrint);
            }

            Console.WriteLine((DateTime.Now - avant).TotalMilliseconds);
            Console.ReadKey(true);
        }
    }
}
