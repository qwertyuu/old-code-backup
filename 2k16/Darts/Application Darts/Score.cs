using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_Darts
{
    public class Score
    {
        private List<int> Pointage { get; set; }
        public int Initial { get; private set; }
        public int Courrant { get; private set; }
        public Score(int initial)
        {
            Pointage = new List<int>();
            this.Initial = initial;
            this.Courrant = initial;
        }

        public List<int> Get()
        {
            return Pointage;
        }

        public void Ajout(int pointage)
        {
            Courrant -= pointage;
            Pointage.Add(pointage);
        }
    }
}
