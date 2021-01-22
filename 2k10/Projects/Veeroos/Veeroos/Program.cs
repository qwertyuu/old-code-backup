using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Veeroos
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Media.SoundPlayer l = new System.Media.SoundPlayer();
            Random randNum = new Random();
            l.SoundLocation = @"http://dl.dropbox.com/u/59121288/FuckYourShit.wav";
            bool iAmGay = false;
            while (iAmGay != true)
            {
                //System.Threading.Thread.Sleep(randNum.Next(30000));
                l.Play();
                System.Threading.Thread.Sleep(2000);
            }
        }
    }
}
