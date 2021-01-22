using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong
{
    class AI
    {
        public Joueur whoIAm { get; private set; }
        public bool canMove { get; set; }
        public Vector2 lastBall { get; set; }
        public bool calculate { get; set; }
        DateTime test;
        public Ball toUpdate { get; set; }
        public void MathUpdate(Ball balle)
        {
            if (toUpdate.spacePos == Rectangle.Empty)
            {
                if (lastBall != Vector2.Zero)
                {
                    if (DateTime.Now >= test)
                    {
                        if (balle.pos != lastBall)
                        {
                            float a = (lastBall.Y - balle.pos.Y) / (lastBall.X - balle.pos.X);
                            float b = lastBall.Y - a * lastBall.X;
                            float y = a * (GraphicsDeviceManager.DefaultBackBufferWidth - 20) + b;
                            bool lol = false;
                            while (y > GraphicsDeviceManager.DefaultBackBufferHeight)
                            {
                                y -= GraphicsDeviceManager.DefaultBackBufferHeight;
                                lol = !lol;
                            }
                            while (y < 0)
                            {
                                y += GraphicsDeviceManager.DefaultBackBufferHeight;
                                lol = !lol;
                            }
                            if (y == 0)
                                lol = false;
                            if (lol)
                            {
                                toUpdate.spacePos = new Rectangle(0, GraphicsDeviceManager.DefaultBackBufferHeight - (int)y, 0, 0);
                            }
                            else
                            {
                                toUpdate.spacePos = new Rectangle(0, (int)y, 0, 0);
                            }
                        }
                    }
                }
                else
                {
                    lastBall = balle.pos;
                    test = DateTime.Now.AddMilliseconds(10);
                }
            }
            else
            {
                Update(toUpdate);
            }
        }
        public void Reset()
        {
            toUpdate = new Ball();
            toUpdate.spacePos = Rectangle.Empty;
            lastBall = Vector2.Zero;
        }
        public void Update(Ball balle)
        {
            if (canMove)
            {
                if (balle.spacePos.Center.Y > whoIAm.spacePos.Center.Y + 30)
                {
                    whoIAm.direction = Joueur.Direction.Down;
                }
                else if (balle.spacePos.Center.Y < whoIAm.spacePos.Center.Y - 30)
                {
                    whoIAm.direction = Joueur.Direction.Up;
                }
                else
                {
                    whoIAm.direction = Joueur.Direction.None;
                }
            }
        }
        public AI(ref Joueur player)
        {
            whoIAm = player;
            toUpdate = new Ball();
            toUpdate.spacePos = Rectangle.Empty;
        }
    }
}
