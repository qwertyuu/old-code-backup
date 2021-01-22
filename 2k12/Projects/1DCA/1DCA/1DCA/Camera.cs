using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _1DCA
{
    class Camera
    {
        public Matrix viewMatrix;
        int old;
        int diff = 0;

        public void Update(int count, GraphicsDeviceManager graphics)
        {
            //je récupère l'état de la Souris pour savoir l'état de la roulette
            var mouse = Mouse.GetState();
            //avec des mathématiques très poussées, je trouve la différence entre l'ancienne et cette phase
            //ce qui me permet de savoir si je dois Zoomer ou Dézoomer
            diff += mouse.ScrollWheelValue - old;

            if (diff >= 0)
            {
                //je crée la translation nécessaire pour afficher l'image plus grande ou plus petite depuis le centre de l'écran et de l'image
                viewMatrix = Matrix.CreateTranslation(-count / 2, 0, 0) * Matrix.CreateScale((diff + 1000) / 1000f) * Matrix.CreateTranslation(graphics.PreferredBackBufferWidth / 2, 0, 0);
            }
            else
            {
                //si on a trop reculé et bien on laisse la caméra au maximum et on ne bouge plus
                diff = 0;
            }
            //on donne la valeur de la roulette à old pour la prochaine itération
            old = mouse.ScrollWheelValue;
        }
    }
}
