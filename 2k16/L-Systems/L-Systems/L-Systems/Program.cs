using System;
using System.Windows.Forms;

namespace L_Systems
{
#if WINDOWS || XBOX
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            Settings s = new Settings();
            if (s.ShowDialog() == DialogResult.Yes)
            {
                using (Game1 game = new Game1(s.settings))
                {
                    game.Run();
                }
            }
        }
    }
#endif
}

