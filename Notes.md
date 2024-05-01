# Winforms Setup

## Setting up a form

- Appearance
  - BackColor
  - BackgroundImage
  - BackgroundImageLayout
- Window Style
  - MaximizeBox
  - MinimizeBox
- Size
  - Start Position
- Font
  - Text
  - Font
  - ForeColor
- Controls
  - Name
  - Text
  - TabIndex

## ListboxItem

- Items : to add items to the listbox only at design time
- Selection Mode: Single, MultiSimple, MultiExtended defines how many items can be selected at a time
- To add item: `listbox1.Items.Add("Item1");`
- Focus on textbox: `textbox1.Focus();`
- Count of items: `listbox1.Items.Count;`
- Sort items: `listbox1.Sorted = true;`
- Remove specific item: `listbox1.Items.Remove(listbox1.SelectedItem);` select the item first. or remove by index `listbox1.Items.RemoveAt(listbox1.SelectedIndex);`
- Remove all items: `listbox1.Items.Clear();`

## Combobox

- Items: to add items to the combobox only at design time.
- DropDownStyle: DropDownList (can not edit), DropDown (can edit), Simple (List box is open) defines the style of the combobox.
- Properties
  - AutoCompleteCustomSource: to add items to the combobox at runtime.
  - AutoCompleteMode: Suggest, Append, SuggestAppend
  - AutoCompleteSource: CustomSource, ListItems, HistoryList
  - Do both AutoCompleteMode and AutoCompleteSource to get the autocomplete feature. (use suggest and ListItems)
- To add item: `combobox1.Items.Add(textbox1.Text);`
- clear textbox: `textbox1.Clear();`
- Selected Index Changed: `combobox1.SelectedItem;`. convert to string if needed.
- Find already existing item: `combobox1.Items.Contains(textbox1.Text);`

## Link Label

- To visit a link: `System.Diagnostics.Process.Start("https://www.google.com");`
- Go to another form:

```csharp
Form2 form2 = new Form2();
form2.Show();
```

- Remove Underline of Link Label

```csharp
// Add this to Form_Load Event
this.linkLabel1.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
```

## Pass Data between Forms

- Create static variables in one form and reference them in another form.

## Radio Button

- check if radio button is checked: `radiobutton1.Checked`. it returns boolean value.
- User group box to group radio buttons.
- change form color: `this.BackColor = System.Drawing.Color.Red;`

## Error Provider

- Add error provider to the form.
- Set error message: `errorProvider1.SetError(this.textbox1, "Please enter a value");`
- clear error message: `errorProvider1.Clear();`
- set icon: `errorProvider1.Icon = Properties.Resources.IconName;`

## Email Validation

- Check the EmailValidation Project

## Password Validation

- same as email validation but with different regex. `(?=^.{8,}$)((?=.*\d)|(?=.*\W+))(?![.\n])(?=.*[A-Z])(?=.*[a-z]).*$`
- to hide password set property `UseSystemPasswordChar` to true.
- To change `.` to `*` set `PasswordChar` property to*.

## Textbox Validation

### Digit Validation

```csharp
private void textbox1_KeyPress(object sender, KeyPressEventArgs e)
{
    char c = e.KeyChar;
    if (!char.IsDigit(c) && c != 8) // c=8 is backspace
    {
        e.Handled = true;
    }
    else 
    {
        e.Handled = false;
    }
}
```

- Set property `MaxLength` to limit the number of characters.

### Letter Validation

```csharp
private void textbox1_KeyPress(object sender, KeyPressEventArgs e)
{
    char c = e.KeyChar;
    if (!char.IsLetter(c) && c != 8 && c != 32) // c=8 is backspace and c=32 is space
    {
        e.Handled = true;
    }
    else 
    {
        e.Handled = false;
    }
}
```

### Both

```csharp
private void textbox1_KeyPress(object sender, KeyPressEventArgs e)
{
    char c = e.KeyChar;
    if (!char.IsLetterOrDigit(c) && c != 8 && c != 32) // c=8 is backspace and c=32 is space
    {
        e.Handled = true;
    }
    else 
    {
        e.Handled = false;
    }
}
```

## MySql Database

- Install MySql Workbench
- Add appsettings.json file to the project and add the connection string.

```json
{
  "ConnectionStrings": {
    "Default": "Default": "Server=127.0.0.1;Port=3306;Database=DatabaseName;Uid=root;Pwd=password;"
  }
}
```

- you can delete the `database=dbname` and store it to a variable to connect multiple databases for different users.
- change appsettings.json property to `copy if newer`.
- Install `Microsoft.Extensions.Configuration.Json` Nuget Package.
- To read the connection string from appsettings.json file:

```csharp

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
```

- Create DataAccessLibrary Project and add referece to the main project.
- Create two classes in DataAccessLibrary Project: `MySqlDataAccess` and `MySqlCrud`.
- Install `Dapper` and `MySql.Data` Nuget Package.
- MySqlDataAccess class:

```csharp
public class MySqlDataAccess
    {
        public List<T> LoadData<T, U>(string sqlStatement, U parameters, string connectionString)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                List<T> rows = connection.Query<T>(sqlStatement, parameters).ToList();
                return rows;
            }
        }

        public void SaveData<T>(string sqlStatement, T parameters, string connectionString)
        {
            using (IDbConnection connection = new MySqlConnection(connectionString))
            {
                connection.Execute(sqlStatement, parameters);
            }
        }
    }
```

- MySqlCrud class:

