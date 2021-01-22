using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenFinal
{
    class CentreTri
    {
        Stack<Matiere> plastique;
        Stack<Matiere> verre;
        Stack<Matiere> papier;
        Queue<Vaisseau> depart;
        Queue<Vaisseau> arrivee;
        CentreTri prochainCentre;
        public int NbVaisseauDepart { get { return depart.Count; } }
        public int Capacite { get; private set; }
        public int Numero { get; private set; }
        public CentreTri(int _num, CentreTri _prochain = null)
        {
            Capacite = 1000;
            Numero = _num;
            prochainCentre = _prochain;
            plastique = new Stack<Matiere>();
            verre = new Stack<Matiere>();
            papier = new Stack<Matiere>();
            depart = new Queue<Vaisseau>();
            arrivee = new Queue<Vaisseau>();
        }

        public void AjoutVaisseau(Vaisseau _v)
        {
            ViderNouveauVaisseau(_v);
        }

        public override string ToString()
        {
            return string.Format("Centre numero {5}\n\n{0} tonnes dans papier\n{1} tonnes dans verre\n{2} tonnes dans plastique\nReste {3} vaisseaux dans la queue de départ\nReste {4} vaisseaux dans la queue d'arrivée",
                    papier.Count,
                    verre.Count,
                    plastique.Count,
                    depart.Count,
                    arrivee.Count,
                    Numero);
        }

        public bool MiseAJour()
        {
            if (depart.Count > 0 && prochainCentre != null)
            {
                prochainCentre.AjoutVaisseau(depart.Dequeue());
                return true;
            }
            return false;
        }

        public void ViderNouveauVaisseau(Vaisseau courrant)
        {
            while (courrant.contenu.Count > 0)
            {
                Matiere matCourrant = courrant.contenu.Pop();
                switch (matCourrant.type)
                {
                    case TypeMateriel.Papier:
                        papier.Push(matCourrant);
                        if (papier.Count == this.Capacite)
                        {
                            ViderPile(papier);
                        }
                        break;
                    case TypeMateriel.Verre:
                        verre.Push(matCourrant);
                        if (verre.Count == this.Capacite)
                        {
                            ViderPile(verre);
                        }
                        break;
                    case TypeMateriel.Plastique:
                        plastique.Push(matCourrant);
                        if (plastique.Count == this.Capacite)
                        {
                            ViderPile(plastique);
                        }
                        break;
                }
            }
            arrivee.Enqueue(courrant);
        }

        private void ViderPile(Stack<Matiere> materiel)
        {
            Vaisseau courrant = arrivee.Dequeue();
            while (materiel.Count > 0)
            {
                courrant.contenu.Push(materiel.Pop());
                if (courrant.contenu.Count == courrant.Capacite && materiel.Count > 0)
                {
                    depart.Enqueue(courrant);
                    if (arrivee.Count == 0)
                    {
                        break;
                    }
                    courrant = arrivee.Dequeue();
                }
            }
            if (courrant != null && courrant.contenu.Count < courrant.Capacite && !depart.Contains(courrant))
            {
                depart.Enqueue(courrant);
            }
        }
    }
}
