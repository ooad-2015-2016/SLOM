using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zatvor_pokusaj2.Klase
{
    public class Narudzba
    {
        private string imeArtikla;
        private double kolicinaArtikla;
        private int idNarudzbe;
        private bool statusNarudzbe;
        public static int brojac = 0;

        public string ImeArtikla
        {
            get
            {
                return imeArtikla;
            }

            set
            {
                imeArtikla = value;
            }
        }

        public double KolicinaArtikla
        {
            get
            {
                return kolicinaArtikla;
            }

            set
            {
                kolicinaArtikla = value;
            }
        }

        public int IdNarudzbe
        {
            get
            {
                return idNarudzbe;
            }

            set
            {
                idNarudzbe = value;
            }
        }

        public bool StatusNarudzbe
        {
            get
            {
                return statusNarudzbe;
            }

            set
            {
                statusNarudzbe = value;
            }
        }

        public Narudzba(string imeArtikla, double kolicinaArtikla, bool statusNarudzbe)
        {
            this.ImeArtikla = imeArtikla;
            this.KolicinaArtikla = kolicinaArtikla;
            this.IdNarudzbe = System.Threading.Interlocked.Increment(ref brojac);
            this.StatusNarudzbe = statusNarudzbe;
        }
    }
}
