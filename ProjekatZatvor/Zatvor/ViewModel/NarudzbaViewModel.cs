using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zatvor.Klase;
using Zatvor_pokusaj2.Klase;
using Zatvor.Forme;

namespace Zatvor.ViewModel
{
    class NarudzbaViewModel
    {
        public bool ValidirajNarudzbu(string naziv, string kolicina)
        {
           

            bool validna = true;
            try
            {
                if (naziv == "") throw (new Exception());
                if (kolicina == "") throw (new Exception());
                double kol = Convert.ToDouble(kolicina);
            }
            catch (Exception)
            {
                validna = false;
            }
            return validna;
        }

        public void OdobriNarudzbu(Narudzba n)
        {
            n.StatusNarudzbe = true;
        }

        public Narudzba KreirajNarudzbu(string naziv, string kolicina)
        {
            double kol = Convert.ToDouble(kolicina);
            return new Narudzba(naziv, kol, false);
        }
    }
}
