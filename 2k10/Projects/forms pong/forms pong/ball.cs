using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace forms_pong
{
    public partial class ball : Form
    {
        public ball()
        {
            InitializeComponent();
        }
        public bool lost = false;
        private void ball_Load(object sender, EventArgs e)
        {
            System.Threading.Thread ha = new System.Threading.Thread(DoThis);
            ha.IsBackground = true;
            ha.Start();
        }
        public int speedX = 9;
        public int speedY = 9;
        public int milTimeout = 6;

        void DoThis()
        {
            bool iAmGay = true;
            while (iAmGay)
            {
                if (this != null)
                {
                    try
                    {
                        this.Invoke(new MethodInvoker(DoThat));
                    }
                    catch (Exception e)
                    {
                    }
                }
                System.Threading.Thread.Sleep(milTimeout);

                if (this.lost == true)
                {
                    iAmGay = false;
                }
            }
        }
        void DoThat()
        {
            this.Left += speedX;
            this.Top += speedY;

            if (this.Location.X + this.Width >= Screen.PrimaryScreen.Bounds.Width)
            {
                speedX *= -1;
            }
            if (this.Location.Y + this.Height >= Screen.PrimaryScreen.Bounds.Height || this.Location.Y <= 0)
            {
                speedY *= -1;
            }
            else if (this.Location.X <= 0)
            {
                lost = true;
            }

        }
        
    }
}
