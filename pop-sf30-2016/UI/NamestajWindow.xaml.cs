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

namespace pop_sf30_2016.UI
{
    /// <summary>
    /// Interaction logic for NamestajWindow.xaml
    /// </summary>
    public partial class NamestajWindow : Window
    {
        private Namestaj namestaj;
        private Operacija operacija;

        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };

        public NamestajWindow(Namestaj namestaj, Operacija operacija)
        {
            InitializeComponent();
            InicijalizujVrednosti(namestaj, operacija);
        }

        private void InicijalizujVrednosti(Namestaj namestaj, Operacija operacija)
        {
            this.namestaj = namestaj;
            this.operacija = operacija;

            tbNazi.Text = namestaj.Naziv;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            List<Namestaj> postojeciNamestaj = Projekat.Instace.Naamestaj;

            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    var noviNamestaj = new Namestaj()
                    {
                        Id = postojeciNamestaj.Count + 1,
                        Naziv = tbNazi.Text,
                        Sifra = tbSifra.Text,
                        JedinicnaCena = Double.Parse(tbJedinicnaCena.Text),
                        KolicinaUMagacinu = int.Parse(tbKolicinaUMagacinu.Text)
                        
                    };
                    postojeciNamestaj.Add(noviNamestaj);
                    break;

                case Operacija.IZMENA:
                    foreach (var n in Projekat.Instace.Naamestaj)
                    {
                        if (n.Id == namestaj.Id)
                        {
                            n.Naziv = tbNazi.Text;
                            n.Sifra = tbSifra.Text;
                            n.JedinicnaCena = Double.Parse(tbJedinicnaCena.Text);
                            n.KolicinaUMagacinu = int.Parse(tbKolicinaUMagacinu.Text);
                            break;
                        }
                    }
                    break;
                default:
                    break;
            }
            Projekat.Instace.Naamestaj = postojeciNamestaj;
        }
    }
}
