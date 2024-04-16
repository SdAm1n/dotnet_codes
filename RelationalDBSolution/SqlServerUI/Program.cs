using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using DataAccessLibrary;
using DataAccessLibrary.Models;

namespace SqlServerUI
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlCrud sql = new SqlCrud(GetConnectionString());

            //ReadAllContacts(sql);

            //ReadContact(sql, 2003);

            //CreateNewContact(sql);

            //UpdateContact(sql);

            RemovePhoneNumber(sql, 2002, 1);
            Console.WriteLine("Done");

            Console.ReadLine();
        }

        // Remove Phone Number from contact
        private static void RemovePhoneNumber(SqlCrud sql, int contactId, int phoneNumberId)
        {
            sql.RemovePhoneNumberFromContact(contactId, phoneNumberId);
        }

        // Update Contact
        private static void UpdateContact(SqlCrud sql)
        {

            BasicContactModel user = new BasicContactModel
            {
                Id = 2002,
                FirstName = "Johny",
                LastName = "Doewy"
            };

            sql.UpdateContactName(user);
        }

        // Create New Contact
        private static void CreateNewContact(SqlCrud sql)
        {
            FullContactModel user = new FullContactModel
            {
                BasicInfo = new BasicContactModel
                {
                    FirstName = "Johny",
                    LastName = "Doewy"
                }
            };

            //user.EmailAddresses.Add(new EmailAddressModel { EmailAddress = "johndoe@gmail.com" });
            user.EmailAddresses.Add(new EmailAddressModel { Id = 1002, EmailAddress = "new@gmail.com" });

            user.PhoneNumbers.Add(new PhoneNumberModel {Id = 1002, PhoneNumber = "555-1122" });
            //user.PhoneNumbers.Add(new PhoneNumberModel { PhoneNumber = "555-9876" });

            sql.CreateContact(user);

        }

        // Getting all contacts from the database and printing them
        private static void ReadAllContacts(SqlCrud sql)
        {
            var rows = sql.GetAllContacts();
            foreach (var row in rows) 
            {
                Console.WriteLine($"{ row.Id }: { row.FirstName } { row.LastName }");
            }
        }

        // Getting a specific contact from the database and printing it
        private static void ReadContact(SqlCrud sql, int contactId)
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