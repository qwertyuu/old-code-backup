using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace DLThemall
{
    class Program
    {
        static void Main(string[] args)
        {
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml("http://spoursh.com/spoursh/duhrpritz/Music/Top%20100%20Trance%20and%20Techno%20Party%20Songs%20of/Top%20100%20Trance%20and%20Techno%20Party%20Songs%20of/");
            Console.WriteLine(doc.DocumentNode.SelectNodes("//"));
            //foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//href"))
            //{
            //    Console.WriteLine(link);
            //}
            Console.ReadKey(true);
        }
    }
}
