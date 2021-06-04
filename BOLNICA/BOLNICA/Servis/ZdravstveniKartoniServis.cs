using Bolnica.Model.Rukovanja;
using Bolnica.Repozitorijum;
using Bolnica.Repozitorijum.Interfejsi;
using Model;
using System;
using System.Collections.Generic;

namespace Bolnica.Model
{
    class ZdravstveniKartoniServis
    {
        NaloziPacijenataServis naloziPacijenataServis = new NaloziPacijenataServis();
        LekoviRepozitorijumInterfejs lekoviRepozitorijum = new LekoviRepozitorijum();

        public List<Lek> DobaviLekoveBezAlergena(String idIzabranogPacijenta)
        {
            List<Lek> lekoviBezAlergena = new List<Lek>();

            foreach (Lek l in lekoviRepozitorijum.DobaviSveObjekte())
            {
                if (!ProveraAlergicnosti(idIzabranogPacijenta, l.IDLeka))
                {
                    lekoviBezAlergena.Add(l);
                }
            }
            return lekoviBezAlergena;
        }

        public Boolean ProveraAlergicnosti(String idIzabranogPacijenta, String idLeka)
        {
            Pacijent izabranPacijent = naloziPacijenataServis.PretraziPoId(idIzabranogPacijenta);

            foreach (Alergeni a in izabranPacijent.ZdravstveniKarton.Alergeni)
            {
                if (a.IdAlergena.Equals(idLeka))
                {
                    return true;
                }
            }

            return false;
        }

        public void DodajRecept(String idPacijenta, Recept novRecept)
        {
            Pacijent p = naloziPacijenataServis.PretraziPoId(idPacijenta);
            p.ZdravstveniKarton.Recepti.Add(novRecept);

            naloziPacijenataServis.IzmeniPacijentaSaKorisnickim(p.KorisnickoIme, p);
        }



        public void DodajAnamnezu(Anamneza novaAnamneza)
        {
            Pacijent p = naloziPacijenataServis.PretraziPoId(novaAnamneza.IdPacijenta);
            p.ZdravstveniKarton.Anamneze.Add(novaAnamneza);

            naloziPacijenataServis.IzmeniPacijentaSaKorisnickim(p.KorisnickoIme, p);

        }

        public void DodajUput(String idPacijenta, Uput noviUput)
        {
            Pacijent p = naloziPacijenataServis.PretraziPoId(idPacijenta);
            p.ZdravstveniKarton.Uputi.Add(noviUput);

            naloziPacijenataServis.IzmeniPacijentaSaKorisnickim(p.KorisnickoIme, p);
        }

        public void IzmeniUput(String idPacijenta, Uput izmenjenUput)
        {
            Pacijent p = naloziPacijenataServis.PretraziPoId(idPacijenta);

            foreach (Uput u in p.ZdravstveniKarton.Uputi)
            {
                if (u.IDUputa.Equals(izmenjenUput.IDUputa))
                {
                    p.ZdravstveniKarton.Uputi.Remove(u);
                    break;
                }
            }
            p.ZdravstveniKarton.Uputi.Add(izmenjenUput);

            naloziPacijenataServis.IzmeniPacijentaSaKorisnickim(p.KorisnickoIme, p);
        }

        public List<Recept> DobaviReceptePacijenta(String idPacijenta)
        {
            Pacijent p = naloziPacijenataServis.PretraziPoId(idPacijenta);
            List<Recept> receptiPacijenta = new List<Recept>();

            foreach (Recept r in p.ZdravstveniKarton.Recepti)
            {
                receptiPacijenta.Add(r);
            }
            return receptiPacijenta;
        }


        public List<Uput> DobaviUputePacijenta(String idPacijenta)
        {
            Pacijent p = naloziPacijenataServis.PretraziPoId(idPacijenta);
            List<Uput> uputiPacijenta = new List<Uput>();

            foreach (Uput u in p.ZdravstveniKarton.Uputi)
            {
                uputiPacijenta.Add(u);
            }
            return uputiPacijenta;
        }

