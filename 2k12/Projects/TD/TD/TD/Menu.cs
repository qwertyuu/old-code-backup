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

    class StateHandler
    {
        public GameState gameState { get; set; }
        Rectangle playMenu;
        Texture2D playText;

        public StateHandler(Texture2D[] textures)
        {
            gameState = GameState.MainMenu;
            playMenu = new Rectangle(0, 0, 100, 40);
            playText = textures[0];
        }

        public void Update(MouseHandler mouse)
        {
            if (playMenu.Contains(mouse.position))
            {
                if (mouse.LeftClickState == ClickState.Clicked)
                {
                    //cliqué sur le bouton

                }
                else
                {
                    //il ne se déclanchera pas (si le bouton est continuellement pressé, pas pressé dutout ou relaché sur le bouton)
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(playText, playMenu, Color.Yellow);
        }
    }
}
