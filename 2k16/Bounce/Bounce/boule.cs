using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bounce
{
    class boule
    {
        public double posX { get; set; }
        public double posY { get; set; }
        public double SpeedX { get; set; }
        public double SpeedY { get; set; }
        public double accY { get; set; }
        public double Friction { get; set; }

        public boule(Random rnd, int width, int height)
        {
            Friction = 0.05;
            SpeedX = rnd.NextDouble() * 3 + 1;
            if (rnd.NextDouble() > 0.5)
            {
                SpeedX = -SpeedX;
            }
            SpeedY = rnd.NextDouble();
            accY = 0.2;
            posX = rnd.Next(width);
            posY = rnd.Next(height);
        }

        public int Update(int width, int height)
        {
            SpeedY += accY;
            posX += SpeedX;
            posY += SpeedY;
            if (posX > width - 1)
            {
                SpeedX -= Friction * SpeedX;
                SpeedX = -SpeedX;
                posX = width + SpeedX;
            }
            else if (posX < 0)
            {
                SpeedX = -SpeedX;
                SpeedX -= Friction * SpeedX;
                posX = SpeedX;
            }
            else if (Math.Abs(SpeedX) < 0.001)
            {
                SpeedX = 0;
            }
            if (posY > height - 1)
            {
                if (Math.Abs(SpeedY) < 0.01)
                {
                    SpeedY = 0;
                    SpeedX = 0;
                    accY = 0;
                }
                else
                {
                    SpeedY -= Friction * SpeedY;
                    SpeedY = -SpeedY;
                    posY = height + SpeedY;
                }
            }
            else if (posY < 0)
            {
                SpeedY = -SpeedY;
                SpeedY -= Friction * SpeedY;
                posY = SpeedY;
            }
            int check = (int)posY * width + (int)posX;
            int max = width * height - 2;
            if (max < check)
            {
                return max;
            }
            return check;
        }
    }
}
