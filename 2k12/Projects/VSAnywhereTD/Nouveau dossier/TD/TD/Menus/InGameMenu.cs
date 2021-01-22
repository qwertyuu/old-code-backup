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
        Camera cam;

        public InGameMenu(ref Camera _cam, string lvl = "1.txt")
        {
            gameState = GameState.InGameMenu;
            Escape = GameState.InGame;
            level = lvl;
            cam = _cam;

            Buttons returnToGame = new Buttons();
            returnToGame.text = "Go back to game";
            returnToGame.font = Game1.font;
            returnToGame.texture = Game1.cellT;
            returnToGame.couleur = Color.RoyalBlue;
            returnToGame.returnState = GameState.InGame;
            AddButton(returnToGame);

            Buttons menu = new Buttons();
            menu.text = "Main Menu";
            menu.font = Game1.font;
            menu.fontColor = Color.Black;
            menu.texture = Game1.cellT;
            menu.couleur = Color.Yellow;
            menu.Clic += menu_Clic;
            menu.returnState = GameState.MainMenu;
            AddButton(menu);
        }

        void menu_Clic(object sender, EventArgs e)
        {
            Map.map = Map.Parse("1.txt");
            cam.position = Vector2.Zero;
        }
    }
}
