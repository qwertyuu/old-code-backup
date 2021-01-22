using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuPireCriss
{
    class Hero : Printable
    {
        public int damage { get; set; }
        public int HP { get; set; }
        public int level { get; set; }
        

        public Hero(System.Drawing.Rectangle rectangle, int p)
        {
            this.Pos = rectangle;
            this.HP = p;
            level = 1;
        }
        public void levelup()
        {
            damage += 5;
            HP += 10;
            level++;
        }
    }
}
