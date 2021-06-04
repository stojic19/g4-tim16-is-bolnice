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
            
            foreach(Uput u in p.ZdravstveniKarton.Uputi)
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
            foreach (Terapija terapija in DobaviSveTerapijePacijenta(korisnickoIme))
            {
                if (DateTime.Compare(terapija.PocetakTerapije, datum) <= 0 && DateTime.Compare(terapija.KrajTerapije, datum) >= 0)
                {
                    brojLekova++;
                }
            }
            return brojLekova;
        }


        public List<Terapija> DobaviSveTerapijeIzvestaja(List<DateTime> vremenskiInterval,String korisnickoIme)
        {
            List<Terapija> sveTerapije = new List<Terapija>();
            foreach (Terapija terapija in DobaviSveTerapijePacijenta(korisnickoIme))
            {
                if (DateTime.Compare(vremenskiInterval[0].Date,terapija.PocetakTerapije) <= 0 && DateTime.Compare(vremenskiInterval[1],terapija.KrajTerapije) >= 0)
                {
                    sveTerapije.Add(terapija);
                    
                }
            }

            return sveTerapije;
        }

    }
}
