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
            return preglediRepozitorijum.PretraziPoId("//ArrayOfPregled/Pregled[IdPregleda='" + idPregleda + "']");
        }

        public Pregled PristupPregledu(Termin terminPregleda)
        {
            Pregled noviPregled = preglediRepozitorijum.PretraziPoId("//ArrayOfPregled/Pregled/Termin[IdTermina='" + terminPregleda.IdTermina + "']");

            if (noviPregled == null)
            {
                noviPregled = new Pregled(Guid.NewGuid().ToString(), terminPregleda);
                preglediRepozitorijum.DodajObjekat(noviPregled);

            }

            return noviPregled;

        }

        public void UklanjanjePregleda(String terminOtkazanogPregleda)
        {
            preglediRepozitorijum.ObrisiObjekat("//ArrayOfPregled/Pregled/Termin[IdTermina='" + terminOtkazanogPregleda + "']");
        }

        public Pregled PretragaPoTerminu(String idTermina)
        {
            return preglediRepozitorijum.PretraziPoId("//ArrayOfPregled/Pregled/Termin[IdTermina='" + idTermina + "']");
        }

        public void DodajUput(String idIzabranogPregleda, Uput noviUput)
        {
            Pregled pregledZaIzmenu = preglediRepozitorijum.PretraziPoId(idIzabranogPregleda);
            pregledZaIzmenu.Odrzan = true;
            pregledZaIzmenu.Uputi.Add(noviUput);

            preglediRepozitorijum.IzmeniPregled(pregledZaIzmenu);
        }

        public void DodajRecept(String idPregleda, Recept novRecept)
        {
            Pregled pregledZaIzmenu = preglediRepozitorijum.PretraziPoId(idPregleda);
            pregledZaIzmenu.Odrzan = true;
            pregledZaIzmenu.Recepti.Add(novRecept);

            preglediRepozitorijum.IzmeniPregled(pregledZaIzmenu);
        }

        public void DodajAnamnezu(String idIzabranogPregleda, Anamneza novaAnamneza)
        {
            Pregled pregledZaIzmenu = preglediRepozitorijum.PretraziPoId(idIzabranogPregleda);
            pregledZaIzmenu.Odrzan = true;
            pregledZaIzmenu.Anamneza = novaAnamneza;

            preglediRepozitorijum.IzmeniPregled(pregledZaIzmenu);
        }

        public void UklanjanjeAnamneze(String idIzabranogPregleda)
        {
            Pregled pregledZaIzmenu = preglediRepozitorijum.PretraziPoId(idIzabranogPregleda);
            pregledZaIzmenu.Odrzan = true;
            pregledZaIzmenu.Anamneza = null;

            preglediRepozitorijum.IzmeniPregled(pregledZaIzmenu);
        }

        public Pregled PretragaPoAnamnezi(String idAnamneze)
        {
            return preglediRepozitorijum.PretraziPoId("//ArrayOfPregled/Pregled/Anamneza[IdAnamneze='" + idAnamneze + "']");
        }
    }
}
