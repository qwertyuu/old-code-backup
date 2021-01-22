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
    class InGameUI
    {
        Texture2D[] textures;
        Rectangle[] textBounds;

        public InGameUI(Texture2D[] listOfTexture)
        {
            textures = listOfTexture;
            textBounds = new Rectangle[listOfTexture.Length];
            setTexturesPosition();
        }

        private void setTexturesPosition()
        {
            textBounds[0] = new Rectangle(0, 0, GraphicsDeviceManager.DefaultBackBufferWidth, GraphicsDeviceManager.DefaultBackBufferHeight);
        }


        public void Draw(SpriteBatch sprite)
        {
            for (int i = 0; i < textures.Length; i++)
            {
                if (textures[i] != null)
                    sprite.Draw(textures[i], textBounds[i], Color.White * 0.5f);
            }
        
        }
    }
}
