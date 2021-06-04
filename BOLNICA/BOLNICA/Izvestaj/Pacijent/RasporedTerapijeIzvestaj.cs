using Bolnica.DTO;
using Bolnica.Kontroler;
using Bolnica.Model;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.PageElements.Charting;
using ceTe.DynamicPDF.PageElements.Charting.Axes;
using ceTe.DynamicPDF.PageElements.Charting.Series;
using Microsoft.Build.Framework.XamlTypes;
using Spire.Pdf.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Izvestaj.Pacijent
{
    public class RasporedTerapijeIzvestaj
    {
        ZdravstvenKartoniKontroler zdravstvenKartoniKontroler = new ZdravstvenKartoniKontroler();
        NaloziPacijenataKontroler naloziPacijenataKontroler = new NaloziPacijenataKontroler();

        public void StampajIzvestaj(List<DateTime> interval, String koricniskoIme)
        {
            //zaglavlje
            PacijentDTO pacijent = naloziPacijenataKontroler.PretraziPoId(koricniskoIme);
            Document document = new Document();
            Page prvaStranica = new Page(PageSize.Letter, PageOrientation.Portrait, 54.0f);
            document.Pages.Add(prvaStranica);
            String naslov = "IZVEŠTAJ RASPOREDA TERAPIJE\n Pacijent: " + pacijent.Ime + " " + pacijent.Prezime + "\n";
            naslov += "Datum štampanja: " + DateTime.Now.ToString("dd.MM.yyyy. HH:mm:ss");
            Label label = new Label(naslov, 0, 0, 504, 100, Font.Helvetica, 18, TextAlign.Center);
            prvaStranica.Elements.Add(label);

            //prvi grafik
            Chart ukupnoLekova = new Chart(-30, 120, 600, 300);
            PlotArea plotArea = ukupnoLekova.PrimaryPlotArea;
            String opisDijagrama = interval[0].Date.ToString("dd.MM.yyyy.") + " - " + interval[1].Date.ToString("dd.MM.yyyy.");
            Title title1 = new Title("Broj terapija koje su u toku u vremenskom periodu: ");
            Title title2 = new Title(opisDijagrama);
            ukupnoLekova.HeaderTitles.Add(title1);
            ukupnoLekova.HeaderTitles.Add(title2);

            DateTimeAreaSeries areaSeries1 = new DateTimeAreaSeries("Terapije pacijenta");
            float ukupnoSvihTerapija = 0;
            float[] brojTerapija = new float[7];
            int brojac = 0;
            for (DateTime datum = interval[0]; DateTime.Compare(datum, interval[1]) <= 0; datum = datum.AddDays(1))
            {
                brojTerapija[brojac] = zdravstvenKartoniKontroler.DobaviBrojLekovaZaDatum(datum.Date, koricniskoIme);
                ukupnoSvihTerapija += brojTerapija[brojac];
                Task.Delay(250);
                areaSeries1.Values.Add(brojTerapija[brojac], datum);
                brojac += 1;
            }

            plotArea.Series.Add(areaSeries1);
            Title title3 = new Title("Broj terapija");
            areaSeries1.YAxis.Titles.Add(title3);
            areaSeries1.XAxis.LabelFormat = "dd.MM.yyyy.";
            ukupnoLekova.AutoLayout = true;
            prvaStranica.Elements.Add(ukupnoLekova);

            /////drugi grafik
            ///
            Chart odnosKolicina = new Chart(-30, 430, 600, 300);
            PlotArea plotArea2 = odnosKolicina.PlotAreas.Add(50, 50, 500, 300);
            Title tTitle = new Title("Odnos ukupne kolicine propisanih lekova");
            odnosKolicina.HeaderTitles.Add(tTitle);

            AutoGradient[] autoGradients = DobaviBojeGrafika();


            ScalarDataLabel da = new ScalarDataLabel(true, true, false);
            PieSeries pieSeries = new PieSeries();
            pieSeries.DataLabel = da;
            plotArea2.Series.Add(pieSeries);


            List<TerapijaDTO> sveTerapije = zdravstvenKartoniKontroler.DobaviSveTerapijeZaIzvestaj(interval, koricniskoIme);
            float[] sveKolicine = new float[sveTerapije.Count];
            String[] sviLekovi = new String[sveTerapije.Count];
            Console.WriteLine("sve terapije vratilaaaaaa" + sveTerapije.Count);
            foreach (TerapijaDTO terapija in sveTerapije)
            {
               
                float kolicina = float.Parse(terapija.Kolicina);
                float satnica = float.Parse(terapija.Satnica);
                float ukupnoDnevno = IzracunajUkupnuTerapiju(kolicina, satnica);
                pieSeries.Elements.Add(ukupnoDnevno, terapija.Lek.NazivLeka);
                
            }

            for (int i = 0; i < sveTerapije.Count; i++)
            {
                pieSeries.Elements[i].Color = autoGradients[i];
                float kolicina = float.Parse(sveTerapije[i].Kolicina);
                float satnica = float.Parse(sveTerapije[i].Satnica);
                sveKolicine[i] = IzracunajUkupnuTerapiju(kolicina,satnica);
                sviLekovi[i] = sveTerapije[i].Lek.NazivLeka;
            }
            prvaStranica.Elements.Add(odnosKolicina);


            //TRECI GRAFIK
            

            Page page2 = new Page();
            document.Pages.Add(page2);

            // Create a chart
            Chart chart3 = new Chart(0, 0, 500, 300);
            // Add a plot area to the chart
            PlotArea plotArea22 = chart3.PlotAreas.Add(50, 50, 500, 300);

            // Create header titles and add it to the chart
            Title title11 = new Title("Ukupna kolicina lekova u zadatom periodu");
            chart3.HeaderTitles.Add(title11);

            // Create a indexed stacked column series elements and add values to it
            IndexedStackedColumnSeriesElement seriesElement11 = new IndexedStackedColumnSeriesElement("Lek");
           
            for(int i = 0; i < sveTerapije.Count;i++)
            {
                seriesElement11.Values.Add(sveKolicine[i]);
                Console.WriteLine("kolicina  " + sveKolicine[i]);
            }

            // Create autogradient and assign it to series
            seriesElement11.Color = new AutoGradient(90f, CmykColor.LightBlue, CmykColor.Lavender);
           

            // Create a Indexed Stacked Column Series
            IndexedStackedColumnSeries columnSeries = new IndexedStackedColumnSeries();
            // Add indexed stacked column series elements to the Indexed Stacked Column Series
            columnSeries.Add(seriesElement11);
            
           
            // Add series to the plot area
            plotArea22.Series.Add(columnSeries);

            // Create a title and add it to the yaxis
            Title lTitle = new Title("Kolicina lekova");
            columnSeries.YAxis.Titles.Add(lTitle);
            for (int i = 0; i < sveTerapije.Count; i++)
            {
                columnSeries.XAxis.Labels.Add(new IndexedXAxisLabel(sviLekovi[i], i));
            }

            page2.Elements.Add(chart3);


            ///////////////////////////////////TABELA
            // Create a Page and add it to the document 
            Page page = new Page();
            document.Pages.Add(page);

            Table2 table = new Table2(-30, 0,700, 800);
            table.CellDefault.Border.Color = RgbColor.LightBlue;
            table.CellDefault.Border.LineStyle = LineStyle.Solid;
            table.CellDefault.Padding.Value = 3.0f;

            // Add columns to the table
            table.Columns.Add(80);
            table.Columns.Add(80);
            table.Columns.Add(80);
            table.Columns.Add(80);
            table.Columns.Add(80);
            table.Columns.Add(80);
            // The first row is used as a table heading
            Row2 row1 = table.Rows.Add(20, Font.HelveticaBold, 14, RgbColor.Black,
            RgbColor.Gray);
            row1.CellDefault.Align = TextAlign.Center;
            row1.CellDefault.VAlign = VAlign.Center;
            row1.Cells.Add("Terapije "+ interval[0].Date.ToString("dd.MM.yyyy.") + " - " + interval[1].Date.ToString("dd.MM.yyyy."), 6);

            // The second row is the column headings
            Row2 row2 = table.Rows.Add(Font.HelveticaBoldOblique, 12);
            row2.CellDefault.Align = TextAlign.Center;
            
            row2.Cells.Add("Naziv");
            row2.Cells.Add("Jacina");
            row2.Cells.Add("Kolicina");
            row2.Cells.Add("Satnica");
            row2.Cells.Add("Pocetak");
            row2.Cells.Add("Kraj");

            Row2 row3;
            
            for (int i=0; i < sveTerapije.Count; i++)
            {
                row3 =table.Rows.Add(30);
                row3.Cells.Add(new FormattedTextArea(sveTerapije[i].Lek.NazivLeka, 0, 0, 140, 50, FontFamily.Helvetica, 12, false));
                row3.Cells.Add(new FormattedTextArea(sveTerapije[i].Lek.Jacina, 0, 0, 140, 50, FontFamily.Helvetica, 12, false));
                row3.Cells.Add(new FormattedTextArea(sveTerapije[i].Kolicina.ToString(), 0, 0, 140, 50, FontFamily.Helvetica, 12, false));
                row3.Cells.Add(new FormattedTextArea(sveTerapije[i].Satnica, 0, 0, 140, 50, FontFamily.Helvetica, 12, false));
                row3.Cells.Add(new FormattedTextArea(sveTerapije[i].PocetakTerapije.ToString("dd/MM//yyyy"), 0, 0, 140, 50, FontFamily.Helvetica, 12, false));
                row3.Cells.Add(new FormattedTextArea(sveTerapije[i].KrajTerapije.ToString("dd/MM/yyyy"), 0, 0, 140, 50, FontFamily.Helvetica, 12, false));
              
            }

            page.Elements.Add(table);

            string nazivIzvestaja = "IzvestajiPacijent/NedeljniIzvestaj" + DateTime.Now.ToString("dd.MM.yyyy.HH.mm") + ".pdf";
            document.Draw(nazivIzvestaja);
        }

        private float IzracunajUkupnuTerapiju(float kolicina,float satnica)
        {
            float suma = 0;
            float granica = 24 / satnica;
            for (float i = 0; i < granica; i++)
                suma += kolicina;

            return suma;
        }

        private AutoGradient[] DobaviBojeGrafika()
        {
            AutoGradient[] autoGradients = new AutoGradient[16];
            autoGradients[0] = (new AutoGradient(90f, CmykColor.Red, CmykColor.DeepPink));
            autoGradients[1] = (new AutoGradient(90f, CmykColor.Green, CmykColor.Lavender));
            autoGradients[2] = (new AutoGradient(90f, CmykColor.Blue, CmykColor.LightBlue));
            autoGradients[3] = (new AutoGradient(90f, CmykColor.Blue, CmykColor.Beige));
            autoGradients[4] = (new AutoGradient(90f, CmykColor.Blue, CmykColor.DarkTurquoise));
            autoGradients[5] = (new AutoGradient(90f, CmykColor.Blue, CmykColor.Chocolate));
            autoGradients[6] = (new AutoGradient(90f, CmykColor.Blue, CmykColor.AliceBlue));
            autoGradients[7] = (new AutoGradient(90f, CmykColor.Blue, CmykColor.Azure));
            autoGradients[8] = (new AutoGradient(90f, CmykColor.Blue, CmykColor.BlanchedAlmond));
            autoGradients[9] = (new AutoGradient(90f, CmykColor.Blue, CmykColor.DarkOrange));
            autoGradients[10] = (new AutoGradient(90f, CmykColor.Blue, CmykColor.DarkMagenta));
            autoGradients[11] = (new AutoGradient(90f, CmykColor.Blue, CmykColor.DeepSkyBlue));
            autoGradients[12] = (new AutoGradient(90f, CmykColor.Blue, CmykColor.DimGray));
            autoGradients[13] = (new AutoGradient(90f, CmykColor.Blue, CmykColor.GoldenRod));
            autoGradients[14] = (new AutoGradient(90f, CmykColor.Blue, CmykColor.Gainsboro));
            autoGradients[15] = (new AutoGradient(90f, CmykColor.Blue, CmykColor.Gold));
            return autoGradients;
        }
    }

    }
