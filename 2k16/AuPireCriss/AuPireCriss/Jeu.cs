using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AuPireCriss
{
    public partial class Jeu : Form
    {
        public Jeu()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            toPrint = new List<Printable>();
            Timer printer = new Timer()
            {
                Interval = 33,
                Enabled = true
                
            };
            printer.Tick += printer_Tick;
            testCreep = new Creep(new Rectangle(30, 30, 15, 30), 100)
            {
                damage = 5
            };
            testHero = new Hero(new Rectangle(150, 150, 30, 60), 200);
            testHero.texture = testCreep.texture = Image.FromFile("textures\\k.jpg");
            toPrint.Add(testHero);
            toPrint.Add(testCreep);
            
        }
        Creep testCreep;
        Hero testHero;
        List<Printable> toPrint;
        void printer_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void Jeu_Paint(object sender, PaintEventArgs e)
        {
            foreach (var item in toPrint)
            {
                item.Print(e.Graphics);
            }
        }
        private void Jeu_KeyDown(object sender, KeyEventArgs e)
        {
            testHero.Pos = new Rectangle(testHero.Pos.X + 2, testHero.Pos.Y, testHero.Pos.Width, testHero.Pos.Height);
        }
    }
}
