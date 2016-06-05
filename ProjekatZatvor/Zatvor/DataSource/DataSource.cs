using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zatvor.Klase;
using Zatvor_pokusaj2.Klase;

namespace Zatvor.DataSource
{
    //[assembly: InternalsVisibleTo("Kontejner")]
    public class DataSourceLikovi
    {
       public static int Brojac = 10004;
        public DataSourceLikovi() { }
        private static List<Korisnik> _korisnici = new List<Korisnik>()
        {
            new Korisnik("Cuvar","Cuvar123"),
            new Korisnik("Strazar","Strazar123"),
            new Korisnik("Upravnik", "Upravnik123"),
            new Korisnik("Doktor", "Dr123"),
            new Korisnik("Kuhar", "Zeljanica")
        };
        private static List<Narudzba> _narudzbe = new List<Narudzba>()
        {
                new Narudzba("Krompir",10,false),
                new Narudzba("Kupus",10,false),
                new Narudzba("Jaja",30,false)
           
        };
        private static List<Cuvar> _cuvari = new List<Cuvar>()
        {
            new Cuvar("Dzevad","Poturak",new DateTime(2008, 5, 1, 8, 30, 52),"1234567890123","Zmaja od Bosne bb.","Cuvar",new Korisnik("Cuvar","Cuvar123")),
            new Cuvar("Nikola","Nakic",new DateTime(2008, 5, 1, 8, 30, 52),"1234567890124","Avde Hume 32","Cuvar",new Korisnik("Meho","Meho123")),
            new Cuvar("Ivan","Herceg",new DateTime(2008, 5, 1, 8, 30, 52),"1234567890125","Fadila Jahića Spanca 33","Cuvar",new Korisnik("opala","Strazar123"))
        };
        private static List<Strazar> _strazari = new List<Strazar>()
        {
            new Strazar("Milorad","Dodik",new DateTime(2008, 5, 1, 8, 30, 52),"1234327890123","Laktaši 34","Strazar",new Korisnik("Strazar","Strazar123")),
            new Strazar("Dragan","Covic",new DateTime(2008, 5, 1, 8, 30, 52),"1234567900124","Franje Tuđmana 25","Strazar",new Korisnik("opcup","beng")),
            new Strazar("Bakir","Izetbegovic",new DateTime(2008, 5, 1, 8, 30, 52),"1232567890125","Alije Izetbegovica 32","Strazar",new Korisnik("mmm","grr"))
        };
        private static List<MedicinskiRadnik> _medicinari = new List<MedicinskiRadnik>()
        {
            new MedicinskiRadnik("Emina","Čekić",new DateTime(1995, 6, 17, 8, 30, 52),"1232527890123","Skenderija","Medicinski radnik",new Korisnik("Medo","Radnik123")),
            new MedicinskiRadnik("Zerina","Šahović",new DateTime(1995, 5, 1, 8, 30, 52),"2523256891023","Vrazova 44","Medicinski radnik",new Korisnik("Medi","Radnik"))
        };
        private static List<ProfilZatvorenika> _zatvorenici = new List<ProfilZatvorenika>()
        {
            new ProfilZatvorenika("Tarik","Omeragić","Olimpijska 28", "061224161", new DateTime(1995, 6, 18, 6, 40, 54), "9H63F3F2A", "AAAAAAAAAAAA biži biži", 188, 90, true,10000),
            new ProfilZatvorenika("Mia", "Muminović", "Trg medjunarodnog prijateljstva 12", "061945535", new DateTime(1995, 9, 5, 12,40,35), "ABC123EFG", "Fakat da je osudjivana", 172, 52, true,10001),
            new ProfilZatvorenika("Haris", "Suljić", "Hrasno brdo seljačina 22", "061268512", new DateTime(1995, 6, 12, 11,44,48), "456HIJ789", "Doktor iz gorazda", 184, 74, true,10002),
            new ProfilZatvorenika("Faris", "Lemeš", "Grbavička 78", "062143897", new DateTime(1995, 12, 8, 10,30,35), "KLM101NOP", "Normala nije osuđivan. Nemojte ga puno", 192, 82, false,10003)
        };
        /*private static List<Narudzba> _narudzbe = new List<Narudzba>()
        {
            new Narudzba("Mlijeko",3,false),
            new Narudzba("Hljeb",4,false),
            new Narudzba("Jaja",30,false)
        };*/
        private static List<FinansijskiSavjetnik> _finansijski = new List<FinansijskiSavjetnik>()
        {
            new FinansijskiSavjetnik("Refko","Krampa", new DateTime(1997, 5, 1, 8, 30, 52),"1232527890123", "Vrazova 44","Finansijski savjetnik", new Korisnik("Refko.Krampa","Refko123"))           
        };
        private static List<RadnikUKantini> _kantiner = new List<RadnikUKantini>()
        {

        };
        private static List<ZdravstveniKarton> _kartoni = new List<ZdravstveniKarton>()
        {
            new ZdravstveniKarton("Mia", "Muminovic", "15664", "Prehlada", "Antibiotik"),
            new ZdravstveniKarton("Tarik","Omeragic", "15232","Migrena", "Neofen"),

        };
        private static Upravnik _upravnik = new Upravnik("Hamdo", "Lampa", new DateTime(1997, 5, 1, 8, 30, 52), "1232527890123", "Vrazova 44", "Upravnik", new Korisnik("Upravnik", "Upravnik123"));
        private static List<Uposlenik> _uposlenici = new List<Uposlenik>();

