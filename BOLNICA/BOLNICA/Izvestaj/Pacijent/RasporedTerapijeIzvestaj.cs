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

            //drugi grafik
          
            Chart odnosKolicina = new Chart(-30, 430, 600, 300);
            PlotArea plotArea2 = odnosKolicina.PlotAreas.Add(50, 50, 500, 300);
            Title drugiNaslov = new Title("Odnos ukupne kolicine propisanih lekova");
            odnosKolicina.HeaderTitles.Add(drugiNaslov);

            AutoGradient[] autoGradients = DobaviBojeGrafika();


            ScalarDataLabel da = new ScalarDataLabel(true, true, false);
            PieSeries pieSeries = new PieSeries();
            pieSeries.DataLabel = da;
            plotArea2.Series.Add(pieSeries);


            List<TerapijaDTO> sveTerapije = zdravstvenKartoniKontroler.DobaviSveTerapijeZaIzvestaj(interval, koricniskoIme);
            float[] sveKolicine = new float[sveTerapije.Count];
            String[] sviLekovi = new String[sveTerapije.Count];
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


            //treci grafik
            Page drugaStranica = new Page();
            document.Pages.Add(drugaStranica);
            Chart treciGrafik = new Chart(0, 0, 500, 300);
            PlotArea plotArea22 = treciGrafik.PlotAreas.Add(50, 50, 500, 300);
            Title title11 = new Title("Dnevna kolicina propisanih lekova");
            treciGrafik.HeaderTitles.Add(title11);
            IndexedStackedColumnSeriesElement seriesElement11 = new IndexedStackedColumnSeriesElement("Lek");
           
            for(int i = 0; i < sveTerapije.Count;i++)
            {
                seriesElement11.Values.Add(sveKolicine[i]);
                Console.WriteLine("kolicina  " + sveKolicine[i]);
            }

            seriesElement11.Color = new AutoGradient(90f, CmykColor.LightBlue, CmykColor.Lavender);
            IndexedStackedColumnSeries columnSeries = new IndexedStackedColumnSeries();
            columnSeries.Add(seriesElement11);
            plotArea22.Series.Add(columnSeries);
            Title lTitle = new Title("Kolicina lekova");
            columnSeries.YAxis.Titles.Add(lTitle);
            for (int i = 0; i < sveTerapije.Count; i++)
            {
                columnSeries.XAxis.Labels.Add(new IndexedXAxisLabel(sviLekovi[i], i));
            }

            drugaStranica.Elements.Add(treciGrafik);
            //tabela
            Page trecaStranica = new Page();
            document.Pages.Add(trecaStranica);

            Table2 tabela = new Table2(-30, 0,700, 800);
            tabela.CellDefault.Border.Color = RgbColor.LightBlue;
            tabela.CellDefault.Border.LineStyle = LineStyle.Solid;
            tabela.CellDefault.Padding.Value = 3.0f;

            tabela.Columns.Add(80);
            tabela.Columns.Add(80);
            tabela.Columns.Add(80);
            tabela.Columns.Add(80);
            tabela.Columns.Add(80);
            tabela.Columns.Add(80);

            Row2 naslovTabele = tabela.Rows.Add(20, Font.HelveticaBold, 14, RgbColor.Black,
            RgbColor.Gray);
            naslovTabele.CellDefault.Align = TextAlign.Center;
            naslovTabele.CellDefault.VAlign = VAlign.Center;
            naslovTabele.Cells.Add("Terapije "+ interval[0].Date.ToString("dd.MM.yyyy.") + " - " + interval[1].Date.ToString("dd.MM.yyyy."), 6);

            Row2 sadrzajZaglavlja = tabela.Rows.Add(Font.HelveticaBoldOblique, 12);
            sadrzajZaglavlja.CellDefault.Align = TextAlign.Center;
            
            sadrzajZaglavlja.Cells.Add("Naziv");
            sadrzajZaglavlja.Cells.Add("Jacina");
            sadrzajZaglavlja.Cells.Add("Kolicina");
            sadrzajZaglavlja.Cells.Add("Satnica");
            sadrzajZaglavlja.Cells.Add("Pocetak");
            sadrzajZaglavlja.Cells.Add("Kraj");

            Row2 sadrzajTabele;
            
            for (int i=0; i < sveTerapije.Count; i++)
            {
                sadrzajTabele =tabela.Rows.Add(30);
                sadrzajTabele.Cells.Add(new FormattedTextArea(sveTerapije[i].Lek.NazivLeka, 0, 0, 140, 50, FontFamily.Helvetica, 12, false));
                sadrzajTabele.Cells.Add(new FormattedTextArea(sveTerapije[i].Lek.Jacina, 0, 0, 140, 50, FontFamily.Helvetica, 12, false));
                sadrzajTabele.Cells.Add(new FormattedTextArea(sveTerapije[i].Kolicina.ToString(), 0, 0, 140, 50, FontFamily.Helvetica, 12, false));
                sadrzajTabele.Cells.Add(new FormattedTextArea(sveTerapije[i].Satnica, 0, 0, 140, 50, FontFamily.Helvetica, 12, false));
                sadrzajTabele.Cells.Add(new FormattedTextArea(sveTerapije[i].PocetakTerapije.ToString("dd/MM//yyyy"), 0, 0, 140, 50, FontFamily.Helvetica, 12, false));
                sadrzajTabele.Cells.Add(new FormattedTextArea(sveTerapije[i].KrajTerapije.ToString("dd/MM/yyyy"), 0, 0, 140, 50, FontFamily.Helvetica, 12, false));
              
            }

            trecaStranica.Elements.Add(tabela);

            string nazivIzvestaja = @"..\..\..\..\KreiraniIzvestaji\IzvestajiPacijent\NedeljniIzvestaj" + DateTime.Now.ToString("dd.MM.yyyy.HH.mm") + ".pdf";
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
            AutoGradient[] bojeGrafika = new AutoGradient[16];
            bojeGrafika[0] = (new AutoGradient(90f, CmykColor.Red, CmykColor.DeepPink));
            bojeGrafika[1] = (new AutoGradient(90f, CmykColor.Green, CmykColor.Lavender));
            bojeGrafika[2] = (new AutoGradient(90f, CmykColor.Blue, CmykColor.DarkMagenta));
            bojeGrafika[3] = (new AutoGradient(90f, CmykColor.Blue, CmykColor.Beige));
            bojeGrafika[4] = (new AutoGradient(90f, CmykColor.Blue, CmykColor.DarkTurquoise));
            bojeGrafika[5] = (new AutoGradient(90f, CmykColor.Blue, CmykColor.Chocolate));
            bojeGrafika[6] = (new AutoGradient(90f, CmykColor.Blue, CmykColor.AliceBlue));
            bojeGrafika[7] = (new AutoGradient(90f, CmykColor.Blue, CmykColor.Azure));
            bojeGrafika[8] = (new AutoGradient(90f, CmykColor.Blue, CmykColor.BlanchedAlmond));
            bojeGrafika[9] = (new AutoGradient(90f, CmykColor.Blue, CmykColor.DarkOrange));
            bojeGrafika[10] = (new AutoGradient(90f, CmykColor.Blue, CmykColor.DarkMagenta));
            bojeGrafika[11] = (new AutoGradient(90f, CmykColor.Blue, CmykColor.DeepSkyBlue));
            bojeGrafika[12] = (new AutoGradient(90f, CmykColor.Blue, CmykColor.DimGray));
            bojeGrafika[13] = (new AutoGradient(90f, CmykColor.Blue, CmykColor.GoldenRod));
            bojeGrafika[14] = (new AutoGradient(90f, CmykColor.Blue, CmykColor.Gainsboro));
            bojeGrafika[15] = (new AutoGradient(90f, CmykColor.Blue, CmykColor.Gold));
            return bojeGrafika;
        }
    }

    }
