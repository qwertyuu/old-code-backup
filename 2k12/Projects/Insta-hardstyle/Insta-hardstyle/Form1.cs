using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Insta_hardstyle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            System.Threading.Thread t = new System.Threading.Thread(Thread1);
            System.Threading.Thread t1 = new System.Threading.Thread(ButtonController);
            button1.Enabled = false;
            t.IsBackground = true;
            t1.IsBackground = true;
            t.Start();
            t1.Start();
        }
        private void Thread1(object obj)
        {
            pInfo = new System.Net.WebClient().DownloadString("http://insta-hardstyle.redirectme.net");
        }

        private void ButtonController()
        {
            while (pInfo == string.Empty)
            {
                System.Threading.Thread.Sleep(100);
            }
            urls = pInfo.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
            button1.Invoke(new MethodInvoker(button1_Enable));
            overflow = new bool[urls.Length];
            for (int i = 0; i < overflow.Length; i++)
            {
                overflow[i] = false;
            }
        }
        string pInfo = string.Empty;
        string[] urls;
        bool[] overflow;
        Random r = new Random();

        private void button1_Click(object sender, EventArgs e)
        {
            button12_Click();
            //this.Close();
        }
        private void button12_Click()
        {
            bool a = false;
            for (int k = 0; k < overflow.Length; k++)
            {
                if (overflow[k] == false)
                {
                    break;
                }
                else if (k == overflow.Length - 1)
                {
                    for (int j = 0; j < overflow.Length; j++)
                    {
                        overflow[j] = false;
                    }
                }
            }
            while (a == false)
            {
                var lol = r.Next(urls.Length);
                if (overflow[lol] == false)
                {
                    Process.Start(urls[lol]);
                    richTextBox1.Text = urls[lol] + "\n" + lol;
                    overflow[lol] = true;
                    a = true;
                }
            }
        }
        private void button1_Enable()
        {
            button1.Enabled = true;
            //button12_Click();
        }
    }
}
