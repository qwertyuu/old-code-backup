using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChatterBotAPI;

namespace cleverchat
{
    class Program
    {
        static void Main(string[] args)
        {
            ChatterBotFactory factory = new ChatterBotFactory();

            ChatterBot bot1 = factory.Create(ChatterBotType.CLEVERBOT);
            ChatterBotSession bot1session = bot1.CreateSession();

            ChatterBot bot2 = factory.Create(ChatterBotType.CLEVERBOT);
            ChatterBotSession bot2session = bot2.CreateSession();

            string s = "Sauce";
            while (true)
            {

                try
                {
                    Console.WriteLine("bot1> " + s);

                    s = bot2session.Think(s);
                    Console.WriteLine("bot2> " + s);

                    s = bot1session.Think(s);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

        }
    }
}
