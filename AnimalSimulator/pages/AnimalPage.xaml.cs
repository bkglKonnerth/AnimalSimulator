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

using AnimalSimulator.utils;
using AnimalSimulator.objects;
using AnimalSimulator.objects.AnimalObjects;
using AnimalSimulator.pages;

namespace AnimalSimulator.pages
{
    /// <summary>
    /// Interaktionslogik für AnimalPage.xaml
    /// </summary>
    /// 

    public partial class AnimalPage : Page
    {
        DispatcherTimer timer = new DispatcherTimer();

        public AnimalPage()
        {
            InitializeComponent();
            loadAnimalDatas();


            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += loadAnimalDatas;
            timer.Start();

        }

        private void button_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new MainMenuPage());
;        }

        private void button_visit_animal1_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AnimalLivePage(0));
        }
        private void button_visit_animal2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AnimalLivePage(1));
        }

        private void button_visit_animal3_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AnimalLivePage(2));
        }

        private void button_visit_animal4_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AnimalLivePage(3));
        }

        private void loadAnimalDatas(object sender, EventArgs e)
        {
            List<Animal> animalContainer = GameManager.animalContainer;

            Animal targetAnimal;

            for (int i = 0; i < animalContainer.Count; i++)
            {
                targetAnimal = animalContainer[i];
                checkStats(targetAnimal);

                BitmapImage animalPic = new BitmapImage(new Uri("pack://application:,,,/pics/" + targetAnimal.type + "icon.png"));

                String name = Convert.ToString(targetAnimal.type);

                if (targetAnimal.dead)
                {
                    name += "(Dead :C)";
                }


                switch (i)
                {
                    case 0:
                        image_animal1.Source = animalPic;
                        label_Name_animal1.Name = name;
                        progressbar_food_animal1.Value = targetAnimal.foodLevel;
                        progressbar_love_animal1.Value = targetAnimal.loveLevel;
                        progressbar_health_animal1.Value = targetAnimal.healthLevel;

                        progress_food_animal1.Content = targetAnimal.foodLevel + "%";
                        progress_love_animal1.Content = targetAnimal.loveLevel + "%";
                        progress_health_animal1.Content = targetAnimal.healthLevel + "%";

                        break;
                    case 1:
                        image_animal2.Source = animalPic;
                        label_Name_animal2.Name = name;
                        progressbar_food_animal2.Value = targetAnimal.foodLevel;
                        progressbar_love_animal2.Value = targetAnimal.loveLevel;
                        progressbar_health_animal2.Value = targetAnimal.healthLevel;

                        progress_food_animal2.Content = targetAnimal.foodLevel + "%";
                        progress_love_animal2.Content = targetAnimal.loveLevel + "%";
                        progress_health_animal2.Content = targetAnimal.healthLevel + "%";
                        break;
                    case 2:
                        image_animal3.Source = animalPic;
                        label_Name_animal3.Name = name;
                        progressbar_food_animal3.Value = targetAnimal.foodLevel;
                        progressbar_love_animal3.Value = targetAnimal.loveLevel;
                        progressbar_health_anima3.Value = targetAnimal.healthLevel;

                        progress_food_animal3.Content = targetAnimal.foodLevel + "%";
                        progress_love_animal3.Content = targetAnimal.loveLevel + "%";
                        progress_health_animal3.Content = targetAnimal.healthLevel + "%";
                        break;
                    case 3:
                        image_animal4.Source = animalPic;
                        label_Name_animal4.Name = name;
                        progressbar_food_animal4.Value = targetAnimal.foodLevel;
                        progressbar_love_animal4.Value = targetAnimal.loveLevel;
                        progressbar_health_animal4.Value = targetAnimal.healthLevel;

                        progress_food_animal4.Content = targetAnimal.foodLevel + "%";
                        progress_love_animal4.Content = targetAnimal.loveLevel + "%";
                        progress_health_animal4.Content = targetAnimal.healthLevel + "%";
                        break;
                }

            }

        }

        private void loadAnimalDatas()
        {
            loadAnimalDatas(null, null);
        }
        private void checkStats(Animal animal)
        {
            if (animal.foodLevel <= 0)
            {
                animal.healthLevel -= 10;
            }

            if (animal.foodLevel <= 60)
            {
                animal.loveLevel -= 5;
            }

            if (animal.healthLevel <= 0)
            {
                animal.dead = true;
            }

        }

    }
}
