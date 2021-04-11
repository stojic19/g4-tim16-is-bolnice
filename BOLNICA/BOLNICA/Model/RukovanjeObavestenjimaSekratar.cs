// File:    RukovanjeObavestenjimaSekratar.cs
// Author:  aleks
// Created: Sunday, April 11, 2021 10:56:39
// Purpose: Definition of Class RukovanjeObavestenjimaSekratar

using Bolnica;
using System;
using System.Collections.Generic;

namespace Model
{
   public class RukovanjeObavestenjimaSekratar
   {
      private String imeFajla;
      public static List<Obavestenje> svaObavestenja = new List<Obavestenje>();
      
      public static Obavestenje DodajObavestenje(Obavestenje o)
      {
            svaObavestenja.Add(o);
            ObavestenjaSekretar.SvaObavestenja.Add(o);

            foreach (Obavestenje oba in svaObavestenja)
            {
                Console.WriteLine(oba.IdObavestenja);
            }
            //Sacuvaj();

            if (svaObavestenja.Contains(o))
            {
                return o;
            }
            else
            {
                return null;
            }
        }
      
      public static Boolean IzmeniObavestenje(Obavestenje o)
      {
           Obavestenje o1 = PretraziPoId(o.IdObavestenja);

            o1.Naslov = o.Naslov;
            o1.Tekst = o.Tekst;

            int indeks = ObavestenjaSekretar.SvaObavestenja.IndexOf(o1);
            ObavestenjaSekretar.SvaObavestenja.RemoveAt(indeks);
            ObavestenjaSekretar.SvaObavestenja.Insert(indeks, o1);

            //Sacuvaj();

            return true;
        }
      
      public static Boolean UkolniObavestenje(String idObavestenja)
      {
            Obavestenje o = PretraziPoId(idObavestenja);

            if (o == null)
            {
                return false;
            }

            svaObavestenja.Remove(o);
            ObavestenjaSekretar.SvaObavestenja.Remove(o);

            //Sacuvaj();

            if (svaObavestenja.Contains(o) || ObavestenjaSekretar.SvaObavestenja.Contains(o))
            {
                return false;
            }
            else
            {
                return true;
            }
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
      
      public static List<Obavestenje> SvaObavestenja(String idKorisnika)
      {
            return svaObavestenja;
      }
   
   }
}