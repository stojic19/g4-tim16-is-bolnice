using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.Repozitorijum.Interfejsi
{
    public interface ZakazaniTerminiRepozitorijumInterfejs : GlavniRepozitorijumInterfejs<Termin>
    {
        Termin ZakaziTermin(Termin t, String lekar);
        

        Boolean OtkaziTermin(String idTermina);
  
        Boolean OtkaziPregledSekretar(String idTermina);
    
        bool DaLiListeSadrzeTerminSekretar(Termin termin);
        

        Boolean IzmeniTermin(Termin stari, Termin novi, String korisnik);
        

        List<Termin> PretraziPoLekaru(String korImeLekara);
      

        List<Termin> DobaviSveSlobodneTermine();
       
        List<Termin> DobaviSveZakazaneTermine();
        

        List<Termin> DobaviSveZakazaneTerminePacijenta(String pacijentKorisnickoIme);
     

        
        Termin DobaviZakazanTerminPoId(String idTermina);
        
        void ObrisiZakazanTermin(Termin terminZaBrisanje);
       
      
        
        void SacuvajZakazanTermin(Termin terminZaUpis);
        void IzmeniTermin(Termin termin);
    }
}
