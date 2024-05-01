using DataAccessLibrary;
using DataAccessLibrary.Helpers;
using Microsoft.Extensions.Configuration;


namespace Credentia_Backend
{
    public class Program
    {


        static void Main(string[] args)
        {
            string DATABASE_NAME = "users";
            

            // Create an instance of the MySqlCrud class
            UsersDBCrud sql = new UsersDBCrud(GetConnectionString() + $"Database={DATABASE_NAME};");

            string choose;
            Console.WriteLine("1. Create New User");
            Console.WriteLine("2. Get All Users");
            Console.WriteLine("3. Delete User");
            Console.WriteLine("4. Get Master Password");
            Console.WriteLine("5. Verify Master Password");
            Console.WriteLine("q. Quit");


            while (true)
            {
                Console.Write("Choose: ");
                choose = Console.ReadLine();

                if (choose == "1")
                {
                    // Add a new user to the users database's user_table
                    Console.WriteLine("Creating New User");
                    CreateUser(sql);

                }
                else if (choose == "2")
                {
                    // Get all users from the users database's user_table
                    ReadAllUsers(sql);
                }
                else if (choose == "3")
                {
                    ReadAllUsers(sql);

                    // Delete a user from the users database's user_table and their database
                    Console.WriteLine("Deleting User");
                    DeleteUser(sql);
                    Console.WriteLine("User Deleted");
                }
                else if (choose == "4")
                {
                    Console.WriteLine("Getting Master Password");
                    string MP = GetMasterPassword(sql);
                    Console.WriteLine($"Master Password: {MP}");
                }
                else if (choose == "5")
                {
                    // Verify Master Password
                    Console.WriteLine("Verifying Master Password");
                    Console.Write("Enter Username: ");
                    string username = Console.ReadLine();
                    Console.Write("Enter Master Password: ");
                    string masterPassword = Console.ReadLine();

                    var storedMasterPassword = sql.GetMasterPassword(username);
                    bool verified = MasterPasswordHelper.VerifyMasterPassword(masterPassword, storedMasterPassword);
                    Console.WriteLine($"Verified: {verified}");
                }
                else if (choose == "q")
                {
                    Console.WriteLine("Quitting");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }
            }


            Console.ReadLine();
        }

        // Get Master Password from the Users database's user_table
        private static string GetMasterPassword(UsersDBCrud sql)
        {
            Console.Write("Enter Username: ");
            string username = Console.ReadLine();
            
            return sql.GetMasterPassword(username);
        }


        // Delete a user from the users database's user_table and their database
        private static void DeleteUser(UsersDBCrud sql)
        {
            Console.Write("Enter User ID: ");
            int id = int.Parse(Console.ReadLine());

            Console.Write("Enter Username: ");
            string username = Console.ReadLine();

            sql.DeleteUser(id, username);
            DeleteUserDB($"{username}_credentia_db");
        }

        // Delete a user database
        private static void DeleteUserDB(string userDatabase)
        {
            UsersDBCrud sql = new UsersDBCrud(GetConnectionString() + $"Database={userDatabase};");

            // Delete a user database
            sql.DeleteDatabase(userDatabase);
        }


        // Create a new user database
        private static void CreateUserDB(UsersDBCrud sql, string userDatabase)
        {
            // Create a new user database
            sql.CreateUserDatabase(userDatabase);
            CreateUserTables(userDatabase);
        }

        // Create Tables for the user in their particular newly created database
        private static void CreateUserTables(string userDatabase)
        {
            UsersDBCrud sql = new UsersDBCrud(GetConnectionString() + $"Database={userDatabase};");

            // Create Tables for the user in their particular newly created database
            sql.CreateTables(userDatabase);
        }


        // Create a new user in the Users database's user_table
        private static void CreateUser(UsersDBCrud sql)
        {
            Console.Write("Enter Username: ");
            string username = Console.ReadLine().ToLower();
            Console.Write("Enter Master Password: ");
            string masterPassword = Console.ReadLine();
            var hashedMasterPassword = MasterPasswordHelper.HashMasterPassword(masterPassword);

            Console.Write("Enter Email: ");
            string email = Console.ReadLine();
            string userDatabase = $"{username}_credentia_db";

            sql.CreateUser(username, hashedMasterPassword, email, userDatabase);

            CreateUserDB(sql, userDatabase);
        }


        // Getting all Data from the Users database's user_table and printing them
        private static void ReadAllUsers(UsersDBCrud sql)
        {
            var rows = sql.GetAllUsers();
            foreach (var row in rows)
            {
                Console.WriteLine($"{row.Id}: {row.Username} {row.MasterPassword} {row.Email} {row.User_Database}");
            }
        }


        // Getting the connection string from the appsettings.json file
        private static string GetConnectionString(string connectionStringName = "Default")
        {
            string output = "";

            var builder = new ConfigurationBuilder()
                          .SetBasePath(Directory.GetCurrentDirectory())
                          .AddJsonFile("appsettings.json");

            var config = builder.Build();

            output = config.GetConnectionString(connectionStringName);

            return output;
        }
    }
}
