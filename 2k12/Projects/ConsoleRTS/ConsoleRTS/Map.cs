using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleRTS
{
    class Map
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public Map()
        {

        }
        public Map(int width, int height)
        {
            this.Height = height;
            this.Width = width;
            Tiles = new Tile[width, height];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Tiles[x, y] = new Tile();
                }
            }
            bool aOrB = true;
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    if (x % 4 == 0 && y % 4 == 0)
                    {
                        Tiles[x, y].Graphic = aOrB ? 'A' : 'B';
                        Tiles[x, y].PrintColor = ConsoleColor.Cyan;
                        aOrB = !aOrB;
                    }
                }
            }
            for (int y = 0; y < height; y++)
            {
                if (y == 0 || y == height - 1)
                {
                    for (int x = 0; x < width; x++)
                    {
                        Tiles[x, y].Graphic = '@';
                        Tiles[x, y].PrintColor = ConsoleColor.DarkGray;
                    }
                }
                else
                {
                    Tiles[0, y].Graphic = '@';
                    Tiles[0, y].PrintColor = ConsoleColor.DarkGray;
                    Tiles[width - 1, y].Graphic = '@';
                    Tiles[width - 1, y].PrintColor = ConsoleColor.DarkGray;
                }
            }
        }
        public Tile[,] Tiles { get; set; }

        internal Tile[,] GetTilesAt(int[] currentCameraPosition, int[] hasMoved)
        {
            Tile[,] toReturn = new Tile[Console.WindowWidth, Program.GlobalHeight];
            int maxY = currentCameraPosition[1] + (Program.GlobalHeight / 2);
            int maxX = currentCameraPosition[0] + (Console.WindowWidth / 2);
            int minY = currentCameraPosition[1] - (Program.GlobalHeight / 2);
            int minX = currentCameraPosition[0] - (Console.WindowWidth / 2);
            int indepX = 0;
            int indepY = 0;
            for (int y = minY; y < maxY; y++)
            {
                for (int x = minX; x < maxX; x++)
                {
                    toReturn[indepX, indepY] = new Tile();
                    toReturn[indepX, indepY] = Tiles[x, y];
                    indepX++;
                }
                indepX = 0;
                indepY++;
            }
            currentCameraPosition[0] += (hasMoved[0] - hasMoved[2]);
            currentCameraPosition[1] += (hasMoved[3] - hasMoved[1]);
            return toReturn;
        }

        internal void SetTile(int x, int y, char toChange)
        {
            Tiles[x, y].Graphic = toChange;
        }
    }
}