```csharp
public class MySqlCrud
    {
        private readonly string _connectionString;
        // Create an instance of the MySqlDataAccess class
        private MySqlDataAccess db = new MySqlDataAccess();

        // Constructor
        public MySqlCrud(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Get all contacts
        public List<BasicContactModel> GetAllContacts()
        {
            string sql = "select Id, FirstName, LastName from Contacts";

            return db.LoadData<BasicContactModel, dynamic>(sql, new { }, _connectionString);
        }

        // Get a contact by ID
        public FullContactModel GetFullContactById(int id)
        {
            string sql = "select Id, FirstName, LastName from Contacts where Id = @Id";
            FullContactModel output = new FullContactModel();

            output.BasicInfo = db.LoadData<BasicContactModel, dynamic>(sql, new { Id = id }, _connectionString).FirstOrDefault();

            if (output.BasicInfo == null)
            {
                // record not found
                return null;
            }

            sql = @"select e.*
                    from EmailAddresses e
                    inner join ContactEmail ce on ce.EmailAddressId = e.Id
                    where ce.ContactId = @Id";

            output.EmailAddresses = db.LoadData<EmailAddressModel, dynamic>(sql, new { Id = id }, _connectionString);


            sql = @"select p.*
                    from PhoneNumbers p
                    inner join ContactPhoneNumbers cp on cp.PhoneNumberId = p.Id
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
            string sql = @"insert into Contacts (FirstName, LastName)
                            values (@FirstName, @LastName);";
            db.SaveData(sql,
                        new { FirstName = contact.BasicInfo.FirstName, LastName = contact.BasicInfo.LastName }, _connectionString);

            // Get the ID from the contact
            sql = "select Id from Contacts where FirstName = @FirstName and LastName = @LastName";
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
                    sql = @"insert into PhoneNumbers (PhoneNumber)
                            values (@PhoneNumber);";
                    db.SaveData(sql, new { PhoneNumber = phoneNumber.PhoneNumber }, _connectionString);

                    sql = "select Id from PhoneNumbers where PhoneNumber = @PhoneNumber";
                    phoneNumber.Id = db.LoadData<IdLookupModel, dynamic>(sql, new { PhoneNumber = phoneNumber.PhoneNumber }, _connectionString).First().Id;
                }

                sql = @"insert into ContactPhoneNumbers (ContactId, PhoneNumberId)
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
                    sql = @"insert into EmailAddresses (EmailAddress)
                            values (@EmailAddress);";
                    db.SaveData(sql, new { EmailAddress = email.EmailAddress }, _connectionString);

                    sql = "select Id from EmailAddresses where EmailAddress = @EmailAddress";
                    email.Id = db.LoadData<IdLookupModel, dynamic>(sql, new { EmailAddress = email.EmailAddress }, _connectionString).First().Id;
                }

                sql = @"insert into ContactEmail (ContactId, EmailAddressId)
                        values (@ContactId, @EmailAddressId);";
                db.SaveData(sql, new { ContactId = contactId, EmailAddressId = email.Id }, _connectionString);
            }


        }

        // Update FirstName and LastName of a contact
        public void UpdateContactName(BasicContactModel contact)
        {
            string sql = @"update Contacts
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
                            from ContactPhoneNumbers
                            where PhoneNumberId = @PhoneNumberId";
            var links = db.LoadData<ContactPhoneNumberModel, dynamic>(sql, new { PhoneNumberId = phoneNumberId }, _connectionString);

            sql = @"delete from ContactPhoneNumbers
                        where PhoneNumberId = @PhoneNumberId and ContactId = @ContactId";
            db.SaveData(sql, new { PhoneNumberId = phoneNumberId, ContactId = contactId }, _connectionString);

            if (links.Count == 1)
            {
                sql = @"delete from PhoneNumbers
                        where Id = @PhoneNumberId";
                db.SaveData(sql, new { PhoneNumberId = phoneNumberId }, _connectionString);
            }
        }
    }
```

- Create a model folder in DataAccessLibrary Project and add models to it.
- Some Models:
- BasicContactModel.cs

```csharp
public class BasicContactModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
```

- EmailAddressModel.cs

```csharp
public class EmailAddressModel
    {
        public int Id { get; set; }
        public string EmailAddress { get; set; }
    }
```

- PhoneNumberModel.cs

```csharp
public class PhoneNumberModel
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
    }
```

- ContactPhoneNumberModel.cs
  
```csharp
public class ContactPhoneNumberModel
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        public string PhoneNumberId { get; set; }
    }
```

- FullContactModel.cs

```csharp
public class FullContactModel
    {
        public BasicContactModel BasicInfo { get; set; }
        public List<EmailAddressModel> EmailAddresses { get; set; } = new List<EmailAddressModel>();
        public List<PhoneNumberModel> PhoneNumbers { get; set; } = new List<PhoneNumberModel>();
    }
```

- IdLookupModel.cs
  
```csharp
public class IdLookupModel
    {
        public int Id { get; set; }
    }
```

- In the main program connect database like this:

```csharp
MySqlCrud sql = new MySqlCrud(GetConnectionString());
```

- Some Functions in the main Program

```csharp
        // Create new contact
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
```

### MYSQL Commands

- Sql commands to create database:

```sql
CREATE SCHEMA `users`;
```

- Sql commands to create tables:

```sql
CREATE TABLE `users`.`user_table` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Username` VARCHAR(200) NOT NULL,
  `MasterPassword` VARCHAR(300) NOT NULL,
  `Email` VARCHAR(300) NOT NULL,
  `User_Database` VARCHAR(300) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE INDEX `Id_UNIQUE` (`Id` ASC) VISIBLE,
  UNIQUE INDEX `Username_UNIQUE` (`Username` ASC) VISIBLE,
  UNIQUE INDEX `Email_UNIQUE` (`Email` ASC) VISIBLE);
```

- Insert data into the table:

```sql
Insert INTO users.user_table(Username, MasterPassword, Email, User_Database) values("demo", "Pass123#", "demo@gmail.com", "demo_db");
```
