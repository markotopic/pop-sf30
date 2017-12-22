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
    /// Interaction logic for IzmenaDodatneUslugeWindow.xaml
    /// </summary>
    public partial class IzmenaDodatneUslugeWindow : Window
    {
        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };

        private DodatnaUsluga dodatnaUsluga;
        private Operacija operacija;

        public IzmenaDodatneUslugeWindow(DodatnaUsluga dodatnaUsluga, Operacija operacija)
        {

            InitializeComponent();

            this.dodatnaUsluga = dodatnaUsluga;
            this.operacija = operacija;

            tbNaziv.DataContext = dodatnaUsluga;
            tbCenaUsluge.DataContext = dodatnaUsluga;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var lista = Projekat.Instace.dodatnausluga;

            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    DodatnaUsluga.Create(dodatnaUsluga);
                    this.Close();
                    break;
                case Operacija.IZMENA:
                    DodatnaUsluga.Update(dodatnaUsluga);
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
