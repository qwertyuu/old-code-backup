using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using agsXMPP;
using agsXMPP.protocol.client;
using agsXMPP.Collections;
using agsXMPP.protocol.iq.roster;
using System.Threading;
using ActualMessage = agsXMPP.protocol.client.Message;

namespace FBBot
{
    public partial class Form1 : Form
    {

        XmppClientConnection xmpp = new XmppClientConnection("chat.facebook.com", 5222);
        public Form1()
        {
            InitializeComponent();
            xmpp.OnLogin += new ObjectHandler(xmpp_OnLogin);
            xmpp.OnError += xmpp_OnError;
            xmpp.OnMessage += xmpp_OnMessage;
            while (true)
            {
                MessageBox.Show(xmpp.XmppConnectionState.ToString());
                Thread.Sleep(5000);
            }
        }

        private void xmpp_OnMessage(object sender, ActualMessage msg)
        {
            MessageBox.Show(msg.Value);
        }


        void xmpp_OnError(object sender, Exception ex)
        {
            MessageBox.Show(ex.Message);
        }

        void xmpp_OnLogin(object sender)
        {
            MessageBox.Show("Login successful.");
            xmpp.Open("qwertyuu", "qw3rtyui0p");
            Presence p = new Presence(ShowType.chat, "Online");
            p.Type = PresenceType.available;
            xmpp.Send(p);
            xmpp.Send(new ActualMessage("qwertyuu@chat.facebook.com", MessageType.chat, "Hi"));
        }
    }
}
