using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zatvor_pokusaj2.Klase
{
    class ProfilZatvorenika
    {
        private string ime;
        private bool osudjivanRanije;
        private string prezime;
        private DateTime datumRodjenja;
        private double visina;
        private double tezina;
        private string adresaStanovanja;
        private int idZatvorenika;
        private int duzinaTrajanjaKazne;
        private char tezinaPrekrsaja;
        private Celija celija;

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

        public bool OsudjivanRanije
        {
            get
            {
                return osudjivanRanije;
            }

            set
            {
                osudjivanRanije = value;
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

        public double Visina
        {
            get
            {
                return visina;
            }

            set
            {
                visina = value;
            }
        }

        public double Tezina
        {
            get
            {
                return tezina;
            }

            set
            {
                tezina = value;
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

        public int IdZatvorenika
        {
            get
            {
                return idZatvorenika;
            }

            set
            {
                idZatvorenika = value;
            }
        }

        public int DuzinaTrajanjaKazne
        {
            get
            {
                return duzinaTrajanjaKazne;
            }

            set
            {
                duzinaTrajanjaKazne = value;
            }
        }

        public char TezinaPrekrsaja
        {
            get
            {
                return tezinaPrekrsaja;
            }

            set
            {
                tezinaPrekrsaja = value;
            }
        }

        public Celija Celija
        {
            get
            {
                return celija;
            }

            set
            {
                celija = value;
            }
        }
        public void AzurirajPodatke(ProfilZatvorenika pz)
        {

        }
    }
}
