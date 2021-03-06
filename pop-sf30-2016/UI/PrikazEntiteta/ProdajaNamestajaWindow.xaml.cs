﻿using pop_sf30_2016.UI.IzmenaEntiteta;
using SF_30_2016.Model;
using SF_30_2016.Modeli;
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
    /// Interaction logic for ProdajaNamestajaWindow.xaml
    /// </summary>
    public partial class ProdajaNamestajaWindow : Window
    {

        ICollectionView view;

        public ProdajaNamestajaWindow()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(Projekat.Instace.prodajanamestaja);

            dgProdajaNamestaja.ItemsSource = view;
            dgProdajaNamestaja.IsSynchronizedWithCurrentItem = true;

            dgProdajaNamestaja.ColumnWidth = new DataGridLength(1, DataGridLengthUnitType.Star);

            if (Projekat.Instace.Aktivan == false)
            {
                //btnAdd.Visibility = Visibility.Hidden;
                //btnUpdate.Visibility = Visibility.Hidden;
                //btnDelete.Visibility = Visibility.Hidden;
            }

        }

        private void dgProdajaNamestaja_AutoGeneratingColumn(object sender,
            DataGridAutoGeneratingColumnEventArgs e)
        {
            if ((string)e.Column.Header == "Id")
            {
                e.Cancel = true;
            }
            if ((string)e.Column.Header == "Obrisan")
            {
                e.Cancel = true;
            }
            if ((string)e.Column.Header == "NamestajZaProdaju")
            {
                e.Cancel = true;
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var selektovani = (ProdajaNamestaja)dgProdajaNamestaja.SelectedItem;

            var a = new RacunWindow(selektovani, RacunWindow.Operacija.IZMENA);
            a.Show();
        }

        private void Racun_Click(object sender, RoutedEventArgs e)
        {
            var noviRacun = new ProdajaNamestaja();

            var a = new RacunWindow(noviRacun, RacunWindow.Operacija.DODAVANJE);
            a.Show();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
