using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pong
{
    class Joueur
    {
        public Rectangle spacePos { get; set; }
        public SpriteFont ecriture { get; set; }
        private Vector2 actualPos { get; set; }
        public int score;
        public int centralPointDistance { get; set; }
        public Vector2 scorePos { get; set; }
        public Direction direction { get; set; }
        public int speed = 160;
        public enum Direction { Up, Down, None };

        public void Update(GameTime gametime)
        {
            switch (direction)
            {
                case Direction.Up:
                    if (actualPos.Y > 0)
                    {
                        actualPos -= new Vector2(0, (float)speed * (float)gametime.ElapsedGameTime.TotalSeconds);
                    }
                    else
                    {
                        actualPos = new Vector2(actualPos.X, 0);
                    }
                    break;
                case Direction.Down:
                    if (actualPos.Y < GraphicsDeviceManager.DefaultBackBufferHeight - spacePos.Height)
                    {
                        actualPos += new Vector2(0, (float)speed * (float)gametime.ElapsedGameTime.TotalSeconds);
                    }
                    else
                    {
                        actualPos = new Vector2(actualPos.X, GraphicsDeviceManager.DefaultBackBufferHeight - spacePos.Height);
                    }
                    break;
                default:
                    break;
            }
            spacePos = new Rectangle((int)actualPos.X, (int)actualPos.Y, spacePos.Width, spacePos.Height);
        }
        public void Reset(PlayerIndex playerIndex)
        {
            direction = Direction.None;
            switch (playerIndex)
            {
                case PlayerIndex.One:
                    scorePos = new Vector2(GraphicsDeviceManager.DefaultBackBufferWidth / 4 - ecriture.MeasureString(score.ToString()).X / 2, 0);
                    spacePos = new Rectangle(0, GraphicsDeviceManager.DefaultBackBufferHeight / 2 - spacePos.Height / 2, 20, 110);
                    break;
                case PlayerIndex.Two:
                    scorePos = new Vector2(3 * GraphicsDeviceManager.DefaultBackBufferWidth / 4 - ecriture.MeasureString(score.ToString()).X / 2, 0);
                    spacePos = new Rectangle(GraphicsDeviceManager.DefaultBackBufferWidth - 20, GraphicsDeviceManager.DefaultBackBufferHeight / 2 - spacePos.Height / 2, 20, 110);
                    break;
                default:
                    break;
            }
            actualPos = new Vector2(spacePos.X, spacePos.Y);
            speed = 160;

        }
        public Joueur(PlayerIndex playerIndex, SpriteFont _ecriture)
        {
            direction = Direction.None;
            centralPointDistance = 40;
            ecriture = _ecriture;
            switch (playerIndex)
            {
                case PlayerIndex.One:
                    scorePos = new Vector2(GraphicsDeviceManager.DefaultBackBufferWidth / 4 - ecriture.MeasureString(score.ToString()).X / 2, 0);
                    spacePos = new Rectangle(0, GraphicsDeviceManager.DefaultBackBufferHeight / 2 - spacePos.Height / 2, 20, 110);
                    break;
                case PlayerIndex.Two:
                    scorePos = new Vector2(3 * GraphicsDeviceManager.DefaultBackBufferWidth / 4 - ecriture.MeasureString(score.ToString()).X / 2, 0);
                    spacePos = new Rectangle(GraphicsDeviceManager.DefaultBackBufferWidth - 20, GraphicsDeviceManager.DefaultBackBufferHeight / 2 - spacePos.Height / 2, 20, 110);
                    break;
                default:
                    break;
            }
            actualPos = new Vector2(spacePos.X, spacePos.Y);
        }
    }
}
