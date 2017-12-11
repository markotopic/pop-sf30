using SF_30_2016.Model;
using SF_30_2016.Modeli;
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
    /// Interaction logic for IzmenaProdajeNamestajaWindow.xaml
    /// </summary>
    public partial class IzmenaProdajeNamestajaWindow : Window
    {

        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };

        private ProdajaNamestaja prodajaNamestaja;
        private Operacija operacija;

        public IzmenaProdajeNamestajaWindow(ProdajaNamestaja prodajaNamestaja, Operacija operacija)
        {
            InitializeComponent();

            this.prodajaNamestaja = prodajaNamestaja;
            this.operacija = operacija;

            //dgDodatnaUsluga.ItemsSource = Projekat.Instace.DodatnaUsluga;
            dgDodatnaUsluga.ItemsSource = prodajaNamestaja.DodatneUsluge;
            dgDodatnaUsluga.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            tbKupac.DataContext = prodajaNamestaja;
            tbUkupnaCena.DataContext = prodajaNamestaja;
            tbBrojRacuna.DataContext = prodajaNamestaja;
            tbBrojKomada.DataContext = prodajaNamestaja;
            tbDatumProdaje.DataContext = prodajaNamestaja;

        }
    }
}
