using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zatvor.Klase;
using Zatvor_pokusaj2.Klase;

namespace Zatvor.ViewModel
{
   public class KontejnerViewModel
    {
        private static List<Korisnik> lista_k;
        private static List<Strazar> lista_s;
        private static List<Cuvar> lista_c;
        private static List<MedicinskiRadnik> lista_m;
        private static List<Uposlenik> lista_u;
        private static List<ProfilZatvorenika> lista_z;
        private static List<ZdravstveniKarton> lista_kartoni;
        private static List<Narudzba> lista_narudzbi;

        public KontejnerViewModel()
        {
        }

        public List<ZdravstveniKarton> DajSveKartone()
        {
            return lista_kartoni;
        }
        public List<ProfilZatvorenika> DajSveZatvorenike()
        {
            return lista_z;
        }
        public List<Korisnik> DajSveKorisnike()
        {
            return lista_k;
        }
        public List<Strazar> DajSveStrazare()
        {
            return lista_s;
        }
        public List<Cuvar> DajSveCuvare()
        {
            return lista_c;
        }
        public List<MedicinskiRadnik> DajSveMedicinare()
        {
            return lista_m;
        }
        public List<Uposlenik> DajSveUposlenike()
        {
            return lista_u;
        }
        public KontejnerViewModel(Kontejner a)
        {
            //lista_k = new List<Korisnik>(a.DajSveKorisnike());
            lista_s = new List<Strazar>(a.DajSveStrazare());
            lista_c = new List<Cuvar>(a.DajSveCuvare());
            lista_m = new List<MedicinskiRadnik>(a.DajSveMedicinare());
            lista_u = new List<Uposlenik>(a.DajSveUposlenike());
            lista_z = new List<ProfilZatvorenika>(a.DajSveZatvorenike());
            lista_kartoni = new List<ZdravstveniKarton>(a.DajSveKartone());
            lista_narudzbi = new List<Narudzba>(a.DajSveNarudzbe());
        }
        //Metoda koja mapira iz Modela(Klase) u ViewModel koji se koristi na View-u
        public static KontejnerViewModel KontejnerMetoda(Kontejner poslan)
        {
            KontejnerViewModel viewModel = new KontejnerViewModel(poslan);
            return viewModel;
        }
        public void DodajUposlenikaNaListu(Uposlenik neki)
        {
            //DataSource.DataSourceLikovi.k.
            lista_u.Add(neki);
            DataSource.DataSourceLikovi.k.Uposlenici = lista_u;
        }
        public void DodajZatvorenikaNaListu(ProfilZatvorenika neki)
        {
            lista_z.Add(neki);
            DataSource.DataSourceLikovi.k.Zatvorenici = lista_z;
        }
        public void DodajZdravstveniKarton(ZdravstveniKarton neki)
        {
            lista_kartoni.Add(neki);
            DataSource.DataSourceLikovi.k.Kartoni = lista_kartoni;
        }
        public void DodajNarudzbu (Narudzba narudzbenica)
        {
            lista_narudzbi.Add(narudzbenica);
            DataSource.DataSourceLikovi.k.Narudzbe = lista_narudzbi;
        }
    }
}
