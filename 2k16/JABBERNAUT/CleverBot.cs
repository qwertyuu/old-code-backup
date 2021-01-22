using System;
using ChatterBotAPI;
using System.Linq;
using System.Text;
using System.Web;

namespace JABBERNAUT
{
    class CleverBot : Game
    {
        public static ChatterBotFactory factory = new ChatterBotFactory();
        public ChatterBotSession session;
        public override string GameName { get; set; }
        public CleverBot(Utilisateur player) : base(player)
        {
            GameName = "CleverBot";
            session = factory.Create(ChatterBotType.CLEVERBOT).CreateSession();
            Player.Tell("Tu parles avec CleverBot!");
        }
        public override bool Input(string arg)
        {
            if (base.Input(arg))
            {
                return true;
            }
            try
            {
                Player.Tell(HttpUtility.HtmlDecode(session.Think(arg)));
            }
            catch (Exception e)
            {
                Player.Tell("Un problème est survenu avec Cleverbot. Retour au menu.\n" + e.Message);
                return true;
            }

            return false;
        }
    }
}
