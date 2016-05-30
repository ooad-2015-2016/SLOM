using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zatvor_pokusaj2.Klase
{
    public class SigurnosniMehanizam
    {
        private DateTime vrijemeAktivacije;
        private string razlogAktivacije;
        private bool alarm;
        private bool zatvaranjeVrata;
        private bool obavijesti;

        public DateTime VrijemeAktivacije
        {
            get
            {
                return vrijemeAktivacije;
            }

            set
            {
                vrijemeAktivacije = value;
            }
        }

        public string RazlogAktivacije
        {
            get
            {
                return razlogAktivacije;
            }

            set
            {
                razlogAktivacije = value;
            }
        }

        public bool Alarm
        {
            get
            {
                return alarm;
            }

            set
            {
                alarm = value;
            }
        }

        public bool ZatvaranjeVrata
        {
            get
            {
                return zatvaranjeVrata;
            }

            set
            {
                zatvaranjeVrata = value;
            }
        }

        public bool Obavijesti
        {
            get
            {
                return obavijesti;
            }

            set
            {
                obavijesti = value;
            }
        }

        public SigurnosniMehanizam(DateTime vrijemeAktivacije, string razlogAktivacije, bool alarm, bool zatvaranjeVrata, bool obavijesti)
        {
            this.VrijemeAktivacije = vrijemeAktivacije;
            this.RazlogAktivacije = razlogAktivacije;
            this.Alarm = alarm;
            this.ZatvaranjeVrata = zatvaranjeVrata;
            this.Obavijesti = obavijesti;
        }
        public void AktivirajSigurnosniMehanizam()
        {
        }
    }
}
