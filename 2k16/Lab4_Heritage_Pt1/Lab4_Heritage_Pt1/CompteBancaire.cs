using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4_Heritage_Pt1
{
    class CompteBancaire
    {
        private static uint conteurDeNumero;
        public string Titulaire { get; private set; }
        public uint Numero { get; private set; }
        public double Solde { get; protected set; }

        public CompteBancaire(string _titulaire)
        {
            if (conteurDeNumero == new uint())
            {
                conteurDeNumero = 1000;
            }
            this.Numero = conteurDeNumero;
            this.Titulaire = _titulaire;
            this.Solde = 0;

            conteurDeNumero++;
        }

        public void Crediter(double _depot)
        {
            this.Solde += _depot;
        }

        public void Debiter(double _retrait)
        {
            this.Solde -= _retrait;
        }

        public string Relever()
        {
            return this.ToString();
        }

        public override string ToString()
        {
            return string.Format("Compte #{0}\nAppartenant à {1}\nA un solde de: {2}$", Numero, Titulaire, Solde);
        }

    }
}
