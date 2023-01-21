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
using MySql.Data.MySqlClient;

using AnimalSimulator.utils;
using AnimalSimulator.objects.AnimalObjects;
using AnimalSimulator.objects;
using AnimalSimulator.enums;

namespace AnimalSimulator.pages
{
    /// <summary>
    /// Interaktionslogik für AnimalShopPage.xaml
    /// </summary>
    public partial class AnimalShopPage : Page
    {
        AnimalObject animalObject;

        public AnimalShopPage()
        {
            InitializeComponent();
        }

        private void button_buy_animal1_Click(object sender, RoutedEventArgs e)
        {
            buyAnimal(AnimalType.Hund, "Hund, wau wau");
        }

        private void button_buy_animal2_Click(object sender, RoutedEventArgs e)
        {
            buyAnimal(AnimalType.Katze, "Katze, wau wau");
        }

        private void button_buy_animal3_Click(object sender, RoutedEventArgs e)
        {
            buyAnimal(AnimalType.Maus, "Maus, wau wau");
        }

        private void button_buy_animal4_Click(object sender, RoutedEventArgs e)
        {
            buyAnimal(AnimalType.Goldfisch, "Goldfisch, wau wau");
        }

        private void button_buy_animal5_Click(object sender, RoutedEventArgs e)
        {
            buyAnimal(AnimalType.Adler, "Adler, wau wau");
        }

        private void button_buy_animal6_Click(object sender, RoutedEventArgs e)
        {
            buyAnimal(AnimalType.Hai, "Hai, wau wau");
        }

        private void button_buy_animal7_Click(object sender, RoutedEventArgs e)
        {
            buyAnimal(AnimalType.Tintenfisch, "Tintenfisch, wau wau");
        }

        private Boolean isAnimalCountMaxed()
        {
            if(GameManager.animalContainer.Count >= 4)
            {
                button_buy_animal1.IsEnabled = false;
                button_buy_animal2.IsEnabled = false;
                button_buy_animal3.IsEnabled = false;
                button_buy_animal4.IsEnabled = false;
                button_buy_animal5.IsEnabled = false;
                button_buy_animal6.IsEnabled = false;
                button_buy_animal7.IsEnabled = false;

                MessageBox.Show("Du kannst keine weiteren Tiere kaufen!");

                return true;
            }else
            {
                return false;
            } 
        }

        private void buyAnimal(AnimalType type, String name)
        {
            if (!isAnimalCountMaxed())
            {
                animalObject = new AnimalObject();
                animalObject.type = type;

                GameManager.animalContainer.Add(animalObject);
                saveAnimalToDatabase(type);
                openSuccesfullMessageBox();
            }
        }

        private void openSuccesfullMessageBox()
        {
            MessageBox.Show("Das Tier wurde erfolgreich gekauft! Du kannst noch " + (4 - GameManager.animalContainer.Count) + " Tier kaufen!", "OK!", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void saveAnimalToDatabase(AnimalType type)
        {
            MySQL.mySqlCon.Open();

            String animalType = Convert.ToString(type);
            MySqlCommand command =  MySQL.buildMySqlCommand("INSERT INTO animals SET animaltype='" + animalType + "', foodlevel=100, healthlevel=100, lovelevel=100, ownerID=" + GameManager.user.userID + ";");
            command.ExecuteNonQuery();

            MySQL.mySqlCon.Close();

        }

        private void button_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainMenuPage());
        }

    }
}
