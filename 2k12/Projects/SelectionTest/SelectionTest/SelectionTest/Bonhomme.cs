using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace SelectionTest
{
    class Bonhomme
    {
        public Rectangle spacePos { get; set; }
        private bool _selected { get; set; }
        public bool selected
        {
            get { return _selected; }
            set
            {
                _selected = value;
                couleur = value ? Color.Red : Color.White;
            }
        }
        private Vector2 _pos { get; set; }
        public int index { get; set; }
        public Vector2 pos
        {
            get { return _pos; }
            set
            {
                spacePos = new Rectangle((int)value.X, (int)value.Y, 20, 20);
                _pos = value;
            }
        }
        public Color couleur { get; set; }
    }
}
