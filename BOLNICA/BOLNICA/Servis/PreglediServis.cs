using Bolnica.Repozitorijum;
using Bolnica.Repozitorijum.Interfejsi;
using Model;
using System;
using System.Collections.Generic;

namespace Bolnica.Model.Rukovanja
{
    class PreglediServis
    {
        private PreglediRepozitorijumInterfejs preglediRepozitorijum = new PreglediRepozitorijum();
        ZakazaniTerminiServis terminiServis = new ZakazaniTerminiServis();
       
        public Pregled PretraziPoId(String idPregleda)
        {
            return preglediRepozitorijum.DobaviPregledPoId(idPregleda);
        }

        public Pregled PristupPregledu(String idTermina)
        {
            Pregled noviPregled = preglediRepozitorijum.PretragaPoTerminu(idTermina);

            if (noviPregled == null)
            {
                noviPregled = new Pregled(Guid.NewGuid().ToString(), terminiServis.DobaviZakazanTerminPoId(idTermina));
                preglediRepozitorijum.DodajObjekat(noviPregled);

            }
            return noviPregled;
        }

        public void UklanjanjePregleda(String terminOtkazanogPregleda)
        {
            Pregled pregledZaBrisanje = PretragaPoTerminu(terminOtkazanogPregleda);
            if (pregledZaBrisanje == null) return;
            preglediRepozitorijum.ObrisiObjekat("//ArrayOfPregled/Pregled[IdPregleda='" + pregledZaBrisanje.IdPregleda + "']");
        }

        public Pregled PretragaPoTerminu(String idTermina)
        {
            return preglediRepozitorijum.PretragaPoTerminu(idTermina);
        }

        public void DodajUput(String idIzabranogPregleda, Uput noviUput)
        {
            Pregled pregledZaIzmenu = preglediRepozitorijum.DobaviPregledPoId(idIzabranogPregleda);
            pregledZaIzmenu.Odrzan = true;
            pregledZaIzmenu.Uputi.Add(noviUput);

            preglediRepozitorijum.IzmeniPregled(pregledZaIzmenu);
        }

        public void DodajRecept(String idPregleda, Recept novRecept)
        {
            Pregled pregledZaIzmenu = preglediRepozitorijum.DobaviPregledPoId(idPregleda);
            pregledZaIzmenu.Odrzan = true;
            pregledZaIzmenu.Recepti.Add(novRecept);

            preglediRepozitorijum.IzmeniPregled(pregledZaIzmenu);
        }

        public void DodajAnamnezu(String idIzabranogPregleda, Anamneza novaAnamneza)
        {
            Pregled pregledZaIzmenu = preglediRepozitorijum.DobaviPregledPoId(idIzabranogPregleda);
            pregledZaIzmenu.Odrzan = true;
            pregledZaIzmenu.Anamneza = novaAnamneza;

            preglediRepozitorijum.IzmeniPregled(pregledZaIzmenu);
        }

        public List<Pregled> DobaviSveObavljenePregledePacijenta(String korisnickoIme)
        {
            return preglediRepozitorijum.DobaviSvePregledePacijenta(korisnickoIme);
        }

        public List<Pregled> DobaviSveNeocenjenePregledePacijenta(String korisnickoIme)
        {
            List<Pregled> neocenjeniPregledi = new List<Pregled>();
            foreach (Pregled pregled in preglediRepozitorijum.DobaviSvePregledePacijenta(korisnickoIme))
            {
                if (!pregled.OcenjenPregled && pregled.Termin != null)
                    neocenjeniPregledi.Add(pregled);
            }
            return neocenjeniPregledi;
        }

        public bool ProveraPostojanjaAnamneze(String idPregleda)
        {
            if (PretraziPoId(idPregleda).Anamneza == null) return false;
            return true;
        }
        public void PostaviOcenuPregledu(String idPregleda)
        {
            Pregled pregled = PretraziPoId(idPregleda);
            pregled.OcenjenPregled = true;
            preglediRepozitorijum.ObrisiPregled(idPregleda);
            preglediRepozitorijum.DodajObjekat(pregled);
        }
    }
}
