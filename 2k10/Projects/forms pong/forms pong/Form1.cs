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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            time.GlobalValue = DateTime.Now;
            time.bounceCount = 0;
        }
        ball ball = new ball();
        Form2 gameOver = new Form2();
        public DateTime startTime = new DateTime();
        private void Form1_Load(object sender, EventArgs e)
        {
            System.Threading.Thread ha = new System.Threading.Thread(DoThis);
            ha.IsBackground = true;
            ha.Start();
            System.Threading.Thread collision = new System.Threading.Thread(CheckCollision);
            collision.IsBackground = true;
            collision.Start();
            ball.Show();
            startTime = DateTime.Now;
        }
        
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
                    catch (ObjectDisposedException e)
                    {
                    }
                }
                System.Threading.Thread.Sleep(20);
                if (gameOver.end == true)
                {
                    this.Invoke(new MethodInvoker(Close));
                }
            }
        }
        void CheckCollision()
        {
            bool iAmGay = true;
            int count = 0;
            while (iAmGay)
            {
                if (this != null)
                {
                    //ball side
                    int ballTop = ball.Location.Y;
                    int ballBot = ball.Location.Y + ball.Height;

                    //player side
                    int playerTop = this.Location.Y;
                    int playerBot = this.Location.Y + this.Height;

                    //collision?
                    if ((this.Location.X + this.Width) - ball.Location.X >= -20 && (this.Location.X + this.Width) - ball.Location.X <= 15)
                    {
                        if (ballBot >= playerTop && ballTop <= playerBot)
                        {
                            if (count >=5)
                            {
                                ball.speedY = (ball.speedY < 0) ? ball.speedY - 1 : ball.speedY + 1;
                                ball.speedX = (ball.speedX < 0) ? ball.speedX - 1 : ball.speedX + 1;
                                count = 0;
                            }
                            count++;
                            if (ball.speedX %2 == 0 && ball.speedY %2 == 0 && ball.speedX + ball.speedY > 30)
                            {
                                ball.speedX /= 2;
                                ball.speedY /= 2;
                                ball.milTimeout /= 2;
                            }
                            ball.speedX *= -1;
                            this.Invoke(new MethodInvoker(UpdateText));
                            time.bounceCount++;
                        }
                    }
                    if (ball.lost == true)
                    {
                        this.Invoke(new MethodInvoker(GameOver));
                        iAmGay = false;
                    }
                }
                System.Threading.Thread.Sleep(6);
            }
        }

        private void UpdateText()
        {
            label1.Text = "X:" + ball.speedX;
            label2.Text = "Y:" + ball.speedY;
        }
        void DoThat()
        {
            if (Cursor.Position.Y<= this.Height / 2)
            {
                this.Top = 0;
            }
            else
            this.Top = Cursor.Position.Y - this.Height / 2;

            if (Cursor.Position.Y >= Screen.PrimaryScreen.Bounds.Height - this.Height / 2)
            {
                this.Top = Screen.PrimaryScreen.Bounds.Height - this.Height;
            }

        }
        bool paused = false;
        int oldSpeedX = 0;
        int oldSpeedY = 0;

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Escape)
            {
                this.Close();
            }
            if (e.KeyData == Keys.P && paused == false)
            {
                oldSpeedX = ball.speedX;
                oldSpeedY = ball.speedY;
                ball.speedX = 0;
                ball.speedY = 0;
                paused = true;
            }
            else if (e.KeyData == Keys.P && paused == true)
            {
                ball.speedX = oldSpeedX;
                ball.speedY = oldSpeedY;
                paused = false;
            }
        }
        void GameOver()
        {
            ball.Close();
            gameOver.Show();
            this.Hide();
        }
        private void Form1_LocationChanged(object sender, EventArgs e)
        {
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
