using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrainfuckInterpret
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            state = new int[Int16.MaxValue];
            buffer = new int[256];
            output.Text = string.Empty;
            pointer = 0;
            i = 0;
            CheckLoop();
            while (i < input.Text.Length)
            {
                Think();
                i++;
            }
        }

        private void CheckLoop()
        {
            Stack<int> lol = new Stack<int>();
            for (int j = 0; j < input.Text.Length; j++)
            {
                switch (input.Text[j])
                {
                    case '[':
                        lol.Push(j);
                        break;
                    case ']':
                        int target = lol.Pop();
                        state[target] = j;
                        state[j] = target;
                        break;
                    default:
                        break;
                }
            }
        }
        int[] state;
        int[] buffer;
        int pointer;
        int i;

        private bool Think()
        {
            switch (input.Text[i])
            {
                case '>':
                    pointer++;
                    if (pointer > 255)
                    {
                        pointer = 0;
                    }
                    break;
                case '<':
                    pointer--;
                    if (pointer <0)
                    {
                        pointer = 255;
                    }
                    break;
                case '+':
                    buffer[pointer]++;
                    if (buffer[pointer] > 255)
                    {
                        buffer[pointer] = 0;
                    }
                    break;
                case '-':
                    buffer[pointer]--;
                    if (buffer[pointer] < 0)
                    {
                        buffer[pointer] = 255;
                    }
                    break;
                case '.':
                    output.Text += (char)buffer[pointer];
                    break;
                case ',':
                    new inputPrompt().ShowDialog();
                    buffer[pointer] = PromptValue[0];
                    break;
                case '[':
                    if (buffer[pointer] == 0)
                    {
                        i = state[i];
                    }
                    break;
                case ']':
                    i = state[i] - 1;
                    break;
                case '#':
                    break;
                default:
                    return false;
            }
            return true;
        }
        public static string PromptValue { get; set; }

        private void button2_Click(object sender, EventArgs e)
        {
            StringBuilder a = new StringBuilder();
            foreach (char j in input.Text)
            {
                switch (j)
                {
                    case '+':
                        a.Append(j);
                        break;
                    case '-':
                        a.Append(j);
                        break;
                    case '>':
                        a.Append(j);
                        break;
                    case '<':
                        a.Append(j);
                        break;
                    case '[':
                        a.Append(j);
                        break;
                    case ']':
                        a.Append(j);
                        break;
                    case '.':
                        a.Append(j);
                        break;
                    case ',':
                        a.Append(j);
                        break;
                    default:
                        break;
                }
            }
            input.Text = a.ToString();
        }
    }
}