using pop_sf30_2016.UI.IzmenaEntiteta;
using SF_30_2016.Model;
using SF_30_2016.Modeli;
using SF_30_2016.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
    /// Interaction logic for KorisnikWindow.xaml
    /// </summary>
    public partial class KorisnikWindow : Window
    {

        ICollectionView view;

        public KorisnikWindow()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(Projekat.Instace.korisnik);
            view.Filter = Filter;
            dgKorisnik.ItemsSource = view;
            dgKorisnik.IsSynchronizedWithCurrentItem = true;

            dgKorisnik.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            cbSortiraj.Items.Add("Reset");
            cbSortiraj.Items.Add("Ime");
            cbSortiraj.Items.Add("Prezime");
            cbSortiraj.Items.Add("KorisnickoIme");

            cbObrisani.Items.Add("Show");
            cbObrisani.Items.Add("Hide");
        }

        private bool Filter(object obj)
        {
            return !((Korisnik)obj).Obrisan;
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            var noviKorisnik = new Korisnik
            {
                Ime = ""
            };
            var a = new IzmenaKorisnikaWindow(noviKorisnik, IzmenaKorisnikaWindow.Operacija.DODAVANJE);
            a.Show();
        }

        private void Izmeni_Click(object sender, RoutedEventArgs e)
        {
            var selektovani = (Korisnik)dgKorisnik.SelectedItem;

            var a = new IzmenaKorisnikaWindow(selektovani, IzmenaKorisnikaWindow.Operacija.IZMENA);
            a.Show();
        }

        private void Obrisi_Click(object sender, RoutedEventArgs e)
        {
            var izabrani = (Korisnik)dgKorisnik.SelectedItem;


            if (MessageBox.Show($"Da li ste sigurni da zelite da obrisete: { izabrani.Ime}?", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Korisnik.Delete(izabrani);
                view.Refresh();
            }
        }

        private void Izlaz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dgKorisnik_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
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
                dgKorisnik.Items.SortDescriptions.Clear();
            }
            else if (cbSortiraj.SelectedIndex == 1)
            {
                dgKorisnik.Items.SortDescriptions.Clear();
                dgKorisnik.Items.SortDescriptions.Add(new SortDescription("Ime", ListSortDirection.Descending));
            }
            else if (cbSortiraj.SelectedIndex == 2)
            {
                dgKorisnik.Items.SortDescriptions.Clear();
                dgKorisnik.Items.SortDescriptions.Add(new SortDescription("Prezime", ListSortDirection.Descending));
            }
            else if (cbSortiraj.SelectedIndex == 3)
            {
                dgKorisnik.Items.SortDescriptions.Clear();
                dgKorisnik.Items.SortDescriptions.Add(new SortDescription("KorisnickoIme", ListSortDirection.Descending));
            }
        }

        private void cbObrisani_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbObrisani.SelectedIndex == 0)
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                {
                    con.Open();


                    SqlCommand cmd = con.CreateCommand();
                    SqlDataAdapter da = new SqlDataAdapter();

                    cmd.CommandText = ("SELECT * FROM Korisnik");
                    DataSet table = new DataSet("Korisnik");

                    da.SelectCommand = cmd;
                    da.Fill(table);
                    dgKorisnik.ItemsSource = table.Tables[0].DefaultView;
                }
            }
            else if (cbObrisani.SelectedIndex == 1)
            {
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                {
                    con.Open();


                    SqlCommand cmd = con.CreateCommand();
                    SqlDataAdapter da = new SqlDataAdapter();

                    cmd.CommandText = ("SELECT * FROM Korisnik WHERE Obrisan=0");
                    DataSet table = new DataSet("Korisnik");

                    da.SelectCommand = cmd;
                    da.Fill(table);
                    dgKorisnik.ItemsSource = table.Tables[0].DefaultView;
                }
            }
        }
    }
}
