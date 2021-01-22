using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using Robocode;

namespace RC
{
    class Rabot : Robot
    {
        // The main method of your robot containing robot logics
        DateTime round;
        bool onOff = true;
        double rate = 30;
        bool scanned = false;
        DateTime firstData;
        DateTime secondData;
        double time;
        public override void Run()
        {
            ScanColor = Color.Violet;
            
            while (onOff)
            {
                while (!scanned)
                {
                    TurnGunLeft(5);
                }
                    
                Fire(1);
                //Ahead(50000);
            }
        }
        public override void OnBulletMissed(BulletMissedEvent evnt)
        {
            base.OnBulletMissed(evnt);
            if (firstData == new DateTime())
            {
                firstData = DateTime.Now;
            }
            else if (secondData == new DateTime())
            {
                secondData = DateTime.Now;
            }
            else
            {
                rate = (secondData - firstData).TotalMilliseconds;
            }
            Out.WriteLine(rate);
            if (DateTime.Now > round)
            {
                scanned = false;
            }
        }
        public override void OnScannedRobot(ScannedRobotEvent evnt)
        {
            base.OnScannedRobot(evnt);
            time = evnt.Distance / (17.0 * rate);
            //Out.WriteLine("Distance: " + evnt.Distance);
            //Out.WriteLine("Temps: " + time);
            round = DateTime.Now;
            round = round.AddSeconds(time);
            scanned = true;

        }
        public override void OnHitWall(HitWallEvent evnt)
        {
            base.OnHitWall(evnt);
            this.TurnLeft(-90);
        }
        public override void OnDeath(DeathEvent evnt)
        {
            base.OnDeath(evnt);
            onOff = false;
        }
    }
}
