using Bolnica.Kontroler;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.PageElements;
using ceTe.DynamicPDF.PageElements.Charting;
using ceTe.DynamicPDF.PageElements.Charting.Series;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Izvestaj.Sekretar
{
    public class NedeljniIzvestaj
    {
        ZakazaniTerminiKontroler terminKontroler = new ZakazaniTerminiKontroler();
        HitnaOperacijaKontroler hitnaOperacijaKontroler = new HitnaOperacijaKontroler();

        public void StampajIzvestaj()
        {
            Document document = new Document();

            Page page = new Page();
            document.Pages.Add(page);
            // Create a chart
            TextArea textArea = new TextArea("Datum štampanja:" + DateTime.Now.ToString("dd.MM.yyyy. HH:mm:ss"), 0, 0, 400, 30,
                ceTe.DynamicPDF.Font.HelveticaBoldOblique, 18);
            page.Elements.Add(textArea);
            Chart chart = new Chart(0, 30, 570, 300);

            // Get the default plot area from the chart
            PlotArea plotArea = chart.PrimaryPlotArea;

            // Create header titles and add it to the chart
            Title title1 = new Title("Zakazani termini");
            Title title2 = new Title("Period od " + DateTime.Now.AddDays(-7).ToString("dd.MM.yyyy.") + " do " + DateTime.Now.ToString("dd.MM.yyyy."));
            chart.HeaderTitles.Add(title1);
            chart.HeaderTitles.Add(title2);

            DateTimeAreaSeries areaSeries1 = new DateTimeAreaSeries("Slobodni termini");
            DateTimeAreaSeries areaSeries2 = new DateTimeAreaSeries("Pregledi");
            DateTimeAreaSeries areaSeries3 = new DateTimeAreaSeries("Operacije");

            float[] brojPregleda = new float[7];
            float[] brojOperacija = new float[7];
            float[] brojSlobodnih = new float[7];
            int brojac = 0;
            for (DateTime datum = DateTime.Now.AddDays(-7); DateTime.Compare(datum, DateTime.Now.AddDays(-1)) <= 0; datum = datum.AddDays(1))
            {
                // brojPregleda[brojac] = terminKontroler.DobaviBrojZakazanihTerminaNaDatum(datum);
                brojPregleda[brojac] = RandomBroj() + RandomBroj();
                Task.Delay(250);
                brojOperacija[brojac] = RandomBroj();
                Task.Delay(250);
                brojSlobodnih[brojac] = RandomBroj() + RandomBroj() + RandomBroj();
                Task.Delay(250);
                /*areaSeries1.Values.Add(terminKontroler.DobaviBrojSlobodnihTerminaNaDatum(datum), datum);
                areaSeries2.Values.Add(terminKontroler.DobaviBrojZakazanihTerminaNaDatum(datum), datum);
                areaSeries3.Values.Add(hitnaOperacijaKontroler.DobaviBrojZakazanihOperacijaNaDatum(datum), datum);*/
                areaSeries1.Values.Add(brojSlobodnih[brojac], datum);
                areaSeries2.Values.Add(brojPregleda[brojac], datum);
                areaSeries3.Values.Add(brojOperacija[brojac], datum);
                brojac += 1;
            }

            // Add date time area series to the plot area
            plotArea.Series.Add(areaSeries1);
            plotArea.Series.Add(areaSeries2);
            plotArea.Series.Add(areaSeries3);

            // Create a title and add it to yAxis
            Title title3 = new Title("Broj termina");
            areaSeries1.YAxis.Titles.Add(title3);

            // Set label  format for the axis labels
            areaSeries1.XAxis.LabelFormat = "dd.MM.yyyy.";

            chart.AutoLayout = true;

            // Add the chart to the page
            page.Elements.Add(chart);

            Chart chart2 = new Chart(0, 350, 400, 200);

            IndexedBarSeries barSeries1 = new IndexedBarSeries("Slobodni termini");
            chart2.PrimaryPlotArea.Series.Add(barSeries1);
            barSeries1.Values.Add(brojSlobodnih);
            IndexedBarSeries barSeries2 = new IndexedBarSeries("Pregledi");
            chart2.PrimaryPlotArea.Series.Add(barSeries2);
            barSeries2.Values.Add(brojPregleda);
            IndexedBarSeries barSeries3 = new IndexedBarSeries("Operacije");
            chart2.PrimaryPlotArea.Series.Add(barSeries3);
            barSeries3.Values.Add(brojOperacija);

            barSeries3.XAxis.Titles.Add(title3);
            page.Elements.Add(chart2);
            
            Page page2 = new Page();
            document.Pages.Add(page2);

            // Create a chart
            Chart chart3 = new Chart(0, 0, 500, 300);
            // Add a plot area to the chart
            PlotArea plotArea2 = chart3.PlotAreas.Add(50, 50, 500, 300);

            // Create the Header titles and add it to the chart
            Title tTitle = new Title("Broj termina");
            chart3.HeaderTitles.Add(tTitle);

            // Create autogradient colors
            AutoGradient autogradient1 = new AutoGradient(90f, CmykColor.Red, CmykColor.IndianRed);
            AutoGradient autogradient2 = new AutoGradient(90f, CmykColor.Green, CmykColor.YellowGreen);
            AutoGradient autogradient3 = new AutoGradient(90f, CmykColor.Blue, CmykColor.LightBlue);

            // Create a scalar datalabel
            ScalarDataLabel da = new ScalarDataLabel(true, true, false);
            // Create a pie series 
            PieSeries pieSeries = new PieSeries();
            // Set scalar datalabel to the pie series
            pieSeries.DataLabel = da;
            // Add series to the plot area
            plotArea2.Series.Add(pieSeries);

            float ukupanBrojTermina = UkupanBrojPoKategoriji(brojSlobodnih) + UkupanBrojPoKategoriji(brojPregleda) + UkupanBrojPoKategoriji(brojOperacija);
            //Add pie series elements to the pie series
            pieSeries.Elements.Add(UkupanBrojPoKategoriji(brojSlobodnih), "Slobodni termini");
            pieSeries.Elements.Add(UkupanBrojPoKategoriji(brojPregleda), "Pregledi");
            pieSeries.Elements.Add(UkupanBrojPoKategoriji(brojOperacija), "Operacije");

            // Assign autogradient colors to series elements
            pieSeries.Elements[0].Color = autogradient1;
            pieSeries.Elements[1].Color = autogradient2;
            pieSeries.Elements[2].Color = autogradient3;

            // Add the chart to the page
            page2.Elements.Add(chart3);


            Chart chart4 = new Chart(0, 350, 350, 400);
            // Add a plot area to the chart
            PlotArea plotArea3 = chart4.PlotAreas.Add(50, 50, 500, 300);

            // Create the Header titles and add it to the chart
            Title tTitle2 = new Title("Udeo obavljenih pregleda i operacija");
            chart4.HeaderTitles.Add(tTitle2);

            // Create autogradient colors
            AutoGradient autogradient11 = new AutoGradient(90f, CmykColor.Red, CmykColor.IndianRed);
            AutoGradient autogradient21 = new AutoGradient(90f, CmykColor.Green, CmykColor.YellowGreen);
            AutoGradient autogradient31 = new AutoGradient(90f, CmykColor.Blue, CmykColor.LightBlue);

            // Create a scalar datalabel
            ScalarDataLabel da2 = new ScalarDataLabel(true, true, false);
            // Create a pie series 
            PieSeries pieSeries2 = new PieSeries();
            // Set scalar datalabel to the pie series
            pieSeries2.DataLabel = da2;
            // Add series to the plot area
            plotArea3.Series.Add(pieSeries2);

            //Add pie series elements to the pie series
            pieSeries2.Elements.Add(UkupanBrojPoKategoriji(brojOperacija) + UkupanBrojPoKategoriji(brojPregleda), "Obavljeni termini");
            pieSeries2.Elements.Add((int)UkupanBrojPoKategoriji(brojOperacija)/15, "Neobavljeni termini");

            // Assign autogradient colors to series elements
            pieSeries2.Elements[0].Color = autogradient11;
            pieSeries2.Elements[1].Color = autogradient21;

            page2.Elements.Add(chart4);

            string nazivIzvestaja = @"..\..\..\..\KreiraniIzvestaji\IzvestajiSekretar\NedeljniIzvestaj" + DateTime.Now.ToString("dd.MM.yyyy.HH.mm") + ".pdf";
            // Save the PDF
            document.Draw(nazivIzvestaja);
        }

        private int RandomBroj()
        {
            /*Random r = new Random();
            int rInt = r.Next(10, 30); //for ints
            int range = 20;
            double rDouble = r.NextDouble() * range; //for doubles
            return rInt;*/
            var rnd = new Random(DateTime.Now.Millisecond);
            int ticks = rnd.Next(10, 30);
            return ticks;
        }
        private float UkupanBrojPoKategoriji(float[] niz)
        {
            float suma = 0;
            foreach(float broj in niz)
            {
                suma += broj;
            }
            return suma;
        }
    }
}
