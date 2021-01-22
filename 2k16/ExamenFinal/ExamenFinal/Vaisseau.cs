using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenFinal
{
    class Vaisseau
    {
        public Stack<Matiere> contenu { get; private set; }
        private static Random rnd;
        public int Capacite { get; private set; }
        public Vaisseau()
        {
            Capacite = 125;
            if (rnd == null)
            {
                rnd = new Random();
            }
            this.contenu = new Stack<Matiere>();
            while (this.contenu.Count < Capacite)
            {
                this.contenu.Push(new Matiere((TypeMateriel)rnd.Next(3)));
            }
        }


    }
}
