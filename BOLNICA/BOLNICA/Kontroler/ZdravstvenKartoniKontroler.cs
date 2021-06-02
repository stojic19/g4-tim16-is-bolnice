using Bolnica.DTO;
using Bolnica.Konverter;
using Bolnica.Model;
using Model;
using System;
using System.Collections.Generic;

namespace Bolnica.Kontroler
{
    public class ZdravstvenKartoniKontroler
    {
        ZdravstveniKartoniServis zdravstveniKartoniServis = new ZdravstveniKartoniServis();
        ReceptKonverter receptKonverter = new ReceptKonverter();
        AnamnezaKonverter anamnezaKonverter = new AnamnezaKonverter();
        UputKonverter uputiKonverter = new UputKonverter();
        LekKonverter lekoviKonverter = new LekKonverter();
        TerapijaKonverter terapijaKonverter = new TerapijaKonverter();

        public List<LekDTO> DobaviLekoveBezAlergena(String idIzabranogPacijenta)
        {
            List<LekDTO> lekoviBezAlergena = new List<LekDTO>();
            foreach (Lek l in zdravstveniKartoniServis.DobaviLekoveBezAlergena(idIzabranogPacijenta))
            {
                lekoviBezAlergena.Add(lekoviKonverter.LekModelULekDTO(l));
            }
            return lekoviBezAlergena;
        }
        public Boolean ProveraAlergicnosti(String idIzabranogPacijenta, String idLeka)
        {
            return zdravstveniKartoniServis.ProveraAlergicnosti(idIzabranogPacijenta, idLeka);
        }

        public void DodajRecept(String idPacijenta, ReceptDTO novRecept)
        {
            zdravstveniKartoniServis.DodajRecept(idPacijenta, receptKonverter.ReceptDTOuModel(novRecept));
        }

        public List<TerapijaDTO> DobaviSveTerapijePacijenta(String idPacijenta)
        {
            List<TerapijaDTO> terapijePacijenta = new List<TerapijaDTO>();
            foreach (Terapija terapija in zdravstveniKartoniServis.DobaviSveTerapijePacijenta(idPacijenta))
                terapijePacijenta.Add(terapijaKonverter.TerapijaModelUDTO(terapija));
            return terapijePacijenta;
        }

        public void DodajAnamnezu(AnamnezaDTO novaAnamneza)
        {
            zdravstveniKartoniServis.DodajAnamnezu(anamnezaKonverter.AnamnezaSaLekaromUModel(novaAnamneza));
        }

        public void DodajUput(String idPacijenta, UputDTO noviUput)
        {
            zdravstveniKartoniServis.DodajUput(idPacijenta, uputiKonverter.UputDTOuModel(noviUput));
        }

        public void IzmeniUput(String idPacijenta, UputDTO izmenjenUput)
        {
            zdravstveniKartoniServis.IzmeniUput(idPacijenta, uputiKonverter.UputDTOuModel(izmenjenUput));
        }

        public List<ReceptDTO> DobaviReceptePacijenta(String idPacijenta)
        {
            List<ReceptDTO> receptiPacijenta = new List<ReceptDTO>();

            foreach (Recept r in zdravstveniKartoniServis.DobaviReceptePacijenta(idPacijenta))
            {
                receptiPacijenta.Add(receptKonverter.ReceptModelUDTO(r));
            }

            return receptiPacijenta;
        }

        public List<AnamnezaDTO> DobaviAnamnezePacijenta(String idPacijenta)
        {
            List<AnamnezaDTO> anamnezePacijenta = new List<AnamnezaDTO>();

            foreach (Anamneza a in zdravstveniKartoniServis.DobaviAnamnezePacijenta(idPacijenta))
            {
                anamnezePacijenta.Add(anamnezaKonverter.AnamnezaSaLekaromUDTO(a));
            }

            return anamnezePacijenta;
        }

        public List<UputDTO> DobaviUputePacijenta(String idPacijenta)
        {
            List<UputDTO> uputiPacijenta = new List<UputDTO>();

            foreach (Uput u in zdravstveniKartoniServis.DobaviUputePacijenta(idPacijenta))
            {
                uputiPacijenta.Add(uputiKonverter.UputModelUDTO(u));
            }

            return uputiPacijenta;
        }
        public int DobaviBrojLekovaZaDatum(DateTime datum, String korisnickoIme)
        {
            return zdravstveniKartoniServis.DobaviBrojLekovaZaDatum(datum,korisnickoIme);
        }


        public List<TerapijaDTO> DobaviSveTerapijeZaIzvestaj(List<DateTime> vremenskiInterval, String korisnickoIme)
        {
            List<TerapijaDTO> terapijeZaIzvestaj = new List<TerapijaDTO>();
            foreach (Terapija terapija in zdravstveniKartoniServis.DobaviSveTerapijeIzvestaja(vremenskiInterval, korisnickoIme))
            {
                terapijeZaIzvestaj.Add(terapijaKonverter.TerapijaModelUDTO(terapija));
            }

            if (terapijeZaIzvestaj.Count == 0)
                Console.WriteLine("sve je prazno kontroler");
            return terapijeZaIzvestaj;
        }
    }
}
