using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4WebM
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        string fichier;
        string debut;
        double debutTemps;
        string fin;
        double finTemps;
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fichier = openFileDialog1.FileName;
                axWindowsMediaPlayer1.URL = fichier;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double position = axWindowsMediaPlayer1.Ctlcontrols.currentPosition;
            debutTemps = position;
            debut = ((int)(position / 3600)).ToString().PadLeft(2, '0') + ':' +
                ((int)((position / 60) % 60)).ToString().PadLeft(2, '0') + ':' +
                ((int)(position % 60)).ToString().PadLeft(2, '0');
            textBox1.Text = debut;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                System.Diagnostics.Process process = new System.Diagnostics.Process();
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Normal;
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = string.Format("/K ffmpeg -i \"{0}\" -ss {1} -t {2} -vf scale=480:-1 -c:v libvpx -b:v " + (int)(3 * 1024 * 1024 * 8 / (finTemps - debutTemps) * 0.975) + " -quality good -cpu-used 0 -bufsize 1000k -an -pass 1 -f webm NUL &" +
                "ffmpeg -i \"{0}\" -ss {1} -t {2} -vf scale=480:-1 -c:v libvpx -b:v " + (int)(3 * 1024 * 1024 * 8 / (finTemps - debutTemps) * 0.975) + " -quality good -cpu-used 0 -bufsize 1000k -an -pass 2 -f webm \"{3}\"", fichier, debut, fin, saveFileDialog1.FileName);
                //startInfo.Arguments = string.Format("/C ffmpeg.exe -i \"{0}\" -threads 0 -ss {1}.000 -to {2}.000 -c:v libvpx -b:v 400K -an \"{3}\"", fichier, debut, fin, saveFileDialog1.FileName);
                MessageBox.Show(startInfo.Arguments);
                process.StartInfo = startInfo;
                process.Start();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double position = axWindowsMediaPlayer1.Ctlcontrols.currentPosition;
            finTemps = position;
            fin = ((int)(position / 3600)).ToString().PadLeft(2, '0') + ':' +
                ((int)((position / 60) % 60)).ToString().PadLeft(2, '0') + ':' +
                ((int)(position % 60)).ToString().PadLeft(2, '0');
            textBox2.Text = fin;
        }
    }
}
