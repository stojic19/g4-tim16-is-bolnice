﻿using Bolnica.Model.Enumi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Model
{
    public class Pitanje
    {
        private String tekstPitanja;
        private int ocena;
        private bool pitanjeOBolnici;

        public String TekstPitanja
        {
            get { return tekstPitanja; }
            set { tekstPitanja = value; }
        }

        public int Ocena
        {
            get { return ocena; }
            set { ocena = value; }
        }


        public bool PitanjeOBolnici
        {
            get { return pitanjeOBolnici; }
            set { pitanjeOBolnici = value; }
        }
        public Pitanje() { }
        public Pitanje(int ocena, string tekstPitanja,  bool pitanjeOBolnici)
        {
            Ocena = ocena;
            TekstPitanja = tekstPitanja;
            PitanjeOBolnici = pitanjeOBolnici;
           
        }
    }
}
