using pop_sf30_2016.UI.IzmenaEntiteta;
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
    /// Interaction logic for AkcijaWindow.xaml
    /// </summary>
    public partial class AkcijaWindow : Window
    {

        ICollectionView view;

        public AkcijaWindow()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(Projekat.Instace.akcija);
            view.Filter = AkcijaFilter;
            dgAkcija.ItemsSource = view;
            dgAkcija.IsSynchronizedWithCurrentItem = true;

            dgAkcija.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            if (Projekat.Instace.Aktivan == false)
            {
                btnDodaj.Visibility = Visibility.Hidden;
                btnIzmeni.Visibility = Visibility.Hidden;
                btnObrisi.Visibility = Visibility.Hidden;
            }

            cbSortiraj.Items.Add("Reset");
            cbSortiraj.Items.Add("Datum Pocetka");
            cbSortiraj.Items.Add("Datum Zavrsetka");
            cbSortiraj.Items.Add("Popust");

            AktivneAkcije();

        }

        public static void AktivneAkcije()
        {
            foreach (Akcija akcija in Projekat.Instace.akcija)
            {
                if (akcija.DatumZavrsetka < DateTime.Now)
                {
                    Akcija.Delete(akcija);
                }
            }
        }

        private bool AkcijaFilter(object obj)
        {
            return !((Akcija)obj).Obrisan;
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            var novaAkcija = new Akcija
            {
                
            };
            var a = new IzmenaAkcijaWindow(novaAkcija, IzmenaAkcijaWindow.Operacija.DODAVANJE);
            a.Show();
        }

        private void Izmeni_Click(object sender, RoutedEventArgs e)
        {
            var selektovani = (Akcija)dgAkcija.SelectedItem;

            var a = new IzmenaAkcijaWindow(selektovani, IzmenaAkcijaWindow.Operacija.IZMENA);
            a.Show();
        }

        private void Obrisi_Click(object sender, RoutedEventArgs e)
        {
            var izabrani = (Akcija)dgAkcija.SelectedItem;


            if (MessageBox.Show($"Da li ste sigurni da zelite da obrisete: { izabrani.DatumPocetka}?", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {

                Akcija.Delete(izabrani);
                view.Refresh();
            }
        }

        private void Izlaz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgAkcija_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
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
                dgAkcija.Items.SortDescriptions.Clear();
            }
            else if (cbSortiraj.SelectedIndex == 1)
            {
                dgAkcija.Items.SortDescriptions.Clear();
                dgAkcija.Items.SortDescriptions.Add(new SortDescription("DatumPocetka", ListSortDirection.Descending));
            }
            else if (cbSortiraj.SelectedIndex == 2)
            {
                dgAkcija.Items.SortDescriptions.Clear();
                dgAkcija.Items.SortDescriptions.Add(new SortDescription("DatumZavrsetka", ListSortDirection.Descending));
            }
            else if (cbSortiraj.SelectedIndex == 3)
            {
                dgAkcija.Items.SortDescriptions.Clear();
                dgAkcija.Items.SortDescriptions.Add(new SortDescription("Popust", ListSortDirection.Descending));
            }
        }
    }
}
