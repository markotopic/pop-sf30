using pop_sf30_2016.UI;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pop_sf30_2016
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ICollectionView view;

        public MainWindow()
        {
            
            InitializeComponent();
           
            view = CollectionViewSource.GetDefaultView(Projekat.Instace.namestaj);
            view.Filter = NamestajFilter;
            dgNamestaj.ItemsSource = view;
            dgNamestaj.IsSynchronizedWithCurrentItem = true;

            dgNamestaj.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            if (Projekat.Instace.Aktivan == false)
            {
                btnDodaj.Visibility = Visibility.Hidden;
                btnIzmeni.Visibility = Visibility.Hidden;
                btnObrisi.Visibility = Visibility.Hidden;
            }

            cbSortiraj.Items.Add("Reset");
            cbSortiraj.Items.Add("Naziv");
            cbSortiraj.Items.Add("Sifra");
            cbSortiraj.Items.Add("Cena");
            cbSortiraj.Items.Add("Kolcini");
            cbSortiraj.Items.Add("Akciji");
            cbSortiraj.Items.Add("Tipu namestaja");

        }

        private bool NamestajFilter(object obj)
        {
            return !((Namestaj)obj).Obrisan;
        }

        private void Izlaz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DodajNamestaj(object sender, RoutedEventArgs e)
        {
            var noviNamestaj = new Namestaj()
            {
                Naziv = ""
            };
            var namestajProzor = new NamestajWindow(noviNamestaj, NamestajWindow.Operacija.DODAVANJE);
            namestajProzor.Show();

            //this.DialogResult = true;

        }

        private void IzmeniNamestaj(object sender, RoutedEventArgs e)
        {
            var selektovaniNamestaj = (Namestaj)dgNamestaj.SelectedItem;

            var namestajProzor = new NamestajWindow(selektovaniNamestaj, NamestajWindow.Operacija.IZMENA);
            namestajProzor.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var izabraniNamestaj = (Namestaj)dgNamestaj.SelectedItem;

            if (MessageBox.Show($"Da li ste sigurni da zelite da obrisete: { izabraniNamestaj.Naziv}?", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Namestaj.Delete(izabraniNamestaj);
                view.Refresh();
            }
        }

        private void dgNamestaj_AutoGeneratingColumn(object sender,
            DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "Obrisan")
            {
                e.Cancel = true;
            }
            if ((string)e.Column.Header == "TipNamestajaId")
            {
                e.Cancel = true;
            }
            if ((string)e.Column.Header == "Id")
            {
                e.Cancel = true;
            }
            if ((string)e.Column.Header == "AkcijaId")
            {
                e.Cancel = true;
            }
        }

        private void cbSortiraj_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbSortiraj.SelectedIndex == 0)
            {
                dgNamestaj.Items.SortDescriptions.Clear();
            }
            else if (cbSortiraj.SelectedIndex == 1)
            {
                dgNamestaj.Items.SortDescriptions.Clear();
                dgNamestaj.Items.SortDescriptions.Add(new SortDescription("Naziv", ListSortDirection.Descending));
            }
            else if (cbSortiraj.SelectedIndex == 2)
            {
                dgNamestaj.Items.SortDescriptions.Clear();
                dgNamestaj.Items.SortDescriptions.Add(new SortDescription("Sifra", ListSortDirection.Descending));
            }
            else if (cbSortiraj.SelectedIndex == 3)
            {
                dgNamestaj.Items.SortDescriptions.Clear();
                dgNamestaj.Items.SortDescriptions.Add(new SortDescription("JedinicnaCena", ListSortDirection.Descending));
            }
            else if (cbSortiraj.SelectedIndex == 4)
            {
                dgNamestaj.Items.SortDescriptions.Clear();
                dgNamestaj.Items.SortDescriptions.Add(new SortDescription("Kolicina", ListSortDirection.Descending));
            }
            else if (cbSortiraj.SelectedIndex == 5)
            {
                dgNamestaj.Items.SortDescriptions.Clear();
                dgNamestaj.Items.SortDescriptions.Add(new SortDescription("AkcijaId", ListSortDirection.Descending));
            }
            else if (cbSortiraj.SelectedIndex == 6)
            {
                dgNamestaj.Items.SortDescriptions.Clear();
                dgNamestaj.Items.SortDescriptions.Add(new SortDescription("TipNamestajaId", ListSortDirection.Descending));
            }
        }
    }
}
