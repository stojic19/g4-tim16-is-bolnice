using Bolnica.Interfejsi.Sekretar;
using Bolnica.Konverter;
using Bolnica.Model;
using Bolnica.Repozitorijum;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Servis
{
    class RadniDaniLekaraServis : CRUDInterfejs<RadniDanDTO>
    {
        LekariServis lekariServis = new LekariServis();
        SmenaServis smenaServis;
        SlobodniTerminiServis slobodniTerminiServis = new SlobodniTerminiServis();
        OperacijeServis operacijeServis = new OperacijeServis();
        RadniDanKonverter radniDanKonverter = new RadniDanKonverter();
        String idLekara;

        public RadniDaniLekaraServis(String idLekara)
        {
            this.idLekara = idLekara;
            smenaServis = new SmenaServis(idLekara);
        }
        public List<RadniDanDTO> DobaviSve()
        {
            List<RadniDanDTO> radniDani = new List<RadniDanDTO>();
            foreach (RadniDan radniDan in lekariServis.DobaviRadneDanePoIdLekara(idLekara))
            {
                radniDani.Add(radniDanKonverter.RadniDanModelUDTO(radniDan));
            }
            return radniDani;
        }

        public RadniDanDTO PretraziPoId(string id)
        {
            foreach(RadniDanDTO radniDan in DobaviSve())
            {
                if (radniDan.IdRadnogDana.Equals(id))
                    return radniDan;
            }
            return null;
        }

        public void Ukloni(RadniDanDTO radniDan)
        {
            Lekar lekar = lekariServis.PretraziPoId(idLekara);
            lekar.UkloniRadniDan(radniDanKonverter.RadniDanDTOUModel(radniDan));
            lekariServis.Izmeni(lekar.KorisnickoIme, lekar);
            smenaServis.Ukloni(radniDanKonverter.RadniDanDTOUModel(radniDan));
        }

        public void Dodaj(RadniDanDTO radniDan)
        {
            Lekar lekar = lekariServis.PretraziPoId(idLekara);
            if (lekar.Specijalizacija == SpecijalizacijeLekara.nema)
            {
                DodajRadneDaneOpstaPraksa(radniDan);
            }
            else
            {
                DodajRadneDaneSpecijalista(radniDan);
            }
        }

        public void Izmeni(string stariId, RadniDanDTO radniDan)
        {
            Lekar lekar = lekariServis.PretraziPoId(idLekara);
            lekar.IzmeniRadniDan(radniDanKonverter.RadniDanDTOUModel(radniDan), KonstruisiRadniDanNaOsnovuParametara(radniDan.PocetakSmene.Date, radniDan.Smena));
            lekariServis.Izmeni(lekar.KorisnickoIme, lekar);
            smenaServis.Izmeni(stariId, KonstruisiRadniDanNaOsnovuParametara(radniDan.PocetakSmene.Date, radniDan.Smena));
            
        }

        public void ProveriDaLiTrebaDodatiDaneZaGodisnji()
        {
            lekariServis.ProveriDaLiTrebaDodatiDaneZaGodisnji();
        }
        private void DodajRadneDaneOpstaPraksa(RadniDanDTO radniDan)
        {
            Lekar lekar = lekariServis.PretraziPoId(idLekara);
            for (DateTime datum = radniDan.PocetakSmene.Date; DateTime.Compare(datum.Date, radniDan.KrajSmene.Date) <= 0; datum = datum.AddDays(1))
            {
                if (lekar.DaLiJeDostupanNaProsledjenDatum(datum.Date) && DaLiJeDatumRadniDan(datum))
                {
                    lekar.DodajRadniDan(KonstruisiRadniDanNaOsnovuParametara(datum, radniDan.Smena));
                    slobodniTerminiServis.DodajSlobodneTermineZaOpstuPraksu(lekar.KorisnickoIme, KonstruisiRadniDanNaOsnovuParametara(datum, radniDan.Smena));
                }
            }
            lekariServis.Izmeni(lekar.KorisnickoIme, lekar);
        }

        public bool DaLiJeMogucePromenitiSmenu(RadniDan radniDanZaPromenuSmene)
        {
            return DateTime.Compare(radniDanZaPromenuSmene.PocetakSmene.Date, DateTime.Now.Date) > 0;
        }

        private void DodajRadneDaneSpecijalista(RadniDanDTO radniDan)
        {
            Lekar lekar = lekariServis.PretraziPoId(idLekara);
            for (DateTime datum = radniDan.PocetakSmene.Date; DateTime.Compare(datum.Date, radniDan.KrajSmene.Date) <= 0; datum = datum.AddDays(1))
            {
                if (lekar.DaLiJeDostupanNaProsledjenDatum(datum.Date) && DaLiJeDatumRadniDan(datum))
                {
                    lekar.DodajRadniDan(KonstruisiRadniDanNaOsnovuParametara(datum, radniDan.Smena));
                    slobodniTerminiServis.DodajSlobodneTermineZaSpecijalistu(lekar.KorisnickoIme, KonstruisiRadniDanNaOsnovuParametara(datum, radniDan.Smena));
                }
            }
            lekariServis.Izmeni(lekar.KorisnickoIme, lekar);
        }
        private bool DaLiJeDatumRadniDan(DateTime datum)
        {
            return datum.DayOfWeek != DayOfWeek.Saturday && datum.DayOfWeek != DayOfWeek.Sunday;
        }

        private RadniDan KonstruisiRadniDanNaOsnovuParametara(DateTime datum, string smena)
        {
            DateTime pocetakSmene, krajSmene;
            pocetakSmene = datum.Date + DobaviPocetakSmene(smena);
            krajSmene = pocetakSmene.AddHours(8);
            return new RadniDan(pocetakSmene, krajSmene);
        }

        public bool DaLiJeMoguceRaditiUZadatomPeriodu(RadniDan radniDan)
        {
            Lekar lekar = lekariServis.PretraziPoId(idLekara);
            for (DateTime datum = radniDan.PocetakSmene.Date; DateTime.Compare(datum.Date, radniDan.KrajSmene.Date) <= 0; datum = datum.AddDays(1))
            {
                if (lekar.DaLiJeNaGodisnjemNaProsledjenDatum(datum.Date) && DatumJeUBuducnosti(datum.Date))
                {
                    return false;
                }
            }
            return true;
        }

        private bool DatumJeUBuducnosti(DateTime datum)
        {
            return DateTime.Compare(datum.Date, DateTime.Now.Date) > 0;
        }

        private TimeSpan DobaviPocetakSmene(string smena)
        {
            TimeSpan ts;
            if (smena.Equals("Prva"))
            {
                ts = new TimeSpan(7, 0, 0);
            }
            else if (smena.Equals("Druga"))
            {
                ts = new TimeSpan(15, 0, 0);
            }
            else
            {
                ts = new TimeSpan(23, 0, 0);
            }
            return ts;
        }
    }
}