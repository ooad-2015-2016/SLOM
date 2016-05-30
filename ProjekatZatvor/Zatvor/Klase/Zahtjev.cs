using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zatvor_pokusaj2.Klase
{
    public class Zahtjev
    {
        private int idZahtjeva;
        private string vrstaZahtjeva;
        private bool hitno;
        private bool status; //True prihvacen, False odbijen

        public int IdZahtjeva
        {
            get
            {
                return idZahtjeva;
            }

            set
            {
                idZahtjeva = value;
            }
        }

        public string VrstaZahtjeva
        {
            get
            {
                return vrstaZahtjeva;
            }

            set
            {
                vrstaZahtjeva = value;
            }
        }

        public bool Hitno
        {
            get
            {
                return hitno;
            }

            set
            {
                hitno = value;
            }
        }

        public bool Status
        {
            get
            {
                return status;
            }

            set
            {
                status = value;
            }
        }
    }
}
