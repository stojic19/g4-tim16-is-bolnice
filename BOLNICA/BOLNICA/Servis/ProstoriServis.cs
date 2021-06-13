using Bolnica;
using Bolnica.Kontroler;
using Bolnica.Model;
using Bolnica.Repozitorijum;
using Bolnica.Servis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Model
{
    public class ProstoriServis
    {
        ZakazaniTerminiServis terminiServis = new ZakazaniTerminiServis();
        ProstoriRepozitorijum prostoriRepozitorijum = new ProstoriRepozitorijum();
        RenoviranjeServis renoviranjeServis = new RenoviranjeServis();
        //public static List<Oprema> oprema = new List<Oprema>();

        public Prostor DodeliProstorZaTermin(DateTime datum)
        {
            List<Termin> termini = DobaviZakazaneTermineZaVreme(datum);
            foreach (Prostor prostor in SviProstori())
            {
                if (prostor.VrstaProstora == VrsteProstora.ordinacija)
                {
                    bool zauzet = false;
                    foreach (Termin terminZaProveru in termini)
                    {
                        if (terminZaProveru.Prostor.IdProstora.Equals(prostor.IdProstora))
                        {
                            zauzet = true;
                            break;
                        }
                    }
                    if (!zauzet)
                    {
                        return prostor;
                    }
                }
            }
            return null;
        }
        public Prostor DodeliProstorZaOperaciju(DateTime datum)
        {
            List<Termin> termini = DobaviZakazaneTermineZaVreme(datum);
            foreach (Prostor prostor in SviProstori())
            {
                if (prostor.VrstaProstora == VrsteProstora.sala)
                {
                    bool zauzet = false;
                    foreach (Termin terminZaProveru in termini)
                    {
                        if (terminZaProveru.Prostor.IdProstora.Equals(prostor.IdProstora))
                        {
                            zauzet = true;
                            break;
                        }
                    }
                    if (!zauzet)
                    {
                        return prostor;
                    }
                }
            }
            return null;
        }
        public List<Termin> DobaviZakazaneTermineZaVreme(DateTime datum)
        {
            List<Termin> termini = new List<Termin>();
            foreach (Termin termin in terminiServis.DobaviSveZakazaneTermine())
            {
                if (DateTime.Compare(termin.Datum, datum) == 0)
                {
                    termini.Add(termin);
                }
            }
            return termini;
        }

        public void DodajProstor(Prostor p)
        {
            prostoriRepozitorijum.DodajObjekat(p);
        }


        public void IzmeniProstor(Prostor noviPodaci)
        {
            Prostor p = prostoriRepozitorijum.PretraziProstorPoId(noviPodaci.IdProstora);

            p.NazivProstora = noviPodaci.NazivProstora;
            p.VrstaProstora = noviPodaci.VrstaProstora;
            p.Sprat = noviPodaci.Sprat;
            p.Kvadratura = noviPodaci.Kvadratura;

            prostoriRepozitorijum.IzmenaProstora(p);

        }

        public void UkloniProstor(String idProstora)
        {
            prostoriRepozitorijum.ObrisiObjekat("//ArrayOfProstor/Prostor[IdProstora='" + idProstora + "']");
        }

        public Prostor PretraziPoId(String idProstora)
        {
            return prostoriRepozitorijum.PretraziProstorPoId(idProstora);
        }

        public Boolean ProvjeriValidnostNaziva(String nazivProstora)
        {
            foreach(Prostor p in prostoriRepozitorijum.DobaviSveObjekte())
            {
                if (p.NazivProstora.Equals(nazivProstora))
                {
                    System.Windows.MessageBox.Show("Postoji prostor sa takvim nazivom!");
                    return false;
                }
            }
            return true;
        }

        public void ProvjeriDaLiJeProstorRenoviran()
        {
            foreach (Renoviranje r in renoviranjeServis.SvaRenoviranja())
            {
                if (DateTime.Compare(DateTime.Now.Date, r.DatumKraja.Date) >= 0)
                {
                    foreach (Prostor p in r.ProstoriKojiSeBrisu)
                    {
                        UkloniProstor(p.IdProstora);
                    }

                    foreach (Prostor p in r.ProstoriKojiSeDodaju)
                    {
                        DodajProstor(p);
                    }

                    renoviranjeServis.UkloniRenoviranje(r);
                }

            }

        }

        public List<Prostor> SviProstori()
        {
            return prostoriRepozitorijum.DobaviSveObjekte();
        }

        public void OduzmiKolicinuOpreme(Prostor prostorIzKojegPremjestamo, Oprema oprema, int kolicina)
        {
            foreach (Oprema o in prostorIzKojegPremjestamo.Oprema)
            {
                if (o.NazivOpreme.Equals(oprema.NazivOpreme))
                {
                    o.Kolicina -= kolicina;
                }
            }

            if (oprema.NazivOpreme.Equals("krevet"))
                prostorIzKojegPremjestamo.BrojSlobodnihKreveta -= kolicina;

            prostoriRepozitorijum.IzmenaProstora(prostorIzKojegPremjestamo);

        }

        public void PremjestiOpremuUDrugiProstor(Prostor prostorUKojiPremjestamo, Oprema oprema, int kolicina)
        {

            if (!DodajSamoKolicinu(prostorUKojiPremjestamo, oprema, kolicina))
            {
                Oprema o = new Oprema(oprema.IdOpreme, oprema.NazivOpreme, oprema.VrstaOpreme, kolicina);
                DodajOpremuProstoru(prostorUKojiPremjestamo, o);
            }
            if (oprema.NazivOpreme.Equals("krevet"))
                prostorUKojiPremjestamo.BrojSlobodnihKreveta += kolicina;

            prostoriRepozitorijum.IzmenaProstora(prostorUKojiPremjestamo);
        }

        public bool DodajSamoKolicinu(Prostor prostorUKojiPrebacujemo, Oprema oprema, int kolicina)
        {
            foreach (Oprema o in prostorUKojiPrebacujemo.Oprema)
            {
                if (o == oprema)
                {
                    o.Kolicina += kolicina;
                    if (oprema.NazivOpreme.Equals("krevet"))
                    {
                        prostorUKojiPrebacujemo.BrojSlobodnihKreveta += kolicina;
                    }
                    prostoriRepozitorijum.IzmenaProstora(prostorUKojiPrebacujemo);
                    return true;
                }

            }
            return false;
        }


        public void DodajOpremuProstoru(Prostor prostorUKojiPrebacujemo, Oprema o)
        {
            prostorUKojiPrebacujemo.Oprema.Add(o);
            prostoriRepozitorijum.IzmenaProstora(prostorUKojiPrebacujemo);
        }


        public bool ProvjeriZakazaneTermine(DateTime pocetniDatum, DateTime zavrsniDatum)
        {
            foreach (Termin t in terminiServis.DobaviSveZakazaneTermine())
            {
                if (t.Datum >= pocetniDatum && t.Datum <= zavrsniDatum)
                {
                    return true;
                }
            }
            return false;
        }

        public List<Prostor> DobaviSlobodneSobe(DateTime krajLecenja)
        {
            List<Prostor> slobodneSobe = new List<Prostor>();

            foreach (Prostor p in prostoriRepozitorijum.DobaviSveObjekte())
            {
                if (!p.JeRenoviranje && p.VrstaProstora.Equals(VrsteProstora.soba) && p.BrojSlobodnihKreveta > 0 && !ProveraRenoviranjaUBuducnosti(p.IdProstora,krajLecenja))
                {
                    slobodneSobe.Add(p);

                }
            }

            return slobodneSobe;
        }

        public bool ProveraRenoviranjaUBuducnosti(String idProstora, DateTime krajLecenja)
        {
            foreach (Renoviranje r in renoviranjeServis.SvaRenoviranja())
            {
                if (r.Prostor.IdProstora.Equals(idProstora) && DateTime.Compare(r.PocetniDatum, krajLecenja) <= 0)
                    return true;
            }

            return false;

        }


        public void SmanjiBrojSlobodnihKreveta(String idProstora)
        {
            Prostor zaIzmenu = prostoriRepozitorijum.PretraziProstorPoId(idProstora);
            zaIzmenu.BrojSlobodnihKreveta--;
            prostoriRepozitorijum.IzmenaProstora(zaIzmenu);
        }

    }
}