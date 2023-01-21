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
            if (!isAnimalCountMaxed())
            {
                animal = new Hund();

                GameManager.animalContainer.Add(animal);
                openSuccesfullMessageBox();
            }
        }

        private void button_buy_animal2_Click(object sender, RoutedEventArgs e)
        {
            if (!isAnimalCountMaxed())
            {
                animal = new Katze();

                GameManager.animalContainer.Add(animal);
                openSuccesfullMessageBox();
            }
        }

        private void button_buy_animal3_Click(object sender, RoutedEventArgs e)
        {
            if (!isAnimalCountMaxed())
            {
                animal = new Maus();

                GameManager.animalContainer.Add(animal);
                openSuccesfullMessageBox();
            }
        }

        private void button_buy_animal4_Click(object sender, RoutedEventArgs e)
        {
            if (!isAnimalCountMaxed())
            {
                animal = new Goldfisch();

                GameManager.animalContainer.Add(animal);
                openSuccesfullMessageBox();
            }
        }

        private void button_buy_animal5_Click(object sender, RoutedEventArgs e)
        {
            if (!isAnimalCountMaxed())
            {
                animal = new Adler();

                GameManager.animalContainer.Add(animal);
                openSuccesfullMessageBox();
            }
        }

        private void button_buy_animal6_Click(object sender, RoutedEventArgs e)
        {
            if (!isAnimalCountMaxed())
            {
                animal = new Hai();

                GameManager.animalContainer.Add(animal);
                openSuccesfullMessageBox();
            }
        }

        private void button_buy_animal7_Click(object sender, RoutedEventArgs e)
        {
            if (!isAnimalCountMaxed())
            {
                animal = new Tintenfisch();

                GameManager.animalContainer.Add(animal);
                openSuccesfullMessageBox();
            }
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
        private void openSuccesfullMessageBox()
        {
            MessageBox.Show("Das Tier wurde erfolgreich gekauft! Du kannst noch " + (4 - GameManager.animalContainer.Count) + " Tier kaufen!", "OK!", MessageBoxButton.OK, MessageBoxImage.Information);
        }


        private void button_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainMenuPage());
        }

    }
}
