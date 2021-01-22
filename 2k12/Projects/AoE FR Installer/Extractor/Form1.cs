using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Ionic.Zip;
using System.Diagnostics;
using System.IO;

namespace Extractor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int value = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            var lol = ZipFile.Read("AoE2FR.zip");
            lol.ExtractProgress += lol_ExtractProgress;
            lol.ExtractAll(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/TempAoE2");
            Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/TempAoE2/InstallAoE2FR.exe").WaitForExit();
            Directory.Delete(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "/TempAoE2", true);
        }

        void lol_ExtractProgress(object sender, ExtractProgressEventArgs e)
        {
            if (e.TotalBytesToTransfer > 0)
            {
                progressBar1.Value = (int)e.BytesTransferred / (int)e.TotalBytesToTransfer;
            }
        }
    }
}
