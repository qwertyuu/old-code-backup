using agsXMPP;
using System;
using System.Linq;
using System.Text;
using ActualMessage = agsXMPP.protocol.client.Message;

namespace JABBERNAUT
{
    public class Utilisateur
    {
        public Jid ID;
        public State WhatAmIDoing;
        public Game WhatAmIPlaying;
        public Infos infos;
        public Utilisateur(Jid _id)
        {
            infos = new Infos(_id);
            
            ID = _id;
			WhatAmIDoing = new State(State.Types.Chatting, Games.None);
        }
        public void Input(string message)
        {
            switch (WhatAmIDoing.state)
            {
                case State.Types.Chatting:

                    var parts = message.Split(' ');
                    bool broken = false;
                    switch (parts[0].ToLower())
                    {
                        case "play":
                            Games outGame = Games.None;
                            if (parts.Length <= 1)
                            {
                                broken = true;
                                break;
                            }
                            if (Enum.GetNames(typeof(Games)).Contains(parts[1]))
                            {
                                outGame = (Games)Enum.Parse(typeof(Games), parts[1]);
                                WhatAmIDoing = new State(State.Types.Playing, outGame);
                                WhatAmIPlaying = GetGameInstance(outGame);
                                Program.Loggit(this, string.Format("joue à {0}", WhatAmIPlaying.GameName), ConsoleColor.DarkYellow);
                            }
                            else
                            {
                                Tell("Le jeu \"" + parts[1] + "\" n'existe pas!");
                            }
                            break;
                        case "aide":
                            Tell("Le seul jeu pour le moment c'est HotAndCold :P Pour jouer entre\nPlay HotAndCold");
                            break;
                        default:
                            Tell(new string(message.Reverse().ToArray()));
                            break;
                    }
                    if (broken)
                    {
                        Tell(new string(message.Reverse().ToArray()));
                    }
                    break;
                case State.Types.Playing:
                    switch (WhatAmIDoing.currentlyPlaying)
                    {
                        case Games.None:
                            this.QuitGame();
                            break;
                        default:
                            if (WhatAmIPlaying.Input(message))
                            {
                                this.QuitGame();
                            }
                            break;
                    }
                    break;
                default:
                    break;
            }
        }

        private Game GetGameInstance(Games game)
        {
            switch (game)
            {
                case Games.HotAndCold:
                    return new HotAndCold(this);
                case Games.CleverBot:
                    return new CleverBot(this);
                default:
                    return null;
            }
        }
        public void Tell(string message)
        {
            Program.Loggit(this, message, ConsoleColor.DarkRed);
            Program.xmpp.Send(new ActualMessage(ID, message));
            System.Threading.Thread.Sleep(100);
        }

        internal void QuitGame()
        {
            Tell("De retour au chat!");
            Program.Loggit(this, "a quitté le jeu", ConsoleColor.DarkYellow);
			WhatAmIDoing = new State(State.Types.Chatting, Games.None);
            WhatAmIPlaying = null;
        }
    }
}
