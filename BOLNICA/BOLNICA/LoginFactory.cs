using Bolnica.DTO;
using Bolnica.Kontroler;
using Bolnica.LekarFolder;
using Bolnica.Model.Enumi;
using Bolnica.View.AdminView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Bolnica.Servis
{
    public class LoginFactory
    {
        public static Window OtvoriProzor(TipoviKorisnika tipKorisnika, String korisnickoIme)
        {
            Window prozor = null;

            switch (tipKorisnika)
            {
                case TipoviKorisnika.LEKAR:
                    prozor = new LekarGlavniProzor(korisnickoIme);
                    break;

                case TipoviKorisnika.PACIJENT:
                    prozor = new PacijentGlavniProzor(korisnickoIme);
                    break;

                case TipoviKorisnika.SEKRETAR:
                    prozor = GlavniProzorSekretar.getInstance(korisnickoIme);
                    break;

                case TipoviKorisnika.UPRAVNIK:
                    prozor = UpravnikGlavniProzor.getInstance();
                    break;

                case TipoviKorisnika.ADMIN:
                    prozor = GlavniProzorAdmin.getInstance(); ;
                    break;

            }

            return prozor;

        }

    }
}
