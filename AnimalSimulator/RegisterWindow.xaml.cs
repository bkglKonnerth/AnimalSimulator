using System;
using System.Windows;
using MySql.Data.MySqlClient;
using System.Data;

namespace AnimalSimulator
{
    /// <summary>
    /// Interaktionslogik für RegisterWindow.xaml
    /// </summary>
    public partial class RegisterWindow : Window
    {
        public RegisterWindow()
        {
            InitializeComponent();
        }

        private void Button_Register_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            this.Close();
        }

        private void Button_Login_Click(object sender, RoutedEventArgs e)
        {
            //Code zum Regestrieren eines Benutzers, danach Login öffnen

            Boolean registerFailed = false;
            String username = TextBox_Username.Text;
            String password = TextBox_Password.Password;

            if (username == "" || username == null)
            {
                MessageBox.Show("Username darf nicht leer sein", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                registerFailed = true;
            }

            if(password != TextBox_Password_check.Password)
            {
                MessageBox.Show("Passwörter stimmen nicht überein!", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
                registerFailed = true;
            }


            if (!registerFailed)
            {

                MySQL.mySqlCon.Open();

                MySqlDataAdapter mySqlDataAdapter = MySQL.buildMySqlDataAdapter("SELECT * FROM user WHERE username='" + username + "';");
                DataTable dataTable = new DataTable();

                mySqlDataAdapter.Fill(dataTable);

                if(dataTable.Rows.Count == 0)
                {
                    MySqlCommand command = MySQL.buildMySqlCommand("INSERT INTO user SET cash=800, username ='" + username + "', password='" + password + "';");
                    command.ExecuteNonQuery();

                    LoginWindow loginWindow = new LoginWindow();
                    loginWindow.Show();
                    this.Close();

                    MessageBox.Show("Erfolgreich Regestriert", "OK!", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Dieser User Existiert bereits!", "Fehler", MessageBoxButton.OK, MessageBoxImage.Warning);
                }




                MySQL.mySqlCon.Close();
            }

            // check User exist
            // if not => register User => Messagebox + open Login 
            // if => error box

        }
    }
}
