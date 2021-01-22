using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CheckBoxFun
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            int originalX = 12;
            int originalY = 12;
            int xMess = originalX;
            int yMess = originalY;
            player = new System.Threading.Thread(new System.Threading.ThreadStart(MoveIt));
            for (int i = 0; i < 2; i++)
            {
                Rectangle lol = new Rectangle();
                lol.Height = 2;
                lol.Width = 2;
                lol.X = 0 + i * 3;
                lol.Y = 0 + i * 3;
                lol.SpeedX = 2;
                lol.SpeedY = 1;
                globalList.Add(lol);
            }
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    CheckBox buffer = new CheckBox();
                    buffer.Left = xMess;
                    buffer.Top = yMess;
                    buffer.Width = 15;
                    buffer.Height = 14;
                    buffer.Checked = false;
                    buffer.Text = string.Empty;
                    state[j, i] = buffer;
                    this.Controls.Add(buffer);
                    xMess += 21;
                }
                xMess = originalX;
                yMess += 20;
            }
            player.IsBackground = true;
            player.Start();
        }
        CheckBox[,] state = new CheckBox[20, 20];
        System.Threading.Thread player;
        List<Rectangle> globalList = new List<Rectangle>();
        private void MoveIt()
        {
            while (true)
            {
                this.Invoke(new MethodInvoker(DrawGame));
                System.Threading.Thread.Sleep(500);
                this.Invoke(new MethodInvoker(ResetGrid));
                UpdateVars();
            }
        }

        private void UpdateVars()
        {
            foreach (var item in globalList)
            {
                if (item.X + item.Width >= 20)
                {
                    item.SpeedX *= -1;
                }
                if (item.X <= 0 && item.SpeedX < 0)
                {
                    item.SpeedX *= -1;
                }
                if (item.Y + item.Height >= 20)
                {
                    item.SpeedY *= -1;
                }
                if (item.Y <= 0 && item.SpeedY < 0)
                {
                    item.SpeedY *= -1;
                }
                item.X += item.SpeedX;
                item.Y += item.SpeedY;
            }
        }

        private void DrawGame()
        {
            foreach (var item in globalList)
            {
                for (int i = item.X; i < item.Width + item.X; i++)
                {
                    for (int j = item.Y; j < item.Height + item.Y; j++)
                    {
                        state[i, j].Checked = true;
                    }
                }
            }
        }

        private void ResetGrid()
        {
            foreach (var item in state)
            {
                item.Checked = false;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            player.Abort();
        }
    }
}
