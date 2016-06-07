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
using Zatvor_pokusaj2.Klase;
using Zatvor.Forme;
using Zatvor.DataSource;
using Zatvor.ViewModel;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Zatvor.Forme
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FormaDodajUposlenika : Page
    {
        public FormaDodajUposlenika()
        {
            this.InitializeComponent();
        }
        private async void button1_Click(object sender, RoutedEventArgs e)
        {
            if (button1.Content.Equals("Dodaj uposlenika"))
            {
                UposlenikViewModel u = new UposlenikViewModel();
                try
                {
                    if (u.ValidirajUposlenika(tIme.Text, tPrezime.Text, tJMBG.Text, tAdresa.Text, comboBox.SelectedItem.ToString()))
                    {
                        string ime = tIme.Text;
                        string prezime = tPrezime.Text;
                        string adresa = tAdresa.Text;
                        string JMBG = tJMBG.Text;
                        DateTime datumRodjenja = new DateTime();
                        if (DateTime.Today.Year - tDatumRodjenja.Date.Year >= 18)
                        {
                            datumRodjenja = tDatumRodjenja.Date.DateTime;
                        }
                        else throw (new Exception());
                        string funkcija = comboBox.SelectedItem.ToString();
                        Korisnik podaci = new Korisnik(tIme.Text + "." + tPrezime.Text, tIme.Text + "123");
                        if (funkcija == "Radnik u kantini")
                        {
                            (ViewModel.KontejnerViewModel.KontejnerMetoda(DataSource.DataSourceLikovi.k)).DodajUposlenikaNaListu(new Zatvor.Klase.RadnikUKantini(ime, prezime, datumRodjenja, JMBG, adresa, funkcija, podaci));
                        }
                        if (funkcija == "Strazar")
                        {
                            (ViewModel.KontejnerViewModel.KontejnerMetoda(DataSource.DataSourceLikovi.k)).DodajUposlenikaNaListu(new Zatvor_pokusaj2.Klase.Strazar(ime, prezime, datumRodjenja, JMBG, adresa, funkcija, podaci));
                        }
                        if (funkcija == "Cuvar")
                        {
                            (ViewModel.KontejnerViewModel.KontejnerMetoda(DataSource.DataSourceLikovi.k)).DodajUposlenikaNaListu(new Zatvor.Klase.Cuvar(ime, prezime, datumRodjenja, JMBG, adresa, funkcija, podaci));
                        }
                        if (funkcija == "Medicinski radnik")
                        {
                            (ViewModel.KontejnerViewModel.KontejnerMetoda(DataSource.DataSourceLikovi.k)).DodajUposlenikaNaListu(new Zatvor_pokusaj2.Klase.MedicinskiRadnik(ime, prezime, datumRodjenja, JMBG, adresa, funkcija, podaci));
                        }
                        if (funkcija == "Finansijski savjetnik")
                        {
                            (ViewModel.KontejnerViewModel.KontejnerMetoda(DataSource.DataSourceLikovi.k)).DodajUposlenikaNaListu(new Zatvor_pokusaj2.Klase.FinansijskiSavjetnik(ime, prezime, datumRodjenja, JMBG, adresa, funkcija, podaci));
                        }
                        MessageDialog dialog = new MessageDialog("Uposlenik dodan.\nUsername: " + ime + "." + prezime + "\nPassword: " + ime + "123", "Obavijest");
                        await dialog.ShowAsync();
                    }
                    else
                    {
                        MessageDialog dialog = new MessageDialog("Pogrešno ste unijeli podatke", "Greška");
                        await dialog.ShowAsync();
                    }
                }
                catch
                {
                    MessageDialog dialog = new MessageDialog("Pogrešno ste unijeli podatke", "Greška");
                    await dialog.ShowAsync();
                }
            }
            else
            {
                try
                {
                    UposlenikViewModel uwm = new UposlenikViewModel();
                    if (uwm.ValidirajUposlenika(tIme.Text, tPrezime.Text, tJMBG.Text, tAdresa.Text, comboBox.SelectedItem.ToString()))
                    {
                        DataSource.DataSourceLikovi.k.Uposlenici.Remove(uposleniCovjek);
                        if (DateTime.Today.Year - tDatumRodjenja.Date.Year >= 18)
                        {
                            uposleniCovjek.DatumRodjenja = tDatumRodjenja.Date.DateTime;
                        }
                        else throw (new Exception());
                        uposleniCovjek.Ime = tIme.Text;
                        uposleniCovjek.Prezime = tPrezime.Text;
                        uposleniCovjek.JMBG = tJMBG.Text;
                        uposleniCovjek.AdresaStanovanja = tAdresa.Text;
                        uposleniCovjek.FunkcijaUposlenika = comboBox.SelectedItem.ToString();
                        uposleniCovjek.Login_podaci.Username = uposleniCovjek.Ime + "." + uposleniCovjek.Prezime;
                        uposleniCovjek.Login_podaci.Password = uposleniCovjek.Ime + "123";
                        MessageDialog dialog = new MessageDialog("Podaci o uposleniku uspješno ažurirani\nUsername: " + uposleniCovjek.Ime+ "." + uposleniCovjek.Prezime + "\nPassword: " + uposleniCovjek.Ime + "123", "Obavijest");
                        await dialog.ShowAsync();
                        DataSourceLikovi.k.Uposlenici.Add(uposleniCovjek);

                    }
                }
                catch(Exception)
                {
                    MessageDialog dialog = new MessageDialog("Pogrešno ste unijeli podatke", "Greška");
                    await dialog.ShowAsync();
                }

            }
        }
        private void button2_Click(object sender, RoutedEventArgs e)
        {
                tIme.Text = "";
                tPrezime.Text = "";
                tAdresa.Text = "";
                tJMBG.Text = "";
                tDatumRodjenja.Date = DateTime.Today;
                comboBox.SelectedItem = null;
        }

        private void button2_Copy_Click(object sender, RoutedEventArgs e)
        {
            if (button1.Content.Equals("Update"))
            {
                this.Frame.Navigate(typeof(FormaLista),alarmic);
            }
            else
            {
                List<string> podaci = new List<string>();
                podaci.Add("Upravnik"); podaci.Add("Upravnik123");
                alarmic.Podaci = podaci;
                this.Frame.Navigate(typeof(FormaUpravnikZatvora1), alarmic);
            }
        }
        Uposlenik uposleniCovjek = null;
        Alarm alarmic = null;
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            alarmic = (Alarm)e.Parameter;
            if (alarmic.Uposlenik!=null)
            {
                
                Uposlenik up = alarmic.Uposlenik;
                uposleniCovjek = up;
                button1.Content = "Update";
                tIme.Text = up.Ime;
                tPrezime.Text = up.Prezime;
                tAdresa.Text = up.AdresaStanovanja;
                tJMBG.Text = up.JMBG;
                tDatumRodjenja.Date = up.DatumRodjenja;
                comboBox.SelectedItem = up.FunkcijaUposlenika;
                textBlock_Copy6.Text = "Editovanje uposlenika";
                button2.Visibility = Visibility.Collapsed;
            }
                else
                    button1.Content = "Dodaj uposlenika";
                base.OnNavigatedTo(e);
            }
        }
 }
