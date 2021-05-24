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
        NaloziPacijenataServis naloziPacijenataServis = new NaloziPacijenataServis();

        public static List<ZdravstveniKarton> sviKartoni = new List<ZdravstveniKarton>();

        public List<Lek> LekoviBezAlergena(String idIzabranogPacijenta)
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

        public Boolean ProveraAlergicnosti(String idIzabranogPacijenta, String idLeka)
        {
            Pacijent izabranPacijent = naloziPacijenataServis.PretraziPoId(idIzabranogPacijenta);

            foreach (Alergeni a in izabranPacijent.ZdravstveniKarton.Alergeni)
            {
                if (a.IdAlergena.Equals(idLeka))
                {
                    return true;
                }
            }

            return false;
        }


        public void DodajRecept(String idPacijenta, Recept novRecept)
        {
            foreach (Pacijent p in naloziPacijenataServis.SviNalozi())
            {

                if (p.KorisnickoIme.Equals(idPacijenta))
                {
                    p.ZdravstveniKarton.Recepti.Add(novRecept);
                    KartonLekar.Recepti.Add(novRecept);

                }
            }
        }

        public List<Terapija> dobaviSveTerapijePacijenta(String idPacijenta)
        {
            List<Terapija> pomocna = new List<Terapija>();

            Pacijent p = naloziPacijenataServis.PretraziPoId(idPacijenta);

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

        public void DodajAnamnezu(Anamneza a)
        {
            foreach (Pacijent p in naloziPacijenataServis.SviNalozi())
            {

                if (p.KorisnickoIme.Equals(a.IdPacijenta))
                {
                    p.ZdravstveniKarton.Anamneze.Add(a);
                    KartonLekar.Anamneze.Add(a);

                }
            }
        }

        public void DodajUput(String idPacijenta,Uput noviUput)
        {
            foreach (Pacijent p in naloziPacijenataServis.SviNalozi())
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
