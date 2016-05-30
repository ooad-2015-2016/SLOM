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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FormaLogin));
        }

        private async void button1_Click(object sender, RoutedEventArgs e)
        {
            UposlenikViewModel u = new UposlenikViewModel();
            if (u.ValidirajUposlenika(tIme.Text, tPrezime.Text, tJMBG.Text))
                   {
                string ime = tIme.Text;
                string prezime = tPrezime.Text;
                string adresa = tAdresa.Text;
                string JMBG = tJMBG.Text;
                DateTime datumRodjenja = tDatumRodjenja.Date.DateTime;
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
            }
            else
            {
                MessageDialog dialog = new MessageDialog("Pogrešno ste unijeli podatke", "Greška");
                await dialog.ShowAsync();
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
            List<string> podaci = new List<string>();
            podaci.Add("Upravnik"); podaci.Add("Upravnik123");
            this.Frame.Navigate(typeof(FormaUpravnikZatvora1), podaci);
        }
    }
}
