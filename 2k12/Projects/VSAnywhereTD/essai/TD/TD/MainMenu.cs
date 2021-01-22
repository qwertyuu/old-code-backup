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

namespace TD
{

    class MainMenu : IMenu
    {
        public GameState gameState { get; set; }

        public MainMenu(List<Texture2D> textures)
        {
            gameState = GameState.MainMenu;
            buttons = new List<Buttons>();
            buttons.Add(new Buttons(new Rectangle(GraphicsDeviceManager.DefaultBackBufferWidth / 2 - 100, 150, 200, 40), textures[0], Color.White, GameState.PlayMenu));
            buttons.Add(new Buttons(new Rectangle(GraphicsDeviceManager.DefaultBackBufferWidth / 2 - 100, buttons[0].spacePos.Y + 60, 200, 40), textures[1], Color.White, GameState.Options));
            buttons.Add(new Buttons(new Rectangle(GraphicsDeviceManager.DefaultBackBufferWidth / 2 - 100, buttons[0].spacePos.Y + 120, 200, 40), textures[0], Color.Orange, GameState.Quit));
        }

        public GameState UpdateGameState(MouseHandler mouse)
        {
            foreach (var item in buttons)
            {
                if (item.spacePos.Contains(mouse.position))
                {
                    item.Transparency = 0.5f;
                    if (mouse.LeftClickState == ClickState.Clicked)
                    {
                        return item.returnState;
                    }
                }
                else
                    item.Transparency = 1.0f;
            }
            return GameState.MainMenu;
        }

    }
}
