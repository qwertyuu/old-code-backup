using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using OpenCvSharp;
using OpenCvSharp.Extensions;

namespace wabcem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadKey(true); 
            Dictionary<char, float> valeurs = new Dictionary<char, float>(){
{'.',0f},{'-',0.03751585f},{',',0.08137692f},{':',0.1281726f},{';',0.2113737f},{'>',0.2619766f},{'<',0.2679252f},
{'=',0.2807741f},{'+',0.2884676f},{'!',0.3012373f},{'*',0.3106757f},{'i',0.3616751f},{'r',0.3673064f},{'7',0.370241f},
{'^',0.3723033f},{'v',0.3889593f},{'c',0.4219544f},{'J',0.4268718f},{'T',0.4422587f},{'?',0.4474142f},{'}',0.4500317f},
{'l',0.4562181f},{'s',0.4656567f},{'[',0.4712085f},{'{',0.4783471f},{')',0.4794573f},{'(',0.4843749f},{'Y',0.4855646f},
{'L',0.4928617f},{'x',0.5084072f},{'t',0.5115005f},{']',0.5220493f},{'C',0.5256979f},{'5',0.5417194f},{'2',0.5452886f},
{'I',0.549889f},{'3',0.5521097f},{'z',0.5561548f},{'F',0.5712246f},{'j',0.5797905f},{'u',0.5814562f},{'1',0.5855805f},
{'V',0.5859773f},{'o',0.5951775f},{'y',0.601602f},{'n',0.6046952f},{'e',0.612389f},{'Z',0.6169097f},{'f',0.6183376f},
{'a',0.6345971f},{'S',0.6388007f},{'A',0.6450666f},{'X',0.6463356f},{'w',0.6467323f},{'4',0.666878f},{'U',0.6851205f},
{'G',0.7025697f},{'E',0.7049491f},{'P',0.7273953f},{'O',0.7409582f},{'K',0.7478585f},{'k',0.7496829f},{'q',0.7699874f},
{'9',0.7753807f},{'6',0.7808533f},{'h',0.7956852f},{'0',0.7982231f},{'d',0.809248f},{'$',0.8159106f},{'p',0.820273f},
{'N',0.826221f},{'M',0.8289971f},{'8',0.8293941f},{'H',0.8313771f},{'m',0.8417671f},{'R',0.8435121f},{'Q',0.8504127f},
{'D',0.8561231f},{'b',0.8691307f},{'W',0.8716688f},{'#',0.8811071f},{'g',0.907519f},{'B',0.9288546f},{'%',0.9394829f},
{'@',0.9725571f},{'&',1f}
};
            //Console.BufferHeight = Console.WindowHeight = 75;
            //Console.BufferWidth = Console.WindowWidth = 133;
            int cWidth = Console.WindowWidth;
            int cHeight = Console.WindowHeight - 1;
            CvCapture cap = Cv.CreateCameraCapture(0);
            Console.CursorVisible = false;
            //StringBuilder sB = new StringBuilder();
            string sB;
            while (true)
            {
                var img = Cv.QueryFrame(cap);
                if (img == null)
                {
                    continue;
                }
                Bitmap bm = BitmapConverter.ToBitmap(img);
                sB = "";
                for (int y = 0; y < cHeight; y++)
                {
                    for (int x = 0; x < cWidth; x++)
                    {
                        Color c = bm.GetPixel(x * bm.Width / cWidth, y * bm.Height / cHeight);
                        float brightness = c.GetBrightness();
                        foreach (var item in valeurs)
                        {
                            if (brightness <= item.Value)
                            {
                                sB += item.Key;
                                break;
                            }
                        }
                    }
                }
                
                Console.SetCursorPosition(0, 0);
                Console.Write(sB);
                //System.Threading.Thread.Sleep(100);
            }
        }
    }
}