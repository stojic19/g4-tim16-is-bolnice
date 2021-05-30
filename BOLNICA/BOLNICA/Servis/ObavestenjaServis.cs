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

    }
}