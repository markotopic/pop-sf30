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
    /// Interaction logic for DodatnaUslugaWindow.xaml
    /// </summary>
    public partial class DodatnaUslugaWindow : Window
    {
        public DodatnaUslugaWindow()
        {
            InitializeComponent();

            dgDodatnaUsluga.ItemsSource = Projekat.Instace.DodatnaUsluga;
            dgDodatnaUsluga.IsSynchronizedWithCurrentItem = true;
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            var novaDodatnaUsluga = new DodatnaUsluga
            {
                Naziv = ""
            };
            var a = new IzmenaDodatneUslugeWindow(novaDodatnaUsluga, IzmenaDodatneUslugeWindow.Operacija.DODAVANJE);
            a.Show();
        }

        private void Izmeni_Click(object sender, RoutedEventArgs e)
        {
            var selektovani = (DodatnaUsluga)dgDodatnaUsluga.SelectedItem;

            var a = new IzmenaDodatneUslugeWindow(selektovani, IzmenaDodatneUslugeWindow.Operacija.IZMENA);
            a.Show();
        }

        private void Obrisi_Click(object sender, RoutedEventArgs e)
        {
            var izabrani = (DodatnaUsluga)dgDodatnaUsluga.SelectedItem;


            if (MessageBox.Show($"Da li ste sigurni da zelite da obrisete: { izabrani.Naziv}?", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {

                foreach (var n in Projekat.Instace.DodatnaUsluga)
                {
                    if (n.Id == izabrani.Id)
                    {
                        n.Obrisan = true;
                        break;
                    }
                }

                GenericSerializer.Serialize("dodatneUsluge.xml", Projekat.Instace.DodatnaUsluga);

            }
        }

        private void Izlaz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
