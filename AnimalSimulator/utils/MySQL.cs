using System;
using MySql.Data.MySqlClient;

namespace AnimalSimulator
{
    class MySQL
    {

        public static MySqlConnection mySqlCon = new MySqlConnection("server=localhost; port=3306; username=root; password=1234; database=animalmanager");


        public static MySqlDataAdapter buildMySqlDataAdapter(String query)
        {
            return new MySqlDataAdapter(query, mySqlCon);
        }

        public static MySqlCommand buildMySqlCommand(String query)
        {
            return new MySqlCommand(query, mySqlCon);
        }


    }
}
