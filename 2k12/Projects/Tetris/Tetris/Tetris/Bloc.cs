using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tetris
{
    class Bloc
    {
        public static Color[] colors = { Color.Red, Color.White, Color.Orange, Color.Yellow, Color.Green, Color.Black };
        public bool rotate = false;
        Database dB = new Database();
        private Vector2 _pos;
        public Vector2 position
        {
            get { return _pos; }
            set
            {
                fakePos = value / 10;
                _pos = value;
            }
        }
        public Color color { get; set; }
        public Vector2 fakePos { get; private set; }
        private List<Vector2> layout = new List<Vector2>();
        public Texture2D texture { get; set; }
        public Rotations rotation { get; set; }
        public BlocTypes type { get; private set; }
        private bool hasRotated = false;

        public void ChangeType(BlocTypes _type)
        {
            layout = dB.Layouts((int)_type);
            color = colors[(int)_type];
            hasRotated = false;
            type = _type;
        }

        public Bloc(BlocTypes _type, Texture2D text, Vector2 _position)
        {
            layout = dB.Layouts((int)_type);
            color = colors[(int)_type];
            type = _type;
            rotation = Rotations.Right;
            position = _position;
            texture = text;
        }

        public Bloc(BlocTypes _type, Texture2D text)
        {
            layout = dB.Layouts((int)_type);
            color = colors[(int)_type];
            rotation = Rotations.Right;
            position = Vector2.Zero;
            texture = text;
        }
        public void Update()
        {
            if (rotate)
            {
                rotate = false;
                if (type == BlocTypes.I)
                {
                    layout = (hasRotated = !hasRotated) ?  dB.Layouts(dB.count - 1) : dB.Layouts(3);
                }
                else
                {
                    if (hasRotated)
                    {
                        hasRotated = false;
                        layout = dB.Layouts((int)type);
                    }
                    else
                    {
                        for (int i = 0; i < layout.Count; i++)
                        {
                            layout[i] = new Vector2(-layout[i].Y, layout[i].X);
                        }
                        if (type == BlocTypes.Sleft || type == BlocTypes.Sright)
                        {
                            hasRotated = true;
                        }
                    }
                }
            }
        }

        internal void Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, color);
            foreach (var item in layout)
            {
                spriteBatch.Draw(texture, item + position, color);
            }
        }
    }
}
