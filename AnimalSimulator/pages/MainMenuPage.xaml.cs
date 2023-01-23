using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using MySql.Data.MySqlClient;
using System.Threading;

using AnimalSimulator.utils;

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
            logOut();

            Thread.Sleep(4000);

            Application.Current.Shutdown();
        }

        public static void logOut()
        {
            MySQL.mySqlCon.Open();

            MySqlCommand sqlcommand = MySQL.buildMySqlCommand("DELETE FROM sessions WHERE hwid='" + GameManager.user.hwid + "';");
            sqlcommand.ExecuteNonQuery();

            MessageBox.Show("Erfolgreich ausgeloggt! Programm schließt in 4 Sekunden!", "OK!", MessageBoxButton.OK, MessageBoxImage.Information);

            MySQL.mySqlCon.Close();
        }

        private void Button_Shops_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AnimalShopPage());
        }

        private void Button_FoodShop_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new FoodOverviewPage());
        }

        private void Button_Barn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new BarnShopPage());
        }

        private void Button_Editmenu_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Soon!");
        }
    }
}
