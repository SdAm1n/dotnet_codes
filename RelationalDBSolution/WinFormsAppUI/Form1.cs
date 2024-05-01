using DataAccessLibrary;
using DataAccessLibrary.Models;
using Microsoft.Extensions.Configuration;

namespace WinFormsAppUI
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
        }


        private void SubmitBtn_Click(object sender, EventArgs e)
        {
            MySqlCrud sql = new MySqlCrud(GetConnectionString());


            FullContactModel user = new FullContactModel
            {
                BasicInfo = new BasicContactModel
                {
                    FirstName = FirstNameTextBox.Text,
                    LastName = LastNameTextBox.Text
                }
            };

            user.EmailAddresses.Add(new EmailAddressModel { EmailAddress = EmailTextBox.Text });
            //user.EmailAddresses.Add(new EmailAddressModel { Id = 1002, EmailAddress = "new@gmail.com" });

            //user.PhoneNumbers.Add(new PhoneNumberModel { Id = 1002, PhoneNumber = "555-1122" });
            user.PhoneNumbers.Add(new PhoneNumberModel { PhoneNumber = PhoneTextBox.Text });

            sql.CreateContact(user);
        }

        private static string GetConnectionString(string connectionStringName = "Default")
        {
            string output = "";

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            var config = builder.Build();
            var st = "MySql";
            output = config.GetConnectionString(connectionStringName) + $"Database={st}ContactsDB;";

            return output;
        }
    }
}
