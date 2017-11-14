﻿using pop_sf30_2016.UI;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pop_sf30_2016
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();

            OsveziPrikaz();

        }

        public bool namestajObirsan { get; set; }

        private void OsveziPrikaz()
        {
            listBoxNamestaj.Items.Clear();

            foreach (var namestaj in Projekat.Instace.Naamestaj)
            {
                if (namestajObirsan == false )
                {
                    listBoxNamestaj.Items.Add(namestaj);
                }
                
            }

            listBoxNamestaj.SelectedIndex = 0;
        }

        private void Izlaz_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void DodajNamestaj(object sender, RoutedEventArgs e)
        {
            var noviNamestaj = new Namestaj()
            {
                Naziv = ""
            };
            var namestajProzor = new NamestajWindow(noviNamestaj, NamestajWindow.Operacija.DODAVANJE);
            namestajProzor.Show();
        }

        private void IzmeniNamestaj(object sender, RoutedEventArgs e)
        {
            var selektovaniNamestaj = (Namestaj)listBoxNamestaj.SelectedItem;

            var namestajProzor = new NamestajWindow(selektovaniNamestaj, NamestajWindow.Operacija.IZMENA);
            namestajProzor.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var izabraniNamestaj = (Namestaj)listBoxNamestaj.SelectedItem;
            var staraListaNamestaj = Projekat.Instace.Naamestaj;

            if (MessageBox.Show($"Da li ste sigurni da zelite da obrisete: { izabraniNamestaj.Naziv}?", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Namestaj namestaj = null;

                foreach (var n in staraListaNamestaj)
                {
                    if (n.Id == izabraniNamestaj.Id)
                    {
                        namestaj = n;
                    }
                }
                
                namestaj.Obrisan = true;

                Projekat.Instace.Naamestaj = staraListaNamestaj;

                OsveziPrikaz();
            }
        }
    }
}
