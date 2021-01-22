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
    class GameOverMenu : IMenu
    {
        string level;
        Camera cam;
        List<Cell> cellWithTowers;

        public GameOverMenu(ref Camera _cam, ref List<Cell> _cellWithTowers, string lvl = "1.txt")
        {
            level = lvl;
            cam = _cam;
            cellWithTowers = _cellWithTowers;

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
            cam.position = Vector2.Zero;
            cellWithTowers.Clear();
            CreepWave.inGameCreeps.Clear();
            Game1.inGameState = InGameState.Play;
        }
    }
}
