using DataAccessLibrary;
using DataAccessLibrary.Models;
using Microsoft.Extensions.Configuration;

namespace MySqlUI
{
    public class Program
    {
        static void Main(string[] args)
        {
            MySqlCrud sql = new MySqlCrud(GetConnectionString());


            //ReadContact(sql, 2);

            //CreateNewContact(sql);

            UpdateContact(sql);

            ReadAllContacts(sql);
            //RemovePhoneNumber(sql, 2002, 1);
            Console.WriteLine("Done Processing MySQL");

            Console.ReadLine();
        }

        // Remove Phone Number from contact
        private static void RemovePhoneNumber(MySqlCrud sql, int contactId, int phoneNumberId)
        {
            sql.RemovePhoneNumberFromContact(contactId, phoneNumberId);
        }

        // Update Contact
        private static void UpdateContact(MySqlCrud sql)
        {

            BasicContactModel user = new BasicContactModel
            {
                Id = 2,
                FirstName = "baka",
                LastName = "Doewy"
            };

            sql.UpdateContactName(user);
        }

        // Create New Contact
        private static void CreateNewContact(MySqlCrud sql)
        {
            FullContactModel user = new FullContactModel
            {
                BasicInfo = new BasicContactModel
                {
                    FirstName = "Johny",
                    LastName = "Doewy"
                }
            };

            user.EmailAddresses.Add(new EmailAddressModel { EmailAddress = "johndoe@gmail.com" });
            //user.EmailAddresses.Add(new EmailAddressModel { Id = 1002, EmailAddress = "new@gmail.com" });

            //user.PhoneNumbers.Add(new PhoneNumberModel { Id = 1002, PhoneNumber = "555-1122" });
            user.PhoneNumbers.Add(new PhoneNumberModel { PhoneNumber = "555-9876" });

            sql.CreateContact(user);

        }

        // Getting all contacts from the database and printing them
        private static void ReadAllContacts(MySqlCrud sql)
        {
            var rows = sql.GetAllContacts();
            foreach (var row in rows)
            {
                Console.WriteLine($"{row.Id}: {row.FirstName} {row.LastName}");
            }
        }

        // Getting a specific contact from the database and printing it
        private static void ReadContact(MySqlCrud sql, int contactId)
        {
            var contact = sql.GetFullContactById(contactId);

            Console.WriteLine($"{contact.BasicInfo.Id}: {contact.BasicInfo.FirstName} {contact.BasicInfo.LastName}");
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

