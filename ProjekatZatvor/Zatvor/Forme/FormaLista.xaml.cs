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
using Zatvor.Forme;
using Zatvor.Klase;
using Zatvor_pokusaj2.Klase;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Zatvor.Forme
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FormaLista : Page
    {
        public FormaLista()
        {
            this.InitializeComponent();
        }

        private void button1_Copy_Click(object sender, RoutedEventArgs e)
        {
            List<string> podaci = new List<string>();
            podaci.Add("Upravnik");podaci.Add("Upravnik123");
            this.Frame.Navigate(typeof(FormaUpravnikZatvora1),podaci);
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            foreach (Uposlenik u in (List<Uposlenik>)e.Parameter)
                listView.Items.Add(u);
            base.OnNavigatedTo(e);
        }
    }
}
