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
            play.couleur = Color.Blue;
            play.returnState = GameState.InGame;
            AddButton(play);

            Buttons options = new Buttons();
            options.text = "Options";
            options.couleur = Color.White;
            options.fontColor = Color.Black;
            options.returnState = GameState.Options;
            AddButton(options);

            Buttons quit = new Buttons();
            quit.text = "Quit";
            quit.couleur = Color.Orange;
            quit.Clic += quit_Clic;
            AddButton(quit);
        }

        private void quit_Clic(object sender, IMenu swag)
        {
            Game1._Exit = true;
        }
        public override void EscapePressed()
        {
            Game1._Exit = true;
            base.EscapePressed();
        }

    }
}
