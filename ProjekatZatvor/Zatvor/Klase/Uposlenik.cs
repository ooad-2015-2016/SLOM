using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zatvor.Klase
{
    public abstract class Uposlenik
    {
        private string ime;
        private string prezime;
        private DateTime datumRodjenja;
        private string brojLicneKarte;
        private int jmbg;
        private string adresaStanovanja;
        private string funkcijaUposlenik;

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

        public string BrojLicneKarte
        {
            get
            {
                return brojLicneKarte;
            }

            set
            {
                brojLicneKarte = value;
            }
        }

        public int Jmbg
        {
            get
            {
                return jmbg;
            }

            set
            {
                jmbg = value;
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

        public string FunkcijaUposlenik
        {
            get
            {
                return funkcijaUposlenik;
            }

            set
            {
                funkcijaUposlenik = value;
            }
        }

        public Uposlenik(string ime, string prezime, DateTime datumRodjenja, string brojLicneKarte, int jmbg, string adresaStanovanja, string funkcijaUposlenik)
        {
            this.Ime = ime;
            this.Prezime = prezime;
            this.DatumRodjenja = datumRodjenja;
            this.BrojLicneKarte = brojLicneKarte;
            this.Jmbg = jmbg;
            this.AdresaStanovanja = adresaStanovanja;
            this.FunkcijaUposlenik = funkcijaUposlenik;
        }
    }
}
