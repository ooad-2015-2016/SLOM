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
using Zatvor.Klase;
using Zatvor.Forme;
using Zatvor_pokusaj2.Klase;
using Zatvor.ViewModel;
using Zatvor.DataSource;
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Zatvor.Forme
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FormaListaZatvorenika : Page
    {
        public FormaListaZatvorenika()
        {
            this.InitializeComponent();
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        Alarm alarmic = null;
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            alarmic = (Alarm)e.Parameter;
            List<ProfilZatvorenika> zatvorenici = (KontejnerViewModel.KontejnerMetoda(DataSourceLikovi.k)).DajSveZatvorenike();
            foreach (ProfilZatvorenika u in zatvorenici)
                listView.Items.Add(u);
            base.OnNavigatedTo(e);
        }

        private void button1_Copy_Click(object sender, RoutedEventArgs e)
        {
            List<Uposlenik> uposlenici = DataSource.DataSourceLikovi.k.DajSveUposlenike();
            foreach (Uposlenik u in uposlenici)
            {
                if (u.Login_podaci.Username.Equals(alarmic.Podaci[0]))
                {
                    if (u.FunkcijaUposlenika.Equals("Upravnik"))
                    {
                        List<string> podaci = new List<string>();
                        podaci.Add("Upravnik"); podaci.Add("Upravnik123");
                        alarmic.Podaci = podaci;
                        this.Frame.Navigate(typeof(FormaUpravnikZatvora1), alarmic);
                    }
                    else if (u.FunkcijaUposlenika.Equals("Cuvar"))
                    {
                        List<string> podaci = new List<string>();
                        podaci.Add(u.Login_podaci.Username); podaci.Add(u.Login_podaci.Password);
                        alarmic.Podaci = podaci;
                        this.Frame.Navigate(typeof(FormaCuvar1), alarmic);
                    }
                }
            }
        }

        private async void button1_Copy1_Click(object sender, RoutedEventArgs e)
        {
            if (listView.SelectedItem != null)
            {
                ProfilZatvorenika pz = (ProfilZatvorenika)listView.SelectedItem;
                ProfilZatvorenikaViewModel pwm = new ProfilZatvorenikaViewModel();
                pwm.ObrisiProfilZatvorenika(pz);
                listView.Items.Remove(listView.SelectedItem);
                MessageDialog dialog = new MessageDialog("Zatvorenik obrisan", "Obavještenje");
                await dialog.ShowAsync();
            }
            else
            {
                MessageDialog dialog = new MessageDialog("Niste odabrali zatvorenika", "Greška");
                await dialog.ShowAsync();
            }
        }

        private void Button_Edit_Click(object sender, RoutedEventArgs e)
        {

        }

        private async void button1_Copy2_Click(object sender, RoutedEventArgs e)
        {
            if(listView.SelectedItem!=null)
            {
                alarmic.ProfilZatvorenika = (ProfilZatvorenika)listView.SelectedItem;
                this.Frame.Navigate(typeof(FormaPrijemZatvorenika1),alarmic);
            }
            else
            {
                MessageDialog dialog = new MessageDialog("Niste odabrali zatvorenika", "Greška");
                await dialog.ShowAsync();
            }
        }
   }
}
