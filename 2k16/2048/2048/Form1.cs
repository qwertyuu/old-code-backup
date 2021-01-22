using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048
{
    public partial class Form1 : Form
    {
        Game jeu;
        PictureBox[][] boxes;
        public Form1()
        {
            InitializeComponent();
            jeu = new Game();
            GetPictureBoxes();
            RefreshInterface();
        }

        private void GetPictureBoxes()
        {
            boxes = new PictureBox[4][];
            for (int i = 0; i < boxes.Length; i++)
            {
                boxes[i] = new PictureBox[4];
            }
            foreach (var item in this.Controls)
            {
                if (item is PictureBox)
                {
                    string TAG = (string)((PictureBox)item).Tag;
                    int x = int.Parse(TAG.Substring(0, 1));
                    int y = int.Parse(TAG.Substring(1, 1));
                    boxes[y][x] = (PictureBox)item;
                }
            }
        }

        private void RefreshInterface()
        {
            for (int y = 0; y < jeu.state.Length; y++)
            {
                for (int x = 0; x < jeu.state[y].Length; x++)
                {
                    if (jeu.state[y][x] != null)
                    {
                        boxes[y][x].Image = jeu.state[y][x].texture;
                    }
                    else
                    {
                        boxes[y][x].Image = null;
                    }
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            jeu.Input(e.KeyCode);
            RefreshInterface();
        }
    }
}
