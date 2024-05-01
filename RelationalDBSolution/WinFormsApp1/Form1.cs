using DataAccessLibrary;
using DataAccessLibrary.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void LastNametextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Submitbutton_Click(object sender, EventArgs e)
        {
            MySqlCrud sql = new MySqlCrud(GetConnectionString());
        }


        private static void CreateNewContact(MySqlCrud sql)
        {
            FullContactModel user = new FullContactModel
            {
                BasicInfo = new BasicContactModel
                {
                    FirstName = FirstNameTextBox.Text,
                    LastName = LastNameTextBox.Text
                }
            };

            user.EmailAddresses.Add(new EmailAddressModel { EmailAddress = "johndoe@gmail.com" });
            //user.EmailAddresses.Add(new EmailAddressModel { Id = 1002, EmailAddress = "new@gmail.com" });

            //user.PhoneNumbers.Add(new PhoneNumberModel { Id = 1002, PhoneNumber = "555-1122" });
            user.PhoneNumbers.Add(new PhoneNumberModel { PhoneNumber = "555-9876" });

            sql.CreateContact(user);

        }


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

        private void FirstNameTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
