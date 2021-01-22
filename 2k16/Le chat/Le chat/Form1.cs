using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Le_chat
{
    public partial class Form1 : Form
    {
        System.Threading.Thread pos;
        public Form1()
        {
            InitializeComponent();
            pos = new System.Threading.Thread(UpdatePos);
            pos.IsBackground = true;
            pos.Start();
            this.KeyDown += Form1_KeyDown;
        }

        void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                pos.Abort();
                this.Close();
            }
        }

        private void UpdatePos(object obj)
        {
            while (true)
            {
                this.Invoke((MethodInvoker)delegate
                {
                    this.Location = new Point(Cursor.Position.X - this.Size.Width / 2, Cursor.Position.Y - this.Size.Height / 2);
                });
            }

        }

        
    }
}
