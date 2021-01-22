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
    public partial class Msgbox : Form
    {
        public Msgbox(bool arg)
        {
            InitializeComponent();
            switch (arg)
            {
                case true:
                    label1.Text = "Bravo, tu as identifié toutes les mines!\nVeux-tu réessayer la même difficulté?";
                    this.Text = "Tu as gagné!";
                    break;
                case false:
                    label1.Text = "Tu as déclanché une mine...\nVeux-tu réessayer la même difficulté?";
                    this.Text = "Tu as perdu...";
                    break;
                default:
                    break;
            }
        }
    }
}
