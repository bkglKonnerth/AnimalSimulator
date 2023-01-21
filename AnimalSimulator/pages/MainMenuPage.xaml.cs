﻿using System.Windows;
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

        private void Button_FoodShop_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Soon!");
        }

        private void Button_Barn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new BarnShopPage());
        }
    }
}
