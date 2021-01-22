using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tetris
{
    class GameGrid
    {
        public GameGrid(Vector2 _size)
        {
            size = _size;
        }
        private Vector2 sizeT;
        public Vector2 size
        {
            get { return sizeT; }
            private set
            {
                if (value.Y > GraphicsDeviceManager.DefaultBackBufferHeight || value.X > GraphicsDeviceManager.DefaultBackBufferWidth)
                {
                    throw new OverflowException("La plage est plus grande que l'aire de jeu");
                }
                else if (value.X % 10 != 0 || value.Y % 10 != 0)
                {
                    throw new Exception("La plage n'est pas divisible par dix");
                }
                else
                {
                    position = new Vector2(GraphicsDeviceManager.DefaultBackBufferWidth / 2 - size.X / 2, GraphicsDeviceManager.DefaultBackBufferHeight / 2 - size.Y / 2);
                    fakeSize = value / 10;
                    sizeT = value;
                }
            }
        }
        public Vector2 position { get; private set; }
        public Vector2 fakeSize { get; private set; }
    }
}
