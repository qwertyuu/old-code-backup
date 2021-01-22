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
    class UIButtons
    {
        public Rectangle spacePos { get; set; }
        public Texture2D icon { get; set; }
        public bool doAnimation = true;
        private Color _couleur;
        public Color couleur
        {
            get { return _couleur; }
            set
            {


                _couleur = value;
                if (tempColor == new Color())
                {
                    tempColor = value;
                }
            }
        }
        public Color tempColor { get; set; }
        public InGameState returnState { get; set; }
        public UIButtonFunction function { get; set; }

        public float Transparency = 1;

        public event EventHandler Clic;
        public event EventHandler Release;

        public void Draw(SpriteBatch sprite)
        {
            sprite.Draw(icon, spacePos, couleur);
        }

        internal void Released()
        {
            if (doAnimation)
                couleur = tempColor;

            if (this.Release != null)
                this.Release(this, new EventArgs());
        }

        internal void Clicked()
        {
            if (doAnimation)
                couleur = Color.Black * 0.5f;

            if (this.Clic != null)
            {
                this.Clic(this, new EventArgs());
            }
        }

        public Keys Hotkey { get; set; }
    }
}