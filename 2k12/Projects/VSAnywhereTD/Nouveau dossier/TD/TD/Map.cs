using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace TD
{
    class Map
    {
        public static Cell[,] map { get; set; }

        public static Cell[,] Parse(string where)
        {
            using (TextReader tReader = new StreamReader(where))
            {
                string[] lines = tReader.ReadToEnd().Replace("\r", "").Split('\n');
                Cell[,] toReturn = new Cell[lines[0].Length, lines.Length];
                for (int y = 0; y < lines.Length; y++)
                {
                    for (int x = 0; x < lines[y].Length; x++)
                    {
                        TD.Cell.CellTypes cellType = (TD.Cell.CellTypes)int.Parse(lines[y][x].ToString());
                        Cell lol = new Cell(cellType, new Rectangle(x * Cell.size, y * Cell.size, Cell.size, Cell.size));
                        lol.contains = null;
                        toReturn[x, y] = lol;
                    }
                }

                return toReturn;
            }
        }

        public Map(string mapToParse)
        {
            map = Parse(mapToParse);
            
        }
    }
}
