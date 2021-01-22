using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong
{
    class Ball
    {
        Random rand;
        public Rectangle spacePos { get; set; }
        public Vector2 pos { get; set; }
        public int direction { get; set; }
        public Vector2 speed { get; set; }
        public void Update(GameTime gametime)
        {
            pos = new Vector2(pos.X + (float)Math.Cos(MathHelper.ToRadians(direction)) * speed.X * (float)gametime.ElapsedGameTime.TotalSeconds, pos.Y + (float)Math.Sin(MathHelper.ToRadians(direction)) * speed.Y * (float)gametime.ElapsedGameTime.TotalSeconds);
            spacePos = new Rectangle((int)pos.X, (int)pos.Y, 20, 20);
        }
        public Ball()
        {
            rand = new Random();
            spacePos = new Rectangle(GraphicsDeviceManager.DefaultBackBufferWidth / 2 - 10, GraphicsDeviceManager.DefaultBackBufferHeight / 2 - 10, 20, 20);
            pos = new Vector2(spacePos.X, spacePos.Y);
            speed = new Vector2(300);
            direction = 90;
            while (direction == 90 || direction == 270)
            {
                direction = rand.Next(360);
            }
            direction = 180;
        }
    }
}
