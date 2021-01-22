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
        List<Cell> cellWithTowers;

        public InGameMenu(ref Camera _cam, ref List<Cell> _cellWithTowers, string lvl = "1.txt")
        {
            gameState = GameState.InGameMenu;
            Escape = GameState.InGame;
            level = lvl;
            cam = _cam;
            cellWithTowers = _cellWithTowers;

            Buttons returnToGame = new Buttons();
            returnToGame.text = "Go back to game";
            returnToGame.font = Game1.font;
            returnToGame.texture = Game1.cellT;
            returnToGame.couleur = Color.RoyalBlue;
            returnToGame.returnState = GameState.InGame;
            AddButton(returnToGame);

            Buttons options = new Buttons();
            options.text = "Options";
            options.font = Game1.font;
            options.texture = Game1.cellT;
            options.couleur = Color.Red;
            options.returnState = GameState.Options;
            AddButton(options);

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

        private void menu_Clic(object sender, IMenu swag)
        {
            Map.map = Map.Parse(Game1.currentMap);
            Game1.gold = 150;
            cam.position = Vector2.Zero;
            cellWithTowers.Clear();
            CreepWave.inGameCreeps.Clear();
            Game1.inGameState = InGameState.Play;
        }
    }
}
