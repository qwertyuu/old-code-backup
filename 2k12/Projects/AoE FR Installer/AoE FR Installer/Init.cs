using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace AoE_FR_Installer
{
    public partial class Init : Form
    {
        public Init()
        {
            InitializeComponent();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            System.Threading.Thread t = new System.Threading.Thread(DoIt);
            t.IsBackground = true;
            t.Start();
        }

        void DoIt()
        {
            Class1.IsAoCInstalled = 0;
            Class1.IsAoKInstalled = 0;
            StringBuilder AoKCrackHash = new StringBuilder();
            StringBuilder AoKInstalledHash = new StringBuilder();
            StringBuilder AoCCrackHash = new StringBuilder();
            StringBuilder AoCInstalledHash = new StringBuilder();
            var AoKCrackStream = new FileStream(Class1.Here + "/Kings/CRACK/empires2.exe", FileMode.Open);
            var AoCCrackStream = new FileStream(Class1.Here + "/Conquerors/CRACK/age2_x1.exe", FileMode.Open);
            foreach (var i in MD5.Create().ComputeHash(AoKCrackStream))
            {
                AoKCrackHash.Append(i);
            }
            if (File.Exists(Class1.GamePath + "/empires2.exe"))
            {
                Class1.IsAoKInstalled = 1;
                var AoKInstallStream = new FileStream(Class1.GamePath + "/empires2.exe", FileMode.Open);
                foreach (var i in MD5.Create().ComputeHash(AoKInstallStream))
                {
                    AoKInstalledHash.Append(i);
                }
                if (AoKCrackHash.ToString() == AoKInstalledHash.ToString())
                {
                    Class1.IsAoKInstalled = 2;
                }
                AoKInstallStream.Close();
            }
            foreach (var i in MD5.Create().ComputeHash(AoCCrackStream))
            {
                AoCCrackHash.Append(i);
            }
            if (File.Exists(Class1.GamePath + "/age2_x1/age2_x1.exe"))
            {
                Class1.IsAoCInstalled = 1;
                var AoCInstallStream = new FileStream(Class1.GamePath + "/age2_x1/age2_x1.exe", FileMode.Open);
                foreach (var i in MD5.Create().ComputeHash(AoCInstallStream))
                {
                    AoCInstalledHash.Append(i);
                }
                if (AoCInstalledHash.ToString() == AoCCrackHash.ToString())
                {
                    Class1.IsAoCInstalled = 2;
                }
                AoCInstallStream.Close();
            }
            AoKCrackStream.Close();
            AoCCrackStream.Close();
            this.Invoke(new MethodInvoker(Close));
        }

    }
}
