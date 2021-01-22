using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace million_pi
{
    class Program
    {
        static void Main(string[] args)
        {
            WebClient client = new WebClient();
            for (int i = 4; i <= 1000; i++)
            {
                Console.WriteLine(i + " ");
                try
                {
                    Console.Write(client.DownloadString("http://3.141592653589793238462643383279502884197169399375105820974944592.com/index" + i + ".html"));
                    Console.ReadKey();
                    Console.Clear();
                }
                catch (WebException e)
                {
                    Console.Clear();
                    Console.Write(e.Message);
                }
            }
            Console.ReadKey();
        }
    }
}
