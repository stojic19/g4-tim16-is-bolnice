// File:    RukovanjeObavestenjimaSekratar.cs
// Author:  aleks
// Created: Sunday, April 11, 2021 10:56:39
// Purpose: Definition of Class RukovanjeObavestenjimaSekratar

using Bolnica;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Model
{
   public class ObavestenjaServis
   {
      private static String imeFajla = "obavestenja.xml";
      public static List<Obavestenje> svaObavestenja = new List<Obavestenje>();
      
      public static Obavestenje DodajObavestenje(Obavestenje obavestenje)
      {
            svaObavestenja.Add(obavestenje);
            ObavestenjaSekretar.SvaObavestenja.Add(obavestenje);
            Console.WriteLine("Usao");
            Sacuvaj();

            if (svaObavestenja.Contains(obavestenje))
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
            svaObavestenja.Add(obavestenje);

            Sacuvaj();

            if (svaObavestenja.Contains(obavestenje))
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

            AzurirajObavestenjeUPrikazu(obavestenjeAzurirano);

            Sacuvaj();

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

            svaObavestenja.Remove(obavestenje);
            ObavestenjaSekretar.SvaObavestenja.Remove(obavestenje);

            Sacuvaj();

            return !DaLiListeSadrzeObavestenje(obavestenje);
        }
        private static bool DaLiListeSadrzeObavestenje(Obavestenje obavestenje)
        {
            return svaObavestenja.Contains(obavestenje) || ObavestenjaSekretar.SvaObavestenja.Contains(obavestenje);
        }

        public static Obavestenje PretraziPoId(String idObavestenja)
        {
            foreach (Obavestenje o in svaObavestenja)
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
            return svaObavestenja;
      }
        public static List<Obavestenje> Ucitaj()
        {
            if (File.ReadAllText(imeFajla).Trim().Equals(""))
            {
                return new List<Obavestenje>();
            }
            else
            {
                FileStream fileStream = File.OpenRead(imeFajla);
                XmlSerializer serializer = new XmlSerializer(typeof(List<Obavestenje>));
                svaObavestenja = (List<Obavestenje>)serializer.Deserialize(fileStream);
                fileStream.Close();
                return svaObavestenja;
            }
        }
        public static void Sacuvaj()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(List<Obavestenje>));
            TextWriter fileStream = new StreamWriter(imeFajla);
            serializer.Serialize(fileStream, svaObavestenja);
            fileStream.Close();
        }
    }
}