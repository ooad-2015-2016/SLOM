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
using Zatvor.ViewModel;
using Zatvor_pokusaj2.Klase;

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
        Alarm alarmic = null;
        private void textBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
        private async void button2_Click(object sender, RoutedEventArgs e)
        {
             if (comboBox.Items.Count == 0)
             {
                 MessageDialog dialog = new MessageDialog("Ne postoji zatvorenik za kojeg možete krairati medicinski karton", "Greška");
                 await dialog.ShowAsync();
             }
             else
             {
                List<ProfilZatvorenika> zatvorenici = DataSource.DataSourceLikovi.k.DajSveZatvorenike();
                string zatvorenik = comboBox.SelectedItem.ToString();
                ZdravstveniKartonViewModel n = new ZdravstveniKartonViewModel();
                if (n.ValidirajZdravstveniKarton(tDijagnoza.Text, tTerapija.Text))
                {
                    string id = zatvorenik[0].ToString() + zatvorenik[1].ToString() + zatvorenik[2].ToString() + zatvorenik[3].ToString() + zatvorenik[4].ToString();
                    foreach (ProfilZatvorenika p in zatvorenici)
                    {
                        if (p.IdZatvorenika.ToString() == id)
                        {
                            ZdravstveniKarton novi = n.KreirajZdravstveniKarton(p.Ime, p.Prezime, p.IdZatvorenika.ToString(), tDijagnoza.Text, tTerapija.Text);
                            (ViewModel.KontejnerViewModel.KontejnerMetoda(DataSource.DataSourceLikovi.k)).DodajZdravstveniKarton(novi);
                            p.MedicinskiKarton = novi;
                            comboBox.Items.Remove(p.IdZatvorenika + " " + p.Ime + " " + p.Prezime);
                            textBlock_Copy1.Text = "";
                            break;
                        }
                    }
                    MessageDialog dialog = new MessageDialog("Karton uspješno dodan", "Obavještenje");
                    await dialog.ShowAsync();
                }
                else
                {
                    MessageDialog dialog = new MessageDialog("Pogrešno ste unijeli podatke", "Greška");
                    await dialog.ShowAsync();
                }
            }
            
        }
       
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            List<Uposlenik> uposlenici = DataSource.DataSourceLikovi.k.DajSveUposlenike();
            foreach (Uposlenik u in uposlenici)
            {
                if (u.Login_podaci.Username.Equals(alarmic.Podaci[0]))
                {
                    if (u.FunkcijaUposlenika.Equals("Medicinski radnik"))
                    {
                        List<string> podaci = new List<string>();
                        podaci.Add(u.Login_podaci.Username); podaci.Add(u.Login_podaci.Password);
                        alarmic.Podaci = podaci;
                        this.Frame.Navigate(typeof(FormaMedicinskiRadnik), alarmic);
                    }
                }
            }
        }

        private void button1_Copy_Click(object sender, RoutedEventArgs e)
        {
            tDijagnoza.Text = "";
            tTerapija.Text = "";
            textBlock_Copy1.Text = "";
            comboBox.SelectedItem = null;
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            alarmic = (Alarm)e.Parameter;
            List<ProfilZatvorenika> zatvorenici = DataSource.DataSourceLikovi.DajSveZatvorenike();
            foreach(ProfilZatvorenika pz in zatvorenici)
            {
                if(pz.MedicinskiKarton==null)
                {
                    comboBox.Items.Add(pz.IdZatvorenika + " " + pz.Ime + " " + pz.Prezime);
                }
            }
            base.OnNavigatedTo(e);
        }

        private async void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            List<ProfilZatvorenika> zatvorenici = DataSource.DataSourceLikovi.k.DajSveZatvorenike();
            try
            {
               
                    string zatvorenik = comboBox.SelectedItem.ToString();
                    string id = zatvorenik[0].ToString() + zatvorenik[1].ToString() + zatvorenik[2].ToString() + zatvorenik[3].ToString() + zatvorenik[4].ToString();
                    textBlock_Copy1.Text = "Broj kartona: " + id;
            }
            catch (Exception)
            {
                
            }
        }
    }
}
