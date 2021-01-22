using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dynamic_Binary_
{
    class Program
    {
        static void Main(string[] args)
        {
            bool quit = false;
            while (!quit)
            {
                Console.WriteLine("1: ToBinary, 2: FromBinary");
                Console.WriteLine(UInt64.MaxValue);
                switch (Console.ReadLine())
                {
                    case "1":
                        ToBinary();
                        break;
                    case "2":
                        FromBinary();
                        break;
                    case "0":
                        quit = true;
                        break;
                    default:
                        break;
                }
            }
        }

        private static void FromBinary()
        {
            var timerStart = DateTime.Now;
            bool[] bytes = new bool[0];
            try
            {
                bytes = Binary.Parse(Console.ReadLine());
            }
            catch (OverflowException c)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(c.Message);
                Console.ResetColor();
            }
            UInt64 len = (UInt64)bytes.Length;
            UInt64 max = (UInt64)Math.Pow(2, len - 1);
            UInt64 val = 0;
            foreach (bool bit in bytes)
            {
                switch (bit)
                {
                    case true:
                        val += max;
                        break;
                    default:
                        break;
                }
                max /= 2;
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(val);
            Console.ResetColor();
            Console.WriteLine("Temps:" + (DateTime.Now - timerStart).Milliseconds + " ms");
        }

        private static void ToBinary()
        {
            var timerStart = DateTime.Now;
            UInt64 uInput = UInt64.Parse(Console.ReadLine());
            UInt64 neededSize = DetectSize(uInput);
            UInt64 maxValue = (UInt64)Math.Pow(2, neededSize - 1);
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            for (UInt64 i = 0; i < neededSize; i++)
            {
                if (maxValue <= uInput)
                {
                    uInput -= maxValue;
                    Console.Write('1');
                }
                else
                {
                    Console.Write('0');
                }
                maxValue /= 2;
            }
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Temps:" + (DateTime.Now - timerStart).Milliseconds + " ms");
        }


        private static UInt64 DetectSize(UInt64 uInput)
        {
            UInt64 bits = 1;
            UInt64 size = (UInt64)Math.Pow(2, bits) - 1;
            while (uInput > size)
            {
                bits++;
                size = (UInt64)Math.Pow(2, bits) - 1;
            }
            return bits;
        }
    }
    class Binary
    {
        internal static bool[] Parse(string p)
        {
            bool[] b = new bool[p.Length];
            int index = 0;
            foreach (char c in p)
            {
                if (c != '1' && c != '0')
                {
                    throw new OverflowException("Not Binary");
                }
                else
                {
                    b[index] = ToBinary(c);
                }
                index++;
            }
            return b;
        }

        private static bool ToBinary(char c)
        {
            switch (c)
            {
                case '1':
                    return true;
                case '0':
                    return false;
            }
            return false;
        }
    }
}
