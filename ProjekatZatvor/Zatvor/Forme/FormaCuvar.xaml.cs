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
    public sealed partial class FormaCuvar1 : Page
    {
        public FormaCuvar1()
        {
            this.InitializeComponent();
        }


        private void button_Click(object sender, RoutedEventArgs e)
        {
           // int brojKartona = Convert.ToInt32(tIdZatvorenika.Text);
            this.Frame.Navigate(typeof(FormaPrijemZatvorenika1));
        }

        private void button1_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FormaLogin));
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FormaPrijemZatvorenika1), textBlock2.Text);
        }
        Alarm a = null;
        private void button2_Copy_Click(object sender, RoutedEventArgs e)
        {
            mediaElement.Stop();
            button2.Visibility = Visibility.Visible;
            button2_Copy.Visibility = Visibility.Collapsed;
            a.t = false;
            a = null;
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            a = new Alarm();
            mediaElement.Play();
            button2_Copy.Visibility = Visibility.Visible;
            button2.Visibility = Visibility.Collapsed;
            a.t = true;
            a.Toggle();
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FormaListaZatvorenika), textBlock2.Text);// (KontejnerViewModel.KontejnerMetoda(DataSourceLikovi.k)).DajSveZatvorenike());

        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            List<ProfilZatvorenika> zatvorenici = DataSource.DataSourceLikovi.k.DajSveZatvorenike();
            foreach(ProfilZatvorenika pz in zatvorenici)
            {
                string zatvorenikList = pz.IdZatvorenika + " " + pz.Ime + " " + pz.Prezime;
                comboBox.Items.Add(zatvorenikList);
            }
            List<Uposlenik> cuvari = DataSource.DataSourceLikovi.k.DajSveUposlenike();
            List<string> podaci = (List<string>)e.Parameter;
            foreach (Uposlenik c in cuvari)
            {
                if (c.Login_podaci.Username.Equals(podaci[0]))
                {
                    textBlock.Text = "Dobrodošli " + c.Ime + " " + c.Prezime;
                    textBlock2.Text = c.Login_podaci.Username;
                }
            }
            base.OnNavigatedTo(e);
        }

        private void buttonZahtjev_Click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FormaZahtjevZaDopust), textBlock2.Text);
        }

        private async void button5_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<ProfilZatvorenika> zatvorenici = DataSourceLikovi.k.DajSveZatvorenike();
                if(comboBox.SelectedItem==null)
                {
                    MessageDialog dialog = new MessageDialog("Niste odabrali zatvorenika ", "Greška");
                    await dialog.ShowAsync();
                }
                else
                {
                    string zatvorenik = comboBox.SelectedItem.ToString();
                    string id = zatvorenik[0].ToString() + zatvorenik[1].ToString() + zatvorenik[2].ToString() + zatvorenik[3].ToString() + zatvorenik[4].ToString();
                    int ID = Convert.ToInt32(id);
                    ProfilZatvorenikaViewModel pr = new ProfilZatvorenikaViewModel();
                    ProfilZatvorenika p = pr.OtvoriProfilZatvorenika(ID);
                    MessageDialog dialog = new MessageDialog("Ime i prezime: " + p.Ime + " " + p.Prezime + "\nAdresa stanovanja: " + p.AdresaStanovanja + "\nBroj telefona: " + p.BrojTelefona + "\nBroj licne karte: " + p.BrojLicneKarte + "\nOpis: " + p.DodatniOpis, "O zatvoreniku");
                    await dialog.ShowAsync();
                    /*
                    
                    foreach (ProfilZatvorenika p in zatvorenici)
                    {
                        if (p.IdZatvorenika.ToString() == id)
                        {
                            MessageDialog dialog = new MessageDialog("Ime i prezime: " + p.Ime + " " + p.Prezime + "\nAdresa stanovanja: " + p.AdresaStanovanja + "\nBroj telefona: " + p.BrojTelefona + "\nBroj lične karte: " + p.BrojLicneKarte + "\nOpis: " + p.DodatniOpis, "O zatvoreniku");
                            await dialog.ShowAsync();
                            break;
                        }
                    }*/
                }
                
            }
            catch (Exception)
            {
                MessageDialog dialog = new MessageDialog("Pogrešan unos", "Greška");
                await dialog.ShowAsync();
            }
        }

        private async void button1_Copy1_Click(object sender, RoutedEventArgs e)
        {
            string poruka = "Korisnički interfejs koji je dostupan čuvaru sadrži funkcionalnosti:\n\n- Otvori profil zatvorenika - otvorit će se podaci o zatvoreniku s ID-em unešenim u 'Id Zatvorenika', koji mora biti broj, te ako ne postoji isti, čuvar će biti obaviješten.\n\n- Kreiraj profil zatvorenika - opcija otvara odgovarajući interfejs za dodavanje zatvorenika. Podrazumijevane vrijednosti polja 'Ime','Prezime','Adresa' te 'Dodatni opis' su stringovi, za 'JMBG' 13-cifreni broj, za 'Broj lične karte' 9-slovni string, 'Osuđivan ranije' vrijednosti Da/Ne, te za 'Visina' visina u cm i 'Težina' u kg. Zatvorenik će biti dodan klikom na 'Dodaj zatvorenika', dok će 'Reset' obrisati unešene podatke.\n\n- Prikaži listu zatvorenika - opcija otvara odgovarajući interfejs koji će prikazati listu zatvorenika, te je moguće obrisati zatvorenika klikom na 'Obriši zatvorenika'.\n\n- Kreiraj zahtjev za dopust - opcija otvara odgovarajći interfejs za kreiranje zahtjeva. Podrazumijevane vrijednosti 'Ime i Prezime' te 'Obrazloženje zahtjeva za dopust' su string. Zahtjev će biti dodan klikom na 'Pošalji zahtjev', dok će 'Reset' obrisati unešene podatke.\n\n- Aktiviraj alarm - opcija za aktivaciju alarma.\n\n- Logout - odjava sa sistema.";
            MessageDialog dialog = new MessageDialog(poruka, "Help");
            await dialog.ShowAsync();
        }
        private void AutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            // Only get results when it was a user typing, 
            // otherwise assume the value got filled in by TextMemberPath 
            // or the handler for SuggestionChosen.
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                //Set the ItemsSource to be your filtered dataset
                //sender.ItemsSource = dataset;
                sender.ItemsSource = DataSourceLikovi.k.DajSveZatvorenike();
                List<ProfilZatvorenika> m = new List<ProfilZatvorenika>();
                foreach (ProfilZatvorenika a in DataSourceLikovi.k.DajSveZatvorenike())
                {
                    if (sender.Text.Length <= a.IdZatvorenika.ToString().Length && a.IdZatvorenika.ToString().Substring(0, sender.Text.Length).Equals(sender.Text)) m.Add(a);
                    else if (sender.Text.Length <= a.Ime.ToString().Length && a.Ime.ToString().Substring(0, sender.Text.Length).Equals(sender.Text)) m.Add(a);
                    else if (sender.Text.Length <= a.Prezime.ToString().Length && a.Prezime.ToString().Substring(0, sender.Text.Length).Equals(sender.Text)) m.Add(a);
                    else if (sender.Text.Length <= a.BrojLicneKarte.ToString().Length && a.BrojLicneKarte.ToString().Substring(0, sender.Text.Length).Equals(sender.Text)) m.Add(a);
                }
                sender.ItemsSource = m;
                //this.InvalidateArrange();
            }
        }


        private void AutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            // Set sender.Text. You can use args.SelectedItem to build your text string.
        }


        private async void AutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if (args.ChosenSuggestion != null)
            {
                // User selected an item from the suggestion list, take an action on it here.
                MessageDialog dialog = new MessageDialog(args.ChosenSuggestion.ToString());
                sender.Text = "";
                await dialog.ShowAsync();
            }
            else
            {
                // Use args.QueryText to determine what to do.
                MessageDialog dialog = new MessageDialog("Ne postoji zatvorenik s tim ID-em", "Greška");
                await dialog.ShowAsync();
            }
        }

    }
}
