using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace jeu_a_cimon
{
    public partial class Form1 : Form
    {
        Control[] cA = new Control[24];
        Random rand = new Random();
        System.Threading.Thread t;
        DateTime timer = DateTime.Now;
        int last = 0;
        bool work = true;
        int current = 0;
        int index = 0;
        public Form1()
        {
            InitializeComponent();
            int index = 0;
            t = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(Work));
            foreach (Control c in this.Controls)
            {
                if (c is Button)
                {
                    cA[index] = c;
                    c.Click += c_Click;
                    index++;
                }
            }
            t.IsBackground = true;
            t.Start();
        }

        void c_Click(object sender, EventArgs e)
        {
            work = false;
            var rep = MessageBox.Show(string.Format("Bravo, tu as réussi en {0} secondes!", Math.Round((DateTime.Now - timer).TotalSeconds, 1)), "Bien joué!", MessageBoxButtons.RetryCancel);
            if (rep == System.Windows.Forms.DialogResult.Retry)
            {
                work = true;
                t = new System.Threading.Thread(new System.Threading.ParameterizedThreadStart(Work));
                t.IsBackground = true;
                timer = DateTime.Now;
                t.Start();
            }
            else if (rep == System.Windows.Forms.DialogResult.Cancel)
            {
                this.Close();
            }
            
        }

        private void Work(object obj)
        {
            while (work == true)
            {
                this.BeginInvoke(new Invoker(EnableButton));
                System.Threading.Thread.Sleep(300);
            }
        }

        private void EnableButton()
        {
            index = rand.Next(0, 24);
            cA[last].Enabled = false;
            current = index;
            if (current == last && current < 24)
            {
                current++;
            }
            else if (current == last && current == 24)
            {
                current--;
            }
            cA[current].Enabled = true;
            last = current;
        }
        delegate void Invoker();
    }
}