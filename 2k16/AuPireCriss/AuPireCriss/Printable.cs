using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace AuPireCriss
{
    class Printable
    {
        public Image texture { get; set; }
        public Rectangle Pos { get; set; }
        public void Print(Graphics gr)
        {
            gr.DrawImage(texture, Pos);
        }
    }
}