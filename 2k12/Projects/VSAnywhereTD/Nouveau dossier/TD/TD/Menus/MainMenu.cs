#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
#endregion

namespace TD.Menus
{
    class MainMenu : IMenu
    {
        public MainMenu()
        {
            gameState = GameState.MainMenu;
            Buttons play = new Buttons();
            play.text = "Play";
            play.font = Game1.font;
            play.texture = Game1.cellT;
            play.couleur = Color.Blue;
            play.returnState = GameState.InGame;
            AddButton(play);

            Buttons quit = new Buttons();
            quit.text = "Quit";
            quit.font = Game1.font;
            quit.texture = Game1.cellT;
            quit.couleur = Color.Orange;
            quit.returnState = GameState.None;
            quit.Clic += quit_Clic;
            AddButton(quit);
        }
        public override void EscapePressed()
        {
            Game1._Exit = true;
            base.EscapePressed();
        }

        void quit_Clic(object sender, EventArgs e)
        {
            Game1._Exit = true;
        }

    }
}
