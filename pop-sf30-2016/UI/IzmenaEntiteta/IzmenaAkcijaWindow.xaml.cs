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
    /// Interaction logic for IzmenaAkcijaWindow.xaml
    /// </summary>
    public partial class IzmenaAkcijaWindow : Window
    {
        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };

        private Akcija akcija;
        private Operacija operacija;

        public IzmenaAkcijaWindow(Akcija akcija, Operacija operacija)
        {

            InitializeComponent();

            this.akcija = akcija;
            this.operacija = operacija;

            tbDatumPocetka.DataContext = akcija;
            tbDatumZavrsetka.DataContext = akcija;
            tbPopust.DataContext = akcija;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var lista = Projekat.Instace.Akcija;

            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    akcija.Id = lista.Count + 1;
                    lista.Add(akcija);
                    this.Close();
                    break;
                case Operacija.IZMENA:
                    foreach (var n in lista)
                    {
                        if (n.Id == akcija.Id)
                        {
                            n.DatumPocetka = akcija.DatumPocetka;
                            n.DatumZavrsetka = akcija.DatumZavrsetka;
                            n.Popust = akcija.Popust;
                            this.Close();
                            break;
                        }
                    }
                    break;
                default:
                    break;
            }
            GenericSerializer.Serialize("akcije.xml", lista);
        }

        private void Izlaz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
