using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TD
{
    class Camera
    {
        public Matrix viewMatrix;
        public Vector2 position = Vector2.Zero;
        public int mapWidth;
        public int mapHeight;
        const int treshold = 3;
        public static int speed = 1000;
        int maxX = GraphicsDeviceManager.DefaultBackBufferWidth - treshold;
        int minX = treshold;
        int maxY = GraphicsDeviceManager.DefaultBackBufferHeight - treshold;
        int minY = treshold;

        public void Update(MouseHandler mouse, GameTime gametime, InGameUI uI)
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

            if (position.Y + (GraphicsDeviceManager.DefaultBackBufferHeight - uI.textBounds[0].Height) >= mapHeight)
                position.Y = mapHeight - (GraphicsDeviceManager.DefaultBackBufferHeight - uI.textBounds[0].Height);

            else if (position.Y < 0)
                position.Y = 0;

            viewMatrix = Matrix.CreateTranslation(new Vector3(-position, 0));
        }

        public Camera()
        {
            mapWidth = Map.map.GetLength(0) * Cell.size;
            mapHeight = Map.map.GetLength(1) * Cell.size;
        }
    }
}
