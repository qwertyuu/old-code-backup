using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SpaceInvader
{
    class Wave
    {
        List<Creep> creeps = new List<Creep>();
        public int Width { get; set; }
        private int _pos;

        public int Pos
        {
            get { return _pos; }
            set 
            {
                _pos = value;
                int diff = value - creeps[0].SpacePos.X;
                if (diff != 0)
                {
                    for (int i = 0; i < creeps.Count; i++)
                    {
                        creeps[i].SpacePos.X += diff;
                    }
                }
            }
        }

        Direction whereWeGoin;
        bool switcher = true;
        private DateTime start;
        public Wave(Texture2D texture, GraphicsDeviceManager graphics)
        {
            for (int i = 0; i < 5; i++)
            {
                creeps.Add(new Creep(i, texture));
            }
            this.graphics = graphics;
            whereWeGoin = Direction.Right;
            start = DateTime.Now;
            UpdateProperties();
        }

        internal void Update()
        {
            if ((DateTime.Now - start).TotalSeconds >= 0.5)
            {

                start = DateTime.Now;
                foreach (var item in creeps)
                {
                    item.Update(whereWeGoin);
                }
                UpdateProperties();
                if (this.Width + this.Pos > graphics.PreferredBackBufferWidth - 50)
                {
                    this.Pos = graphics.PreferredBackBufferWidth - 50 - this.Width;
                    whereWeGoin = Direction.Down;
                }
                else if (whereWeGoin == Direction.Down)
                {
                    whereWeGoin = switcher ? Direction.Left : Direction.Right;
                    switcher = !switcher;
                }
                else if (this.Pos < 50)
                {
                    this.Pos = 50;
                    whereWeGoin = Direction.Down;
                }
            }
        }

        private void UpdateProperties()
        {
            this.Pos = creeps[0].SpacePos.X;
            this.Width = (creeps[creeps.Count - 1].SpacePos.X + 60) - this.Pos;
        }

        internal void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            foreach (var item in creeps)
            {
                item.Draw(spriteBatch);
            }
        }

        public GraphicsDeviceManager graphics { get; set; }
    }
}
