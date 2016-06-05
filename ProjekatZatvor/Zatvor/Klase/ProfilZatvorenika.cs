using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zatvor_pokusaj2.Klase
{
   public class ProfilZatvorenika
    {
        private string ime;
        private bool osudjivanRanije;
        private string prezime;
        private DateTime datumRodjenja;
        private double visina;
        private double tezina;
        private string adresaStanovanja;
        private string brojLicneKarte;
        private string dodatniOpis;
        private string brojTelefona;
        private int idZatvorenika;
        private char tezinaPrekrsaja;
        private Celija celija;
        private int duzinaTrajanjaKazne;
        private ZdravstveniKarton medicinskiKarton;

        public ProfilZatvorenika(string ime, string prezime, string adresaStanovanja, string brojtelefona, DateTime datumRodjenja, string brojLicneKarte, string dodatniOpis, double visina, double tezina, bool osudjivanRanije, int id)
        {
            this.ime = ime;
            this.osudjivanRanije = osudjivanRanije;
            this.prezime = prezime;
            this.datumRodjenja = datumRodjenja;
            this.visina = visina;
            this.tezina = tezina;
            this.adresaStanovanja = adresaStanovanja;
            this.brojLicneKarte = brojLicneKarte;
            this.dodatniOpis = dodatniOpis;
            this.brojTelefona = brojtelefona;
            this.IdZatvorenika = id;
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

        public string DodatniOpis
        {
            get
            {
                return dodatniOpis;
            }

            set
            {
                dodatniOpis = value;
            }
        }

        public string BrojTelefona
        {
            get
            {
                return brojTelefona;
            }

            set
            {
                brojTelefona = value;
            }
        }

        public ZdravstveniKarton MedicinskiKarton
        {
            get
            {
                return medicinskiKarton;
            }

            set
            {
                medicinskiKarton = value;
            }
        }

        public override string ToString()
        {
            return "Ime i prezime: " + Ime + " " + Prezime + ", Broj LK: " + brojLicneKarte + ", ID: " + IdZatvorenika;
        }
        public void AzurirajPodatke(ProfilZatvorenika pz)
        {

        }
        public ProfilZatvorenika(ProfilZatvorenika p)
        {
            this.ime = p.ime;
            this.osudjivanRanije = p.osudjivanRanije;
            this.prezime = p.prezime;
            this.datumRodjenja = p.datumRodjenja;
            this.visina = p.visina;
            this.tezina = p.tezina;
            this.adresaStanovanja = p.adresaStanovanja;
            this.brojLicneKarte = p.brojLicneKarte;
            this.dodatniOpis = p.dodatniOpis;
            this.brojTelefona = p.brojTelefona;
            this.IdZatvorenika = p.IdZatvorenika;
        }
    }
}
