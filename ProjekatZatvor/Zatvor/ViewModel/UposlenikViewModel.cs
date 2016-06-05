using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zatvor.Klase;
using Zatvor_pokusaj2.Klase;
using Zatvor.DataSource;
using Zatvor.ViewModel;

namespace Zatvor.ViewModel
{
    public class UposlenikViewModel : Uposlenik
    {
        public bool ValidirajUposlenika(string ime, string prezime , string jmbg,string adresa, string funkcija )
        {
            try
            {
                if (ime == "") throw (new Exception());
                if (prezime == "") throw (new Exception());
                if (adresa == "") throw (new Exception());
                if (jmbg == "") throw (new Exception());
                if (funkcija == "") throw (new Exception());
                //Ime
                int unesenaDuzinaImena = ime.Length;
            int duzinaImena = 0;
            foreach (char c in ime)
            {
                if (c >= 'a' && c <= 'z' || c >= 'A' && c <= 'Z')
                {
                    duzinaImena++;
                }
            }
            if (duzinaImena != unesenaDuzinaImena)
            {
                throw (new Exception());

            } 
            //Prezime
                int unesenaDuzinaPrezimena = prezime.Length;
                int duzinaPrezimena = 0;
                foreach (char c in prezime)
                {
                    if (c >= 'a' && c <= 'z' || c >= 'A' && c <= 'Z')
                    {
                        duzinaPrezimena++;
                    }
                }
                if (duzinaPrezimena != unesenaDuzinaPrezimena)
                {
                    throw (new Exception());
                }
                //JMBG
                int unesenaDuzinaJMBG = jmbg.Length;
                int duzinaKartona = 0;
                foreach (char c in jmbg)
                {
                    if (c >= '0' && c <= '9')
                    {
                        duzinaKartona++;
                    }
                }
                if (duzinaKartona != unesenaDuzinaJMBG || unesenaDuzinaJMBG!=13)
                {
                    throw (new Exception());
                }
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
        public void ObrisiUposlenika(Uposlenik u)
        {
            foreach (Uposlenik p in DataSourceLikovi.k.Uposlenici)
            {
                if (u.Login_podaci.Username.Equals(p.Login_podaci.Username))
                {
                    DataSourceLikovi.k.Uposlenici.Remove(p);
                    break;
                }
            }
        }
    }
}
