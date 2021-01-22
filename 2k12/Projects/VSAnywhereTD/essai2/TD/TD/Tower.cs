#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers;
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
        public List<Creep> AvailableCreeps = new List<Creep>();
        public bool inCooldown { get; set; }
        private int _Range;

        public int Range
        {        
            get
            {
                return _Range;
            }
            set
            {
                _Range = value;
                rangePos = SetRangePos();
            }
        }

        private Rectangle SetRangePos()
        {
            return new Rectangle(boundingBox.Center.X - Range, boundingBox.Center.Y - Range, Range * 2, Range * 2);
        }

        public Rectangle rangePos { get; set; }
        public Texture2D text;
        private Rectangle _boundingBox;
        public Rectangle boundingBox
        {
            get
            {
                return _boundingBox;
            }
            set
            {
                _boundingBox = value;
                rangePos = SetRangePos();
            }
        }
        public Types towertype;
        public List<UIButtonFunction> neededFunctions { get; set; }
        public Vector2 gridPosition;
        public int level;
        public int damage;
        public bool show;
        private DateTime Cooldown;
        public List<Projectile> projectiles { get; set; }
        public int speed { get; set; }
        static public int maxLevel { get { return 3; }}

        public Tower(Point pos, Types _type, Texture2D texture, int range, bool _show)
        {
            inCooldown = false;
            projectiles = new List<Projectile>();
            level = 1;

            damage = 5;
            speed = 500;
            towertype = _type;
            text = texture;
            show = _show;
            boundingBox = new Rectangle(pos.X, pos.Y, Cell.size, Cell.size);
            Range = range;
            neededFunctions = new List<UIButtonFunction>();
            if (_type == Types.type1)
            {
                neededFunctions.Add(UIButtonFunction.Add);
                neededFunctions.Add(UIButtonFunction.Sell);
                neededFunctions.Add(UIButtonFunction.Upgrade);
            }
        }

        public void Draw(SpriteBatch sprite, float alpha)
        {
            if (this == Game1.SelectedObject)
                sprite.Draw(text, boundingBox, Color.Blue * alpha);
            else
                sprite.Draw(text, boundingBox, Color.Red * alpha);

            if (projectiles.Count > 0)
            {
                foreach (var item in projectiles)
                {
                    item.Draw(sprite);
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            if (AvailableCreeps.Count > 0)
            {
                //double minimum = AvailableCreeps.Min(bK => bK.distances[this]);
                //var lol = AvailableCreeps.Find(bk => bk.distances[this] <= minimum);
                Attack(AvailableCreeps[0]);
            }


            if (projectiles.Count > 0)
            {
                for (int i = 0; i < projectiles.Count; i++)
                {
                    if (projectiles[i].Update(gameTime))
                    {
                        projectiles.RemoveAt(i);
                        i--;
                    }
                }
            }
            AvailableCreeps.Clear();
        }

        private void Attack(Creep item)
        {
            if (!inCooldown)
            {
                projectiles.Add(new Projectile(Game1.missileText, this, item));
                inCooldown = true;
                Cooldown = DateTime.Now.AddMilliseconds(speed);
            }
            else if(DateTime.Now >= Cooldown)
            {
                inCooldown = false;
            }
        }

        public void DrawRange(SpriteBatch sprite)
        {
            sprite.Draw(Game1.towerRange, rangePos, Color.White * 0.3f);
        }

        public void levelUp()
        {
            if (level < maxLevel)
            {
                level++;
                if (damage > int.MaxValue / 2)
                {
                    damage = int.MaxValue;
                }
                else
                {
                    damage *= 2;
                }
                speed /= 2;
                Range += 30;
            }
        }

        public static double DetectCreep(Creep creep, Tower tower)
        {
            //a^2+b^2=c^2
            //c = SQRT(a^2+b^2)
            List<Point> corners = new List<Point>();
            corners.Add(creep.boundingBox.Location);
            corners.Add(new Point(creep.boundingBox.Right, creep.boundingBox.Top));
            corners.Add(new Point(creep.boundingBox.Left, creep.boundingBox.Bottom));
            corners.Add(new Point(creep.boundingBox.Right, creep.boundingBox.Bottom));
            double smallest = double.MaxValue;
            foreach (var item in corners)
            {
                int deltaX = tower.boundingBox.Center.X - item.X;
                int deltaY = tower.boundingBox.Center.Y - item.Y;
                var dist = Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
                if (dist < smallest)
                {
                    smallest = dist;
                }
            }

            return smallest;
        }
        
        public static uint getAddCostByType(Types type)
        {
                switch (type)
	                {
                    case Types.type1 :
                        return 50;

		            default:
                        return 0;
	                }
        }

        internal uint UpgradeCostByType(Types type)
        {
            switch (type)
            {
                case Types.type1:
                    return 150;

                default:
                    return 0;
            }
        }
    }
}