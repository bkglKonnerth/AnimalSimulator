using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Threading;

using AnimalSimulator.utils;
using AnimalSimulator.objects;

namespace AnimalSimulator.pages
{
    /// <summary>
    /// Interaktionslogik für AnimalPage.xaml
    /// </summary>
    /// 

    public partial class AnimalPage : Page
    {
        DispatcherTimer timer = new DispatcherTimer();
        int emptyPlace;
        public AnimalPage()
        {
            InitializeComponent();

            button_page_back.Visibility = Visibility.Hidden;

            isPlaceEmpty();
            loadAnimalDatas();
            updateSideButtons();


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
            int calc = (GameManager.page * 4);

            if (GameManager.animalContainer.Count > calc - 4)
            {
                NavigationService.Navigate(new AnimalLivePage(calc - 4));
            }
            else if (emptyPlace == calc - 4)
            {
                MessageBoxResult result = MessageBox.Show("Möchtest du das Gehge wirklich verkaufen?", "Sicher?", MessageBoxButton.YesNo, MessageBoxImage.Asterisk);
                checkBarnDeleteAnswer(result);
            }
            else
            {
                MessageBox.Show("Nein!", "Kein Tier wohnt hier!");
            }
        }
        private void button_visit_animal2_Click(object sender, RoutedEventArgs e)
        {
            int calc = (GameManager.page * 4);

            if (GameManager.animalContainer.Count >= calc - 2)
            {
                NavigationService.Navigate(new AnimalLivePage(calc - 3));
            }
            else if (emptyPlace == calc - 2)
            {
                MessageBoxResult result = MessageBox.Show("Möchtest du das Gehge wirklich verkaufen?", "Sicher?", MessageBoxButton.YesNo, MessageBoxImage.Asterisk);
                checkBarnDeleteAnswer(result);
            }
            else
            {
                MessageBox.Show("Nein!", "Kein Tier wohnt hier!");
            }
        }

        private void button_visit_animal3_Click(object sender, RoutedEventArgs e)
        {
            int calc = (GameManager.page * 4);

            if (GameManager.animalContainer.Count >= calc - 1)
            {
                NavigationService.Navigate(new AnimalLivePage(calc - 2));
            }
            else if (emptyPlace == calc - 1)
            {
                MessageBoxResult result = MessageBox.Show("Möchtest du das Gehge wirklich verkaufen?", "Sicher?", MessageBoxButton.YesNo, MessageBoxImage.Asterisk);
                checkBarnDeleteAnswer(result);
            }
            else
            {
                MessageBox.Show("Nein!", "Kein Tier wohnt hier!");
            }
        }

        private void button_visit_animal4_Click(object sender, RoutedEventArgs e)
        {
            int calc = (GameManager.page * 4);

            if (GameManager.animalContainer.Count >= calc)
            {
                NavigationService.Navigate(new AnimalLivePage(calc - 1));
            }else if (emptyPlace == calc)
            {
                MessageBoxResult result = MessageBox.Show("Möchtest du das Gehge wirklich verkaufen?", "Sicher?", MessageBoxButton.YesNo, MessageBoxImage.Asterisk);
                checkBarnDeleteAnswer(result);
            }
            else
            {
                MessageBox.Show("Nein!", "Kein Tier wohnt hier!");
            }
        }

        private void checkBarnDeleteAnswer(MessageBoxResult result)
        {
            if(result == MessageBoxResult.Yes)
            {
                GameManager.barnContainer.RemoveAt(GameManager.barnContainer.Count - 1);
                GameManager.user.cash += 100;

                NavigationService.Navigate(new AnimalPage());
            }
        }

        private void isPlaceEmpty()
        {
            int difference = GameManager.barnContainer.Count - GameManager.animalContainer.Count;
            Barn barn;

            if (difference == 1)
            {
                barn = GameManager.barnContainer[GameManager.barnContainer.Count - 1];
                BitmapImage animalPic = barn.getBarnPic();
                int count = GameManager.animalContainer.Count;

                while (count > 4) 
                {
                    count = GameManager.animalContainer.Count - 4;
                }

                switch (count)
                {
                    case 0:
                        image_animal1.Source = animalPic;
                        emptyPlace = count + 1;
                        break;
                    case 1:
                        image_animal2.Source = animalPic;
                        emptyPlace = count + 1;
                        break;
                    case 2:
                        image_animal3.Source = animalPic;
                        emptyPlace = count + 1;
                        break;
                    case 3:
                        image_animal4.Source = animalPic;
                        emptyPlace = count + 1;
                        break;
                }

            }
        }

