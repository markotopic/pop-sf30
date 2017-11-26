using pop_sf30_2016.UI.PrikazEntiteta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace pop_sf30_2016.UI
{
    /// <summary>
    /// Interaction logic for EntitetiWindow.xaml
    /// </summary>
    public partial class EntitetiWindow : Window
    {
        public EntitetiWindow()
        {
            InitializeComponent();
        }

        private void NamestajWindow_Click(object sender, RoutedEventArgs e)
        {
            
            var prikazNamestaja = new MainWindow();
            prikazNamestaja.Show();

        }

        private void TipNamestaja_Click(object sender, RoutedEventArgs e)
        {
            var prikazTipaNamestaja = new TipNamestajaWindow();
            prikazTipaNamestaja.Show();
        }

        private void DodatanaUsluga_Click(object sender, RoutedEventArgs e)
        {
            var prikazDodanteUsluge = new DodatnaUslugaWindow();
            prikazDodanteUsluge.Show();
        }

        private void Akcija_Click(object sender, RoutedEventArgs e)
        {
            var prikazAkcije = new AkcijaWindow();
            prikazAkcije.Show();
        }

        private void Koirsnik_Click(object sender, RoutedEventArgs e)
        {
            var prikazKorisnike = new KorisnikWindow();
            prikazKorisnike.Show();
        }

        private void ProdajaNamestaja_Click(object sender, RoutedEventArgs e)
        {
            var a = new ProdajaNamestajaWindow();
            a.Show();
        }
    }
}
