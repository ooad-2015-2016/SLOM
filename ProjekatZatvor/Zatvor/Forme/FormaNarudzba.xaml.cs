using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Zatvor.ViewModel;
using Zatvor_pokusaj2.Klase;
using Zatvor.Klase;
using Zatvor.DataSource;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Zatvor.Forme
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FormaNarudzb1a : Page
    {
        public FormaNarudzb1a()
        {
            this.InitializeComponent();
        }

        private async void button_Click(object sender, RoutedEventArgs e)
        {
            //List<Narudzba> narudzbe = new List<Narudzba>();
            NarudzbaViewModel n = new NarudzbaViewModel();
            if (n.ValidirajNarudzbu(tNaziv.Text, tKolicina.Text))
            {
                Narudzba nova = n.KreirajNarudzbu(tNaziv.Text, tKolicina.Text);
                //narudzbe.Add(nova);
                listView.Items.Add(tNaziv.Text + "          " + tKolicina.Text + " kom");

            }

            else {
                MessageDialog dialog = new MessageDialog("Pogrešno ste unijeli kolicinu", "Greška");
                await dialog.ShowAsync();
            }
            tNaziv.Text = "";
            tKolicina.Text = "";
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            if (testniHepek.Text.Equals("MedicinskiRadnik"))
                  this.Frame.Navigate(typeof(FormaMedicinskiRadnik));
            else 
                  this.Frame.Navigate(typeof(FormaRadnikUKantini));
        }

        private void tNaziv_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            tNaziv.Text = "";
            tKolicina.Text = "";
            listView.Items.Clear();
        }

        private void button3_Copy_Click(object sender, RoutedEventArgs e)
        {
            listView.Items.Remove(listView.SelectedItem);
        }

        private async void button1_Click(object sender, RoutedEventArgs e)
        {
            MessageDialog dialog = new MessageDialog("Zahtjev uspješno poslan", "Obavještenje");
            await dialog.ShowAsync();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is string)
            {
                testniHepek.Text = e.Parameter.ToString();
            }
            base.OnNavigatedTo(e);
        }
    }
}
