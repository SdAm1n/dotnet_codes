using DataAccessLibrary;
using DataAccessLibrary.Helpers;
using Microsoft.Extensions.Configuration;


namespace Credentia_Backend
{
    public class Program
    {


        static void Main(string[] args)
        { 

            string db_name = "testing_credentia_db";

            UsersDBCrud sql = new UsersDBCrud(GetConnectionString() + $"Database={db_name};");

            // create users db and user_table if doesn't exist
            CreateUsersDB(sql);

            string choose;
            Console.WriteLine("1. view all");
            Console.WriteLine("2. Add new");
            Console.WriteLine("3. Delete");
            Console.WriteLine("4. Update");
            Console.WriteLine("q. Quit");



            //while (true)
            //{
            //    Console.Write("Choose: ");
            //    choose = Console.ReadLine();

            //    if (choose == "1")
            //    {
            //        ReadAllSecureNotes(sql, db_name);
            //    }
            //    else if (choose == "2")
            //    {
            //        AddSecureNote(sql, db_name);
            //        Console.WriteLine("Secure Note Added");
            //    }
            //    else if (choose == "3")
            //    {
            //        Console.Write("Enter ID: ");
            //        int id = int.Parse(Console.ReadLine());

            //        DeleteSecureNote(sql, id, db_name);
                    
            //        Console.WriteLine("Secure Note Deleted");
            //    }
            //    else if (choose == "4")
            //    {
            //        Console.Write("Enter ID: ");
            //        int id = int.Parse(Console.ReadLine());
            //        Console.Write("Enter Name: ");
            //        string name = Console.ReadLine();
            //        Console.Write("Enter Secure Note: ");
            //        string securenote = Console.ReadLine();

            //        UpdateSecureNote(sql, id, name, securenote, db_name);
            //    }
            //    else if (choose == "q")
            //    {
            //        Console.WriteLine("Quitting");
            //        break;
            //    }
            //    else
            //    {
            //        Console.WriteLine("Invalid Input");
            //    }
            //}

            //string DATABASE_NAME = "users";
            //// Create an instance of the MySqlCrud class
            //UsersDBCrud sql = new UsersDBCrud(GetConnectionString() + $"Database={DATABASE_NAME};");


            //string choose;
            //Console.WriteLine("1. Create New User");
            //Console.WriteLine("2. Get All Users");
            //Console.WriteLine("3. Delete User");
            //Console.WriteLine("4. Get Master Password");
            //Console.WriteLine("5. Verify Master Password");
            //Console.WriteLine("q. Quit");


            //while (true)
            //{
            //    Console.Write("Choose: ");
            //    choose = Console.ReadLine();

            //    if (choose == "1")
            //    {
            //        // Add a new user to the users database's user_table
            //        Console.WriteLine("Creating New User");
            //        CreateUser(sql);

            //    }
            //    else if (choose == "2")
            //    {
            //        // Get all users from the users database's user_table
            //        ReadAllUsers(sql);
            //    }
            //    else if (choose == "3")
            //    {
            //        ReadAllUsers(sql);

            //        // Delete a user from the users database's user_table and their database
            //        Console.WriteLine("Deleting User");
            //        DeleteUser(sql);
            //        Console.WriteLine("User Deleted");
            //    }
            //    else if (choose == "4")
            //    {
            //        Console.WriteLine("Getting Master Password");
            //        string MP = GetMasterPassword(sql);
            //        Console.WriteLine($"Master Password: {MP}");
            //    }
            //    else if (choose == "5")
            //    {
            //        // Verify Master Password
            //        Console.WriteLine("Verifying Master Password");
            //        Console.Write("Enter Username: ");
            //        string username = Console.ReadLine();
            //        Console.Write("Enter Master Password: ");
            //        string masterPassword = Console.ReadLine();

            //        var storedMasterPassword = sql.GetMasterPassword(username);
            //        bool verified = MasterPasswordHelper.VerifyMasterPassword(masterPassword, storedMasterPassword);
            //        Console.WriteLine($"Verified: {verified}");
            //    }
            //    else if (choose == "q")
            //    {
            //        Console.WriteLine("Quitting");
            //        break;
            //    }
            //    else
            //    {
            //        Console.WriteLine("Invalid Input");
            //    }
            //}


            Console.ReadLine();
        }

        // -------------------- Secure Notes Table Operations -------------------------- //

        
        // Get all Secure Notes from the user's database's secure_notes_table
        private static void ReadAllSecureNotes(UsersDBCrud sql, string userDatabase)
        {
            var rows = sql.GetSecureNotes(userDatabase);
            foreach (var row in rows)
            {
                // Decrypt the Secure Note
                string decrypted = AesHelper.Decrypt(row.SecureNote);

                Console.WriteLine($"{row.Name}: {decrypted}");
            }
        }

        // Add a new Secure Note to the user's database's secure_notes_table
        private static void AddSecureNote(UsersDBCrud sql, string userDatabase)
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            Console.Write("Enter Secure Note: ");
            string secureNote = Console.ReadLine();

            // Encrypt the Secure Note
            byte[] encrypted = AesHelper.Encrypt(secureNote);

            sql.AddSecureNote(name, encrypted, userDatabase);
        }

        // Delete a Secure Note from the user's database's secure_notes_table
        private static void DeleteSecureNote(UsersDBCrud sql, int id, string userDatabase)
        {
            sql.DeleteSecureNote(id, userDatabase);
        }

        // Update a Secure Note in the user's database's secure_notes_table
        private static void UpdateSecureNote(UsersDBCrud sql, int id, string name, string securenote, string userDatabase)
        {
            // Update a Secure Note in the user's database's secure_notes_table
            byte[] encrypted = AesHelper.Encrypt(securenote);

            sql.UpdateSecureNote(id, name, encrypted, userDatabase);
        }


        // --------------- User Table Operations ----------------- //

        // create users db and user_table if doesn't exist
        private static void CreateUsersDB(UsersDBCrud sql)
        {
            sql.CreateUsersDB();
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
