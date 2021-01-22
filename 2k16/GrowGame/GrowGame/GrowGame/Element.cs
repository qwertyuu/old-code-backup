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

namespace GrowGame
{
    class Element
    {
        public Element()
        {
            SpacePos = new Rectangle(0, 0, 50, 50);
            Acceleration = Vector2.Zero;
            Speed = Vector2.Zero;
        }
        public Rectangle SpacePos { get; private set; }
        public int Size
        {
            get
            {
                return SpacePos.Width / 5;
            }
            set
            {
                SpacePos = new Rectangle(SpacePos.X, SpacePos.Y, value * 5, value * 5);
            }
        }
        private Vector2 _pos;

        public Vector2 Pos
        {
            get { return _pos; }
            set
            {
                SpacePos = new Rectangle((int)value.X, (int)value.Y, SpacePos.Width, SpacePos.Height);
                _pos = value;
            }
        }

        public Vector2 Acceleration { get; set; }
        public Vector2 Speed { get; set; }

        internal void Update(GameTime gameTime)
        {
            Speed += Acceleration * new Vector2((float)gameTime.ElapsedGameTime.TotalSeconds);
            if (Math.Sqrt(Speed.X * Speed.X + Speed.Y * Speed.Y) > 30 || (Math.Abs(Acceleration.X) > 0 || Math.Abs(Acceleration.Y) > 0))
            {
                Speed -= Speed / 30;
            }
            else
            {
                Speed = Vector2.Zero;
            }
            Pos += new Vector2(Speed.X * (float)gameTime.ElapsedGameTime.TotalSeconds, Speed.Y * (float)gameTime.ElapsedGameTime.TotalSeconds);
        }
    }
}
