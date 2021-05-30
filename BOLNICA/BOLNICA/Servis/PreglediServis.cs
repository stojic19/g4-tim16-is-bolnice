using Bolnica.Repozitorijum;
using Bolnica.Repozitorijum.Interfejsi;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bolnica.Model.Rukovanja
{
    class PreglediServis
    {
        private PreglediRepozitorijumInterfejs preglediRepozitorijum = new PreglediRepozitorijum();
        ZakazaniTerminiServis terminiServis = new ZakazaniTerminiServis();
        public List<Pregled> DobaviSvePreglede()
        {
            return preglediRepozitorijum.DobaviSveObjekte();
        }

        public List<Pregled> SortPoDatumuPregleda()
        {
            return preglediRepozitorijum.SortPoDatumuPregleda();
        }

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

        public void UklanjanjeAnamneze(String idIzabranogPregleda)
        {
            Pregled pregledZaIzmenu = preglediRepozitorijum.DobaviPregledPoId(idIzabranogPregleda);
            pregledZaIzmenu.Odrzan = true;
            pregledZaIzmenu.Anamneza = null;

            preglediRepozitorijum.IzmeniPregled(pregledZaIzmenu);
        }

        public Pregled PretragaPoAnamnezi(String idAnamneze)
        {
            return preglediRepozitorijum.PretraziPoAnamnezi(idAnamneze);
        }

        public List<Pregled> DobaviSveObavljenePregledePacijenta(String korisnickoIme)
        {
            return preglediRepozitorijum.DobaviSvePregledePacijenta(korisnickoIme);
        }
    }
}
