using Bolnica.DTO;
using Bolnica.Konverter;
using Bolnica.Servis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Kontroler
{
    public class SekretarKontroler
    {
        SekretariServis sekretariServis = new SekretariServis();
        SekretarKonverter sekretarKonverter = new SekretarKonverter();
        public void Dodaj(SekretarDTO sekretar)
        {
            sekretariServis.Dodaj(sekretarKonverter.SekretarDTOUModel(sekretar));
        }
        public List<SekretarDTO> DobaviSve()
        {
            List<SekretarDTO> sekretari = new List<SekretarDTO>();
            foreach(Model.Sekretar sekretar in sekretariServis.DobaviSve())
            {
                sekretari.Add(sekretarKonverter.SekretarModelUDTO(sekretar));
            }
            return sekretari;
        }

        public SekretarDTO pretraziPoId(string korIme)
        {
            return sekretarKonverter.SekretarModelUDTO(sekretariServis.PretraziPoId(korIme));
        }
    }
}
