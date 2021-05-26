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
    class RasporedLekaraServis
    {
        LekariServis lekariServis = new LekariServis();
        SlobodniTerminiServis slobodniTerminiServis = new SlobodniTerminiServis();
        TerminiServis terminiServis = new TerminiServis();

        public void UkloniRadniDan(String idLekara, RadniDan radniDan)
        {
            Lekar lekar = lekariServis.PretraziPoId(idLekara);
            lekar.UkloniRadniDan(radniDan);
            lekariServis.IzmeniLekara(lekar);
            slobodniTerminiServis.UkloniRadniDan(idLekara, radniDan);
        }
        public void PromeniSmenu(String idLekara, RadniDan radniDan, string smena)
        {
            Lekar lekar = lekariServis.PretraziPoId(idLekara);
            lekar.IzmeniRadniDan(radniDan, KonstruisiRadniDanNaOsnovuParametara(radniDan.PocetakSmene.Date,smena));
            lekariServis.IzmeniLekara(lekar);
            //terminiServis.PromeniSmenu(idLekara,radniDan, KonstruisiRadniDanNaOsnovuParametara(radniDan.PocetakSmene.Date, smena));
            slobodniTerminiServis.PromeniSmenu(idLekara, radniDan, KonstruisiRadniDanNaOsnovuParametara(radniDan.PocetakSmene.Date, smena));
        }
        public void DodajRadneDane(String idLekara, RadniDan radniDan, string smena)
        {
            Lekar lekar = lekariServis.PretraziPoId(idLekara);
            if(lekar.Specijalizacija == SpecijalizacijeLekara.nema)
            {
                DodajRadneDaneOpstaPraksa(idLekara, radniDan, smena);
            }
            else
            {
                DodajRadneDaneSpecijalista(idLekara, radniDan, smena);
            }
        }
        private void DodajRadneDaneOpstaPraksa(string idLekara,RadniDan radniDan,string smena)
        {
            Lekar lekar = lekariServis.PretraziPoId(idLekara);
            for (DateTime datum = radniDan.PocetakSmene.Date; DateTime.Compare(datum.Date, radniDan.KrajSmene.Date) <= 0; datum = datum.AddDays(1))
            {
                if (lekar.DaLiJeDostupanNaProsledjenDatum(datum.Date) && DaLiJeDatumRadniDan(datum))
                {
                    lekar.DodajRadniDan(KonstruisiRadniDanNaOsnovuParametara(datum, smena));
                    slobodniTerminiServis.DodajSlobodneTermineZaOpstuPraksu(idLekara, KonstruisiRadniDanNaOsnovuParametara(datum, smena));
                }
            }
            lekariServis.IzmeniLekara(lekar);
        }
        private void DodajRadneDaneSpecijalista(string idLekara,RadniDan radniDan,string smena)
        {
            Lekar lekar = lekariServis.PretraziPoId(idLekara);
            for (DateTime datum = radniDan.PocetakSmene.Date; DateTime.Compare(datum.Date, radniDan.KrajSmene.Date) <= 0; datum = datum.AddDays(1))
            {
                if (lekar.DaLiJeDostupanNaProsledjenDatum(datum.Date) && DaLiJeDatumRadniDan(datum))
                {
                    lekar.DodajRadniDan(KonstruisiRadniDanNaOsnovuParametara(datum, smena));
                    slobodniTerminiServis.DodajSlobodneTermineZaSpecijalistu(idLekara, KonstruisiRadniDanNaOsnovuParametara(datum, smena));
                }
            }
            lekariServis.IzmeniLekara(lekar);
        }
        private bool DaLiJeDatumRadniDan(DateTime datum)
        {
            return datum.DayOfWeek != DayOfWeek.Saturday && datum.DayOfWeek != DayOfWeek.Sunday;
        }

        private RadniDan KonstruisiRadniDanNaOsnovuParametara(DateTime datum,string smena)
        {
            DateTime pocetakSmene, krajSmene;
            pocetakSmene = datum.Date + DobaviPocetakSmene(smena);
            krajSmene = pocetakSmene.AddHours(8);
            return new RadniDan(pocetakSmene, krajSmene);
        }

        public List<RadniDan> DobaviRadneDanePoIdLekara(string idLekara)
        {
            return lekariServis.DobaviRadneDanePoIdLekara(idLekara);
        }

        public List<Odsustvo> DobaviOdsustvoPoIdLekara(string idLekara)
        {
            return lekariServis.DobaviOdsustvoPoIdLekara(idLekara);
        }

        public bool DaLiJeMoguceRaditiUZadatomPeriodu(string idLekara, RadniDan radniDan)
        {
            Lekar lekar = lekariServis.PretraziPoId(idLekara);
            for (DateTime datum = radniDan.PocetakSmene.Date; DateTime.Compare(datum.Date, radniDan.KrajSmene.Date) <= 0; datum = datum.AddDays(1))
            {
                if (lekar.DaLiJeNaGodisnjemNaProsledjenDatum(datum.Date))
                {
                    return false;
                }
            }
            return true;
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
        public void DodajSlobodneDane(String idLekara, Odsustvo odsustvo)
        {
            Lekar lekar = lekariServis.PretraziPoId(idLekara);
            lekar.DodajSlobodneDane(odsustvo);
            lekariServis.IzmeniLekara(lekar);
        }
        public bool DaLiJeMogucGodisnjiUZadatomPeriodu(String idLekara, Odsustvo odsustvo)
        {
            Lekar lekar = lekariServis.PretraziPoId(idLekara);
            for (DateTime datum = odsustvo.PocetakOdsustva.Date; DateTime.Compare(datum.Date, odsustvo.KrajOdsustva.Date) <= 0; datum = datum.AddDays(1))
            {
                if (lekar.DaLiRadiNaProsledjenDatum(datum.Date))
                {
                    return false;
                }
            }
            return true;
        }
        public void UkloniSlobodneDane(String idLekara, Odsustvo odsustvo)
        {
            Lekar lekar = lekariServis.PretraziPoId(idLekara);
            lekar.UkloniSlobodneDane(odsustvo);
            lekariServis.IzmeniLekara(lekar);
        }
        public void IzmeniSlobodneDane(String idLekara, Odsustvo staroOdsustvo,Odsustvo novoOdsustvo)
        {
            Lekar lekar = lekariServis.PretraziPoId(idLekara);
            lekar.IzmeniSlobodneDane(staroOdsustvo, novoOdsustvo);
            lekariServis.IzmeniLekara(lekar);
        }
    }
}
