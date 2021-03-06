using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using vJoyInterfaceWrap;

namespace TwitchPlays
{
    public partial class InputHandler
    {
        private Dictionary<String, uint> usersList;
        private Dictionary<String, Delegate> commands ;
        private vJoy player1;
        private vJoy player2;

        public InputHandler()
        {
            player1 = new vJoy();
            player2 = new vJoy();
            ///// Write access to vJoy Device - Basic
            VjdStat status = player1.GetVJDStatus(1);
            
            // Acquire the target
            string prt;
            if ((status == VjdStat.VJD_STAT_OWN) ||
            ((status == VjdStat.VJD_STAT_FREE) && (!player1.AcquireVJD(1))))
                prt = String.Format("Failed to acquire vJoy device number {0}.", 1);
            else
                prt = String.Format("Acquired: vJoy device number {0}.", 1);
            MessageBox.Show(prt);


            status = player2.GetVJDStatus(2);

            // Acquire the target
            if ((status == VjdStat.VJD_STAT_OWN) ||
            ((status == VjdStat.VJD_STAT_FREE) && (!player2.AcquireVJD(2))))
                prt = String.Format("Failed to acquire vJoy device number {0}.", 2);
            else
                prt = String.Format("Acquired: vJoy device number {0}.", 2);

            MessageBox.Show(prt);
            usersList = new Dictionary<string, uint>();
            commands = new Dictionary<string, Delegate>();
            commands["left"] = new Func<uint, vJoy,  bool>(Left);
            commands["right"] = new Func<uint, vJoy, bool>(Right);
            commands["up"] = new Func<uint, vJoy, bool>(Up);
            commands["down"] = new Func<uint, vJoy, bool>(Down);
            commands["a"] = new Func<uint, vJoy, bool>(A);
            commands["b"] = new Func<uint, vJoy, bool>(B);
            commands["start"] = new Func<uint, vJoy, bool>(Start);
            commands["c1"] = commands["z"] = new Func<uint, vJoy, bool>(C1);
            commands["c2"] = new Func<uint, vJoy, bool>(C2);
            commands["c3"] = new Func<uint, vJoy, bool>(C3);
            commands["c4"] = new Func<uint, vJoy, bool>(C4);
            commands["rb"] = new Func<uint, vJoy, bool>(RB);
            commands["lb"] = new Func<uint, vJoy, bool>(LB);
            commands["none"] = new Func<uint, vJoy, bool>(None);
        }

        private bool None(uint player, vJoy playa)
        {
            return playa.SetDiscPov(-1, player, 1);
        }

        private bool C1(uint player, vJoy playa)
        {
            return playa.SetDiscPov(3, player, 2);
        }
        private bool C2(uint player, vJoy playa)
        {
            return playa.SetDiscPov(0, player, 2);
        }
        private bool C3(uint player, vJoy playa)
        {
            return playa.SetDiscPov(1, player, 2);
        }
        private bool C4(uint player, vJoy playa)
        {
            return playa.SetDiscPov(2, player, 2);
        }

        private bool Start(uint player, vJoy playa)
        {
            return playa.SetBtn(true, player, 5);
        }

        private bool Right(uint player, vJoy playa)
        {
            return playa.SetDiscPov(1, player, 1);
        }

        private bool Left(uint player, vJoy playa)
        {
            return playa.SetDiscPov(3, player, 1);
        }

        private bool Up(uint player, vJoy playa)
        {
            return playa.SetDiscPov(0, player, 1);
        }

        private bool Down(uint player, vJoy playa)
        {
            return playa.SetDiscPov(2, player, 1);
        }

        private bool B(uint player, vJoy playa)
        {
            return playa.SetBtn(true, player, 2);
        }

        private bool A(uint player, vJoy playa)
        {
            return playa.SetBtn(true, player, 1);
        }

        private bool RB(uint player, vJoy playa)
        {
            return playa.SetBtn(true, player, 3);
        }

        private bool LB(uint player, vJoy playa)
        {
            return playa.SetBtn(true, player, 4);
        }
        public CommandEventArgs Handle(string command, string user)
        {
            string[] allTheStuff = command.Trim().Split(' ');
            bool succeeded = false;
            uint chosenPlayer = 0;
            allTheStuff[0] = allTheStuff[0].ToLower();
            switch (allTheStuff[0])
            {
                case "player":
                    if (uint.TryParse(allTheStuff[1], out chosenPlayer) && allTheStuff.Length == 2)
                    {
                        succeeded = SetPlayer(chosenPlayer, user);
                    }
                    break;
                default:
                    if (!usersList.ContainsKey(user) || allTheStuff.Length > 1 || !commands.ContainsKey(allTheStuff[0]))
                        return null;
                    uint currentPlayer = usersList[user];
                    vJoy playa = currentPlayer == 1 ? player1 : player2;

                    Reset(currentPlayer, playa);
                    succeeded = (bool)commands[allTheStuff[0]].DynamicInvoke(currentPlayer, playa);
                    break;
            }
            if (succeeded)
            {
                return new CommandEventArgs()
                {
                    Player = user,
                    Command = allTheStuff[0],
                    NewPlayer = chosenPlayer
                };
            }
            else
            {
                return null;
            }
        }

        private bool SetPlayer(uint chosenPlayer, string user)
        {
            if (chosenPlayer == 1 || chosenPlayer == 2)
            {
                usersList[user] = chosenPlayer;
                return true;
            }
            return false;
        }
        private void ResetAll(uint player)
        {
            vJoy playa = player == 1 ? player1 : player2;
            bool code = false;
            for (uint i = 1; i <= 2; i++)
            {
                code = playa.SetDiscPov(-1, player, i);
                code = playa.SetBtn(false, player, i);
            }
            for (uint i = 3; i <= 5; i++)
                code = playa.SetBtn(false, player, i);

            System.Threading.Thread.Sleep(50);
        }
        private void Reset(uint player, vJoy playa)
        {
            bool code = false;
            code = playa.SetDiscPov(-1, player, 2);
            for (uint i = 1; i <= 5; i++)
                code = playa.SetBtn(false, player, i);

            System.Threading.Thread.Sleep(50);
        }
    }
}
