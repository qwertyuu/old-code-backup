using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Clock
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            int multiplier;
            int minutes = 0;
            int i;
            int cycle;
            char on = '☻';
            char off = '☺';
            bool bypass = true;
            char[] baite = new char[6];
            for (int j = 0; j < baite.Length; j++)
            {
                baite[j] = off;
            }
            int datSeconds;
            int demSeconds;
            while (true)
            {
                i = 0;
                cycle = 6;
                multiplier = 32;
                datSeconds = DateTime.Now.Second;
                demSeconds = datSeconds;
                if (datSeconds == 0 || bypass == true)
                {
                    minutes = CalculateMinutes(on, off);
                    bypass = false;
                }
                Console.SetCursorPosition(1, 1);
                while (cycle > 0)
                {
                    if (datSeconds >= multiplier)
                    {
                        datSeconds -= multiplier;
                        baite[i] = on;
                    }
                    Console.Write(baite[i]);
                    i++;
                    multiplier /= 2;
                    cycle -= 1;
                }
                Console.Title = minutes + " " + demSeconds.ToString();
                while (demSeconds == DateTime.Now.Second)
                {
                    System.Threading.Thread.Sleep(1000);
                }
                //array reset
                for (int j = 0; j < baite.Length; j++)
                {
                    baite[j] = off;
                }
            }
        }

        private static int CalculateMinutes(char _on, char _off)
        {
            Console.SetCursorPosition(0, 0);
            var i = 0;
            var cycle = 7;
            char[] baite = new char[7];
            for (int j = 0; j < baite.Length; j++)
            {
                baite[j] = _off;
            }
            var multiplier = 64;
            int thatMinute = DateTime.Now.Minute;
            int thisMinute = thatMinute;
            while (cycle > 0)
            {
                if (thatMinute >= multiplier)
                {
                    thatMinute -= multiplier;
                    baite[i] = _on;
                }
                Console.Write(baite[i]);
                i++;
                multiplier /= 2;
                cycle -= 1;
            }
            return thisMinute;
        }

    }
}
