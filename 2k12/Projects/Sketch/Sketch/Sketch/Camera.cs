using Microsoft.Xna.Framework;

namespace Sketch
{
    class Camera
    {
        Vector2 position;
        Matrix viewMatrix;
        public Matrix ViewMatrix
        {
            get { return viewMatrix; }
        }
        public void Update(Player joueur)
        {
            position.X = (joueur.position.X + joueur.texture.Width / 2) - (GraphicsDeviceManager.DefaultBackBufferWidth / 2);
            position.Y = (joueur.position.Y + joueur.texture.Height / 2) - GraphicsDeviceManager.DefaultBackBufferHeight;
            if (position.X < 0)
            {
                position.X = 0;
            }
            if (position.Y < 0)
            {
                position.Y = 0;
            }
            viewMatrix = Matrix.CreateTranslation(new Vector3(-position, 0));
        }
    }
}
