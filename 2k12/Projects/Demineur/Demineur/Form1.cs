using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Demineur
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Settings.initialXPos = 12;
            Settings.initialYPos = 12;
            Settings.AmountOfFlags = 0;
            Settings.numOfFlaggedMines = 0;
            int XPos = Settings.initialXPos;
            int YPos = Settings.initialYPos;
            Settings.state = new OPButton[Settings.width][];
            for (int i = 0; i < Settings.state.Length; i++)
            {
                Settings.state[i] = new OPButton[Settings.height];
                for (int j = 0; j < Settings.state[i].Length; j++)
                {
                    OPButton btn = new OPButton();
                    btn.Name = "button" + i + j;
                    btn.Height = 30;
                    btn.Width = 30;
                    btn.XPos = i;
                    btn.YPos = j;
                    btn.WasOriginalColor = btn.UseVisualStyleBackColor;
                    btn.Activated = false;
                    btn.Flagged = false;
                    btn.IsMine = false;
                    btn.FlaggedMine = false;
                    btn.State = 0;
                    btn.Font = Settings.ActualFont;
                    btn.Location = new Point(XPos, YPos);
                    btn.Anchor = (AnchorStyles.Top | AnchorStyles.Left);
                    btn.Click += btn_Click;
                    btn.MouseDown += btn_MouseDown;
                    btn.MouseUp += btn_MouseUp;
                    Settings.state[i][j] = btn;
                    this.Controls.Add(btn);
                    YPos += 36;
                }
                XPos += 36;
                YPos = Settings.initialYPos;
            }
            //max 28!!!
            this.Height = (36 * Settings.height) + 54;
            //max 52!!!
            this.Width = 36 * (Settings.width + 1);
            this.Text = string.Format("Démineur! {0}/{1}", Settings.amountOfMines - Settings.AmountOfFlags, Settings.amountOfMines);
            Settings.MineCoords = SetRandomMines(Settings.height, Settings.width, Settings.amountOfMines, Settings.state);
            SetState(Settings.MineCoords, Settings.width, Settings.height, Settings.state);
        }

        void btn_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                if (AllAround(((OPButton)sender), Settings.width, Settings.height, Settings.state, false) >= ((OPButton)sender).State && ((OPButton)sender).Activated)
                {
                    ActivateAllAround(Settings.width, Settings.height, (OPButton)sender, Settings.state);
                }
            }
        }

        void btn_MouseDown(object sender, MouseEventArgs e)
        {
            ((OPButton)sender).Focus();
            switch (e.Button)
            {
                case MouseButtons.Middle:
                    AllAround(((OPButton)sender), Settings.width, Settings.height, Settings.state, true);
                    break;
                case MouseButtons.Right:
                    if (!((OPButton)sender).Activated)
                    {
                        if (Settings.amountOfMines > Settings.AmountOfFlags || ((OPButton)sender).Flagged)
                        {
                            if (((OPButton)sender).IsMine)
                            {
                                ((OPButton)sender).FlaggedMine = !((OPButton)sender).FlaggedMine;
                                Settings.numOfFlaggedMines += (((OPButton)sender).FlaggedMine) ? 1 : -1;
                            }
                            ((OPButton)sender).Flagged = !((OPButton)sender).Flagged;
                            Settings.AmountOfFlags += (((OPButton)sender).Flagged) ? 1 : -1;
                            ((OPButton)sender).Text = (((OPButton)sender).Flagged) ? "F" : string.Empty;
                            this.Text = string.Format("Démineur! {0}/{1}", Settings.amountOfMines - Settings.AmountOfFlags, Settings.amountOfMines);
                            CheckWin();
                        }
                    }
                    break;
                default:
                    break;
            }
        }

        bool CheckWin()
        {
            bool win = false;
            if (Settings.numOfFlaggedMines == Settings.amountOfMines)
            {
                win = true;
            }
            if (win)
            {
                Msgbox dial = new Msgbox(true);
                switch (dial.ShowDialog())
                {
                    case DialogResult.No:
                        this.DialogResult = System.Windows.Forms.DialogResult.Retry;
                        this.Close();
                        break;
                    case DialogResult.Yes:
                        Reset();
                        break;
                    case DialogResult.Cancel:
                        this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                        this.Close();
                        break;
                    default:
                        this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                        this.Close();
                        break;
                }
                return true;
            }
            return false;
        }

        private void Reset()
        {
            Settings.AmountOfFlags = 0;
            Settings.numOfFlaggedMines = 0;
            for (int i = 0; i < Settings.state.Length; i++)
            {
                for (int j = 0; j < Settings.state[i].Length; j++)
                {
                    OPButton btn = Settings.state[i][j];
                    btn.BackColor = default(Color);
                    btn.UseVisualStyleBackColor = true;
                    btn.Text = string.Empty;
                    btn.Activated = false;
                    btn.Flagged = false;
                    btn.IsMine = false;
                    btn.FlaggedMine = false;
                    btn.State = 0;
                    Settings.state[i][j] = btn;
                }
            }
            this.Text = string.Format("Démineur! {0}/{1}", Settings.amountOfMines - Settings.AmountOfFlags, Settings.amountOfMines);
            Settings.MineCoords = SetRandomMines(Settings.height, Settings.width, Settings.amountOfMines, Settings.state);
            SetState(Settings.MineCoords, Settings.width, Settings.height, Settings.state);
        }

        void btn_Click(object sender, EventArgs e)
        {
            if (!((OPButton)sender).Flagged && !((OPButton)sender).Activated)
            {
                OpenButton((OPButton)sender, Settings.height, Settings.width, Settings.state, false);
            }
        }

        void Lost(OPButton[][] state)
        {
            for (int i = 0; i < Settings.MineCoords.Length; i++)
            {
                state[Settings.MineCoords[i][0]][Settings.MineCoords[i][1]].BackColor = Settings.MineColor;
            }
            Msgbox dial = new Msgbox(false);
            switch (dial.ShowDialog())
            {
                case DialogResult.No:
                    this.DialogResult = System.Windows.Forms.DialogResult.Retry;
                    this.Close();
                    break;
                case DialogResult.Yes:
                    Reset();
                    break;
                case DialogResult.Cancel:
                    this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                    this.Close();
                    break;
                default:
                    this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                    this.Close();
                    break;
            }
        }
        void WriteState(OPButton[][] state)
        {
            for (int i = 0; i < state.Length; i++)
            {
                for (int j = 0; j < state[i].Length; j++)
                {
                    state[i][j].Text = (state[i][j].State > 0 && state[i][j].IsMine == false) ? state[i][j].State.ToString() : string.Empty;
                    state[i][j].State = 0;
                    state[i][j].IsMine = false;
                }
            }
        }
        void SetState(int[][] mineCoords, int width, int height, OPButton[][] state)
        {
            foreach (var item in mineCoords)
            {
                OPButton buttBuffer = state[item[0]][item[1]];
                int xMin = -1;
                int xMax = 1;
                int yMin = -1;
                int yMax = 1;
                if (buttBuffer.XPos >= width - 1)
                {
                    xMax = 0;
                }
                if (buttBuffer.XPos <= 0)
                {
                    xMin = 0;
                }
                if (buttBuffer.YPos >= height - 1)
                {
                    yMax = 0;
                }
                if (buttBuffer.YPos <= 0)
                {
                    yMin = 0;
                }
                for (int x = xMin; x <= xMax; x++)
                {
                    for (int y = yMin; y <= yMax; y++)
                    {
                        if (!(x == 0 && y == 0))
                        {
                            state[buttBuffer.XPos + x][buttBuffer.YPos + y].State++;
                        }
                    }
                }
            }
        }
        int[][] SetRandomMines(int height, int width, int amountOfMines, OPButton[][] state)
        {
            Random rand = new Random();
            int[] buffer = new int[2];
            bool save = true;
            int index = 0;
            int[][] savedCoords = new int[amountOfMines][];
            for (int i = 0; i < savedCoords.Length; i++)
            {
                savedCoords[i] = new int[2];
                for (int j = 0; j < savedCoords[i].Length; j++)
                {
                    savedCoords[i][j] = -1;
                }
            }
            for (int i = 0; i < amountOfMines; i++)
            {
                buffer[0] = rand.Next(width);
                buffer[1] = rand.Next(height);
                foreach (var item in savedCoords)
                {
                    if (item[0] == buffer[0])
                    {
                        if (item[1] == buffer[1])
                        {
                            save = false;
                            i--;
                            break;
                        }
                    }
                }
                if (save)
                {
                    savedCoords[index][0] = buffer[0];
                    savedCoords[index][1] = buffer[1];
                    index++;
                }
                else
                {
                    save = true;
                }
            }
            foreach (var item in savedCoords)
            {
                state[item[0]][item[1]].IsMine = true;
            }
            return savedCoords;
        }
        void GetOptimalStart()
        {

        }
        void Virus(List<OPButton> virus, int height, int width, OPButton[][] state)
        {
            List<OPButton> toReturn = new List<OPButton>();
            foreach (var oPButton in virus)
            {
                OPButton buffer;
                int xMin = -1;
                int xMax = 1;
                int yMin = -1;
                int yMax = 1;
                if (oPButton.XPos >= width - 1)
                {
                    xMax = 0;
                }
                if (oPButton.XPos <= 0)
                {
                    xMin = 0;
                }
                if (oPButton.YPos >= height - 1)
                {
                    yMax = 0;
                }
                if (oPButton.YPos <= 0)
                {
                    yMin = 0;
                }
                for (int x = xMin; x <= xMax; x++)
                {
                    for (int y = yMin; y <= yMax; y++)
                    {
                        if (!(x == 0 && y == 0))
                        {
                            buffer = state[oPButton.XPos + x][oPButton.YPos + y];
                            if (!buffer.IsMine && !buffer.Activated && !buffer.Flagged)
                            {
                                OpenButton(buffer, height, width, state, true);
                                if (buffer.State == 0)
                                {
                                    toReturn.Add(buffer);
                                }
                            }
                        }
                    }
                }
            }
            if (toReturn.Count > 0)
            {
                Virus(toReturn, height, width, state);
            }
        }
        int AllAround(OPButton oPButton, int width, int height, OPButton[][] state, bool activate)
        {
            int toReturn = 0;
            oPButton.OldBackColor = oPButton.BackColor;
            oPButton.OldForeColor = oPButton.ForeColor;
            oPButton.WasOriginalColor = oPButton.UseVisualStyleBackColor;
            int xMin = -1;
            int xMax = 1;
            int yMin = -1;
            int yMax = 1;
            if (oPButton.XPos >= width - 1)
            {
                xMax = 0;
            }
            if (oPButton.XPos <= 0)
            {
                xMin = 0;
            }
            if (oPButton.YPos >= height - 1)
            {
                yMax = 0;
            }
            if (oPButton.YPos <= 0)
            {
                yMin = 0;
            }
            for (int x = xMin; x <= xMax; x++)
            {
                for (int y = yMin; y <= yMax; y++)
                {
                    if (!(x == 0 && y == 0))
                    {
                        if (state[oPButton.XPos + x][oPButton.YPos + y].Flagged)
                        {
                            toReturn++;
                        }
                        if (!activate)
                        {
                            if (state[oPButton.XPos + x][oPButton.YPos + y].WasOriginalColor)
                            {
                                state[oPButton.XPos + x][oPButton.YPos + y].UseVisualStyleBackColor = true;
                            }
                            else
                            {
                                state[oPButton.XPos + x][oPButton.YPos + y].BackColor = state[oPButton.XPos + x][oPButton.YPos + y].OldBackColor;
                            }
                            state[oPButton.XPos + x][oPButton.YPos + y].ForeColor = state[oPButton.XPos + x][oPButton.YPos + y].OldForeColor;
                        }
                        else if (activate)
                        {
                            state[oPButton.XPos + x][oPButton.YPos + y].OldBackColor = state[oPButton.XPos + x][oPButton.YPos + y].BackColor;
                            state[oPButton.XPos + x][oPButton.YPos + y].OldForeColor = state[oPButton.XPos + x][oPButton.YPos + y].ForeColor;
                            state[oPButton.XPos + x][oPButton.YPos + y].WasOriginalColor = state[oPButton.XPos + x][oPButton.YPos + y].UseVisualStyleBackColor;
                            if (!state[oPButton.XPos + x][oPButton.YPos + y].Activated)
                            {
                                state[oPButton.XPos + x][oPButton.YPos + y].BackColor = Color.Black;
                                state[oPButton.XPos + x][oPButton.YPos + y].ForeColor = Color.White;
                            }
                        }
                    }
                }
            }
            return toReturn;
        }

        bool OpenButton(OPButton oPButton, int height, int width, OPButton[][] state, bool virus)
        {
            oPButton.Activated = true;
            if (oPButton.IsMine)
            {
                Lost(state);
                return true;
            }
            if (CheckWin())
            {
                return true;
            }
            if (!virus)
            {
                if (oPButton.State == 0)
                {
                    List<OPButton> toVirus = new List<OPButton>();
                    toVirus.Add(oPButton);
                    Virus(toVirus, height, width, state);
                }
            }
            oPButton.BackColor = (oPButton.State > 0) ? Settings.FullColor : Settings.EmptyColor;
            if (oPButton.State > 0)
            {
                oPButton.Text = oPButton.State.ToString();
            }
            return false;
        }


        void ActivateAllAround(int width, int height, OPButton oPButton, OPButton[][] state)
        {
            bool lostOrWin = false;
            int xMin = -1;
            int xMax = 1;
            int yMin = -1;
            int yMax = 1;
            if (oPButton.XPos >= width - 1)
            {
                xMax = 0;
            }
            if (oPButton.XPos <= 0)
            {
                xMin = 0;
            }
            if (oPButton.YPos >= height - 1)
            {
                yMax = 0;
            }
            if (oPButton.YPos <= 0)
            {
                yMin = 0;
            }
            for (int x = xMin; x <= xMax; x++)
            {
                for (int y = yMin; y <= yMax; y++)
                {
                    if (!(x == 0 && y == 0))
                    {
                        if (!state[oPButton.XPos + x][oPButton.YPos + y].Activated && !state[oPButton.XPos + x][oPButton.YPos + y].Flagged)
                        {
                            lostOrWin = OpenButton(state[oPButton.XPos + x][oPButton.YPos + y], height, width, state, false);
                            if (lostOrWin)
                            {
                                break;
                            }
                        }
                    }
                }
                if (lostOrWin)
                {
                    break;
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.R:
                    Reset();
                    break;
                case Keys.N:
                    this.DialogResult = System.Windows.Forms.DialogResult.Retry;
                    this.Close();
                    break;
                default:
                    break;
            }
        }
    }

    public class OPButton : Button
    {
        public bool WasOriginalColor { get; set; }
        public Color OldBackColor { get; set; }
        public Color OldForeColor { get; set; }
        public int XPos { get; set; }
        public int YPos { get; set; }
        public int State { get; set; }
        public bool Flagged { get; set; }
        public bool IsMine { get; set; }
        public bool Activated { get; set; }
        public bool FlaggedMine { get; set; }
    }
}