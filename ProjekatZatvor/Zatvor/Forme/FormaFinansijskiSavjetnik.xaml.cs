using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Zatvor_pokusaj2.Klase;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Zatvor.Forme
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FormaFinansijskiSavjetnik1 : Page
    {
        public FormaFinansijskiSavjetnik1()
        {
            this.InitializeComponent();
        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private async void button1_Click(object sender, RoutedEventArgs e)
        {
            if (listView.SelectedItem != null)
            {
                Narudzba n = (Narudzba)listView.SelectedItem;
                listView.Items.Remove(n);
                n.StatusNarudzbe = true;
                listView.Items.Add(n);
                foreach (Narudzba na in DataSource.DataSourceLikovi.Narudzbe)
                {
                    if (na.Equals(n))
                        na.StatusNarudzbe = true;
                }

                MessageDialog dialog = new MessageDialog("Narudzba odobrena", "Obavještenje");
                await dialog.ShowAsync();
            }
            else
            {
                MessageDialog dialog = new MessageDialog("Niste odabrali narudžbu", "Greška");
                await dialog.ShowAsync();
            }
        }

        private void button1_Copy_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FormaLogin),alarmic);
        }
        Alarm alarmic = null;
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            int brojac = 0;
            List < Narudzba > narudzbe = DataSource.DataSourceLikovi.Narudzbe;
            alarmic = (Alarm)e.Parameter;
            foreach(Narudzba narudzbenica in narudzbe)
            {
                listView.Items.Add(narudzbenica);
                brojac++;
            }
            brojZahtjeva.Text = brojac.ToString();

            List<Uposlenik> finanseri = DataSource.DataSourceLikovi.k.DajSveUposlenike();
            List<string> podaci = alarmic.Podaci;
            foreach (Uposlenik c in finanseri)
            {
                if (c.Login_podaci.Username.Equals(podaci[0]))
                {
                    textBlock_Copy.Text = "Dobrodošli " + c.Ime + " " + c.Prezime;
                    textBlock1.Text = c.Login_podaci.Username;
                }
            }
            base.OnNavigatedTo(e);
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            if (listView.SelectedItem != null)
            {
                Narudzba n = (Narudzba)listView.SelectedItem;
                string status = "";
                if (n.StatusNarudzbe)
                    status = "Odobrena";
                else status = "Odbijena";
                MessageDialog dialog = new MessageDialog(n.ImeArtikla + "      " + n.KolicinaArtikla + "   Status: " + status, "Obavještenje");
                await dialog.ShowAsync();
            }
            else
            {
                MessageDialog dialog = new MessageDialog("Niste odabrali narudžbu", "Greška");
                await dialog.ShowAsync();
            }
        }

        private async void button2_Click(object sender, RoutedEventArgs e)
        {
            if (listView.SelectedItem != null)
            {
                Narudzba n = (Narudzba)listView.SelectedItem;
                listView.Items.Remove(n);
                n.StatusNarudzbe = false;
                listView.Items.Add(n);
                foreach (Narudzba na in DataSource.DataSourceLikovi.Narudzbe)
                {
                    if (na.Equals(n))
                        na.StatusNarudzbe = false;
                }
                MessageDialog dialog = new MessageDialog("Narudzba odbijena", "Obavještenje");
                await dialog.ShowAsync();
            }
            else
            {
                MessageDialog dialog = new MessageDialog("Niste odabrali narudžbu", "Greška");
                await dialog.ShowAsync();
            }

        }

        private async void button1_Copy1_Click(object sender, RoutedEventArgs e)
        {
            string poruka = "Korisnički interfejs koji je dostupan finansijskom savjetniku sadrži:\n\n- Prikaži zahtjev - klikom na stavku liste, te klikom na 'Prikaži zahtjev' otvorit će se odabrani zahtjev.\n\n- Odobri zahtjev - klikom na 'Odobri zahtjev' zahtjev će biti odobren o čemu će podnosilac istog biti obaviješten.\n\n- Odbij zahtjev - klikom na 'Odbij zahtjev' zahtjev će biti odbijen o čemu će podnosilac istog biti obaviješten.\n\n- LooOut - odjava sa sistema.";
            MessageDialog dialog = new MessageDialog(poruka, "Help");
            await dialog.ShowAsync();
        }
    }
}
