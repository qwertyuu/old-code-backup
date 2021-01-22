using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleRTS
{
    class Program
    {
        static public int GlobalHeight = 26;
        static void Main(string[] args)
        {
            mapTest = new Map(100, 50);
            currentCameraPosition[0] = 50;
            currentCameraPosition[1] = 25;
            Console.WindowHeight = 27;
            Console.WindowWidth = 80;
            Console.CursorVisible = false;
            Thread uInputThread = new Thread(new ParameterizedThreadStart(UInputHandler));
            Thread update = new Thread(new ParameterizedThreadStart(Update));
            uInputThread.IsBackground = true;
            uInputThread.Start();
            update.IsBackground = true;
            update.Start();
            while (!quit)
            {
                if (graphics[10, 10] != null)
                {
                    while (!quit)
                    {
                        StringBuilder line = new StringBuilder();
                        var buffer = graphics;
                        for (int y = 0; y < GlobalHeight; y++)
                        {
                            for (int x = 0; x < Console.WindowWidth; x++)
                            {
                                //Console.ForegroundColor = graphics[x, y].PrintColor;
                                //Console.Write(buffer[x, y].Graphic);
                                line.Append(buffer[x, y].Graphic);
                            }
                            Console.Write(line);
                            line.Clear();
                        }
                        GetKey = true;
                        System.Threading.Thread.Sleep(latency);
                        Console.Clear();
                    }
                }
            }
        
        }

        private static void Update(object obj)
        {
            while (true)
            {
                graphics = mapTest.GetTilesAt(currentCameraPosition, hasMoved);
                for (int i = 0; i < latency.ToString().Length + 1; i++)
                {
                    mapTest.SetTile((mapTest.Width / 2) + i, (mapTest.Height / 2) + 1, (latency.ToString() + (char)0)[i]);
                }
                for (int i = 0; i < hasMoved.Length; i++)
                {
                    hasMoved[i] = 0;
                }
            }
        }
        static int[] currentCameraPosition = new int[2];
        static int[] hasMoved = new int[4];
        static Map mapTest;
        static bool GetKey = false;
        static bool quit = false;
        static int latency = 20;
        static Tile[,] graphics = new Tile[Console.WindowWidth, GlobalHeight];
        private static void UInputHandler(object obj)
        {
            while (true)
            {
                if (GetKey)
                {
                    while (true)
                    {
                        var buffer = Console.ReadKey(true);
                        switch (buffer.Key)
                        {
                            case ConsoleKey.DownArrow:
                                if (currentCameraPosition[1] < mapTest.Height - GlobalHeight / 2)
                                {
                                    //currentCameraPosition[1]++;
                                    hasMoved[3]++;
                                }
                                break;
                            case ConsoleKey.LeftArrow:
                                if (currentCameraPosition[0] > 40)
                                {
                                    //currentCameraPosition[0]--;
                                    hasMoved[2]++;
                                }
                                break;
                            case ConsoleKey.RightArrow:
                                if (currentCameraPosition[0] < 60)
                                {
                                    //currentCameraPosition[0]++;
                                    hasMoved[0]++;
                                }
                                break;
                            case ConsoleKey.UpArrow:
                                if (currentCameraPosition[1] > GlobalHeight / 2)
                                {
                                    //currentCameraPosition[1]--;
                                    hasMoved[1]++;
                                }
                                break;
                            case ConsoleKey.Escape:
                                quit = true;
                                break;
                            case ConsoleKey.Subtract:
                                if (latency > 0)
                                {
                                    latency--;
                                }
                                break;
                            case ConsoleKey.Add:
                                latency++;
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
        }
    }
}
