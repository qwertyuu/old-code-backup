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

    class Buttons
    {
        public Rectangle spacePos { get; set; }
        public Texture2D texture { get; set; }
        public Color couleur { get; set; }
        public SpriteFont font { get; set; }
        public static float variation = 100;
        public bool offset { get; set; }
        public string text { get; set; }
        public float Transparency { get; set; }

        public GameState returnState { get; set; }
        public String Text { get; set; }
        public event EventHandler Clic;

        public Buttons(Rectangle _spacePos, Texture2D _texture, Color _couleur, GameState _return, string text)
        {
            spacePos = _spacePos;
            couleur = _couleur;
            texture = _texture;
            returnState = _return;
            Transparency = 1.0f;

        }
        public void Draw(SpriteBatch spriteBatch)
        {

        }

        internal void Clicked()
        {
            if (this.Clic != null)
            {
                this.Clic(this, new EventArgs());
            }
        }
    }
}
