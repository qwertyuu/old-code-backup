using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatTheShit
{
    class Auto
    {
        public string Marque { get; set; }
        public int Annee { get; set; }
        public int NbDeRoues { get; set; }
        public string Modele { get; set; }

        public Auto(string _marque, int _annee, int _nbroues, string _modele)
        {
            if (_annee < 0)
            {
                throw new Exception();
            }
            this.Marque = _marque;
            this.Annee = _annee;
            this.NbDeRoues = _nbroues;
            this.Modele = _modele;
        }
    }
}
