using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Serialization;

namespace TD
{
    class Cell
    {
        public enum CellTypes {Rock, Path, Turret};
        public Tower contains { get; set; }
        public static int size = 15;
        public Rectangle spacePos;
        public CellTypes type;

        public static Cell[,] Parse(string pathToLevel)
        {
            using (TextReader tReader = new StreamReader(pathToLevel))
            {
                string[] lines = tReader.ReadToEnd().Replace("\r", "").Split('\n');
                Cell[,] toReturn = new Cell[lines[0].Length, lines.Length];
                for (int y = 0; y < lines.Length; y++)
                {
                    for (int x = 0; x < lines[y].Length; x++)
                    {
                        CellTypes cellType = (CellTypes)int.Parse(lines[y][x].ToString());
                        toReturn[x, y] = new Cell(cellType, new Rectangle(x * size, y * size, size, size));
                    }
                }

                return toReturn;
            }
        }

        public Cell(CellTypes _type, Rectangle _spacePos)
        {
            type = _type;
            contains = null;
            spacePos = _spacePos;
        }
    }
}
