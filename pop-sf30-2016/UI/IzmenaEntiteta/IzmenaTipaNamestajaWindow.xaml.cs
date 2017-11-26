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
    /// Interaction logic for IzmenaTipaNamestajaWindow.xaml
    /// </summary>
    public partial class IzmenaTipaNamestajaWindow : Window
    {
        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };

        private TipNamestaja tipNamestaja;
        private Operacija operacija;

        public IzmenaTipaNamestajaWindow(TipNamestaja tipNamestaja, Operacija operacija)
        {
            InitializeComponent();

            this.tipNamestaja = tipNamestaja;
            this.operacija = operacija;

            tbNazi.DataContext = tipNamestaja;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var listaNamestaja = Projekat.Instace.tipnamestaja;

            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    tipNamestaja.Id = listaNamestaja.Count + 1;
                    listaNamestaja.Add(tipNamestaja);
                    this.Close();
                    break;
                case Operacija.IZMENA:
                    foreach (var n in listaNamestaja)
                    {
                        if (n.Id == tipNamestaja.Id)
                        {
                            n.Naziv = tipNamestaja.Naziv;
                            this.Close();
                            break;
                        }
                    }
                    break;
                default:
                    break;
            }
            GenericSerializer.Serialize("tipNamestaja.xml", listaNamestaja);
        }

        private void Izlaz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
