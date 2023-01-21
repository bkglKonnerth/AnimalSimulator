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
        Animal animal;

        public AnimalShopPage()
        {
            InitializeComponent();
        }

        private void button_buy_animal1_Click(object sender, RoutedEventArgs e)
        {
                animal = new Hund();

            if (gehegeExists(animal))
            {
                saveAnimal(animal);
            }
        }

        private void button_buy_animal2_Click(object sender, RoutedEventArgs e)
        {
                animal = new Katze();

            if (gehegeExists(animal))
            {
                saveAnimal(animal);
            }
        }

        private void button_buy_animal3_Click(object sender, RoutedEventArgs e)
        {
                animal = new Maus();

            if (gehegeExists(animal))
            {
                saveAnimal(animal);
            }
        }

        private void button_buy_animal4_Click(object sender, RoutedEventArgs e)
        {
                animal = new Goldfisch();

            if (gehegeExists(animal))
            {
                saveAnimal(animal);
            }
        }

        private void button_buy_animal5_Click(object sender, RoutedEventArgs e)
        {
                animal = new Adler();

            if (gehegeExists(animal))
            {
                saveAnimal(animal);
            }
        }

        private void button_buy_animal6_Click(object sender, RoutedEventArgs e)
        {
                animal = new Hai();

            if (gehegeExists(animal))
            {
                saveAnimal(animal);
            }
        }

        private void button_buy_animal7_Click(object sender, RoutedEventArgs e)
        {
            animal = new Tintenfisch();

            if (gehegeExists(animal))
            {
                saveAnimal(animal);
            }
        }

        private Boolean gehegeExists(Animal animal)
        {
            //If gehege existiert 
            //If gehege type = richtig
            //

            if(GameManager.barnContainer.Count == 0)
            {
                return false;

            } 
            else if(GameManager.barnContainer.Count > GameManager.animalContainer.Count)
            {
                String type;
             
                String barnType = Convert.ToString(GameManager.barnContainer[GameManager.animalContainer.Count].type);
                String animalType = Convert.ToString(animal.type);

                type = barnType + animalType;

                switch (type)
                {
                    case "BasketHund":
                        return true;
                    case "BasketKatze":
                        return true;
                    case "CageMaus":
                        return true;
                    case "NestAdler":
                        return true;
                    case "WaterGoldfisch":
                        return true;
                    case "WaterHai":
                        return true;
                    case "WaterTintenfisch":
                        return true;
                    default:
                        MessageBox.Show("Du musst vorher noch ein Gehege mit dem richtigen typen kaufen!", "Nein!", MessageBoxButton.OK, MessageBoxImage.Information);
                        return false;
                }
            }
            else
            {
                MessageBox.Show("Du musst vorher noch ein Gehege mit dem richtigen typen kaufen!", "Nein!", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }

        }

        private void saveAnimal(Animal animal)
        {
            saveAnimalToDatabase(animal);
            GameManager.animalContainer.Add(animal);
            openSuccesfullMessageBox();
        }

        private void saveAnimalToDatabase(Animal animal)
        {
            MySQL.mySqlCon.Open();

            String animalType = Convert.ToString(animal.type);
            MySqlCommand command = MySQL.buildMySqlCommand("INSERT INTO animals SET animaltype='" + animalType + "', foodlevel=100, healthlevel=100, lovelevel=100, ownerID=" + GameManager.user.userID + ";");
            command.ExecuteNonQuery();

            MySQL.mySqlCon.Close();

        }
        private void openSuccesfullMessageBox()
        {
            MessageBox.Show("Das Tier wurde erfolgreich gekauft!", "OK!", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void button_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainMenuPage());
        }

    }
}
