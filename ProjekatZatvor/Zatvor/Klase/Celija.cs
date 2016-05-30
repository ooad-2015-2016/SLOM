using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zatvor_pokusaj2.Klase
{
   public class Celija
    {
        private int brojCelije;
        private bool statusCelije; //True slobodna, False zauzeta
        private int idZatvorenika;

        public Celija(int brojCelije, bool statusCelije, int idZatvorenika)
        {
            this.brojCelije = brojCelije;
            this.statusCelije = statusCelije;
            this.idZatvorenika = idZatvorenika;
        }

        public int BrojCelije
        {
            get
            {
                return brojCelije;
            }

            set
            {
                brojCelije = value;
            }
        }

        public bool StatusCelije
        {
            get
            {
                return statusCelije;
            }

            set
            {
                statusCelije = value;
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
    }
}
