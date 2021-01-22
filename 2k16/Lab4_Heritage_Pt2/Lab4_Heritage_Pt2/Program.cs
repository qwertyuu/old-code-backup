using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Heritage_Pt2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.ReadKey(true);
            bool simuler = true;
            List<Element> plateforme = new List<Element>();
            Console.CursorVisible = false;
            Random hasard = new Random();
            //dimensions: 80, 25 - 1
            GenererPopDepart(plateforme, 50);

            while (simuler)
            {
                if (hasard.Next(100) == 1)
                {
                    Pleuvoir(plateforme);
                }
                for (int i = 0; i < plateforme.Count; i++)
                {
                    Element item = plateforme[i];
                    if (!item.EnVie)
                    {
                        plateforme.Remove(item);
                        i--;
                    }
                    item.Update(plateforme);
                }
                RendreGraphique(plateforme);
            }
        }

        private static void Pleuvoir(List<Element> _plateforme)
        {
            Random dé = new Random();
            int w = Console.WindowWidth;
            int h = Console.WindowHeight - 1;
            int max = dé.Next(60);
            for (int i = 0; i < max; i++)
            {
                _plateforme.Add(new Eau(dé.Next(w), dé.Next(h)));
            }
        }

        private static void GenererPopDepart(List<Element> plateforme, int _max)
        {
            Random random = new Random();
            int w = Console.WindowWidth;
            int h = Console.WindowHeight - 1;
            for (int i = 0; i < _max; i++)
            {
                Element choix;
                int pourcent = random.Next(100);
                if (pourcent < 10)
                {
                    choix = new Predateur(random.Next(w), random.Next(h));
                }
                else if (pourcent < 40)
                {
                    choix = new Proie(random.Next(w), random.Next(h));
                }
                else if (pourcent < 60)
                {
                    choix = new Plante(random.Next(w), random.Next(h));
                }
                else
                {
                    choix = new Eau(random.Next(w), random.Next(h));
                }
                plateforme.Add(choix);
            }
        }

        private static void RendreGraphique(List<Element> _plateforme)
        {
            int w = Console.WindowWidth;
            int h = Console.WindowHeight - 1;
            char[] leGraphique = new string(' ', w * h).ToCharArray();
            foreach (var item in _plateforme)
            {
                leGraphique[(int)Math.Round(item.Pos.X) + w * (int)Math.Round(item.Pos.Y)] = item.Caractere;
            }
            Console.SetCursorPosition(0, 0);
            System.Threading.Thread.Sleep(100);
            Console.Write(new string(leGraphique));
        }
    }
}
