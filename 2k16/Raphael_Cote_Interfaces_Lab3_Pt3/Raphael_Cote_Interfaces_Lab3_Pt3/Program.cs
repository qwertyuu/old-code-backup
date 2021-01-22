using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raphael_Cote_Interfaces_Lab3_Pt3
{
    class Program
    {
        static void Main(string[] args)
        {
            Client bertrand = new Client();
            Console.WriteLine(bertrand.Compte.NAS);
            Console.ReadKey(true);
        }
    }
}
