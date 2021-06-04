// File:    RukovanjeObavestenjimaSekratar.cs
// Author:  aleks
// Created: Sunday, April 11, 2021 10:56:39
// Purpose: Definition of Class RukovanjeObavestenjimaSekratar

using Bolnica;
using Bolnica.DTO;
using Bolnica.Repozitorijum;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Model
{
   public class ObavestenjaServis
   {
        ObavestenjaRepozitorijum obavestenjaRepozitorijum = new ObavestenjaRepozitorijum();

      public void DodajObavestenje(Obavestenje obavestenje)
      {
            obavestenjaRepozitorijum.DodajObjekat(obavestenje);
        }

        public Obavestenje DodajObavestenjePacijentu(Obavestenje obavestenje)
        {
            obavestenjaRepozitorijum.DodajObjekat(obavestenje);

            if (SvaObavestenja().Contains(obavestenje))
            {
                return obavestenje;
            }
            else
            {
                return null;
            }
        }

        public void IzmeniObavestenje(Obavestenje obavestenje)
        {
            Obavestenje obavestenjeAzurirano = obavestenjaRepozitorijum.PretraziObavestenjaPoId(obavestenje.IdObavestenja);

            obavestenjeAzurirano.Naslov = obavestenje.Naslov;
            obavestenjeAzurirano.Tekst = obavestenje.Tekst;
            obavestenjeAzurirano.IdPrimaoca = obavestenje.IdPrimaoca;

            obavestenjaRepozitorijum.IzmeniObavestenje(obavestenjeAzurirano);
        }

        public void UkolniObavestenje(String idObavestenja)
        {
            Obavestenje obavestenje = obavestenjaRepozitorijum.PretraziObavestenjaPoId(idObavestenja);

            obavestenjaRepozitorijum.ObrisiObjekat("//ArrayOfObavestenje/Obavestenje[IdObavestenja='" + idObavestenja + "']");
        }

        public Obavestenje PretraziObavestenjaPoId(String idObavestenja)
        {
            return obavestenjaRepozitorijum.PretraziObavestenjaPoId(idObavestenja);
        }
      
        public List<Obavestenje> SvaObavestenja()
        {
            return obavestenjaRepozitorijum.DobaviSveObjekte();
        }
        public List<Obavestenje> DobaviSvaObavestenjaOsobe(String IdOsobe)
        {
            return obavestenjaRepozitorijum.DobaviSvaObavestenjaOsobe(IdOsobe);
        }

        public void DodajPodsetnikOAnamnezi(PodsetnikDTO podsetnik, String idPacijenta)
        {
            int intervalObavestenja = (int)(podsetnik.DatumDo - podsetnik.DatumOd).TotalDays + 1;
            for (int i = 0; i < intervalObavestenja; i++)
            {
               DateTime  datumObavestenja = podsetnik.DatumOd.AddDays(i);
               DateTime formatiranDatum = new DateTime(datumObavestenja.Year, datumObavestenja.Month, datumObavestenja.Day, podsetnik.Vreme.Hour, podsetnik.Vreme.Minute, 0);
               Obavestenje novoObavestenje = new Obavestenje(podsetnik.Naslov, podsetnik.Tekst, formatiranDatum, idPacijenta);
               DodajObavestenjePacijentu(novoObavestenje);
            }
        }
        public void DodajObavestenjeOZakazanomPregledu(String idPacijenta, Termin termin)
        {
            String TekstObavestenja= "Termin pregleda kod lekara \n " + termin.Lekar.Ime+" "+termin.Lekar.Prezime
                + " \n biće održan " + termin.Datum.ToString("dd/MM/yyyy") + " u " + termin.PocetnoVreme + "h. ";
            DodajObavestenjePacijentu(new Obavestenje("Obaveštenje o zakazanom pregledu", TekstObavestenja, termin.Datum.AddDays(-2), idPacijenta));
        }
        public void DodajObavestenjeOPomerenomPregledu(Termin noviTermin, Termin stariTermin)
        {
            String TekstObavestenja = "Upravo ste pomerili pregled \nkod lekara " + stariTermin.Lekar.Ime + " " + stariTermin.Lekar.Prezime
                + "\n" + stariTermin.Datum.ToString("dd/MM/yyyy") + " u " + stariTermin.PocetnoVreme + "h. \nNovi pregled je zakazan kod lekara \n"
                + noviTermin.Lekar.Ime+" "+noviTermin.Lekar.Prezime+ "\n" + noviTermin.Datum.ToString("dd/MM/yyyy") + " u " + noviTermin.PocetnoVreme+" h.";
            DodajObavestenjePacijentu(new Obavestenje("Obaveštenje o pomerenom pregledu", TekstObavestenja, DateTime.Now, noviTermin.Pacijent.KorisnickoIme));
        }

        public void DodajObavestenjeOTerapiji(Terapija terapija,String korisnickoIme)
        {
            int intervalObavestenja = (int)(terapija.KrajTerapije - terapija.PocetakTerapije).TotalDays + 1;
            String sadrzaj = "Terapija: " + terapija.PreporucenLek.NazivLeka + terapija.PreporucenLek.Jacina +
               "\ndnevna količina: " + terapija.Kolicina + ",\nvremenski interval između doza:\n " + terapija.Satnica + "h.";
            for (int i = 0; i < intervalObavestenja; i++)
            {
                DateTime datumObavestenja = terapija.PocetakTerapije.AddDays(i);
                DateTime formatiranDatum = new DateTime(datumObavestenja.Year, datumObavestenja.Month, datumObavestenja.Day, 8, 0, 0);
                Obavestenje novoObavestenje = new Obavestenje("Podsetnik o terapiji", sadrzaj, formatiranDatum, korisnickoIme);
                DodajObavestenjePacijentu(novoObavestenje);
            }
        }

    }
}