using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace Sketch
{
    class Player
    {
        public Vector2 position { get; set; }
        public Texture2D texture { get; set; }
        public BoundingBox box { get; set; }
        public Vector2 speed { get; set; }
        public Vector2 acceleration { get; set; }
        public bool inAir { get; set; }
        public bool isStopping { get; set; }
        int plancher = 300;
        float accelSpeed = 80;
        public void Update(GameTime gameTime)
        {
            speed += acceleration * (float)gameTime.ElapsedGameTime.TotalSeconds;
            Vector2 buffer = speed;
            if (Math.Abs(speed.X) < 0.1f)
            {
                buffer.X = 0;
            }
            if (Math.Abs(speed.Y) < 0.1f)
            {
                buffer.Y = 0;
            }
            speed = buffer;
            position += speed;
            if (position.Y < plancher)
            {
                Vector2 lol = acceleration;
                lol.Y += 9.8f;
                acceleration = lol;
            }
            else
            {
                Vector2 lol = acceleration;
                Vector2 lolPos = position;
                Vector2 lolSpeed = speed;
                inAir = false;
                lolSpeed.Y = 0;
                lol.Y = 0;
                lolPos.Y = plancher;
                speed = lolSpeed;
                position = lolPos;
                acceleration = lol;
            }
            if (!inAir && isStopping)
            {
                Vector2 maxHandler = speed * -10;
                if (maxHandler.X < 0)
                {
                    if (maxHandler.X < -accelSpeed)
                    {
                        Vector2 buf = acceleration;
                        buf.X = -accelSpeed;
                        acceleration = buf;
                    }
                    else
                    {
                        Vector2 buf = acceleration;
                        buf.X = maxHandler.X;
                        acceleration = buf;
                    }
                }
                else
                {
                    if (maxHandler.X > accelSpeed)
                    {
                        Vector2 buf = acceleration;
                        buf.X = accelSpeed;
                        acceleration = buf;
                    }
                    else
                    {
                        Vector2 buf = acceleration;
                        buf.X = maxHandler.X;
                        acceleration = buf;
                    }
                }
            }
            if (speed.X < 0)
            {
                if (acceleration.X > 0)
                {
                    isStopping = true;
                }
                else
                {
                    isStopping = false;
                }
            }
            else if (speed.X > 0)
            {
                if (acceleration.X < 0)
                {
                    isStopping = true;
                }
                else
                {
                    isStopping = false;
                }
            }
            else
            {
                isStopping = false;
            }
        }
    }
}
