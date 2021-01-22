using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using agsXMPP;
using agsXMPP.protocol.client;
using agsXMPP.Collections;
using agsXMPP.protocol.iq.roster;
using System.Threading;
using ActualMessage = agsXMPP.protocol.client.Message;
using System.Net;
using System.Text.RegularExpressions;
using System.Globalization;
using System.IO;

namespace JABBERNAUT
{
    public enum Games { None, HotAndCold, CleverBot }
    class Program
    {
        static List<Utilisateur> online;
        public static XmppClientConnection xmpp = new XmppClientConnection("chat.facebook.com");
        static void Main(string[] args)
        {
            online = new List<Utilisateur>();
            Thread query = new Thread(TellUsTheTruth);
            query.IsBackground = true;
            string JID_Sender = "da.jabber.naut@chat.facebook.com";
            Console.WriteLine("JID: {0}", JID_Sender);
            string Password = "";
            using (StreamReader sR = new StreamReader("pw.txt"))
            {
                Password = sR.ReadLine();
            }
            Console.WriteLine(Password);
            try
            {
                xmpp.OnMessage += xmpp_OnMessage;
                xmpp.OnLogin += new ObjectHandler(xmpp_OnLogin);
                xmpp.OnSocketError += xmpp_OnSocketError;
                xmpp.OnClose += xmpp_OnClose;
                xmpp.OnAuthError += xmpp_OnAuthError;
                xmpp.OnStreamError += xmpp_OnStreamError;
                xmpp.OnError += xmpp_OnError;
                xmpp.OnPresence += new PresenceHandler(xmpp_OnPresence);
                Jid jidSender = new Jid(JID_Sender);
                xmpp.Open(jidSender.User, Password);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            query.Start(xmpp);
            while (true)
            {
                if (Console.ReadKey(true).Key == ConsoleKey.Q)
                {
                    foreach (var item in online)
                    {
                        item.Tell("Bye bye!");
                    }
                    xmpp.Close();
                    break;
                }
            }
        }

        static void xmpp_OnStreamError(object sender, agsXMPP.Xml.Dom.Element e)
        {
            Console.WriteLine("fgdsf");
            Console.WriteLine(e.InnerXml);
        }

        static void xmpp_OnAuthError(object sender, agsXMPP.Xml.Dom.Element e)
        {
            Console.WriteLine("sad");
            Console.WriteLine(e.InnerXml);
        }

        static void xmpp_OnSocketError(object sender, Exception ex)
        {
            Console.WriteLine("clown");
            Console.WriteLine(ex.Data.Values);
            Console.WriteLine(ex.InnerException);
            Console.WriteLine(ex.Message);
        }

        static void xmpp_OnMessage(object sender, ActualMessage msg)
        {
            var user = GIMME(msg.From);

            string uName = user.infos.FirstName;
            Program.Loggit(user, msg.Body, ConsoleColor.Green);
            if (!string.IsNullOrEmpty(msg.Body))
            {
                //FAIRE UN INPUTHANDLER POUR LES INPUT!!!!!
                //non raph tayeule
                user.Input(msg.Body);
            }
        }

        private static Utilisateur GIMME(Jid jid)
        {
            var toReturn = online.Find(a => a.ID.User == jid.User);
            if (toReturn == null)
            {
                toReturn = new Utilisateur(jid);
                online.Add(toReturn);

                Program.Loggit(toReturn, "Added!", ConsoleColor.Blue);
                
                toReturn.Input("aide");
            }
            return toReturn;
        }


        static void xmpp_OnClose(object sender)
        {
            Console.WriteLine("Connection closed");
        }

        static void xmpp_OnError(object sender, Exception ex)
        {
            Console.WriteLine("ccccccc");
            Console.WriteLine(ex.Message);
        }

        private static void TellUsTheTruth(object obj)
        {
            while (true)
            {
                Console.Title = string.Format("Connection State:{0} -- Authenticated?:{1}", xmpp.XmppConnectionState, xmpp.Authenticated);
                Thread.Sleep(100);
            }
        }
        public static void Loggit(Utilisateur user, string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write("<{0}>", user.infos.Name);
            Console.ResetColor();
            Console.WriteLine(message);
        }

        private static void xmpp_OnPresence(object sender, Presence pres)
        {
            if (pres.Type == PresenceType.available)
            {
                var user = GIMME(pres.From);
                string uName = user.infos.FirstName;
            }
        }

        private static void xmpp_OnLogin(object sender)
        {
            Console.WriteLine("Logged In");
            Presence p = new Presence(ShowType.chat, "Online");
            p.Type = PresenceType.available;
            xmpp.Send(p);

        }
    }
}
