using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MATRIX_MUCH
{
    class Matrix
    {
        List<Line> lines;
        Random rand;
        char[][] a;
        public Matrix(Random _rand)
        {
            lines = new List<Line>();
            rand = _rand;
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                lines.Add(new Line(rand, i, true));
            }
        }
        public void Update()
        {
            for (int i = 0; i < lines.Count; i++)
            {
                var line = lines[i];
                line.Update();
                if (line.Y == Console.WindowHeight)
                {
                    lines.Remove(line);
                    i--;
                }
                else if (line.Y == 0)
                {
                    lines.Add(new Line(rand, line.X));
                }
            }
        }

        public string Get()
        {
            a = new char[Console.WindowHeight - 1][];
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = new char[Console.WindowWidth];
            }
            foreach (var item in lines)
            {
                item.CheckYourself(a);
            }
            StringBuilder sB = new StringBuilder();
            for (int i = 0; i < a.Length; i++)
            {
                sB.Append(new string(a[i]));
            }
            return sB.ToString();
        }
    }
}
