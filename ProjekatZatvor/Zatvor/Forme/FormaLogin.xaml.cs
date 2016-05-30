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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Zatvor.Forme
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FormaLogin : Page
    {
        public FormaLogin()
        {
            this.InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            List<Uposlenik> uposlenici = DataSource.DataSourceLikovi.k.DajSveUposlenike();
            
            Korisnici uneseno = new Korisnici(tUsername.Text, tPassword.Password);
            
            foreach (Uposlenik u in uposlenici)
            {
                if (u.Login_podaci.Username.Equals(uneseno.Username) && u.Login_podaci.Password.Equals(uneseno.Password))
                {
                    textBlock_Copy1.Visibility = Visibility.Collapsed;
                    List<string> prijava = new List<string>();
                    prijava.Add(tUsername.Text);
                    prijava.Add(tPassword.Password);
                    if (u.FunkcijaUposlenika.Equals("Strazar"))
                    {
                        this.Frame.Navigate(typeof(FormaStrazar1), prijava);
                    }
                    else if (u.FunkcijaUposlenika.Equals("Cuvar"))
                    {
                        this.Frame.Navigate(typeof(FormaCuvar1), prijava);
                    }
                    else if (u.FunkcijaUposlenika.Equals("Upravnik"))
                    {
                        this.Frame.Navigate(typeof(FormaUpravnikZatvora1), prijava);
                    }
                    else if (u.FunkcijaUposlenika.Equals("RadnikUKantini"))
                    {
                        this.Frame.Navigate(typeof(FormaRadnikUKantini), prijava);
                    }
                    else if (u.FunkcijaUposlenika.Equals("Medicinski Radnik"))
                    {
                        this.Frame.Navigate(typeof(FormaMedicinskiRadnik), prijava);
                    }
                    break;
                }
            }
            textBlock_Copy1.Visibility = Visibility.Visible;
            tUsername.Text = "";
            tPassword.Password = "";
        }

        }
}
