using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zatvor.DataSource;
using Zatvor_pokusaj2.Klase;

namespace Zatvor.ViewModel
{
    class ProfilZatvorenikaViewModel
    {
        public ProfilZatvorenika OtvoriProfilZatvorenika(int ID)
        {
            List<ProfilZatvorenika> zatvorenici = DataSourceLikovi.k.DajSveZatvorenike();
            foreach (ProfilZatvorenika p in zatvorenici)
            {
                if (p.IdZatvorenika == ID)
                {
                    return p;
                }
            }
            throw new Exception();
        }
        public void ObrisiProfilZatvorenika(ProfilZatvorenika profil)
        {
            foreach (ProfilZatvorenika p in DataSourceLikovi.k.Zatvorenici)
            {
                if (profil.IdZatvorenika.Equals(p.IdZatvorenika))
                {
                    DataSourceLikovi.k.Zatvorenici.Remove(p);
                    break;
                }
            }
        }
    }
}
