using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace AoE_FR_Installer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Class1.GamePath = "C:\\" + dasDir + "\\Microsoft Games\\Age of Empires II";
            Class1.Here = thisDir;
            Detect();
        }
        private void Detect()
        {
            Init i = new Init();
            i.ShowDialog();
            button1.Enabled = true;
            button2.Enabled = true;
            button2.Text = "Go!";
            switch (Class1.IsAoKInstalled)
            {
                case 0:
                    MessageBox.Show("NE CHANGEZ PAS LE DOSSIER DE DESTINATION DE L'INSTALLEUR, CAR LE LOGICIEL NE TROUVERA PAS LES FICHIERS À CRACKER.\n\nSI VOUS NE SAVEZ PAS C'EST QUOI, OUBLIEZ CE MESSAGE.", "ATTENTION!!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    button2.Text = "Installez Age of Empires 2 avant!";
                    button2.Enabled = false;
                    break;
                case 1:
                    button1.Text = "Installé mais je le crack...";
                    button1.Enabled = false;
                    CrackAoK();
                    break;
                case 2:
                    button1.Text = "Installé et cracké";
                    button1.Enabled = false;
                    break;
                default:
                    break;
            }
            switch (Class1.IsAoCInstalled)
            {
                case 1:
                    button2.Text = "Installé mais je le crack...";
                    button2.Enabled = false;
                    UpdateAoC();
                    CrackAoC();
                    break;
                case 2:
                    button2.Text = "Installé, à jour et cracké";
                    button2.Enabled = false;
                    break;
                default:
                    break;
            }
        }
        string thisDir = Directory.GetCurrentDirectory();
        string dasDir = (!Directory.Exists("C:\\Program Files (x86)")) ? "Program Files" : "Program Files (x86)";
        private void button1_Click(object sender, EventArgs e)
        {
            InstallAoK();
        }

        private void InstallAoC()
        {
            Process.Start(thisDir + "/Conquerors/AOCSETUP.EXE").WaitForExit();
            System.Threading.Thread.Sleep(2000);
            if (MessageBox.Show("Cliquez sur OK quand Age of Empires 2: The Conquerors est installé pour le mettre à jour!", "J'attends...", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                UpdateAoC();
                CrackAoC();
            }
            Detect();
        }

        private void CrackAoC()
        {
            File.Copy(thisDir + "/Conquerors/CRACK/age2_x1.exe", "C:\\" + dasDir + "\\Microsoft Games\\Age of Empires II\\age2_x1\\age2_x1.exe", true);
        }

        private void UpdateAoC()
        {
            Process.Start(thisDir + "/Conquerors/PATCH/Age_Of_Empires_2_The_Conquerors_Patch_1.0C.exe").WaitForExit();
        }

        private void CrackAoK()
        {
            File.Copy(thisDir + "/Kings/CRACK/EMPIRES2.exe", "C:\\" + dasDir + "\\Microsoft Games\\Age of Empires II\\empires2.exe", true);
        }

        private void InstallAoK()
        {
            Process.Start(thisDir + "/Kings/AOESETUP.exe").WaitForExit();
            System.Threading.Thread.Sleep(2000);
            if (MessageBox.Show("Cliquez sur OK quand Age of Empires 2 est installé!", "J'attends...", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                CrackAoK();
            }
            Detect();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            InstallAoC();
        }
    }
}