        private void loadAnimalDatas(object sender, EventArgs e)
        {
            int page = GameManager.page;
                                         
            List<Animal> animalContainer = GameManager.animalContainer;
            Animal targetAnimal;

            for (int usedContent = ((page - 1) * 4); usedContent < (page*4); usedContent++)
            {
                // 0-3
                if (usedContent <= (animalContainer.Count - 1))
                {

                    targetAnimal = animalContainer[usedContent];
                    checkStats(targetAnimal);

                    BitmapImage animalPic = new BitmapImage(new Uri("pack://application:,,,/pics/" + targetAnimal.type + "icon.png"));

                    String name = Convert.ToString(targetAnimal.type);

                    switch (usedContent % 4)
                    {

                        case 0:
                            image_animal1.Source = animalPic;
                            label_Name_animal1.Name = Convert.ToString(targetAnimal.type);
                            progressbar_food_animal1.Value = targetAnimal.foodLevel;
                            progressbar_love_animal1.Value = targetAnimal.loveLevel;
                            progressbar_health_animal1.Value = targetAnimal.healthLevel;

                            progress_food_animal1.Content = targetAnimal.foodLevel + "%";
                            progress_love_animal1.Content = targetAnimal.loveLevel + "%";
                            progress_health_animal1.Content = targetAnimal.healthLevel + "%";

                            break;
                        case 1:
                            image_animal2.Source = animalPic;
                            label_Name_animal2.Name = Convert.ToString(targetAnimal.type);
                            progressbar_food_animal2.Value = targetAnimal.foodLevel;
                            progressbar_love_animal2.Value = targetAnimal.loveLevel;
                            progressbar_health_animal2.Value = targetAnimal.healthLevel;

                            progress_food_animal2.Content = targetAnimal.foodLevel + "%";
                            progress_love_animal2.Content = targetAnimal.loveLevel + "%";
                            progress_health_animal2.Content = targetAnimal.healthLevel + "%";
                            break;
                        case 2:
                            image_animal3.Source = animalPic;
                            label_Name_animal3.Name = Convert.ToString(targetAnimal.type);
                            progressbar_food_animal3.Value = targetAnimal.foodLevel;
                            progressbar_love_animal3.Value = targetAnimal.loveLevel;
                            progressbar_health_anima3.Value = targetAnimal.healthLevel;

                            progress_food_animal3.Content = targetAnimal.foodLevel + "%";
                            progress_love_animal3.Content = targetAnimal.loveLevel + "%";
                            progress_health_animal3.Content = targetAnimal.healthLevel + "%";
                            break;
                        case 3:
                            image_animal4.Source = animalPic;
                            label_Name_animal4.Name = Convert.ToString(targetAnimal.type);
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

        }

        private void loadAnimalDatas()
        {
            lable_page.Content = "Page: " + GameManager.page;
            loadAnimalDatas(null, null);
        }
        private void checkStats(Animal animal)
        {
            if (animal.foodLevel <= 0)
            {
                if (animal.healthLevel >= 1.5)
                {
                    animal.straving = false;
                    animal.straveTimes = 0;

                    animal.healthLevel -= 1.5;
                }
                else
                {
                    animal.healthLevel = 0;
                }
            }

            if (animal.foodLevel <= 60)
            {
                if (animal.loveLevel >= 1.5)
                {
                    animal.loveLevel -= 1.5;

                }
                else
                {
                    animal.loveLevel = 0;
                }
            }

            if (animal.healthLevel <= 0)
            {
                animal.dead = true;
            }

        }
        private void updateSideButtons()
        {
            int currentPage = GameManager.page;
            double maxSides = GameManager.animalContainer.Count / 4;
            maxSides = Math.Ceiling(maxSides) + 1;


            if(currentPage < 2)
            {
                button_page_next.Visibility = Visibility.Hidden;
            }
            else
            {
                button_page_back.Visibility = Visibility.Visible;
            }

            if(currentPage < maxSides)
            {
                button_page_next.Visibility = Visibility.Visible;
            }

            if(currentPage == maxSides)
            {
                button_page_next.Visibility = Visibility.Hidden;
            }
        }

        private void button_page_back_Click(object sender, RoutedEventArgs e)
        {
            updateSideButtons();
            GameManager.page--;
            NavigationService.Navigate(new AnimalPage());
        }

        private void button_page_next_Click(object sender, RoutedEventArgs e)
        {
            updateSideButtons();
            GameManager.page++;
            NavigationService.Navigate(new AnimalPage());
        }
    }
}
