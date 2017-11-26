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
    /// Interaction logic for KorisnikWindow.xaml
    /// </summary>
    public partial class KorisnikWindow : Window
    {
        public KorisnikWindow()
        {
            InitializeComponent();

            dgKorisnik.ItemsSource = Projekat.Instace.Korisnik;
            dgKorisnik.IsSynchronizedWithCurrentItem = true;
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

                foreach (var n in Projekat.Instace.Korisnik)
                {
                    if (n.Id == izabrani.Id)
                    {
                        n.Obrisan = true;
                        break;
                    }
                }

                GenericSerializer.Serialize("korisnici.xml", Projekat.Instace.Korisnik);

            }
        }

        private void Izlaz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
