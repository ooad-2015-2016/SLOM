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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Zatvor.Forme
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FormaCuvar1 : Page
    {
        public FormaCuvar1()
        {
            this.InitializeComponent();
        }

       
        private void button_Click(object sender, RoutedEventArgs e)
        {
            int brojKartona = Convert.ToInt32(tIdZatvorenika.Text);
            this.Frame.Navigate(typeof(FormaPrijemZatvorenika1));
        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FormaLogin));
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FormaPrijemZatvorenika1));
        }

        private void button2_Copy_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Stop();
            button2.Visibility = Visibility.Visible;
            button2_Copy.Visibility = Visibility.Collapsed;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Play();
            button2_Copy.Visibility = Visibility.Visible;
            button2.Visibility = Visibility.Collapsed;
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FormaZahtjevZaDopust));
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            List<Uposlenik> cuvari = DataSource.DataSourceLikovi.k.DajSveUposlenike();
            List<string> podaci = (List<string>)e.Parameter;
            foreach(Uposlenik c in cuvari)
            {
                if(c.Login_podaci.Username.Equals(podaci[0]))
                    {
                    textBlock.Text = "Dobrodošli " + c.Ime + " " + c.Prezime;
                    }
            }
            base.OnNavigatedTo(e);
        }
    }
}
