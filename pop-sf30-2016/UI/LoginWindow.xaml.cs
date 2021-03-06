﻿using SF_30_2016.Model;
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
using static SF_30_2016.Model.Korisnik;

namespace pop_sf30_2016.UI
{
    /// <summary>
    /// Interaction logic for LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {

        public LoginWindow()
        {
            InitializeComponent();
        }

        private void LogIn(object sender, RoutedEventArgs e)
        {

            foreach (var i in Projekat.Instace.korisnik)
            {

                if (i.KorisnickoIme == tbUsername.Text && i.Sifra == tbPassword.Password && i.Obrisan == false)
                {
                    if (i.TipKorisnikaa == TipKorisnika.Prodavac)
                    {
                        Projekat.Instace.Aktivan = false;
                        var main = new EntitetiWindow();
                        main.ShowDialog();
                        break;
                    }
                    else if (i.TipKorisnikaa == TipKorisnika.Administrator)
                    {
                        Projekat.Instace.Aktivan = true;
                        var mainn = new EntitetiWindow();
                        mainn.ShowDialog();
                        break;
                    }
                }
                else if (tbUsername.Text == "" || tbPassword.Password == "")
                {
                    MessageBox.Show("Morate popuniti sva polja");
                }
                

            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
