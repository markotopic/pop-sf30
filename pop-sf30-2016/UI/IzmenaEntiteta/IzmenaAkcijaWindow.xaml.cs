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


            dpDatumPocetka.DataContext = akcija;
            dpDatumZavrsetka.DataContext = akcija;
            tbPopust.DataContext = akcija;

            TimeSpan razlika = new TimeSpan(14, 0, 0, 0);

            DateTime datumPocetka = DateTime.Now;
            DateTime datumZavrsetka = datumPocetka.Add(razlika);

            akcija.DatumPocetka = datumPocetka;
            akcija.DatumZavrsetka = datumZavrsetka;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var lista = Projekat.Instace.akcija;

            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    Akcija.Create(akcija);
                    this.Close();
                    break;
                case Operacija.IZMENA:
                    Akcija.Update(akcija);
                    this.Close();
                    break;
            }
        }

        private void Izlaz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

    }
}
