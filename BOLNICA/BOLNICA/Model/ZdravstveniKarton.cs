using Bolnica;
using Bolnica.Model;
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
                Console.WriteLine(alergen.IdAlergena);
                if (!alergen.IdAlergena.Equals(alergenZaUklanjanje.IdAlergena))
                    novaLista.Add(alergen);
            }
            Alergeni = novaLista;
        }
    }
}