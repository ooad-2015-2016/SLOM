#SLOM
##Zatvor
###Članovi tima
1. Faris Lemeš
2. Haris Suljić
3. Mia Muminović
4. Tarik Omeragić

###Opis teme

Zatvor je ustanova u kojoj osuđenici izdržavaju zatvorsku kaznu. Zatvorska je kazna jedna od mogućih kaznenih sankcija za počinitelje kaznenih djela. Ona se provodi lišavanjem slobode optuženika. Svrha sistema je centralizirano upravljanje i nadzor u gotovo svim segmentima jedne ovakve ustanove, počevši od prijema zatvorenika i kreiranja njegovog dosjea, smještanja u odgovarajući sektor i ćeliju. Zatvor se sastoji od 3 sektora, sektora A (laki prestupi), sektora B (teži prestupi) te sektora C koji je zapravo tamnica. Upravnik zatvora je supervizor i on ima pristup svim segmetnima sistema.

###Procesi

- Zatvorenik dolazi u zatvor te mu se stvara dosje (ako ga već nema) sa svim podacima o tom zatvoreniku. U toku stvaranja profila zatvorenika se vrši zapis o stvarima koje je zatvorenik imao te se podvrgava ljekarskom pregledu, te mu se otvara zdravstveni karton i vrši se čipovanje zatovrenika s ciljem da se u svakom trenutku zna njegov položaj. Nakon kreiranja profila, zatvorenik se smješta u odgovarajuću ćeliju. Ovaj cjelokupan proces nadgleda čuvar.
- Bit će omogućen proces komunikacije među korisnicima sistema.
- Bit će omogućena evidencija o posjetama, nadzor istih, kreiranje naloga za posjetu.
- U slučaju pobune ili bilo kakve druge potrebe biti će omugućeno otvaranje i zatvaranje ćelija ili sektora.
- Proces podnošenja zahtjeva za uslovnu kaznu, privremeni dopust.

###Funkcionalnosti

- Mogućnost stvaranja profila zatvorenika
- Mogućnost uvida u profil zatvorenika
- Mogućnost praćenja lokacije zatvorenika
- Mogućnost komunikacije sa čuvarima
- Mogućnost regulacije osvjetljenja i temperature po sektorima
- Mogućnost praćenja stanja resursa u svim segmetima zatvora (npr. kantina, ambulanta)
- Mogućnost kontrole vrata (pojedina pomoću otiska prsta)
- Mogućnost prijave sa različitim privilegijama

###Akteri

- Upravnik zatvora (potpuna kontrola sistema)
- Upravnici sektora (kontrola nad sektorom)
- Finansijski savjetnik (kontrolisanje budžeta)
- Medicinski radnici (pristup zdravstvenim kartonima zatvorenika i izmjena istih)
- Radnici u kantini (pristup resursima kantine)
- Stražari (na ogradi/zidu, mogućnost paljenja alarma)
- Čuvari (unutar zatvora, mogućnost paljenja alarma i kontrole ćelija)
- Zatvorenici 


###Eksterni uređaji
-Koristi se GPS čiji se kod nalazi unutar forme FormaUpravnikZatvora. (https://github.com/ooad-2015-2016/SLOM/blob/master/ProjekatZatvor/Zatvor/Forme/FormaUpravnikZatvora.xaml.cs)

-Koristi se zvučnik od uređaja na kojem je pokrenut, za validacijom nije bilo potrebe jer je urađeno koristeći mediaElement i jednostavno implementirano start stop dugme na koje se pali i gasi alarm. Ovaj kod imamo u sljedećim formama: FormaUpravnikZatvora, FormaCUvar i FormaStrazar. 

(https://github.com/ooad-2015-2016/SLOM/blob/master/ProjekatZatvor/Zatvor/Forme/FormaUpravnikZatvora.xaml.cs), (https://github.com/ooad-2015-2016/SLOM/blob/master/ProjekatZatvor/Zatvor/Forme/FormaCuvar.xaml.cs), (https://github.com/ooad-2015-2016/SLOM/blob/master/ProjekatZatvor/Zatvor/Forme/FormaStrazar.xaml.cs).

-Kao eksterni uređaj je korišten ARDUINO na kojem se pale i gase lampice kada je alarm upaljen, odnosno ne dešava se ništa kada je alarm ugašen. Kod za arduino je implementiran u klasi Alarm. (https://github.com/ooad-2015-2016/SLOM/blob/master/ProjekatZatvor/Zatvor/Klase/Alarm.cs). 
Isto tako validacija za ovaj uređaj nije potrebna jer korisnik nema pristup bilo kakvim podacima o Arduinu. Kod se poziva unutar klasa u kojima se aktivira alarm, koje su navedene kod eksternog uređaja Zvučnik.

-Adaptive layout nažalost nije uspješno urađen.
