using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using System.Windows.Threading;

using AnimalSimulator.objects;
using AnimalSimulator.utils;

// 1. Automatisch speichern (in DB)
// 2. Gehege kaufen, bevor man Tier kaufen kann
// 3. Gehege wieder verkaufen können


// - Geld einführen => 
// - Hund: Füttern (50€), Streicheln (25€), Streicheln wenn unter Love unter 100% = -25€
// - Katze: Füttern (50€), Streicheln (25€), Streicheln wenn unter Love unter 100% = -25€
// - Maus: Füttern (50€), Streicheln (25€), Streicheln wenn unter Love unter 100% = -25€

// - Goldfisch: Füttern (100€), Streicheln (75€), Streicheln wenn unter Love unter 100% = -75€
// - Adler: Füttern (200€), Streicheln (120€), Streicheln wenn unter Love unter 100% = -120€
// - Hai: Füttern (350€), Streicheln (180€), Streicheln wenn unter Love unter 100% = -180€
// - Tintenfisch: Füttern (450€), Streicheln (250€), Streicheln wenn unter Love unter 100% = -250€

// - Essensshop, wo man spezial essen kaufen kann, z.B. Tier wiederbeleben oder Leben hinzuzufügen =>
// - Normales Futter  - 25€
// - Biggi (Gibt wieder Leben) - 150€
// - OP Goldapfel (Wiederbelebung) - 500€

// - Tiershop preise setzten =>
// - Hund: 800€
// - Katze: 800€
// - Maus: 800€

// - Goldfisch: 2000€
// - Adler: 6000€
// - Hai: 9000€
// - Tintenfisch: 14000€


namespace AnimalSimulator.pages
{
    /// <summary>
    /// Interaktionslogik für AnimalOnePage.xaml
    /// </summary>
    public partial class AnimalLivePage : Page
    {

        DispatcherTimer timer = new DispatcherTimer();
        Animal animal;

        User user = GameManager.user;

        public AnimalLivePage(int id)
        {
            InitializeComponent();
            animal = GameManager.animalContainer[id];
            Image.Source = animal.getAnimalPic();

            loadAnimalData();
            updateCashLabel();

            combobox_food.Items.Add("Normales Futter | Kosten: 10€");
            combobox_food.Items.Add("Biggi | Kosten: 400€");
            combobox_food.Items.Add("OP Goldapfel | Kosten: 1000€");

            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += loadAnimalData;
            timer.Start();

        }

        private void button_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AnimalPage());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            User initUser = GameManager.user;

            if (!animal.dead)
            {
                if (animal.foodLevel <= 100)
                {
                    switch (combobox_food.Text)
                    {
                        case "Normales Futter | Kosten: 10€":
                            if (hasEnoghCash(10))
                            {
                                if (animal.foodLevel > 95)
                                {
                                    double fill = 100 - animal.foodLevel;
                                    animal.foodLevel += fill;

                                    user.cash += animal.feedCash;
                                    updateCashLabel();
                                }
                                else
                                {
                                    animal.foodLevel += 5;
                                }

                                initUser.cash -= 10;
                            }
                            else
                            {
                                sendNoCashBox();
                            }

                            break;

                        case "Biggi | Kosten: 400€":
                            if (hasEnoghCash(400))
                            {
                                animal.foodLevel += 50;
                                animal.healthLevel = 100;
                                initUser.cash -= 400;

                                user.cash += animal.feedCash;
                                updateCashLabel();
                            }
                            else
                            {
                                sendNoCashBox();
                            }

                            break;

                        case "OP Goldapfel | Kosten: 1000€":
                            if (hasEnoghCash(1000))
                            { 
                                animal.foodLevel = 100;
                                animal.healthLevel = 100;
                                animal.loveLevel = 0;
                                initUser.cash -= 1000;

                                user.cash += animal.feedCash;
                                updateCashLabel();
                            }
                            else
                            {
                                sendNoCashBox();
                            }
                            break;
                    }
                }
                if (animal.foodLevel == 100)
                {
                    animal.straveTimes = 0;
                    animal.straving = false;
                }
            }else
            {
                if(combobox_food.Text == "OP Goldapfel | Kosten: 1000€")
                {
                    if (hasEnoghCash(1000))
                    {
                        animal.foodLevel = 100;
                        animal.healthLevel = 100;
                        animal.dead = false;

                        animal.loveLevel = 0;
                        initUser.cash -= 1000;
                    }
                    else
                    {
                        sendNoCashBox();
                    }
                }
                else
                {
                    MessageBox.Show("Dein Tier ist Tot!", "Nein!", MessageBoxButton.OKCancel, MessageBoxImage.Error);
                }
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

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {

            User initUser = GameManager.user;

            if (!animal.dead)
            { 
                if (animal.foodLevel <= 100)
                {
                    if (animal.loveLevel == 100)
                    {
                        initUser.cash += animal.strokeCash;
                        updateCashLabel();
                    }

                    if (animal.loveLevel <= 100)
                    {
                        initUser.cash -= animal.strokeCash;
                        updateCashLabel();
                    }
                }

                if (animal.loveLevel <= 95)
                {
                    animal.loveLevel += 5;
                }
                else
                {
                    animal.loveLevel = 100;
                }
            }
        }
        private void updateCashLabel()
        {
            label_cash.Content = "Geld: " + user.cash;
        }

        private void sendNoCashBox()
        {
            MessageBox.Show("Du hast nicht genug Geld!", "Nö!", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private Boolean hasEnoghCash(int cash)
        {
            return user.cash >= cash;
        }
    }
}
