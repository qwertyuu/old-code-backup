using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Threading;

namespace TwitchPlays
{
    class IrcBot
    {
        // Irc server to connect
        public static string SERVER = "irc.twitch.tv";
        // Irc server's port (6667 is default port)
        private static int PORT = 6667;
        // User information defined in RFC 2812 (Internet Relay Chat: Client Protocol) is sent to irc server
        private static string USER = "USER twitchplaysmortalkombat4 0 * :twitchplaysmortalkombat4";
        // Bot's nickname
        private static string NICK = "twitchplaysmortalkombat4";
        // Channel to join
        private static string CHANNEL = "#twitchplaysmortalkombat4";
        // StreamWriter is declared here so that PingSender can access it
        public static StreamWriter writer;
        static void Main(string[] args)
        {
            NetworkStream stream;
            TcpClient irc;
            string inputLine;
            StreamReader reader;
            string nickname;
            try
            {
                irc = new TcpClient(SERVER, PORT);
                stream = irc.GetStream();
                string commandToRemove = "PRIVMSG #twitchplaysmortalkombat4 :";
                reader = new StreamReader(stream);
                writer = new StreamWriter(stream) { AutoFlush = true };
                // Start PingSender thread
                PingSender ping = new PingSender();
                writer.WriteLine("PASS oauth:l9u905e27ueea0z3gp559wlm83pn91f");
                ping.Start();
                writer.WriteLine("NICK " + NICK);
                writer.WriteLine(USER);
                writer.WriteLine("JOIN " + CHANNEL);
                while (true)
                {
                    while ((inputLine = reader.ReadLine()) != null)
                    {
                        Console.WriteLine(inputLine);
                        int index;
                        if ((index = inputLine.IndexOf(commandToRemove)) != -1)
                        {
                            string command = inputLine.Substring(index + commandToRemove.Length);
                            Console.WriteLine("Le message est:" + command);
                        }
                    }
                    // Close all streams
                    writer.Close();
                    reader.Close();
                    irc.Close();
                }
            }
            catch (Exception e)
            {
                // Show the exception, sleep for a while and try to establish a new connection to irc server
                Console.WriteLine(e.ToString());
                Thread.Sleep(5000);
                string[] argv = { };
                Main(argv);
            }
        }
    }
    class PingSender
    {
        static string PING = "PING :";
        private Thread pingSender;
        // Empty constructor makes instance of Thread
        public PingSender()
        {
            pingSender = new Thread(this.Run);
        }
        // Starts the thread
        public void Start()
        {
            pingSender.Start();
        }
        // Send PING to irc server every 15 seconds
        public void Run()
        {
            while (true)
            {
                IrcBot.writer.WriteLine(PING + IrcBot.SERVER);
                Thread.Sleep(20000);
            }
        }
    }
}
