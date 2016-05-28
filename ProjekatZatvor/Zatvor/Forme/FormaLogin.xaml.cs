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
            List<Korisnici> korisnici = new List<Korisnici>();
            Korisnici k1 = new Korisnici("Cuvar", "Cuvar123");
            Korisnici k2 = new Korisnici("Strazar", "Cuvar123");
            korisnici.Add(k1); korisnici.Add(k2);
            Korisnici uneseno = new Korisnici(tUsername.Text, tPassword.Password);
            foreach (Korisnici k in korisnici)
            {
                if (k.Username.Equals(uneseno.Username) && k.Password.Equals(uneseno.Password))
                {
                    textBlock_Copy1.Visibility = Visibility.Collapsed;
                    List<string> stvarcice = new List<string>();
                    stvarcice.Add(tUsername.Text);
                    stvarcice.Add(tPassword.Password);
                    if (k.Username.Equals("Strazar"))
                    {
                        this.Frame.Navigate(typeof(FormaStrazar1));
                    }
                    else if (k.Username.Equals("Cuvar"))
                    {
                        this.Frame.Navigate(typeof(FormaCuvar1), stvarcice);
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
