using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Videotron_Mois
{
    class Program
    {
        static void Main(string[] args)
        {
            int mLength = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
            int now = DateTime.Now.Day - 3;
            if (now <= 0)
            {
                now += DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month - 1);
                mLength = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month - 1);
            }
            var a = Math.Round((decimal)now / mLength * 100, 0);
            Console.WriteLine(a + "%");
            string uInput = Console.ReadLine();
            int outResult;
            int daysUntil = mLength - now;
            bool pasEnAvance = true;
            if (int.TryParse(uInput, out outResult))
            {
                if (outResult > a)
                {
                    Console.Write("Arrete le download, tu dépasse... t'es {0}GBs en avance. ", (outResult * 125 / 100) - (a * 125 / 100));
                    pasEnAvance = false;
                }
                else if (outResult < a)
                {
                    Console.WriteLine("Tu peux encore downloader {0}GBs avant d'égaliser! ", (a * 125 / 100) - (outResult * 125 / 100));
                    if (daysUntil >= 2 * mLength / 3)
                    {
                        Console.Write("Mais y reste quand même {0} jours... ", daysUntil);
                    }
                    else if (daysUntil <= mLength / 3)
                    {
                        Console.Write("Pi y te reste juste {0} jours!! Gâtes-toi Raph! ", daysUntil);
                    }
                    else
                    {
                        Console.Write("Pis y reste encore {0} jours... Fais pas trop le fou! ", daysUntil);
                    }
                }
                else
                {
                    Console.Write("Si tu download, tu vas dépasser... T'es sur la limite!");
                }
                if (pasEnAvance)
                {
                    if (daysUntil == 0)
                    {
                        daysUntil = 1;
                    }
                    Console.Write("Environs {0}GB/jour.", Math.Round(((a * 125 / 100) - (outResult * 125 / 100)) / daysUntil, 1));
                }
                Console.ReadKey(true);
            }
        }
    }
}