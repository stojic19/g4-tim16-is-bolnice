using Bolnica;
using Bolnica.Model;
using Bolnica.Model.Enumi;
using System;
using System.Collections.Generic;

namespace Model
{
    public class ZdravstveniKarton
    {

        private BracniStatus BracniStatus;

        private String MestoZaposlenja;

        public String IDPacijenta { get; set; }

        public ZdravstveniKarton() { }

        public ZdravstveniKarton(string iDPacijenta)
        {
            IDPacijenta = iDPacijenta;
            Alergeni = new List<Alergeni>();
            BracniStatus = BracniStatus.neozenjenNeudata;
            MestoZaposlenja = "";
        }

        public List<Alergeni> Alergeni { get; set; }

        public List<Recept> Recepti { get; set; } = new List<Recept>();

        public List<Anamneza> Anamneze { get; set; } = new List<Anamneza>();

        public List<Uput> Uputi { get; set; } = new List<Uput>();

        public List<Alergeni> DobaviAlergene()
        {
            return Alergeni;
        }

        public void DodajAlergen(Alergeni alergen)
        {
            Alergeni.Add(alergen);
        }

        public void IzmeniAlergen(Alergeni alergenZaIzmenu)
        {
            foreach(Alergeni alergen in Alergeni)
            {
                if(alergen.IdAlergena.Equals(alergenZaIzmenu.IdAlergena))
                {
                    alergen.OpisReakcije = alergenZaIzmenu.OpisReakcije;
                    alergen.VremeZaPojavu = alergenZaIzmenu.VremeZaPojavu;
                    break;
                }
            }
        }

        public void UkloniAlergen(Alergeni alergenZaUklanjanje)
        {
            List<Alergeni> novaLista = new List<Alergeni>();
            foreach (Alergeni alergen in Alergeni)
            {
                if (!alergen.IdAlergena.Equals(alergenZaUklanjanje.IdAlergena))
                    novaLista.Add(alergen);
            }
            Alergeni = novaLista;
        }
    }
}