        public static List<Uposlenik> DajSveUposlenike()
        {
            foreach (Strazar s in DataSource.DataSourceLikovi.DajSveStrazare())
            {
                Uposlenici.Add(s);
            }
            foreach (Cuvar c in DataSource.DataSourceLikovi.DajSveCuvare())
            {
                Uposlenici.Add(c);
            }
            foreach (MedicinskiRadnik m in DataSource.DataSourceLikovi.DajSveMedicinare())
            {
                Uposlenici.Add(m);
            }
            foreach (FinansijskiSavjetnik f in DataSource.DataSourceLikovi.DajSveFinansijske())
            {
                Uposlenici.Add(f);
            }
            foreach (RadnikUKantini k in DataSource.DataSourceLikovi.DajSveKantinere())
            {
                Uposlenici.Add(k);
            }
            Uposlenici.Add(Upravnik);
            return Uposlenici;
        }
        public static List<Narudzba> DajSveNarudzbe()
        {
            return _narudzbe;
        }
        public static List<RadnikUKantini> DajSveKantinere()
        {
            return _kantiner;
        }
        public static List<FinansijskiSavjetnik> DajSveFinansijske()
        {
            return _finansijski;
        }
        public static List<ProfilZatvorenika> DajSveZatvorenike()
        {
            return Zatvorenici;
        }
        public static List<Korisnik> DajSveKorisnike()
        {
            return _korisnici;
        }
        public static Korisnik DajKorisnikaPoUsername(string username)
        {
            return _korisnici.Where(k => k.username.Equals(username)).FirstOrDefault();
        }

        public static List<Cuvar> DajSveCuvare()
        {
            return _cuvari;
        }
        public static Cuvar DajCuvaraPoImenu(string ime)
        {
            return _cuvari.Where(k => k.Ime.Equals(ime)).FirstOrDefault();
        }
        public static Cuvar DajCuvaraPoJMBG(string jmbg)
        {
            return _cuvari.Where(k => k.JMBG.Equals(jmbg)).FirstOrDefault();
        }
        public static List<Strazar> DajSveStrazare()
        {
            return _strazari;
        }
        public static Strazar DajStrazaraPoImenu(string ime)
        {
            return _strazari.Where(k => k.Ime.Equals(ime)).FirstOrDefault();
        }
        public static Strazar DajStrazaraPoJMBG(string jmbg)
        {
            return _strazari.Where(k => k.JMBG.Equals(jmbg)).FirstOrDefault();
        }
        public static List<MedicinskiRadnik> DajSveMedicinare()
        {
            return _medicinari;
        }
        public static MedicinskiRadnik DajMedicinaraPoImenu(string ime)
        {
            return _medicinari.Where(k => k.Ime.Equals(ime)).FirstOrDefault();
        }
        public static MedicinskiRadnik DajMedicinaraPoJMBG(string jmbg)
        {
            return _medicinari.Where(k => k.JMBG.Equals(jmbg)).FirstOrDefault();
        }
        public static List<ZdravstveniKarton> DajSveKartone()
        {
            return _kartoni;
        }
        public static void Zavrti()
        {
            Brojac++;
        }
        public static Kontejner k = new Kontejner();

        public static List<ProfilZatvorenika> Zatvorenici
        {
            get
            {
                return _zatvorenici;
            }

            set
            {
                _zatvorenici = value;
            }
        }

        public static List<Uposlenik> Uposlenici
        {
            get
            {
                return _uposlenici;
            }

            set
            {
                _uposlenici = value;
            }
        }

        public static Upravnik Upravnik
        {
            get
            {
                return _upravnik;
            }

            set
            {
                _upravnik = value;
            }
        }

        public static List<Narudzba> Narudzbe
        {
            get
            {
                return _narudzbe;
            }

            set
            {
                _narudzbe = value;
            }
        }
        //public static Zatvor.ViewModel.KontejnerViewModel m = new ViewModel.KontejnerViewModel();
        //DataSourceLikovi m = new DataSourceLikovi();

    };
}
