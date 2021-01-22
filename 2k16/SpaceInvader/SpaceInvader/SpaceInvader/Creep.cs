using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvader
{
    enum Direction
    {
        Left,
        Right,
        Up,
        Down
    }
    class Creep
    {
        private int i;
        int speed;

        public Creep(int i, Texture2D texture)
        {
            this.speed = 10;
            this.Width = 50;
            this.SpacePos = new Rectangle(i * 60 + 50, 30, this.Width, this.Width);
            this.texture = texture;
        }
        public Rectangle SpacePos;
        public int Width;
        public Texture2D texture;

        internal void Update(Direction goingThisWay)
        {
            switch (goingThisWay)
            {
                case Direction.Left:
                    this.SpacePos.X -= speed;
                    break;
                case Direction.Right:
                    this.SpacePos.X += speed;
                    break;
                case Direction.Up:
                    this.SpacePos.Y -= speed;
                    break;
                case Direction.Down:
                    this.SpacePos.Y += speed;
                    break;
            }
        }

        internal void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, SpacePos, Color.White);
        }
    }
}
