using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MapMaker
{
    class Grille
    {
        public Cell[,] cellules;
        public Grille(int width, int height)
        {
            cellules = new Cell[width, height];
            for (int i = 0; i < cellules.GetLength(0); i++)
            {
                for (int j = 0; j < cellules.GetLength(1); j++)
                {
                    cellules[i,j] = new Cell(j, i);
                }
            }
        }
        public static Grille Parse(Texture2D toParse)
        {
            Grille toReturn = new Grille(toParse.Width, toParse.Height);
            Color[] colorData = new Color[toParse.Width * toParse.Height];
            toParse.GetData(colorData);
            for (int j = 0; j < toParse.Width; j++)
            {
                for (int i = 0; i < toParse.Height; i++)
                {
                    var buf = colorData[j + i * toParse.Width];
                    if (buf == Color.White)
                    {
                        toReturn.cellules[j, i] = new Cell(j, i);
                        toReturn.cellules[j, i].chiffre = 1;
                        toReturn.cellules[j, i].couleur = buf;
                        toReturn.cellules[j, i].kind = Cell.Kind.Creep;
                    }
                    else if (buf == Color.Lime)
                    {
                        toReturn.cellules[j, i] = new Cell(j, i);
                        toReturn.cellules[j, i].chiffre = 2;
                        toReturn.cellules[j, i].couleur = Color.Green;
                        toReturn.cellules[j, i].kind = Cell.Kind.Turret;
                    }
                    else if (buf == Color.Red)
                    {
                        toReturn.cellules[j, i] = new Cell(j, i);
                        toReturn.cellules[j, i].chiffre = 0;
                        toReturn.cellules[j, i].couleur = buf;
                        toReturn.cellules[j, i].kind = Cell.Kind.Rock;
                    }
                }
            }
            return toReturn;

        }
        public void Draw(SpriteBatch sprite)
        {
            foreach (var item in cellules)
            {
                item.Draw(sprite);
            }
        }
    }
}
