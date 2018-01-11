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
using static SF_30_2016.Model.Korisnik;

namespace pop_sf30_2016.UI.IzmenaEntiteta
{
    /// <summary>
    /// Interaction logic for IzmenaKorisnikaWindow.xaml
    /// </summary>
    public partial class IzmenaKorisnikaWindow : Window
    {
        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };

        private Korisnik korisnik;
        private Operacija operacija;

        public IzmenaKorisnikaWindow(Korisnik korisnik, Operacija operacija)
        {
            InitializeComponent();

            this.korisnik = korisnik;
            this.operacija = operacija;

            cbTipKorisnika.ItemsSource = Enum.GetValues(typeof(TipKorisnika)).Cast<TipKorisnika>();

            tbIme.DataContext = korisnik;
            tbPrezime.DataContext = korisnik;
            tbKorisnickoIme.DataContext = korisnik;
            tbSifra.DataContext = korisnik;

            cbTipKorisnika.DataContext = korisnik;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var lista = Projekat.Instace.korisnik;

            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    Korisnik.Create(korisnik);
                    this.Close();
                    break;
                case Operacija.IZMENA:
                    Korisnik.Update(korisnik);
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
