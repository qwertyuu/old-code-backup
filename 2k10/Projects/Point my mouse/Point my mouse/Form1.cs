using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Point_my_mouse
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            System.Threading.Thread ha = new System.Threading.Thread(DoThis);
            ha.IsBackground = true;
            ha.Start();
        }
        
        private void label1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void DoThis()
        {
            bool iAmGay = true;
            while (iAmGay)
            {
                label1.Invoke(new MethodInvoker(AddOne));
                System.Threading.Thread.Sleep(30);
            }
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            

        }
        void AddOne()
        {
            var curPos = Cursor.Position;
            var labelX = (label1.Location.X + 13) + this.Location.X;
            var labelY = (label1.Location.Y + 37) + this.Location.Y;
            label2.Text = curPos.X + " " + labelX + "\n" + curPos.Y + " " + labelY;
            var treshold = 20;
            if ((curPos.X  -labelX) <= treshold && (curPos.X - labelX) >= -treshold && (curPos.Y - labelY) <= treshold && (curPos.Y - labelY) >= -treshold)
            {
                label1.Text = "•";
            }
            else if ((curPos.X - labelX) <= treshold && (curPos.X - labelX) >= -treshold)
            {
                label1.Text = "|";
            }
            else if ((curPos.Y - labelY) <= treshold && (curPos.Y - labelY) >= -treshold)
            {
                label1.Text = "—";
            }
            else if (curPos.X < labelX && curPos.Y < labelY || curPos.X > labelX && curPos.Y > labelY)
            {
                label1.Text = @"\";
            }

            else if (curPos.X < labelX && curPos.Y > labelY || curPos.X > labelX && curPos.Y < labelY)
                label1.Text = "/";


        }

        private void button1_Click(object sender, EventArgs e)
        {
        }
    }
}
