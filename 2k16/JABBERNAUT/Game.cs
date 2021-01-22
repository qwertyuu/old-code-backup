using System;
using System.Linq;
using System.Text;

namespace JABBERNAUT
{
    public abstract class Game
    {
        public Utilisateur Player;
        public abstract string GameName { get; set; }
        public Game(Utilisateur player)
        {
            Player = player;
        }
        public virtual bool Input(string arg)
        {
            if (arg.Trim().ToLower() == "quit")
            {
                return true;
            }
            return false;
        }
    }
}
