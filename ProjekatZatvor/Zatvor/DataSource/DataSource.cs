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
        public DataSourceLikovi() { }
        private static List<Korisnik> _korisnici = new List<Korisnik>()
        {
            new Korisnik("Cuvar","Cuvar123"),
            new Korisnik("Strazar","Strazar123"),
            new Korisnik("Upravnik", "Upravnik123"),
            new Korisnik("Doktor", "Dr123"),
            new Korisnik("Kuhar", "Zeljanica")
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
            new MedicinskiRadnik("Selma","Lekić",new DateTime(1997, 5, 1, 8, 30, 52),"1232527890123","Vrazova 44","Medicinski Radnik",new Korisnik("Medo","Radnik123")),
            new MedicinskiRadnik("Ilhana","Lekić",new DateTime(1996, 5, 1, 8, 30, 52),"2345672343217","Vrazova 44","Medicinski Radnik",new Korisnik("Sulja","Radnik123")),
            new MedicinskiRadnik("Emina","Čekić",new DateTime(1995, 6, 17, 8, 30, 52),"1232527890123","Skenderija","Medicinski Radnik",new Korisnik("Medo","Radnik123")),
            new MedicinskiRadnik("Zerina","Šahović",new DateTime(1995, 5, 1, 8, 30, 52),"2523256891023","Vrazova 44","Medicinski Radnik",new Korisnik("Medo","Radnik"))
        };
        private static List<ProfilZatvorenika> _zatvorenici = new List<ProfilZatvorenika>()
        {
            new ProfilZatvorenika("Tarik","Omeragić","Olimpijska 28", "061224161", new DateTime(1995, 6, 18, 6, 40, 54), "9H63F3F2A", "AAAAAAAAAAAA biži biži", 188, 90, true),
            new ProfilZatvorenika("Mia", "Muminović", "Trg medjunarodnog prijateljstva 12", "061945535", new DateTime(1995, 9, 5, 12,40,35), "ABC123EFG", "Fakat da je osudjivana", 172, 52, true),
            new ProfilZatvorenika("Haris", "Suljić", "Hrasno brdo seljačina 22", "061268512", new DateTime(1995, 6, 12, 11,44,48), "456HIJ789", "Jebac iz gorazda aka silovatelj mrtvi uusta", 184, 74, true),
            new ProfilZatvorenika("Faris", "Lemeš", "Grbavička 78", "062143897", new DateTime(1995, 12, 8, 10,30,35), "KLM101NOP", "Normala nije osuđivan. Nemojte ga puno", 192, 82, false)
        };
        /*private static List<Narudzba> _narudzbe = new List<Narudzba>()
        {
            new Narudzba("Mlijeko",3,false),
            new Narudzba("Hljeb",4,false),
            new Narudzba("Jaja",30,false)
        };*/
        private static Upravnik _upravnik = new Upravnik("Hamdo", "Šupak", new DateTime(1997, 5, 1, 8, 30, 52), "1232527890123", "Vrazova 44", "Upravnik", new Korisnik("Upravnik", "Upravnik123"));
        private static List<Uposlenik> _uposlenici = new List<Uposlenik>();

        public static List<Uposlenik> DajSveUposlenike()
        {
            foreach (Strazar s in DataSource.DataSourceLikovi.DajSveStrazare())
            {
                _uposlenici.Add(s);
            }
            foreach (Cuvar c in DataSource.DataSourceLikovi.DajSveCuvare())
            {
                _uposlenici.Add(c);
            }
            foreach (MedicinskiRadnik m in DataSource.DataSourceLikovi.DajSveMedicinare())
            {
                _uposlenici.Add(m);
            }
           _uposlenici.Add(_upravnik);
            return _uposlenici;
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
        public static Kontejner k = new Kontejner();
        //public static Zatvor.ViewModel.KontejnerViewModel m = new ViewModel.KontejnerViewModel();
        //DataSourceLikovi m = new DataSourceLikovi();

    };
}
