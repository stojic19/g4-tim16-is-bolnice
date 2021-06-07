using Bolnica.Lokalizacija;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Bolnica
{
    public partial class App : Application
    {
        public ResourceDictionary ThemeDictionary
        {
            get { return Resources.MergedDictionaries[0]; }
        }

        public void PromenaTeme(Uri uri)
        {
            ThemeDictionary.MergedDictionaries.Clear();
            ThemeDictionary.MergedDictionaries.Add(new ResourceDictionary() { Source = uri });
        }

        public void PromenaJezika(string currLang)
        {
            if (currLang.Equals("en-US"))
            {
                Prevod.Instance.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            }
            else
            {
                Prevod.Instance.CurrentCulture = new System.Globalization.CultureInfo("sr-LATN");
            }

        }
    }
}
