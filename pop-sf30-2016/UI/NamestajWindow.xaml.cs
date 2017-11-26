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

            tbNazi.DataContext = namestaj;
            cbTipNamestaja.DataContext = namestaj;
            tbJedinicnaCena.DataContext = namestaj;
            tbSifra.DataContext = namestaj;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            var listaNamestaja = Projekat.Instace.Namestaj;

            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    namestaj.Id = listaNamestaja.Count + 1;
                    listaNamestaja.Add(namestaj);
                    this.Close();
                    break;
                case Operacija.IZMENA:
                    foreach (var n in listaNamestaja)
                    {
                        if (n.Id == namestaj.Id)
                        {
                            n.TipNamestajaId = namestaj.TipNamestajaId;
                            n.Naziv = namestaj.Naziv;
                            n.JedinicnaCena = namestaj.JedinicnaCena;
                            n.Sifra = namestaj.Sifra;
                            this.Close();
                            break;
                        }
                    }
                    break;
                default:
                    break;
            }
            GenericSerializer.Serialize("namestaj.xml", listaNamestaja);
        }

        private void Izlaz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
