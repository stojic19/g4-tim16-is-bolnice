using Bolnica;
using Bolnica.Model;
using Bolnica.Model.Enumi;
using System;
using System.Collections.Generic;

namespace Model
{
    public class ZdravstveniKarton
    {

        private BracniStatus bracniStatus;
        private String mestoZaposlenja;
        private String imeRoditelja;
        private String brojKartona;
        public String IDPacijenta { get; set; }

        public ZdravstveniKarton() { }

        public ZdravstveniKarton(string iDPacijenta)
        {
            IDPacijenta = iDPacijenta;
            this.Alergeni = new List<Alergeni>();
            this.bracniStatus = BracniStatus.neozenjenNeudata;
            this.mestoZaposlenja = "";
            this.imeRoditelja = "";
            this.brojKartona = "";
        }

        public List<Alergeni> Alergeni { get; set; }

        public List<Recept> Recepti { get; set; } = new List<Recept>();

        public List<Anamneza> Anamneze { get; set; } = new List<Anamneza>();

        public List<Uput> Uputi { get; set; } = new List<Uput>();
        public BracniStatus BracniStatus
        {
            get { return bracniStatus; }
            set { bracniStatus = value; }
        }
        public String MestoZaposlenja
        {
            get { return mestoZaposlenja; }
            set { mestoZaposlenja = value; }
        }
        public String ImeRoditelja
        {
            get { return imeRoditelja; }
            set { imeRoditelja = value; }
        }
        public String BrojKartona
        {
            get { return brojKartona; }
            set { brojKartona = value; }
        }

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