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

namespace TD
{
    class IMenu
    {

        protected List<Buttons> buttonsList;
        public GameState gameState { get; set; }
        public GameState Escape { get; set; }
        public Vector2 centerPoint = new Vector2(GraphicsDeviceManager.DefaultBackBufferWidth / 2, GraphicsDeviceManager.DefaultBackBufferHeight / 2);
        public static List<IMenu> lesMenus = new List<IMenu>();

        public IMenu(GameState _gameState)
        {
            buttonsList = new List<Buttons>();
            gameState = _gameState;
            lesMenus.Add(this);
        }

        public void AddButton(string text, SpriteFont font, Texture2D texture, GameState returnState)
        {
            AddButton(text, font, texture, returnState, Color.White);
        }

        public void AddButton(string text, SpriteFont font, Texture2D texture, GameState returnState, Color couleur)
        {
            Vector2 stringM = font.MeasureString(text) + new Vector2(40);
            buttonsList.Add(new Buttons(new Rectangle(0, 0, (int)stringM.X, (int)stringM.Y),
                texture,
                couleur,
                returnState,
                text));
            for (int i = 0; i < buttonsList.Count; i++)
            {
                Rectangle place = new Rectangle((int)centerPoint.X, (int)centerPoint.Y + (int)((i + ((buttonsList.Count - 1) * -0.5)) * Buttons.variation), buttonsList[i].spacePos.Width, buttonsList[i].spacePos.Height);
                buttonsList[i].spacePos = new Rectangle(place.X - place.Width / 2, place.Y - place.Height / 2, place.Width, place.Height);
            }
        }

        public static IMenu UpdateMenu(MouseHandler mouse, IMenu current)
        {
            List<Buttons> currentMenuList = lesMenus[lesMenus.IndexOf(current)].buttonsList;
            foreach (var item in currentMenuList)
            {
                if (item.spacePos.Contains(mouse.position))
                {
                    item.Transparency = 0.5f;
                    if (mouse.LeftClickState == ClickState.Clicked)
                    {
                        item.Clicked();
                        return lesMenus.Find(bk => bk.gameState == item.returnState);
                    }
                }
                else
                    item.Transparency = 1.0f;
            }
            return current;
        }

        public static void Draw(SpriteBatch spriteBatch, IMenu current)
        {
            List<Buttons> currentMenuList = lesMenus.Find(bk => bk == current).buttonsList;
            foreach (var item in currentMenuList)
            {
                spriteBatch.Draw(item.texture, item.spacePos, item.couleur * item.Transparency);
            }
        }

        static public Cell[,] cleanMap(Cell[,] map)
        {
            for (int i = 0; i < map.GetLength(0); i++)
            {
                for (int j = 0; j < map.GetLength(1); j++)
                {
                    map = Cell.Parse("1.txt");
                }
            }
            return map;
        }
    }
}
