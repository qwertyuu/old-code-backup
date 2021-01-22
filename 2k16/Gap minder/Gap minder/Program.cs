using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;

namespace Gap_minder
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> notDownloaded = new List<int>();
            int[] lel = new int[]{196, 225, 226, 227, 228, 229, 230, 231, 232, 234, 235, 237, 238, 239, 240, 241, 242, 243, 244, 246, 247, 248, 249, 250, 251, 252, 253, 254, 255, 256, 257, 258, 259, 276};
            foreach (int page in lel)
			{
                string url = "http://nmg.thecomicseries.com/comics/" + page;
                string HTML;
                using (WebClient client = new WebClient())
                {
                    Console.WriteLine("Downloading page {0}...", page);
                    HTML = client.DownloadString(url);
                }
                Regex findar = new Regex(@"http:\/\/nmg\.webcomic\.ws\/images\/comics\/.+\.(png|jpg)");
                string match = findar.Match(HTML).Value;
                Console.WriteLine("found match: {0}", match);
                if (match != "")
                {
                    Console.WriteLine("found match: {0}", match);
                    using (WebClient client = new WebClient())
                    {
                        Console.WriteLine("Downloading image...");
                        string location = string.Format(@"C:\Users\Paul\Desktop\Backup\Images\Pictures\MindTheGap\{0}.{1}", page, match.Split('.').Last());

                        client.DownloadFile(match, location);
                        Console.WriteLine("Image saved as {0}", location);
                    }
                }
                else
                {
                    Console.WriteLine("Nothing matched. Adding page to the \"not downloaded\" list.");
                    notDownloaded.Add(page);
                }
			}
            Console.WriteLine("The following pages have not been downloaded:");
            foreach (var item in notDownloaded)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine("Fini");
            Console.ReadKey(true);
        }
    }
}
