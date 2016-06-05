using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zatvor_pokusaj2.Klase
{
   public class ZdravstveniKarton
    {
        private string brojKartona;
        private string ime;
        private string prezime;
        private string dijagnoza;
        private string terapija;

        public ZdravstveniKarton(string ime, string prezime, string brojKartona, string dijagnoza, string terapija)
        {
            this.ime = ime;
            this.prezime = prezime;
            this.brojKartona = brojKartona;
            this.dijagnoza = dijagnoza;
            this.terapija = terapija;
        }

        public string BrojKartona
        {
            get
            {
                return brojKartona;
            }

            set
            {
                brojKartona = value;
            }
        }

        public string Dijagnoza
        {
            get
            {
                return dijagnoza;
            }

            set
            {
                dijagnoza = value;
            }
        }

        public string Terapija
        {
            get
            {
                return terapija;
            }

            set
            {
                terapija = value;
            }
        }

        public string Ime
        {
            get
            {
                return ime;
            }

            set
            {
                ime = value;
            }
        }

        public string Prezime
        {
            get
            {
                return prezime;
            }

            set
            {
                prezime = value;
            }
        }

        public void promijeniTerapiju(string terapija)
        {
        }
        public void promijeniTrenutnuDijagnozu(string dijagnoza)
        {
        }
        
    }
}
