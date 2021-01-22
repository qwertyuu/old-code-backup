using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weekdays
{
    class Program
    {
        static void Main(string[] args)
        {
            int uInput1 = GetDayValue(Console.ReadLine());
            int uInput2 = GetDayValue(Console.ReadLine());
            int days = 0;

            if (uInput1 > uInput2)
            {
                for (int i = uInput2; i < uInput1; i++)
                {
                    days = i;
                }
                days = 7 - days;
            }
            else
            {
                for (int i = uInput1; i < uInput2; i++)
                {
                    days = i;
                }                    
            }
            Console.Write(days);
            Console.ReadLine();
            
        }

        private static int GetDayValue(string p)
        {
            switch (p)
            {
                case "Mon":
                    return 1;
                case "Tue":
                    return 2;
                case "Wed":
                    return 3;
                case "Thu":
                    return 4;
                case "Fri":
                    return 5;
                case "Sat":
                    return 6;
                case "Sun":
                    return 7;
                default:
                    return 0;
            }
        }
    }
}
