using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zatvor_pokusaj2.Klase
{
    public class Zahtjev
    {
        private string podaciOZatvoreniku;
        private string obrazlozenje;
        private DateTime pocetniDatum;
        private DateTime krajnjiDatum;
        private bool status; //True prihvacen, False odbijen

        public Zahtjev(string podaciOZatvoreniku, string obrazlozenje, DateTime pocetniDatum, DateTime krajnjiDatum, bool status)
        {
            this.podaciOZatvoreniku = podaciOZatvoreniku;
            this.obrazlozenje = obrazlozenje;
            this.pocetniDatum = pocetniDatum;
            this.krajnjiDatum = krajnjiDatum;
            this.status = status;
        }

        public string PodaciOZatvoreniku
        {
            get
            {
                return podaciOZatvoreniku;
            }

            set
            {
                podaciOZatvoreniku = value;
            }
        }

        public string Obrazlozenje
        {
            get
            {
                return obrazlozenje;
            }

            set
            {
                obrazlozenje = value;
            }
        }

        public DateTime PocetniDatum
        {
            get
            {
                return pocetniDatum;
            }

            set
            {
                pocetniDatum = value;
            }
        }

        public DateTime KrajnjiDatum
        {
            get
            {
                return krajnjiDatum;
            }

            set
            {
                krajnjiDatum = value;
            }
        }

        public bool Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }
        public override string ToString()
        {
            if(this.Status)
                return PodaciOZatvoreniku + " " + Obrazlozenje + " Status: ODOBREN";
    
            else
                return PodaciOZatvoreniku + " " + Obrazlozenje +  "Status: ODBIJEN";

        }
    }
}
