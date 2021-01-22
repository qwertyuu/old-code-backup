using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MusicariumSVC
{
    public partial class Form1 : Form
    {
        System.Threading.Thread watcher;
        public Form1()
        {
            
            InitializeComponent();
            watcher = new System.Threading.Thread(Watch);
            watcher.IsBackground = true;
            //watcher.Start();
            notifyIcon1.ShowBalloonTip(10000, "haha", "huhu", ToolTipIcon.Warning);
        }

        private void Watch()
        {

        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            this.WindowState = FormWindowState.Normal;
            this.BringToFront();
            this.Focus();
        }

        protected override void Dispose(bool disposing)
        {
            notifyIcon1.Dispose();
            base.Dispose(disposing);
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Veux tu fermer pour de vré?", "Fermer?", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
            {
                e.Cancel = true;
                this.WindowState = FormWindowState.Minimized;
            }
        }

    }
}
