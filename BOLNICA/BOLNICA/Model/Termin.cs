
using System;

public class Termin
{
   public String idTermina;
   public VrsteTermina vrstaTermina;
   public DateTime pocetnoVreme;
   public DateTime krajnjeVreme;
   
   public Prostor prostor;
   
 
   public Prostor Prostor
   {
      get
      {
         return prostor;
      }
      set
      {
         this.prostor = value;
      }
   }
   public Pacijent pacijent;
   
   public Pacijent Pacijent
   {
      get
      {
         return pacijent;
      }
      set
      {
         this.pacijent = value;
      }
   }
   public Lekar lekar;
   
   public Lekar Lekar
   {
      get
      {
         return lekar;
      }
      set
      {
         this.lekar = value;
      }
   }

}