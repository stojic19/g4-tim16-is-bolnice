// File:    ZdravstveniKarton.cs
// Author:  aleks
// Created: Tuesday, March 30, 2021 13:30:41
// Purpose: Definition of Class ZdravstveniKarton

using System;

namespace Model
{
   public class ZdravstveniKarton
   {
      public System.Collections.Generic.List<Alergeni> alergeni;
      
      /// <summary>
      /// Property for collection of Alergeni
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.Generic.List<Alergeni> Alergeni
      {
         get
         {
            if (alergeni == null)
               alergeni = new System.Collections.Generic.List<Alergeni>();
            return alergeni;
         }
         set
         {
            RemoveAllAlergeni();
            if (value != null)
            {
               foreach (Alergeni oAlergeni in value)
                  AddAlergeni(oAlergeni);
            }
         }
      }
      
      /// <summary>
      /// Add a new Alergeni in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddAlergeni(Alergeni newAlergeni)
      {
         if (newAlergeni == null)
            return;
         if (this.alergeni == null)
            this.alergeni = new System.Collections.Generic.List<Alergeni>();
         if (!this.alergeni.Contains(newAlergeni))
            this.alergeni.Add(newAlergeni);
      }
      
      /// <summary>
      /// Remove an existing Alergeni from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveAlergeni(Alergeni oldAlergeni)
      {
         if (oldAlergeni == null)
            return;
         if (this.alergeni != null)
            if (this.alergeni.Contains(oldAlergeni))
               this.alergeni.Remove(oldAlergeni);
      }
      
      /// <summary>
      /// Remove all instances of Alergeni from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllAlergeni()
      {
         if (alergeni != null)
            alergeni.Clear();
      }
      public System.Collections.Generic.List<Recept> recept;
      
      /// <summary>
      /// Property for collection of Recept
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.Generic.List<Recept> Recept
      {
         get
         {
            if (recept == null)
               recept = new System.Collections.Generic.List<Recept>();
            return recept;
         }
         set
         {
            RemoveAllRecept();
            if (value != null)
            {
               foreach (Recept oRecept in value)
                  AddRecept(oRecept);
            }
         }
      }
      
      /// <summary>
      /// Add a new Recept in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddRecept(Recept newRecept)
      {
         if (newRecept == null)
            return;
         if (this.recept == null)
            this.recept = new System.Collections.Generic.List<Recept>();
         if (!this.recept.Contains(newRecept))
            this.recept.Add(newRecept);
      }
      
      /// <summary>
      /// Remove an existing Recept from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveRecept(Recept oldRecept)
      {
         if (oldRecept == null)
            return;
         if (this.recept != null)
            if (this.recept.Contains(oldRecept))
               this.recept.Remove(oldRecept);
      }
      
      /// <summary>
      /// Remove all instances of Recept from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllRecept()
      {
         if (recept != null)
            recept.Clear();
      }
      public System.Collections.Generic.List<Anamneza> anamneza;
      
      /// <summary>
      /// Property for collection of Anamneza
      /// </summary>
      /// <pdGenerated>Default opposite class collection property</pdGenerated>
      public System.Collections.Generic.List<Anamneza> Anamneza
      {
         get
         {
            if (anamneza == null)
               anamneza = new System.Collections.Generic.List<Anamneza>();
            return anamneza;
         }
         set
         {
            RemoveAllAnamneza();
            if (value != null)
            {
               foreach (Anamneza oAnamneza in value)
                  AddAnamneza(oAnamneza);
            }
         }
      }
      
      /// <summary>
      /// Add a new Anamneza in the collection
      /// </summary>
      /// <pdGenerated>Default Add</pdGenerated>
      public void AddAnamneza(Anamneza newAnamneza)
      {
         if (newAnamneza == null)
            return;
         if (this.anamneza == null)
            this.anamneza = new System.Collections.Generic.List<Anamneza>();
         if (!this.anamneza.Contains(newAnamneza))
            this.anamneza.Add(newAnamneza);
      }
      
      /// <summary>
      /// Remove an existing Anamneza from the collection
      /// </summary>
      /// <pdGenerated>Default Remove</pdGenerated>
      public void RemoveAnamneza(Anamneza oldAnamneza)
      {
         if (oldAnamneza == null)
            return;
         if (this.anamneza != null)
            if (this.anamneza.Contains(oldAnamneza))
               this.anamneza.Remove(oldAnamneza);
      }
      
      /// <summary>
      /// Remove all instances of Anamneza from the collection
      /// </summary>
      /// <pdGenerated>Default removeAll</pdGenerated>
      public void RemoveAllAnamneza()
      {
         if (anamneza != null)
            anamneza.Clear();
      }
   
   }
}