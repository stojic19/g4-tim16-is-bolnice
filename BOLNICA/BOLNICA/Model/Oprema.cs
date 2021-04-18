using System;
using System.ComponentModel;

namespace Model
{
    public class Oprema : INotifyPropertyChanged
    {
        public String IdOpreme { get; set; }
        public String NazivOpreme { get; set; }
        public VrsteOpreme VrstaOpreme { get; set; }
        public int Kolicina { get; set; }

        public Oprema() { }

        public Oprema(String idOpreme, String nazivOpreme, VrsteOpreme vrstaOpreme, int kolicina)
        {
            IdOpreme = idOpreme;
            NazivOpreme = nazivOpreme;
            VrstaOpreme = vrstaOpreme;
            Kolicina = kolicina;
        }

        public Oprema(String idOpreme, String nazivOpreme, int kolicina)
        {
            IdOpreme = idOpreme;
            NazivOpreme = nazivOpreme;
            Kolicina = kolicina;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
