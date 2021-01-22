using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowWidth = 260;
            Random r = new Random();
            int[] toMerge = new int[25];
            for (int i = 0; i < toMerge.Length; i++)
            {
                toMerge[i] = r.Next(10, 100);
            }
            int[] merged = merge(toMerge, 0);

            Console.ReadKey(true);
        }
        static int[] merge(int[] toSort, int depth)
        {
            Console.Write(new string(' ', depth * 3));
            foreach (var item in toSort)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            System.Threading.Thread.Sleep(100);
            if (toSort.Length == 1)
            {
                return toSort;
            }
            int halfLength = toSort.Length / 2;
            int[] left = merge(SubArray(toSort, 0, halfLength), depth);
            int[] right = merge(SubArray(toSort, halfLength, toSort.Length - halfLength), depth + left.Length);
            int[] final = new int[toSort.Length];
            int leftIndex = 0;
            int rightIndex = 0;
            for (int i = 0; i < toSort.Length; i++)
            {
                if (leftIndex == left.Length)
                {
                    final[i] = right[rightIndex];
                    rightIndex++;
                    continue;
                }
                else if (rightIndex == right.Length)
                {
                    final[i] = left[leftIndex];
                    leftIndex++;
                    continue;
                }
                if (left[leftIndex] < right[rightIndex])
                {
                    final[i] = left[leftIndex];
                    leftIndex++;
                }
                else
                {
                    final[i] = right[rightIndex];
                    rightIndex++;
                }
            }
            Console.Write(new string(' ', depth * 3));
            foreach (var item in final)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            System.Threading.Thread.Sleep(100);
            return final;
        }
        static int[] SubArray(int[] data, int index, int length)
        {
            int[] result = new int[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }
    }
}
