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
    public sealed partial class FormaMedicinskiRadnik : Page
    {
        public FormaMedicinskiRadnik()
        {
            this.InitializeComponent();
        }

        private async void button1_Click(object sender, RoutedEventArgs e)
        {
            List<ProfilZatvorenika> zatvorenici = DataSource.DataSourceLikovi.k.DajSveZatvorenike();
            try
            {
                string zatvorenik = comboBox.SelectedItem.ToString();
                string id = zatvorenik[0].ToString() + zatvorenik[1].ToString() + zatvorenik[2].ToString() + zatvorenik[3].ToString() + zatvorenik[4].ToString();
                ZdravstveniKartonViewModel zwm = new ZdravstveniKartonViewModel();
                ProfilZatvorenika pz = zwm.OtvoriZdravstveniKarton(id);
                MessageDialog dialog = new MessageDialog("Zdravstveni karton \nIme i prezime: " + pz.Ime + " " + pz.Prezime + "\nBroj kartona: " + pz.MedicinskiKarton.BrojKartona + "\nDijagnoza: " + pz.MedicinskiKarton.Dijagnoza + "\nTerapija: " + pz.MedicinskiKarton.Terapija);
                await dialog.ShowAsync();
            }
            catch (Exception)
            {
                MessageDialog dialog = new MessageDialog("Niste odabrali zatvorenika", "Greška");
                await dialog.ShowAsync();
            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FormaLogin));
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FormaZdravstveniKarton),textBlock2.Text);
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FormaNarudzb1a),textBlock2.Text);
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            List<ProfilZatvorenika> zatvorenici = DataSourceLikovi.k.DajSveZatvorenike();
            foreach(ProfilZatvorenika pz in zatvorenici)
            {
                if(pz.MedicinskiKarton!=null)
                {
                    comboBox.Items.Add(pz.IdZatvorenika + " " + pz.Ime + " " + pz.Prezime);
                }
            }
            List<Uposlenik> medicinari = DataSource.DataSourceLikovi.k.DajSveUposlenike();
            List<string> podaci = (List<string>)e.Parameter;
            foreach (Uposlenik c in medicinari)
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
            string poruka = "Korisnički interfejs koji je dostupan medicinskom radniku sadrži funkcionalnosti:\n\n- Otvori zdravstveni karton - prikazat će se podaci o zdravstvenom kartonu s brojem unešenim u 'Broj kartona', koji mora biti broj, te ako ne postoji isti, čuvar će biti obaviješten.\n\n- Kreiraj zdravstveni karton - opcija otvara odgovarajući interfejs za dodavanje zdravstvenog kartona. Podrazumijevane vrijednosti polja 'Naziv potrepštine' i 'Količina' su string i broj respektivno. Ista će biti dodana na listu klikom na 'Dodaj na listu', dok je klikom na 'Delete' moguće obrisati narudžbu s liste.'Reset' će obrisati unešene podatke, a 'Pošalji zahtjev' će narudžbe koje su trenutno na listi poslati finansijskom savjetniku koji donosi odluku.\n\n- Logout - odjava sa sistema.";
            MessageDialog dialog = new MessageDialog(poruka, "Help");
            await dialog.ShowAsync();
        }
    }
}
