using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace AuPireCriss
{
    class Creep : Printable
    {
        public int HP { get; set; }
        public int damage { get; set; }
        public int speed { get; set; }

        public Creep(Rectangle pos, int HP)
        {
            this.Pos = pos;
        }
    }
}