        public List<Anamneza> DobaviAnamnezePacijenta(String idPacijenta)
        {
            Pacijent p = naloziPacijenataServis.PretraziPoId(idPacijenta);
            List<Anamneza> anamnezePacijenta = new List<Anamneza>();

            foreach (Anamneza a in p.ZdravstveniKarton.Anamneze)
            {
                anamnezePacijenta.Add(a);
            }
            return anamnezePacijenta;
        }

        public List<Terapija> DobaviSveTerapijePacijenta(String idPacijenta)
        {
            List<Terapija> terapijePacijenta = new List<Terapija>();
            foreach (Anamneza anamneza in DobaviSveAnamnezePacijenta(idPacijenta))
            {
                foreach (Terapija t in anamneza.Terapije)
                    terapijePacijenta.Add(t);
            }

            return UkloniStareTerapije(terapijePacijenta);
        }

        private List<Anamneza> DobaviSveAnamnezePacijenta(String idPacijenta)
        {
            Pacijent pacijent = naloziPacijenataServis.PretraziPoId(idPacijenta);
            List<Anamneza> anamnezePacijenta = new List<Anamneza>();
            foreach (Anamneza anamneza in pacijent.ZdravstveniKarton.Anamneze)
            {
                if (anamneza.IdPacijenta.Equals(pacijent.KorisnickoIme))
                    anamnezePacijenta.Add(anamneza);
            }

            return anamnezePacijenta;
        }

        private List<Terapija> UkloniStareTerapije(List<Terapija> sveTerapije)
        {
            List<Terapija> terapijeUSadasnjosti = new List<Terapija>();
            foreach (Terapija terapija in sveTerapije)
            {
                if (DatumTerapijeJeUSadasnjosti(terapija))
                    terapijeUSadasnjosti.Add(terapija);
            }
            return terapijeUSadasnjosti;
        }
        private bool DatumTerapijeJeUSadasnjosti(Terapija terapija)
        {
            if (DateTime.Compare(DateTime.Now.Date, terapija.KrajTerapije) <= 0) return true;
            return false;
        }


        public int DobaviBrojLekovaZaDatum(DateTime datum, String korisnickoIme)
        {
            int brojLekova = 0;
            List<DateTime> intervalTerapije = new List<DateTime>();
            foreach (Terapija terapija in DobaviSveTerapijePacijenta(korisnickoIme))
            {
                if (PogodnaTerapija(terapija, datum))
                    brojLekova++;
            }
            return brojLekova;
        }

        private bool PogodnaTerapija(Terapija terapija,DateTime datum)
        {
            List<DateTime> intervalTerapije = new List<DateTime>();
            intervalTerapije.Add(terapija.PocetakTerapije);
            intervalTerapije.Add(terapija.KrajTerapije);
            if (TerapijaPripadaDatumu(intervalTerapije, datum))
                return true;
            return false;
        }

        public List<Terapija> DobaviSveTerapijeIzvestaja(List<DateTime> vremenskiInterval,String korisnickoIme)
        {
            List<Terapija> sveTerapije = new List<Terapija>();
            List<DateTime> intervalTerapije = new List<DateTime>();
           
            foreach (Terapija terapija in DobaviSveTerapijePacijenta(korisnickoIme))
            {
                intervalTerapije.Add(terapija.PocetakTerapije);
                intervalTerapije.Add(terapija.KrajTerapije);
                if (TerapijaJeUIntervalu(vremenskiInterval,intervalTerapije))
                {
                    sveTerapije.Add(terapija);
                }
                intervalTerapije.Clear();
            }

            return sveTerapije;
        }
        

        public bool TerapijaJeUIntervalu(List<DateTime> vremenskiInterval,List<DateTime>intervalTerapije)
        {
            DateTime pocetakIntervala = vremenskiInterval[0];
            DateTime krajIntervala = vremenskiInterval[1];
            DateTime pocetakTerapije = intervalTerapije[0];
            DateTime krajTerapije = intervalTerapije[1];
            return !((krajIntervala < pocetakTerapije && pocetakIntervala < pocetakTerapije) ||
                        (krajTerapije < pocetakIntervala && pocetakTerapije < pocetakIntervala));
        }

        public bool TerapijaPripadaDatumu(List<DateTime> intervalTerapije,DateTime datumZaPoredjenje)
        {
            return datumZaPoredjenje >= intervalTerapije[0] && datumZaPoredjenje <= intervalTerapije[1];
        }

    }
}
