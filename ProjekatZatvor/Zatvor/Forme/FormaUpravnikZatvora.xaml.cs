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
using Zatvor.ViewModel;
using Zatvor.DataSource;
using Zatvor_pokusaj2.Klase;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Zatvor.Forme
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FormaUpravnikZatvora1 : Page
    {
        public FormaUpravnikZatvora1()
        {
            this.InitializeComponent();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FormaLista), KontejnerViewModel.KontejnerMetoda(DataSourceLikovi.k).DajSveUposlenike());
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FormaDodajUposlenika));
        }

        private void button2_Copy1_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Stop();
            button2_Copy.Visibility = Visibility.Visible;
            button2_Copy1.Visibility = Visibility.Collapsed;
            
        }

        private void button2_Copy_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Play();
            button2_Copy.Visibility = Visibility.Collapsed;
            button2_Copy1.Visibility = Visibility.Visible;
        }

        private void button1_Copy_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FormaLogin));
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            List<Uposlenik> upravnici = DataSource.DataSourceLikovi.k.DajSveUposlenike();
            List<string> podaci = (List<string>)e.Parameter;
            foreach (Uposlenik s in upravnici)
            {
                if (s.Login_podaci.Username.Equals(podaci[0]))
                {
                    textBlock.Text = "Dobrodošli " + s.Ime + " " + s.Prezime;
                }
            }
            base.OnNavigatedTo(e);
        }

    }
}
