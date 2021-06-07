using System;
using System.Data;
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;
using Bolnica.DTO;
using Bolnica.Kontroler;
using System.Text;

namespace Bolnica.Izvestaj.Lekar
{
    public class ReceptiIzvestaj
    {
        NaloziPacijenataKontroler naloziPacijenataKontroler = new NaloziPacijenataKontroler();
        ZdravstvenKartoniKontroler zdravstvenKartoniKontroler = new ZdravstvenKartoniKontroler();
        LekariKontroler lekariKontroler = new LekariKontroler();
        LekarDTO izabranLekar = null;

        public void ExportDataTableToPdf(DataTable dtblTable, String strPdfPath, string strHeader)
        {
            System.IO.FileStream fs = new FileStream(strPdfPath, FileMode.Create, FileAccess.Write, FileShare.None);
            Document document = new Document();
            document.SetPageSize(iTextSharp.text.PageSize.A4);
            PdfWriter writer = PdfWriter.GetInstance(document, fs);
            document.Open();

            BaseFont bfntHead = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntHead = new Font(bfntHead, 16, 1, new Color(0,138,255));
            Paragraph prgHeading = new Paragraph();
            prgHeading.Alignment = Element.ALIGN_CENTER;
            prgHeading.Add(new Chunk(strHeader.ToUpper(), fntHead));
            document.Add(prgHeading);

            //Author
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

            //Write the table
            PdfPTable table = new PdfPTable(dtblTable.Columns.Count);
            //Table header
            BaseFont btnColumnHeader = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            Font fntColumnHeader = new Font(btnColumnHeader, 10, 1, Color.DARK_GRAY);
            for (int i = 0; i < dtblTable.Columns.Count; i++)
            {
                PdfPCell cell = new PdfPCell();
                cell.BackgroundColor = new Color(153, 204, 255);
                cell.AddElement(new Chunk(dtblTable.Columns[i].ColumnName.ToUpper(), fntColumnHeader));
                table.AddCell(cell);
            }
            //table Data
            for (int i = 0; i < dtblTable.Rows.Count; i++)
            {
                for (int j = 0; j < dtblTable.Columns.Count; j++)
                {
                    table.AddCell(dtblTable.Rows[i][j].ToString());
                }
            }

            document.Add(table);
            document.Close();
            writer.Close();
            fs.Close();
        }

        public DataTable MakeDataTable(TerminDTO izabranTermin)
        {
            this.izabranLekar = lekariKontroler.PretraziPoId(izabranTermin.Lekar.KorisnickoIme);

            //Create friend table object
            DataTable tabela = new DataTable();
            
            //Define columns
            tabela.Columns.Add("Datum izdavanja");
            tabela.Columns.Add("Naziv leka");
            string jacina = "Jačina leka";
            byte[] bytes = Encoding.Default.GetBytes(jacina);
            jacina = Encoding.UTF8.GetString(bytes);
            tabela.Columns.Add(jacina);

            PacijentDTO p = naloziPacijenataKontroler.PretraziPoId(izabranTermin.IdPacijenta);

            foreach (ReceptDTO r in zdravstvenKartoniKontroler.DobaviReceptePacijenta(p.KorisnickoIme))
            {
                tabela.Rows.Add(new string[] { r.Datum.ToString("dd.MM.yyyy", System.Globalization.CultureInfo.InvariantCulture),
                        r.Lek.NazivLeka, r.Lek.Jacina });

            }


            return tabela;
        }

    }
}
