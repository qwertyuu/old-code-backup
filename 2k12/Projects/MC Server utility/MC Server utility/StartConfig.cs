using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MC_Server_utility
{
    public partial class StartConfig : Form
    {
        public StartConfig()
        {
            InitializeComponent();
            KindOfStart = true;
            MinHeap = numericUpDown2.Value;
            MaxHeap = numericUpDown2.Value;
        }
        public bool KindOfStart { get; set; }
        public decimal  MaxHeap { get; set; }
        public decimal MinHeap { get; set; }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                KindOfStart = false;
                numericUpDown1.Enabled = true;
                numericUpDown2.Enabled = true;
            }
            else if (radioButton1.Checked)
            {
                KindOfStart = true;
                numericUpDown1.Enabled = false;
                numericUpDown2.Enabled = false;
            }
        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value < numericUpDown2.Value)
            {
                numericUpDown1.Value = numericUpDown2.Value;
            }
            MinHeap = numericUpDown2.Value;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (numericUpDown1.Value < numericUpDown2.Value)
            {
                numericUpDown2.Value = numericUpDown1.Value;
            }
            MaxHeap = numericUpDown1.Value;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
