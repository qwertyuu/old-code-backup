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
        public GameState Escape = GameState.None;
        public Vector2 centerPoint = new Vector2(GraphicsDeviceManager.DefaultBackBufferWidth / 2, GraphicsDeviceManager.DefaultBackBufferHeight / 2);
        public static List<IMenu> lesMenus = new List<IMenu>();

        public virtual void EscapePressed()
        {

        }

        public IMenu()
        {
            buttonsList = new List<Buttons>();
            lesMenus.Add(this);
        }

        public void AddButton(Buttons _button)
        {
            buttonsList.Add(_button);
            for (int i = 0; i < buttonsList.Count; i++)
            {
                Rectangle place = new Rectangle((int)centerPoint.X, (int)centerPoint.Y + (int)((i + ((buttonsList.Count - 1) * -0.5)) * Buttons.variation), buttonsList[i].spacePos.Width, buttonsList[i].spacePos.Height);
                buttonsList[i].spacePos = new Rectangle(place.X - place.Width / 2, place.Y - place.Height / 2, place.Width, place.Height);
                buttonsList[i].textSpot = new Vector2(buttonsList[i].textOffset.X + buttonsList[i].spacePos.X, buttonsList[i].textOffset.Y + buttonsList[i].spacePos.Y);
            }
        }

        public static IMenu UpdateMenu(MouseHandler mouse, IMenu current, KeyboardHandler kB)
        {
            List<Buttons> currentMenuList = lesMenus[lesMenus.IndexOf(current)].buttonsList;
            if (kB.pressedKeysList.Contains(Keys.Escape))
            {
                current.EscapePressed();
                return lesMenus.Find(bk => bk.gameState == current.Escape);
            }
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
                item.Draw(spriteBatch);
            }
        }
    }
}
