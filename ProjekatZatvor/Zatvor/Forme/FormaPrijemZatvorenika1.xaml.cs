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

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Zatvor.Forme
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class FormaPrijemZatvorenika1 : Page
    {
        public FormaPrijemZatvorenika1()
        {
            this.InitializeComponent();
        }

        private void button1_Copy_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void tIme_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tIme_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button1_Copy_Click_1(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FormaLogin));
        }

        private void button2_click(object sender, RoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(FormaCuvar1));
        }
    }
}
