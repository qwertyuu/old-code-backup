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
    public class Tower
    {
        public enum Types { type1, swag }
        public Texture2D text;
        public Rectangle boundingBox;
        public Types type;
        public Vector2 gridPosition;
        public int level;
        public int damage;

        public static void PrintAllTowers(List<Tower> list, SpriteBatch sBatch)
        {
            foreach (var item in list)
            {
                item.Draw(sBatch, 1.0f);
            }
        }

        public Tower()
        {

        }

        public Tower(Point pos, Types _type, Texture2D texture)
        {
            level = 1;
            type = _type;
            text = texture;
            boundingBox = new Rectangle(pos.X, pos.Y, Cell.size, Cell.size);
        }

        public void Draw(SpriteBatch sprite, float alpha)
        {
            sprite.Draw(text, boundingBox, Color.White * alpha);
        }

        public void levelUp()
        {
            level++;
            //damage =   ???  ;

        }

        public Rectangle BoundingBox { get { return boundingBox; } }

    }
}
