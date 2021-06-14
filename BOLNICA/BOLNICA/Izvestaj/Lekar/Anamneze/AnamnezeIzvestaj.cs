using System;
using System.Data;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using Bolnica.DTO;
using Bolnica.Kontroler;
using System.Text;
using System.Collections.Generic;

namespace Bolnica.Izvestaj.Lekar
{
    public class AnamnezeIzvestaj
    {
        private String lekar;
        private String pacijent;
        private List<AnamnezaDTO> anamneze;

        public string Lekar { get => lekar; set => lekar = value; }
        public string Pacijent { get => pacijent; set => pacijent = value; }
        public List<AnamnezaDTO> Anamneze { get => anamneze; set => anamneze = value; }

        public void ExportDataTableToPdf(String strPdfPath, string strHeader)
        {
            System.IO.FileStream fs = new FileStream(strPdfPath, FileMode.Create, FileAccess.Write, FileShare.None);
            Document document = new Document();
            document.SetPageSize(iTextSharp.text.PageSize.A4);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();
            Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, Color.BLACK, Element.ALIGN_LEFT, 1)));

            document.Add(KreirajZaglavlje(strHeader));
            document.Add(KreirajPasusLekara());
            document.Add(p);
            document.Add(new Chunk("\n"));

            foreach(AnamnezaDTO a in Anamneze) {

                document.Add(KreirajTekstAnamneze(a));
                document.Add(new Chunk("\n"));

                if(a.SveTerapije.Count == 0)
                {
                    document.Add(new Chunk("\n"));
                    document.Add(p);
                    document.Add(new Chunk("\n"));
                    continue;
                }

                DataTable tabelaTerapija = NapraviTabeluTerapija(a);
                PdfPTable table = PopuniTabeluTerapija(tabelaTerapija);

                document.Add(table);
                document.Add(new Chunk("\n"));
                document.Add(p);
                document.Add(new Chunk("\n"));

            }
            document.Close();
            writer.Close();
            fs.Close();
        }

        private Paragraph KreirajTekstAnamneze(AnamnezaDTO a)
        {
            Paragraph paragrafAnamneza = new Paragraph();
            BaseFont fontAnamneza = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font font2Anamneza = new Font(fontAnamneza, 8, 2, Color.BLACK);
            paragrafAnamneza.Alignment = Element.ALIGN_LEFT;
            paragrafAnamneza.Add(new Chunk("Datum pregleda : " + a.Datum.ToString("dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture), font2Anamneza));
            paragrafAnamneza.Add(new Chunk("\nLekar : " + a.Lekar, font2Anamneza));
            paragrafAnamneza.Add(new Chunk("\nNalaz : " + a.Dijagnoza, font2Anamneza));
            return paragrafAnamneza;
        }

        private Paragraph KreirajPasusLekara()
        {
            Paragraph prgAuthor = new Paragraph();
            BaseFont btnAuthor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntAuthor = new Font(btnAuthor, 8, 2, Color.BLACK);
            prgAuthor.Alignment = Element.ALIGN_RIGHT;
            prgAuthor.Add(new Chunk("Lekar : " + Lekar, fntAuthor));
            prgAuthor.Add(new Chunk("\nDatum izdavanja : " + DateTime.Now.ToString("dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture), fntAuthor));
            return prgAuthor;
        }


        private Paragraph KreirajZaglavlje(String strHeader)
        {
            BaseFont bfntHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntHead = new Font(bfntHead, 16, 1, new Color(0, 138, 255));
            Paragraph prgHeading = new Paragraph();
            prgHeading.Alignment = Element.ALIGN_CENTER;
            prgHeading.Add(new Chunk(strHeader.ToUpper(), fntHead));

            return prgHeading;
        }

        public DataTable NapraviTabeluTerapija(AnamnezaDTO anamneza)
        {
            DataTable tabela = DefiniseKolone();

            foreach (TerapijaDTO t in anamneza.SveTerapije)
            {
                tabela.Rows.Add(new string[] {t.Lek.NazivLeka, t.Lek.Jacina,t.PocetakTerapije.ToString("dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture), 
                    t.KrajTerapije.ToString("dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture), t.Kolicina.ToString()});

            }

            return tabela;
        }

        private DataTable DefiniseKolone()
        {
            DataTable tabela = new DataTable();
            tabela.Columns.Add("Naziv leka");
            tabela.Columns.Add(Dekodiraj("Jačina leka"));
            tabela.Columns.Add(Dekodiraj("Početak terapije"));
            tabela.Columns.Add(Dekodiraj("Kraj terapije"));
            tabela.Columns.Add(Dekodiraj("Dnevna količina"));
            return tabela;
        }

        private String Dekodiraj(String tekst)
        {
            byte[] bytes = Encoding.Default.GetBytes(tekst);
            tekst = Encoding.UTF8.GetString(bytes);
            return tekst;

        }

        private PdfPTable PopuniTabeluTerapija(DataTable tabelaTerapija)
        {
            PdfPTable table = new PdfPTable(tabelaTerapija.Columns.Count);

            BaseFont btnColumnHeader = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntColumnHeader = new Font(btnColumnHeader, 10, 1, Color.DARK_GRAY);
            for (int i = 0; i < tabelaTerapija.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell();
                cell.BackgroundColor = new Color(153, 204, 255);
                cell.AddElement(new Chunk(tabelaTerapija.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                table.AddCell(cell);
            }

            for (int i = 0; i < tabelaTerapija.Rows.Count; i++)
            {
                for (int j = 0; j < tabelaTerapija.Columns.Count; j++)
                {
                    table.AddCell(tabelaTerapija.Rows[i][j].ToString());
                }
            }

            return table;
        }
    }
}
