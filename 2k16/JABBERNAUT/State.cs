using System;
using System.Linq;
using System.Text;

namespace JABBERNAUT
{
    public class State
    {
        public enum Types { Chatting, Playing }
        public Types state;
        public Games currentlyPlaying;
        public State(Types wut, Games game)
        {
            state = wut;
            currentlyPlaying = game;
        }
    }
}
