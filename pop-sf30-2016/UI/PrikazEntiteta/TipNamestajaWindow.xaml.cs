using pop_sf30_2016.UI.IzmenaEntiteta;
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

namespace pop_sf30_2016.UI.PrikazEntiteta
{
    /// <summary>
    /// Interaction logic for TipNamestajaWindow.xaml
    /// </summary>
    public partial class TipNamestajaWindow : Window
    {
        public TipNamestajaWindow()
        {
            InitializeComponent();

            dgTipNamestaja.ItemsSource = Projekat.Instace.tipnamestaja;
            dgTipNamestaja.IsSynchronizedWithCurrentItem = true;
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            var noviTipNamestaja = new TipNamestaja()
            {
                Naziv = ""
            };
            var a = new IzmenaTipaNamestajaWindow(noviTipNamestaja, IzmenaTipaNamestajaWindow.Operacija.DODAVANJE);
            a.Show();
        }

        private void Izmeni_Click(object sender, RoutedEventArgs e)
        {
            var selektovani = (TipNamestaja)dgTipNamestaja.SelectedItem;

            var a = new IzmenaTipaNamestajaWindow(selektovani, IzmenaTipaNamestajaWindow.Operacija.IZMENA);
            a.Show();
        }

        private void Obrisi_Click(object sender, RoutedEventArgs e)
        {
            var izabrani = (TipNamestaja)dgTipNamestaja.SelectedItem;


            if (MessageBox.Show($"Da li ste sigurni da zelite da obrisete: { izabrani.Naziv}?", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {

                foreach (var n in Projekat.Instace.tipnamestaja)
                {
                    if (n.Id == izabrani.Id)
                    {
                        n.Obrisan = true;
                        break;
                    }
                }

                GenericSerializer.Serialize("tipNamestaja.xml", Projekat.Instace.tipnamestaja);

            }
        }

        private void Izlaz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
