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
using System.Threading;
using System.Windows.Threading;
using MySql.Data.MySqlClient;
using System.Data;

using AnimalSimulator.objects.AnimalObjects;
using AnimalSimulator.objects;
using AnimalSimulator.enums;
using AnimalSimulator.utils;

namespace AnimalSimulator
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Animal> animals = GameManager.animalContainer;
        DispatcherTimer timer = new DispatcherTimer();
        Random random = new Random();

        public MainWindow()
        {
            InitializeComponent();
            ContentFrame.Content = new pages.MainMenuPage();

            loadAnimalsFromDB();

            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Tick += timerTick;
            timer.Start();

        }

        private void timerTick(object sender, EventArgs e)
        {
            for (int i = 0; i < animals.Count; i++)
            {
                if (!animals[i].dead)
                {
                    if (animals[i].straving)
                    {
                        starve(animals[i]);
                    }
                    else if (animals[i].nextFoodTime <= 0)
                    {
                        animals[i].straving = true;
                        animals[i].straveTimes = random.Next(10, 240);


                        int calcFoodTime = random.Next(40000, 70000);
                        animals[i].nextFoodTime = calcFoodTime;

                        Console.WriteLine(calcFoodTime);

                        starve(animals[i]);
                    }
                    else
                    {
                        reduceFoodTime();
                    }
                }
            }
        }

        private void starve(Animal animal)
        {       
                if(animal.straveTimes == 0)
                {
                    animal.straving = false;

                }else
                {
                    animal.straveTimes -= 1;
                    animal.foodLevel -= 0.5;
                }
        }
        private void reduceFoodTime()
        {
            foreach(Animal allAnimals in animals)
            {
                allAnimals.nextFoodTime -= 1000;
            }
        }

        private void loadAnimalsFromDB()
        {
            User user = GameManager.user;
            MySqlDataAdapter adapter = MySQL.buildMySqlDataAdapter("SELECT * FROM animals WHERE ownerID=" + user.userID + ";");
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);

            Animal animal;

            if(dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    
                    String type = (string)dataTable.Rows[i].ItemArray[1];

                    switch (type)
                    {
                        case "Hund":
                            animal = new Hund();
                            animal.type = AnimalType.Hund;
                            break;
                        case "Katze":
                            animal = new Katze();
                            animal.type = AnimalType.Katze;
                            break;
                        case "Maus":
                            animal = new Maus();
                            animal.type = AnimalType.Maus;
                            break;
                        case "Goldfisch":
                            animal = new Goldfisch();
                            animal.type = AnimalType.Goldfisch;
                            break;
                        case "Hai":
                            animal = new Hai();
                            animal.type = AnimalType.Hai;
                            break;
                        case "Tintenfisch":
                            animal = new Tintenfisch();
                            animal.type = AnimalType.Tintenfisch;
                            break;
                        case "Adler":
                            animal = new Adler();
                            animal.type = AnimalType.Adler;
                            break;
                        default:
                            animal = new Animal();
                            break;
                    }

                    animal.foodLevel = Convert.ToInt32(dataTable.Rows[i].ItemArray[2]);
                    animal.healthLevel = Convert.ToInt32(dataTable.Rows[i].ItemArray[3]);
                    animal.loveLevel = Convert.ToInt32(dataTable.Rows[i].ItemArray[4]);

                    GameManager.animalContainer.Add(animal);

                }
            }

        }

    }
}
