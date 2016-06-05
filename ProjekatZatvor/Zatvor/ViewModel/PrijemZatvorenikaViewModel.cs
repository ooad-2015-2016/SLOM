using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zatvor.Klase;
using Zatvor_pokusaj2.Klase;
using Zatvor.Forme;
using Zatvor.ViewModel;

namespace Zatvor.Forme
{
    class PrijemZatvorenikaViewModel
    {
        public bool ValidirajProfilZavorenika(string i, string prez, string adres, string brojtel, DateTime datum, string brlkarte, string opis, string vis, string tez)
        {
          try
            {
                if (DateTime.Today.Year - datum.Year < 10) throw (new Exception());
                int brojtelefona = Convert.ToInt32(brojtel);
                double visina = Convert.ToDouble(vis);
                double tezina = Convert.ToDouble(tez);
                //Validacija imena
                string ime = i;
                if (i == "") throw (new Exception());
                if (prez == "") throw (new Exception());
                if (adres == "") throw (new Exception());
                if (brojtel == "") throw (new Exception());
                if (brlkarte == "") throw (new Exception());
                if (opis == "") throw (new Exception());
                if (datum.ToString() == "") throw (new Exception());
                if (vis == "") throw (new Exception());
                if (tez == "") throw (new Exception());
                //Validacija imena
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

                //Validacija prezimena
                string prezime = prez;
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

                //Validacija broja licne karte
                string brojLicneKarte = brlkarte;
                int unesenaDuzinaKarte = brojLicneKarte.Length;
                int duzinaKarte = 0;
                foreach (char c in brojLicneKarte)
                {
                    if (c >= 'a' && c <= 'z' || c >= 'A' && c <= 'Z' || c >= '0' && c <= '9')
                    {
                        duzinaKarte++;
                    }
                }
                if (duzinaKarte != unesenaDuzinaKarte || duzinaKarte != 9)
                {
                    throw (new Exception());
                }
                //Validacija tezine
                if (visina < 0 || visina > 250) throw(new Exception());
                //Validacija visine
                if(tezina <0 || tezina > 250) throw (new Exception());


            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}
