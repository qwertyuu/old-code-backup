using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickSortRecursif
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> lol = new List<int>();
            using (StreamReader sR = new StreamReader("Valeurs.txt"))
            {
                string line = "";
                while (line != null)
                {
                    line = sR.ReadLine();
                    if (line != null)
                    {
                        lol.Add(int.Parse(line));
                    }
                }
            }


            foreach (var item in QuickSort(lol))
            {
                Console.WriteLine(item);
            }
            Console.ReadKey(true);
        }

        public static List<int> QuickSort(List<int> _num)
        {
            if (_num.Count <= 1)
            {
                return _num;
            }
            List<int> egalOuInferieur = new List<int>();
            List<int> superieur = new List<int>();
            int pivot = _num[_num.Count - 1];
            _num.Remove(pivot);
            foreach (var item in _num)
            {
                if (item <= pivot)
                {
                    egalOuInferieur.Add(item);
                }
                else
                {
                    superieur.Add(item);
                }
            }
            List<int> toReturn = new List<int>();
            foreach (var item in QuickSort(egalOuInferieur))
            {
                toReturn.Add(item);
            }
            toReturn.Add(pivot);
            foreach (var item in QuickSort(superieur))
            {
                toReturn.Add(item);
            }
            return toReturn;
        }

    }
}
