using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Threading;
using MySql.Data.MySqlClient;
using System.Data;

using AnimalSimulator.objects.BarnObjects;
using AnimalSimulator.objects.AnimalObjects;
using AnimalSimulator.objects;
using AnimalSimulator.enums;
using AnimalSimulator.utils;

// Liste mit Gehege typen [0] = 1 Gehege
// Animal.type = gehege[0].type  


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
        int timerCounter = 0;
        public MainWindow()
        {
            InitializeComponent();
            ContentFrame.Content = new pages.MainMenuPage();

            loadAnimalsFromDB();
            loadBarnsFromDB();

            timer.Interval = TimeSpan.FromMilliseconds(1000);
            timer.Tick += timerTick;
            timer.Start();
        }

        private void timerTick(object sender, EventArgs e)
        {
            timerCounter++;
            saveDatasAfterSeconds();


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
                if (animal.foodLevel >= 0.5)
                {
                    animal.foodLevel -= 0.5;
                }
                else
                {
                    double diff = 100 - animal.foodLevel;
                    animal.foodLevel -= diff;
                }
            }
        }
        private void reduceFoodTime()
        {
            foreach(Animal allAnimals in animals)
            {
                allAnimals.nextFoodTime -= 1000;
            }
        }

        private void saveDatasAfterSeconds()
        {
            User user = GameManager.user;

            if(timerCounter == 10)
            {
                timerCounter = 0;

                MySQL.mySqlCon.Open();

                MySqlCommand command = MySQL.buildMySqlCommand("DELETE FROM animals WHERE ownerID=" + user.userID + ";");
                command.ExecuteNonQuery();

                command = MySQL.buildMySqlCommand("DELETE FROM barns WHERE ownerID=" + user.userID + ";");
                command.ExecuteNonQuery();

                command = MySQL.buildMySqlCommand("UPDATE user SET cash =" + user.cash + " WHERE userID=" + user.userID + ";");
                command.ExecuteNonQuery();

                for (int i = 0; i < GameManager.animalContainer.Count; i++)
                {
                    Animal target = GameManager.animalContainer[i];
                    command = MySQL.buildMySqlCommand("INSERT INTO animals SET animaltype='" + target.type + "', foodlevel=" + Math.Floor(target.foodLevel) + ", healthlevel=" + Math.Floor(target.healthLevel) +", lovelevel=" + Math.Floor(target.loveLevel) + ", ownerID=" + user.userID + ";");
                    command.ExecuteNonQuery();
                }

                for (int i = 0; i < GameManager.barnContainer.Count; i++)
                {
                    Barn barn = GameManager.barnContainer[i];
                    command = MySQL.buildMySqlCommand("INSERT INTO barns SET barntype='" + barn.type + "',ownerID =" + user.userID + ";");
                    command.ExecuteNonQuery();
                }
                MySQL.mySqlCon.Close();
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


        private void loadBarnsFromDB()
        {
            User user = GameManager.user;
            MySqlDataAdapter adapter = MySQL.buildMySqlDataAdapter("SELECT * FROM barns WHERE ownerID=" + user.userID + ";");
            DataTable dataTable = new DataTable();

            adapter.Fill(dataTable);

            Barn barn;

            if (dataTable.Rows.Count > 0)
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {

                    String type = (string)dataTable.Rows[i].ItemArray[1];

                    switch (type)
                    {
                        case "Basket":
                            barn = new BasketBarn();
                            barn.type = BarnType.Basket;
                            break;
                        case "Cage":
                            barn = new CageBarn();
                            barn.type = BarnType.Cage;
                            break;
                        case "Nest":
                            barn = new NestBarn();
                            barn.type = BarnType.Nest;
                            break;
                        case "Water":
                            barn = new WaterBarn();
                            barn.type = BarnType.Water;
                            break;
                        default:
                            barn = new Barn();
                            break;
                    }

                    GameManager.barnContainer.Add(barn);

                }
            }
        }
    }
}
