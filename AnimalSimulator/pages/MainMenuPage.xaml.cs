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
using MySql.Data.MySqlClient;
using System.Windows.Shapes;
using System.Threading;

using AnimalSimulator.utils;
using AnimalSimulator.pages;

namespace AnimalSimulator.pages
{
    /// <summary>
    /// Interaktionslogik für MainMenuPage.xaml
    /// </summary>
    public partial class MainMenuPage : Page
    {
        public MainMenuPage()
        {
            InitializeComponent();

        }
        private void Button_Animals_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new pages.AnimalPage());
        }

        private void Button_logout_Click(object sender, RoutedEventArgs e)
        {
            MySQL.mySqlCon.Open();

            MySqlCommand sqlcommand = MySQL.buildMySqlCommand("DELETE FROM sessions WHERE hwid='" + GameManager.user.hwid + "';");
            sqlcommand.ExecuteNonQuery();

            MessageBox.Show("Erfolgreich ausgeloggt! Programm schließt in 4 Sekunden!", "OK!", MessageBoxButton.OK, MessageBoxImage.Information);

            MySQL.mySqlCon.Close();

            Thread.Sleep(4000);

            Application.Current.Shutdown();
        }

        private void Button_Shops_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AnimalShopPage());
        }
    }
}
