using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth
{
    class Program
    {
        enum Directions
        {
            Top,
            Right,
            Bottom,
            Left
        }
        static void Main(string[] args)
        {
            Directions before = Directions.Right;
            Random rand = new Random();
            Console.ReadKey(true);
            bool[,] state = new bool[Console.WindowWidth, Console.WindowHeight];
            bool exit = false;
            Directions direction = Directions.Right;
            int[] position = { 0, 10 };
            int sameDir = 0;
            Directions turned = Directions.Right;
            while (!exit)
            {
                state[position[0], position[1]] = true;
                switch (direction)
                {
                    case Directions.Top:
                        position[1]--;
                        break;
                    case Directions.Right:
                        position[0]++;
                        break;
                    case Directions.Bottom:
                        position[1]++;
                        break;
                    case Directions.Left:
                        position[0]--;
                        break;
                }
                List<Directions> canGo = new List<Directions>();
                if (position[1] > 1 && before != Directions.Bottom && direction != Directions.Bottom)
                {
                    if (sameDir == 2)
                    {
                        if (direction == Directions.Right && turned != Directions.Left)
                        {
                             canGo.Add(Directions.Top);
                        }
                        else if (direction == Directions.Left && turned != Directions.Right)
                        {
                             canGo.Add(Directions.Top);
                        }
                        else
                        {
                            if (position[1] - 2 > 0)
                            {
                                if (!state[position[0], position[1] - 2])
                                {
                                    canGo.Add(Directions.Top);
                                }
                            }
                            else
                            {
                                canGo.Add(Directions.Top);
                            }
                        }
                    }
                    else
                    {
                        if (position[1] - 2 > 0)
                        {
                            if (!state[position[0], position[1] - 2])
                            {
                                canGo.Add(Directions.Top);
                            }
                        }
                        else
                        {
                            canGo.Add(Directions.Top);
                        }
                    }
                }
                if (position[1] < state.GetLength(1) - 1 && before != Directions.Top && direction != Directions.Top)
                {
                    if (sameDir == 2)
                    {
                        if (direction == Directions.Left && turned != Directions.Right)
                        {
                            canGo.Add(Directions.Bottom);
                        }
                        else if (direction == Directions.Right && turned != Directions.Left)
                        {
                            canGo.Add(Directions.Bottom);
                        }
                        else
                        {
                            if (position[1] + 2 < state.GetLength(1))
                            {
                                if (!state[position[0], position[1] + 2])
                                {
                                    canGo.Add(Directions.Bottom);
                                }
                            }
                            else
                            {
                                canGo.Add(Directions.Bottom);
                            }
                        }
                    }
                    else
                    {
                        if (position[1] + 2 < state.GetLength(1))
                        {
                            if (!state[position[0], position[1] + 2])
                            {
                                canGo.Add(Directions.Bottom);
                            }
                        }
                        else
                        {
                            canGo.Add(Directions.Bottom);
                        }
                    }
                }
                if (before != Directions.Left && direction != Directions.Left)
                {
                    if (sameDir == 2)
                    {
                        if (direction == Directions.Top && turned != Directions.Right)
                        {
                            canGo.Add(Directions.Right);
                        }
                        else if (direction == Directions.Bottom && turned != Directions.Left)
                        {
                            canGo.Add(Directions.Right);
                        }
                        else
                        {
                            if (position[0] + 2 < state.GetLength(0))
                            {
                                if (!state[position[0] + 2, position[1]])
                                {
                                    canGo.Add(Directions.Right);
                                }
                            }
                            else
                            {
                                canGo.Add(Directions.Right);
                            }
                        }
                    }
                    else
                    {
                        if (position[0] + 2 < state.GetLength(0))
                        {
                            if (!state[position[0] + 2, position[1]])
                            {
                                canGo.Add(Directions.Right);
                            }
                        }
                        else
                        {
                            canGo.Add(Directions.Right);
                        }
                    }
                }
                if (position[0] > 1 && before != Directions.Right && direction != Directions.Right)
                {
                    if (sameDir == 2)
                    {
                        if (direction == Directions.Top && turned != Directions.Left)
                        {
                            canGo.Add(Directions.Left);
                        }
                        else if (direction == Directions.Bottom && turned != Directions.Right)
                        {
                            canGo.Add(Directions.Left);
                        }
                        else
                        {
                            if (position[0] - 2 > 0)
                            {
                                if (!state[position[0] - 2, position[1]])
                                {
                                    canGo.Add(Directions.Left);
                                }
                            }
                            else
                            {
                                canGo.Add(Directions.Left);
                            }
                        }
                    }
                    else
                    {
                        if (position[0] - 2 > 0)
                        {
                            if (!state[position[0] - 2, position[1]])
                            {
                                canGo.Add(Directions.Left);
                            }
                        }
                        else
                        {
                            canGo.Add(Directions.Left);
                        }
                    }
                }
                if (direction != before)
                {
                    before = direction;
                }
                if (canGo.Count == 0)
                {
                    break;
                }
                direction = canGo[rand.Next(canGo.Count)];
                if (before != direction)
                {
                    switch (direction)
                    {
                        case Directions.Top:
                            if (before == Directions.Left)
                            {
                                if (turned == Directions.Right)
                                {
                                    sameDir++;
                                }
                                else
                                {
                                    sameDir = 0;
                                }
                                turned = Directions.Right;
                            }
                            else
                            {
                                if (turned == Directions.Left)
                                {
                                    sameDir++;
                                }
                                else
                                {
                                    sameDir = 0;
                                }
                                turned = Directions.Left;
                            }
                            break;
                        case Directions.Right:
                            if (before == Directions.Top)
                            {
                                if (turned == Directions.Right)
                                {
                                    sameDir++;
                                }
                                else
                                {
                                    sameDir = 0;
                                }
                                turned = Directions.Right;
                            }
                            else
                            {
                                if (turned == Directions.Left)
                                {
                                    sameDir++;
                                }
                                else
                                {
                                    sameDir = 0;
                                }
                                turned = Directions.Right;
                            }
                            break;
                        case Directions.Bottom:
                            if (before == Directions.Left)
                            {
                                if (turned == Directions.Left)
                                {
                                    sameDir++;
                                }
                                else
                                {
                                    sameDir = 0;
                                }
                                turned = Directions.Left;
                            }
                            else
                            {
                                if (turned == Directions.Right)
                                {
                                    sameDir++;
                                }
                                else
                                {
                                    sameDir = 0;
                                }
                                turned = Directions.Right;
                            }
                            break;
                        case Directions.Left:
                            if (before == Directions.Top)
                            {
                                if (turned == Directions.Left)
                                {
                                    sameDir++;
                                }
                                else
                                {
                                    sameDir = 0;
                                }
                                turned = Directions.Left;
                            }
                            else
                            {
                                if (turned == Directions.Right)
                                {
                                    sameDir++;
                                }
                                else
                                {
                                    sameDir = 0;
                                }
                                turned = Directions.Right;
                            }
                            break;
                    }
                }
                if (position[0] == state.GetLength(0))
                {
                    exit = true;
                }
            }
            StringBuilder a = new StringBuilder();
            for (int i = 0; i < state.GetLength(1); i++)
            {
                for (int j = 0; j < state.GetLength(0); j++)
                {
                    Console.Write(!state[j, i] ? ' ' : '#');
                }
            }
            Console.ReadKey(true);
            Main(args);
        }
    }
}
