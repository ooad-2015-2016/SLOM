using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zatvor_pokusaj2.Klase
{
    class FinansijskiSavjetnik : Uposlenik
    {
        private List<Narudzba> narudzbeNaCekanju;

        public List<Narudzba> NarudzbeNaCekanju
        {
            get
            {
                return narudzbeNaCekanju;
            }

            set
            {
                narudzbeNaCekanju = value;
            }
        }
    }
}
