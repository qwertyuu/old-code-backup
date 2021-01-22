using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Launcher
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            currentDir = Directory.GetCurrentDirectory();
            Directory.CreateDirectory(currentDir + "/D-Mineur/");
            if (!File.Exists(currentDir + "/D-Mineur/Demineur.exe"))
            {
                button2.Enabled = false;
            }
            if (!File.Exists(currentDir + "/D-Mineur/version.txt"))
            {
                File.Create(currentDir + "/D-Mineur/version.txt").Close();
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        StreamReader checkVer;
        bool controlModif = false;
        private void button1_Click(object sender, EventArgs e)
        {
            if (Form.ModifierKeys == Keys.Control)
            {
                controlModif = true;
            }
            checkVer = new StreamReader(currentDir + "/D-Mineur/version.txt");
            var checkOnline = new System.Net.WebClient();
            checkOnline.DownloadStringCompleted += checkOnline_DownloadStringCompleted;
            checkOnline.DownloadStringAsync(new Uri("http://pastebin.com/raw.php?i=4avqFMrx"));
            progressBar1.Style = ProgressBarStyle.Marquee;
            label1.Text = "Attendez...";
        }

        void checkOnline_DownloadStringCompleted(object sender, System.Net.DownloadStringCompletedEventArgs e)
        {
            if (e.Result != checkVer.ReadLine() || controlModif)
            {
                var lol = e.Result.Split('\n');
                checkVer.Close();
                var b = new System.Net.WebClient();
                progressBar1.Style = ProgressBarStyle.Continuous;
                b.DownloadProgressChanged += b_DownloadProgressChanged;
                b.DownloadFileCompleted += b_DownloadFileCompleted;
                foreach (var item in lol)
                {
                    if (item != string.Empty)
                    {
                        b.DownloadFileAsync(new Uri(item), currentDir + "/D-Mineur/" + Path.GetFileName(new Uri(item).LocalPath));
                    }
                }
                StreamWriter setActualVer = new StreamWriter(currentDir + "/D-Mineur/version.txt");
                setActualVer.Write(e.Result);
                setActualVer.Close();
            }
            else
            {
                Process.Start(currentDir + "/D-Mineur/Demineur.exe");
                this.Close();
            }
        }

        void b_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Process.Start(currentDir + "/D-Mineur/Demineur.exe");
            this.Close();
        }

        void b_DownloadProgressChanged(object sender, System.Net.DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            label1.Text = string.Format("{0}%", e.ProgressPercentage);
        }

        public string currentDir { get; set; }

        private void button2_Click(object sender, EventArgs e)
        {
            Process.Start(currentDir + "/D-Mineur/Demineur.exe");
            this.Close();
        }
    }
}