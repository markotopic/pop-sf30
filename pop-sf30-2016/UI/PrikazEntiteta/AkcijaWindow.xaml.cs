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

            view = CollectionViewSource.GetDefaultView(Projekat.Instace.Akcija);
            view.Filter = AkcijaFilter;
            dgAkcija.ItemsSource = view;
            dgAkcija.IsSynchronizedWithCurrentItem = true;

            dgAkcija.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

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

                foreach (var n in Projekat.Instace.Akcija)
                {
                    if (n.Id == izabrani.Id)
                    {
                        n.Obrisan = true;
                        view.Refresh();
                        break;
                    }
                }

                GenericSerializer.Serialize("akcije.xml", Projekat.Instace.Akcija);

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
    }
}
