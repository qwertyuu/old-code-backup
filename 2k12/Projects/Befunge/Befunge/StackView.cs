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
    public partial class StackView : Form
    {
        private Form1 form1;

        public StackView()
        {
            InitializeComponent();
        }

        public StackView(Form1 form1)
        {
            // TODO: Complete member initialization
            InitializeComponent();
            this.form1 = form1;
            form1.runtimeStack.OnPop += runtimeStack_OnPop;
            form1.runtimeStack.OnPush += runtimeStack_OnPush;
            form1.Finish += form1_Finish;
        }

        void form1_Finish(object sender, EventArgs e)
        {
            //UpdateList((YoloStack<int>)sender);
        }
        void runtimeStack_OnPush(object sender, EventArgs e)
        {
            UpdateList((YoloStack<int>)sender);
        }

        private void runtimeStack_OnPop(object sender, EventArgs e)
        {
            UpdateList((YoloStack<int>)sender);
        }

        private void UpdateList(YoloStack<int> sender)
        {
            StringBuilder buf = new StringBuilder();
            int count = 1;
            foreach (var item in sender)
            {
                buf.Append(string.Format("{0}.    \"{1}\"     {2}\n", count, (char)item, item));
                count++;
            }
            richTextBox1.Text = buf.ToString();
            this.Update();
        }

        private void UpdateList()
        {
            StringBuilder buf = new StringBuilder();
            richTextBox1.Text = buf.ToString();
        }
    }
}
