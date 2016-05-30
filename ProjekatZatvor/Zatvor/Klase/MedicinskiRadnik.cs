using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zatvor.Klase;
using Zatvor_pokusaj2.Klase;

namespace Zatvor_pokusaj2.Klase
{
   public class MedicinskiRadnik : Uposlenik
    {
        public MedicinskiRadnik(string ime, string prezime, DateTime datumRodjenja, string jMBG, string adresaStanovanja, string funkcijaUposlenika, Korisnik login_podaci)
        {
            this.Ime = ime;
            this.Prezime = prezime;
            this.DatumRodjenja = datumRodjenja;
            this.JMBG = jMBG;
            this.AdresaStanovanja = adresaStanovanja;
            this.FunkcijaUposlenika = funkcijaUposlenika;
            this.Login_podaci = login_podaci;
        }
    }
}
