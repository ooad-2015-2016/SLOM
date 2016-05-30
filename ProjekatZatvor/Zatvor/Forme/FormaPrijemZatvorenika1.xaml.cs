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

        private void button1_Copy_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FormaLogin));
        }

        private void button2_click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FormaCuvar1));
        }

        private async void button_Click(object sender, RoutedEventArgs e)
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
                ProfilZatvorenika pz = new ProfilZatvorenika(ime,prezime,adresa,brojTelefona,datumRodjenja,brojLicneKarte,opis,visina,tezina,osudjivan);
            }
            else
            {
                MessageDialog dialog = new MessageDialog("Pogrešno ste unijeli podatke", "Greška");
                await dialog.ShowAsync();
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
    }
}
