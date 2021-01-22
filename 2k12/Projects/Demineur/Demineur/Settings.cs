using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demineur
{
    class Settings
    {
        //max 52!!!
        public static OPButton[][] state { get; set; }
        public static int width { get; set; }
        //max 28!!!
        public static int[][] MineCoords { get; set; }
        public static int height { get; set; }
        public static int amountOfMines { get; set; }
        public static int initialXPos { get; set; }
        public static int initialYPos { get; set; }
        public static int AmountOfFlags { get; set; }
        public static int numOfFlaggedMines { get; set; }
        public static System.Drawing.Color FullColor { get; set; }
        public static System.Drawing.Color EmptyColor { get; set; }
        public static System.Drawing.Color FontColor { get; set; }
        public static System.Drawing.Color MineColor { get; set; }
        public static System.Drawing.Font ActualFont { get; set; }
    }
}