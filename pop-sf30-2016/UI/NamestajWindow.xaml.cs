using SF_30_2016.Model;
using SF_30_2016.Modeli;
using SF_30_2016.Util;
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
    /// Interaction logic for NamestajWindow.xaml
    /// </summary>
    public partial class NamestajWindow : Window
    {
        private Namestaj namestaj;
        private Operacija operacija;

        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };

        public NamestajWindow(Namestaj namestaj, Operacija operacija)
        {
            InitializeComponent();

            this.namestaj = namestaj;
            this.operacija = operacija;

            cbTipNamestaja.ItemsSource = Projekat.Instace.tipnamestaja;
            cbAkcija.ItemsSource = Projekat.Instace.akcija;

            tbNazi.DataContext = namestaj;
            cbTipNamestaja.DataContext = namestaj;
            cbAkcija.DataContext = namestaj;
            tbJedinicnaCena.DataContext = namestaj;
            //tbSifra.DataContext = namestaj;
            tbKolicinaUMagacinu.DataContext = namestaj;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            var listaNamestaja = Projekat.Instace.namestaj;

            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    Namestaj.Create(namestaj);
                    this.Close();
                    break;
                case Operacija.IZMENA:
                    Namestaj.Update(namestaj);
                    this.Close();
                    break;
                default:
                    break;
            }
            
        }

        private void Izlaz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
