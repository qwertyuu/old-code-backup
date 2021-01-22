using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapMaker
{
    class Camera
    {
        public Matrix viewMatrix;
        public Vector2 position = Vector2.Zero;
        public int mapWidth;
        public int mapHeight;
        const int treshold = 3;
        int speed = 1000;
        int maxX = GraphicsDeviceManager.DefaultBackBufferWidth - treshold;
        int minX = treshold;
        int maxY = GraphicsDeviceManager.DefaultBackBufferHeight - treshold;
        int minY = treshold;

        public void Update(MouseHandler mouse, GameTime gametime)
        {
            if (mouse.position.X > maxX)
                position.X += (float)(speed * gametime.ElapsedGameTime.TotalSeconds);

            else if (mouse.position.X < minX)
                position.X -= (float)(speed * gametime.ElapsedGameTime.TotalSeconds);

            if (mouse.position.Y > maxY)
                position.Y += (float)(speed * gametime.ElapsedGameTime.TotalSeconds);

            else if (mouse.position.Y < minY)
                position.Y -= (float)(speed * gametime.ElapsedGameTime.TotalSeconds);

            if (position.X + GraphicsDeviceManager.DefaultBackBufferWidth >= mapWidth)
                position.X = mapWidth - GraphicsDeviceManager.DefaultBackBufferWidth;

            else if (position.X < 0)
                position.X = 0;

            if (position.Y + GraphicsDeviceManager.DefaultBackBufferHeight >= mapHeight)
                position.Y = mapHeight - GraphicsDeviceManager.DefaultBackBufferHeight;

            else if (position.Y < 0)
                position.Y = 0;

            viewMatrix = Matrix.CreateTranslation(new Vector3(-position, 0));
        }

        public Camera(Grille grid)
        {
            mapWidth = grid.cellules.GetLength(0) * Cell.grosseur;
            mapHeight = grid.cellules.GetLength(1) * Cell.grosseur;
        }
    }
}
