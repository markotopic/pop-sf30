using pop_sf30_2016.UI.IzmenaEntiteta;
using SF_30_2016.Model;
using SF_30_2016.Modeli;
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
    /// Interaction logic for SalonWindow.xaml
    /// </summary>
    public partial class SalonWindow : Window
    {
        ICollectionView view;

        public SalonWindow()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(Projekat.Instace.salon);
            view.Filter = NamestajFilter;
            dgNamestaj.ItemsSource = view;
            dgNamestaj.IsSynchronizedWithCurrentItem = true;

            dgNamestaj.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            cbSortiraj.Items.Add("Reset");
            cbSortiraj.Items.Add("Nazivu");
            cbSortiraj.Items.Add("Email-u");
            cbSortiraj.Items.Add("Adresi sajta");
            cbSortiraj.Items.Add("PIB-u");
            cbSortiraj.Items.Add("Maticnom broju");
            cbSortiraj.Items.Add("Ziro racun");
        }

        private bool NamestajFilter(object obj)
        {
            return !((Salon)obj).Obrisan;
        }

        private void dgNamestaj_AutoGeneratingColumn(object sender,
            DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "ID")
            {
                e.Cancel = true;
            }
            if ((string)e.Column.Header == "Obrisan")
            {
                e.Cancel = true;
            }
        }

        private void btnDodaj_Click(object sender, RoutedEventArgs e)
        {
            var noviSalon = new Salon()
            {
                Naziv = ""
            };
            var Prozor = new IzmenaSalonaWindow(noviSalon, IzmenaSalonaWindow.Operacija.DODAVANJE);
            Prozor.Show();
        }

        private void btnIzmeni_Click(object sender, RoutedEventArgs e)
        {
            var selektovaniNamestaj = (Salon)dgNamestaj.SelectedItem;

            var namestajProzor = new IzmenaSalonaWindow(selektovaniNamestaj, IzmenaSalonaWindow.Operacija.IZMENA);
            namestajProzor.Show();
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            var izabraniNamestaj = (Salon)dgNamestaj.SelectedItem;

            if (MessageBox.Show($"Da li ste sigurni da zelite da obrisete: { izabraniNamestaj.Naziv}?", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Salon.Delete(izabraniNamestaj);
                view.Refresh();
            }
        }

        private void Izlaz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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
                dgNamestaj.Items.SortDescriptions.Add(new SortDescription("Email", ListSortDirection.Descending));
            }
            else if (cbSortiraj.SelectedIndex == 3)
            {
                dgNamestaj.Items.SortDescriptions.Clear();
                dgNamestaj.Items.SortDescriptions.Add(new SortDescription("AdresaSajta", ListSortDirection.Descending));
            }
            else if (cbSortiraj.SelectedIndex == 4)
            {
                dgNamestaj.Items.SortDescriptions.Clear();
                dgNamestaj.Items.SortDescriptions.Add(new SortDescription("PIB", ListSortDirection.Descending));
            }
            else if (cbSortiraj.SelectedIndex == 5)
            {
                dgNamestaj.Items.SortDescriptions.Clear();
                dgNamestaj.Items.SortDescriptions.Add(new SortDescription("MaticniBroj", ListSortDirection.Descending));
            }
            else if (cbSortiraj.SelectedIndex == 6)
            {
                dgNamestaj.Items.SortDescriptions.Clear();
                dgNamestaj.Items.SortDescriptions.Add(new SortDescription("BrZiroRacuna", ListSortDirection.Descending));
            }
        }
    }
}
