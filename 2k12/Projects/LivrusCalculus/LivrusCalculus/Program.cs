using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrusCalculus
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Heures: ");
            int hour = int.Parse(Console.ReadLine());
            Console.Write("Minutes: ");
            int mins = int.Parse(Console.ReadLine());
            Console.Write("Secondes: ");
            int secs = int.Parse(Console.ReadLine());
            TimeSpan total = new TimeSpan(9, 55, 20);
            Console.WriteLine("{0} pages", (1 - ((double)new TimeSpan(hour, mins, secs).Ticks / total.Ticks)) * 313);
            var totalTime = new TimeSpan(new TimeSpan(hour, mins, secs).Ticks * 65 / 100);
            Console.WriteLine("Restant: {0}h{1}m{2}s", totalTime.Hours, totalTime.Minutes, totalTime.Seconds);
            Console.CursorVisible = false;
            Console.ReadLine();
        }
    }
}