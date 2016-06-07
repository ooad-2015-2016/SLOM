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
using Zatvor.DataSource;
using Zatvor.Forme;
using Zatvor.Klase;
using Zatvor.ViewModel;
using Zatvor_pokusaj2.Klase;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Zatvor.Forme
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FormaLista : Page
    {
        public FormaLista()
        {
            this.InitializeComponent();
        }
        Alarm alarmic = null;
        private void button1_Copy_Click(object sender, RoutedEventArgs e)
        {
            List<string> podaci = new List<string>();
            podaci.Add("Upravnik");podaci.Add("Upravnik123");
            alarmic.Podaci = podaci;
            this.Frame.Navigate(typeof(FormaUpravnikZatvora1),alarmic);
        }
        Uposlenik upravnik = null;
        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            alarmic = (Alarm)e.Parameter;
           foreach(Uposlenik u in DataSource.DataSourceLikovi.k.Uposlenici)
            {
                listView.Items.Add(u);
                if (u.FunkcijaUposlenika.Equals("Upravnik"))
                    upravnik = u;
            }
                
            base.OnNavigatedTo(e);
        }

        private async void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (listView.SelectedItem != null && listView.SelectedItem != upravnik)
            {
                Uposlenik pz = (Uposlenik)listView.SelectedItem;
                UposlenikViewModel uwm = new UposlenikViewModel();
                uwm.ObrisiUposlenika(pz);
                listView.Items.Remove(listView.SelectedItem);
                MessageDialog dialog = new MessageDialog("Uposlenik obrisan", "Obavještenje");
                await dialog.ShowAsync();
            }
            else
            {
                MessageDialog dialog = new MessageDialog("Niste odabrali uposlenika ili ste odabrali upravnika", "Greška");
                await dialog.ShowAsync();
            }
        }

        private async void buttonEdit_Click(object sender, RoutedEventArgs e)
        {
            if (listView.SelectedItem != null && listView.SelectedItem!=upravnik)
            {
                alarmic.Uposlenik = (Uposlenik)listView.SelectedItem;
                this.Frame.Navigate(typeof(FormaDodajUposlenika), alarmic);
            }
            else
            {
                MessageDialog dialog = new MessageDialog("Niste odabrali uposlenika ili ste odabrali upravnika", "Greška");
                await dialog.ShowAsync();
            }
        }
    }
}
