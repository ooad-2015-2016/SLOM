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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Zatvor.Forme
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FormaZdravstveniKarton : Page
    {
        public FormaZdravstveniKarton()
        {
            this.InitializeComponent();
        }

        private void textBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private async void button2_Click(object sender, RoutedEventArgs e)
        {
            string ime = tIme.Text;
            string prezime = tPrezime.Text;
            int brojKartona = Convert.ToInt32(tBrKartona.Text);
            string terapija = tTerapija.Text;
            string dijagnoza = tDijagnoza.Text;
            /*
            //Validacija imena
            string ime = tIme.Text;
            int unesenaDuzinaImena = ime.Length;
            int duzinaImena = 0;
            foreach (char c in ime)
            {
                if (c >= 'a' && c <= 'z' || c >= 'A' && c <= 'Z')
                {
                    duzinaImena++;
                }
            }
            if (duzinaImena != unesenaDuzinaImena)
            {
                MessageDialog dialog = new MessageDialog("Pogrešno ste unijeli ime", "Greška");
                await dialog.ShowAsync();

            }
            // Kraj validacije imena

            //Validacija prezimena
            string prezime = tPrezime.Text;
            int unesenaDuzinaPrezimena = prezime.Length;
            int duzinaPrezimena = 0;
            foreach (char c in prezime)
            {
                if (c >= 'a' && c <= 'z' || c >= 'A' && c <= 'Z')
                {
                    duzinaPrezimena++;
                }
            }
            if (duzinaPrezimena != unesenaDuzinaPrezimena)
            {
                MessageDialog dialog = new MessageDialog("Pogrešno ste unijeli prezime", "Greška");
                await dialog.ShowAsync();
            }
            // Kraj validacije prezimena

            //Validacija za broj kartona
            string brojKartona = tBrKartona.Text;
            int unesenaDuzinaKartona = brojKartona.Length;
            int duzinaKartona = 0;
            foreach (char c in brojKartona)
            {
                if (c >= '0' && c <= '9')
                {
                    duzinaKartona++;
                }
            }
            if (duzinaKartona != unesenaDuzinaKartona)
            {
                MessageDialog dialog = new MessageDialog("Pogrešno ste unijeli broj kartona", "Greška");
                await dialog.ShowAsync();
            }
            //Kraj validacje za broj kartona */
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FormaLogin));
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FormaMedicinskiRadnik));
        }

        private void button1_Copy_Click(object sender, RoutedEventArgs e)
        {
            tIme.Text = "";
            tPrezime.Text = "";
            tDijagnoza.Text = "";
            tTerapija.Text = "";
            tBrKartona.Text = "";
        }
    }
}
