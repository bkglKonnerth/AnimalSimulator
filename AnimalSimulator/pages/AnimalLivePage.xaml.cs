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
using System.Windows.Threading;

using AnimalSimulator.objects;
using AnimalSimulator.objects.AnimalObjects;
using AnimalSimulator.utils;


namespace AnimalSimulator.pages
{
    /// <summary>
    /// Interaktionslogik für AnimalOnePage.xaml
    /// </summary>
    public partial class AnimalLivePage : Page
    {

        DispatcherTimer timer = new DispatcherTimer();
        Animal animal = new AnimalObject();
        Random random = new Random();

        public AnimalLivePage(int id)
        {
            InitializeComponent();
            animal = GameManager.animalContainer[id];
            Image.Source = animal.getAnimalPic();
            loadAnimalData();


            if (!animal.dead)
            {
                timer.Interval = TimeSpan.FromMilliseconds(500);
                timer.Tick += loadAnimalData;
                timer.Start();
            }

        }

        private void button_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AnimalPage());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            if (animal.foodLevel != 100)
            {
                animal.removeFeed(5);

            }

            if (animal.foodLevel == 100)
            {
                animal.straveTimes = 0;
                animal.straving = false;
            }

        }
        private void loadAnimalData(object sender, EventArgs e)
        {
            checkStats();

            progressbar_food.Value = animal.foodLevel;
            progressbar_love.Value = animal.loveLevel;
            progressbar_health.Value = animal.healthLevel;

            progress_food.Content = animal.foodLevel + "%";
            progress_love.Content = animal.loveLevel + "%";
            progress_health.Content = animal.healthLevel + "%";
        }
        private void loadAnimalData()
        {
            loadAnimalData(null, null);
        }

        private void checkStats()
        {
            if(animal.foodLevel <= 0)
            {
                animal.removeHeal(10);
            }

            if(animal.foodLevel <= 60)
            {
                animal.removeLove(5);
            }

            if(animal.healthLevel <= 0)
            {
                animal.dead = true;
            }

        }

    }
}
