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

            foreach (var i in Projekat.Instace.Korisnici)
            {
                if (i.KorisnickoIme == tbUsername.Text && i.Sifra == tbPassword.Text)
                {
                    var main = new MainWindow();
                    main.Show();
                    break;
                }
                else
                {
                    break;
                }
            }

        }
    }
}
