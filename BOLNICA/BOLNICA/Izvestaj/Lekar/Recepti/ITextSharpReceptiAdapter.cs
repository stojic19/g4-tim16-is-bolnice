using Bolnica.DTO;
using Bolnica.Interfejsi.Lekar;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Bolnica.Izvestaj.Lekar
{
    public class ITextSharpReceptiAdapter : IzvestajiRecepataInterfejs
    {
        private List<ReceptDTO> recepti = new List<ReceptDTO>();
        private String lekar;
        private String pacijent;

        public List<ReceptDTO> Recepti { get => recepti; set => recepti = value; }
        public string Lekar { get => lekar; set => lekar = value; }
        public string Pacijent { get => pacijent; set => pacijent = value; }

        public void ProslediPodatke(List<ReceptDTO> recepti)
        {
            this.Recepti = recepti;
        }

        public void ProslediLekara(String lekar)
        {
            this.Lekar = lekar;
        }

        public void ProslediPacijenta(string pacijent)
        {
            this.pacijent = pacijent;
        }

        public void KreirajIzvestaj()
        {
            ReceptiIzvestaj receptiIzvestaj = new ReceptiIzvestaj();
            receptiIzvestaj.Lekar = Lekar;
            receptiIzvestaj.Pacijent = Pacijent;
            DataTable dtbl = receptiIzvestaj.MakeDataTable(Recepti);

            receptiIzvestaj.ExportDataTableToPdf(dtbl, KreirajPutanju(), KreirajNaslov());
            PrikazIzvestaja();
        }

        private void PrikazIzvestaja()
        {
            if (MessageBox.Show("Izveštaj izgenerisan! Pogledati ga?", "Izveštaj recepata", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                System.Diagnostics.Process.Start(KreirajPutanju());
            }
        }

        private String KreirajNaslov()
        {
            String naslov = "Izveštaj recepata@@Pacijent " + pacijent;
            naslov = naslov.Replace("@", System.Environment.NewLine);
            return naslov;
        }

        private String KreirajPutanju()
        {
            String datum = DateTime.Now.ToString("_dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
            String putanja = @"..\..\..\..\KreiraniIzvestaji\IzvestajiLekar\Recepti_" + pacijent + datum + ".pdf";
            return putanja;
        }
    }
}
