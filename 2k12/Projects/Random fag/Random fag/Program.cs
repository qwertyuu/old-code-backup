using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_fag
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();

            string[] demStuff = { "nigger", "faggot", "fuck", "xD", "bitch", "hurr", "lul" };
            do
            {
                foreach (char haha in demStuff[rand.Next(demStuff.Length)])
                {
                    Console.Write(haha);
                    System.Threading.Thread.Sleep(100);
                }
                System.Threading.Thread.Sleep(400);
                Console.Write(" ");
            } while (true);
        }
    }
}
