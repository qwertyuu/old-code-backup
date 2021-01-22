using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapMaker
{
    class Cell
    {
        public enum Kind { Rock, Turret, Creep }
        public bool changed { get; set; }
        public Rectangle position;
        public static int grosseur = 15;
        public Color couleur;
        public int chiffre;
        public Kind kind { get; set; }
        public Cell(int x, int y)
        {
            couleur = Color.Green;
            chiffre = 2;
            kind = Kind.Turret;
            position = new Rectangle(x * grosseur, y * grosseur, grosseur, grosseur);
        }

        internal void Draw(SpriteBatch sprite)
        {
            sprite.Draw(Game1.texture, position, couleur);
        }

        internal void SwitchKind()
        {
            if (!changed)
            {
                if ((int)kind < 2)
                {
                    kind++;
                }
                else
                {
                    kind = (Kind)0;
                }
                switch (kind)
                {
                    case Kind.Rock:
                        couleur = Color.Red;
                        chiffre = 0;
                        break;
                    case Kind.Turret:
                        couleur = Color.Green;
                        chiffre = 2;
                        break;
                    case Kind.Creep:
                        couleur = Color.White;
                        chiffre = 1;
                        break;
                    default:
                        break;
                }
                changed = true;
            }
        }
    }
}
