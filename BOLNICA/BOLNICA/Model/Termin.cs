// File:    Termin.cs
// Author:  Jelena
// Created: Friday, March 26, 2021 12:40:47 PM
// Purpose: Definition of Class Termin

using System;

namespace Model
{
   public class Termin
   {
      public String idTermina;
      public VrsteTermina vrstaTermina;
      public DateTime pocetnoVreme;
      public DateTime krajnjeVreme;
      
      public Prostor prostor;
      
      /// <summary>
      /// Property for Prostor
      /// </summary>
      /// <pdGenerated>Default opposite class property</pdGenerated>
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
      
      /// <summary>
      /// Property for Pacijent
      /// </summary>
      /// <pdGenerated>Default opposite class property</pdGenerated>
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
      
      /// <summary>
      /// Property for Lekar
      /// </summary>
      /// <pdGenerated>Default opposite class property</pdGenerated>
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
}