using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Zatvor.ViewModel;
using Zatvor_pokusaj2.Klase;
using Zatvor.Klase;
using Zatvor.DataSource;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Zatvor.Forme
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FormaNarudzb1a : Page
    {
        public FormaNarudzb1a()
        {
            this.InitializeComponent();
        }
        Alarm alarmic = null;
        List<Narudzba> narudzbenica = new List<Narudzba>();
        private async void button_Click(object sender, RoutedEventArgs e)
        {
            NarudzbaViewModel n = new NarudzbaViewModel();
            if (n.ValidirajNarudzbu(tNaziv.Text, tKolicina.Text))
            {
                Narudzba nova = n.KreirajNarudzbu(tNaziv.Text, tKolicina.Text);
                narudzbenica.Add(nova);
                listView.Items.Add(nova);

            }

            else {
                MessageDialog dialog = new MessageDialog("Pogrešno ste unijeli kolicinu", "Greška");
                await dialog.ShowAsync();
            }
            tNaziv.Text = "";
            tKolicina.Text = "";
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            List<Uposlenik> uposlenici = DataSource.DataSourceLikovi.k.DajSveUposlenike();
            foreach (Uposlenik u in uposlenici)
            {
                if (u.Login_podaci.Username.Equals(alarmic.Podaci[0]))
                {
                    if (u.FunkcijaUposlenika.Equals("Medicinski radnik"))
                    {
                        List<string> podaci = new List<string>();
                        podaci.Add(u.Login_podaci.Username); podaci.Add(u.Login_podaci.Password);
                        alarmic.Podaci = podaci;
                        this.Frame.Navigate(typeof(FormaMedicinskiRadnik), alarmic);
                    }
                    else if (u.FunkcijaUposlenika.Equals("Radnik u kantini"))
                    {
                        List<string> podaci = new List<string>();
                        podaci.Add(u.Login_podaci.Username); podaci.Add(u.Login_podaci.Password);
                        alarmic.Podaci = podaci;
                        this.Frame.Navigate(typeof(FormaRadnikUKantini), alarmic);
                    }
                }
            }
        }

        private void tNaziv_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            tNaziv.Text = "";
            tKolicina.Text = "";
            listView.Items.Clear();
        }

        private async void button3_Copy_Click(object sender, RoutedEventArgs e)
        {
            Narudzba nar = (Narudzba)listView.SelectedItem;
            try
            {
                listView.Items.Remove(listView.SelectedItem);
                foreach (Narudzba n in narudzbenica) 
                {
                    if (n.ImeArtikla.Equals(nar.ImeArtikla) && n.KolicinaArtikla.Equals(nar.KolicinaArtikla))
                    {
                        
                        narudzbenica.Remove(n);
                    }
                }
                
            }
            catch (Exception )
            {
                //MessageDialog dialog = new MessageDialog("Niste odabrali stavku", "Greška");
                //await dialog.ShowAsync();
            }

        }

        private async void button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (Narudzba n in narudzbenica)
                {
                    DataSource.DataSourceLikovi.Narudzbe.Add(n);
                }
                MessageDialog dialog = new MessageDialog("Zahtjev uspješno poslan", "Obavještenje");
                tNaziv.Text = "";
                tKolicina.Text = "";
                listView.Items.Clear();
                await dialog.ShowAsync();
            }
            catch(Exception)
            {
                MessageDialog dialog = new MessageDialog("Došlo je do greške", "Obavještenje");
                await dialog.ShowAsync();
            }
        }
            protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            alarmic = (Alarm)e.Parameter;
            base.OnNavigatedTo(e);
        }
    
    }
}
