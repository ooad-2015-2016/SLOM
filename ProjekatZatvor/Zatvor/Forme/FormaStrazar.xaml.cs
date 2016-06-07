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
using Zatvor_pokusaj2.Klase;
using Zatvor.DataSource;
using Zatvor.ViewModel;
using Windows.UI.Popups;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Zatvor.Forme
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FormaStrazar1 : Page
    {
        public FormaStrazar1()
        {
            this.InitializeComponent();
        }
        Alarm alarmic = null;
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FormaLogin),alarmic);
        }
        private void button2_Copy_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Stop();
            button2.Visibility = Visibility.Visible;
            button2_Copy.Visibility = Visibility.Collapsed;
            alarmic.t = false;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Play();
            button2_Copy.Visibility = Visibility.Visible;
            button2.Visibility = Visibility.Collapsed;
            alarmic.t = true;
            alarmic.Toggle();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            alarmic = (Alarm)e.Parameter;
            List<Uposlenik> strazari = DataSource.DataSourceLikovi.k.DajSveUposlenike();
            List<string> podaci = alarmic.Podaci;
            foreach (Uposlenik s in strazari)
            {
                if (s.Login_podaci.Username.Equals(podaci[0]))
                {
                    textBlock.Text = "Dobrodošli " + s.Ime + " " + s.Prezime;
                }
            }
            base.OnNavigatedTo(e);
        }

        private async void button1_Copy1_Click(object sender, RoutedEventArgs e)
        {
            string poruka = "Korisnički interfejs koji je dostupan stražaru sadrži funkcionalnosti:\n\n- Aktiviraj alarm - opcija za aktivaciju alarma.\n\n- Logout - odjava sa sistema.";
            MessageDialog dialog = new MessageDialog(poruka, "Help");
            await dialog.ShowAsync();
        }
    }
}
