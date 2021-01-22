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
        public Vector2 textSpot { get; set; }
        public Vector2 textOffset { get; set; }
        public Color fontColor { get; set; }
        private SpriteFont _font { get; set; }
        public SpriteFont font
        {
            get
            { 
                return _font; 
            }
            set 
            {
                _font = value;
                fontColor = Color.White;
                Vector2 buf = _font.MeasureString(text);
                spacePos = new Rectangle(spacePos.X, spacePos.Y, (int)buf.X + 100, (int)buf.Y + 10);
                textOffset = new Vector2(spacePos.Width / 2 - buf.X / 2, spacePos.Height / 2 - buf.Y / 2);
            }
        }
        public static float variation = 100;
        public bool offset { get; set; }
        public string text { get; set; }
        public float Transparency = 1;

        public GameState returnState { get; set; }
        public event EventHandler Clic;

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, spacePos, couleur * Transparency);
            spriteBatch.DrawString(font, text, textSpot, fontColor);

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
