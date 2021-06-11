// File:    TipGreske.cs
// Author:  aleks
// Created: Friday, June 11, 2021 0:27:06
// Purpose: Definition of Enum TipGreske

using System;
using System.ComponentModel;

namespace Model
{
   public enum TipFunkcije
   {
        [Description("Interfejs")]
        interfejs,
        [Description("Funkcija")]
        funkcija
   }
}