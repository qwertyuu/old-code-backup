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
        public static Point initialPathLocation { get; set; }
        enum toWatch { Up, Left, Down, Right }
        enum toWatch1 { Down, Right, Up, Left }
        public static List<Cell> waypoints = new List<Cell>();
        static List<toWatch> toScan = new List<toWatch>();

        public static Cell[,] Parse(string where)
        {
            waypoints.Clear();
            using (TextReader tReader = new StreamReader(where))
            {
                string[] lines = tReader.ReadToEnd().Replace("\r", "").Split('\n');
                Cell[,] toReturn = new Cell[lines[0].Length, lines.Length];
                for (int y = 0; y < lines.Length; y++)
                {
                    for (int x = 0; x < lines[y].Length; x++)
                    {
                        Cell lol = new Cell((TD.Cell.CellTypes)char.GetNumericValue(lines[y][x]), new Rectangle(x * Cell.size, y * Cell.size, Cell.size, Cell.size));
                        lol.contains = null;
                        toReturn[x, y] = lol;
                    }
                }
                Vector2 scanPosition = Vector2.Zero;
                toWatch direction = toWatch.Right;
                for (int y = 0; y < toReturn.GetLength(0); y++)
                {
                    if (toReturn[0, y].type == Cell.CellTypes.Path)
                    {
                        scanPosition = new Vector2(toReturn[0, y].spacePos.X / Cell.size, toReturn[0, y].spacePos.Y / Cell.size);
                        initialPathLocation = new Point(toReturn[0, y].spacePos.X - Cell.size, toReturn[0, y].spacePos.Y);
                        break;
                    }
                }
                bool endReached = false;
                while (!endReached)
                {
                    toScan.Clear();
                    for (int i = 0; i < 4; i++)
                    {
                        if ((toWatch)i != direction)
                        {
                            toScan.Add((toWatch)Enum.Parse(typeof(toWatch), ((toWatch1)i).ToString()));
                        }
                    }
                    foreach (var item in toScan)
                    {
                        int X = 0;
                        int Y = 0;
                        switch (item)
                        {
                            case toWatch.Up:
                                Y = -1;
                                break;
                            case toWatch.Left:
                                X = -1;
                                break;
                            case toWatch.Down:
                                Y = 1;
                                break;
                            case toWatch.Right:
                                X = 1;
                                break;
                            default:
                                break;
                        }
                        Cell buf0 = toReturn[(int)scanPosition.X, (int)scanPosition.Y];
                        Cell buf1 = buf0;
                        bool skip = false;
                        try
                        {
                            buf1 = toReturn[(int)scanPosition.X + X, (int)scanPosition.Y + Y];
                        }
                        catch (IndexOutOfRangeException)
                        {
                            if (item == toWatch.Right)
                            {
                                endReached = true;
                                waypoints.Add(buf0);
                                break;
                            }
                            else
                            {
                                skip = true;
                            }
                        }
                        if (!skip)
                        {
                            if (buf1.type == Cell.CellTypes.Path)
                            {
                                if (direction != item)
                                {
                                    waypoints.Add(buf0);
                                    direction = item;
                                }
                                scanPosition.X += X;
                                scanPosition.Y += Y;
                                break;
                            }
                        }
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
