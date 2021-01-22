using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageToBits
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            hScrollBar1.Value = (int)(thress * 1000);
            label1.Text = thress.ToString();
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog1.FileName;
                image = new Bitmap(openFileDialog1.FileName);
                Draw(image, thress, thress1);
            }
        }
        private Bitmap image;
        public double thress1 = 0.5;
        private double thress = 0.5;
        private void Draw(Bitmap a, double thres, double thres1)
        {
            StringBuilder r = new StringBuilder();
            for (int i = 0; i < a.Height; i++)
            {
                for (int j = 0; j < a.Width; j++)
                {
                    Color c = a.GetPixel(j, i);
                    var q = c.GetBrightness();
                    if (q > thres)
                    {
                        r.Append('~');
                    }
                    else if(q > thres1)
                    {
                        r.Append('!');
                    }
                    else
                    {
                        r.Append('_');
                    }
                }
                r.Append(Environment.NewLine);
            }
            richTextBox1.Text = r.ToString();
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            thress = (double)e.NewValue / 1000;
            label1.Text = thress.ToString();
            if (image != null)
            {
                Draw(image, thress, thress1);
            }
        }

        private void hScrollBar2_Scroll(object sender, ScrollEventArgs e)
        {
            if (image != null)
            {
                image = new Bitmap(openFileDialog1.FileName);
                Bitmap result = new Bitmap((int)((double)image.Width * ((double)e.NewValue / 100)), (int)((double)image.Height * ((double)e.NewValue / 100)));
                using (Graphics g = Graphics.FromImage((Image)result))
                    g.DrawImage(image, 0, 0, result.Width, result.Height);
                image = result;
                Draw(image, thress, thress1);
            }
        }

        private void hScrollBar3_Scroll(object sender, ScrollEventArgs e)
        {
            thress1 = (double)e.NewValue / 1000;
            if (image != null)
            {
                Draw(image, thress, thress1);
            }
        }


    }
}
