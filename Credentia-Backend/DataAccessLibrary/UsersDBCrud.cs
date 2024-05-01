using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class UsersDBCrud
    {
        private readonly string _connectionString;
        // Create an instance of the MySqlDataAccess class
        private MySqlDataAccess db = new MySqlDataAccess();

        // Constructor
        public UsersDBCrud(string connectionString)
        {
            _connectionString = connectionString;
        }


        // Get all users from the users database's user_table
        public List<UsersModel> GetAllUsers()
        {
            string sql = "SELECT * FROM users.user_table";

            try
            {
                return db.LoadData<UsersModel, dynamic>(sql, new { }, _connectionString);
            }
            catch (Exception)
            {
                return null;
            }
        }

        // Add a new user to the users database's user_table
        public void CreateUser(string username, string masterPassword, string email, string userDatabase)
        {
            UsersModel data = new UsersModel
            {
                Username = username,
                MasterPassword = masterPassword,
                Email = email,
                User_Database = userDatabase
            };

            string sql = @"INSERT INTO users.user_table (Username, MasterPassword, Email, User_Database) 
                            VALUES (@Username, @MasterPassword, @Email, @User_Database);";

            db.SaveData(sql, data, _connectionString);

        }

        // Create a new user database
        public void CreateUserDatabase(string userDatabase)
        {
            string sql = $"CREATE SCHEMA IF NOT EXISTS {userDatabase};";

            db.SaveData(sql, new { }, _connectionString);
        }

        // Create Tables for the user in their particular newly created database
        public void CreateTables(string userDatabase)
        {

            // Create Logins Table
            string sql = $"CREATE TABLE {userDatabase}.`logins_table` (`Id` int NOT NULL AUTO_INCREMENT,  " +
                $"`Name` varchar(500) NOT NULL, `Username` varchar(300) NOT NULL," +
                $"`Password` varchar(500) NOT NULL, `URL` varchar(500), PRIMARY KEY (`Id`)," +
                $" UNIQUE KEY `Id_UNIQUE` (`Id`))";

            db.SaveData(sql, new { }, _connectionString);

            // Create Cards Table
            sql = $"CREATE TABLE {userDatabase}.`cards_table` (`Id` int NOT NULL AUTO_INCREMENT," +
                $"`Name` varchar(300) NOT NULL,  `CardholderName` varchar(300) NOT NULL," +
                $"`CardNumber` varchar(100) NOT NULL, `Brand` varchar(300) NOT NULL," +
                $"`ExpirationMonth` varchar(45) NOT NULL,`ExpirationYear` varchar(45) NOT NULL, " +
                $"`SecurityCode` varchar(45) NOT NULL,PRIMARY KEY (`Id`), UNIQUE KEY `Id_UNIQUE` (`Id`))";

            db.SaveData(sql, new { }, _connectionString);

            // Create Identities Table
            sql = $"CREATE TABLE {userDatabase}.`identities_table` (`Id` int NOT NULL AUTO_INCREMENT, " +
                $"`Name` varchar(300) NOT NULL, `Title` varchar(300) NOT NULL, `FirstName` varchar(300) NOT NULL," +
                $"`LastName` varchar(300) NOT NULL, `Username` varchar(100) DEFAULT NULL, " +
                $"`Company` varchar(200) DEFAULT NULL,`LicenseNumber` varchar(200) DEFAULT NULL, " +
                $"`Email` varchar(300) DEFAULT NULL, `Phone` varchar(200) DEFAULT NULL," +
                $"`Address` varchar(500) DEFAULT NULL, `Zip` varchar(100) DEFAULT NULL, " +
                $"`Country` varchar(200) DEFAULT NULL, PRIMARY KEY (`Id`), UNIQUE KEY `Id_UNIQUE` (`Id`))";

            db.SaveData(sql, new { }, _connectionString);


            // Create Secure Notes Table
            sql = $"CREATE TABLE {userDatabase}.`secure_notes_table` (`Id` int NOT NULL AUTO_INCREMENT," +
                $" `Name` varchar(300) NOT NULL,`SecureNote` text NOT NULL, PRIMARY KEY (`Id`)," +
                $" UNIQUE KEY `Id_UNIQUE` (`Id`))";

            db.SaveData(sql, new { }, _connectionString);
        }

        // Delete a user from the users database's user_table and delete the user's database
        public void DeleteUser(int id, string username)
        {
            string sql = "DELETE FROM users.user_table WHERE Id = @Id and Username = @Username";

            db.SaveData(sql, new { Id = id, Username = username }, _connectionString);

        }


        // Delete users Database
        public void DeleteDatabase(string userDatabase)
        {
            string sql = $"DROP DATABASE IF EXISTS `{userDatabase}`;";

            db.SaveData(sql, new { }, _connectionString);
        }

        // Get the Master Password from the Users database's user_table by unique Username
        public string GetMasterPassword(string username)
        {
            string sql = "SELECT MasterPassword FROM users.user_table WHERE Username = @Username";

            try
            {
                var data = db.LoadData<UsersModel, dynamic>(sql, new { Username = username }, _connectionString).First();

                return data.MasterPassword;
            }
            catch (Exception)
            {
                return null;
            }
        }
    }
}
