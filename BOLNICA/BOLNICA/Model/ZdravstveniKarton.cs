using Bolnica;
using System;
using System.Collections.Generic;

namespace Model
{
    public class ZdravstveniKarton
    {

        public String IDPacijenta { get; set; }

        public ZdravstveniKarton() { }
        public ZdravstveniKarton(string iDPacijenta)
        {
            IDPacijenta = iDPacijenta;
            Alergeni = new List<Alergeni>();
        }

        public List<Alergeni> Alergeni { get; set; }

        public List<Recept> Recepti { get; set; } = new List<Recept>();

        public List<Anamneza> Anamneze { get; set; } = new List<Anamneza>();

    }
}