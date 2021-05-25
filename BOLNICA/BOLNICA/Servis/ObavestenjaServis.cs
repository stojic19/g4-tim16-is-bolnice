// File:    RukovanjeObavestenjimaSekratar.cs
// Author:  aleks
// Created: Sunday, April 11, 2021 10:56:39
// Purpose: Definition of Class RukovanjeObavestenjimaSekratar

using Bolnica;
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

      public Obavestenje DodajObavestenje(Obavestenje obavestenje)
      {
            obavestenjaRepozitorijum.DodajObjekat(obavestenje);
            ObavestenjaSekretar.SvaObavestenja.Add(obavestenje);

            if (SvaObavestenja().Contains(obavestenje))
            {
                return obavestenje;
            }
            else
            {
                return null;
            }
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

        public Boolean IzmeniObavestenje(Obavestenje obavestenje)
        {
            Obavestenje obavestenjeAzurirano = PretraziPoId(obavestenje.IdObavestenja);

            obavestenjeAzurirano.Naslov = obavestenje.Naslov;
            obavestenjeAzurirano.Tekst = obavestenje.Tekst;
            obavestenjeAzurirano.IdPrimaoca = obavestenje.IdPrimaoca;

            // AzurirajObavestenjeUPrikazu(obavestenjeAzurirano);

            obavestenjaRepozitorijum.IzmeniObavestenje(obavestenjeAzurirano);

            return true;
        }

        private void AzurirajObavestenjeUPrikazu(Obavestenje obavestenje)
        {
            int indeks = ObavestenjaSekretar.SvaObavestenja.IndexOf(obavestenje);
            ObavestenjaSekretar.SvaObavestenja.RemoveAt(indeks);
            ObavestenjaSekretar.SvaObavestenja.Insert(indeks, obavestenje);
        }

        public Boolean UkolniObavestenje(String idObavestenja)
        {
            Obavestenje obavestenje = PretraziPoId(idObavestenja);

            if (obavestenje == null)
            {
                return false;
            }

            obavestenjaRepozitorijum.ObrisiObjekat("//ArrayOfObavestenje/Obavestenje[IdObavestenja='" + idObavestenja + "']");
            ObavestenjaSekretar.SvaObavestenja.Remove(obavestenje);

            return !DaLiListeSadrzeObavestenje(obavestenje);
        }
        private bool DaLiListeSadrzeObavestenje(Obavestenje obavestenje)
        {
            return SvaObavestenja().Contains(obavestenje) || ObavestenjaSekretar.SvaObavestenja.Contains(obavestenje);
        }

        public Obavestenje PretraziPoId(String idObavestenja)
        {
            return obavestenjaRepozitorijum.PretraziPoId("//ArrayOfObavestenje/Obavestenje[IdObavestenja='" + idObavestenja + "']");
        }
      
      public List<Obavestenje> SvaObavestenja()
      {
            return obavestenjaRepozitorijum.DobaviSveObjekte();
      }

    }
}