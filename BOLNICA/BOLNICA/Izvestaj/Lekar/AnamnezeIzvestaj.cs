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

        NaloziPacijenataKontroler naloziPacijenataKontroler = new NaloziPacijenataKontroler();
        ZdravstvenKartoniKontroler zdravstvenKartoniKontroler = new ZdravstvenKartoniKontroler();
        LekariKontroler lekariKontroler = new LekariKontroler();

        public void ExportDataTableToPdf(TerminDTO izabranTermin, String strPdfPath, string strHeader)
        {
            System.IO.FileStream fs = new FileStream(strPdfPath, FileMode.Create, FileAccess.Write, FileShare.None);
            Document document = new Document();
            document.SetPageSize(iTextSharp.text.PageSize.A4);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();

            BaseFont bfntHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntHead = new Font(bfntHead, 16, 1, new Color(0, 138, 255));
            Paragraph prgHeading = new Paragraph();
            prgHeading.Alignment = Element.ALIGN_CENTER;
            prgHeading.Add(new Chunk(strHeader.ToUpper(), fntHead));
            document.Add(prgHeading);

            //Author
            LekarDTO izabranLekar = lekariKontroler.PretraziPoId(izabranTermin.Lekar.KorisnickoIme);
            Paragraph prgAuthor = new Paragraph();
            BaseFont btnAuthor = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntAuthor = new Font(btnAuthor, 8, 2, Color.BLACK);
            prgAuthor.Alignment = Element.ALIGN_RIGHT;
            prgAuthor.Add(new Chunk("Lekar : " + izabranLekar.Ime + " " + izabranLekar.Prezime, fntAuthor));
            prgAuthor.Add(new Chunk("\nDatum izdavanja : " + DateTime.Now.ToString("dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture), fntAuthor));
            document.Add(prgAuthor);

            //Add a line seperation
            Paragraph p = new Paragraph(new Chunk(new iTextSharp.text.pdf.draw.LineSeparator(0.0F, 100.0F, Color.BLACK, Element.ALIGN_LEFT, 1)));
            document.Add(p);

            //Add line break
            document.Add(new Chunk("\n", fntHead));

            List<AnamnezaDTO> listaAnamneza = zdravstvenKartoniKontroler.DobaviAnamnezePacijenta(izabranTermin.IdPacijenta);

            foreach(AnamnezaDTO a in listaAnamneza) {

                Paragraph paragrafAnamneza = new Paragraph();
                BaseFont fontAnamneza = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                Font font2Anamneza = new Font(fontAnamneza, 8, 2, Color.BLACK);
                paragrafAnamneza.Alignment = Element.ALIGN_LEFT;
                paragrafAnamneza.Add(new Chunk("Datum pregleda : " + a.Datum.ToString("dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture), font2Anamneza));
                paragrafAnamneza.Add(new Chunk("\nLekar : " + a.Lekar, font2Anamneza));
                paragrafAnamneza.Add(new Chunk("\nNalaz : " + a.Dijagnoza, font2Anamneza));
                document.Add(paragrafAnamneza);
                document.Add(new Chunk("\n", fntHead));

                if(a.SveTerapije.Count == 0)
                {
                    document.Add(new Chunk("\n", fntHead));
                    document.Add(p);
                    document.Add(new Chunk("\n", fntHead));
                    continue;
                }

                DataTable tabelaTerapija = NapraviTabeluTerapija(a);
               
                //Write the table
                PdfPTable table = new PdfPTable(tabelaTerapija.Columns.Count);
                //Table header
                BaseFont btnColumnHeader = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                Font fntColumnHeader = new Font(btnColumnHeader, 10, 1, Color.DARK_GRAY);
                for (int i = 0; i < tabelaTerapija.Columns.Count; i++)
                {
                    PdfPCell cell = new PdfPCell();
                    cell.BackgroundColor = new Color(153, 204, 255);
                    cell.AddElement(new Chunk(tabelaTerapija.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                    table.AddCell(cell);
                }
                //table Data
                for (int i = 0; i < tabelaTerapija.Rows.Count; i++)
                {
                    for (int j = 0; j < tabelaTerapija.Columns.Count; j++)
                    {
                        table.AddCell(tabelaTerapija.Rows[i][j].ToString());
                    }
                }

                document.Add(table);
                document.Add(new Chunk("\n", fntHead));
                document.Add(p);
                document.Add(new Chunk("\n", fntHead));
                
            }
            document.Close();
            writer.Close();
            fs.Close();
        }

        public DataTable NapraviTabeluTerapija(AnamnezaDTO anamneza)
        {

            //Create friend table object
            DataTable tabela = new DataTable();

            //Define columns
            tabela.Columns.Add("Naziv leka");
            string jacina = "Jačina leka";
            byte[] bytes = Encoding.Default.GetBytes(jacina);
            jacina = Encoding.UTF8.GetString(bytes);
            tabela.Columns.Add(jacina);
            string pocetak = "Početak terapije";
            bytes = Encoding.Default.GetBytes(pocetak);
            pocetak = Encoding.UTF8.GetString(bytes);
            tabela.Columns.Add(pocetak);
            string kraj = "Kraj terapije";
            bytes = Encoding.Default.GetBytes(kraj);
            kraj = Encoding.UTF8.GetString(bytes);
            tabela.Columns.Add(kraj);
            string kolicina = "Dnevna količina";
            bytes = Encoding.Default.GetBytes(kolicina);
            kolicina = Encoding.UTF8.GetString(bytes);
            tabela.Columns.Add(kolicina);

            foreach (TerapijaDTO t in anamneza.SveTerapije)
            {
                tabela.Rows.Add(new string[] {t.Lek.NazivLeka, t.Lek.Jacina,t.PocetakTerapije.ToString("dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture), 
                    t.KrajTerapije.ToString("dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture), t.Kolicina.ToString()});

            }


            return tabela;
        }
    }
}
