using SF_30_2016.Model;
using SF_30_2016.Modeli;
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
    /// Interaction logic for IzmenaSalonaWindow.xaml
    /// </summary>
    public partial class IzmenaSalonaWindow : Window
    {
        private Salon salon;
        private Operacija operacija;

        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };

        public IzmenaSalonaWindow(Salon salon, Operacija operacija)
        {
            InitializeComponent();

            this.salon = salon;
            this.operacija = operacija;

            tbNazi.DataContext = salon;
            tbTelefon.DataContext = salon;
            tbEmail.DataContext = salon;
            tbAdresaSajta.DataContext = salon;
            tbPIB.DataContext = salon;
            tbMaticniBroj.DataContext = salon;
            tbBrZiroRacuna.DataContext = salon;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            var lista = Projekat.Instace.salon;

            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    Salon.Create(salon);
                    this.Close();
                    break;
                case Operacija.IZMENA:
                    Salon.Update(salon);
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
