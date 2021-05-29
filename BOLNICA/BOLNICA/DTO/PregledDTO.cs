using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bolnica.DTO
{
    public class PregledDTO
    {
        private String idPregleda;
        private Boolean odrzan;
        private TerminDTO termin;
        private AnamnezaDTO anamneza;
        private List<ReceptDTO> recepti;
        private bool ocenjenPregled;

        public String IdPregleda
        {
            get { return idPregleda; }
            set { idPregleda = value; }
        }
        public bool Odrzan
        {
            get { return odrzan; }
            set { odrzan = value; }
        }
        public TerminDTO Termin
        {
            get { return termin; }
            set { termin = value; }
        }
        public AnamnezaDTO Anamneza
        {
            get { return anamneza; }
            set { anamneza = value; }
        }
        public List<ReceptDTO> Recepti
        {
            get { return recepti; }
            set { recepti = value; }
        }
        public bool OcenjenPregled
        {
            get { return ocenjenPregled; }
            set { ocenjenPregled = value; }
        }
        PregledDTO() { }

        public PregledDTO(string idPregleda, bool odrzan, TerminDTO termin, AnamnezaDTO anamneza, List<ReceptDTO> recepti, bool ocenjenPregled)
        {
            this.idPregleda = idPregleda;
            this.odrzan = odrzan;
            this.termin = termin;
            this.anamneza = anamneza;
            this.recepti = recepti;
            this.ocenjenPregled = ocenjenPregled;
        }
    }
}
