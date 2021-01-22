using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace binary_keys_generator
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.Write("Longueur d'encryption, en bits:");
            int bits = int.Parse(Console.ReadLine());
            StreamWriter lol = new StreamWriter(@"C:\Users\Paul\Desktop\lol.txt");
            StringBuilder a = new StringBuilder();
            Random randBit = new Random();
            for (int i = 0; i < bits; i++)
            {
                if (i % 100 == 0 && i > 0)
                {
                    lol.Write(lol.NewLine);
                }
                lol.Write(randBit.Next(2));
            }
            lol.Close();
            Console.Write("Fini");
            Console.ReadLine();
        }
    }
}
