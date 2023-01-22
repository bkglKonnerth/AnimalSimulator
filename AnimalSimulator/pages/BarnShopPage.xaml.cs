using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using MySql.Data.MySqlClient;

using AnimalSimulator.utils;
using AnimalSimulator.objects;
using AnimalSimulator.objects.BarnObjects;

namespace AnimalSimulator.pages
{
    /// <summary>
    /// Interaktionslogik für BarnShopPage.xaml
    /// </summary>
    public partial class BarnShopPage : Page
    {
        User user = GameManager.user;
        public BarnShopPage()
        {
            InitializeComponent();
            updateCashLabel();
        }

        Barn barn;

        private void button_buy_barn1_Click(object sender, RoutedEventArgs e)
        {
            barn = new BasketBarn();
            contorlBarnbuy(barn);
        }

        private void button_buy_barn2_Click(object sender, RoutedEventArgs e)
        {
            barn = new CageBarn();
            contorlBarnbuy(barn);
        }

        private void button_buy_barn3_Click(object sender, RoutedEventArgs e)
        {
            barn = new NestBarn();
            contorlBarnbuy(barn);
        }

        private void button_buy_barn4_Click(object sender, RoutedEventArgs e)
        {
            barn = new WaterBarn();
            contorlBarnbuy(barn);
        }

        private void contorlBarnbuy(Barn barn)
        {
            if (!isToMuchBarnsEmpty())
            {
                if (hasEnoghCash(100))
                {
                    user.cash -= 100;
                    saveBarn(barn);
                }
                else
                {
                    openNotSuccessfullMessageBox("DU hast nicht genug Geld!");
                }
            }
            else
            {
                openNotSuccessfullMessageBox("Du hast bereits ein leeres Gehege!\nKaufe dir zuerst ein Tier dafür!");
            }
        }

        private Boolean hasEnoghCash(int amount)
        {
            return (user.cash >= amount);
        }

        private Boolean isToMuchBarnsEmpty()
        { 
            int difference = GameManager.barnContainer.Count - GameManager.animalContainer.Count;
            return difference == 1 || difference == -1;
        }

        private void updateCashLabel()
        {
            lable_cash.Content = "Geld: " + user.cash;
        }

        private void saveBarn(Barn barn)
        {
            GameManager.barnContainer.Add(barn);
            saveBarnToDatabase(barn);
            updateCashLabel();
            openSuccessfullMessageBox();
        }

        private void saveBarnToDatabase(Barn barn)
        {
            MySQL.mySqlCon.Open();

            String barnType = Convert.ToString(barn.type);
            MySqlCommand command = MySQL.buildMySqlCommand("INSERT INTO barns SET barntype='" + barnType + "', ownerID=" + GameManager.user.userID + ";");
            command.ExecuteNonQuery();

            MySQL.mySqlCon.Close();

        }

        private void openSuccessfullMessageBox()
        {
            MessageBox.Show("Dieses Gehege wurde erfolgreich gekauft :)\nDu hast jetzt " + GameManager.barnContainer.Count + " Gehege", "OK!", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void openNotSuccessfullMessageBox(String message)
        {
            MessageBox.Show(message, "Nein!", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void button_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainMenuPage());
        }
    }
}
