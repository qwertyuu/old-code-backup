using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TrollForm
{
    public partial class Form1 : Form
    {
        public Form1(double _size, Random _rnd)
        {
            InitializeComponent();
            rnd = _rnd;
            size = _size / 1.1;
        }
        Random rnd;
        double size;
        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < 2; i++)
            {
                Form1 f = new Form1(this.size, rnd);
                f.Show();
            }
            //this.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = (int)size;
            this.Height = (int)size;
            this.Top = rnd.Next(1080 - this.Height);
            this.Left = rnd.Next(1920 - this.Width);
            this.BackColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
        }


    }
}
