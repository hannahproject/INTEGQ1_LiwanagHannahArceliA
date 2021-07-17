using System;
using MySql.Data.MySqlClient;

namespace DL
{
    public class MyDB
    {
        static string connect = "server=localhost; port=3306; uid=root; database=couriermngmntsystem; charset=utf8; sslMode=none;";
        static MySqlConnection connection = new MySqlConnection(connect);

        public bool LoginValidation(string _username, string _password)
        {
            var selectStatement = "SELECT * FROM rider WHERE username = @username and password = @password";
            MySqlCommand selectCommand = new MySqlCommand(selectStatement, connection);
            selectCommand.Parameters.AddWithValue("@username", _username);
            selectCommand.Parameters.AddWithValue("@password", _password);
            connection.Open();
            MySqlDataReader reader = selectCommand.ExecuteReader();
            var isExists = reader.Read();
            connection.Close();
            return isExists;
        }

        public void DisplayPendingDeliveries()
        {
            var display = "SELECT * FROM pendingdeliveries";
            MySqlCommand selectCommand = new MySqlCommand(display,connection);
            connection.Open();
            MySqlDataReader reader = selectCommand.ExecuteReader();

            if(reader.HasRows)
            {                
                while(reader.Read())
                {
                    Console.WriteLine("\n-------------------------------------------------");
                    Console.WriteLine($"Parcel ID: {reader["ParcelID"]}");
                    Console.WriteLine($"Client Name: {reader["ClientName"]}");
                    Console.WriteLine($"Category: {reader["Category"]}");
                    Console.WriteLine($"Address: {reader["Address"]}");
                    Console.WriteLine($"Delivery Fee: {reader["DelFee"]}");
                    Console.WriteLine("-------------------------------------------------");
                }
            }
            connection.Close();
        }

        public bool SearchParcelID(string _parcelid)
        {
            var search = "SELECT ParcelID FROM pendingdeliveries WHERE ParcelID = @ParcelID";
            MySqlCommand selectCommand = new MySqlCommand(search,connection);
            selectCommand.Parameters.AddWithValue("@ParcelID", _parcelid);
            connection.Open();
            MySqlDataReader reader = selectCommand.ExecuteReader();
            var isExists = reader.Read();
            connection.Close();
            return isExists;
        }
    }
}
