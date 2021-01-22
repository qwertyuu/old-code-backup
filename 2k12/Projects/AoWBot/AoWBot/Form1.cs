using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AoWBot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            t = new System.Threading.Thread(DoThis);
            t.IsBackground = true;
        }
        System.Threading.Thread t;
        /* 1142, 283: premier menu et 1er character
         * 1191, 278: 2ieme character
         * 1245, 274: 3ieme
         * 1362, 279: retour
         * 1331, 278: lvl up */
        private void DoThis()
        {
            Point old = new Point();
            while (true)
            {
                while (int.Parse(axShockwaveFlash1.GetVariable("cash")) >= 15)
                {
                    old = Cursor.Position;
                    Cursor.Position = new Point(1142, 283);
                    DoMouseClick();
                    System.Threading.Thread.Sleep(100);
                    Cursor.Position = old;
                }
            }
        }
        bool click = true;
        [DllImport("user32.dll", CharSet = CharSet.Auto, CallingConvention = CallingConvention.StdCall)]
        public static extern void mouse_event(uint dwFlags, uint dx, uint dy, uint cButtons, uint dwExtraInfo);

        private const int MOUSEEVENTF_LEFTDOWN = 0x02;
        private const int MOUSEEVENTF_LEFTUP = 0x04;
        private const int MOUSEEVENTF_RIGHTDOWN = 0x08;
        private const int MOUSEEVENTF_RIGHTUP = 0x10;

        public void DoMouseClick()
        {
            mouse_event(MOUSEEVENTF_LEFTDOWN | MOUSEEVENTF_LEFTUP, (uint)Cursor.Position.X, (uint)Cursor.Position.Y, 0, 0);
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
        }

        private List<List<object>> GenerateList(string p)
        {
            List<List<object>> toReturn = new List<List<object>>();
            string[] a = p.Split(',');
            int index = -1;
            int inout;
            foreach (var item in a)
            {
                if (!(item == null || item == string.Empty))
                {
                    if (int.TryParse(item, out inout))
                    {
                        toReturn[index].Add(inout);
                    }
                    else
                    {
                        toReturn.Add(new List<object>());
                        index++;
                        toReturn[index].Add(item);
                    }
                }
            }
            return toReturn;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<List<object>> characters = GenerateList(axShockwaveFlash1.GetVariable("EN"));
            List<List<object>> turrets = GenerateList(axShockwaveFlash1.GetVariable("TU"));
            t.Start();
            click = true;
        }

        private void axShockwaveFlash1_MouseCaptureChanged(object sender, EventArgs e)
        {
            textBox1.Text = Cursor.Position.X + ", " + Cursor.Position.Y;
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            click = false;
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            click = false;
        }

    }
}
