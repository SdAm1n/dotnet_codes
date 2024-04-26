using DataAccessLibrary;
using DataAccessLibrary.Models;
using Microsoft.Extensions.Configuration;

namespace Files
{
    class Program
    {
        private static IConfiguration _config;
        private static string textFile;
        private static TextFileDataAccess db = new TextFileDataAccess();

        static void Main(string[] args)
        {
            FileConfiguration();
            textFile = _config.GetValue<string>("TextFile");

            ContactModel user1 = new ContactModel
            {
                FirstName = "sadikul",
                LastName = "amin",
                PhoneNumbers = new List<string> { "123-456-7890", "987-654-3210" },
                EmailAddresses = new List<string> { "sadman@gmail.com" }
            };

            ContactModel user2 = new ContactModel
            {
                FirstName = "nj",
                LastName = "sm",
                PhoneNumbers = new List<string> { "123-456-78901" },
                EmailAddresses = new List<string> { "" }
            };

            AddContact(user1);
            AddContact(user2);
            GetAllContacts();



            Console.ReadLine();
        }


        private static void GetAllContacts()
        {
            var contacts = db.ReadAllRecords(textFile);

            foreach(var contact in contacts)
            {
                Console.WriteLine($"{ contact.FirstName } { contact.LastName }");
            }
        }

        private static void AddContact(ContactModel contact)
        {
            var contacts = db.ReadAllRecords(textFile);
            contacts.Add(contact);
            db.WriteAllRecords(contacts, textFile);
        }

        private static void UpdateContactsFirstName(string firstName)
        {
            var contacts = db.ReadAllRecords(textFile);

            contacts[0].FirstName = firstName;

            db.WriteAllRecords(contacts, textFile);
        }


        private static void FileConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            _config = builder.Build();
        }
    }
}
