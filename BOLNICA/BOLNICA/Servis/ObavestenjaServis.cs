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

      public static Obavestenje DodajObavestenje(Obavestenje obavestenje)
      {
            ObavestenjaRepozitorijum.DodajObavestenje(obavestenje);
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

        public static Obavestenje DodajObavestenjePacijentu(Obavestenje obavestenje)
        {
            ObavestenjaRepozitorijum.DodajObavestenje(obavestenje);

            if (SvaObavestenja().Contains(obavestenje))
            {
                return obavestenje;
            }
            else
            {
                return null;
            }
        }

        public static Boolean IzmeniObavestenje(Obavestenje obavestenje)
        {
            Obavestenje obavestenjeAzurirano = PretraziPoId(obavestenje.IdObavestenja);

            obavestenjeAzurirano.Naslov = obavestenje.Naslov;
            obavestenjeAzurirano.Tekst = obavestenje.Tekst;
            obavestenjeAzurirano.IdPrimaoca = obavestenje.IdPrimaoca;

            // AzurirajObavestenjeUPrikazu(obavestenjeAzurirano);

            ObavestenjaRepozitorijum.IzmeniObavestenje(obavestenjeAzurirano);

            return true;
        }

        private static void AzurirajObavestenjeUPrikazu(Obavestenje obavestenje)
        {
            int indeks = ObavestenjaSekretar.SvaObavestenja.IndexOf(obavestenje);
            ObavestenjaSekretar.SvaObavestenja.RemoveAt(indeks);
            ObavestenjaSekretar.SvaObavestenja.Insert(indeks, obavestenje);
        }

        public static Boolean UkolniObavestenje(String idObavestenja)
        {
            Obavestenje obavestenje = PretraziPoId(idObavestenja);

            if (obavestenje == null)
            {
                return false;
            }

            ObavestenjaRepozitorijum.ObrisiObavestenje(obavestenje);
            ObavestenjaSekretar.SvaObavestenja.Remove(obavestenje);

            return !DaLiListeSadrzeObavestenje(obavestenje);
        }
        private static bool DaLiListeSadrzeObavestenje(Obavestenje obavestenje)
        {
            return SvaObavestenja().Contains(obavestenje) || ObavestenjaSekretar.SvaObavestenja.Contains(obavestenje);
        }

        public static Obavestenje PretraziPoId(String idObavestenja)
        {
            foreach (Obavestenje o in ObavestenjaRepozitorijum.DobaviSvaObavestenja())
            {
                if (o.IdObavestenja.Equals(idObavestenja))
                {
                    return o;
                }
            }
            return null;
        }
      
      public static List<Obavestenje> SvaObavestenja()
      {
            return ObavestenjaRepozitorijum.DobaviSvaObavestenja();
      }

    }
}