using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Web;
using System.Diagnostics;
using System.IO;

namespace RedditScrper
{
    class Program
    {
        static void Main(string[] args)
        {
            XmlDocument xml = new XmlDocument();
            Console.WriteLine("Enter the subreddit:");
            string uInput = Console.ReadLine();
            Console.WriteLine("Loading RSS...");
            xml.Load("http://www.reddit.com/r/" + uInput + "/.rss");
            List<string> liens = new List<string>();
            string site = @"<!DOCTYPE html>
<html>
    <head>
        <title>sup</title>
        <meta charset=""UTF-8"">
        <link rel=""stylesheet"" type=""text/css"" href=""theme.css"">
    </head> 
    <body>
        <input type=""button"" value=""prev"" onclick=""prev()""/>
        <div id=""count""></div>
        <input type=""button"" value=""next"" onclick=""next()""/>
        <div id=""globalYT""><div id=""youtubeROX""></div></div>
        {0}
        <script src=""http://www.youtube.com/player_api""></script>
        <script src=""sauce.js""></script>
    </body>
</html>";
            string spans = "\n\t";
            foreach (XmlElement item in xml.GetElementsByTagName("item"))
            {
                XmlElement lel = xml.CreateElement("item");
                lel.InnerXml = HttpUtility.HtmlDecode(item.InnerXml);
                string lien = lel.SelectSingleNode("//text()[contains(.,'[link]')]").ParentNode.Attributes["href"].Value;
                if (lien.Contains("youtube"))
                {
                    int index = lien.IndexOf('&');
                    if (index != -1)
                    {
                        lien = lien.Substring(0, index);
                    }
                    string ID = lien.Substring(lien.Length - 11, 11);
                    Console.WriteLine(lien + ">" + ID);
                    spans += "<span id=\"" + ID + "\"></span>\n\t";

                }
            }
            site = site.Replace("{0}", spans);
            using (StreamWriter sW = new StreamWriter("index.html"))
            {
                sW.Write(site);
            }
            if (!File.Exists("sauce.js"))
            {
                GenerateJS();
            }
            Process.Start("index.html");
            Console.ReadKey(true);
        }

        private static void GenerateJS()
        {
            using (StreamWriter sW = new StreamWriter("sauce.js"))
            {
                sW.Write(@"var IDs = [];
var lel = document.getElementsByTagName(""SPAN"");
var count = document.getElementById(""count"");
var body = document.getElementsByTagName(""body"")[0];
var currentSong = 0;
var IDs = [];
var ready = false;
for (var index = 0; index < lel.length; index++) {
    IDs.push(lel[index].getAttribute(""id""));
}
setCurrent(currentSong);

function next()
{
    if (currentSong < IDs.length - 1)
    {
        currentSong++;
        setCurrent(currentSong);
    }
}
function prev()
{
    if (currentSong > 1)
    {
        currentSong--;
        setCurrent(currentSong);
        
    }
}
function setCurrent(_index)
{
    // create youtube player
    if (!ready) {
        window.onYouTubePlayerAPIReady = function() {
            var player = new YT.Player('youtubeROX', {
                height: '390',
                width: '640',
                videoId: IDs[_index],
                events: {
                    'onReady': onPlayerReady,
                    'onStateChange': onPlayerStateChange
                }
            });
        };
        ready = true;
    }
    else {
        document.getElementById(""globalYT"").innerHTML = ""<div id='youtubeROX'></div>"";
        var player = new YT.Player('youtubeROX', {
            height: '390',
            width: '640',
            videoId: IDs[_index],
            events: {
                'onReady': onPlayerReady,
                'onStateChange': onPlayerStateChange
            }
        });
    }
    // autoplay video
    function onPlayerReady(event) {
        event.target.playVideo();
    }

    // when video ends
    function onPlayerStateChange(event) {
        if (event.data === 0) {
            next();
        }
    }
    count.textContent = (_index + 1) + '/' + IDs.length;
}");

            }
        }
    }
}
