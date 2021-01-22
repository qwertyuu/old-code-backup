using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2048
{
    class Case
    {
        public Image texture { get; set; }
        private int _value;
        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                SetTexture(value);
                _value = value;
            }
        }

        private void SetTexture(int value)
        {
            texture = Game.Textures[value];
        }

        public Case(Random rand)
        {
            Value = rand.Next(1, 3) * 2;
        }
        public Case(int value)
        {
            Value = value;
        }
    }
}
