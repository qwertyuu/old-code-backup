using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace RSSSniffer
{
    class Program
    {
        static void Main(string[] args)
        {

            HttpWebRequest rssFeed = (HttpWebRequest)WebRequest.Create("https://www.facebook.com/feeds/page.php?id=305291009614592&format=rss20");

            rssFeed.UserAgent = "Mozilla/5.0 (Windows NT 6.1; WOW64; rv:25.0) Gecko/20100101 Firefox/25.0";
            Console.WriteLine("Working...");
            using (StreamWriter sw = new StreamWriter("lol.xml"))
            {
                //sw.Write(WebUtility.HtmlDecode(new StreamReader(rssFeed.GetResponse().GetResponseStream()).ReadToEnd()));
                sw.Write(new StreamReader(rssFeed.GetResponse().GetResponseStream()).ReadToEnd());
            }
            Console.WriteLine("Done. Enregistré dans \"lol.xml\".");
            Console.Write("Appuyer sur une touche pour continuer...");
            Console.ReadKey(true);
        }
    }
}