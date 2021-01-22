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
    class InGameMenu : IMenu
    {
        string level;

        public InGameMenu(string lvl = "1.txt")
        {
            gameState = GameState.InGameMenu;

            level = lvl;

            Buttons play = new Buttons();
            play.text = "Play";
            play.font = Game1.font;
            play.texture = Game1.cellT;
            play.couleur = Color.Blue;
            play.returnState = GameState.InGame;
            AddButton(play);

            Buttons menu = new Buttons();
            menu.text = "Main Menu";
            menu.font = Game1.font;
            menu.texture = Game1.cellT;
            menu.couleur = Color.Yellow;
            menu.Clic += menu_Clic;
            menu.returnState = GameState.MainMenu;
            AddButton(menu);
        }

        void menu_Clic(object sender, EventArgs e)
        {
            Map.Res
        }
    }
}
