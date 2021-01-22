using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Befunge
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            r = new Random();
            this.Height = 807;
            this.Width = 1296;
            this.KeyPreview = true;
            for (int x = 0; x < 80; x++)
            {
                state[x] = new YoloButton[25];
                for (int y = 0; y < 25; y++)
                {
                    YoloButton yeaBuddy = new YoloButton();
                    yeaBuddy.PreviewKeyDown += yeaBuddy_PreviewKeyDown;
                    yeaBuddy.KeyPress += yeaBuddy_KeyPress;
                    yeaBuddy.Text = " ";
                    yeaBuddy.Font = new System.Drawing.Font("Courier New", 12);
                    yeaBuddy.Position[0] = x;
                    yeaBuddy.Position[1] = y;
                    yeaBuddy.FlatStyle = FlatStyle.Flat;
                    yeaBuddy.FlatAppearance.BorderSize = 1;
                    yeaBuddy.Size = new Size(16, 25);
                    yeaBuddy.Left = x * yeaBuddy.Size.Width;
                    yeaBuddy.ForeColor = Color.Gray;
                    yeaBuddy.Top = y * yeaBuddy.Size.Height;
                    yeaBuddy.Name = "bouton" + x + y;
                    state[x][y] = yeaBuddy;
                    this.Controls.Add(yeaBuddy);
                }
            }
            state[0][0].Select();
            var lol = new StackView(this);
            lol.Show(this);
        }
        public event EventHandler Finish;
        int msWait;
        void yeaBuddy_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 22)
            {
                string A = "Salut";

                var buf = Clipboard.GetText().Replace('\n', (char)0);
                state[0][0].Select();
                int index = ((YoloButton)this.ActiveControl).Position[0];
                foreach (var item in buf)
                {
                    if (item == '\r')
                    {
                        state[index][((YoloButton)this.ActiveControl).Position[1] + 1].Select();
                    }
                    else if(item != (char)0)
                    {
                        ((YoloButton)this.ActiveControl).Text = item.ToString();
                        SelectNext(((YoloButton)this.ActiveControl), 0);
                    }
                }
            }
            else
            {
                if (!(e.KeyChar == (char)Keys.Back || e.KeyChar == (char)Keys.Escape))
                {
                    if (e.KeyChar == '^')
                    {
                        currentDirection = 1;
                    }
                    else if (e.KeyChar == 'v')
                    {
                        currentDirection = 3;
                    }
                    else if (e.KeyChar == '<')
                    {
                        currentDirection = 2;
                    }
                    else if (e.KeyChar == '>')
                    {
                        currentDirection = 0;
                    }
                    ((YoloButton)ActiveControl).Text = e.KeyChar.ToString();
                    SelectNext((YoloButton)ActiveControl, currentDirection);
                    e.Handled = true;
                }
            }
        }
        void yeaBuddy_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    e.IsInputKey = true;
                    currentDirection = 1;
                    break;
                case Keys.Down:
                    e.IsInputKey = true;
                    currentDirection = 3;
                    break;
                case Keys.Left:
                    e.IsInputKey = true;
                    currentDirection = 2;
                    break;
                case Keys.Right:
                    e.IsInputKey = true;
                    currentDirection = 0;
                    break;
                case Keys.Back:
                    e.IsInputKey = true;
                    break;
                default:
                    break;
            }
        }
        YoloButton[][] state = new YoloButton[80][];
        KeysConverter kC = new KeysConverter();
        int currentDirection = 0;
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    if (this.ActiveControl is YoloButton)
                    {
                        var current = (YoloButton)this.ActiveControl;
                        SelectNext(current, 2);
                    }
                    break;
                case Keys.Right:
                    if (this.ActiveControl is YoloButton)
                    {
                        var current = (YoloButton)this.ActiveControl;
                        SelectNext(current, 0);
                    }
                    break;
                case Keys.Up:
                    if (this.ActiveControl is YoloButton)
                    {
                        var current = (YoloButton)this.ActiveControl;
                        SelectNext(current, 1);
                    }
                    break;
                case Keys.Down:
                    if (this.ActiveControl is YoloButton)
                    {
                        var current = (YoloButton)this.ActiveControl;
                        SelectNext(current, 3);
                    }
                    break;
                case Keys.Back:
                    if (this.ActiveControl is YoloButton)
                    {
                        var current = (YoloButton)this.ActiveControl;
                        SelectNext(current, Opposite(currentDirection));
                        current = (YoloButton)this.ActiveControl;
                        current.Text = " ";
                    }
                    break;
                case Keys.V:
                    if (e.Modifiers == Keys.Control)
                    {
                    }
                    break;
                default:
                    break;
            }
        }

        private int Opposite(int currentDirection)
        {
            switch (currentDirection)
            {
                case 0:
                    return 2;
                case 1:
                    return 3;
                case 2:
                    return 0;
                case 3:
                    return 1;
                default:
                    return 0;
            }
        }

        private void SelectNext(YoloButton current, int direction)
        {
            switch (direction)
            {
                case 0:
                    if (current.Position[0] == 79)
                    {
                        state[0][current.Position[1]].Select();
                    }
                    else
                    {
                        state[current.Position[0] + 1][current.Position[1]].Select();
                    }
                    break;
                case 1:
                    if (current.Position[1] == 0)
                    {
                        state[current.Position[0]][24].Select();
                    }
                    else
                    {
                        state[current.Position[0]][current.Position[1] - 1].Select();
                    }
                    break;
                case 2:
                    if (current.Position[0] == 0)
                    {
                        state[79][current.Position[1]].Select();
                    }
                    else
                    {
                        state[current.Position[0] - 1][current.Position[1]].Select();
                    }
                    break;
                case 3:
                    if (current.Position[1] == 24)
                    {
                        state[current.Position[0]][0].Select();
                    }
                    else
                    {
                        state[current.Position[0]][current.Position[1] + 1].Select();
                    }
                    break;
                default:
                    break;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {

        }
        Random r;
        private void button2_Click(object sender, EventArgs e)
        {
            msWait = (10 - trackBar1.Value) * 100;
            state[0][0].Select();
            currentDirection = 0;
            bool terminated = false;
            char buffer;
            while (!terminated)
            {
                buffer = ((YoloButton)ActiveControl).Text[0];
                terminated = EvalThis(buffer);
                if (!terminated)
                {
                    SelectNext((YoloButton)ActiveControl, currentDirection);
                }
                this.Update();
                System.Threading.Thread.Sleep(msWait);
            }
            richTextBox1.Text += Environment.NewLine + Environment.NewLine + "*Fin*" + Environment.NewLine;
        }
        bool stringMode = false;
        public YoloStack<int> runtimeStack = new YoloStack<int>();
        bool jump = false;
        private bool EvalThis(char buffer)
        {
            if (stringMode)
            {
                if (buffer == '"')
                {
                    stringMode = !stringMode;
                }
                else
                {
                    runtimeStack.Push((int)buffer);
                }
            }
            else
            {
                if (jump)
                {
                    jump = false;
                }
                else
                {
                    switch (buffer)
                    {
                        case '?':
                            currentDirection = r.Next(4);
                            break;
                        case 'v':
                            currentDirection = 3;
                            break;
                        case '>':
                            currentDirection = 0;
                            break;
                        case '^':
                            currentDirection = 1;
                            break;
                        case '<':
                            currentDirection = 2;
                            break;
                        case '"':
                            stringMode = !stringMode;
                            break;
                        case '@':
                            runtimeStack.Clear();
                            if (Finish != null)
                            {
                                Finish(runtimeStack, null);
                            }
                            return true;
                        case ':':
                            if (runtimeStack.Count == 0)
                            {
                                runtimeStack.Push(0);
                            }
                            int buf = runtimeStack.Pop();
                            runtimeStack.Push(buf);
                            runtimeStack.Push(buf);
                            break;
                        case '+':
                            if (runtimeStack.Count == 0)
                            {
                                runtimeStack.Push(0);
                                runtimeStack.Push(0);
                            }
                            runtimeStack.Push(runtimeStack.Pop() + runtimeStack.Pop());
                            break;
                        case '-':
                            if (runtimeStack.Count == 0)
                            {
                                runtimeStack.Push(0);
                                runtimeStack.Push(0);
                            }
                            int a, b;
                            a = runtimeStack.Pop();
                            b = runtimeStack.Pop();
                            runtimeStack.Push(b - a);
                            break;
                        case '\\':
                            int a1, b1;
                            a1 = runtimeStack.Pop();
                            b1 = runtimeStack.Pop();
                            runtimeStack.Push(a1);
                            runtimeStack.Push(b1);
                            break;
                        case '*':
                            if (runtimeStack.Count == 0)
                            {
                                runtimeStack.Push(0);
                                runtimeStack.Push(0);
                            }
                            runtimeStack.Push(runtimeStack.Pop() * runtimeStack.Pop());
                            break;
                        case '_':
                            if (runtimeStack.Count == 0)
                            {
                                runtimeStack.Push(0);
                            }
                            currentDirection = (runtimeStack.Pop() == 0) ? 0 : 2;
                            break;
                        case '|':
                            if (runtimeStack.Count == 0)
                            {
                                runtimeStack.Push(0);
                            }
                            currentDirection = (runtimeStack.Pop() == 0) ? 3 : 1;
                            break;
                        case ',':
                            if (runtimeStack.Count == 0)
                            {
                                runtimeStack.Push(0);
                            }
                            richTextBox1.Text += (char)runtimeStack.Pop();
                            break;
                        case '#':
                            jump = true;
                            break;
                        default:
                            int parseOut = 0;
                            if (int.TryParse(buffer.ToString(), out parseOut))
                            {
                                runtimeStack.Push(parseOut);
                            }
                            break;
                    }
                }

            }
            return false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
        }
    }
    class YoloButton : Button
    {
        public int[] Position = new int[2];
    }
    class MyList<T> : List<T>
    {

        public event EventHandler OnAdd;

        public void Add(T item)
        {
            if (null != OnAdd)
            {
                OnAdd(this, null);
            }
            base.Add(item);
        }

    }
    public class YoloStack<T> : Stack<T>
    {
        public event EventHandler OnPush;
        public event EventHandler OnPop;
        public void Push(T item)
        {
            base.Push(item);
            if (null != OnPush)
            {
                OnPush(this, null);
            }
        }
        public T Pop()
        {
            var lol = base.Pop();
            if (null != OnPop)
            {
                OnPop(this, null);
            }
            return lol;
        }
    }
}
