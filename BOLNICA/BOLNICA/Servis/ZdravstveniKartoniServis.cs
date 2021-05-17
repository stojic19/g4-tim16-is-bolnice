using Bolnica.Model.Rukovanja;
using Bolnica.Repozitorijum;
using Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Bolnica.Model
{
    class ZdravstveniKartoniServis
    {

        public static List<ZdravstveniKarton> sviKartoni = new List<ZdravstveniKarton>();

        public static List<Lek> LekoviBezAlergena(String idIzabranogPacijenta)
        {
            List<Lek> lekoviBezAlergena = new List<Lek>();


            foreach (Lek l in LekoviRepozitorijum.SviLekovi)
            {
                if (!ProveraAlergicnosti(idIzabranogPacijenta, l.IDLeka))
                {
                    lekoviBezAlergena.Add(l);
                }
            }
            return lekoviBezAlergena;
        }

        public static Boolean ProveraAlergicnosti(String idIzabranogPacijenta, String idLeka)
        {
            Pacijent izabranPacijent = NaloziPacijenataServis.PretraziPoId(idIzabranogPacijenta);

            foreach (Alergeni a in izabranPacijent.ZdravstveniKarton.Alergeni)
            {
                if (a.IdAlergena.Equals(idLeka))
                {
                    return true;
                }
            }

            return false;
        }


        public static void DodajRecept(String idPacijenta, Recept novRecept)
        {
            foreach (Pacijent p in NaloziPacijenataServis.sviNaloziPacijenata)
            {

                if (p.KorisnickoIme.Equals(idPacijenta))
                {
                    p.ZdravstveniKarton.Recepti.Add(novRecept);
                    KartonLekar.Recepti.Add(novRecept);

                }
            }
        }

        public static List<Terapija> dobaviSveTerapijePacijenta(String idPacijenta)
        {
            List<Terapija> pomocna = new List<Terapija>();

            Pacijent p = NaloziPacijenataServis.PretraziPoId(idPacijenta);

            foreach (Anamneza a in p.ZdravstveniKarton.Anamneze)
            {
                if (a.IdPacijenta.Equals(p.KorisnickoIme))
                {
                    foreach (Terapija t in a.Terapije)
                    {

                        pomocna.Add(t);
                    }

                }

            }

            return pomocna;
        }

        public static void DodajAnamnezu(Anamneza a)
        {
            foreach (Pacijent p in NaloziPacijenataServis.sviNaloziPacijenata)
            {

                if (p.KorisnickoIme.Equals(a.IdPacijenta))
                {
                    p.ZdravstveniKarton.Anamneze.Add(a);
                    KartonLekar.Anamneze.Add(a);

                }
            }
        }

        public static void DodajUput(String idPacijenta,Uput noviUput)
        {
            foreach (Pacijent p in NaloziPacijenataServis.sviNaloziPacijenata)
            {

                if (p.KorisnickoIme.Equals(idPacijenta))
                {
                    p.ZdravstveniKarton.Uputi.Add(noviUput);
                    KartonLekar.Uputi.Add(noviUput);

                }
            }
        }

        public static List<Terapija> Privremeno { get; set; }

        public static void NovoPrivremeno()
        {
            Privremeno = new List<Terapija>();
        }

        public static void dodajPrivremeno(Terapija t)
        {

            Privremeno.Add(t);


        }

        public static void obrisiPrivremeno(Terapija t)
        {

            Privremeno.Remove(t);


        }

    }
}
