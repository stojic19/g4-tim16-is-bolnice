
using Bolnica;
using Bolnica.Interfejsi.Sekretar;
using Bolnica.Model.Rukovanja;
using Bolnica.Repozitorijum;
using System;
using System.Collections.Generic;

namespace Model
{
    public class NaloziPacijenataServis : CRUDInterfejs<Pacijent>
    {
        private NaloziPacijenataRepozitorijum naloziPacijenataRepozitorijum = new NaloziPacijenataRepozitorijum();

        public void Dodaj(Pacijent pacijentZaDodavanje)
        {
            naloziPacijenataRepozitorijum.DodajObjekat(pacijentZaDodavanje);
        }

        public void Izmeni(Pacijent pacijentZaIZmenu)
        {     
            naloziPacijenataRepozitorijum.IzmeniPacijenta(pacijentZaIZmenu);
        }

        public void Ukloni(Pacijent pacijent)
        {
            naloziPacijenataRepozitorijum.ObrisiObjekat("//ArrayOfPacijent/Pacijent[KorisnickoIme='" + pacijent.KorisnickoIme + "']");
        }

        
        public Pacijent PretraziPoId(String idNaloga)
        {
            return naloziPacijenataRepozitorijum.PretraziPoId("//ArrayOfPacijent/Pacijent[KorisnickoIme='" + idNaloga + "']");
        }
        public List<Pacijent> DobaviSve()
        {
            return naloziPacijenataRepozitorijum.DobaviSveObjekte();
        }

        public void IzmeniStanjeNalogaPacijenta(Pacijent pacijent)
        {
            int broj = pacijent.ZloupotrebioSistem + 1;
            pacijent.ZloupotrebioSistem = broj;
            if (PrekoracioBrojZloupotreba(pacijent))
            {
                BlokirajNalogPacijenta(pacijent);
                return;
            }
            naloziPacijenataRepozitorijum.IzmeniPacijenta(pacijent);
        }
        private void BlokirajNalogPacijenta(Pacijent pacijent)
        {
            pacijent.Blokiran = true;
            pacijent.PoslednjaZloupotreba = DateTime.Now.Date;
            naloziPacijenataRepozitorijum.IzmeniPacijenta(pacijent);
        }
        private bool PrekoracioBrojZloupotreba(Pacijent pacijent)
        {
            if (pacijent.ZloupotrebioSistem > 5)
                return true;
            return false;
        }



        //
        public bool NalogJeBlokiran(String korisnickoIme)
        {
            if (PretraziPoId(korisnickoIme).Blokiran)
                return true;
            return false;
        }

        public void OdblokirajNalog(String idPacijenta)
        {
            Pacijent pacijent = PretraziPoId(idPacijenta);
            pacijent.Blokiran = false;
            naloziPacijenataRepozitorijum.IzmeniPacijenta(pacijent);
        }

        public bool DaLiJeKorisnickoImeJedinstveno(String korisnickoIme)
        {
            foreach (Pacijent pacijentZaProveru in DobaviSve())
            {
                if (pacijentZaProveru.KorisnickoIme.Equals(korisnickoIme))
                {
                    return false;
                }
            }
            return true;
        }
        public bool DaLiJeJmbgJedinstven(String jmbg)
        {
            foreach (Pacijent pacijentZaProveru in DobaviSve())
            {
                if (pacijentZaProveru.Jmbg.Equals(jmbg))
                {
                    return false;
                }
            }
            return true;
        }
       
        public bool ProveraNalogaPacijenta(String korisnickoIme)
        {
            Pacijent pacijent = PretraziPoId(korisnickoIme);
            if (JeBlokiran(pacijent))
            {
                if (ProsloJe30DanaOdZloupotrebe(pacijent))
                {
                    odblokirajPacijenta(pacijent);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (ProsloJe30DanaOdZloupotrebe(pacijent))
                    resetujZloupotrebuSistema(pacijent);
            }
            return true;
        }
        public bool ProsloJe30DanaOdZloupotrebe(Pacijent pacijent)
        {
            if (DateTime.Compare(DateTime.Now.Date.AddDays(30), pacijent.PoslednjaZloupotreba.Date) > 0)
                return true;
            return false;
        }
        private void odblokirajPacijenta(Pacijent pacijent)
        {
            pacijent.ZloupotrebioSistem = 0;
            pacijent.Blokiran = false;

        }
        private void resetujZloupotrebuSistema(Pacijent pacijent)
        {
            pacijent.ZloupotrebioSistem = 0;
        }
        private bool JeBlokiran(Pacijent pacijent)
        {
            if (pacijent.Blokiran)
                return true;
            return false;
        }
    }
}