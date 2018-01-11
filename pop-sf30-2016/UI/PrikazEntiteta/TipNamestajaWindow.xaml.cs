using pop_sf30_2016.UI.IzmenaEntiteta;
using SF_30_2016.Model;
using SF_30_2016.Modeli;
using SF_30_2016.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        ICollectionView view;

        public TipNamestajaWindow()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(Projekat.Instace.tipnamestaja);
            view.Filter = Filter;
            dgTipNamestaja.ItemsSource = view;
            dgTipNamestaja.IsSynchronizedWithCurrentItem = true;

            dgTipNamestaja.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            cbSortiraj.Items.Add("Reset");
            cbSortiraj.Items.Add("Nazivu");
            
        }

        private bool Filter(object obj)
        {
            return !((TipNamestaja)obj).Obrisan;
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
                TipNamestaja.Delete(izabrani);
                view.Refresh();
            }
        }

        private void Izlaz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgTipNamestaja_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "Obrisan")
            {
                e.Cancel = true;
            }
            if ((string)e.Column.Header == "Id")
            {
                e.Cancel = true;
            }
        }

        private void cbSortiraj_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbSortiraj.SelectedIndex == 0)
            {
                dgTipNamestaja.Items.SortDescriptions.Clear();
            }
            else if (cbSortiraj.SelectedIndex == 1)
            {
                dgTipNamestaja.Items.SortDescriptions.Clear();
                dgTipNamestaja.Items.SortDescriptions.Add(new SortDescription("Naziv", ListSortDirection.Descending));
            }
        }
    }
}
