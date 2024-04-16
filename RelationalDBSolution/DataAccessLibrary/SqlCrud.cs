using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class SqlCrud
    {
        private readonly string _connectionString;
        private SqlDataAccess db = new SqlDataAccess();

        // Constructor
        public SqlCrud(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Get all contacts
        public List<BasicContactModel> GetAllContacts()
        {
            string sql = "select Id, FirstName, LastName from dbo.Contacts";

            return db.LoadData<BasicContactModel, dynamic>(sql, new {}, _connectionString);
        }

        // Get a contact by ID
        public FullContactModel GetFullContactById(int id)
        {
            string sql = "select Id, FirstName, LastName from dbo.Contacts where Id = @Id";
            FullContactModel output = new FullContactModel();

            output.BasicInfo = db.LoadData<BasicContactModel, dynamic>(sql, new { Id = id }, _connectionString).FirstOrDefault();

            if (output.BasicInfo == null)
            {
                // record not found
                return null;
            }

            sql = @"select e.*
                    from dbo.EmailAddresses e
                    inner join dbo.ContactEmail ce on ce.EmailAddressId = e.Id
                    where ce.ContactId = @Id";

            output.EmailAddresses = db.LoadData<EmailAddressModel, dynamic>(sql, new { Id = id }, _connectionString);


            sql = @"select p.*
                    from dbo.PhoneNumbers p
                    inner join dbo.ContactPhoneNumbers cp on cp.PhoneNumberId = p.Id
                    where cp.ContactId = @Id";

            output.PhoneNumbers = db.LoadData<PhoneNumberModel, dynamic>(sql, new { Id = id }, _connectionString);

            return output;
        }

        // Create a new contact
        public void CreateContact(FullContactModel contact)
        {
            /*  Save the basic contact
             *  Get the ID from the contact
             *  
             *  Identify if the phone number exists
             *  insert into link table if it exists or create the phone number, get id and insert into link table
             *  
             *  do the same for email
             */

            // Save basic contact
            string sql = @"insert into dbo.Contacts (FirstName, LastName)
                            values (@FirstName, @LastName);";
            db.SaveData(sql, 
                        new {FirstName = contact.BasicInfo.FirstName, LastName = contact.BasicInfo.LastName}, _connectionString);

            // Get the ID from the contact
            sql = "select Id from dbo.Contacts where FirstName = @FirstName and LastName = @LastName";
            var contactId = db.LoadData<IdLookupModel, dynamic>(sql, 
                                       new { contact.BasicInfo.FirstName, contact.BasicInfo.LastName }, 
                                       _connectionString).First().Id;
            
            // Save Phone Number
            foreach (var phoneNumber in contact.PhoneNumbers)
            {
                // Identify if the phone number exists
                if (phoneNumber.Id == 0)
                {
                    // insert into link table if it exists or create the phone number, get id and insert into link table
                    sql = @"insert into dbo.PhoneNumbers (PhoneNumber)
                            values (@PhoneNumber);";
                    db.SaveData(sql, new { PhoneNumber = phoneNumber.PhoneNumber }, _connectionString);

                    sql = "select Id from dbo.PhoneNumbers where PhoneNumber = @PhoneNumber";
                    phoneNumber.Id = db.LoadData<IdLookupModel, dynamic>(sql, new { PhoneNumber = phoneNumber.PhoneNumber }, _connectionString).First().Id;
                }

                sql = @"insert into dbo.ContactPhoneNumbers (ContactId, PhoneNumberId)
                        values (@ContactId, @PhoneNumberId);";
                db.SaveData(sql, new { ContactId = contactId, PhoneNumberId = phoneNumber.Id }, _connectionString);
            }

            // Save Email Address
            foreach (var email in contact.EmailAddresses)
            {
                // Identify if the email exists
                if (email.Id == 0)
                {
                    // insert into link table if it exists or create the email, get id and insert into link table
                    sql = @"insert into dbo.EmailAddresses (EmailAddress)
                            values (@EmailAddress);";
                    db.SaveData(sql, new { EmailAddress = email.EmailAddress }, _connectionString);

                    sql = "select Id from dbo.EmailAddresses where EmailAddress = @EmailAddress";
                    email.Id = db.LoadData<IdLookupModel, dynamic>(sql, new { EmailAddress = email.EmailAddress }, _connectionString).First().Id;
                }

                sql = @"insert into dbo.ContactEmail (ContactId, EmailAddressId)
                        values (@ContactId, @EmailAddressId);";
                db.SaveData(sql, new { ContactId = contactId, EmailAddressId = email.Id }, _connectionString);
            }   


        }

        // Update FirstName and LastName of a contact
        public void UpdateContactName(BasicContactModel contact)
        {
            string sql = @"update dbo.Contacts
                            set FirstName = @FirstName, LastName = @LastName
                            where Id = @Id";
            
            db.SaveData(sql, contact, _connectionString);
        }

        // Remova a phone number from a contact
        public void RemovePhoneNumberFromContact(int contactId, int phoneNumberId)
        {
            // Find all the usage of phone number
                // If 1, then delete the link and the phone number
                // If more than 1, then delete the link only

            string sql = @"select Id, ContactId, PhoneNumberId
                            from dbo.ContactPhoneNumbers
                            where PhoneNumberId = @PhoneNumberId";
            var links = db.LoadData<ContactPhoneNumberModel, dynamic>(sql, new { PhoneNumberId = phoneNumberId }, _connectionString);

            sql = @"delete from dbo.ContactPhoneNumbers
                        where PhoneNumberId = @PhoneNumberId and ContactId = @ContactId";  
            db.SaveData(sql, new { PhoneNumberId = phoneNumberId, ContactId = contactId }, _connectionString);

            if (links.Count == 1)
            {
                sql = @"delete from dbo.PhoneNumbers
                        where Id = @PhoneNumberId";
                db.SaveData(sql, new { PhoneNumberId = phoneNumberId }, _connectionString);
            }
        }

    }
}
