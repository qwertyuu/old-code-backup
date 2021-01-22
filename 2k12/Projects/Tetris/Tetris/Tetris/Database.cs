using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tetris
{
    public enum Rotations { Right, Down, Left, Up }
    public enum BlocTypes { Sleft, Sright, T, I, Lleft, Lright }
    class Database
    {
        public List<Vector2> Layouts(int index)
        {
            return new List<Vector2>(layouts[index]);
        }
        public int count
        {
            get
            {
                return layouts.Count;
            }
        }
        private List<List<Vector2>> layouts =
            new List<List<Vector2>>()
            {
                new List<Vector2>() {new Vector2(-10, 0), new Vector2(0, 10), new Vector2(10, 10)},
                new List<Vector2>() {new Vector2(10, 0), new Vector2(0, 10), new Vector2(-10, 10)},
                new List<Vector2>() {new Vector2(-10, 0), new Vector2(10, 0), new Vector2(0, 10)},
                new List<Vector2>() {new Vector2(0, -10), new Vector2(0, 10), new Vector2(0, -20)},
                new List<Vector2>() {new Vector2(0, -10), new Vector2(0, 10), new Vector2(-10, 10)},
                new List<Vector2>() {new Vector2(0, -10), new Vector2(0, 10), new Vector2(10, 10)},
                new List<Vector2>() {new Vector2(-20, 0), new Vector2(-10, 0), new Vector2(10, 0)}
            };
    }
}
