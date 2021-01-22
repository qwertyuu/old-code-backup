using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab4_Heritage_Pt2
{
    class Point
    {
        private double _x;

        public double X
        {
            get { return _x; }
            set
            {
                int w = 0;
                if (value < 0) this._x = 0;

                else if (value > (w = Console.WindowWidth - 1)) this._x = w;

                else this._x = value;
            }
        }


        private double _y;

        public double Y
        {
            get { return _y; }
            set
            {
                int h = 0;
                if (value < 0) this._y = 0;

                else if (value > (h = Console.WindowHeight - 2)) this._y = h;

                else this._y = value;
            }
        }


        public Point()
        {
            this.X = 0;
            this.Y = 0;
        }

        public Point(double _x, double _y)
        {
            this.X = _x;
            this.Y = _y;
        }

        public void ReglerPosition(Point _pos)
        {
            this.X = _pos.X;
            this.Y = _pos.Y;
        }

        public void AvancerSelonAngleEtDistance(double _angle, double _distance)
        {
            double deltaX = Math.Cos(_angle) * _distance;
            double deltaY = Math.Sin(_angle) * _distance;
            X += deltaX;
            Y += deltaY;
        }

        public static double AngleEntre(Point _origine, Point _but)
        {
            return Math.Atan2(_origine.Y - _but.Y, _origine.X - _but.X) + Math.PI;
        }

        public static double Distance(Point _premierElement, Point _deuxiemeElement)
        {
            double tempX = _premierElement.X - _deuxiemeElement.X;
            double tempY = _premierElement.Y - _deuxiemeElement.Y;
            return tempX * tempX + tempY * tempY;
        }
    }
}
