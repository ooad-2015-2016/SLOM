using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjekatZatvor.Klase
{
    class Zatvorenik
    {
        private string ime;
        private string prezime;
        private DateTime datum_rodjenja;
        private Dosje dosje;
        private ZdravstveniKarton zdravstveni_karton;
        private int id_zatvorenika;

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

        public DateTime Datum_rodjenja
        {
            get
            {
                return datum_rodjenja;
            }

            set
            {
                datum_rodjenja = value;
            }
        }

        public Dosje Dosje
        {
            get
            {
                return dosje;
            }

            set
            {
                dosje = value;
            }
        }

        public ZdravstveniKarton Zdravstveni_karton
        {
            get
            {
                return zdravstveni_karton;
            }

            set
            {
                zdravstveni_karton = value;
            }
        }

        public int Id_zatvorenika
        {
            get
            {
                return id_zatvorenika;
            }

            set
            {
                id_zatvorenika = value;
            }
        }
    }
}
