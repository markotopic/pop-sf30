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

            cbTipKorisnika.ItemsSource = Projekat.Instace.TipKorisnika;

            tbIme.DataContext = korisnik;
            tbPrezime.DataContext = korisnik;
            tbKorisnickoIme.DataContext = korisnik;
            tbSifra.DataContext = korisnik;
            cbTipKorisnika.DataContext = korisnik;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var lista = Projekat.Instace.Korisnik;

            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    korisnik.Id = lista.Count + 1;
                    lista.Add(korisnik);
                    this.Close();
                    break;
                case Operacija.IZMENA:
                    foreach (var n in lista)
                    {
                        if (n.Id == korisnik.Id)
                        {
                            n.Ime = korisnik.Ime;
                            n.Prezime = korisnik.Prezime;
                            n.KorisnickoIme = korisnik.KorisnickoIme;
                            n.Sifra = korisnik.Sifra;
                            n.TipKorisnika = korisnik.TipKorisnika;
                            this.Close();
                            break;
                        }
                    }
                    break;
                default:
                    break;
            }
            GenericSerializer.Serialize("korisnici.xml", lista);
        }

        private void Izlaz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
