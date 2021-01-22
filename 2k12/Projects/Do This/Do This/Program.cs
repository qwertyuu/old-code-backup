using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Do_This
{
    class Program
    {
        static void Main(string[] args)
        {
            string lel = @"　　　　　　　　　　▄█▀█▀█▄
　　　　　　　　▄█▀　　█　　▀█▄
　　　　　　　▄█▀　　　　　　　▀█▄
　　　　　　　█　　　　　　　　　　　█
　　　　　　　█　　　　　　　　　　　█
　　　　　　　▀█▄▄　　█　　　▄█▀
　　　　　　　　　█　　▄▀▄　　█
　　　　　　　　　█　▀　　　▀　█
　　　　　　　　　█　　　　　　　█
　　　　　　　　　█　　　　　　　█
　　　　　　　　　█　　　　 　　█
　　　　　　　　　█　　　　　　　█
　　　　　　　　　█　　　　　　　█
　　　▄█▀█▄█　　　　 　　　█▄█▀█▄
　▄█▀▀　　　　▀　　　　　　　　　　　　▀▀█
█▀　　　　　　　　　　　　　　　　　　　　　　▀█
█　　　　　　　　　　　　　　　　　　　　　　　　█
█　　　　　　　　　　　▄█▄　　　　　　　　　　█
▀█　　　　　　　　　█▀　▀█　　　　　　　　█▀
　▀█▄　　　　　　█▀　　　▀█　　　　　▄█▀
　　　▀█▄▄▄█▀　　　　　　▀█▄▄▄█▀";
            StringReader reader = new StringReader(lel);
                string line;
                var color = ConsoleColor.White;
                bool iAmGay = false;
                do
                {
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (color == ConsoleColor.Black)
                        {
                            color++;
                        }
                        Console.ForegroundColor = color;
                        Console.WriteLine(line);
                        if (color == ConsoleColor.White)
                        {
                            color = ConsoleColor.Black;
                        }
                        else
                            color++;
                    }
                    reader.Close();
                    reader.Dispose();
                    reader = new StringReader(lel);
                    System.Threading.Thread.Sleep(40);
                    Console.Clear();
                    color++;
                } while (iAmGay == false);
            Console.ReadLine();
        }
    }
}
