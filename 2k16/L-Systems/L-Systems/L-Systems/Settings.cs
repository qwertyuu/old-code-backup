using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace L_Systems
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        public SettingsInfo settings { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Yes;
        }
    }
}
