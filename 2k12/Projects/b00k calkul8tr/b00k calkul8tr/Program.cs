using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace b00k_calkul8tr
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Page actuelle: ");
            int whereAmINow = int.Parse(Console.ReadLine()) - 1;
            Console.Write("Nombre de pages dans le livre: ");
            int totalPages = int.Parse(Console.ReadLine());
            Console.Write("Appuyez sur une touche quand vous commencez à lire la page...");
            Console.ReadLine();
            int index = 0;
            while (true)
            {
                DateTime reading = DateTime.Now;
                Console.Clear();
                Console.Title = "LECTURE";
                Console.WriteLine("Page {0}/{1}, il reste donc {2} page" + ((totalPages - whereAmINow > 1) ? "s" : string.Empty) + " à lire. {3}% de lu.", whereAmINow + 1, totalPages, totalPages - whereAmINow, Math.Round(((double)whereAmINow) / (double)totalPages * 100, 1));
                Console.WriteLine("MODE LECTURE, APPUYEZ SUR ÉCHAP POUR VOIR LES STATISTIQUES ET METTRE LE CHRONO  SUR PAUSE");
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.Escape:
                        Console.Clear();
                        spanTime += DateTime.Now - reading;
                        MathThis(index, totalPages, whereAmINow);
                        Console.Title = "PAUSE";
                        Console.WriteLine("MODE PAUSE, APPUYEZ SUR UNE TOUCHE POUR RECOMMENCER À LIRE");
                        Console.ReadKey(true);
                        break;
                    case ConsoleKey.Tab:
                        Console.Clear();
                        spanTime += DateTime.Now - reading;
                        whereAmINow++;
                        MathThis(index, totalPages, whereAmINow);
                        index++;
                        Console.Title = "PAUSE, FIN DE PAGE";
                        Console.WriteLine("MODE PAUSE, APPUYEZ SUR UNE TOUCHE POUR RECOMMENCER À LIRE");
                        Console.ReadKey(true);
                        break;
                    default:
                        index++;
                        whereAmINow++;
                        spanTime += DateTime.Now - reading;
                        break;
                }
            }
        }
        static TimeSpan spanTime = new TimeSpan();
        static TimeSpan moyenne = new TimeSpan();
        static TimeSpan remainBuffer = new TimeSpan();
        static void MathThis(int _i, int totalPages, int _where)
        {
            int pageBuf = _i + 1;
            Console.WriteLine("Page {0}/{1}, il reste donc {2} page" + ((totalPages - _where > 1) ? "s" : string.Empty) + " à lire. {3}% de lu.", _where + 1, totalPages, totalPages - _where, Math.Round(((double)_where) / (double)totalPages * 100, 1));
            moyenne = TimeSpan.FromTicks(spanTime.Ticks / pageBuf);
            Console.WriteLine("Moyenne: {0} minute" + ((moyenne.Minutes > 1) ? "s" : string.Empty) + " et {1} seconde" + ((moyenne.Seconds > 0) ? "s" : string.Empty) + " par pages.", moyenne.Minutes, moyenne.Seconds);
            remainBuffer = TimeSpan.FromTicks((spanTime.Ticks / pageBuf) * (totalPages - _where));
            Console.WriteLine("Temps restant total: {0} heure" + ((remainBuffer.Hours > 1) ? "s" : string.Empty) + " et {1} minute" + ((remainBuffer.Minutes > 0) ? "s" : string.Empty), remainBuffer.Hours, remainBuffer.Minutes);
            DateTime actualBuffer = DateTime.Now + remainBuffer;
            Console.WriteLine("Tu devrais avoir fini vers {0}", string.Format("{0:t}", actualBuffer));
        }
    }
}