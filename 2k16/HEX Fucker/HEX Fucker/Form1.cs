using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace HEX_Fucker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            gameInfos = ReadFile(@"C:\Users\Paul\Pictures\GameWP\Conker's Bad Fur Day.z64");
        }
        byte[] gameInfos;
        private void button1_Click(object sender, EventArgs e)
        {
            gameInfos = ReadFile(@"C:\Users\Paul\Pictures\GameWP\Conker's Bad Fur Day.z64");
            long start = long.Parse(textBox1.Text, System.Globalization.NumberStyles.HexNumber);
            sbyte? offset = null;
            
            int each = int.Parse(textBox4.Text);
            long end = int.Parse(textBox5.Text, System.Globalization.NumberStyles.HexNumber);
            long pos = start;
            long nbOfModif = 0;
            do
            {
                switch (radioButton1.Checked)
                {
                    case true:
                        if (offset == null)
                        {
                            offset = sbyte.Parse(textBox3.Text);
                        }
                        if (offset >= 0)
                        {
                            gameInfos[pos] += (byte)offset;
                        }
                        else
                        {
                            gameInfos[pos] -= (byte)-offset;
                        }
                        nbOfModif++;
                        break;

                    case false:
                        if (gameInfos[pos].ToString("X") == textBox6.Text)
                        {
                            gameInfos[pos] = byte.Parse(textBox7.Text, System.Globalization.NumberStyles.HexNumber);
                            nbOfModif++;
                        }
                        break;
                }
                pos += each;
            } while (pos < end);
            MessageBox.Show(string.Format("J'ai changé {0} valeurs", nbOfModif));
            WriteFile(gameInfos, @"C:\Users\Paul\Desktop\MODIFIED.z64");
            Process.Start(@"C:\Program Files (x86)\Project64 1.6\Project64.exe", @"C:\Users\Paul\Desktop\MODIFIED.z64");
        }

        private void WriteFile(byte[] gameInfos, string p)
        {
            FileStream fileStream = new FileStream(p, FileMode.Create, FileAccess.Write);
            try
            {
                fileStream.Write(gameInfos, 0, gameInfos.Length);
            }
            finally
            {
                fileStream.Close();
            }
        }
        public byte[] ReadFile(string filePath)
        {
            byte[] buffer;
            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            try
            {
                int length = (int)fileStream.Length;  
                buffer = new byte[length];          
                int count;                            
                int sum = 0;

                while ((count = fileStream.Read(buffer, sum, length - sum)) > 0)
                    sum += count;
            }
            finally
            {
                fileStream.Close();
            }
            return buffer;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            long start = long.Parse(textBox1.Text, System.Globalization.NumberStyles.HexNumber);
            long increment = long.Parse(textBox2.Text);
            textBox1.Text = (start + increment).ToString("X");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            long start = long.Parse(textBox1.Text, System.Globalization.NumberStyles.HexNumber);
            long increment = long.Parse(textBox2.Text);
            textBox1.Text = (start - increment).ToString("X");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox5.Text = gameInfos.Length.ToString("X");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            long start = long.Parse(textBox5.Text, System.Globalization.NumberStyles.HexNumber);
            long increment = long.Parse(textBox2.Text);
            textBox5.Text = (start + increment).ToString("X");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            long start = long.Parse(textBox5.Text, System.Globalization.NumberStyles.HexNumber);
            long increment = long.Parse(textBox2.Text);
            textBox5.Text = (start - increment).ToString("X");
        }
    }
}
