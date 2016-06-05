using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zatvor.Klase;
using Zatvor_pokusaj2.Klase;
using Zatvor.DataSource;

namespace Zatvor.Klase
{
   public class Kontejner
    {
        public List<Cuvar> Cuvari;
        public List<Strazar> Strazari;
        public List<MedicinskiRadnik> Medicinari;
        public List<Korisnik> Korisnici;
        public List<Uposlenik> Uposlenici;
        public List<ProfilZatvorenika> Zatvorenici;
        public List<ZdravstveniKarton> Kartoni;
        public List<Narudzba> Narudzbe;
        public Kontejner()
        {
            Cuvari = DataSource.DataSourceLikovi.DajSveCuvare();
            Strazari = DataSource.DataSourceLikovi.DajSveStrazare();
            Medicinari = DataSource.DataSourceLikovi.DajSveMedicinare();
            //Korisnici = DataSource.DataSourceLikovi.DajSveKorisnike();
            Uposlenici = DataSource.DataSourceLikovi.DajSveUposlenike();
            Zatvorenici = DataSourceLikovi.DajSveZatvorenike();
            Kartoni = DataSource.DataSourceLikovi.DajSveKartone();
            Narudzbe = DataSource.DataSourceLikovi.DajSveNarudzbe();
        }
        //public List<Narudzba> NarudzbeNaCekanju { get; set; }
       public List<Korisnik> DajSveKorisnike()
        {
            return Korisnici;
        }
        public List<MedicinskiRadnik> DajSveMedicinare()
        {
            return Medicinari;
        }
        public List<Strazar> DajSveStrazare()
        {
            return Strazari;
        }
        public List<Cuvar> DajSveCuvare()
        {
            return Cuvari;
        }
        public List<Uposlenik> DajSveUposlenike()
        {
            return Uposlenici; ;
        }
        public List<ProfilZatvorenika> DajSveZatvorenike()
        {
            return Zatvorenici;
        }
        public List<ZdravstveniKarton> DajSveKartone()
        {
            return Kartoni;
        }
        public List<Narudzba> DajSveNarudzbe()
        {
            return Narudzbe;
        }
    }
}
