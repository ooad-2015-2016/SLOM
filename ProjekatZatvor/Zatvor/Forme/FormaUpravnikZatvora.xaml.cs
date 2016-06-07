using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Zatvor.ViewModel;
using Zatvor.DataSource;
using Zatvor_pokusaj2.Klase;
using Windows.UI.Popups;
using Windows.Devices.Geolocation;


// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Zatvor.Forme
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FormaUpravnikZatvora1 : Page
    {
        public FormaUpravnikZatvora1()
        {
            //Alarm a = new Alarm();
            this.InitializeComponent();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FormaLista),alarmic);
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FormaDodajUposlenika),alarmic);
        }


        Alarm alarmic = null;
        private void button2_Copy1_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Stop();
            button2_Copy.Visibility = Visibility.Visible;
            button2_Copy1.Visibility = Visibility.Collapsed;
            alarmic.t = false;

        }

        private void button2_Copy_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Play();
            button2_Copy.Visibility = Visibility.Collapsed;
            button2_Copy1.Visibility = Visibility.Visible;
            alarmic.t = true;
            alarmic.Toggle();
        }

        private void button1_Copy_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FormaLogin),alarmic);
        }
        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            List<Uposlenik> upravnici = DataSource.DataSourceLikovi.k.DajSveUposlenike();
            alarmic = (Alarm)e.Parameter;
            try
            {
                foreach (Zahtjev z in DataSourceLikovi.Upravnik.Zahtjevi)
                {
                    listView.Items.Add(z);
                }
            }
            catch (Exception)
            { }
            foreach (Uposlenik s in upravnici)
            {
                if (s.Login_podaci.Username.Equals(alarmic.Podaci[0]))
                {
                    textBlock.Text = "Dobrodošli " + s.Ime + " " + s.Prezime;
                }
            }
            var locator = new Geolocator();
            locator.DesiredAccuracyInMeters = 10;
            var position = await locator.GetGeopositionAsync();
            await MyMap.TrySetViewAsync(position.Coordinate.Point, 18D);
            alarmic.Uposlenik = null;
            alarmic.ProfilZatvorenika = null;
            base.OnNavigatedTo(e);
        }

        private void button5_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FormaListaZatvorenika), alarmic);
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Zahtjev z = (Zahtjev)listView.SelectedItem;
                MessageDialog dialog = new MessageDialog("Ime i prezime zatvorenika: " + z.PodaciOZatvoreniku + "\nDatum početka dopusta: " + z.PocetniDatum.ToString() + "\nDatum završetka dopusta: " + z.KrajnjiDatum.ToString() + "\nObrazloženje: " + z.Obrazlozenje, "Informacije o zahtjevu");
                await dialog.ShowAsync();
            }
            catch(Exception)
            {
                MessageDialog dialog = new MessageDialog("Greška, niste odabrali zahtjev", "Greška");
                await dialog.ShowAsync();
            }
        }

        private async void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Zahtjev z = (Zahtjev)listView.SelectedItem;
                listView.Items.Remove(z);
                z.Status = false;
                listView.Items.Add(z);
                foreach (Zahtjev za in DataSource.DataSourceLikovi.Upravnik.Zahtjevi)
                {
                    if (za.Equals(z))
                        za.Status = false;
                }
                MessageDialog dialog = new MessageDialog("Zahtjev odbijen", "Obavijest");
                await dialog.ShowAsync();
            }
            catch (Exception)
            {
                MessageDialog dialog = new MessageDialog("Greška, niste odabrali zahtjev", "Greška");
                await dialog.ShowAsync();
            }
        }

        private async void button2_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Zahtjev z = (Zahtjev)listView.SelectedItem;
                listView.Items.Remove(z);
                z.Status = true;
                listView.Items.Add(z);
                foreach (Zahtjev za in DataSource.DataSourceLikovi.Upravnik.Zahtjevi)
                {
                    if (za.Equals(z))
                        za.Status = true;
                }
                MessageDialog dialog = new MessageDialog("Zahtjev odobren", "Obavijest");
                await dialog.ShowAsync();
            }
            catch (Exception)
            {
                MessageDialog dialog = new MessageDialog("Greška, niste odabrali zahtjev", "Greška");
                await dialog.ShowAsync();
            }
        }

        private async void button1_Copy1_Click(object sender, RoutedEventArgs e)
        {
            string poruka = "Korisnički interfejs koji je dostupan upravniku sadrži funkcionalnosti:\n\n- Dodaj uposlenika - opcija otvara odgovarajući interfejs za dodavanje uposlenika. Podrazumijevane vrijednosti polja 'Ime','Prezime','Adresa' su stringovi, za 'JMBG' 13 - cifreni broj. Uposlenik će biti dodan klikom na 'Dodaj uposlenika', dok će 'Reset' obrisati unešene podatke. Kreirani uposlenik će dobiti korisničke podatke 'Username' i 'Password' automatski u formatu 'Ime.Prezime' i 'Ime123'.\n\n- Prikaži listu uposlenika - opcija otvara odgovarajući interfejs koji će prikazati listu uposlenika, te je moguće obrisati uposlenika klikom na 'Obriši uposlenika'.\n\n- Prikaži listu zatvorenika - opcija otvara odgovarajući interfejs koji će prikazati listu zatvorenika, te je moguće obrisati zatvorenika klikom na 'Obriši zatvorenika'.\\nn- Aktiviraj alarm - opcija za aktivaciju alarma.\n\n-Zahtjevi - prikaz liste zahtjeva na čekanju. Zahtjev je moguće prikazati klikom na 'Prikaži zahtjev', odobriti klikom na 'Odobri zahtjev' te odbiti klikom na 'Odbij zahtjev' o čemu će podnosilac zahtjeva biti obaviješten.\n\n- Logout - odjava sa sistema.";
            //sageDialog dialog = new MessageDialog("Pri pokretanju aplikacije, prvi prozor koji se otvori je LogIn.Kako bi svaki korisnik imao određene privilegije potrebno je unijeti Username i Password, koji su Case - Sensitive, te kliknuti na 'Login' .Ukoliko uneseni podaci nisu ispravni aplikacija će javiti poruku o neispravnom unosu.Ukoliko ste zaboravili korisničke podatke javite se administratoru(upravniku) koji će vam ih dati / kreirati.";
            MessageDialog dialog = new MessageDialog(poruka, "Help");
            await dialog.ShowAsync();
        }

        private async void textBlock_Copy_DoubleTapped(object sender, DoubleTappedRoutedEventArgs e)
        {
            var locator = new Geolocator();
            locator.DesiredAccuracyInMeters = 10;
            var position = await locator.GetGeopositionAsync();
            await MyMap.TrySetViewAsync(position.Coordinate.Point, 18D);
        }
    }
}
