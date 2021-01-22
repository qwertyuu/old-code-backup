using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MATRIX_MUCH
{
    class Line
    {
        public int length { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int spaceLength { get; set; }
        public int lineLength { get; set; }
        public bool[] WHATDOILOOKLIKE { get; set; }
        public char[] LES_ÉCREVISSES { get; set; }
        Random rand;
        public Line(Random _rand, int _X, bool addOffset = false)
        {
            lineLength = _rand.Next(4, Console.WindowHeight - 1);
            spaceLength = _rand.Next(Console.WindowHeight / 2, Console.WindowHeight);
            rand = _rand;
            length = lineLength + spaceLength;
            this.X = _X;
            Y = -length;
            if (addOffset)
            {
                Y -= _rand.Next(100);
            }
            GenerateMeAndMyFriend();
        }

        private void GenerateMeAndMyFriend()
        {
            WHATDOILOOKLIKE = new bool[length];
            for (int i = spaceLength; i < WHATDOILOOKLIKE.Length; i++)
            {
                WHATDOILOOKLIKE[i] = true;
            }
            LES_ÉCREVISSES = new char[Console.WindowHeight - 1];
            for (int i = 0; i < LES_ÉCREVISSES.Length; i++)
            {
                LES_ÉCREVISSES[i] = (char)rand.Next(33, 127);
            }
        }
        public void Update()
        {
            Y++;
        }


        internal void CheckYourself(char[][] a)
        {
            int currentPos;
            for (int i = 0; i < WHATDOILOOKLIKE.Length; i++)
            {
                currentPos = this.Y + i;
                if (currentPos >= 0 && currentPos < a.Length && WHATDOILOOKLIKE[i])
                {
                    a[currentPos][this.X] = LES_ÉCREVISSES[currentPos];
                }
            }
        }
    }
}
