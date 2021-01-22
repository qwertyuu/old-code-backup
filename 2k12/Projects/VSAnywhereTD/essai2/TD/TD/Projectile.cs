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
    public class Projectile
    {
        public Texture2D text { get; set; }
        public Rectangle boundingBox;
        public Vector2 pos { get; set; }
        Vector2 direction;
        float speed;
        Vector2 destination;
        Tower thetower;
        Creep aim;

        public Projectile(Texture2D texture, Tower tower, Creep _aim)
        {
            text = texture;
            speed = 900f;
            thetower = tower;
            aim = _aim;
            boundingBox = new Rectangle(tower.boundingBox.Center.X, tower.boundingBox.Center.Y, 5, 15);
            destination = new Vector2(aim.boundingBox.Center.X, aim.boundingBox.Center.Y);
        }

        public bool Update(GameTime gameTime)
        {
            pos = new Vector2(boundingBox.X, boundingBox.Y);
            destination = new Vector2(aim.boundingBox.Center.X, aim.boundingBox.Center.Y);
            if (pos != destination)
            {
                direction = Vector2.Normalize(destination - pos);
                pos += direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (Math.Abs(Vector2.Dot(direction, Vector2.Normalize(destination - pos)) + 1) < 0.1f)
                {
                    pos = destination;
                    aim.getDamage(thetower);
                    return true;
                }
                boundingBox = new Rectangle((int)pos.X, (int)pos.Y, boundingBox.Width, boundingBox.Height);
                return false;
            }
            else
            {
                return true;
            }
        }

        public void Draw(SpriteBatch sprite)
        {
            sprite.Draw(text, boundingBox, null, Color.White,(float)(Math.Atan2(destination.Y - pos.Y,destination.X - pos.X) + Math.PI / 2) , new Vector2(text.Width / 2, text.Height / 2), SpriteEffects.None, 0);
        }
    }
}
