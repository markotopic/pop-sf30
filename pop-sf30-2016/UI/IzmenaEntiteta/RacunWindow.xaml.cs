using SF_30_2016.Model;
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

namespace pop_sf30_2016.UI.IzmenaEntiteta
{
    /// <summary>
    /// Interaction logic for RacunWindow.xaml
    /// </summary>
    public partial class RacunWindow : Window
    {

        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };

        private ProdajaNamestaja prodajaNamestaja;
        private Operacija operacija;

        public RacunWindow(ProdajaNamestaja prodajaNamestaja, Operacija operacija)
        {
            InitializeComponent();

            this.prodajaNamestaja = prodajaNamestaja;
            this.operacija = operacija;

            tbKupac.DataContext = prodajaNamestaja;
            tbBrojRacuna.DataContext = prodajaNamestaja;
            
        }

        private void btnDodajNamestaj_Click(object sender, RoutedEventArgs e)
        {
            var prikazNamestaja = new MainWindow();
            prikazNamestaja.Show();

        }
    }
}
