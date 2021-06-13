using Bolnica.DTO;
using Bolnica.Interfejsi.Lekar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Bolnica.Izvestaj.Lekar.Anamneze
{
    public class ITextSharpAnamnezeAdapter : IzvestajiAnamnezaInterfejs
    {
        private List<AnamnezaDTO> anamneze = new List<AnamnezaDTO>();
        private String lekar;
        private String pacijent;

        public List<AnamnezaDTO> Anamneze { get => anamneze; set => anamneze = value; }
        public string Lekar { get => lekar; set => lekar = value; }
        public string Pacijent { get => pacijent; set => pacijent = value; }

        public void ProslediLekara(String lekar)
        {
            this.Lekar = lekar;
        }

        public void ProslediPacijenta(string pacijent)
        {
            this.pacijent = pacijent;
        }

        public void ProslediPodatke(List<AnamnezaDTO> anamneze)
        {
            this.anamneze = anamneze;
        }

        public void KreirajIzvestaj()
        {
            AnamnezeIzvestaj anamnezeIzvestaj = new AnamnezeIzvestaj();
            anamnezeIzvestaj.Lekar = Lekar;
            anamnezeIzvestaj.Pacijent = Pacijent;
            anamnezeIzvestaj.Anamneze = Anamneze;

            anamnezeIzvestaj.ExportDataTableToPdf(KreirajPutanju(), KreirajNaslov());
            PrikazIzvestaja();
        }
        private void PrikazIzvestaja()
        {
            if (MessageBox.Show("Izveštaj izgenerisan! Pogledati ga?", "Izveštaj anamneza", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                System.Diagnostics.Process.Start(KreirajPutanju());
            }
        }

        private String KreirajNaslov()
        {
            String naslov = "Izveštaj anamneza@@Pacijent " + Pacijent;
            naslov = naslov.Replace("@", System.Environment.NewLine);
            return naslov;
        }

        private String KreirajPutanju()
        {
            String datum = DateTime.Now.ToString("_dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
            String putanja = @"..\..\..\..\KreiraniIzvestaji\IzvestajiLekar\Anamneze_" + Pacijent + datum + ".pdf";
            return putanja;
        }
    }
}
