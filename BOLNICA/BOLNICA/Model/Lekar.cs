using Bolnica.Model;
using System;
using System.Collections.Generic;

namespace Model
{
    public class Lekar : Osoba
    {
        private List<RadniDan> radniDani = new List<RadniDan>();
        private Godisnji godisnji;
        private List<Odsustvo> odsustva = new List<Odsustvo>();
        private SpecijalizacijeLekara specijalizacija = SpecijalizacijeLekara.nema;
        private bool dostupnost = false;

        private List<RadniDan> RadniDani { get => radniDani; set => radniDani = value; }

        private Godisnji Godisnji { get => godisnji; set => godisnji = value; }

        private List<Odsustvo> Odsustva { get => odsustva; set => odsustva = value; }

        public SpecijalizacijeLekara Specijalizacija { get => specijalizacija; set => specijalizacija = value; }
        public Boolean Dostupnost { get => dostupnost; set => dostupnost = value; }
        public Lekar() { }

        public Lekar(string korisnickoIme, string ime, string prezime, DateTime datum, Pol pol, string jmbg, string adresa, string telefon, string email, string lozinka, SpecijalizacijeLekara specijalizacija)
        {
            this.KorisnickoIme = korisnickoIme;
            this.Ime = ime;
            this.Prezime = prezime;
            this.DatumRodjenja = datum;
            this.Pol = pol;
            this.AdresaStanovanja = adresa;
            this.Jmbg = jmbg;
            this.KontaktTelefon = telefon;
            this.Email = email;
            this.Lozinka = lozinka;
            this.specijalizacija = specijalizacija;

            this.RadniDani = new List<RadniDan>();
            this.Godisnji = new Godisnji(DateTime.Now.Year, 20);
            this.Odsustva = new List<Odsustvo>();
        }

        public Lekar(string korisnickoIme, string ime, string prezime, DateTime datum, Pol pol, string jmbg, string adresa, string telefon, string email, string lozinka)
        {
            this.KorisnickoIme = korisnickoIme;
            this.Ime = ime;
            this.Prezime = prezime;
            this.DatumRodjenja = datum;
            this.Pol = pol;
            this.AdresaStanovanja = adresa;
            this.Jmbg = jmbg;
            this.KontaktTelefon = telefon;
            this.Email = email;
            this.Lozinka = lozinka;

            this.RadniDani = new List<RadniDan>();
            this.Godisnji = new Godisnji(DateTime.Now.Year, 20);
            this.Odsustva = new List<Odsustvo>();
        }

        public Lekar(string korisnickoIme, string ime, string prezime)
        {
            this.KorisnickoIme = korisnickoIme;
            this.Ime = ime;
            this.Prezime = prezime;
        }


        public Lekar(string korisnickoIme, SpecijalizacijeLekara specijalizacija, bool dostupnost)
        {
            this.KorisnickoIme = korisnickoIme;
            this.specijalizacija = specijalizacija;
            this.dostupnost = dostupnost;
        }

        public List<RadniDan> DobaviRadneDane()
        {
            return RadniDani;
        }
        public void DodajRadniDan(RadniDan radniDan)
        {
            RadniDani.Add(radniDan);
        }
        public void IzmeniRadniDan(RadniDan stariRadniDan, RadniDan noviRadniDan)
        {
            foreach (RadniDan radniDan in RadniDani)
            {
                if (DateTime.Compare(radniDan.PocetakSmene, stariRadniDan.PocetakSmene) == 0)
                {
                    radniDan.PocetakSmene = noviRadniDan.PocetakSmene;
                    radniDan.KrajSmene = noviRadniDan.KrajSmene;
                    break;
                }
            }
        }
        public void UkloniRadniDan(RadniDan radniDanZaUklanjanje)
        {
            List<RadniDan> novaLista = new List<RadniDan>();
            foreach (RadniDan radniDan in RadniDani)
            {
                if (!(DateTime.Compare(radniDan.PocetakSmene, radniDanZaUklanjanje.PocetakSmene) == 0))
                    novaLista.Add(radniDan);
            }
            RadniDani = novaLista;
        }
        public bool DaLiRadiNaProsledjenDatum(DateTime datum)
        {
            foreach(RadniDan radniDan in RadniDani)
            {
                if (DateTime.Compare(datum.Date, radniDan.PocetakSmene.Date) == 0)
                    return true;
            }
            return false;
        }
        public void DodajSlobodneDane(Odsustvo odsustvo)
        {
            Odsustva.Add(odsustvo);
        }
        public void IzmeniSlobodneDane(Odsustvo staroOdsustvo, Odsustvo novoOdsustvo)
        {
            foreach (Odsustvo odsustvo in Odsustva)
            {
                if (DateTime.Compare(odsustvo.PocetakOdsustva.Date, staroOdsustvo.PocetakOdsustva.Date) == 0)
                {
                    odsustvo.PocetakOdsustva = novoOdsustvo.PocetakOdsustva;
                    odsustvo.KrajOdsustva = novoOdsustvo.KrajOdsustva;
                    break;
                }
            }
        }
        public void UkloniSlobodneDane(Odsustvo odsustvoZaUklanjanje)
        {
            List<Odsustvo> novaLista = new List<Odsustvo>();
            foreach (Odsustvo odsustvo in Odsustva)
            {
                if (!(DateTime.Compare(odsustvo.PocetakOdsustva.Date, odsustvoZaUklanjanje.PocetakOdsustva.Date) == 0))
                    novaLista.Add(odsustvo);
            }
            Odsustva = novaLista;
        }
        public bool DaLiJeDostupanNaProsledjenDatum(DateTime prosledjenDatum)
        {
            foreach (RadniDan radniDan in RadniDani)
            {
                if (DateTime.Compare(prosledjenDatum.Date, radniDan.PocetakSmene.Date) == 0)
                    return false;
            }
            foreach (Odsustvo odsustvo in Odsustva)
            {
                for (DateTime datum = odsustvo.PocetakOdsustva.Date; DateTime.Compare(datum, odsustvo.KrajOdsustva.Date) <= 0;datum = datum.AddDays(1))
                    if (DateTime.Compare(prosledjenDatum.Date, datum) == 0)
                        return false;
            }
            return true;
        }
        public bool DaLiJeNaGodisnjemNaProsledjenDatum(DateTime prosledjenDatum)
        {
            foreach (Odsustvo odsustvo in Odsustva)
            {
                for (DateTime datum = odsustvo.PocetakOdsustva.Date; DateTime.Compare(datum, odsustvo.KrajOdsustva.Date) <= 0;datum = datum.AddDays(1))
                    if (DateTime.Compare(prosledjenDatum.Date, datum) == 0)
                        return true;
            }
            return false;
        }
        public List<Odsustvo> DobaviSlobodneDane()
        {
            return Odsustva;
        }
    }
}