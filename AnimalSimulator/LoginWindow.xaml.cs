using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows;
using System.Data;
using System.Management;

using AnimalSimulator.objects;
using AnimalSimulator.utils;

namespace AnimalSimulator
{
    /// <summary>
    /// Interaktionslogik für LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        User user = new User();

        public LoginWindow()
        {
            InitializeComponent();

            if (isHWIDLoggedIn())
            {
                MySQL.mySqlCon.Open();

                MySqlDataAdapter mySqlDataAdapter = MySQL.buildMySqlDataAdapter("SELECT * FROM user WHERE userID='" + GameManager.user.userID + "';");
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);

                GameManager.user.hwid = getHWID();
                GameManager.user.username = (String)dataTable.Rows[0].ItemArray[1];
                GameManager.user.password = (String)dataTable.Rows[0].ItemArray[2];

                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();

                MySQL.mySqlCon.Close();
                MessageBox.Show("Eingeloggt als: " + GameManager.user.username + ", Password: " + GameManager.user.password, "OK!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void Button_Login_Click(object sender, RoutedEventArgs e)
        {
            MySQL.mySqlCon.Open();

            if(!isHWIDLoggedIn())
            {
                String username = TextBox_Username.Text;
                String password = TextBox_Password.Password;
                bool? stayLogedInState = CheckBox_stayloggedin.IsChecked;

                MySqlDataAdapter mySqlDataAdapter = MySQL.buildMySqlDataAdapter("SELECT * FROM user WHERE username='" + username + "'AND password='" + password + "';");
                DataTable dataTable = new DataTable();
                mySqlDataAdapter.Fill(dataTable);

                if(dataTable.Rows.Count == 1)
                {
                    int userID = Convert.ToInt32(dataTable.Rows[0].ItemArray[0]);
                    String userHWID = getHWID();

                    GameManager.user.userID = userID;
                    GameManager.user.username = username;
                    GameManager.user.password = password;
                    GameManager.user.hwid = userHWID;

                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();

                    if ((bool)stayLogedInState)
                    {
                        MySqlCommand sqlcommand = MySQL.buildMySqlCommand("INSERT INTO sessions SET hwid='" + userHWID + "', userID='" + userID + "';");
                        sqlcommand.ExecuteNonQuery();
                    }

                    MessageBox.Show("Erfolgreich Eingeloggt", "OK!", MessageBoxButton.OK, MessageBoxImage.Information);
                    MySQL.mySqlCon.Close();
                }
                else
                {
                    MessageBox.Show("Der User exsistiert nicht!", "Fehler!", MessageBoxButton.OK, MessageBoxImage.Error);
                    MySQL.mySqlCon.Close();
                }

            }
        }

        private void Button_Register_Click(object sender, RoutedEventArgs e)
        {
            RegisterWindow registerWindow = new RegisterWindow();
            registerWindow.Show();
            this.Close();
        }

        // Check if HWID reg. => Use Data from database => Login
        // If Pressed Logout => Drop Row Where HWID = No Remember Me!

        private String getHWID()
        {

            //Source: https:// jai-on-asp.blogspot.com/2010/03/finding-hardware-id-of-computer.html

            ManagementObjectCollection mbsList = null;
            ManagementObjectSearcher mbs = new ManagementObjectSearcher("Select * From Win32_processor");
            mbsList = mbs.Get();
            string id = "";
            foreach (ManagementObject mo in mbsList)
            {
                id = mo["ProcessorID"].ToString();
            }

            return id;
        }

        private Boolean isHWIDLoggedIn()
        {

            String hwid = getHWID();
            MySqlDataAdapter mySqlDataAdapter = MySQL.buildMySqlDataAdapter("SELECT * FROM sessions WHERE hwid='" + hwid + "';");
            DataTable dataTable = new DataTable();

            mySqlDataAdapter.Fill(dataTable);

            


            if (dataTable.Rows.Count == 1)
            {
                GameManager.user.userID = Convert.ToInt32(dataTable.Rows[0].ItemArray[1]);
                return true;
            }
            else
            {
                return false;
            }


        }

    }
}
