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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }
        static bool _debug;
        public static bool debug
        {
            get
            {
                return _debug;
            }
            set
            {
                _debug = value;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Server_Database srvDB = new Server_Database();
            srvDB.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CreateServer newServer = new CreateServer();
            if (newServer.ShowDialog() == System.Windows.Forms.DialogResult.Yes)
            {
                if (CreateServer.KillMain == true)
                {
                    this.Close();
                }
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                debug = true;
            }
            else
            {
                debug = false;
            }
        }
    }
}
