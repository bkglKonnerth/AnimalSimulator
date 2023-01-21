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
        public BarnShopPage()
        {
            InitializeComponent();
        }

        Barn barn;

        private void button_buy_barn1_Click(object sender, RoutedEventArgs e)
        {
            barn = new BasketBarn();
            if (!isToMuchBarnsEmpty())
            {
                saveBarn(barn);
            }
            else
            {
                openNotSuccessfullMessageBox();
            }
        }

        private void button_buy_barn2_Click(object sender, RoutedEventArgs e)
        {
            barn = new CageBarn();
            if (!isToMuchBarnsEmpty())
            {
                saveBarn(barn);
            }
            else
            {
                openNotSuccessfullMessageBox();
            }
        }

        private void button_buy_barn3_Click(object sender, RoutedEventArgs e)
        {
            barn = new NestBarn();
            if (!isToMuchBarnsEmpty())
            {
                saveBarn(barn);
            }
            else
            {
                openNotSuccessfullMessageBox();
            }
        }

        private void button_buy_barn4_Click(object sender, RoutedEventArgs e)
        {
                barn = new WaterBarn();
            if (!isToMuchBarnsEmpty())
            {
                saveBarn(barn);
            }
            else
            {
                openNotSuccessfullMessageBox();
            }
        }

        private Boolean isToMuchBarnsEmpty()
        {
            int difference = GameManager.barnContainer.Count - GameManager.animalContainer.Count;
            if (difference == 1 || difference == -1)
            {
                return true;
            }else
            {
                return false;
            }
        }

        private void saveBarn(Barn barn)
        {
            GameManager.barnContainer.Add(barn);
            saveBarnToDatabase(barn);
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

        private void openNotSuccessfullMessageBox()
        {
            MessageBox.Show("Du hast bereits ein leeres Gehege!\nKaufe dir zuerst ein Tier dafür!", "Nein!", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void button_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainMenuPage());
        }
    }
}
