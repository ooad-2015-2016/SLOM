using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zatvor.Klase;
using Zatvor_pokusaj2.Klase;

namespace Zatvor.ViewModel
{
    class ZdravstveniKartonViewModel
    {
        public bool ValidirajZdravstveniKarton(string dijagnoza, string terapija)
        {
            try
            {
                if (dijagnoza == "") throw (new Exception());
                if (terapija == "") throw (new Exception());
            }
            catch(Exception)
            {
                return false;
            }
            return true;
            
        }

        public ZdravstveniKarton KreirajZdravstveniKarton(string ime, string prezime, string brKartona, string dijagnoza, string terapija)
        {
            return new ZdravstveniKarton(ime, prezime, brKartona, dijagnoza, terapija);
        }

        public void IzmijeniDijagnozu(ZdravstveniKarton karton, string dijagnoza)
        {
            karton.Dijagnoza = dijagnoza;
        }

        public void IzmijeniTerapiju(ZdravstveniKarton karton, string terapija)
        {
            karton.Terapija = terapija;
        }
        public ProfilZatvorenika OtvoriZdravstveniKarton(string id)
        {
            List<ProfilZatvorenika> zatvorenici = DataSource.DataSourceLikovi.k.DajSveZatvorenike();
            foreach (ProfilZatvorenika pz in zatvorenici)
            {
                if (pz.IdZatvorenika.ToString().Equals(id))
                {
                    return pz;
                    break;
                }
            }
            throw (new Exception());
        }
    }
}
