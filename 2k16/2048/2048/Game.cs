using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048
{

    class Game
    {
        public Case[][] state;
        public static Dictionary<int, Image> Textures;
        Random rand;
        public Game()
        {
            rand = new Random();
            Textures = new Dictionary<int, Image>();
            for (int i = 2; i <= 2048; i *= 2)
            {
                Textures[i] = Image.FromFile("textures\\" + i + ".jpg");
            }
            NewGame();
        }

        private void NewGame()
        {
            state = new Case[4][];
            for (int i = 0; i < state.Length; i++)
            {
                state[i] = new Case[4];
            }
            for (int i = 0; i < 2; i++)
            {
                GenerateNewUniqueCase();
            }
        }

        private void GenerateNewUniqueCase()
        {
            List<int[]> vides = new List<int[]>();
            for (int y = 0; y < state.Length; y++)
            {
                for (int x = 0; x < state[y].Length; x++)
                {
                    if (state[y][x] == null)
                    {
                        vides.Add(new int[] { y, x });
                    }
                }
            }
            int[] chosenOne = vides[rand.Next(vides.Count)];
            state[chosenOne[0]][chosenOne[1]] = new Case(rand);
        }

        public void Input(Keys key)
        {
            bool reponse = false;
            switch (key)
            {
                case Keys.Left:
                    reponse = ProcessLeft();
                    break;
                case Keys.Right:
                    reponse = ProcessRight();
                    break;
                case Keys.Up:
                    reponse = ProcessUp();
                    break;
                case Keys.Down:
                    reponse = ProcessDown();
                    break;
                default:
                    return;
            }
            GenerateNewUniqueCase();
        }

        private bool ProcessDown()
        {
            bool toReturn = false;
            Case[] toSend;
            for (int i = 0; i < 4; i++)
            {
                toSend = new Case[4];
                for (int j = 0; j < 4; j++)
                {
                    toSend[j] = state[j][i];
                }
                toReturn |= ProcessIt(toSend);

                for (int j = 0; j < 4; j++)
                {
                    state[j][i] = toSend[3 - j];
                }
            }
            return toReturn;
        }

        private bool ProcessIt(Case[] p, bool aLenvers = false)
        {
            List<Case> list = new List<Case>();
            bool nothing = true;
            if (aLenvers)
            {
                for (int i = 3; i >= 0; i--)
                {
                    var item = p[i];
                    if (item != null)
                    {
                        list.Add(item);
                        nothing = false;
                    }
                }
            }
            else
            {
                foreach (var item in p)
                {
                    if (item != null)
                    {
                        list.Add(item);
                        nothing = false;
                    }
                }
            }
            if (nothing)
            {
                return false;
            }
            int index = 0;
            Case[] toApply = new Case[4];
            while (list.Count > 1)
            {
                Case first = list[list.Count - 1];
                Case second = list[list.Count - 2];
                if (first.Value == second.Value)
                {
                    toApply[index] = new Case(first.Value + second.Value);
                    index++;
                    list.Remove(first);
                    list.Remove(second);
                }
                else
                {
                    toApply[index] = new Case(first.Value);
                    index++;
                    list.Remove(first);
                }
            }
            if (list.Count == 1)
            {
                toApply[index] = new Case(list[list.Count - 1].Value);
                index++;
            }
            bool toReturn = false;
            for (int i = 0; i < p.Length; i++)
            {
                if (toApply[i] != null && p[i] != null && p[i].Value != toApply[i].Value)
                {
                    toReturn = true;
                }
                p[i] = toApply[i];
            }
            return toReturn;
        }

        private bool ProcessUp()
        {
            bool toReturn = false;
            Case[] toSend;
            for (int i = 0; i < 4; i++)
            {
                toSend = new Case[4];
                for (int j = 0; j < 4; j++)
                {
                    toSend[j] = state[j][i];
                }
                toReturn |= ProcessIt(toSend, true);

                for (int j = 0; j < 4; j++)
                {
                    state[j][i] = toSend[j];
                }
            }
            return toReturn;
        }

        private bool ProcessRight()
        {

            bool toReturn = false;
            for (int i = 0; i < 4; i++)
            {
                Case[] reversed = state[i];
                toReturn |= ProcessIt(reversed);
                state[i] = reversed.Reverse().ToArray();
            }
            return toReturn;
        }

        private bool ProcessLeft()
        {
            bool toReturn = false;
            for (int i = 0; i < 4; i++)
            {
                toReturn |= ProcessIt(state[i], true);

            }
            return toReturn;
        }
    }
}
