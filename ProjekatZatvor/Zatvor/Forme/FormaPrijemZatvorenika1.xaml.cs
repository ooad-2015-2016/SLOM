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
using Zatvor.Klase;
using Zatvor.ViewModel;
using Zatvor_pokusaj2.Klase;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Zatvor.Forme
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FormaPrijemZatvorenika1 : Page
    {
        public FormaPrijemZatvorenika1()
        {
            this.InitializeComponent();
        }

        private void button1_Copy_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void tIme_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tIme_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void button2_click(object sender, RoutedEventArgs e)
        {
            if (button.Content.Equals("Dodaj zatvorenika"))
            {
                List<Uposlenik> uposlenici = DataSource.DataSourceLikovi.k.DajSveUposlenike();
                foreach (Uposlenik u in uposlenici)
                {
                    if (u.Login_podaci.Username.Equals(alarmic.Podaci[0]))
                    {
                        if (u.FunkcijaUposlenika.Equals("Cuvar"))
                        {
                            List<string> podaci = new List<string>();
                            podaci.Add(u.Login_podaci.Username); podaci.Add(u.Login_podaci.Password);
                            alarmic.Podaci = podaci;
                            this.Frame.Navigate(typeof(FormaCuvar1), alarmic);
                        }
                    }
                }
            }
            else if(button.Content.Equals("Update"))
            {
                this.Frame.Navigate(typeof(FormaListaZatvorenika), alarmic);
            }
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            if (button.Content.Equals("Dodaj zatvorenika"))
            {
                PrijemZatvorenikaViewModel p = new PrijemZatvorenikaViewModel();
                if (p.ValidirajProfilZavorenika(tIme.Text, tPrezime.Text, tAdresa.Text, tBrojTelefona.Text, dDatumRodjenja.Date.DateTime, tBrojLicneKarte.Text, textBox.Text, tVisina.Text, tTezina.Text))
                {
                    string ime = tIme.Text;
                    string prezime = tPrezime.Text;
                    string adresa = tAdresa.Text;
                    string brojTelefona = tBrojTelefona.Text;
                    DateTime datumRodjenja = dDatumRodjenja.Date.DateTime;
                    string brojLicneKarte = tBrojLicneKarte.Text;
                    string opis = textBox.Text;
                    double visina = Convert.ToDouble(tVisina.Text);
                    double tezina = Convert.ToDouble(tTezina.Text);
                    bool osudjivan = new bool();
                    if (radioButton.IsChecked == true)
                        osudjivan = true;
                    else if (radioButton1.IsChecked == true)
                        osudjivan = false;
                    ProfilZatvorenika pz = new ProfilZatvorenika(ime, prezime, adresa, brojTelefona, datumRodjenja, brojLicneKarte, opis, visina, tezina, osudjivan, DataSource.DataSourceLikovi.Brojac); DataSource.DataSourceLikovi.Zavrti();
                    (KontejnerViewModel.KontejnerMetoda(DataSource.DataSourceLikovi.k)).DodajZatvorenikaNaListu(pz);
                    MessageDialog dialog = new MessageDialog("Zatvorenik uspješno dodan.", "Obavještenje");
                    await dialog.ShowAsync();
                }
                else
                {
                    MessageDialog dialog = new MessageDialog("Pogrešno ste unijeli podatke", "Greška");
                    await dialog.ShowAsync();
                }
            }
            else if (button.Content.Equals("Update"))
            {
                PrijemZatvorenikaViewModel pwm = new PrijemZatvorenikaViewModel();
                if (pwm.ValidirajProfilZavorenika(tIme.Text, tPrezime.Text, tAdresa.Text, tBrojTelefona.Text, dDatumRodjenja.Date.DateTime, tBrojLicneKarte.Text, textBox.Text, tVisina.Text, tTezina.Text))
                {
                    DataSource.DataSourceLikovi.k.Zatvorenici.Remove(profilZaEdit);
                    profilZaEdit.Ime = tIme.Text;
                    profilZaEdit.Prezime = tPrezime.Text;
                    profilZaEdit.AdresaStanovanja = tAdresa.Text;
                    profilZaEdit.BrojTelefona = tBrojTelefona.Text;
                    profilZaEdit.DatumRodjenja = dDatumRodjenja.Date.DateTime;
                    profilZaEdit.BrojLicneKarte = tBrojLicneKarte.Text;
                    profilZaEdit.Visina = Convert.ToDouble(tVisina.Text);
                    profilZaEdit.Tezina = Convert.ToDouble(tTezina.Text);
                    if (radioButton.IsChecked == true)
                        profilZaEdit.OsudjivanRanije = true;
                    else if (radioButton1.IsChecked == true)
                        profilZaEdit.OsudjivanRanije = false;
                    profilZaEdit.DodatniOpis = textBox.Text;
                    DataSource.DataSourceLikovi.k.Zatvorenici.Add(profilZaEdit);
                    MessageDialog dialog = new MessageDialog("Podaci uspješno ažurirani", "Obavještenje");
                    await dialog.ShowAsync();
                }
                else
                {
                    MessageDialog dialog = new MessageDialog("Pogrešno ste unijeli podatke", "Greška");
                    await dialog.ShowAsync();
                }
            }

        }
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            tIme.Text = "";
            tPrezime.Text = "";
            tAdresa.Text = "";
            tBrojTelefona.Text = "";
            tBrojLicneKarte.Text = "";
            tVisina.Text = "";
            tTezina.Text = "";
            textBox.Text = "";
            radioButton.IsChecked = false;
            radioButton1.IsChecked = false;
            dDatumRodjenja.Date = DateTime.Today;
        }
        ProfilZatvorenika profilZaEdit = null;
        Alarm alarmic = null;
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            alarmic = (Alarm)e.Parameter;
            /* if(e.Parameter.GetType()==typeof(string))
             {
                 testniHepek.Text = e.Parameter.ToString();

             }*/
            if (alarmic.ProfilZatvorenika != null)
            {
                ProfilZatvorenika pz = alarmic.ProfilZatvorenika;
                profilZaEdit = pz;
                tIme.Text = pz.Ime;
                tPrezime.Text = pz.Prezime;
                tAdresa.Text = pz.AdresaStanovanja;
                tBrojLicneKarte.Text = pz.BrojLicneKarte;
                tBrojTelefona.Text = pz.BrojTelefona;
                tVisina.Text = pz.Visina.ToString();
                tTezina.Text = pz.Tezina.ToString();
                dDatumRodjenja.Date = pz.DatumRodjenja;
                textBox.Text = pz.DodatniOpis;
                if(pz.OsudjivanRanije)
                {
                    radioButton.IsChecked = true;
                    radioButton1.IsChecked = false;
                }
                else
                {
                    radioButton.IsChecked = false;
                    radioButton1.IsChecked = true;
                }
                button3.Visibility = Visibility.Collapsed;
                button.Content = "Update";


            }
            base.OnNavigatedTo(e);
        }
    }
}
