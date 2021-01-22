using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Glitcher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            rand = new Random();
        }

        byte[] leFichier;
        Random rand;
        private void button1_Click(object sender, EventArgs e)
        {
            leFichier = File.ReadAllBytes("space.jpg");

            //using (MemoryStream mS = new MemoryStream(leFichier))
            //{
            //    pictureBox1.Image = Image.FromStream(mS, false, false);
            //}
            FuckUp(leFichier);
        }

        private void FuckUp(byte[] _leFichier)
        {
            List<byte> leFuckUp = new List<byte>((byte[])_leFichier.Clone());
            for (int i = 0; i < rand.Next(1, 500); i++)
            {
                if (rand.NextDouble() > 0.5)
                {
                    //leFuckUp[rand.Next(leFuckUp.Count)] += (byte)(rand.Next(byte.MaxValue * 2) - byte.MaxValue);
                }
                if (rand.NextDouble() > 0.9)
                {
                    int index = rand.Next(leFuckUp.Count);
                    int length = rand.Next(1, leFuckUp.Count / 100);
                    while (length + index >= leFuckUp.Count)
                    {
                        length = rand.Next(1, leFuckUp.Count / 100);
                    }
                    leFuckUp.RemoveRange(index, length);
                }
            }
            for (int i = 3000; i < leFuckUp.Count; i++)
            {
                if (rand.NextDouble() > 0.9998)
                {
                    leFuckUp[i] &= 127;
                }
            }
            byte[] temp = leFuckUp.ToArray();
            File.WriteAllBytes("toOpen.jpg", temp);
            Process.Start("toOpen.jpg");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FuckUp(leFichier);
        }
    }
}
