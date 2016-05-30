using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zatvor.Klase;

namespace Zatvor_pokusaj2.Klase
{
   public abstract class Uposlenik
    {
        private string ime;
        private string prezime;
        private DateTime datumRodjenja;
        private string jMBG;
        private string adresaStanovanja;
        private string funkcijaUposlenika;
        private Korisnik login_podaci;
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

        public DateTime DatumRodjenja
        {
            get
            {
                return datumRodjenja;
            }

            set
            {
                datumRodjenja = value;
            }
        }

        public string JMBG
        {
            get
            {
                return jMBG;
            }

            set
            {
                jMBG = value;
            }
        }

        public string AdresaStanovanja
        {
            get
            {
                return adresaStanovanja;
            }

            set
            {
                adresaStanovanja = value;
            }
        }

        public string FunkcijaUposlenika
        {
            get
            {
                return funkcijaUposlenika;
            }

            set
            {
                funkcijaUposlenika = value;
            }
        }

        internal Korisnik Login_podaci
        {
            get
            {
                return login_podaci;
            }

            set
            {
                login_podaci = value;
            }
        }
        public override string ToString()
        {
            return Ime + " " + Prezime + " " + FunkcijaUposlenika;
        }
    }
}
