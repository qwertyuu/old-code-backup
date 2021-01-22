using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            bool planter = false;
            try
            {
                s.Connect("127.0.0.1", 8);
            }
            catch (Exception ex)
            {
                planter = true;
                Console.WriteLine(ex.Message);
            }
            if (!planter)
            {
                Console.WriteLine("connecté");
                s.Close();
                Console.WriteLine("déconnecté");
                s.Dispose();
            }
            Console.ReadKey(true);
        }
    }
}
