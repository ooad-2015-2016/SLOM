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
    public sealed partial class FormaRadnikUKantini : Page
    {
        public FormaRadnikUKantini()
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FormaLogin));
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FormaNarudzb1a), textBlock2.Text);
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            List<Uposlenik> kuhari = DataSource.DataSourceLikovi.k.DajSveUposlenike();
            List<string> podaci = (List<string>)e.Parameter;
            foreach (Uposlenik c in kuhari)
            {
                if (c.Login_podaci.Username.Equals(podaci[0]))
                {
                    textBlock.Text = "Dobrodošli " + c.Ime + " " + c.Prezime;
                    textBlock2.Text = c.Login_podaci.Username;
                }
            }
            base.OnNavigatedTo(e);
        }

        private async void button1_Copy1_Click(object sender, RoutedEventArgs e)
        {
            string poruka = "Korisnički interfejs koji je dostupan radniku u kantinu sadrži:\n\n-Kreiraj narudžbu - klikom na 'Kreiraj narudžbu' otvorit će se korisnički interfejs za naručivanje";
            MessageDialog dialog = new MessageDialog(poruka, "Help");
            await dialog.ShowAsync();
        }
    }
}
