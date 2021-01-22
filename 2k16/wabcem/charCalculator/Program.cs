using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace charCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Bitmap img = (Bitmap)Bitmap.FromFile("charset.png");
            Dictionary<char, float> valeurs = new Dictionary<char, float>();
            char[] caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*(){}[]:;?<>-+=.,".ToCharArray();
            int width = 8;
            int height = 14;
            for (int i = 0; i < caracteres.Length; i++)
            {
                int offX = (i % 26) * width;
                int offY = (i / 26) * height;
                float totalBrightness = 0;
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        totalBrightness += img.GetPixel(x + offX, y + offY).GetBrightness();
                    }
                }
                valeurs.Add(caracteres[i], ConvertRange(0.02829132f, 0.2490196f, 0, 1, totalBrightness / 112.0f));
            }
            var sortedDict = from entry in valeurs orderby entry.Value ascending select entry;
            Console.WriteLine("Dictionary<char, float> valeurs = new Dictionary<char, float>(){");
            foreach (var item in sortedDict)
            {
                Console.WriteLine("{'" + item.Key + "'," + item.Value.ToString().Replace(',', '.') + "f},");
            }
            Console.WriteLine("};");
            Console.ReadKey(true);
        }


        public static float ConvertRange(
            float originalStart, float originalEnd, // original range
            float newStart, float newEnd, // desired range
            float value) // value to convert
        {
            double scale = (double)(newEnd - newStart) / (originalEnd - originalStart);
            return (float)(newStart + ((value - originalStart) * scale));
        }


    }
}
