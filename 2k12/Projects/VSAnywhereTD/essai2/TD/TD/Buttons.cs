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
        virtual public Rectangle spacePos { get; set; }
        public Texture2D texture { get; set; }
        public Color couleur { get; set; }
        virtual public Vector2 textSpot { get; set; }
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
        public Buttons()
        {
            this.texture = Game1.cellT;
            this.returnState = GameState.None;
        }
        public static float variation = 50;
        public bool offset { get; set; }
        private string _text;
        public string text
        {
            get { return _text; }
            set
            {
                _text = value;
                this.font = Game1.font;
            }
        }
        public float Transparency = 1;

        public GameState returnState { get; set; }
        public event OwnerChangedEventHandler Clic;

        virtual public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, spacePos, couleur * Transparency);
            spriteBatch.DrawString(font, text, textSpot, fontColor);

        }
        public delegate void OwnerChangedEventHandler(object sender, IMenu swag);
        internal void Clicked(IMenu lol)
        {
            if (this.Clic != null)
            {
                this.Clic(this, lol);
            }
        }

        virtual public bool Update(MouseHandler mouse, IMenu sender)
        {

            if (spacePos.Contains(mouse.position))
            {
                Transparency = 0.5f;
                if (mouse.LeftClickState == ClickState.Clicked)
                {
                    Clicked(sender);
                    if (returnState != GameState.None)
                        return true;
                }
            }
            else
                Transparency = 1.0f;

            return false;
        }

    }
}
