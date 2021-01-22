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
    public class Creep
    {
        public enum Types { type1, type2 }

        public Rectangle boundingBox { get; set; }
        public Dictionary<Tower, double> distances = new Dictionary<Tower, double>();
        private int index = 0;
        public Vector2 vectorPos { get; set; }
        public Vector2 direction { get; set; }
        public Vector2 destination { get; set; }
        public int speed { get; set; }
        public bool IsDead { get { return life <= 0; } }
        public int life;
        public Types type { get; set; }
        public Texture2D text;
        public Vector2 gridPos;

        public Creep(Types _type)
        {
            life = 100;
            index = 0;
            speed = 60;
            destination = new Vector2(Map.waypoints[index].spacePos.X, Map.waypoints[index].spacePos.Y);
            vectorPos = new Vector2(Map.initialPathLocation.X, Map.initialPathLocation.Y);
            boundingBox = new Rectangle(Map.initialPathLocation.X, Map.initialPathLocation.Y, Cell.size, Cell.size);
            text = Game1.creepText;
            type = _type;
        }

        public void Update(GameTime gameTime)
        {
            distances.Clear();
            if (vectorPos != destination)
            {
                direction = Vector2.Normalize(destination - vectorPos);
                vectorPos += direction * speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
                if (Math.Abs(Vector2.Dot(direction, Vector2.Normalize(destination - vectorPos)) + 1) < 0.1f)
                {
                    vectorPos = destination;
                }
                boundingBox = new Rectangle((int)vectorPos.X, (int)vectorPos.Y, boundingBox.Width, boundingBox.Height);
            }
            else
            {
                index++;
                if (index < Map.waypoints.Count)
                {
                    destination = new Vector2(Map.waypoints[index].spacePos.Location.X, Map.waypoints[index].spacePos.Location.Y);
                }
                else
                {
                    life = 0;
                    Game1.playerLife--;
                }
            }
        }

        public void Draw(SpriteBatch sprite)
        {
            sprite.Draw(text, boundingBox, show ? Color.Red : Color.White);
        }

        public void getDamage(Tower attackingTower)
        {
            life -= attackingTower.damage;
            if (life < 0)
            {
                life = 0;
                Game1.gold += 20;
            }
        }

        public bool show { get; set; }
    }
}
