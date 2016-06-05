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
    public sealed partial class FormaZahtjevZaDopust : Page
    {
        public FormaZahtjevZaDopust()
        {
            this.InitializeComponent();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            comboBox.SelectedItem = null;
            textBox1.Text = "";
            pocetak.Date = DateTime.Today;
            kraj.Date = DateTime.Today;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            List<Uposlenik> uposlenici = DataSource.DataSourceLikovi.k.DajSveUposlenike();
            foreach (Uposlenik u in uposlenici)
            {
                if (u.Login_podaci.Username.Equals(testniHepek.Text))
                {
                    if (u.FunkcijaUposlenika.Equals("Cuvar"))
                    {
                        List<string> podaci = new List<string>();
                        podaci.Add(u.Login_podaci.Username); podaci.Add(u.Login_podaci.Password);
                        this.Frame.Navigate(typeof(FormaCuvar1), podaci);
                    }
                }
            }
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            List<ProfilZatvorenika> zatvorenici = DataSource.DataSourceLikovi.k.DajSveZatvorenike();
            foreach(ProfilZatvorenika pz in zatvorenici)
            {
                comboBox.Items.Add(pz.Ime + " " + pz.Prezime);
            }
            testniHepek.Text = e.Parameter.ToString();
            base.OnNavigatedTo(e);
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FormaLogin));
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (textBox1.Text == "") throw (new Exception());
                if (pocetak.Date < DateTime.Today) throw (new Exception()); 
                if (kraj.Date < DateTime.Today) throw (new Exception());
                string podaci = comboBox.SelectedItem.ToString();
                Zahtjev z = new Zahtjev(podaci, textBox1.Text, pocetak.Date.DateTime, kraj.Date.DateTime, false);
                DataSource.DataSourceLikovi.Upravnik.Zahtjevi.Add(z);
                MessageDialog dialog = new MessageDialog("Zahtjev poslan", "Obavještenje");
                await dialog.ShowAsync();
            }
            catch(Exception)
            {
                MessageDialog dialog = new MessageDialog("Pogrešan unos", "Greška");
                await dialog.ShowAsync();
            }
           
        }
    }
}
